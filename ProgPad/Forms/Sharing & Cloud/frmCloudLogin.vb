Imports System.ComponentModel

Public Class frmCloudLogin
    Friend WithEvents bw7z As New BackgroundWorker

    Private Sub lblHelp_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblHelp.LinkClicked
        MessageBox.Show("Programmer's Cloud [BETA]" & Environment.NewLine & "Programmer's Cloud lets you upload files (text only) to the internet and access them on any other computer - with or without NeoIDE. Each user gets 100mb of space to store files in Programmer's Cloud." & Environment.NewLine & Environment.NewLine & "What kind of files can I upload?" & Environment.NewLine & "You can upload any file at all (must be under 10mb, no sound/video/compressed files)." & Environment.NewLine & Environment.NewLine & "How secure is it?" & Environment.NewLine & "Interesting question. The actual content of your files is about as safe as your password - all the files you upload are encrypted using your password - so whilst it is relatively easy to gain access to the files which you upload, nothing usefull can be done with them unless the attacker has your password." & Environment.NewLine & Environment.NewLine & "Are my files backed up or in any way guranteed to last?" & Environment.NewLine & "The short answer is 'No'." & Environment.NewLine & Environment.NewLine & "Is there any way to recover my password if I forget it?" & Environment.NewLine & "Not at the moment. I may add a feature to do this in the future." & Environment.NewLine & Environment.NewLine & "For all other enquiries, please contact Jack Eagles1 on HackForums.", "Programmer's Cloud Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnLogIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogIn.Click
        If bw7z.IsBusy = True Then
            MessageBox.Show("Required files are still being downloaded for Programmer's Cloud. This should not take more than ~1 minute", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Try
            Try
                FtpClientCtl1.RemoteHost = "ols18.com"
                FtpClientCtl1.ControlPort = 21
                FtpClientCtl1.Connect()
                FtpClientCtl1.Login("progpad", ÂÂÁ.ÂÅÂ(ÂÂÁ.鳱儇))
            Catch
            End Try
            Dim found As Boolean
            For Each itm In FtpClientCtl1.GetDetails("/ProgCloud")
                If itm.Name.ToLower = txtUser.Text.ToLower Then
                    found = True
                End If
            Next
            If found = False Then
                MessageBox.Show("Error - account not found. If you don't have an account, login anonymously, or create an account to store documents securely.", "Error")
                Exit Sub
            End If
            Try
                My.Computer.Network.DownloadFile("ftp://progpad@ols18.com/ProgCloud/" & txtUser.Text & "/userauth.7z", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Temp\userauth.7z", "progpad", ÂÂÁ.ÂÅÂ(ÂÂÁ.鳱儇), False, 100000, True)
                Dim zip As New SevenZip.SevenZipExtractor(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Temp\userauth.7z", txtPass.Text)
                zip.ExtractArchive(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Temp")
                frmCloudEditor.uName = txtUser.Text
                frmCloudEditor.uPass = txtPass.Text
                frmCloudEditor.Show()
            Catch ex As Exception
                MessageBox.Show("Error: you entered an incorrect username or password: " & ex.Message)
                Exit Sub
            End Try
            Me.Hide()
        Catch ex As Exception
            MessageBox.Show("An error occured loging in. If you are online, please try again. If this message persists, the server may be down or running very slowly. The error returned was: " & ex.Message, "Error")
        End Try
    End Sub

    Private Sub lblCreateAccount_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblCreateAccount.LinkClicked
        frmCreateProgrammersCloudAccount.ShowDialog()
    End Sub

    Private Sub frmCloudLogin_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub frmSharing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = New Icon(Application.StartupPath & "\Images\Mainicon.ico")
        pbMain.Image = Image.FromFile(Application.StartupPath & "\Images\share_cloud.png")
        bw7z.RunWorkerAsync()
   End Sub

    Private Sub txtUser_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtUser.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPass.Select()
            e.Handled = False
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtUser_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtUser.TextChanged

    End Sub

    Private Sub txtPass_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPass.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLogIn.PerformClick()

            e.Handled = False
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub FtpClientCtl1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FtpClientCtl1.Load

    End Sub

    Private Sub lblAnonLogin_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblAnonLogin.LinkClicked
        txtUser.Text = "Anonymous"
        txtPass.Text = "password"
        btnLogIn.PerformClick()
    End Sub
End Class