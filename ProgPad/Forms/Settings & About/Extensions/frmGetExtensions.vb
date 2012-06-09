Imports System.Net
Imports System.Xml
Imports System.ComponentModel
Imports System.IO
Imports System.Collections.Specialized
Imports System.Threading

Public Class frmGetExtensions
    Friend WithEvents bwInitial, bwImages As New BackgroundWorker
    Friend WithEvents wr As New WebClient
    Dim AddonsXML As String
    Dim BarRestart As Boolean


    Private Sub frmGetExtensions_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If IO.File.Exists(frmMain.ThemeFile) = False Then
            e.Cancel = True
            MessageBox.Show("No themes are installed, or the currently applied theme has been uninstalled. Please install and/or select a new theme before closing this form!")
        Else
            Me.Dispose()
        End If

    End Sub

    Private Sub frmGetExtensions_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        pbAddonLargeImage.Image = Image.FromFile(Application.StartupPath & "\Images\loading.gif")
        tcMain.Controls.Remove(tbAddonDetails)
        tcMain.Controls.Remove(tbDownloadingAddon)
        txtAddonDescription.SelectionAlignment = ExtendedRichTextBox.RichTextAlign.Justify
        bwInitial.RunWorkerAsync()


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
            For Each fi In New IO.DirectoryInfo(Application.StartupPath & "\Addons").GetFiles
                If fi.Extension = ".txt" Then
                    Dim xmlDoc3 As New XmlDocument
                    xmlDoc3.Load(fi.FullName)
                    If itm.ChildNodes(8).InnerText = xmlDoc3.ChildNodes(0).ChildNodes(8).InnerText Then
                        AddonButton.Installed.Text = "-  Installed"
                    End If
                End If
            Next

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
            AddHandler ThemeButton.Click, AddressOf ShowAddonInfo
            AddHandler ThemeButton.Title.Click, AddressOf ShowThemeInfo
            AddHandler ThemeButton.Description.Click, AddressOf ShowThemeInfo
            AddHandler ThemeButton.ImageBox.Click, AddressOf ShowThemeInfo
            AddHandler ThemeButton.Installed.Click, AddressOf ShowThemeInfo
        Next
    End Sub

    Private Sub ShowThemeInfo(sender As System.Object, e As System.EventArgs)
        Dim sendR As AddonButton
        Try
            xDocText = sender.Tag.ToString
            sendR = sender
        Catch ex As Exception
            Try
                xDocText = CType(sender, Control).Parent.Tag.ToString
                sendR = sender.Parent
            Catch ex2 As Exception
                xDocText = CType(sender, Control).Parent.Parent.Tag.ToString
                sendR = sender.Parent.Parent
            End Try
        End Try
        If sendR.Installed.Text.Contains("Installed") = False Then
            Dim thrd As New Thread(AddressOf DownloadTheme)
            thrd.Start(xDocText)
            nbMain.Text = "Theme downloaded && Installed. You can apply the theme on the 'Installed Themes' tab."
            nbMain.Shw(True)
            sendR.Installed.Text = "-  Installed"
        Else
            Dim xmlDoc As New XmlDocument
            xmlDoc.LoadXml(xDocText)
            If UninstallTheme(xmlDoc) = True Then
                sendR.Installed.Text = ""
            End If
        End If
    End Sub

    Private Sub DownloadTheme(ByVal theme As String)
        Dim xmlDoc As New XmlDocument
        xmlDoc.LoadXml(theme)
        Dim loc As String = xmlDoc.ChildNodes(0).ChildNodes(4).InnerText
        My.Computer.Network.DownloadFile(loc, Application.StartupPath & "\Themes\" & loc.Substring(loc.LastIndexOf("/")).Replace("/", ""))
        IO.File.WriteAllText(Application.StartupPath & "\Themes\" & loc.Substring(loc.LastIndexOf("/")).Replace("/", "").Replace(".dll", ".txt"), theme)
        BarRestart = False
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
        ImageURI = xmlDoc.ChildNodes(0).ChildNodes(4).InnerText
        btnInstallAddon.Tag = XML
        Dim ImageThread As New Thread(AddressOf GetPictureboxImage)
        ImageThread.Start()

        lblAuthor.Text = "Author: " & xmlDoc.ChildNodes(0).ChildNodes(6).InnerText
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

    Private Sub GetPictureboxImage()
        pbAddonLargeImage.Image = getImage(ImageURI)
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
    Friend WithEvents tmrAddonDownloaderInfoUpdater As New System.Windows.Forms.Timer

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
            Try
                IO.File.Copy((Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Temp\" & DownloadExtractDirName) & "\" & itm, Application.StartupPath & "\" & itm)
            Catch ex As Exception
                MessageBox.Show("A non fatal error occured during the addon installation: one of the native dll files required for the addon to function properly is already present in the application startup directory. This will be ignored, but if the version of the file in the startup directory is different to the version of the file required by the Addon, errors may occur.", "Non fatal error")
            End Try
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
        BarRestart = True
        nbMain.Flash(500, 5)
        nbMain.Shw(True)
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

    Private Sub nbMain_Click(sender As System.Object, e As System.EventArgs) Handles nbMain.Click
        If BarRestart = True Then
            Process.Start(Application.ExecutablePath)
            End
        End If
    End Sub

    Private Function UninstallTheme(ByVal XMLFile As XmlDocument) As Boolean
        Try
            Dim mbres As DialogResult = MessageBox.Show("Do you want to uninstall this theme?", "Uninstall theme", MessageBoxButtons.YesNo)
            If mbres = DialogResult.Yes Then
                Dim loc As String = XMLFile.ChildNodes(0).ChildNodes(4).InnerText
                IO.File.Delete(Application.StartupPath & "\Themes\" & loc.Substring(loc.LastIndexOf("/")).Replace("/", ""))
                IO.File.Delete(Application.StartupPath & "\Themes\" & loc.Substring(loc.LastIndexOf("/")).Replace("/", "").Replace(".dll", ".txt"))
                RefreshThemeBox()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub tcMain_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tcMain.SelectedIndexChanged
        RefreshThemeBox()
    End Sub

    Private Sub RefreshThemeBox()
        On Error Resume Next
        If tcMain.SelectedTab.Text = "Installed Themes && Addons" Then
            tvInstalledAddons.Nodes.Clear()
            tvInstalledThemes.Nodes.Clear()
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
                    For Each itm As XmlNode In xmlDoc.GetElementsByTagName("Dll")
                        Dim dllInfo As New FileInfo(Application.StartupPath & "\" & itm.InnerText)
                        sizeOfAddon += dllInfo.Length
                    Next
                    sizeOfAddon = sizeOfAddon / 1024
                    If sizeOfAddon.ToString.Contains(".") Then
                        Dim LastPart As String = sizeOfAddon.ToString.Substring(sizeOfAddon.ToString.LastIndexOf("."))
                        ourNode.Nodes.Add("Size of addon: " & sizeOfAddon.ToString.Replace(LastPart, "") & "kb")
                    Else
                        ourNode.Nodes.Add("Size of addon: " & sizeOfAddon & "kb")
                    End If
                    ourNode.Nodes.Add("ID: " & xmlDoc.GetElementsByTagName("ID").Item(0).InnerText)
                    tvInstalledAddons.Nodes.Add(ourNode)
                End If
            Next
            For Each fi In New DirectoryInfo(Application.StartupPath & "\Themes").GetFiles
                If fi.Extension = ".txt" Then
                    Dim xmlDoc As New XmlDocument
                    xmlDoc.Load(fi.FullName)
                    Dim ourNode As New TreeNode
                    ourNode.Text = xmlDoc.GetElementsByTagName("Name").Item(0).InnerText
                    ourNode.Nodes.Add("Description: " & xmlDoc.GetElementsByTagName("Description").Item(0).InnerText)
                    ourNode.Nodes.Add("Version: " & xmlDoc.GetElementsByTagName("Version").Item(0).InnerText)
                    ourNode.Nodes.Add("ID: " & xmlDoc.GetElementsByTagName("ID").Item(0).InnerText)
                    tvInstalledThemes.Nodes.Add(ourNode)
                End If
            Next
        End If
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles btnApplyTheme.Click
        Dim ourNode As TreeNode
        If tvInstalledThemes.SelectedNode.Nodes.Count = 0 Then
            ourNode = tvInstalledThemes.SelectedNode.Parent
        Else
            ourNode = tvInstalledThemes.SelectedNode
        End If
        For Each itm In New IO.DirectoryInfo(Application.StartupPath & "\Themes").GetFiles
            If itm.Extension = ".txt" Then
                Dim xmldoc As New XmlDocument()
                xmldoc.Load(itm.FullName)
                If ourNode.Text = xmldoc.GetElementsByTagName("Name").Item(0).InnerText Then
                    Dim themeDLL As String = xmldoc.GetElementsByTagName("ThemeLocation").Item(0).InnerText
                    themeDLL = themeDLL.Substring(themeDLL.LastIndexOf("/")).Replace("/", "")
                    frmMain.SetPluginFile(Application.StartupPath & "\Themes\" & themeDLL)
                End If
            End If
        Next
        BarRestart = False
        nbMain.Shw(True)
        nbMain.Text = "Theme Applied. Some themes may require the application to be restarted before displaying properly."
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim ourNode As TreeNode
        If tvInstalledThemes.SelectedNode.Nodes.Count = 0 Then
            ourNode = tvInstalledThemes.SelectedNode.Parent
        Else
            ourNode = tvInstalledThemes.SelectedNode
        End If
        For Each itm In New IO.DirectoryInfo(Application.StartupPath & "\Themes").GetFiles
            If itm.Extension = ".txt" Then

                Dim xmldoc As New XmlDocument()
                xmldoc.Load(itm.FullName)
                If ourNode.Text = xmldoc.ChildNodes(0).ChildNodes(0).InnerText Then
                    UninstallTheme(xmldoc)
                    For Each ctrl In ThemeContainer.Controls
                        If TypeOf ctrl Is AddonButton Then
                            If CType(ctrl, AddonButton).Title.Text = ourNode.Text Then
                                CType(ctrl, AddonButton).Installed.Text = ""
                            End If
                        End If
                    Next
                End If
            End If
        Next
        tvInstalledThemes.Nodes.Remove(ourNode)
    End Sub
End Class