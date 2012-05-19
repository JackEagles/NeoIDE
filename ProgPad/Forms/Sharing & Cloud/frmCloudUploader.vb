Imports System.IO
Imports System.Collections.Specialized
Imports EnterpriseDT.Net.Ftp
Imports System.ComponentModel

Public Class frmCloudUploader
    Enum Action
        Uploading
        Downloading
    End Enum
    Public CurrentAction As Action
    Public FilesToDownload As New Collection
    Dim FilesToUpload As New Collection
    Dim dlInt As Integer
    Dim ftpLb As New FTPLib.FTP
    Friend WithEvents bwDownload As New BackgroundWorker
    Friend WithEvents bwUpload As New BackgroundWorker
    Public UNRARPASS As String = frmCloudEditor.uPass

    Private Sub frmCloudUploader_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
        'Show the pretty dragover animation.
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub frmCloudUploader_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Icon = New Icon(Application.StartupPath & "\Images\Mainicon.ico")
        ftpLb.Connect("ols18.com", "progpad", ÂÂÁ.ÂÅÂ(ÂÂÁ.鳱儇))
        ftpLb.ChangeDir("/ProgCloud/" & frmCloudEditor.uName & "/")
        If CurrentAction = Action.Uploading Then
            btnBeginCancel.Visible = True
            btnSelectFiles.Visible = True
        ElseIf CurrentAction = Action.Downloading Then
            btnSelectFiles.Visible = False
            btnBeginCancel.Text = "Cancel"
            For Each itm As ListViewItem In FilesToDownload
                Dim lItm = lvwMain.Items.Add(itm.Text & itm.SubItems(1).Text)
                lItm.Tag = itm.Tag
                lItm.SubItems.Add(itm.SubItems(2).Text)
                lItm.SubItems.Add("Waiting...")
            Next
            tmrUpdateProgress.Start()
            bwDownload.RunWorkerAsync()
            lblMain.Text = "Downloading your files..."
        End If
    End Sub


    Private Sub UploadFile(ByVal fileName As String)
        Dim finfo As New IO.FileInfo(fileName)
        If finfo.Length <= 10485670 Then

        Else
            MessageBox.Show("The file is too large. The Maximum size for a file is 10mb")
        End If
    End Sub

    Private Sub btnBeginCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnBeginCancel.Click
        If CurrentAction = Action.Downloading Then
            Me.Dispose()
        ElseIf CurrentAction = Action.Uploading Then
            For Each itm As ListViewItem In lvwMain.Items
                FilesToUpload.Add(itm.Text)
            Next
            tmrUpdateProgress.Start()
            bwUpload.RunWorkerAsync()
        End If
    End Sub

    Dim perc As Integer = 0
    Dim lindex As Integer = -1
    Private Sub bwDownload_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwDownload.DoWork
        For Each itm As ListViewItem In FilesToDownload
            lindex += 1
            ftpLb.OpenDownload(itm.Text.Replace(" ", "**_*") & itm.SubItems(1).Text & ".7z", Application.StartupPath & "\Cloud\Downloads\" & itm.Text & itm.SubItems(1).Text & ".7z")
            While ftpLb.DoDownload() > 0
                perc = CInt((ftpLb.BytesTotal * 100) / ftpLb.FileSize)
            End While
        Next
        lindex = 3000
        Dim dinfo As New IO.DirectoryInfo(Application.StartupPath & "\Cloud\downloads")
        For Each itm In dinfo.GetFiles
            If itm.Extension = ".7z" Then
                Try
                    Dim zip As New SevenZip.SevenZipExtractor(itm.FullName, UNRARPASS)
                    zip.ExtractArchive(Application.StartupPath & "\Cloud\downloads")
                    My.Computer.FileSystem.DeleteFile(itm.FullName)
                Catch ex As Exception
                End Try
            End If
        Next
    End Sub

    Private Sub bwDownload_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwDownload.RunWorkerCompleted
        Process.Start(Application.StartupPath & "\Cloud\Downloads")
        Me.Dispose()
    End Sub


    Private Sub btnSelectFiles_Click(sender As System.Object, e As System.EventArgs) Handles btnSelectFiles.Click
        Dim ofd As New OpenFileDialog
        ofd.Multiselect = True
        If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
            For Each itm In ofd.FileNames
                Dim finfo As New IO.FileInfo(itm)
                Dim litm As ListViewItem = lvwMain.Items.Add(itm)
                Try
                    litm.SubItems.Add((finfo.Length / 1024).ToString.Replace((finfo.Length / 1024).ToString.Substring((finfo.Length / 1024).ToString.LastIndexOf(".")), "") & "kb")
                Catch
                    litm.SubItems.Add((finfo.Length / 1024) & "bytes")
                End Try
                litm.SubItems.Add("Waiting...")
            Next
        End If
    End Sub

    Private Sub lvwMain_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles lvwMain.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim filePaths As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
            For Each fileLoc As String In filePaths
                If File.Exists(fileLoc) Then
                    Dim finfo As New IO.FileInfo(fileLoc)
                    Dim litm As ListViewItem = lvwMain.Items.Add(fileLoc)
                    Try
                        litm.SubItems.Add((finfo.Length / 1024).ToString.Replace((finfo.Length / 1024).ToString.Substring((finfo.Length / 1024).ToString.LastIndexOf(".")), "") & "kb")
                    Catch
                        litm.SubItems.Add((finfo.Length / 1024) & "bytes")
                    End Try
                    litm.SubItems.Add("Waiting...")
                End If
            Next fileLoc
        End If
    End Sub

    Private Sub lvwMain_DragOver(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles lvwMain.DragOver
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub tmrUpdateProgress_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrUpdateProgress.Tick
        On Error Resume Next
        If CurrentAction = Action.Uploading Then
            pbUploadDownload.Maximum = 100
            pbUploadDownload.Value = perc
            lvwMain.Items(lindex).SubItems(2).Text = "Compressing & Uploading"
            lvwMain.Items(lindex - 1).SubItems(2).Text = "Completed"
        ElseIf CurrentAction = Action.Downloading Then
            pbUploadDownload.Maximum = 100
            pbUploadDownload.Value = perc
            If lindex = 3000 Then
                For Each itm As ListViewItem In lvwMain.Items
                    itm.SubItems(2).Text = "Decompressing..."
                Next
                Exit Sub
            End If
            lvwMain.Items(lindex).SubItems(2).Text = "Downloading..."
            lvwMain.Items(lindex - 1).SubItems(2).Text = "Completed"
        End If
    End Sub

    Private Sub bwUpload_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwUpload.DoWork
        lindex = -1
        For Each itm As String In FilesToUpload
            lindex += 1
            Dim zip As New SevenZip.SevenZipCompressor
            zip.ArchiveFormat = SevenZip.OutArchiveFormat.SevenZip
            zip.ZipEncryptionMethod = SevenZip.ZipEncryptionMethod.Aes256
            zip.CompressFilesEncrypted(itm.Substring(itm.LastIndexOf("\")).Replace("\", "") & ".7z", UNRARPASS, itm)
            ftpLb.OpenUpload(Application.StartupPath & "\" & itm.Substring(itm.LastIndexOf("\")).Replace("\", "") & ".7z", itm.Substring(itm.LastIndexOf("\")).Replace("\", "").Replace(" ", "**_*") & ".7z")
            While ftpLb.DoUpload() > 0
                perc = CInt((ftpLb.BytesTotal * 100) / ftpLb.FileSize)
            End While
            Try
                My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\" & itm.Substring(itm.LastIndexOf("\")).Replace("\", "") & ".7z")
            Catch
            End Try
        Next
    End Sub

    Private Sub bwUpload_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwUpload.RunWorkerCompleted
        Me.Close()
        frmCloudEditor.bwGetFiles.RunWorkerAsync()
        MessageBox.Show("Upload Complete!", "Finished", MessageBoxButtons.OK)
    End Sub
End Class