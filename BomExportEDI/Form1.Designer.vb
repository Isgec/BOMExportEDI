<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
  Inherits System.Windows.Forms.Form

  'Form overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()>
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()>
  Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.split1 = New System.Windows.Forms.SplitContainer()
    Me.cmdF = New System.Windows.Forms.Button()
    Me.F_Search = New System.Windows.Forms.TextBox()
    Me.cmdCache = New System.Windows.Forms.Button()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.cmdStop = New System.Windows.Forms.Button()
    Me.cmdStart = New System.Windows.Forms.Button()
    Me.split2 = New System.Windows.Forms.SplitContainer()
    Me.ListBox1 = New System.Windows.Forms.ListBox()
    Me.split3 = New System.Windows.Forms.SplitContainer()
    Me.DataGridView1 = New System.Windows.Forms.DataGridView()
    Me.FileNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.CardNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.ProjectIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.IsValidDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
    Me.IsComponentXLDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
    Me.IsMCDDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
    Me.IsDWGDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
    Me.JobFileNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.JobPathFileNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.IsErrorDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
    Me.SerializedPathDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.IsTitleBlockFoundDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
    Me.IsPDFCreatedDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
    Me.IsXMLGeneratedDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
    Me.IsComponentXLFoundDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
    Me.IsMCDFoundDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
    Me.VaultFolderIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.ComponentXLFileNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.ComponentXLDataDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.MCDFileNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.MCDxDataDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.OtherFileNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.ForOtherFileDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
    Me.FileIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.UserIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.VaultDBDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.ClientVersionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.ClientMachineNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.JobCreationDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.JobCreationTimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
    Me.DataGridView2 = New System.Windows.Forms.DataGridView()
    Me.ErrDetailDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.BindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
    CType(Me.split1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.split1.Panel1.SuspendLayout()
    Me.split1.Panel2.SuspendLayout()
    Me.split1.SuspendLayout()
    CType(Me.split2, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.split2.Panel1.SuspendLayout()
    Me.split2.Panel2.SuspendLayout()
    Me.split2.SuspendLayout()
    CType(Me.split3, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.split3.Panel1.SuspendLayout()
    Me.split3.Panel2.SuspendLayout()
    Me.split3.SuspendLayout()
    CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.BindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'split1
    '
    Me.split1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.split1.Location = New System.Drawing.Point(0, 0)
    Me.split1.Name = "split1"
    Me.split1.Orientation = System.Windows.Forms.Orientation.Horizontal
    '
    'split1.Panel1
    '
    Me.split1.Panel1.Controls.Add(Me.cmdF)
    Me.split1.Panel1.Controls.Add(Me.F_Search)
    Me.split1.Panel1.Controls.Add(Me.cmdCache)
    Me.split1.Panel1.Controls.Add(Me.Label1)
    Me.split1.Panel1.Controls.Add(Me.cmdStop)
    Me.split1.Panel1.Controls.Add(Me.cmdStart)
    '
    'split1.Panel2
    '
    Me.split1.Panel2.Controls.Add(Me.split2)
    Me.split1.Size = New System.Drawing.Size(354, 255)
    Me.split1.SplitterDistance = 77
    Me.split1.TabIndex = 2
    '
    'cmdF
    '
    Me.cmdF.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.cmdF.Location = New System.Drawing.Point(299, 55)
    Me.cmdF.Name = "cmdF"
    Me.cmdF.Size = New System.Drawing.Size(45, 20)
    Me.cmdF.TabIndex = 7
    Me.cmdF.Text = ". . ."
    Me.cmdF.UseVisualStyleBackColor = True
    '
    'F_Search
    '
    Me.F_Search.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.F_Search.Location = New System.Drawing.Point(3, 55)
    Me.F_Search.Name = "F_Search"
    Me.F_Search.Size = New System.Drawing.Size(289, 20)
    Me.F_Search.TabIndex = 6
    '
    'cmdCache
    '
    Me.cmdCache.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.cmdCache.Location = New System.Drawing.Point(353, 52)
    Me.cmdCache.Name = "cmdCache"
    Me.cmdCache.Size = New System.Drawing.Size(134, 23)
    Me.cmdCache.TabIndex = 5
    Me.cmdCache.Text = "Show Processed Jobs"
    Me.cmdCache.UseVisualStyleBackColor = True
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(7, 32)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(50, 13)
    Me.Label1.TabIndex = 4
    Me.Label1.Text = "Message"
    '
    'cmdStop
    '
    Me.cmdStop.Enabled = False
    Me.cmdStop.Location = New System.Drawing.Point(111, 6)
    Me.cmdStop.Name = "cmdStop"
    Me.cmdStop.Size = New System.Drawing.Size(75, 23)
    Me.cmdStop.TabIndex = 3
    Me.cmdStop.Text = "Stop"
    Me.cmdStop.UseVisualStyleBackColor = True
    '
    'cmdStart
    '
    Me.cmdStart.Location = New System.Drawing.Point(10, 6)
    Me.cmdStart.Name = "cmdStart"
    Me.cmdStart.Size = New System.Drawing.Size(75, 23)
    Me.cmdStart.TabIndex = 2
    Me.cmdStart.Text = "Start"
    Me.cmdStart.UseVisualStyleBackColor = True
    '
    'split2
    '
    Me.split2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.split2.Location = New System.Drawing.Point(0, 0)
    Me.split2.Name = "split2"
    '
    'split2.Panel1
    '
    Me.split2.Panel1.Controls.Add(Me.ListBox1)
    '
    'split2.Panel2
    '
    Me.split2.Panel2.Controls.Add(Me.split3)
    Me.split2.Size = New System.Drawing.Size(354, 174)
    Me.split2.SplitterDistance = 324
    Me.split2.TabIndex = 0
    '
    'ListBox1
    '
    Me.ListBox1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ListBox1.FormattingEnabled = True
    Me.ListBox1.Location = New System.Drawing.Point(0, 0)
    Me.ListBox1.Name = "ListBox1"
    Me.ListBox1.Size = New System.Drawing.Size(324, 174)
    Me.ListBox1.TabIndex = 0
    '
    'split3
    '
    Me.split3.Dock = System.Windows.Forms.DockStyle.Fill
    Me.split3.Location = New System.Drawing.Point(0, 0)
    Me.split3.Name = "split3"
    Me.split3.Orientation = System.Windows.Forms.Orientation.Horizontal
    '
    'split3.Panel1
    '
    Me.split3.Panel1.Controls.Add(Me.DataGridView1)
    '
    'split3.Panel2
    '
    Me.split3.Panel2.Controls.Add(Me.DataGridView2)
    Me.split3.Size = New System.Drawing.Size(26, 174)
    Me.split3.SplitterDistance = 92
    Me.split3.TabIndex = 0
    '
    'DataGridView1
    '
    Me.DataGridView1.AllowUserToAddRows = False
    Me.DataGridView1.AllowUserToDeleteRows = False
    Me.DataGridView1.AutoGenerateColumns = False
    Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FileNameDataGridViewTextBoxColumn, Me.CardNoDataGridViewTextBoxColumn, Me.ProjectIDDataGridViewTextBoxColumn, Me.IsValidDataGridViewCheckBoxColumn, Me.IsComponentXLDataGridViewCheckBoxColumn, Me.IsMCDDataGridViewCheckBoxColumn, Me.IsDWGDataGridViewCheckBoxColumn, Me.JobFileNameDataGridViewTextBoxColumn, Me.JobPathFileNameDataGridViewTextBoxColumn, Me.IsErrorDataGridViewCheckBoxColumn, Me.SerializedPathDataGridViewTextBoxColumn, Me.IsTitleBlockFoundDataGridViewCheckBoxColumn, Me.IsPDFCreatedDataGridViewCheckBoxColumn, Me.IsXMLGeneratedDataGridViewCheckBoxColumn, Me.IsComponentXLFoundDataGridViewCheckBoxColumn, Me.IsMCDFoundDataGridViewCheckBoxColumn, Me.VaultFolderIDDataGridViewTextBoxColumn, Me.ComponentXLFileNameDataGridViewTextBoxColumn, Me.ComponentXLDataDataGridViewTextBoxColumn, Me.MCDFileNameDataGridViewTextBoxColumn, Me.MCDxDataDataGridViewTextBoxColumn, Me.OtherFileNameDataGridViewTextBoxColumn, Me.ForOtherFileDataGridViewCheckBoxColumn, Me.FileIDDataGridViewTextBoxColumn, Me.UserIDDataGridViewTextBoxColumn, Me.VaultDBDataGridViewTextBoxColumn, Me.ClientVersionDataGridViewTextBoxColumn, Me.ClientMachineNameDataGridViewTextBoxColumn, Me.JobCreationDateDataGridViewTextBoxColumn, Me.JobCreationTimeDataGridViewTextBoxColumn})
    Me.DataGridView1.DataSource = Me.BindingSource1
    Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
    Me.DataGridView1.Name = "DataGridView1"
    Me.DataGridView1.ReadOnly = True
    Me.DataGridView1.Size = New System.Drawing.Size(26, 92)
    Me.DataGridView1.TabIndex = 6
    '
    'FileNameDataGridViewTextBoxColumn
    '
    Me.FileNameDataGridViewTextBoxColumn.DataPropertyName = "FileName"
    Me.FileNameDataGridViewTextBoxColumn.HeaderText = "FileName"
    Me.FileNameDataGridViewTextBoxColumn.Name = "FileNameDataGridViewTextBoxColumn"
    Me.FileNameDataGridViewTextBoxColumn.ReadOnly = True
    '
    'CardNoDataGridViewTextBoxColumn
    '
    Me.CardNoDataGridViewTextBoxColumn.DataPropertyName = "CardNo"
    Me.CardNoDataGridViewTextBoxColumn.HeaderText = "CardNo"
    Me.CardNoDataGridViewTextBoxColumn.Name = "CardNoDataGridViewTextBoxColumn"
    Me.CardNoDataGridViewTextBoxColumn.ReadOnly = True
    '
    'ProjectIDDataGridViewTextBoxColumn
    '
    Me.ProjectIDDataGridViewTextBoxColumn.DataPropertyName = "ProjectID"
    Me.ProjectIDDataGridViewTextBoxColumn.HeaderText = "ProjectID"
    Me.ProjectIDDataGridViewTextBoxColumn.Name = "ProjectIDDataGridViewTextBoxColumn"
    Me.ProjectIDDataGridViewTextBoxColumn.ReadOnly = True
    '
    'IsValidDataGridViewCheckBoxColumn
    '
    Me.IsValidDataGridViewCheckBoxColumn.DataPropertyName = "IsValid"
    Me.IsValidDataGridViewCheckBoxColumn.HeaderText = "IsValid"
    Me.IsValidDataGridViewCheckBoxColumn.Name = "IsValidDataGridViewCheckBoxColumn"
    Me.IsValidDataGridViewCheckBoxColumn.ReadOnly = True
    '
    'IsComponentXLDataGridViewCheckBoxColumn
    '
    Me.IsComponentXLDataGridViewCheckBoxColumn.DataPropertyName = "IsComponentXL"
    Me.IsComponentXLDataGridViewCheckBoxColumn.HeaderText = "IsComponentXL"
    Me.IsComponentXLDataGridViewCheckBoxColumn.Name = "IsComponentXLDataGridViewCheckBoxColumn"
    Me.IsComponentXLDataGridViewCheckBoxColumn.ReadOnly = True
    '
    'IsMCDDataGridViewCheckBoxColumn
    '
    Me.IsMCDDataGridViewCheckBoxColumn.DataPropertyName = "IsMCD"
    Me.IsMCDDataGridViewCheckBoxColumn.HeaderText = "IsMCD"
    Me.IsMCDDataGridViewCheckBoxColumn.Name = "IsMCDDataGridViewCheckBoxColumn"
    Me.IsMCDDataGridViewCheckBoxColumn.ReadOnly = True
    '
    'IsDWGDataGridViewCheckBoxColumn
    '
    Me.IsDWGDataGridViewCheckBoxColumn.DataPropertyName = "IsDWG"
    Me.IsDWGDataGridViewCheckBoxColumn.HeaderText = "IsDWG"
    Me.IsDWGDataGridViewCheckBoxColumn.Name = "IsDWGDataGridViewCheckBoxColumn"
    Me.IsDWGDataGridViewCheckBoxColumn.ReadOnly = True
    '
    'JobFileNameDataGridViewTextBoxColumn
    '
    Me.JobFileNameDataGridViewTextBoxColumn.DataPropertyName = "JobFileName"
    Me.JobFileNameDataGridViewTextBoxColumn.HeaderText = "JobFileName"
    Me.JobFileNameDataGridViewTextBoxColumn.Name = "JobFileNameDataGridViewTextBoxColumn"
    Me.JobFileNameDataGridViewTextBoxColumn.ReadOnly = True
    '
    'JobPathFileNameDataGridViewTextBoxColumn
    '
    Me.JobPathFileNameDataGridViewTextBoxColumn.DataPropertyName = "JobPathFileName"
    Me.JobPathFileNameDataGridViewTextBoxColumn.HeaderText = "JobPathFileName"
    Me.JobPathFileNameDataGridViewTextBoxColumn.Name = "JobPathFileNameDataGridViewTextBoxColumn"
    Me.JobPathFileNameDataGridViewTextBoxColumn.ReadOnly = True
    '
    'IsErrorDataGridViewCheckBoxColumn
    '
    Me.IsErrorDataGridViewCheckBoxColumn.DataPropertyName = "IsError"
    Me.IsErrorDataGridViewCheckBoxColumn.HeaderText = "IsError"
    Me.IsErrorDataGridViewCheckBoxColumn.Name = "IsErrorDataGridViewCheckBoxColumn"
    Me.IsErrorDataGridViewCheckBoxColumn.ReadOnly = True
    '
    'SerializedPathDataGridViewTextBoxColumn
    '
    Me.SerializedPathDataGridViewTextBoxColumn.DataPropertyName = "SerializedPath"
    Me.SerializedPathDataGridViewTextBoxColumn.HeaderText = "SerializedPath"
    Me.SerializedPathDataGridViewTextBoxColumn.Name = "SerializedPathDataGridViewTextBoxColumn"
    Me.SerializedPathDataGridViewTextBoxColumn.ReadOnly = True
    '
    'IsTitleBlockFoundDataGridViewCheckBoxColumn
    '
    Me.IsTitleBlockFoundDataGridViewCheckBoxColumn.DataPropertyName = "IsTitleBlockFound"
    Me.IsTitleBlockFoundDataGridViewCheckBoxColumn.HeaderText = "IsTitleBlockFound"
    Me.IsTitleBlockFoundDataGridViewCheckBoxColumn.Name = "IsTitleBlockFoundDataGridViewCheckBoxColumn"
    Me.IsTitleBlockFoundDataGridViewCheckBoxColumn.ReadOnly = True
    '
    'IsPDFCreatedDataGridViewCheckBoxColumn
    '
    Me.IsPDFCreatedDataGridViewCheckBoxColumn.DataPropertyName = "IsPDFCreated"
    Me.IsPDFCreatedDataGridViewCheckBoxColumn.HeaderText = "IsPDFCreated"
    Me.IsPDFCreatedDataGridViewCheckBoxColumn.Name = "IsPDFCreatedDataGridViewCheckBoxColumn"
    Me.IsPDFCreatedDataGridViewCheckBoxColumn.ReadOnly = True
    '
    'IsXMLGeneratedDataGridViewCheckBoxColumn
    '
    Me.IsXMLGeneratedDataGridViewCheckBoxColumn.DataPropertyName = "IsXMLGenerated"
    Me.IsXMLGeneratedDataGridViewCheckBoxColumn.HeaderText = "IsXMLGenerated"
    Me.IsXMLGeneratedDataGridViewCheckBoxColumn.Name = "IsXMLGeneratedDataGridViewCheckBoxColumn"
    Me.IsXMLGeneratedDataGridViewCheckBoxColumn.ReadOnly = True
    '
    'IsComponentXLFoundDataGridViewCheckBoxColumn
    '
    Me.IsComponentXLFoundDataGridViewCheckBoxColumn.DataPropertyName = "IsComponentXLFound"
    Me.IsComponentXLFoundDataGridViewCheckBoxColumn.HeaderText = "IsComponentXLFound"
    Me.IsComponentXLFoundDataGridViewCheckBoxColumn.Name = "IsComponentXLFoundDataGridViewCheckBoxColumn"
    Me.IsComponentXLFoundDataGridViewCheckBoxColumn.ReadOnly = True
    '
    'IsMCDFoundDataGridViewCheckBoxColumn
    '
    Me.IsMCDFoundDataGridViewCheckBoxColumn.DataPropertyName = "IsMCDFound"
    Me.IsMCDFoundDataGridViewCheckBoxColumn.HeaderText = "IsMCDFound"
    Me.IsMCDFoundDataGridViewCheckBoxColumn.Name = "IsMCDFoundDataGridViewCheckBoxColumn"
    Me.IsMCDFoundDataGridViewCheckBoxColumn.ReadOnly = True
    '
    'VaultFolderIDDataGridViewTextBoxColumn
    '
    Me.VaultFolderIDDataGridViewTextBoxColumn.DataPropertyName = "VaultFolderID"
    Me.VaultFolderIDDataGridViewTextBoxColumn.HeaderText = "VaultFolderID"
    Me.VaultFolderIDDataGridViewTextBoxColumn.Name = "VaultFolderIDDataGridViewTextBoxColumn"
    Me.VaultFolderIDDataGridViewTextBoxColumn.ReadOnly = True
    '
    'ComponentXLFileNameDataGridViewTextBoxColumn
    '
    Me.ComponentXLFileNameDataGridViewTextBoxColumn.DataPropertyName = "ComponentXLFileName"
    Me.ComponentXLFileNameDataGridViewTextBoxColumn.HeaderText = "ComponentXLFileName"
    Me.ComponentXLFileNameDataGridViewTextBoxColumn.Name = "ComponentXLFileNameDataGridViewTextBoxColumn"
    Me.ComponentXLFileNameDataGridViewTextBoxColumn.ReadOnly = True
    '
    'ComponentXLDataDataGridViewTextBoxColumn
    '
    Me.ComponentXLDataDataGridViewTextBoxColumn.DataPropertyName = "ComponentXLData"
    Me.ComponentXLDataDataGridViewTextBoxColumn.HeaderText = "ComponentXLData"
    Me.ComponentXLDataDataGridViewTextBoxColumn.Name = "ComponentXLDataDataGridViewTextBoxColumn"
    Me.ComponentXLDataDataGridViewTextBoxColumn.ReadOnly = True
    '
    'MCDFileNameDataGridViewTextBoxColumn
    '
    Me.MCDFileNameDataGridViewTextBoxColumn.DataPropertyName = "MCDFileName"
    Me.MCDFileNameDataGridViewTextBoxColumn.HeaderText = "MCDFileName"
    Me.MCDFileNameDataGridViewTextBoxColumn.Name = "MCDFileNameDataGridViewTextBoxColumn"
    Me.MCDFileNameDataGridViewTextBoxColumn.ReadOnly = True
    '
    'MCDxDataDataGridViewTextBoxColumn
    '
    Me.MCDxDataDataGridViewTextBoxColumn.DataPropertyName = "MCDxData"
    Me.MCDxDataDataGridViewTextBoxColumn.HeaderText = "MCDxData"
    Me.MCDxDataDataGridViewTextBoxColumn.Name = "MCDxDataDataGridViewTextBoxColumn"
    Me.MCDxDataDataGridViewTextBoxColumn.ReadOnly = True
    '
    'OtherFileNameDataGridViewTextBoxColumn
    '
    Me.OtherFileNameDataGridViewTextBoxColumn.DataPropertyName = "OtherFileName"
    Me.OtherFileNameDataGridViewTextBoxColumn.HeaderText = "OtherFileName"
    Me.OtherFileNameDataGridViewTextBoxColumn.Name = "OtherFileNameDataGridViewTextBoxColumn"
    Me.OtherFileNameDataGridViewTextBoxColumn.ReadOnly = True
    '
    'ForOtherFileDataGridViewCheckBoxColumn
    '
    Me.ForOtherFileDataGridViewCheckBoxColumn.DataPropertyName = "ForOtherFile"
    Me.ForOtherFileDataGridViewCheckBoxColumn.HeaderText = "ForOtherFile"
    Me.ForOtherFileDataGridViewCheckBoxColumn.Name = "ForOtherFileDataGridViewCheckBoxColumn"
    Me.ForOtherFileDataGridViewCheckBoxColumn.ReadOnly = True
    '
    'FileIDDataGridViewTextBoxColumn
    '
    Me.FileIDDataGridViewTextBoxColumn.DataPropertyName = "FileID"
    Me.FileIDDataGridViewTextBoxColumn.HeaderText = "FileID"
    Me.FileIDDataGridViewTextBoxColumn.Name = "FileIDDataGridViewTextBoxColumn"
    Me.FileIDDataGridViewTextBoxColumn.ReadOnly = True
    '
    'UserIDDataGridViewTextBoxColumn
    '
    Me.UserIDDataGridViewTextBoxColumn.DataPropertyName = "UserID"
    Me.UserIDDataGridViewTextBoxColumn.HeaderText = "UserID"
    Me.UserIDDataGridViewTextBoxColumn.Name = "UserIDDataGridViewTextBoxColumn"
    Me.UserIDDataGridViewTextBoxColumn.ReadOnly = True
    '
    'VaultDBDataGridViewTextBoxColumn
    '
    Me.VaultDBDataGridViewTextBoxColumn.DataPropertyName = "VaultDB"
    Me.VaultDBDataGridViewTextBoxColumn.HeaderText = "VaultDB"
    Me.VaultDBDataGridViewTextBoxColumn.Name = "VaultDBDataGridViewTextBoxColumn"
    Me.VaultDBDataGridViewTextBoxColumn.ReadOnly = True
    '
    'ClientVersionDataGridViewTextBoxColumn
    '
    Me.ClientVersionDataGridViewTextBoxColumn.DataPropertyName = "ClientVersion"
    Me.ClientVersionDataGridViewTextBoxColumn.HeaderText = "ClientVersion"
    Me.ClientVersionDataGridViewTextBoxColumn.Name = "ClientVersionDataGridViewTextBoxColumn"
    Me.ClientVersionDataGridViewTextBoxColumn.ReadOnly = True
    '
    'ClientMachineNameDataGridViewTextBoxColumn
    '
    Me.ClientMachineNameDataGridViewTextBoxColumn.DataPropertyName = "ClientMachineName"
    Me.ClientMachineNameDataGridViewTextBoxColumn.HeaderText = "ClientMachineName"
    Me.ClientMachineNameDataGridViewTextBoxColumn.Name = "ClientMachineNameDataGridViewTextBoxColumn"
    Me.ClientMachineNameDataGridViewTextBoxColumn.ReadOnly = True
    '
    'JobCreationDateDataGridViewTextBoxColumn
    '
    Me.JobCreationDateDataGridViewTextBoxColumn.DataPropertyName = "JobCreationDate"
    Me.JobCreationDateDataGridViewTextBoxColumn.HeaderText = "JobCreationDate"
    Me.JobCreationDateDataGridViewTextBoxColumn.Name = "JobCreationDateDataGridViewTextBoxColumn"
    Me.JobCreationDateDataGridViewTextBoxColumn.ReadOnly = True
    '
    'JobCreationTimeDataGridViewTextBoxColumn
    '
    Me.JobCreationTimeDataGridViewTextBoxColumn.DataPropertyName = "JobCreationTime"
    Me.JobCreationTimeDataGridViewTextBoxColumn.HeaderText = "JobCreationTime"
    Me.JobCreationTimeDataGridViewTextBoxColumn.Name = "JobCreationTimeDataGridViewTextBoxColumn"
    Me.JobCreationTimeDataGridViewTextBoxColumn.ReadOnly = True
    '
    'BindingSource1
    '
    Me.BindingSource1.DataMember = "LstJobFiles"
    Me.BindingSource1.DataSource = GetType(EDICommon.JobFiles)
    '
    'DataGridView2
    '
    Me.DataGridView2.AllowUserToAddRows = False
    Me.DataGridView2.AllowUserToDeleteRows = False
    Me.DataGridView2.AutoGenerateColumns = False
    Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ErrDetailDataGridViewTextBoxColumn})
    Me.DataGridView2.DataSource = Me.BindingSource2
    Me.DataGridView2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
    Me.DataGridView2.Location = New System.Drawing.Point(0, 0)
    Me.DataGridView2.Name = "DataGridView2"
    Me.DataGridView2.ReadOnly = True
    Me.DataGridView2.Size = New System.Drawing.Size(26, 78)
    Me.DataGridView2.TabIndex = 0
    '
    'ErrDetailDataGridViewTextBoxColumn
    '
    Me.ErrDetailDataGridViewTextBoxColumn.DataPropertyName = "ErrDetail"
    Me.ErrDetailDataGridViewTextBoxColumn.HeaderText = "ErrDetail"
    Me.ErrDetailDataGridViewTextBoxColumn.Name = "ErrDetailDataGridViewTextBoxColumn"
    Me.ErrDetailDataGridViewTextBoxColumn.ReadOnly = True
    Me.ErrDetailDataGridViewTextBoxColumn.Width = 600
    '
    'BindingSource2
    '
    Me.BindingSource2.DataMember = "ErrorList"
    Me.BindingSource2.DataSource = Me.BindingSource1
    '
    'frmMain
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.AutoSize = True
    Me.ClientSize = New System.Drawing.Size(354, 255)
    Me.Controls.Add(Me.split1)
    Me.Name = "frmMain"
    Me.Text = "Bom Export EDI Services"
    Me.split1.Panel1.ResumeLayout(False)
    Me.split1.Panel1.PerformLayout()
    Me.split1.Panel2.ResumeLayout(False)
    CType(Me.split1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.split1.ResumeLayout(False)
    Me.split2.Panel1.ResumeLayout(False)
    Me.split2.Panel2.ResumeLayout(False)
    CType(Me.split2, System.ComponentModel.ISupportInitialize).EndInit()
    Me.split2.ResumeLayout(False)
    Me.split3.Panel1.ResumeLayout(False)
    Me.split3.Panel2.ResumeLayout(False)
    CType(Me.split3, System.ComponentModel.ISupportInitialize).EndInit()
    Me.split3.ResumeLayout(False)
    CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.BindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

  Friend WithEvents split1 As SplitContainer
  Friend WithEvents cmdStop As Button
  Friend WithEvents cmdStart As Button
  Friend WithEvents Label1 As Label
  Friend WithEvents split2 As SplitContainer
  Friend WithEvents ListBox1 As ListBox
  Friend WithEvents BindingSource1 As BindingSource
  Friend WithEvents split3 As SplitContainer
  Friend WithEvents DataGridView1 As DataGridView
  Friend WithEvents DataGridView2 As DataGridView
  Friend WithEvents BindingSource2 As BindingSource
  Friend WithEvents cmdCache As Button
  Friend WithEvents ErrDetailDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
  Friend WithEvents FileNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
  Friend WithEvents CardNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
  Friend WithEvents ProjectIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
  Friend WithEvents IsValidDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
  Friend WithEvents IsComponentXLDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
  Friend WithEvents IsMCDDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
  Friend WithEvents IsDWGDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
  Friend WithEvents JobFileNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
  Friend WithEvents JobPathFileNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
  Friend WithEvents IsErrorDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
  Friend WithEvents SerializedPathDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
  Friend WithEvents IsTitleBlockFoundDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
  Friend WithEvents IsPDFCreatedDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
  Friend WithEvents IsXMLGeneratedDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
  Friend WithEvents IsComponentXLFoundDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
  Friend WithEvents IsMCDFoundDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
  Friend WithEvents VaultFolderIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
  Friend WithEvents ComponentXLFileNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
  Friend WithEvents ComponentXLDataDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
  Friend WithEvents MCDFileNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
  Friend WithEvents MCDxDataDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
  Friend WithEvents OtherFileNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
  Friend WithEvents ForOtherFileDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
  Friend WithEvents FileIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
  Friend WithEvents UserIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
  Friend WithEvents VaultDBDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
  Friend WithEvents ClientVersionDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
  Friend WithEvents ClientMachineNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
  Friend WithEvents JobCreationDateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
  Friend WithEvents JobCreationTimeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
  Friend WithEvents F_Search As TextBox
  Friend WithEvents cmdF As Button
End Class
