Imports System.Security.Cryptography
Imports System.IO
Imports System.Net
Imports System.Runtime.InteropServices

Public Class frmCloudEditor
    Public uName As String
    Public uPass As String
    Private mIcons As New Hashtable
    Private Structure SHFILEINFO
        Public hIcon As IntPtr
        Public iIcon As Integer
        Public dwAttributes As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)> _
        Public szDisplayName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> _
        Public szTypeName As String
    End Structure

    Private Declare Auto Function SHGetFileInfo Lib "shell32.dll" (ByVal pszPath As String, ByVal dwFileAttributes As Integer, ByRef psfi As SHFILEINFO, ByVal cbFileInfo As Integer, ByVal uFlags As Integer) As IntPtr
    Public Const SHGFI_ICON As Integer = &H100
    Public Const SHGFI_SMALLICON As Integer = &H1
    Public Const SHGFI_LARGEICON As Integer = &H0
    Public Const SHGFI_OPENICON As Integer = &H2
    Public nIndex As Integer = 0
    Function GetShellIconAsImage(ByVal argPath As String) As Image
        Dim mShellFileInfo As New SHFILEINFO
        mShellFileInfo.szDisplayName = New String(Chr(0), 260)
        mShellFileInfo.szTypeName = New String(Chr(0), 80)
        SHGetFileInfo(argPath, 0, mShellFileInfo, System.Runtime.InteropServices.Marshal.SizeOf(mShellFileInfo), SHGFI_ICON Or SHGFI_SMALLICON)
        Dim mIcon As System.Drawing.Icon
        Dim mImage As System.Drawing.Image
        Try
            mIcon = System.Drawing.Icon.FromHandle(mShellFileInfo.hIcon)
            mImage = mIcon.ToBitmap
        Catch ex As Exception
            mImage = New System.Drawing.Bitmap(16, 16)
        End Try
        Return mImage
    End Function

    Public Function CacheShellIcon(ByVal argPath As String) As String
        Dim randomfile As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Temp\tmpfile" & argPath
        IO.File.WriteAllText(randomfile, "test")

        If ilFiles.Images.ContainsKey(argPath) = False Then
            ilFiles.Images.Add(argPath, GetShellIconAsImage(randomfile))
        End If
        IO.File.Delete(randomfile)

        Return argPath
    End Function

    Function GetShellOpenIconAsImage(ByVal argPath As String) As System.Drawing.Image
        Dim mShellFileInfo As New SHFILEINFO
        mShellFileInfo = New SHFILEINFO
        mShellFileInfo.szDisplayName = New String(Chr(0), 260)
        mShellFileInfo.szTypeName = New String(Chr(0), 80)
        SHGetFileInfo(IO.Path.GetTempPath, 0, mShellFileInfo, System.Runtime.InteropServices.Marshal.SizeOf(mShellFileInfo), SHGFI_ICON Or SHGFI_SMALLICON Or SHGFI_OPENICON)
        Dim mIcon As System.Drawing.Icon
        Dim mImage As System.Drawing.Image
        Try
            mIcon = System.Drawing.Icon.FromHandle(mShellFileInfo.hIcon)
            mImage = mIcon.ToBitmap
        Catch ex As Exception
            mImage = New System.Drawing.Bitmap(16, 16)
        End Try
        Return mImage
    End Function


    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub UploadFilesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadFilesToolStripMenuItem.Click
        Dim uFrm As New frmCloudUploader
        uFrm.CurrentAction = frmCloudUploader.Action.Uploading
        uFrm.ShowDialog()
    End Sub
    Dim coll As New Collection

    Private Sub bwGetFiles_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwGetFiles.DoWork
        Try
            FtpClientCtl1.RemoteHost = "ols18.com"
            FtpClientCtl1.ControlPort = 21
            FtpClientCtl1.Connect()
            FtpClientCtl1.Login("progpad", ÂÂÁ.ÂÅÂ(ÂÂÁ.鳱儇))
        Catch
        End Try
        Dim flist = FtpClientCtl1.GetDetails("/ProgCloud/" & uName)

        coll.Clear()
        For Each itm In flist
            Try
                Dim lvwItm As New ListViewItem
                lvwItm.Text = itm.Name.Replace(".7z", "")
                Dim ext As String = lvwItm.Text.Substring(lvwItm.Text.LastIndexOf("."))
                lvwItm.Text = lvwItm.Text.Replace("**_*", " ")
                lvwItm.Text = lvwItm.Text.Replace(ext, "")
                lvwItm.Tag = itm
                lvwItm.SubItems.Add(ext)
                Dim kbs As String = itm.Size / 1000 & "kb"
                Try
                    kbs = kbs.Replace(kbs.Substring(kbs.LastIndexOf(".")), "") & "kb"
                Catch
                End Try
                lvwItm.SubItems.Add(kbs)
                coll.Add(lvwItm)
            Catch
            End Try
        Next



    End Sub

    Private Sub frmCloudEditor_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub frmCloudEditor_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Icon = New Icon(Application.StartupPath & "\Images\Mainicon.ico")
        bwGetFiles.RunWorkerAsync()

    End Sub

    Private Sub bwGetFiles_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwGetFiles.RunWorkerCompleted
        lvwMain.Items.Clear()
        For Each itm As ListViewItem In coll
            lvwMain.Items.Add(itm)
            itm.ImageKey = CacheShellIcon(itm.SubItems(1).Text)

        Next

    End Sub

    Private Sub DownloadToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DownloadToolStripMenuItem.Click
        Dim uFrm As New frmCloudUploader
        uFrm.CurrentAction = frmCloudUploader.Action.Downloading
        For Each itm In lvwMain.SelectedItems
            uFrm.FilesToDownload.Add(itm)
        Next
        uFrm.ShowDialog()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim toRemove As New Collection
        Try
            For Each itm As ListViewItem In lvwMain.SelectedItems
                FtpClientCtl1.Delete("/ProgCloud/" & uName & "/" & itm.Text.Replace(" ", "**_*") & itm.SubItems(1).Text & ".7z")
                toRemove.Add(itm)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        For Each itm In toRemove
            lvwMain.Items.Remove(itm)
        Next
        toRemove.Clear()

    End Sub

    Private Sub RenameToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RenameToolStripMenuItem.Click
        Try
            Dim ib As String = Interaction.InputBox("Please enter a new name for the file (including extension!):", "New Name")
            FtpClientCtl1.Rename("/ProgCloud/" & uName & "/" & lvwMain.SelectedItems(0).Text.Replace(" ", "**_*") & lvwMain.SelectedItems(0).SubItems(1).Text & ".7z", "/ProgCloud/" & uName & "/" & ib & ".7z")
            lvwMain.SelectedItems(0).Text = ib.Replace(ib.Substring(ib.LastIndexOf(".")), "")
            lvwMain.SelectedItems(0).SubItems(1).Text = ib.Substring(ib.LastIndexOf("."))
            lvwMain.SelectedItems(0).ImageKey = CacheShellIcon(ib.Substring(ib.LastIndexOf(".")))
        Catch
        End Try
    End Sub

    Private Sub UploadFilesToolStripMenuItem_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles UploadFilesToolStripMenuItem.DragEnter
  
    End Sub
    
    Private Sub GetPublicLinkToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GetPublicLinkToolStripMenuItem.Click
        Try
            Dim uFrm As New frmCloudUploader
            uFrm.CurrentAction = frmCloudUploader.Action.Downloading
            uFrm.FilesToDownload.Add(lvwMain.SelectedItems(0))
            uFrm.ShowDialog()
            Dim fLocHost As New frmLocalHostrUploader
            fLocHost.fName = Application.StartupPath & "\Cloud\Downloads\" & lvwMain.SelectedItems(0).Text & lvwMain.SelectedItems(0).SubItems(1).Text
            fLocHost.ShowDialog()
        Catch
        End Try
    End Sub

End Class