Public Class frmAbout

   



    Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pbMain.BackgroundImage = Image.FromFile(Application.StartupPath & "\Images\Mainicon.png")
        Me.Icon = New Icon(Application.StartupPath & "\Images\Mainicon.ico")
        lblMsg.Text = "NeoIDE v" & My.Settings.Version
    End Sub

    Private Sub pbMain_Click(sender As System.Object, e As System.EventArgs) Handles pbMain.Click

    End Sub
End Class