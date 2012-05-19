<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUpdater
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
        Me.gbUpdate = New System.Windows.Forms.GroupBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.pbUpdate = New System.Windows.Forms.PictureBox()
        Me.pbDownloadProgress = New System.Windows.Forms.ProgressBar()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.txtUpdateInfo = New System.Windows.Forms.TextBox()
        Me.lblNewProgram = New System.Windows.Forms.Label()
        Me.lblCurrentVersion = New System.Windows.Forms.Label()
        Me.bwDoDownload = New System.ComponentModel.BackgroundWorker()
        Me.tmrExtract = New System.Windows.Forms.Timer(Me.components)
        Me.gbUpdate.SuspendLayout()
        CType(Me.pbUpdate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbUpdate
        '
        Me.gbUpdate.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbUpdate.Controls.Add(Me.lblStatus)
        Me.gbUpdate.Controls.Add(Me.pbUpdate)
        Me.gbUpdate.Controls.Add(Me.pbDownloadProgress)
        Me.gbUpdate.Controls.Add(Me.btnCancel)
        Me.gbUpdate.Controls.Add(Me.btnUpdate)
        Me.gbUpdate.Controls.Add(Me.txtUpdateInfo)
        Me.gbUpdate.Controls.Add(Me.lblNewProgram)
        Me.gbUpdate.Controls.Add(Me.lblCurrentVersion)
        Me.gbUpdate.Location = New System.Drawing.Point(3, 2)
        Me.gbUpdate.Name = "gbUpdate"
        Me.gbUpdate.Size = New System.Drawing.Size(432, 207)
        Me.gbUpdate.TabIndex = 0
        Me.gbUpdate.TabStop = False
        Me.gbUpdate.Text = "An update is available for NeoIDE:"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(9, 187)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(146, 13)
        Me.lblStatus.TabIndex = 7
        Me.lblStatus.Text = "Status: Looking for updates..."
        '
        'pbUpdate
        '
        Me.pbUpdate.Location = New System.Drawing.Point(9, 22)
        Me.pbUpdate.Name = "pbUpdate"
        Me.pbUpdate.Size = New System.Drawing.Size(58, 34)
        Me.pbUpdate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbUpdate.TabIndex = 6
        Me.pbUpdate.TabStop = False
        '
        'pbDownloadProgress
        '
        Me.pbDownloadProgress.Location = New System.Drawing.Point(9, 158)
        Me.pbDownloadProgress.MarqueeAnimationSpeed = 70
        Me.pbDownloadProgress.Name = "pbDownloadProgress"
        Me.pbDownloadProgress.Size = New System.Drawing.Size(255, 23)
        Me.pbDownloadProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbDownloadProgress.TabIndex = 5
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(270, 158)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Enabled = False
        Me.btnUpdate.Location = New System.Drawing.Point(351, 158)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 3
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'txtUpdateInfo
        '
        Me.txtUpdateInfo.Location = New System.Drawing.Point(9, 66)
        Me.txtUpdateInfo.Multiline = True
        Me.txtUpdateInfo.Name = "txtUpdateInfo"
        Me.txtUpdateInfo.ReadOnly = True
        Me.txtUpdateInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtUpdateInfo.Size = New System.Drawing.Size(417, 81)
        Me.txtUpdateInfo.TabIndex = 2
        '
        'lblNewProgram
        '
        Me.lblNewProgram.AutoSize = True
        Me.lblNewProgram.Location = New System.Drawing.Point(73, 40)
        Me.lblNewProgram.Name = "lblNewProgram"
        Me.lblNewProgram.Size = New System.Drawing.Size(128, 13)
        Me.lblNewProgram.TabIndex = 1
        Me.lblNewProgram.Text = "New program version: 0.0"
        '
        'lblCurrentVersion
        '
        Me.lblCurrentVersion.AutoSize = True
        Me.lblCurrentVersion.Location = New System.Drawing.Point(73, 21)
        Me.lblCurrentVersion.Name = "lblCurrentVersion"
        Me.lblCurrentVersion.Size = New System.Drawing.Size(140, 13)
        Me.lblCurrentVersion.TabIndex = 0
        Me.lblCurrentVersion.Text = "Current program version: 0.0"
        '
        'tmrExtract
        '
        Me.tmrExtract.Interval = 200
        '
        'frmUpdater
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(436, 211)
        Me.Controls.Add(Me.gbUpdate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUpdater"
        Me.Text = "Update"
        Me.gbUpdate.ResumeLayout(False)
        Me.gbUpdate.PerformLayout()
        CType(Me.pbUpdate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbUpdate As System.Windows.Forms.GroupBox
    Friend WithEvents pbUpdate As System.Windows.Forms.PictureBox
    Friend WithEvents pbDownloadProgress As System.Windows.Forms.ProgressBar
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents txtUpdateInfo As System.Windows.Forms.TextBox
    Friend WithEvents lblNewProgram As System.Windows.Forms.Label
    Friend WithEvents lblCurrentVersion As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents bwDoDownload As System.ComponentModel.BackgroundWorker
    Friend WithEvents tmrExtract As System.Windows.Forms.Timer
End Class
