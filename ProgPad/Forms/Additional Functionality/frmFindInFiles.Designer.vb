<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFindInFiles
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFindInFiles))
        Me.txtInitialDir = New System.Windows.Forms.TextBox()
        Me.lblInitialDIR = New System.Windows.Forms.Label()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.chkFileName = New System.Windows.Forms.CheckBox()
        Me.chkFileContents = New System.Windows.Forms.CheckBox()
        Me.txtFileNAme = New System.Windows.Forms.TextBox()
        Me.txtFileContents = New System.Windows.Forms.TextBox()
        Me.txtFileTypes = New System.Windows.Forms.TextBox()
        Me.lblFileTypes = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.tmrUpdateStatus = New System.Windows.Forms.Timer(Me.components)
        Me.bwEnumFiles = New System.ComponentModel.BackgroundWorker()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtInitialDir
        '
        Me.txtInitialDir.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInitialDir.Location = New System.Drawing.Point(95, 6)
        Me.txtInitialDir.Name = "txtInitialDir"
        Me.txtInitialDir.Size = New System.Drawing.Size(592, 20)
        Me.txtInitialDir.TabIndex = 0
        '
        'lblInitialDIR
        '
        Me.lblInitialDIR.AutoSize = True
        Me.lblInitialDIR.Location = New System.Drawing.Point(10, 10)
        Me.lblInitialDIR.Name = "lblInitialDIR"
        Me.lblInitialDIR.Size = New System.Drawing.Size(79, 13)
        Me.lblInitialDIR.TabIndex = 1
        Me.lblInitialDIR.Text = "Initial Directory:"
        '
        'btnBrowse
        '
        Me.btnBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowse.Location = New System.Drawing.Point(694, 6)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(29, 20)
        Me.btnBrowse.TabIndex = 2
        Me.btnBrowse.Text = "..."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'chkFileName
        '
        Me.chkFileName.AutoSize = True
        Me.chkFileName.Location = New System.Drawing.Point(13, 59)
        Me.chkFileName.Name = "chkFileName"
        Me.chkFileName.Size = New System.Drawing.Size(137, 17)
        Me.chkFileName.TabIndex = 3
        Me.chkFileName.Text = "File name must contain:"
        Me.chkFileName.UseVisualStyleBackColor = True
        '
        'chkFileContents
        '
        Me.chkFileContents.AutoSize = True
        Me.chkFileContents.Location = New System.Drawing.Point(13, 82)
        Me.chkFileContents.Name = "chkFileContents"
        Me.chkFileContents.Size = New System.Drawing.Size(152, 17)
        Me.chkFileContents.TabIndex = 4
        Me.chkFileContents.Text = "File contents must contain:"
        Me.chkFileContents.UseVisualStyleBackColor = True
        '
        'txtFileNAme
        '
        Me.txtFileNAme.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFileNAme.Location = New System.Drawing.Point(156, 57)
        Me.txtFileNAme.Name = "txtFileNAme"
        Me.txtFileNAme.Size = New System.Drawing.Size(567, 20)
        Me.txtFileNAme.TabIndex = 5
        '
        'txtFileContents
        '
        Me.txtFileContents.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFileContents.Location = New System.Drawing.Point(171, 80)
        Me.txtFileContents.Name = "txtFileContents"
        Me.txtFileContents.Size = New System.Drawing.Size(552, 20)
        Me.txtFileContents.TabIndex = 6
        '
        'txtFileTypes
        '
        Me.txtFileTypes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFileTypes.Location = New System.Drawing.Point(110, 32)
        Me.txtFileTypes.Name = "txtFileTypes"
        Me.txtFileTypes.Size = New System.Drawing.Size(613, 20)
        Me.txtFileTypes.TabIndex = 7
        Me.txtFileTypes.Text = resources.GetString("txtFileTypes.Text")
        '
        'lblFileTypes
        '
        Me.lblFileTypes.AutoSize = True
        Me.lblFileTypes.Location = New System.Drawing.Point(10, 35)
        Me.lblFileTypes.Name = "lblFileTypes"
        Me.lblFileTypes.Size = New System.Drawing.Size(101, 13)
        Me.lblFileTypes.TabIndex = 8
        Me.lblFileTypes.Text = "File types to search:"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(12, 115)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(60, 13)
        Me.lblStatus.TabIndex = 10
        Me.lblStatus.Text = "Status: Idle"
        '
        'tmrUpdateStatus
        '
        Me.tmrUpdateStatus.Interval = 20
        '
        'bwEnumFiles
        '
        '
        'btnStart
        '
        Me.btnStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStart.Location = New System.Drawing.Point(589, 105)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(134, 33)
        Me.btnStart.TabIndex = 12
        Me.btnStart.Text = "Start Search"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'frmFindInFiles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(735, 140)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblFileTypes)
        Me.Controls.Add(Me.txtFileTypes)
        Me.Controls.Add(Me.txtFileContents)
        Me.Controls.Add(Me.txtFileNAme)
        Me.Controls.Add(Me.chkFileContents)
        Me.Controls.Add(Me.chkFileName)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.lblInitialDIR)
        Me.Controls.Add(Me.txtInitialDir)
        Me.Name = "frmFindInFiles"
        Me.Text = "Find in Files"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtInitialDir As System.Windows.Forms.TextBox
    Friend WithEvents lblInitialDIR As System.Windows.Forms.Label
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents chkFileName As System.Windows.Forms.CheckBox
    Friend WithEvents chkFileContents As System.Windows.Forms.CheckBox
    Friend WithEvents txtFileNAme As System.Windows.Forms.TextBox
    Friend WithEvents txtFileContents As System.Windows.Forms.TextBox
    Friend WithEvents txtFileTypes As System.Windows.Forms.TextBox
    Friend WithEvents lblFileTypes As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents tmrUpdateStatus As System.Windows.Forms.Timer
    Friend WithEvents bwEnumFiles As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnStart As System.Windows.Forms.Button
End Class
