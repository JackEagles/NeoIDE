<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCloudUploader
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
        Me.btnSelectFiles = New System.Windows.Forms.Button()
        Me.lblMain = New System.Windows.Forms.Label()
        Me.btnBeginCancel = New System.Windows.Forms.Button()
        Me.pbUploadDownload = New System.Windows.Forms.ProgressBar()
        Me.lvwMain = New System.Windows.Forms.ListView()
        Me.clmnFileName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clmnFileSize = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clmnStatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tmrUpdateProgress = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'btnSelectFiles
        '
        Me.btnSelectFiles.Location = New System.Drawing.Point(336, 329)
        Me.btnSelectFiles.Name = "btnSelectFiles"
        Me.btnSelectFiles.Size = New System.Drawing.Size(134, 23)
        Me.btnSelectFiles.TabIndex = 1
        Me.btnSelectFiles.Text = "Select files to Upload"
        Me.btnSelectFiles.UseVisualStyleBackColor = True
        '
        'lblMain
        '
        Me.lblMain.AutoSize = True
        Me.lblMain.Location = New System.Drawing.Point(9, 334)
        Me.lblMain.Name = "lblMain"
        Me.lblMain.Size = New System.Drawing.Size(238, 13)
        Me.lblMain.TabIndex = 2
        Me.lblMain.Text = "Note that you can drag && drop files to upload too!"
        '
        'btnBeginCancel
        '
        Me.btnBeginCancel.Location = New System.Drawing.Point(476, 329)
        Me.btnBeginCancel.Name = "btnBeginCancel"
        Me.btnBeginCancel.Size = New System.Drawing.Size(134, 23)
        Me.btnBeginCancel.TabIndex = 3
        Me.btnBeginCancel.Text = "Begin Upload"
        Me.btnBeginCancel.UseVisualStyleBackColor = True
        '
        'pbUploadDownload
        '
        Me.pbUploadDownload.Location = New System.Drawing.Point(12, 295)
        Me.pbUploadDownload.Name = "pbUploadDownload"
        Me.pbUploadDownload.Size = New System.Drawing.Size(598, 28)
        Me.pbUploadDownload.TabIndex = 5
        '
        'lvwMain
        '
        Me.lvwMain.AllowDrop = True
        Me.lvwMain.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clmnFileName, Me.clmnFileSize, Me.clmnStatus})
        Me.lvwMain.Location = New System.Drawing.Point(12, 12)
        Me.lvwMain.Name = "lvwMain"
        Me.lvwMain.Size = New System.Drawing.Size(598, 277)
        Me.lvwMain.TabIndex = 6
        Me.lvwMain.UseCompatibleStateImageBehavior = False
        Me.lvwMain.View = System.Windows.Forms.View.Details
        '
        'clmnFileName
        '
        Me.clmnFileName.Text = "File Name"
        Me.clmnFileName.Width = 378
        '
        'clmnFileSize
        '
        Me.clmnFileSize.Text = "File Size"
        Me.clmnFileSize.Width = 99
        '
        'clmnStatus
        '
        Me.clmnStatus.Text = "Status"
        Me.clmnStatus.Width = 115
        '
        'tmrUpdateProgress
        '
        '
        'frmCloudUploader
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(622, 358)
        Me.Controls.Add(Me.lvwMain)
        Me.Controls.Add(Me.pbUploadDownload)
        Me.Controls.Add(Me.btnBeginCancel)
        Me.Controls.Add(Me.lblMain)
        Me.Controls.Add(Me.btnSelectFiles)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCloudUploader"
        Me.Text = "Cloud Upload"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSelectFiles As System.Windows.Forms.Button
    Friend WithEvents lblMain As System.Windows.Forms.Label
    Friend WithEvents btnBeginCancel As System.Windows.Forms.Button
    Friend WithEvents pbUploadDownload As System.Windows.Forms.ProgressBar
    Friend WithEvents lvwMain As System.Windows.Forms.ListView
    Friend WithEvents clmnFileName As System.Windows.Forms.ColumnHeader
    Friend WithEvents clmnFileSize As System.Windows.Forms.ColumnHeader
    Friend WithEvents clmnStatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents tmrUpdateProgress As System.Windows.Forms.Timer
End Class
