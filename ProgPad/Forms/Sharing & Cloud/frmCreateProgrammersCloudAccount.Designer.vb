<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreateProgrammersCloudAccount
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
        Me.btnRegister = New System.Windows.Forms.Button()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.cbxSMTP = New System.Windows.Forms.ComboBox()
        Me.lblSMTP = New System.Windows.Forms.Label()
        Me.bwGetFiles = New System.ComponentModel.BackgroundWorker()
        Me.FtpClientCtl1 = New Global.DotNetRemoting.FTPClientCtl()
        Me.SuspendLayout()
        '
        'btnRegister
        '
        Me.btnRegister.Location = New System.Drawing.Point(273, 116)
        Me.btnRegister.Name = "btnRegister"
        Me.btnRegister.Size = New System.Drawing.Size(75, 23)
        Me.btnRegister.TabIndex = 3
        Me.btnRegister.Text = "Register"
        Me.btnRegister.UseVisualStyleBackColor = True
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(86, 90)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(262, 20)
        Me.txtEmail.TabIndex = 2
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(86, 64)
        Me.txtPassword.MaxLength = 60
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtPassword.Size = New System.Drawing.Size(262, 20)
        Me.txtPassword.TabIndex = 1
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(86, 38)
        Me.txtUsername.MaxLength = 20
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(262, 20)
        Me.txtUsername.TabIndex = 0
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.Location = New System.Drawing.Point(12, 11)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(314, 13)
        Me.lblInfo.TabIndex = 4
        Me.lblInfo.Text = "Please enter the information required below to set up an account:"
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Location = New System.Drawing.Point(12, 41)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(58, 13)
        Me.lblUsername.TabIndex = 5
        Me.lblUsername.Text = "Username:"
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(12, 67)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(56, 13)
        Me.lblPassword.TabIndex = 6
        Me.lblPassword.Text = "Password:"
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(12, 93)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(39, 13)
        Me.lblEmail.TabIndex = 7
        Me.lblEmail.Text = "E-Mail:"
        '
        'cbxSMTP
        '
        Me.cbxSMTP.FormattingEnabled = True
        Me.cbxSMTP.Items.AddRange(New Object() {"Google Mail: smtp.gmail.com", "Bt Click: mail.btclick.com", "Bt Connect: smtp.btconnect.com", "BT Internet: mail.btinternet.com", "BT Openworld: mail.btopenworld.com", "Freeserve/Wanadoo: smtp.freeserve.co.uk", "Freeserve: smtp.freeserve.net", "NTL World: smtp.ntlworld.com", "Orange: smtp.orange.net", "Orange (Home): smtp.orangehome.co.uk", "Pipex: smtp.dial.pipex.com", "Tesco: smtp.tesco.net", "Tesconet: mail.tesco.net", "Tiscali: smtp.tiscali.co.uk", "Virgin: smtp.virgin.net", "Wanadoo: smtp.freeserve.co.uk", "Yahoo: smtp.mail.yahoo.com", "Amaze.net.au: mail.amaze.net.au", "Ameritech DSL: mailhost.col.ameritech.net", "aol: za.mx.aol.com", "aol: zb.mx.aol.com", "aol: zc.mx.aol.com", "AT&T: smtp1.attglobal.net", "AT&T: mailhost.worldnet.att.net", "AT&T WorldNet: mailhost.att.net", "AT&T WorldNet: mailhost.worldnet.att.net", "Australink.net: mail.australink.net", "bellatlantic.net: smtpout.bellatlantic.net", "Bluelight.com: smtp.mail.yahoo.com", "BlueYonder: smtp.blueyonder.co.uk", "Bondinet.com: mail1.oznet.net.au", "Breathe: mailhost.breathemail.net", "bright.net: mail.bright.net", "Bt Click: mail.btclick.com", "Bt Connect: smtp.btconnect.com", "BT Internet: mail.btinternet.com", "BT Openworld: mail.btopenworld.com", "BusinessServe: smtp.businessserve.co.uk", "Cableinet: smtp.blueyonder.co.uk", "Claranet: relay.clara.net", "Comcast: smtp.comcast.net", "CompuServe 2000: smtp.cs.com", "CompuServe Classic: mail.compuserve.com", "CWCom: smtp.ntlworld.com", "DCAnet: postoffice.dca.net", "Demon: post.demon.co.uk", "Earthlink.net: smtp.earthlink.net", "Easynet: smtp.easynet.co.uk", "ee.net: mail.ee.net", "Freeinet.com: mail.ma.freei.net", "Freeserve/Wanadoo: smtp.freeserve.co.uk", "Freeserve: smtp.freeserve.net", "Gateway: smtp.gateway.net", "Genie: mail.genie.co.uk", "Greenbank.net.au: mail.greenbank.net.au", "Hotkey.net.au: mail.hotkey.net.au", "ibm.net: smtp1.ibm.net", "IC24: smtp.ic24.net", "icdc.com: mailout.icdc.com", "INFOLINK.com: mail.nfolink.com", "Interlink: mail.your-net.com", "Inweb Networks: post.inweb.co.uk", "IronNet: mail.iron.net", "iwayNET: smtp.iwaynet.net", "Jade Inc.: mail.jadeinc.com", "Lineone: smtp.lineone.net", "Log on America: mail.loa.com", "Logicworld.com.au: mail.logicworld.com.au", "Lycos: smtp.lycos.co.uk", "Madasafish: smtp.madasafish.com", "MegaNet: smtp.meganet.net", "Microsoft's MSN: smtp.email.msn.com", "MidOhio.net: mail.midohio.net", "MindSpring: smtp.mindspring.com", "MindSpring: mail.mindspring.com", "Mistral: smtp.mistral.co.uk", "MSN.com: smtp.email.msn.com", "MSN.DSL: secure.smtp.email.msn.com", "NamesToday: smtp.namestoday.ws", "netcom.com: smtp.ix.netcom.com", "netreach.net: smtp.netreach.net", "Netscapeonline: mailhost.netscapeonline.co.uk", "NetSet: mail.netset.com", "NetWalk.com: mail.netwalk.com", "netzero.net: smtp.netzero.net", "nextek.net: mail.nextek.net", "Nildram: smtp.nildram.co.uk", "nni.com: nni.com", "Northstar Data Systems: mail.nn.net", "NTL World: smtp.ntlworld.com", "OneTel: mail.onetel.net.uk", "On-Ramp: mail.marion.net", "Orange: smtp.orange.net", "Orange (Home): smtp.orangehome.co.uk", "Ozemail.com.au: smtp.ozemail.com.au", "peoplepc: mail.peoplepc.com", "Phone Co-op: smtp-1.opaltelecom.net", "Pipex: smtp.dial.pipex.com", "Prodigy: smtp.prodigy.net", "Purplenet: smtp.purplenet.co.uk", "rcn.com: smtp.rcn.com", "redbird.net: mail.redbird.net", "RichNet: mail.richnet.net", "Road Runner (Insight Communications): smtp-server.insight.rr.com", "Road Runner (Time Warner): smtp-server.columbus.rr.com", "Road Runner (Time Warner): smtp-server.nc.rr.com", "Screaming.Net: smtp.tiscali.co.uk", "Spire: mail.spire.com", "Supanet: smtp.supanet.com", "Telewest: smtp.blueyonder.co.uk", "Telocity: mail.telocity.com", "Tesco: smtp.tesco.net", "Tesconet: mail.tesco.net", "Tiscali: smtp.tiscali.co.uk", "Totalise: mail.totalise.co.uk", "TPG.com.au: mail.tpg.com.au", "TTLC: mail.ttlc.net", "UKGateway: smtp.ukgateway.net", "uu.net: uu.net", "V 21: smtp.v21.co.uk", "Verizon: smtp.verizon.net", "Virgin: smtp.virgin.net", "Vispa: mail.vispa.com", "voicenet.com: mail.voicenet.com", "Wanadoo: smtp.freeserve.co.uk", "Waitrose: smtpmail.waitrose.com", "Webcom: smtp.webcom.com", "Which Online: mail.which.net", "Wide Open West: smtp.mail.wowway.com", "Wide Open West (users with @wideopenwest.com): smtp.mail.wideopenwest.com", "Worldonline: smtp.tiscali.co.uk", "Yahoo: smtp.mail.yahoo.com"})
        Me.cbxSMTP.Location = New System.Drawing.Point(86, 118)
        Me.cbxSMTP.Name = "cbxSMTP"
        Me.cbxSMTP.Size = New System.Drawing.Size(181, 21)
        Me.cbxSMTP.TabIndex = 8
        Me.cbxSMTP.Visible = False
        '
        'lblSMTP
        '
        Me.lblSMTP.AutoSize = True
        Me.lblSMTP.Location = New System.Drawing.Point(11, 123)
        Me.lblSMTP.Name = "lblSMTP"
        Me.lblSMTP.Size = New System.Drawing.Size(77, 13)
        Me.lblSMTP.TabIndex = 9
        Me.lblSMTP.Text = "Email Provider:"
        Me.lblSMTP.Visible = False
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
        Me.FtpClientCtl1.Location = New System.Drawing.Point(341, 18)
        Me.FtpClientCtl1.Name = "FtpClientCtl1"
        Me.FtpClientCtl1.ProgrBar = Nothing
        Me.FtpClientCtl1.ProgressLabel = Nothing
        Me.FtpClientCtl1.RemoteHost = Nothing
        Me.FtpClientCtl1.Size = New System.Drawing.Size(105, 17)
        Me.FtpClientCtl1.TabIndex = 10
        Me.FtpClientCtl1.Timeout = 121000
        Me.FtpClientCtl1.Timeout = 122000
        Me.FtpClientCtl1.Visible = False
        '
        'frmCreateProgrammersCloudAccount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(360, 146)
        Me.Controls.Add(Me.FtpClientCtl1)
        Me.Controls.Add(Me.cbxSMTP)
        Me.Controls.Add(Me.lblSMTP)
        Me.Controls.Add(Me.lblEmail)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.lblUsername)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.btnRegister)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCreateProgrammersCloudAccount"
        Me.Text = "Create Programmer's Cloud account"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnRegister As System.Windows.Forms.Button
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents lblUsername As System.Windows.Forms.Label
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents cbxSMTP As System.Windows.Forms.ComboBox
    Friend WithEvents lblSMTP As System.Windows.Forms.Label
    Friend WithEvents bwGetFiles As System.ComponentModel.BackgroundWorker
    Friend WithEvents FtpClientCtl1 As Global.DotNetRemoting.FTPClientCtl
End Class
