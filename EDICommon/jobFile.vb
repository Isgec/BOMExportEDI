Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports System.Xml.Serialization
Public Class JobFiles
  Implements IDisposable

  Public Property LstJobFiles As List(Of jobFile) = Nothing
  Sub New()
    LstJobFiles = New List(Of jobFile)
  End Sub

#Region "IDisposable Support"
  Private disposedValue As Boolean ' To detect redundant calls

  ' IDisposable
  Protected Overridable Sub Dispose(disposing As Boolean)
    If Not disposedValue Then
      If disposing Then
        ' TODO: dispose managed state (managed objects).
        For Each x As jobFile In LstJobFiles
          x = Nothing
        Next
        LstJobFiles = Nothing
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
<DataObject()>
<Serializable>
Public Class lgErrors
  Implements ICloneable
  Public Function Clone() As Object Implements ICloneable.Clone
    Return MyBase.MemberwiseClone()
  End Function
  Public Property ErrDetail As String = ""
  Sub New(ByVal errMsg As String)
    ErrDetail = errMsg
  End Sub
  Sub New()
    'dummy
  End Sub
End Class
<DataObject()> <Serializable>
Public Class jobFile
  Implements ICloneable
  Public Function Clone() As Object Implements ICloneable.Clone
    Return MyBase.MemberwiseClone()
  End Function

  'Derived Properties
  Public Property ProjectID As String = ""
  Public Property CardNo As String = ""
  Public Property IsValid As Boolean = False
  Public Property IsComponentXL As Boolean = False
  Public Property IsMCD As Boolean = False
  Public Property IsDWG As Boolean = False
  Public Property JobFileName As String = ""
  Public Property JobPathFileName As String = ""
  Public Property IsError As Boolean = False
  Public Property ErrorList As New List(Of lgErrors)
  Public Property SerializedPath As String = ""
  Public Property IsTitleBlockFound As Boolean = False
  Public Property IsPDFCreated As Boolean = False
  Public Property IsXMLGenerated As Boolean = False
  Public Property IsComponentXLFound As Boolean = False
  Public Property IsMCDFound As Boolean = False
  'Public Property UnknownError As Boolean = False
  Public Property VaultFolderID As Long = 0
  Public Property ComponentXLFileName As String = ""
  Public Property ComponentXLData As DrawingData = Nothing
  Public Property MCDFileName As String = ""
  Public Property MCDxData As DrawingData = Nothing
  Public Property OtherFileName As String = ""
  Public Property ForOtherFile As Boolean = False
  'Main Properties
  Public Property FileID As String = ""
  Public Property FileName As String = ""
  Public Property UserID As String = ""
  Public Property VaultDB As String = ""
  Public Property ClientVersion As String = ""
  Public Property ClientMachineName As String = ""
  Public Property JobCreationDate As String = ""
  Public Property JobCreationTime As String = ""
  Public Shared Function SelectList(ByVal JobPath As String) As List(Of jobFile)
    Dim tmp As New List(Of jobFile)
    Dim aFiles() As String = IO.Directory.GetFiles(JobPath, "*.job", IO.SearchOption.TopDirectoryOnly)
    If aFiles.Length > 0 Then
      For Each tmpFile As String In aFiles
        tmp.Add(GetFile(tmpFile))
      Next
    End If
    Return tmp
  End Function
  Public Shared Function GetFile(ByVal FilePath As String) As jobFile
    Dim tmp As jobFile = Nothing
    If IO.File.Exists(FilePath) Then
      tmp = New jobFile()
      Dim tr As IO.StreamReader = New IO.StreamReader(FilePath)
      Dim str As String = tr.ReadLine
      Do While str IsNot Nothing
        With tmp
          If str.StartsWith("[FileID]", StringComparison.OrdinalIgnoreCase) Then
            .FileID = str.Replace("[FileID]", "")
          ElseIf str.StartsWith("[FileName]", StringComparison.OrdinalIgnoreCase) Then
            .FileName = str.Replace("[FileName]", "")
            .ProjectID = .FileName.Substring(0, 6)
          ElseIf str.StartsWith("[UserID]", StringComparison.OrdinalIgnoreCase) Then
            .UserID = str.Replace("[UserID]", "").Replace(" ", "").Replace("ISGECNET\", "")
          ElseIf str.StartsWith("[VaultDB]", StringComparison.OrdinalIgnoreCase) Then
            .VaultDB = str.Replace("[VaultDB]", "")
          ElseIf str.StartsWith("[ClientVersion]", StringComparison.OrdinalIgnoreCase) Then
            .ClientVersion = str.Replace("[ClientVersion]", "")
          ElseIf str.StartsWith("[ClientMachineName]", StringComparison.OrdinalIgnoreCase) Then
            .ClientMachineName = str.Replace("[ClientMachineName]", "")
            .CardNo = .ClientMachineName.Substring(0, 4)
          ElseIf str.StartsWith("[JobCreationDate]", StringComparison.OrdinalIgnoreCase) Then
            .JobCreationDate = str.Replace("[JobCreationDate]", "")
          ElseIf str.StartsWith("[JobCreationTime]", StringComparison.OrdinalIgnoreCase) Then
            .JobCreationTime = str.Replace("[JobCreationTime]", "")
          End If
        End With
        str = tr.ReadLine
      Loop
      tr.Close()
    End If
    'Initialize Derived Properties
    tmp.JobFileName = IO.Path.GetFileName(FilePath)
    tmp.JobPathFileName = FilePath
    Try
      tmp.IsValid = IsValidFile(tmp.FileName)
      tmp.IsComponentXL = IsComponentFile(tmp.FileName)
      tmp.IsMCD = IsMCDFile(tmp.FileName)
      tmp.IsDWG = IIf(IO.Path.GetExtension(tmp.FileName).ToUpper = ".DWG", True, False)
    Catch ex As Exception
    End Try
    Return tmp
  End Function
  Private Shared Function IsMCDFile(ByVal FileName As String) As Boolean
    Dim mRet As Boolean = False
    Dim tmp As String = IO.Path.GetFileNameWithoutExtension(FileName)
    Dim r As RegularExpressions.Regex = New RegularExpressions.Regex("^[a-zA-Z0-9]{6}-[0-9]{8}-MCD-[0-9A-Za-z]{3}")
    If Not r.IsMatch(tmp) Or (Not FileName.ToUpper.EndsWith("XLS") And Not FileName.ToUpper.EndsWith("XLSX")) Then
    Else
      mRet = True
    End If
    Return mRet
  End Function
  Private Shared Function IsComponentFile(ByVal FileName As String) As Boolean
    Dim mRet As Boolean = False
    If Not FileName.ToUpper.Contains("-MCD-") Then
      If FileName.ToUpper.EndsWith("XLS") Or FileName.ToUpper.EndsWith("XLSX") Then
        mRet = True
      End If
    End If
    Return mRet
  End Function
  Private Shared Function IsValidFile(ByVal FileName As String) As Boolean
    Dim mRet As Boolean = False
    Dim r As RegularExpressions.Regex = Nothing
    Dim tmp As String = IO.Path.GetFileNameWithoutExtension(FileName)
    If FileName.ToUpper.Contains("-MCD-") Then
      r = New RegularExpressions.Regex("^[a-zA-Z0-9]{6}-[0-9]{8}-MCD-[0-9A-Za-z]{3}")
    Else
      r = New RegularExpressions.Regex("^[a-zA-Z0-9]{6}-[0-9]{8}-[0-9A-Za-z]{3}-[0-9]{3}")
    End If
    mRet = r.IsMatch(tmp)
    Return mRet
  End Function
  Public Shared Function Serialize(ByVal job As jobFile) As jobFile
    Return Serialize(job.SerializedPath, job)
  End Function
  Public Shared Function Serialize(ByVal TargetPath As String, ByVal job As jobFile) As jobFile
    Dim FileName As String = TargetPath & "\" & IO.Path.GetFileNameWithoutExtension(IIf(job.ForOtherFile, job.OtherFileName, job.FileName)) & ".slz"
    job.SerializedPath = FileName
    Dim oSrz As XmlSerializer = New XmlSerializer(job.GetType)
    Dim oSW As IO.StreamWriter = New IO.StreamWriter(FileName)
    oSrz.Serialize(oSW, job)
    oSW.Close()
    Return job
  End Function
  Public Shared Function DeSerialize(Optional ByVal job As jobFile = Nothing, Optional ByVal SerializedAt As String = "") As jobFile
    Dim FileName As String = ""
    If job IsNot Nothing Then
      FileName = job.SerializedPath
    Else
      FileName = SerializedAt
    End If
    If IO.File.Exists(FileName) Then
      job = New jobFile
      Dim oFS As IO.FileStream = New IO.FileStream(FileName, IO.FileMode.Open)
      Dim oSrz As XmlSerializer = New XmlSerializer(job.GetType)
      job = CType(oSrz.Deserialize(oFS), jobFile)
      oFS.Close()
    End If
    Return job
  End Function

  Public Sub New()
    'Dummy
  End Sub
End Class
