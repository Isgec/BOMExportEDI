Imports System.Xml
Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Text

Imports System.Windows.Forms
Imports EDICommon
Public Class JobProcessor
  Inherits TimerSupport
  Implements IDisposable

  Public Property jpConfig As ConfigFile = Nothing
  Public Event JobStarted()
  Public Event JobStopped()
  Public Event ProcessedFile(ByVal slzFile As String)
  Private cad As cadUtility = Nothing
  Private vlt As vltUtility = Nothing
  Private lst As ListBox = Nothing
  Private lbl As Label = Nothing
  Delegate Sub showMsg(ByVal str As String)

  Public Sub msg(ByVal str As String)
    If lbl.InvokeRequired Then
      lbl.Invoke(New showMsg(AddressOf sMsg), str)
    End If
  End Sub
  Public Sub sMsg(ByVal str As String)
    'lst.Items.Insert(0, str)
    lst.Items.Add(str)
    lbl.Text = str
  End Sub
  Public Overrides Sub Process()
    Try
      Dim I As Integer = 0
      Dim Jobs As List(Of jobFile) = jobFile.SelectList(jpConfig.JobPath)
      If Jobs.Count > 0 Then
        msg("Total Jobs: " & Jobs.Count)
      End If
      For Each tmpJob As jobFile In Jobs
        I += 1
        msg(I & ".====================")
        '==========================
        Try
          tmpJob = ProcessJobFile(tmpJob)
          RaiseEvent ProcessedFile(tmpJob.SerializedPath)
        Catch ex As Exception
          msg(ex.Message)
          If IO.File.Exists(jpConfig.JobPathError & "\" & tmpJob.JobFileName) Then
            IO.File.Delete(jpConfig.JobPathError & "\" & tmpJob.JobFileName)
          End If
          IO.File.Move(tmpJob.JobPathFileName, jpConfig.JobPathError & "\" & tmpJob.JobFileName)
        End Try
        '==========================
        If Not tmpJob.IsError Then
          If IO.File.Exists(jpConfig.JobPathProcessed & "\" & tmpJob.JobFileName) Then
            IO.File.Delete(jpConfig.JobPathProcessed & "\" & tmpJob.JobFileName)
          End If
          IO.File.Move(tmpJob.JobPathFileName, jpConfig.JobPathProcessed & "\" & tmpJob.JobFileName)
        Else
          Try
            SendMail(tmpJob)
          Catch ex As Exception
          End Try
          If IO.File.Exists(jpConfig.JobPathError & "\" & tmpJob.JobFileName) Then
            IO.File.Delete(jpConfig.JobPathError & "\" & tmpJob.JobFileName)
          End If
          IO.File.Move(tmpJob.JobPathFileName, jpConfig.JobPathError & "\" & tmpJob.JobFileName)
        End If
        If IsStopping Then
          msg("Cancelled")
          Exit For
        End If
      Next
    Catch ex As Exception
      msg(ex.Message)
    End Try
  End Sub
  Private Function ProcessJobFile(ByVal tmpJob As jobFile) As jobFile
    If Not tmpJob.IsValid Then
      With tmpJob
        .IsError = True
        .ErrorList.Add(New lgErrors("Invalid File Name in Job."))
      End With
      msg("Invalid Job File.")
      Return tmpJob
    End If
    '1. DWG
    If tmpJob.IsDWG Then
      msg("Processing for drawing file.")
      tmpJob = vlt.DownloadMain(tmpJob)
      If Not tmpJob.IsError Then
        msg("Extracting BOM & PDF")
        tmpJob = cad.ExtractBOMPDF(tmpJob)
        If tmpJob.IsPDFCreated Then
          msg("PDF file created.")
          If Not tmpJob.IsXMLGenerated Then
            If Not tmpJob.IsTitleBlockFound Then
              msg("Title Block NOT Found. Searching Component XL")
              tmpJob = vlt.DownloadComponentXL(tmpJob)
              If Not tmpJob.IsError Then
                msg("Creating XML file from component XL.")
                DrawingData.WriteXMLDocument(tmpJob.ComponentXLData, tmpJob, jpConfig.XMLFolderPath & "\" & IO.Path.GetFileNameWithoutExtension(tmpJob.FileName) & ".xml", jpConfig.TempFolderPath)
              Else
                'MCD Process
                msg("Component XL NOT Found, searching MCD files.")
                tmpJob = vlt.DownloadMCD(tmpJob)
                If Not tmpJob.IsError Then
                  msg("Creating XML file from MCD.")
                  DrawingData.WriteXMLDocument(tmpJob.MCDxData, tmpJob, jpConfig.XMLFolderPath & "\" & IO.Path.GetFileNameWithoutExtension(tmpJob.FileName) & ".xml", jpConfig.TempFolderPath)
                End If
              End If
            End If
          Else
            msg("XML file created.")
          End If
        End If
      Else
        msg("Error during processing Job File: " & tmpJob.JobFileName)
      End If
    End If
    '2. XL File
    If tmpJob.IsComponentXL Then
      msg("Processing for component XL. Downloading file.")
      tmpJob = vlt.DownloadMain(tmpJob)
      msg("xData to check if itself is component XL")
      Dim xData As List(Of DrawingData) = xlConverter.GetDrawingData(jpConfig.TempFolderPath & "\" & tmpJob.FileName)
      If xData.Count <= 0 Then
        msg("This is NOT Component File but XL is Document File")
        msg("Searching for component file.")
        tmpJob = vlt.DownloadComponentXL(tmpJob)
        If Not tmpJob.IsError Then
          msg("Creating XML & PDF file from component XL.")
          DrawingData.WriteXMLDocument(tmpJob.ComponentXLData, tmpJob, jpConfig.XMLFolderPath & "\" & IO.Path.GetFileNameWithoutExtension(tmpJob.FileName) & ".xml", jpConfig.TempFolderPath)
          pdfWriter.generateXLPDF({jpConfig.TempFolderPath & "\" & tmpJob.FileName}.ToList, jpConfig.PDFFolderPath)
        Else
          msg("Searching ALL MCD files.")
          'TO DO-Check in All MCD
          tmpJob = vlt.DownloadMCD(tmpJob)
          If Not tmpJob.IsError Then
            msg("Creating XML & PDF file from MCD.")
            DrawingData.WriteXMLDocument(tmpJob.MCDxData, tmpJob, jpConfig.XMLFolderPath & "\" & IO.Path.GetFileNameWithoutExtension(tmpJob.FileName) & ".xml", jpConfig.TempFolderPath)
            pdfWriter.generateXLPDF({jpConfig.TempFolderPath & "\" & tmpJob.FileName}.ToList, jpConfig.PDFFolderPath)
          End If
        End If
      Else
        msg("This is Component File.")
        For Each tmpX As DrawingData In xData
          msg("Download file, convert to PDF and generate xml")
          For Each tmpData As DrawingData In xData
            tmpJob = vlt.DownloadxData(tmpJob, tmpX)
            If Not tmpJob.IsError Then
              msg("Creating XML File.")
              DrawingData.WriteXMLDocument(tmpX, tmpJob, jpConfig.XMLFolderPath, jpConfig.TempFolderPath)
              If IO.Path.GetExtension(tmpX.DrawingFileName).ToUpper <> ".DWG" Then
                msg("Creating PDF of drawing file.")
                pdfWriter.generatePDF(jpConfig.TempFolderPath & "\" & tmpX.DrawingFileName, jpConfig.PDFFolderPath)
              Else
                msg("Creating PDF of listed file.")
                tmpJob.ForOtherFile = True
                tmpJob.OtherFileName = tmpX.DrawingFileName
                tmpJob = cad.ExtractPDF(tmpJob)
              End If
            End If
          Next
        Next
      End If
    End If
    '3. MCD File
    If tmpJob.IsMCD Then
      msg("Downloading MCD file")
      tmpJob = vlt.DownloadMain(tmpJob)
      Dim xData As List(Of DrawingData) = xlConverter.GetDrawingData(jpConfig.TempFolderPath & "\" & tmpJob.FileName)
      Dim AllFilesFoundInVault As Boolean = True
      msg("Checking all files available in vault.")
      For Each tmpX As DrawingData In xData
        msg("Downloading: " & tmpX.DrawingFileName)
        tmpJob = vlt.DownloadxData(tmpJob, tmpX)
        If tmpJob.IsError Then
          AllFilesFoundInVault = False
          tmpJob.ErrorList.Add(New lgErrors(tmpX.DrawingFileName & " NOT Found, or Checked out."))
        End If
      Next
      If Not AllFilesFoundInVault Then
        msg("All files not found in Vault.")
        tmpJob.ErrorList.Add(New lgErrors("All files not available in vault."))
        tmpJob.IsError = True
      Else
        msg("MCD processing for :" & xData.Count & " files.")
        For Each tmpX As DrawingData In xData
          msg("Downloading and generating XML & PDF: " & tmpX.DrawingFileName)
          DrawingData.WriteXMLDocument(tmpX, tmpJob, jpConfig.XMLFolderPath, jpConfig.TempFolderPath)
          msg("XML generated." & tmpX.DrawingFileName)
          If IO.Path.GetExtension(tmpX.DrawingFileName).ToUpper <> ".DWG" Then
            pdfWriter.generatePDF(jpConfig.TempFolderPath & "\" & tmpX.DrawingFileName, jpConfig.PDFFolderPath)
          Else
            tmpJob.ForOtherFile = True
            tmpJob.OtherFileName = tmpX.DrawingFileName
            tmpJob = cad.ExtractPDF(tmpJob)
          End If
          msg("PDF generated." & tmpX.DrawingFileName)
        Next
        msg("MCD " & xData.Count & " files Processed.")
      End If
    End If
    Return tmpJob
  End Function

  Public Overrides Sub Started()
    msg("Checking Configuration.")
    Try
      If Not IO.Directory.Exists(jpConfig.JobPathError) Then
        IO.Directory.CreateDirectory(jpConfig.JobPathError)
      End If
      If Not IO.Directory.Exists(jpConfig.JobPathProcessed) Then
        IO.Directory.CreateDirectory(jpConfig.JobPathProcessed)
      End If
      If Not IO.Directory.Exists(jpConfig.JobPathWorking) Then
        IO.Directory.CreateDirectory(jpConfig.JobPathWorking)
      End If
    Catch ex As Exception
    End Try
    cad = New cadUtility
    cad.jp = Me
    cad.jpConfig = jpConfig
    msg("Loading CAD")
    cad.LoadCad()
    msg("Connecting Vault")
    vlt = New vltUtility(jpConfig.VaultServer, jpConfig.VaultUserName, jpConfig.VaultUserPassword)
    vlt.jp = Me
    vlt.jpConfig = jpConfig
    RaiseEvent JobStarted()
  End Sub

  Public Overrides Sub Stopped()
    cad.UnloadCad()
    vlt.jpConfig = Nothing
    vlt = Nothing
    RaiseEvent JobStopped()
  End Sub

  Public Shared Function IsFileAvailable(ByVal FilePath As String) As Boolean
    If Not IO.File.Exists(FilePath) Then Return False
    Dim fInfo As IO.FileInfo = Nothing
    Dim st As IO.FileStream = Nothing
    Try
      fInfo = New IO.FileInfo(FilePath)
    Catch ex As Exception
      Return False
    End Try
    Dim ret As Boolean = False
    If fInfo.IsReadOnly Then
      If DateDiff(DateInterval.Minute, fInfo.CreationTime, Now) >= 1 Then
        fInfo.IsReadOnly = False
      End If
    End If
    Try
      st = fInfo.Open(IO.FileMode.Open, IO.FileAccess.ReadWrite, IO.FileShare.None)
      ret = True
    Catch ex As Exception
      ret = False
    Finally
      If st IsNot Nothing Then
        st.Close()
      End If
    End Try
    Return ret
  End Function
  Sub New(ByVal lt As ListBox, ByVal lb As Label)
    lst = lt
    lbl = lb
  End Sub

  Sub New()
    'dummy
  End Sub

  Public Shared Sub SendMail(ByVal fl As jobFile)
    Dim emailIDError As Boolean = False
    Dim ToEMailID As String = ""
    Try
      ToEMailID = GetMailID(fl.CardNo)
    Catch ex As Exception
      ToEMailID = "baansupport@isgec.co.in"
      emailIDError = True
    End Try
    Try
      Dim oClient As SmtpClient = New SmtpClient("192.9.200.214", 25)
      oClient.Credentials = New Net.NetworkCredential("adskvaultadmin", "isgec@123")
      Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
      oMsg.From = New System.Net.Mail.MailAddress("Error IN Transfer Vault To ERPLN<adskvaultadmin@isgec.co.in>")
      With oMsg
        If ToEMailID <> String.Empty Then
          .To.Add(ToEMailID)
        End If
        .To.Add("adskvaultadmin@isgec.co.in")
        .CC.Add("harishkumar@isgec.co.in")
        .IsBodyHtml = True
        .Subject = fl.FileName & " Not Transfered in BaaN"
        Dim tmpStr As String = ""
        If emailIDError Then
          tmpstr = "E-Mail Address Not found for Vault User : " & fl.CardNo
          tmpStr &= "<br/> Job File Name : " & fl.JobFileName
          tmpStr &= "<br/> Client Machine Name : " & fl.ClientMachineName
          .Body = tmpStr
        End If
        tmpstr = ""
        For Each str As lgErrors In fl.ErrorList
          tmpstr &= "<br/>" & str.ErrDetail
        Next
        .Body = .Body & tmpStr
      End With
      'If Not SIS.SYS.SQLDatabase.DBCommon.Testing Then
      oClient.Send(oMsg)
      'End If
    Catch ex As Exception
    End Try
  End Sub

  Public Shared Function GetMailID(ByVal LoginID As String) As String
    Dim _Result As String = ""
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
      Using Cmd As SqlCommand = Con.CreateCommand()
        Dim mSql As String = "SELECT TOP 1 EMailID FROM HRM_Employees WHERE CardNo = '" & LoginID & "'"
        Cmd.CommandType = System.Data.CommandType.Text
        Cmd.CommandText = mSql
        Con.Open()
        _Result = Cmd.ExecuteScalar()
        If _Result IsNot Nothing Then
          If Convert.IsDBNull(_Result) Then
            _Result = ""
          End If
        Else
          _Result = ""
        End If
      End Using
    End Using
    Return _Result
  End Function

#Region "IDisposable Support"
  Private disposedValue As Boolean ' To detect redundant calls

  ' IDisposable
  Protected Overridable Sub Dispose(disposing As Boolean)
    If Not disposedValue Then
      If disposing Then
        ' TODO: dispose managed state (managed objects).
        lst.Dispose()
        lbl.Dispose()
      End If

      ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
      ' TODO: set large fields to null.
    End If
    disposedValue = True
  End Sub

  ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
  'Protected Overrides Sub Finalize()
  '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
  '    Dispose(False)
  '    MyBase.Finalize()
  'End Sub

  ' This code added by Visual Basic to correctly implement the disposable pattern.
  Public Sub Dispose() Implements IDisposable.Dispose
    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
    Dispose(True)
    ' TODO: uncomment the following line if Finalize() is overridden above.
    ' GC.SuppressFinalize(Me)
  End Sub
#End Region
End Class
