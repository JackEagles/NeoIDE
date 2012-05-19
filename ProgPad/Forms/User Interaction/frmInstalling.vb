Imports Microsoft.Win32

Public Class frmInstalling

    Private Sub frmInstalling_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\FirstRun.txt") Then
            MessageBox.Show("First-run setup failed. Exiting", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        End If
    End Sub

    Private Sub frmInstalling_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\NeoIDE") IsNot Nothing Then
            lblInfo.Text = "Please click 'Proceed' in order to upgrade:"
            rbPortable.Enabled = False
            txtInstallLocation.Enabled = False
            btnBrowse.Enabled = False
        End If
        txtInstallLocation.Text = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)
        Me.Icon = New Icon(Application.StartupPath & "\Images\Mainicon.ico")
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Dim fbd As New FolderBrowserDialog
        fbd.Description = "Please select an install location"
        fbd.ShowNewFolderButton = True
        If fbd.ShowDialog = DialogResult.OK Then
            txtInstallLocation.Text = fbd.SelectedPath
        End If
    End Sub

    Private Sub rbInstall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbInstall.CheckedChanged
        txtInstallLocation.Enabled = rbInstall.Checked
        lblInstLoc.Enabled = rbInstall.Checked
        btnBrowse.Enabled = rbInstall.Checked
        chkInstallFeatures.Enabled = rbInstall.Checked
        chkInstallFeatures.Checked = rbInstall.Checked
    End Sub

    Private Sub btnProceed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProceed.Click
        If rbInstall.Checked = True Then

            If My.Computer.FileSystem.DirectoryExists(txtInstallLocation.Text) Then
                Try
                    MkDir(txtInstallLocation.Text & "\NeoIDE")
                    IO.File.Delete(Application.StartupPath & "\FirstRun.txt")
                    My.Computer.FileSystem.CopyDirectory(Application.StartupPath, txtInstallLocation.Text & "\NeoIDE", True)
                    If chkInstallFeatures.Checked = True Then
                        Dim objShell, objLink
                        objShell = CreateObject("WScript.Shell")
                        objLink = objShell.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) & "\NeoIDE.lnk")
                        objLink.TargetPath = txtInstallLocation.Text & "\NeoIDE\neoide.exe"
                        objLink.WindowStyle = 1
                        objLink.Save()

                        Dim objShell2, objLink2
                        objShell2 = CreateObject("WScript.Shell")
                        objLink2 = objShell2.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) & "\Uninstall NeoIDE.lnk")
                        objLink2.TargetPath = txtInstallLocation.Text & "\NeoIDE\neoide.exe"
                        objLink2.IconLocation = txtInstallLocation.Text & "\NeoIDE\Images\uninstall.ico"
                        objLink2.WindowStyle = 1
                        objLink2.Arguments = "/uninstall"
                        objLink2.Save()

                        Dim objShell3, objLink3
                        objShell3 = CreateObject("WScript.Shell")
                        objLink3 = objShell3.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\NeoIDE.lnk")
                        objLink3.TargetPath = txtInstallLocation.Text & "\NeoIDE\neoide.exe"
                        objLink3.WindowStyle = 1
                        objLink3.Save()
                        Dim regKey As RegistryKey
                        regKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\NeoIDE")
                        regKey.SetValue("InstallLocation", txtInstallLocation.Text & "\NeoIDE", RegistryValueKind.String)
                        regKey.SetValue("DisplayIcon", Application.ExecutablePath, RegistryValueKind.String)
                        regKey.SetValue("DisplayName", "NeoIDE", RegistryValueKind.String)
                        regKey.SetValue("UninstallString", """" & txtInstallLocation.Text & "\NeoIDE\neoide.exe" & """" & " /uninstall", RegistryValueKind.String)
                        Me.Close()
                    End If
                    Dim Info As ProcessStartInfo = New ProcessStartInfo()
                    Info.Arguments = "/C ping 1.1.1.1 -n 1 -w 3000 > Nul & rd /s /q """ & Application.StartupPath & """"
                    Info.FileName = "cmd.exe"
                    Process.Start(Info)
                    Process.Start(txtInstallLocation.Text & "\NeoIDE\neoide.exe")
                    End
                Catch ex As Exception
                    IO.File.WriteAllText("true", Application.StartupPath & "\Firstrun.txt", System.Text.Encoding.Default)
                    MessageBox.Show("An error occured during the installation: " & ex.Message, "Error", MessageBoxButtons.OK)
                    Exit Sub
                End Try
            Else
                IO.File.WriteAllText(Application.StartupPath & "\Firstrun.txt", "true", System.Text.Encoding.Default)
                MessageBox.Show("Specified install path does not exist!", "Error", MessageBoxButtons.OK)
                Exit Sub
            End If
        Else
            IO.File.Delete(Application.StartupPath & "\Firstrun.txt")
            Me.Close()
        End If
    End Sub
End Class