<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCloudLogin
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
        Me.gbLogin = New System.Windows.Forms.GroupBox()
        Me.FtpClientCtl1 = New DotNetRemoting.FTPClientCtl()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.lblAnonLogin = New System.Windows.Forms.LinkLabel()
        Me.btnLogIn = New System.Windows.Forms.Button()
        Me.lblHelp = New System.Windows.Forms.LinkLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCreateAccount = New System.Windows.Forms.LinkLabel()
        Me.lblPass = New System.Windows.Forms.Label()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.pbMain = New System.Windows.Forms.PictureBox()
        Me.gbLogin.SuspendLayout()
        CType(Me.pbMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbLogin
        '
        Me.gbLogin.Controls.Add(Me.FtpClientCtl1)
        Me.gbLogin.Controls.Add(Me.CheckBox1)
        Me.gbLogin.Controls.Add(Me.lblAnonLogin)
        Me.gbLogin.Controls.Add(Me.btnLogIn)
        Me.gbLogin.Controls.Add(Me.lblHelp)
        Me.gbLogin.Controls.Add(Me.Label1)
        Me.gbLogin.Controls.Add(Me.lblCreateAccount)
        Me.gbLogin.Controls.Add(Me.lblPass)
        Me.gbLogin.Controls.Add(Me.lblUser)
        Me.gbLogin.Controls.Add(Me.txtPass)
        Me.gbLogin.Controls.Add(Me.txtUser)
        Me.gbLogin.Location = New System.Drawing.Point(12, 115)
        Me.gbLogin.Name = "gbLogin"
        Me.gbLogin.Size = New System.Drawing.Size(557, 128)
        Me.gbLogin.TabIndex = 0
        Me.gbLogin.TabStop = False
        Me.gbLogin.Text = "Log In:"
        '
        'FtpClientCtl1
        '
        Me.FtpClientCtl1.BackColor = System.Drawing.Color.Orange
        Me.FtpClientCtl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FtpClientCtl1.ControlPort = 21
        Me.FtpClientCtl1.FtpToolStripProgressBar = Nothing
        Me.FtpClientCtl1.Location = New System.Drawing.Point(446, 17)
        Me.FtpClientCtl1.Name = "FtpClientCtl1"
        Me.FtpClientCtl1.ProgrBar = Nothing
        Me.FtpClientCtl1.ProgressLabel = Nothing
        Me.FtpClientCtl1.RemoteHost = Nothing
        Me.FtpClientCtl1.Size = New System.Drawing.Size(105, 17)
        Me.FtpClientCtl1.TabIndex = 9
        Me.FtpClientCtl1.Timeout = 123000
        Me.FtpClientCtl1.TimeOut = 124000
        Me.FtpClientCtl1.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(287, 103)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(183, 17)
        Me.CheckBox1.TabIndex = 8
        Me.CheckBox1.Text = "Remember username && password"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'lblAnonLogin
        '
        Me.lblAnonLogin.AutoSize = True
        Me.lblAnonLogin.Location = New System.Drawing.Point(82, 103)
        Me.lblAnonLogin.Name = "lblAnonLogin"
        Me.lblAnonLogin.Size = New System.Drawing.Size(98, 13)
        Me.lblAnonLogin.TabIndex = 7
        Me.lblAnonLogin.TabStop = True
        Me.lblAnonLogin.Text = "Login Anonymously"
        '
        'btnLogIn
        '
        Me.btnLogIn.Location = New System.Drawing.Point(476, 99)
        Me.btnLogIn.Name = "btnLogIn"
        Me.btnLogIn.Size = New System.Drawing.Size(75, 23)
        Me.btnLogIn.TabIndex = 6
        Me.btnLogIn.Text = "Log In"
        Me.btnLogIn.UseVisualStyleBackColor = True
        '
        'lblHelp
        '
        Me.lblHelp.AutoSize = True
        Me.lblHelp.Location = New System.Drawing.Point(8, 103)
        Me.lblHelp.Name = "lblHelp"
        Me.lblHelp.Size = New System.Drawing.Size(25, 13)
        Me.lblHelp.TabIndex = 4
        Me.lblHelp.TabStop = True
        Me.lblHelp.Text = "Info"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(417, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Please log in to Programmer's Cloud to see your personal files && make changes to" & _
    " them:"
        '
        'lblCreateAccount
        '
        Me.lblCreateAccount.AutoSize = True
        Me.lblCreateAccount.Location = New System.Drawing.Point(186, 103)
        Me.lblCreateAccount.Name = "lblCreateAccount"
        Me.lblCreateAccount.Size = New System.Drawing.Size(95, 13)
        Me.lblCreateAccount.TabIndex = 1
        Me.lblCreateAccount.TabStop = True
        Me.lblCreateAccount.Text = "Create an account"
        '
        'lblPass
        '
        Me.lblPass.AutoSize = True
        Me.lblPass.Location = New System.Drawing.Point(6, 76)
        Me.lblPass.Name = "lblPass"
        Me.lblPass.Size = New System.Drawing.Size(56, 13)
        Me.lblPass.TabIndex = 3
        Me.lblPass.Text = "Password:"
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Location = New System.Drawing.Point(6, 50)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(58, 13)
        Me.lblUser.TabIndex = 2
        Me.lblUser.Text = "Username:"
        '
        'txtPass
        '
        Me.txtPass.Location = New System.Drawing.Point(74, 73)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtPass.Size = New System.Drawing.Size(477, 20)
        Me.txtPass.TabIndex = 1
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(74, 47)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(477, 20)
        Me.txtUser.TabIndex = 0
        '
        'pbMain
        '
        Me.pbMain.Location = New System.Drawing.Point(12, 12)
        Me.pbMain.Name = "pbMain"
        Me.pbMain.Size = New System.Drawing.Size(557, 97)
        Me.pbMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbMain.TabIndex = 1
        Me.pbMain.TabStop = False
        '
        'frmCloudLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(581, 245)
        Me.Controls.Add(Me.pbMain)
        Me.Controls.Add(Me.gbLogin)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCloudLogin"
        Me.Text = "Programmer's Cloud"
        Me.gbLogin.ResumeLayout(False)
        Me.gbLogin.PerformLayout()
        CType(Me.pbMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbLogin As System.Windows.Forms.GroupBox
    Friend WithEvents btnLogIn As System.Windows.Forms.Button
    Friend WithEvents lblHelp As System.Windows.Forms.LinkLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCreateAccount As System.Windows.Forms.LinkLabel
    Friend WithEvents lblPass As System.Windows.Forms.Label
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents txtPass As System.Windows.Forms.TextBox
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents lblAnonLogin As System.Windows.Forms.LinkLabel
    Friend WithEvents pbMain As System.Windows.Forms.PictureBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents FtpClientCtl1 As Global.DotNetRemoting.FTPClientCtl
End Class
