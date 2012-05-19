Imports System.ComponentModel

Public Class frmCreateProgrammersCloudAccount

    Friend WithEvents bwCreate As New BackgroundWorker

    Private Sub btnRegister_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegister.Click
        If bwGetFiles.IsBusy = True Then
            MessageBox.Show("Required files are still being downloaded for Programmer's Cloud. This should not take more than ~1 minute", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim mailman As New CHILKATMAILLib2.ChilkatMailMan2
        Dim success As Boolean
        success = mailman.UnlockComponent("MAIL12345678_03197EB5G82G")
        If (success <> True) Then
            MsgBox("Component unlock failed")
            Exit Sub
        End If
        Dim recipient As String
        recipient = txtEmail.Text
        '  Do a DNS MX lookup for the recipient's mail server.
        Dim smtpHostname As String

        If cbxSMTP.Visible = True Then
            smtpHostname = cbxSMTP.SelectedItem.ToString.Substring(cbxSMTP.SelectedItem.ToString.LastIndexOf(": ")).Replace(": ", "")
        Else
            smtpHostname = mailman.MxLookup(recipient)
            If (smtpHostname Is Nothing) Then
                lblSMTP.Visible = True
                cbxSMTP.Visible = True
                MsgBox("Could not retrieve your email's SMTP server. Please select your e-mail provider from the list.", MsgBoxStyle.OkOnly, "Error")
                Exit Sub
            End If
        End If

        '  Set the SMTP server.
        mailman.SmtpHost = smtpHostname


        '  Create a new email object
        Dim email As New CHILKATMAILLib2.ChilkatEmail2
        Dim randConfirmation As New Random
        Dim confirmation As Integer = randConfirmation.Next(500000, 999999999)
        email.subject = "Registration Confirmation for Programmer's Cloud"
        email.From = "donotreply@omegabrowser.tk"
        email.Body = "Hey There," & Environment.NewLine & Environment.NewLine & Environment.NewLine & "This is an email to cofirm your registration to Programmer's Cloud. Please type the authentication code below in the prompt in the Programmer's Cloud application in order to create your account! Thanks!" & Environment.NewLine & Environment.NewLine & confirmation.ToString
            email.AddTo("", recipient)
        success = mailman.SendEmail(email)
        If (success <> True) Then
            MsgBox("Could not send confirmation e-mail. Please contact Jack Eagles1 on HackForums for help: " & mailman.LastErrorText)
            IO.File.WriteAllText("C:\lol.txt", mailman.LastErrorText)
            Exit Sub
        Else
            Dim ib As String = Interaction.InputBox("Please enter the confirmation code sent to your e-mail address!", "Aren't you glad you entered a real e-mail address now...")
            If ib = confirmation.ToString Then
                'CREATE ACCOUNT HERE
                If txtPassword.Text <> "" AndAlso txtUsername.Text <> "" Then
                    bwCreate.RunWorkerAsync()
                    cbxSMTP.Visible = False
                    lblSMTP.Visible = True
                    txtUsername.Enabled = False
                    txtPassword.Enabled = False
                    txtEmail.Enabled = False
                    lblSMTP.Text = "Creating your account..."
                Else
                    MessageBox.Show("Error - Please enter a username and password!", "Error", MessageBoxButtons.OK)
                End If
            Else
                MessageBox.Show("Error - the confirmation code you have entered is not correct!", "Error", MessageBoxButtons.OK)
            End If
        End If
    End Sub

    Private Sub bwCreate_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwCreate.DoWork
        Try

            ftpClientCtl1.RemoteHost = "ols18.com"
            ftpClientCtl1.ControlPort = 21
            ftpClientCtl1.Connect()
            FtpClientCtl1.Login("progpad", ÂÂÁ.ÂÅÂ(ÂÂÁ.鳱儇))

            For Each itm In ftpClientCtl1.GetDetails("/ProgCloud")
                If itm.Name.ToLower = txtUsername.Text.ToLower Then
                    MessageBox.Show("Error - A user with the Username specified already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Next
            Try
                ftpClientCtl1.MkDir("/ProgCloud/" & txtUsername.Text)
                Dim zip As New SevenZip.SevenZipCompressor
                zip.ArchiveFormat = SevenZip.OutArchiveFormat.SevenZip
                zip.ZipEncryptionMethod = SevenZip.ZipEncryptionMethod.Aes256
                zip.CompressFilesEncrypted("userauth.7z", txtPassword.Text, Application.StartupPath & "\Cloud\Settings\Auth.nps")
                My.Computer.Network.UploadFile(Application.StartupPath & "\userauth.7z", "ftp://progpad@ols18.com/ProgCloud/" & txtUsername.Text & "/userauth.7z", "progpad", ÂÂÁ.ÂÅÂ(ÂÂÁ.鳱儇), False, 100000, True)
                My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\userauth.7z")
                MessageBox.Show("Account Created - you may now log in!", "Done", MessageBoxButtons.OK)
            Catch ex As Exception
                MessageBox.Show("Could not create the account. This was not due to a conflict of usernames", "Error")
            End Try
        Catch ex As Exception
            MessageBox.Show("Could not create account. The error was as follows: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub bwCreate_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwCreate.RunWorkerCompleted
        Me.Close()
    End Sub

    Private Sub frmCreateProgrammersCloudAccount_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub frmCreateProgrammersCloudAccount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = New Icon(Application.StartupPath & "\Images\Mainicon.ico")
        bwGetFiles.RunWorkerAsync()
    End Sub

    Private Sub bwGetFiles_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwGetFiles.DoWork
        If My.Computer.FileSystem.DirectoryExists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\ProgPad") Then
            Exit Sub
        End If
        MkDir(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\ProgPad")
        My.Computer.Network.DownloadFile("http://dl.dropbox.com/u/7543521/Executables/ProgPad/ChilkatMail_v8.dll", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\ProgPad\ChilkatMail_v8.dll")
        My.Computer.Network.DownloadFile("http://dl.dropbox.com/u/7543521/Executables/ProgPad/ChilkatCert.dll", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\ProgPad\ChilkatCert.dll")
        My.Computer.Network.DownloadFile("http://dl.dropbox.com/u/7543521/Executables/ProgPad/ChilkatUtil.dll", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\ProgPad\ChilkatUtil.dll")
        Shell("regsvr32 /s """ & Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\ProgPad\ChilkatMail_v8.dll""")
        Shell("regsvr32 /s """ & Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\ProgPad\ChilkatCert.dll""")
        Shell("regsvr32 /s """ & Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\ProgPad\ChilkatUtil.dll""")
    End Sub

    Private Sub txtUsername_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtUsername.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPassword.Select()
            e.Handled = False
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtEmail_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtEmail.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnRegister.PerformClick()
            e.Handled = False
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtEmail.Select()
            e.Handled = False
            e.SuppressKeyPress = True
        End If
    End Sub

End Class