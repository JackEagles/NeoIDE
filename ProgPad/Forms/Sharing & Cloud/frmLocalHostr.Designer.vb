<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLocalHostrUploader
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
        Me.pbMain = New System.Windows.Forms.ProgressBar()
        Me.txtInfo = New System.Windows.Forms.Label()
        Me.txtFileURL = New System.Windows.Forms.TextBox()
        Me.lblFileURL = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'pbMain
        '
        Me.pbMain.Location = New System.Drawing.Point(13, 52)
        Me.pbMain.Name = "pbMain"
        Me.pbMain.Size = New System.Drawing.Size(430, 18)
        Me.pbMain.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbMain.TabIndex = 0
        '
        'txtInfo
        '
        Me.txtInfo.AutoSize = True
        Me.txtInfo.Location = New System.Drawing.Point(12, 9)
        Me.txtInfo.Name = "txtInfo"
        Me.txtInfo.Size = New System.Drawing.Size(433, 26)
        Me.txtInfo.TabIndex = 1
        Me.txtInfo.Text = "Please wait while your file is uploaded. The amount of time that this process wil" & _
    "l take varies" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "depending upon the size of the file."
        '
        'txtFileURL
        '
        Me.txtFileURL.Location = New System.Drawing.Point(67, 50)
        Me.txtFileURL.Name = "txtFileURL"
        Me.txtFileURL.Size = New System.Drawing.Size(378, 20)
        Me.txtFileURL.TabIndex = 2
        Me.txtFileURL.Visible = False
        '
        'lblFileURL
        '
        Me.lblFileURL.AutoSize = True
        Me.lblFileURL.Location = New System.Drawing.Point(10, 53)
        Me.lblFileURL.Name = "lblFileURL"
        Me.lblFileURL.Size = New System.Drawing.Size(51, 13)
        Me.lblFileURL.TabIndex = 3
        Me.lblFileURL.Text = "File URL:"
        Me.lblFileURL.Visible = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(9, 86)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(439, 13)
        Me.LinkLabel1.TabIndex = 4
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "All credits go to Perplexity and idb on HackForums for the Localhostr uploading f" & _
    "unctionality!"
        '
        'frmLocalHostrUploader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(455, 108)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.lblFileURL)
        Me.Controls.Add(Me.txtFileURL)
        Me.Controls.Add(Me.txtInfo)
        Me.Controls.Add(Me.pbMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLocalHostrUploader"
        Me.Text = "Localhostr Uploader"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbMain As System.Windows.Forms.ProgressBar
    Friend WithEvents txtInfo As System.Windows.Forms.Label
    Friend WithEvents txtFileURL As System.Windows.Forms.TextBox
    Friend WithEvents lblFileURL As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
End Class
