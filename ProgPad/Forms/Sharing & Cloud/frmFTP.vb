Public Class frmFTP

    Private Sub frmFTP_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
 

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        FtpClientCtl1.RemoteHost = "ols18.com"
        FtpClientCtl1.ControlPort = 21
        FtpClientCtl1.Connect()
        FtpClientCtl1.Login("progpad", ÂÂÁ.ÂÅÂ(ÂÂÁ.鳱儇))
    End Sub

    Private Sub txtPassword_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPassword.TextChanged
        txtPassword.PasswordChar = "●"
    End Sub

    Private Sub txtUsername_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtUsername.TextChanged

    End Sub

    Private Sub txtHost_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtHost.TextChanged

    End Sub

    Private Sub txtPort_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPort.TextChanged

    End Sub
End Class