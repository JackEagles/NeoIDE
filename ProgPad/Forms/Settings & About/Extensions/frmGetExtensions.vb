Imports System.Net
Imports System.Xml
Imports System.ComponentModel
Imports System.IO
Imports System.Collections.Specialized

Public Class frmGetExtensions
    Friend WithEvents bwInitial, bwImages As New BackgroundWorker
    Friend WithEvents wr As New WebClient
    Dim AddonsXML As String

    Private Sub frmGetExtensions_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        pbAddonLargeImage.Image = Image.FromFile(Application.StartupPath & "\Images\loading.gif")
        tcMain.Controls.Remove(tbAddonDetails)
        tcMain.Controls.Remove(tbDownloadingAddon)
        tcMain.Controls.Remove(tbDownloadingTheme)
        txtAddonDescription.SelectionAlignment = ExtendedRichTextBox.RichTextAlign.Justify
        bwInitial.RunWorkerAsync()



        For Each fi In New DirectoryInfo(Application.StartupPath & "\Addons").GetFiles
            If fi.Extension = ".txt" Then
                Dim sizeOfAddon As Integer = 0
                Dim xmlDoc As New XmlDocument
                xmlDoc.Load(fi.FullName)
                Dim ourNode As New TreeNode
                ourNode.Text = xmlDoc.GetElementsByTagName("Name").Item(0).InnerText
                ourNode.Nodes.Add("Description: " & xmlDoc.GetElementsByTagName("Description").Item(0).InnerText)
                ourNode.Nodes.Add("Author: " & xmlDoc.GetElementsByTagName("Author").Item(0).InnerText)
                ourNode.Nodes.Add("Version: " & xmlDoc.GetElementsByTagName("Version").Item(0).InnerText)
                Dim finfo As New IO.FileInfo(Application.StartupPath & "\Addons\" & xmlDoc.GetElementsByTagName("PluginFile").Item(0).InnerText)
                sizeOfAddon += finfo.Length
                For Each itm In New DirectoryInfo(Application.StartupPath & "\Addons\Resources\" & xmlDoc.GetElementsByTagName("DataDir").Item(0).InnerText).GetFiles
                    sizeOfAddon += itm.Length
                Next
                ourNode.Nodes.Add("Size of addon: " & sizeOfAddon / 1000 & "kb")
                ourNode.Nodes.Add("ID: " & xmlDoc.GetElementsByTagName("ID").Item(0).InnerText)
                tvInstalledAddons.Nodes.Add(ourNode)
            End If
        Next

    End Sub

    Dim buttonCollection, themeCollection As New Collection
    Private Sub bw_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwInitial.DoWork
        Dim xmlDoc As New XmlDocument
        xmlDoc.LoadXml(getText("http://dl.dropbox.com/u/7543521/Webpages/NeoIDE/plugins.xml"))
        For Each itm As XmlNode In xmlDoc.GetElementsByTagName("Addon")
            Dim AddonButton As New AddonButton
            AddonButton.Title.Text = itm.ChildNodes(0).InnerText
            AddonButton.Description.Text = itm.ChildNodes(1).InnerText
            AddonButton.Installed.Text = ""
            AddonButton.Tag = itm.OuterXml
            buttonCollection.Add(AddonButton)
            AddHandler AddonButton.Click, AddressOf ShowAddonInfo
            AddHandler AddonButton.Title.Click, AddressOf ShowAddonInfoChildControl
            AddHandler AddonButton.Description.Click, AddressOf ShowAddonInfoChildControl
            AddHandler AddonButton.ImageBox.Click, AddressOf ShowAddonInfoChildControl
            AddHandler AddonButton.Installed.Click, AddressOf ShowAddonInfoChildControl
        Next
        Dim xmlDoc2 As New XmlDocument
        xmlDoc2.LoadXml(getText("http://dl.dropbox.com/u/7543521/Webpages/NeoIDE/themes.xml"))
        For Each itm As XmlNode In xmlDoc2.GetElementsByTagName("Theme")
            Dim ThemeButton As New AddonButton
            ThemeButton.Title.Text = itm.ChildNodes(0).InnerText
            ThemeButton.Description.Text = itm.ChildNodes(1).InnerText
            ThemeButton.Installed.Text = ""
            For Each fi In New IO.DirectoryInfo(Application.StartupPath & "\Themes").GetFiles
                If fi.Extension = ".txt" Then
                    Dim xmlDoc3 As New XmlDocument
                    xmlDoc3.Load(fi.FullName)
                    If itm.ChildNodes(5).InnerText = xmlDoc3.ChildNodes(0).ChildNodes(5).InnerText Then
                        ThemeButton.Installed.Text = "-  Installed"
                    End If
                End If
            Next
            ThemeButton.Tag = itm.OuterXml
            themeCollection.Add(ThemeButton)
        Next
    End Sub

    Private Sub bw_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwInitial.RunWorkerCompleted
        For Each itm As AddonButton In buttonCollection
            AddonContainer.Controls.Add(itm)
        Next
        For Each itm As AddonButton In themeCollection
            ThemeContainer.Controls.Add(itm)
        Next
        bwImages.RunWorkerAsync()
        lblDownloading.Visible = False
        pbLoadingPlugins.Visible = False
    End Sub
    Public gettingLargeImage As Boolean
    Dim ImageURI As String
    Private Sub bwImages_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwImages.DoWork
        If gettingLargeImage = False Then
            For Each itm In AddonContainer.Controls
                If TypeOf itm Is AddonButton Then
                    Dim xmlDoc As New XmlDocument
                    xmlDoc.LoadXml(itm.Tag.ToString)
                    CType(itm, AddonButton).ImageBox.Image = getImage(xmlDoc.ChildNodes(0).ChildNodes(2).InnerText)
                End If
            Next
            For Each itm In ThemeContainer.Controls
                If TypeOf itm Is AddonButton Then
                    Dim xmlDoc As New XmlDocument
                    xmlDoc.LoadXml(itm.Tag.ToString)
                    CType(itm, AddonButton).ImageBox.Image = getImage(xmlDoc.ChildNodes(0).ChildNodes(2).InnerText)
                End If
            Next
        Else
            pbAddonLargeImage.Image = getImage(ImageURI)
        End If
    End Sub


    Function getImage(ByVal aUrl As String) As Image
        Dim response As WebResponse
        Dim remoteStream As Stream
        Dim readStream As StreamReader
        Dim request As WebRequest = WebRequest.Create(aUrl)
        response = request.GetResponse
        remoteStream = response.GetResponseStream
        readStream = New StreamReader(remoteStream)
        Return System.Drawing.Image.FromStream(remoteStream)
        response.Close()
        remoteStream.Close()
        readStream.Close()
    End Function

    Function getText(ByVal aUrl As String) As String
        Dim response As WebResponse
        Dim remoteStream As Stream
        Dim readStream As StreamReader
        Dim request As WebRequest = WebRequest.Create(aUrl)
        response = request.GetResponse
        remoteStream = response.GetResponseStream
        readStream = New StreamReader(remoteStream)
        Return readStream.ReadToEnd
        response.Close()
        remoteStream.Close()
        readStream.Close()
    End Function
    Dim xDocText As String
    Private Sub ShowAddonInfo(sender As System.Object, e As System.EventArgs)
        xDocText = sender.Tag.ToString
        ShowAddonDetails(xDocText)
    End Sub
    Private Sub ShowAddonInfoChildControl(sender As System.Object, e As System.EventArgs)
        Try
            xDocText = CType(sender, Control).Parent.Tag.ToString
        Catch ex As Exception
            xDocText = CType(sender, Control).Parent.Parent.Tag.ToString
        End Try
        ShowAddonDetails(xDocText)
    End Sub

    Private Sub ShowAddonDetails(ByVal XML As String)
        Dim xmlDoc As New XmlDocument
        xmlDoc.LoadXml(XML)
        btnInstallAddon.Text = "Install"

        tcMain.Controls.Add(tbAddonDetails)
        tcMain.Controls.Remove(tbAddons)
        tcMain.Controls.Remove(tbThemes)
        tcMain.Controls.Remove(tbInstalled)
        lblAddonName.Text = xmlDoc.ChildNodes(0).ChildNodes(0).InnerText
        txtAddonDescription.Text = xmlDoc.ChildNodes(0).ChildNodes(3).InnerText
        gettingLargeImage = True
        ImageURI = xmlDoc.ChildNodes(0).ChildNodes(4).InnerText
        btnInstallAddon.Tag = XML
        lblAuthor.Text = "Author: " & xmlDoc.ChildNodes(0).ChildNodes(6).InnerText
        bwImages.RunWorkerAsync()
        For Each fi In New DirectoryInfo(Application.StartupPath & "\Addons").GetFiles
            If fi.Extension = ".txt" Then
                Dim secondaryDoc As New XmlDocument
                secondaryDoc.Load(fi.FullName)
                If xmlDoc.GetElementsByTagName("ID").Item(0).InnerText = secondaryDoc.GetElementsByTagName("ID").Item(0).InnerText Then
                    btnInstallAddon.Text = "Uninstall"
                End If
            End If
        Next
    End Sub

    Private Sub btnBack_Click(sender As System.Object, e As System.EventArgs) Handles btnBack.Click
        pbAddonLargeImage.Image = Image.FromFile(Application.StartupPath & "\Images\loading.gif")
        tcMain.Controls.Remove(tbAddonDetails)
        tcMain.Controls.Add(tbAddons)
        tcMain.Controls.Add(tbThemes)
        tcMain.Controls.Add(tbInstalled)
        tcMain.SelectedIndex = 0
    End Sub

    Friend WithEvents bwAddonDownloader As New BackgroundWorker
    Friend WithEvents wcDownloadAddon As New WebClient
    Friend WithEvents tmrAddonDownloaderInfoUpdater As New Timer

    Dim AddonDLLFiles As New StringCollection
    Dim AddonDataFiles As New StringCollection
    Dim AddonDataDirectory As String
    Dim AddonFile As String


    Dim DownloadFileName As String
    Dim DownloadExtractDirName As String
    Dim DownloadingAddon As Boolean = False
    Dim DownloadEvents As String

    Private Sub btnInstallAddon_Click(sender As System.Object, e As System.EventArgs) Handles btnInstallAddon.Click
        If btnInstallAddon.Text = "Install" Then
            DownloadingAddon = True
            tcMain.Controls.Add(tbDownloadingAddon)
            tcMain.Controls.Remove(tbAddonDetails)
            AddonDLLFiles.Clear()
            AddonDataFiles.Clear()

            DownloadFileName = New Random().Next(500000, 1000000000)
            Dim xmlDoc As New XmlDocument
            xmlDoc.LoadXml(btnInstallAddon.Tag.ToString)

            For Each itm As XmlNode In xmlDoc.GetElementsByTagName("Dll")
                AddonDLLFiles.Add(itm.InnerText)
            Next
            For Each itm As XmlNode In xmlDoc.GetElementsByTagName("DataFile")
                AddonDataFiles.Add(itm.InnerText)
            Next
            AddonDataDirectory = xmlDoc.GetElementsByTagName("DataDir").Item(0).InnerText
            AddonFile = xmlDoc.GetElementsByTagName("PluginFile").Item(0).InnerText
            IO.File.WriteAllText(Application.StartupPath & "\Addons\" & AddonFile.Replace(".dll", ".txt"), btnInstallAddon.Tag.ToString)

            tmrAddonDownloaderInfoUpdater.Interval = 50
            tmrAddonDownloaderInfoUpdater.Start()

            wcDownloadAddon.DownloadFileAsync(New Uri(xmlDoc.GetElementsByTagName("PluginLocation").Item(0).InnerText), Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Temp\" & DownloadFileName)
            DownloadEvents &= "Downloading addon started..." & Environment.NewLine
        ElseIf btnInstallAddon.Text = "Uninstall" Then
            Dim xmlDoc As New XmlDocument
            xmlDoc.LoadXml(btnInstallAddon.Tag.ToString)
            UninstallAddon(xmlDoc)
        End If
    End Sub

    Private Sub bwAddonDownloader_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwAddonDownloader.DoWork
        DownloadEvents &= "Unpacking addon..." & Environment.NewLine
        Dim un7z As New SevenZip.SevenZipExtractor(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Temp\" & DownloadFileName)
        DownloadExtractDirName = New Random().Next(500000, 1000000000)
        un7z.ExtractArchive(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Temp\" & DownloadExtractDirName)
        DownloadEvents &= "Addon unpacked successfully..." & Environment.NewLine
        If IO.Directory.Exists(Application.StartupPath & "\Addons\Resources\" & AddonDataDirectory) = False Then
            IO.Directory.CreateDirectory(Application.StartupPath & "\Addons\Resources\" & AddonDataDirectory)
        End If
        DownloadEvents &= "Created addon data directory..." & Environment.NewLine
        For Each itm In AddonDLLFiles
                IO.File.Copy((Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Temp\" & DownloadExtractDirName) & "\" & itm, Application.StartupPath & "\" & itm)
        Next

        DownloadEvents &= "Moved resource files for addon..." & Environment.NewLine
        For Each itm In AddonDataFiles
            IO.File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Temp\" & DownloadExtractDirName & "\" & itm, Application.StartupPath & "\Addons\Resources\" & AddonDataDirectory & "\" & itm)
        Next
        DownloadEvents &= "Moved dll files for addon..." & Environment.NewLine
        IO.File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Temp\" & DownloadExtractDirName & "\" & AddonFile, Application.StartupPath & "\Addons\" & AddonFile)
        DownloadEvents &= "Installed Addon..." & Environment.NewLine
    End Sub

    Private Sub wcDownloadAddon_DownloadFileCompleted(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs) Handles wcDownloadAddon.DownloadFileCompleted
        bwAddonDownloader.RunWorkerAsync()
        DownloadEvents &= "Finished downloading addon..." & Environment.NewLine
    End Sub

    Private Sub wcDownloadAddon_DownloadProgressChanged(sender As Object, e As System.Net.DownloadProgressChangedEventArgs) Handles wcDownloadAddon.DownloadProgressChanged
        If DownloadingAddon = True Then
            pbAddonDownloading.Value = e.ProgressPercentage
            lblDownloaded.Text = "Downloaded: " & e.BytesReceived / 1000 & "/" & e.TotalBytesToReceive / 1000 & "kb"
        End If
    End Sub

    Private Sub tmrAddonDownloaderInfoUpdater_Tick(sender As Object, e As System.EventArgs) Handles tmrAddonDownloaderInfoUpdater.Tick
        txtAddonEvents.Text = DownloadEvents
    End Sub

    Private Sub bwAddonDownloader_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwAddonDownloader.RunWorkerCompleted
        tmrAddonDownloaderInfoUpdater.Stop()
        DownloadEvents = ""
        MessageBox.Show("Addon downloaded & Installed! Please re-start the program for changed to take effect!", "Addon", MessageBoxButtons.OK)
        tcMain.Controls.Remove(tbDownloadingAddon)
        tcMain.Controls.Add(tbAddons)
        tcMain.Controls.Add(tbThemes)
        tcMain.Controls.Add(tbInstalled)
    End Sub

    Private Sub UninstallAddon(ByVal XMLFile As XmlDocument)
        Dim mbres As DialogResult = MessageBox.Show("Do you want to uninstall this addon? The program will re-start immediately after the uninstall, meaning that any unsaved data may be lost. Please make sure that you have saved all of your open documents before continuing!", "Information", MessageBoxButtons.YesNo)
        If mbres = Windows.Forms.DialogResult.Yes Then
            Dim batFileName As String = New Random().Next(500000, 1000000000) & ".bat"
            Dim batFile As String = "title NeoIDE Addon Uninstaller" & Environment.NewLine & "@echo off" & Environment.NewLine & "cls" & Environment.NewLine
            batFile &= "echo This script will uninstall the NeoIDE addon '" & XMLFile.GetElementsByTagName("Name").Item(0).InnerText & "'. Do you want to continue?" & Environment.NewLine & "pause" & Environment.NewLine

            Dim dataLocation As String = Application.StartupPath & "\Addons\Resources\" & XMLFile.GetElementsByTagName("DataDir").Item(0).InnerText
            batFile &= "rd /s /q " & """" & dataLocation & """""" & Environment.NewLine
            Dim addonFile As String = Application.StartupPath & "\Addons\" & XMLFile.GetElementsByTagName("PluginFile").Item(0).InnerText
            batFile &= "del /f /q " & """" & addonFile & """" & Environment.NewLine
            batFile &= "del /f /q " & """" & addonFile.Replace(".dll", ".txt") & """" & Environment.NewLine
            For Each itm As XmlNode In XMLFile.GetElementsByTagName("Dll")
                batFile &= "del /f /q " & """" & Application.StartupPath & "\" & itm.InnerText & """" & Environment.NewLine
            Next
            batFile &= "echo Completed... press any key to restart NeoIDE..." & Environment.NewLine
            batFile &= "pause" & Environment.NewLine
            batFile &= """" & Application.ExecutablePath & """" & Environment.NewLine
            batFile &= "exit"
            IO.File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\temp\" & batFileName, batFile)
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\temp\" & batFileName)
            End
        End If
    End Sub

    Private Sub btnUninstallSelected_Click(sender As System.Object, e As System.EventArgs) Handles btnUninstallSelected.Click
        For Each itm In New DirectoryInfo(Application.StartupPath & "\Addons").GetFiles()
            If itm.Extension = ".txt" Then
                Dim xmlDoc As New XmlDocument
                xmlDoc.Load(itm.FullName)
                If xmlDoc.GetElementsByTagName("ID").Item(0).InnerText = tvInstalledAddons.SelectedNode.Nodes(4).Text.Replace("ID: ", "") Then
                    UninstallAddon(xmlDoc)
                End If
            End If
        Next
    End Sub
End Class