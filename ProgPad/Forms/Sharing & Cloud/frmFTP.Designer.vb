<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFTP
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
        Me.FtpClientCtl1 = New DotNetRemoting.FTPClientCtl()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtHost = New System.Windows.Forms.TextBox()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'FtpClientCtl1
        '
        Me.FtpClientCtl1.BackColor = System.Drawing.Color.Orange
        Me.FtpClientCtl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FtpClientCtl1.ControlPort = 21
        Me.FtpClientCtl1.FtpToolStripProgressBar = Nothing
        Me.FtpClientCtl1.Location = New System.Drawing.Point(-4, 502)
        Me.FtpClientCtl1.Name = "FtpClientCtl1"
        Me.FtpClientCtl1.ProgrBar = Nothing
        Me.FtpClientCtl1.ProgressLabel = Nothing
        Me.FtpClientCtl1.RemoteHost = Nothing
        Me.FtpClientCtl1.Size = New System.Drawing.Size(105, 17)
        Me.FtpClientCtl1.TabIndex = 11
        Me.FtpClientCtl1.Timeout = 122000
        Me.FtpClientCtl1.TimeOut = 123000
        Me.FtpClientCtl1.Visible = False
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(118, 12)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(100, 20)
        Me.txtUsername.TabIndex = 12
        Me.txtUsername.Text = "Username"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(224, 12)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(100, 20)
        Me.txtPassword.TabIndex = 13
        Me.txtPassword.Text = "Password"
        '
        'txtHost
        '
        Me.txtHost.Location = New System.Drawing.Point(12, 12)
        Me.txtHost.Name = "txtHost"
        Me.txtHost.Size = New System.Drawing.Size(100, 20)
        Me.txtHost.TabIndex = 14
        Me.txtHost.Text = "Remote Host"
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(330, 12)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(100, 20)
        Me.txtPort.TabIndex = 15
        Me.txtPort.Text = "Port"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(436, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 31)
        Me.Button1.TabIndex = 16
        Me.Button1.Text = "Login"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmFTP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1038, 531)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.txtHost)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.FtpClientCtl1)
        Me.Name = "frmFTP"
        Me.Text = "FTP Control"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FtpClientCtl1 As DotNetRemoting.FTPClientCtl
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtHost As System.Windows.Forms.TextBox
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
