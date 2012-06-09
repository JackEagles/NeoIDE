Imports System.Runtime.InteropServices
Imports System.Collections.Specialized
Imports System.IO
Imports WeifenLuo.WinFormsUI.Docking

Public Class frmSidebar
    Inherits DockContent

    Enum ProjectCPU
        x86
        x64
        AnyCPU
        Itanium
    End Enum

    Enum ProjectLanguage
        VB
        CS
        VBS
        Batch
        HTML
        Ambiguous
    End Enum

    Public ProjectPath, ProjectBuildPath, ProjectIconPath As String

    Public ProjectCPUType As ProjectCPU
    Public ProjectLang As ProjectLanguage



#Region "Show file properties"
    <DllImport("shell32.dll", EntryPoint:="ShellExecuteEx")> Private Shared Function ShellExecute(ByRef s As SHELLEXECUTEINFO) As Integer
    End Function

    <StructLayout(LayoutKind.Sequential)> Private Structure SHELLEXECUTEINFO
        Public cbSize As Integer
        Public fMask As Integer
        Public hwnd As IntPtr
        Public lpVerb As String
        Public lpFile As String
        Public lpParameters As String
        Public lpDirectory As String
        Public nShow As Integer
        Public hInstApp As IntPtr
        Public lpIDList As IntPtr
        Public lpClass As String
        Public hkeyClass As IntPtr
        Public dwHotKey As Integer
        Public hIcon As IntPtr
        Public hProcess As IntPtr
    End Structure

    Public Shared Sub DisplayFileProperties(ByVal xFileName As String, ByVal hwnd As IntPtr)
        Const SEE_MASK_INVOKEIDLIST As Integer = &HC
        Const SW_SHOW As Integer = 5
        Dim shInfo As New SHELLEXECUTEINFO()
        With shInfo
            .cbSize = Marshal.SizeOf(shInfo)
            .lpFile = xFileName
            .nShow = SW_SHOW
            .fMask = SEE_MASK_INVOKEIDLIST
            .lpVerb = "properties"
            .hwnd = hwnd
        End With
        ShellExecute(shInfo)
    End Sub
#End Region
#Region "Get Icons"
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

    Function CacheShellIcon(ByVal argPath As String) As String

        Dim mKey As String = Nothing
        If IO.Directory.Exists(argPath) = True Then
            mKey = "folder"
        ElseIf IO.File.Exists(argPath) = True Then
            mKey = IO.Path.GetExtension(argPath)
        End If
        If ilMain.Images.ContainsKey(mKey) = False Then
            ilMain.Images.Add(mKey, GetShellIconAsImage(argPath))
            If mKey = "folder" Then ilMain.Images.Add(mKey & "-open", GetShellOpenIconAsImage(argPath))
        End If
        Return mKey
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
#End Region
#Region "Other Delcarations"
    Dim BadFiles As New StringCollection
    Dim AllFiles As New StringCollection
    Dim ProjectSaved As Boolean = True
#End Region

#Region "Tree expand & collapse get files & icons"
    Private Sub treeMain_BeforeExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles treeMain.BeforeExpand
        If e.Node.Tag.ToString <> "ProjectNode" Then
            e.Node.Nodes.Clear()
            Dim mNodeDirectory As IO.DirectoryInfo
            mNodeDirectory = New IO.DirectoryInfo(e.Node.Tag.ToString)
            For Each mDirectory As IO.DirectoryInfo In mNodeDirectory.GetDirectories
                For Each itm In BadFiles
                    If itm = mDirectory.FullName Then
                        GoTo badfolder
                    End If
                Next
                Dim mDirectoryNode As New TreeNode
                mDirectoryNode.Tag = mDirectory.FullName
                mDirectoryNode.Text = mDirectory.Name
                mDirectoryNode.Nodes.Add("*DUMMY*")
                mDirectoryNode.ToolTipText = "Directory"
                mDirectoryNode.ImageKey = CacheShellIcon(mDirectory.FullName)
                mDirectoryNode.SelectedImageKey = mDirectoryNode.ImageKey & "-open"
                e.Node.Nodes.Add(mDirectoryNode)
badfolder:
            Next

            For Each mFile As IO.FileInfo In mNodeDirectory.GetFiles
                For Each itm In BadFiles
                    If itm = mFile.FullName Then
                        GoTo badfile
                    End If
                Next
                Dim mFileNode As New TreeNode
                mFileNode.Tag = mFile.FullName
                mFileNode.Text = mFile.Name
                mFileNode.ToolTipText = "File"
                mFileNode.ImageKey = CacheShellIcon(mFile.FullName)
                mFileNode.SelectedImageKey = mFileNode.ImageKey
                e.Node.Nodes.Add(mFileNode)
badfile:
            Next
        End If
    End Sub

    Private Sub treeMain_BeforeCollapse(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles treeMain.BeforeCollapse
        If e.Node.Tag.ToString <> "ProjectNode" Then
            e.Node.Nodes.Clear()
            e.Node.Nodes.Add("*DUMMY*")
        End If
    End Sub
#End Region
#Region "Tree ContextMenu"
#Region "Add folders/files to tree"
    Private Sub AddFolderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddFolderToolStripMenuItem.Click
        Dim fbd As New FolderBrowserDialog
        If fbd.ShowDialog = DialogResult.OK Then
            Dim mRootNode As New TreeNode
            mRootNode.Text = fbd.SelectedPath.Substring(fbd.SelectedPath.LastIndexOf("\")).Replace("\", "")
            mRootNode.Tag = fbd.SelectedPath
            mRootNode.ImageKey = CacheShellIcon(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles))
            mRootNode.SelectedImageKey = mRootNode.ImageKey & "-open"
            mRootNode.Nodes.Add("*DUMMY*")
            treeMain.Nodes(0).Nodes.Add(mRootNode)
            treeMain.Nodes(0).Expand()
            AllFiles.Add(fbd.SelectedPath)
            mRootNode.Expand()
            ProjectSaved = False
        End If
    End Sub
    Public Sub AddDir(ByVal dir As String)
        Dim mRootNode As New TreeNode
        mRootNode.Text = dir.Substring(dir.LastIndexOf("\")).Replace("\", "")
        mRootNode.Tag = dir
        mRootNode.ImageKey = CacheShellIcon(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles))
        mRootNode.SelectedImageKey = mRootNode.ImageKey & "-open"
        mRootNode.Nodes.Add("*DUMMY*")
        treeMain.Nodes(0).Nodes.Add(mRootNode)
        treeMain.Nodes(0).Expand()
        AllFiles.Add(dir)
        mRootNode.Expand()
        ProjectSaved = False

    End Sub

    Private Sub AddFilesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddFilesToolStripMenuItem.Click
        Dim ofd As New OpenFileDialog
        ofd.Filter = "All Files (*.*)|*.*"
        ofd.Multiselect = True
        ofd.Title = "Select files to add..."
        If ofd.ShowDialog = DialogResult.OK Then
            For Each itm In ofd.FileNames
                Dim mFileNode As New TreeNode
                mFileNode.Tag = itm
                mFileNode.Text = itm.Substring(itm.LastIndexOf("\")).Replace("\", "")
                mFileNode.ToolTipText = "File"
                mFileNode.ImageKey = CacheShellIcon(itm)
                mFileNode.SelectedImageKey = mFileNode.ImageKey
                treeMain.Nodes(0).Nodes.Add(mFileNode)
                AllFiles.Add(itm)
                ProjectSaved = False
            Next
        End If
    End Sub
#End Region
#Region "File/Folder manipulation"
    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        Dim tcDocked As Boolean = False

        If Me.DockState = WeifenLuo.WinFormsUI.Docking.DockState.DockRightAutoHide Then
            Me.DockState = WeifenLuo.WinFormsUI.Docking.DockState.DockRight
            tcDocked = True
        End If
        Dim tbNo As Integer = -1

        For Each tb In frmMain.tcMain.Controls(2).Controls
            If TypeOf tb.Controls.Item(0) Is ScintillaEx Then
                If CType(tb.Controls.Item(0), ScintillaEx).SavePath = treeMain.SelectedNode.Tag.ToString Then
                    If tb.Tag = tb.Controls.Item(0).SavePath Then
                        frmMain.tcMain.TabPages(tb).Select()
                        Exit Sub
                    End If
                End If
            End If
        Next
        frmMain.CreateNewDoc(treeMain.SelectedNode.Tag.ToString)
        If tcDocked = True Then
            Me.DockState = WeifenLuo.WinFormsUI.Docking.DockState.DockRightAutoHide
        End If

    End Sub

    Private Sub ShowInExplorerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowInExplorerToolStripMenuItem.Click
        If treeMain.SelectedNode.ToolTipText = "File" Then
            Process.Start("explorer.exe", treeMain.SelectedNode.Tag.ToString.Replace(treeMain.SelectedNode.Tag.ToString.Substring(treeMain.SelectedNode.Tag.ToString.LastIndexOf("\")).Replace("\", ""), ""))
        ElseIf treeMain.SelectedNode.ToolTipText = "Folder" Then
            Process.Start("explorer.exe", treeMain.SelectedNode.Tag.ToString)
        End If
    End Sub


    Private Sub PropertiesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropertiesToolStripMenuItem.Click
        DisplayFileProperties(treeMain.SelectedNode.Tag.ToString, Me.Handle)
    End Sub

    Private Sub RenameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RenameToolStripMenuItem.Click
        Dim ib As String = Interaction.InputBox("Please enter the new name (with extension):", "New name", treeMain.SelectedNode.Text)
        Try
            If treeMain.SelectedNode.ToolTipText.ToString = "File" Then
                My.Computer.FileSystem.RenameFile(treeMain.SelectedNode.Tag.ToString, ib)
            ElseIf treeMain.SelectedNode.ToolTipText.ToString = "Folder" Then
                My.Computer.FileSystem.RenameDirectory(treeMain.SelectedNode.Tag.ToString, ib)
            End If
            treeMain.SelectedNode.Text = ib
            treeMain.SelectedNode.Tag = treeMain.SelectedNode.Tag.ToString.Substring(0, treeMain.SelectedNode.Tag.ToString.LastIndexOf("\"))
            treeMain.SelectedNode.Tag &= "\" & ib
        Catch ex As Exception
            MessageBox.Show("Error renaming file: " & ex.Message, "Error!")
        End Try
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim res As DialogResult = MessageBox.Show("Do you really want to delete: " & treeMain.SelectedNode.Text & " from the folder: " & treeMain.SelectedNode.Parent.Text & " to the Recycle Bin?", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If res = Windows.Forms.DialogResult.Yes Then
            Try
                If treeMain.SelectedNode.ToolTipText.ToString = "File" Then
                    My.Computer.FileSystem.DeleteFile(treeMain.SelectedNode.Tag.ToString, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)
                ElseIf treeMain.SelectedNode.ToolTipText.ToString = "Folder" Then
                    My.Computer.FileSystem.DeleteDirectory(treeMain.SelectedNode.Tag.ToString, FileIO.DeleteDirectoryOption.DeleteAllContents, FileIO.RecycleOption.SendToRecycleBin)
                End If
                BadFiles.Add(treeMain.SelectedNode.ToolTipText.ToString)
                treeMain.Nodes.Remove(treeMain.SelectedNode)
                ProjectSaved = False
            Catch ex As Exception
                MessageBox.Show("Error deleting file: " & ex.Message, "Error!")
            End Try
        End If
    End Sub
#End Region
#Region "Showing items on ContextMenu Open"
    Private Sub HideFileRelevant()
        OpenToolStripMenuItem.Visible = False
        ShowInExplorerToolStripMenuItem.Visible = False
        RenameToolStripMenuItem.Visible = False
        DeleteToolStripMenuItem.Visible = False
        PropertiesToolStripMenuItem.Visible = False
        RemoveFromProjectToolStripMenuItem.Visible = False
        ToolStripSeparator1.Visible = False
        ToolStripSeparator2.Visible = False
        ToolStripSeparator3.Visible = False
        CreateFileToolStripMenuItem.Visible = False
        ToolStripSeparator4.Visible = False
        CreateFolderToolStripMenuItem.Visible = False
        OpenInToolStripMenuItem.Visible = False
    End Sub
    Private Sub ShowFileRelevant()
        OpenToolStripMenuItem.Visible = True
        ShowInExplorerToolStripMenuItem.Visible = True
        RenameToolStripMenuItem.Visible = True
        DeleteToolStripMenuItem.Visible = True
        PropertiesToolStripMenuItem.Visible = True
        RemoveFromProjectToolStripMenuItem.Visible = True
        ToolStripSeparator1.Visible = True
        ToolStripSeparator2.Visible = True
        ToolStripSeparator3.Visible = True
        CreateFileToolStripMenuItem.Visible = True
        CreateFolderToolStripMenuItem.Visible = True
        ToolStripSeparator4.Visible = True
        OpenInToolStripMenuItem.Visible = True
    End Sub

    Private Sub cmuMain_Opened(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmuMain.Opened

    End Sub
    Private Sub cmuMain_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmuMain.Opening
        If IsNothing(treeMain.SelectedNode) Then
            HideFileRelevant()
        Else
            If treeMain.SelectedNode.Tag.ToString = "ProjectNode" Then
                HideFileRelevant()
            Else
                ShowFileRelevant()
            End If
        End If
        If treeMain.Nodes.Count = 0 Then
            AddFilesToolStripMenuItem.Visible = False
            AddFolderToolStripMenuItem.Visible = False
            SaveProjectToolStripMenuItem.Visible = False
        Else
            AddFilesToolStripMenuItem.Visible = True
            AddFolderToolStripMenuItem.Visible = True
            SaveProjectToolStripMenuItem.Visible = True
        End If
    End Sub
#End Region
#Region "Project manipulation"
    Private Sub NewProjectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewProjectToolStripMenuItem.Click
        If ProjectSaved = False Then
            Dim mbox = MessageBox.Show("Do you want to save the current project?", "Save Project", MessageBoxButtons.YesNoCancel)
            If mbox = Windows.Forms.DialogResult.Yes Then
                If SaveProject() = False Then
                    Exit Sub
                End If
            ElseIf mbox <> Windows.Forms.DialogResult.No Then
                Exit Sub
            End If

        End If

        treeMain.Nodes.Clear()
        Dim nd As New TreeNode
        nd.Text = InputBox("Please enter the project name...", "Project Name", "Name...")
        nd.Tag = "ProjectNode"
        nd.ImageKey = "fldr"
        ProjectSaved = False
        treeMain.Nodes.Add(nd)
    End Sub
    Private Sub RemoveFromProjectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveFromProjectToolStripMenuItem.Click
        If treeMain.SelectedNode.Tag.ToString <> "ProjectNode" Then
            ProjectSaved = False
            BadFiles.Add(treeMain.SelectedNode.Tag.ToString)
            treeMain.Nodes.Remove(treeMain.SelectedNode)
        End If
    End Sub

    Private Sub SaveProjectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveProjectToolStripMenuItem.Click
        SaveProject()
    End Sub
#End Region
    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub
#End Region

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If treeMain.Nodes.Count <> 0 Then
            If ProjectSaved = False Then
                Dim res As DialogResult = MessageBox.Show("This Project has not been saved. Save now?", "Save?", MessageBoxButtons.YesNoCancel)
                If res = DialogResult.Yes Then
                    If SaveProject() <> True Then
                        e.Cancel = True
                    End If
                ElseIf res = DialogResult.Cancel Then
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Function SaveProject() As Boolean
        Dim toSave As String = ""
        toSave &= treeMain.Nodes(0).Text & Environment.NewLine
        For Each itm In AllFiles
            toSave &= itm & Environment.NewLine
        Next
        If IsNothing(BadFiles) = False Then
            If BadFiles.Count <> 0 Then
                toSave &= "BADFILES" & Environment.NewLine
                For Each itm In BadFiles
                    toSave &= itm & Environment.NewLine
                Next
            End If
        End If

        Dim sfd As New SaveFileDialog
        sfd.Filter = "NeoIDE Project Files (*.ppproj)|*.ppproj"
        sfd.Title = "Save Project"
        sfd.InitialDirectory = Application.StartupPath & "\Projects"
        If sfd.ShowDialog = DialogResult.OK Then
            Dim savef As New IO.StreamWriter(sfd.FileName)
            savef.Write(toSave)
            savef.Close()
            savef.Dispose()
            Return True
            ProjectSaved = True
        Else
            Return False
        End If
    End Function

    Private Sub OpenProjectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenProjectToolStripMenuItem.Click
        If ProjectSaved = False Then
            Dim mbox = MessageBox.Show("Do you want to save the current project?", "Save Project", MessageBoxButtons.YesNoCancel)
            If mbox = Windows.Forms.DialogResult.Yes Then
                If SaveProject() = False Then
                    Exit Sub
                End If
            ElseIf mbox <> Windows.Forms.DialogResult.No Then
                Exit Sub
            End If

        End If
        treeMain.Nodes.Clear()
        Dim ofd As New OpenFileDialog
        ofd.Title = "Open Project"
        ofd.InitialDirectory = Application.StartupPath & "\Projects"
        ofd.Filter = "NeoIDE Project Files (*.ppproj)|*.ppproj"

        If ofd.ShowDialog = DialogResult.OK Then
            Dim loadf As New IO.StreamReader(ofd.FileName)
            Dim lr2e As String = loadf.ReadToEnd
            loadf.Close()
            loadf.Dispose()
            Dim nd As New TreeNode
            nd.Text = lr2e.Split(Environment.NewLine)(0)
            nd.Tag = "ProjectNode"
            nd.ImageKey = "fldr"
            treeMain.Nodes.Add(nd)
            Dim bfiles As Boolean = False
            Dim iiS As Integer = 0
            For Each itm As String In lr2e.Split(Environment.NewLine)
                iiS += 1
                If iiS <> 1 Then
                    itm = itm.Substring(1, itm.Length - 1)
                End If
                If itm = "BADFILES" Then
                    bfiles = True
                End If
                If bfiles = True Then
                    BadFiles.Add(itm)
                Else
                    AllFiles.Add(itm)

                End If
            Next
            For Each itm In AllFiles
                itm = itm.Replace(ChrW(13), "")
                If IsBad(itm) = False Then
                    If My.Computer.FileSystem.FileExists(itm) Then
                        Dim mFileNode As New TreeNode
                        mFileNode.Tag = itm
                        mFileNode.Text = itm.Substring(itm.LastIndexOf("\")).Replace("\", "")
                        mFileNode.ToolTipText = "File"
                        mFileNode.ImageKey = CacheShellIcon(itm)
                        mFileNode.SelectedImageKey = mFileNode.ImageKey
                        treeMain.Nodes(0).Nodes.Add(mFileNode)
                    ElseIf My.Computer.FileSystem.DirectoryExists(itm) Then
                        Dim mRootNode As New TreeNode
                        mRootNode.Text = itm.Substring(itm.LastIndexOf("\")).Replace("\", "")
                        mRootNode.Tag = itm
                        mRootNode.ImageKey = CacheShellIcon(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles))
                        mRootNode.SelectedImageKey = mRootNode.ImageKey & "-open"
                        mRootNode.Nodes.Add("*DUMMY*")
                        treeMain.Nodes(0).Nodes.Add(mRootNode)
                        treeMain.Nodes(0).Expand()
                        mRootNode.Expand()
                    End If
                End If
            Next
            ProjectSaved = True
        End If
    End Sub

    Private Function IsBad(ByVal str As String) As Boolean
        For Each itm In BadFiles
            If str = itm Then
                Return True
                Exit Function
            End If
        Next
        Return False
    End Function

    Private Sub frmSidebar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = New Icon(Application.StartupPath & "\Images\Mainicon.ico")
        ilMain.Images.Add("fldr", Image.FromFile(Application.StartupPath & "\Images\folder.png"))
    End Sub



    Private Sub treeMain_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles treeMain.DragDrop
        If treeMain.Nodes.Count = 0 Then
            MessageBox.Show("Please create a new project first!", "Error", MessageBoxButtons.OK)
            Exit Sub
        End If
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim filePaths As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
            For Each itm As String In filePaths
                itm = itm.Replace(ChrW(13), "")
                If IsBad(itm) = False Then
                    If My.Computer.FileSystem.FileExists(itm) Then
                        Dim mFileNode As New TreeNode
                        mFileNode.Tag = itm
                        mFileNode.Text = itm.Substring(itm.LastIndexOf("\")).Replace("\", "")
                        mFileNode.ToolTipText = "File"
                        mFileNode.ImageKey = CacheShellIcon(itm)
                        mFileNode.SelectedImageKey = mFileNode.ImageKey
                        treeMain.Nodes(0).Nodes.Add(mFileNode)
                        AllFiles.Add(itm)
                    ElseIf My.Computer.FileSystem.DirectoryExists(itm) Then
                        Dim mRootNode As New TreeNode
                        mRootNode.Text = itm.Substring(itm.LastIndexOf("\")).Replace("\", "")
                        mRootNode.Tag = itm
                        mRootNode.ImageKey = CacheShellIcon(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles))
                        mRootNode.SelectedImageKey = mRootNode.ImageKey & "-open"
                        mRootNode.Nodes.Add("*DUMMY*")
                        treeMain.Nodes(0).Nodes.Add(mRootNode)
                        treeMain.Nodes(0).Expand()
                        mRootNode.Expand()
                        AllFiles.Add(itm)
                    End If
                End If
            Next itm
        End If
    End Sub

    Private Sub treeMain_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles treeMain.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub treeMain_NodeMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles treeMain.NodeMouseDoubleClick
        If OpenToolStripMenuItem.Visible = True Then
            OpenToolStripMenuItem.PerformClick()
        End If
    End Sub

    Private Sub treeMain_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles treeMain.MouseDown
        If e.Button = MouseButtons.Right Then
            treeMain.SelectedNode = treeMain.GetNodeAt(e.Location)
        End If
    End Sub
End Class
