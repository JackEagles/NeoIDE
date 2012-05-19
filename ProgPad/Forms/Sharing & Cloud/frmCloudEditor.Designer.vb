<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCloudEditor
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
        Me.GetPublicLinkToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lvwMain = New System.Windows.Forms.ListView()
        Me.clmnFile = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clmnExt = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clmnSize = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmuMain = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DownloadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RenameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.UploadFilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ilFiles = New System.Windows.Forms.ImageList(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bwGetFiles = New System.ComponentModel.BackgroundWorker()
        Me.FtpClientCtl1 = New DotNetRemoting.FTPClientCtl()
        Me.cmuMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'GetPublicLinkToolStripMenuItem
        '
        Me.GetPublicLinkToolStripMenuItem.Name = "GetPublicLinkToolStripMenuItem"
        Me.GetPublicLinkToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.GetPublicLinkToolStripMenuItem.Text = "Upload to localhostr"
        '
        'lvwMain
        '
        Me.lvwMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwMain.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clmnFile, Me.clmnExt, Me.clmnSize})
        Me.lvwMain.ContextMenuStrip = Me.cmuMain
        Me.lvwMain.FullRowSelect = True
        Me.lvwMain.Location = New System.Drawing.Point(0, 0)
        Me.lvwMain.Name = "lvwMain"
        Me.lvwMain.Size = New System.Drawing.Size(624, 314)
        Me.lvwMain.SmallImageList = Me.ilFiles
        Me.lvwMain.TabIndex = 1
        Me.lvwMain.UseCompatibleStateImageBehavior = False
        Me.lvwMain.View = System.Windows.Forms.View.Details
        '
        'clmnFile
        '
        Me.clmnFile.Text = "File Name"
        Me.clmnFile.Width = 461
        '
        'clmnExt
        '
        Me.clmnExt.Text = "Extension"
        Me.clmnExt.Width = 79
        '
        'clmnSize
        '
        Me.clmnSize.Text = "Size"
        Me.clmnSize.Width = 75
        '
        'cmuMain
        '
        Me.cmuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GetPublicLinkToolStripMenuItem, Me.DownloadToolStripMenuItem, Me.RenameToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.ToolStripSeparator1, Me.UploadFilesToolStripMenuItem, Me.CloseToolStripMenuItem})
        Me.cmuMain.Name = "cmuMain"
        Me.cmuMain.Size = New System.Drawing.Size(182, 164)
        '
        'DownloadToolStripMenuItem
        '
        Me.DownloadToolStripMenuItem.Name = "DownloadToolStripMenuItem"
        Me.DownloadToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.DownloadToolStripMenuItem.Text = "Download"
        '
        'RenameToolStripMenuItem
        '
        Me.RenameToolStripMenuItem.Name = "RenameToolStripMenuItem"
        Me.RenameToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.RenameToolStripMenuItem.Text = "Rename"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(144, 6)
        '
        'UploadFilesToolStripMenuItem
        '
        Me.UploadFilesToolStripMenuItem.Name = "UploadFilesToolStripMenuItem"
        Me.UploadFilesToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.UploadFilesToolStripMenuItem.Text = "Upload Files..."
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'ilFiles
        '
        Me.ilFiles.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit
        Me.ilFiles.ImageSize = New System.Drawing.Size(16, 16)
        Me.ilFiles.TransparentColor = System.Drawing.Color.Transparent
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 322)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(263, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "All of your files are listed above. Right click for options."
        '
        'bwGetFiles
        '
        '
        'FtpClientCtl1
        '
        Me.FtpClientCtl1.BackColor = System.Drawing.Color.Orange
        Me.FtpClientCtl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FtpClientCtl1.ControlPort = 21
        Me.FtpClientCtl1.FtpToolStripProgressBar = Nothing
        Me.FtpClientCtl1.Location = New System.Drawing.Point(201, 338)
        Me.FtpClientCtl1.Name = "FtpClientCtl1"
        Me.FtpClientCtl1.ProgrBar = Nothing
        Me.FtpClientCtl1.ProgressLabel = Nothing
        Me.FtpClientCtl1.RemoteHost = Nothing
        Me.FtpClientCtl1.Size = New System.Drawing.Size(98, 44)
        Me.FtpClientCtl1.TabIndex = 3
        Me.FtpClientCtl1.Timeout = 126000
        Me.FtpClientCtl1.Timeout = 127000
        Me.FtpClientCtl1.Visible = False
        '
        'frmCloudEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 344)
        Me.Controls.Add(Me.lvwMain)
        Me.Controls.Add(Me.FtpClientCtl1)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCloudEditor"
        Me.Text = "Cloud Control"
        Me.cmuMain.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GetPublicLinkToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lvwMain As System.Windows.Forms.ListView
    Friend WithEvents cmuMain As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DownloadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RenameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UploadFilesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents bwGetFiles As System.ComponentModel.BackgroundWorker
    Friend WithEvents clmnFile As System.Windows.Forms.ColumnHeader
    Friend WithEvents clmnExt As System.Windows.Forms.ColumnHeader
    Friend WithEvents clmnSize As System.Windows.Forms.ColumnHeader
    Friend WithEvents FtpClientCtl1 As Global.DotNetRemoting.FTPClientCtl
    Friend WithEvents ilFiles As System.Windows.Forms.ImageList
End Class
