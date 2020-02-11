Imports EDICommon
Public Class frmMain
  Delegate Sub ThreadedSub(ByVal lt As ListBox, ByVal lb As Label)
  Delegate Sub ThreadedShow(ByVal slzFile As String)
  Delegate Sub ThreadedNone()
  Private dsM As New EDICommon.JobFiles
  Dim WithEvents jp As JobProcess.JobProcessor = Nothing
  Private Sub cmdStart_Click(sender As Object, e As EventArgs) Handles cmdStart.Click
    cmdStart.Enabled = False
    cmdStart.Text = "Loading..."
    ListBox1.Items.Clear()
    BindingSource1.DataSource = Nothing
    Dim tmp As ThreadedSub = AddressOf Start
    tmp.BeginInvoke(ListBox1, Label1, Nothing, Nothing)
  End Sub
  Private Sub Start(ByVal lt As ListBox, ByVal lb As Label)
    jp = New JobProcess.JobProcessor(lt, lb)
    jp.jpConfig = ConfigFile.GetFile(Application.StartupPath & "\Settings.xml")
    jp.jpConfig.StartupPath = Application.StartupPath
    jp.Start()
  End Sub

  Private Sub cmdStop_Click(sender As Object, e As EventArgs) Handles cmdStop.Click
    cmdStop.Enabled = False
    cmdStop.Text = "Closing..."
    jp.StopJob()
  End Sub

  Private Sub jp_JobStarted() Handles jp.JobStarted
    If cmdStart.InvokeRequired Then
      cmdStart.Invoke(New ThreadedNone(AddressOf jp_JobStarted))
    Else
      cmdStart.Enabled = False
      cmdStart.Text = "Start"
      cmdStop.Enabled = True
      dsM = New EDICommon.JobFiles
      BindingSource1.DataMember = "LstJobFiles"
      BindingSource1.DataSource = dsM
      DataGridView1.DataSource = BindingSource1
      BindingSource2.DataMember = "ErrorList"
      BindingSource2.DataSource = BindingSource1
      DataGridView2.DataSource = BindingSource2
    End If
  End Sub
  Private Sub jp_JobStopped() Handles jp.JobStopped
    If cmdStop.InvokeRequired Then
      cmdStop.Invoke(New ThreadedNone(AddressOf jp_JobStopped))
    Else
      cmdStop.Enabled = False
      cmdStop.Text = "Stop"
      cmdStart.Enabled = True
    End If
  End Sub

  Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
    'Dim items() As String = ListBox1.Items.Cast(Of Object).Select(Function(o) ListBox1.GetItemText(o)).ToArray
    'F_Search.AutoCompleteCustomSource = ListBox1.Items.
    'CheckForIllegalCrossThreadCalls = False
    Dim tmp() As String = IO.Path.GetDirectoryName(Application.StartupPath).Split("\".ToCharArray)
    Me.Text = "[" & tmp(tmp.Length - 1) & "]-" & Me.Text
  End Sub

  Private Sub cmdCache_Click(sender As Object, e As EventArgs) Handles cmdCache.Click
    dsM = New EDICommon.JobFiles
    Dim Location As String = ""
    If jp IsNot Nothing Then
      Location = jp.jpConfig.JobPathWorking
    Else
      Location = ConfigFile.GetFile(Application.StartupPath & "\Settings.xml").JobPathWorking
    End If
    Dim tmpFiles() As String = IO.Directory.GetFiles(Location, "*.slz", IO.SearchOption.TopDirectoryOnly)
    For Each tmpStr As String In tmpFiles
      dsM.LstJobFiles.Add(jobFile.DeSerialize(Nothing, tmpStr))
    Next
    BindingSource1.DataMember = "LstJobFiles"
    BindingSource1.DataSource = dsM
    DataGridView1.DataSource = BindingSource1
    BindingSource2.DataMember = "ErrorList"
    BindingSource2.DataSource = BindingSource1
    DataGridView2.DataSource = BindingSource2
    BindingSource1.ResetBindings(True)
    DataGridView1.Refresh()
  End Sub

  Private Sub jp_ProcessedFile(slzFile As String) Handles jp.ProcessedFile
    If DataGridView1.InvokeRequired Then
      DataGridView1.Invoke(New ThreadedShow(AddressOf RefreshGrids), slzFile)
    End If
  End Sub
  Private Sub RefreshGrids(ByVal slzFile As String)
    If DataGridView2.InvokeRequired Then
      DataGridView2.Invoke(New ThreadedShow(AddressOf RefreshGrids), slzFile)
    Else
      dsM.LstJobFiles.Add(jobFile.DeSerialize(Nothing, slzFile))
      BindingSource1.ResetBindings(True)
      DataGridView1.Refresh()
    End If
  End Sub

  Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
    Try
      'Dim xData As List(Of DrawingData) = JobProcess.xlConverter.GetDrawingData("d:\mcd.xlsx")
      Dim tmp As New List(Of String)
      tmp.Add("d:\temp\abc.xlsx")

      pdfWriter.generateXLPDF(tmp, "d:\temp\abc.pdf")
    Catch ex As Exception
    End Try
  End Sub

  Private Sub cmdF_Click(sender As Object, e As EventArgs) Handles cmdF.Click
    Try
      ListBox1.SetSelected(ListBox1.FindString(F_Search.Text, ListBox1.SelectedIndex), True)
    Catch ex As Exception
    End Try
  End Sub

  Private Sub F_Search_KeyPress(sender As Object, e As KeyPressEventArgs) Handles F_Search.KeyPress
    If e.KeyChar = Chr(13) Then
      Try
        Dim StartFrom As Integer = 0
        Try
          StartFrom = ListBox1.SelectedIndex
        Catch ex As Exception
        End Try
        For I As Integer = StartFrom To ListBox1.Items.Count - 1
          If ListBox1.Items(I).ToString.ToLower.IndexOf(F_Search.Text.ToLower) > -1 Then
            ListBox1.SetSelected(I, True)
            Exit For
          End If
        Next
      Catch ex As Exception
      End Try
    End If
  End Sub
End Class
