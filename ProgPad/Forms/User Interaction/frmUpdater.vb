Imports System.Net
Imports System.Xml
Imports System.ComponentModel

Public Class frmUpdater
    Dim updateURI As String
    Dim xDoc As New XmlDocument
    Friend WithEvents bwGetXML As New BackgroundWorker

    Private Sub frmUpdater_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = New Icon(Application.StartupPath & "\Images\Mainicon.ico")
        pbUpdate.Image = Image.FromFile(Application.StartupPath & "\Images\Download.png")
        lblCurrentVersion.Text = "Current program version: " & My.Settings.Version.Substring(0, 1) & "." & My.Settings.Version.Substring(1, 2)
        bwGetXML.RunWorkerAsync()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Friend WithEvents DownloaderWC As New WebClient
    Dim jdlf As Boolean = False
    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            If Application.StartupPath.ToLower.Contains("program files") Then
                DownloaderWC.DownloadFileAsync(New Uri(updateURI), Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Temp\progpadupdate.7z")
            Else
                MessageBox.Show("NeoIDE is running in portable mode. The update will be downloaded to your Desktop!")
                DownloaderWC.DownloadFileAsync(New Uri(updateURI), Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Temp\progpadupdateportable.7z")
            End If
            lblStatus.Text = "Status: Downloading files."
            btnUpdate.Enabled = False
        Catch
        End Try
    End Sub

    Private Sub DownloaderWC_DownloadFileCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs) Handles DownloaderWC.DownloadFileCompleted
        tmrExtract.Start()
    End Sub

    Private Sub DownloaderWC_DownloadProgressChanged(ByVal sender As Object, ByVal e As System.Net.DownloadProgressChangedEventArgs) Handles DownloaderWC.DownloadProgressChanged
        pbDownloadProgress.Maximum = 100
        pbDownloadProgress.Value = e.ProgressPercentage
    End Sub

    Private Sub tmrExtract_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrExtract.Tick
        tmrExtract.Stop()
        If jdlf = False Then
            If Application.StartupPath.ToLower.Contains("program files") Then
                SevenZip.SevenZipExtractor.SetLibraryPath(Application.StartupPath & "\7z.dll")
                Dim zip As New SevenZip.SevenZipExtractor(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Temp\progpadupdate.7z")
                If My.Computer.FileSystem.DirectoryExists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Temp\progpadupdate") = False Then
                    My.Computer.FileSystem.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Temp\progpadupdate")
                Else
                    My.Computer.FileSystem.DeleteDirectory((Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Temp\progpadupdate"), FileIO.DeleteDirectoryOption.DeleteAllContents)
                    My.Computer.FileSystem.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Temp\progpadupdate")
                End If
                zip.ExtractArchive(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Temp\progpadupdate")
                Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Temp\progpadupdate\neoide.exe")
                Application.Exit()
            Else
                SevenZip.SevenZipExtractor.SetLibraryPath(Application.StartupPath & "\7z.dll")
                Dim zip As New SevenZip.SevenZipExtractor(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Temp\progpadupdateportable.7z")
                If My.Computer.FileSystem.DirectoryExists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\NeoIDE") = False Then
                    My.Computer.FileSystem.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\NeoIDE")
                Else
                    My.Computer.FileSystem.DeleteDirectory((Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\NeoIDE"), FileIO.DeleteDirectoryOption.DeleteAllContents)
                    My.Computer.FileSystem.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\NeoIDE")
                End If
                zip.ExtractArchive(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\NeoIDE")
                MessageBox.Show("Update has been downloaded & extracted to your desktop. The program will now exit.", "Information")
                Application.Exit()
            End If
        End If
            If jdlf = True Then
                jdlf = False
                DownloaderWC.DownloadFileAsync(New Uri(updateURI), Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Temp\progpadupdate.7z")
            End If
    End Sub
    Dim errD As Boolean
    Private Sub bwGetXML_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwGetXML.DoWork
        Try
            Dim wc As New WebClient
            Dim wReq As HttpWebRequest = HttpWebRequest.Create("http://dl.dropbox.com/u/7543521/Executables/ProgPad/update.xml")
            Dim reader As New IO.StreamReader(wReq.GetResponse.GetResponseStream)
            xDoc.LoadXml(reader.ReadToEnd)
        Catch
            errD = True
            MsgBox("Could not check for updates.")
        End Try

    End Sub

    Private Sub bwGetXML_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwGetXML.RunWorkerCompleted
        If errD = True Then
            Me.Close()
            Exit Sub
        End If
        
        With xDoc.GetElementsByTagName("Version").Item(0)
            lblNewProgram.Text = "New Version: " & .InnerText.Substring(0, 1) & "." & .InnerText.Substring(1, 2)
        End With
        If My.Settings.Version < xDoc.GetElementsByTagName("Version").Item(0).InnerText Then
            lblStatus.Text = "Status: Waiting for user..."
            btnUpdate.Enabled = True
            pbDownloadProgress.Style = ProgressBarStyle.Blocks
        Else
            MsgBox("No updates available")
            Me.Close()
        End If
        For Each itm In xDoc.GetElementsByTagName("Description").Item(0).InnerText.Split("$NL")
            txtUpdateInfo.Text &= itm.Replace("NL", "") & Environment.NewLine
        Next
        updateURI = xDoc.GetElementsByTagName("UpdateURI").Item(0).InnerText
    End Sub
End Class