#Region "Imports"
Imports System.Runtime.InteropServices
Imports System.Drawing
Imports ScintillaNET
Imports System.IO
Imports System.Collections.Specialized
Imports System.Xml
Imports System.ComponentModel
Imports System.Reflection
Imports WeifenLuo.WinFormsUI.Docking
Imports Microsoft.Win32
Imports System.Net
Imports CustomTabControl
Imports vtExtender.vtExtender
Imports System.Text.RegularExpressions

#End Region

Public Class frmMain
#Region "Executable Icon extraction"
    'Declarations & functions used in order to extract icons from executable files in order to show them in the "Run In..." menu.
    'This may be extended in future to show file type icons in the tabcontrol, when it has icon support.
    <DllImport("shell32.dll", CharSet:=CharSet.Auto)> _
    Public Shared Function ExtractIconEx(ByVal szFileName As String, ByVal nIconIndex As Integer, ByVal phiconLarge() As IntPtr, ByVal phiconSmall() As IntPtr, ByVal nIcons As Integer) As Integer
    End Function
    <DllImport("user32.dll", EntryPoint:="DestroyIcon", SetLastError:=True)> Public Shared Function DestroyIcon(ByVal hIcon As IntPtr) As Integer
    End Function

    Public Sub WriteIconOut(ByVal iconsrcpath As String, ByVal icondestpath As String)
        Dim iconsrc As Icon = ExtractIconFromExe(iconsrcpath, True)
        iconsrc.Save(System.IO.File.OpenWrite(icondestpath))
    End Sub

    Public Function ExtractIconFromExe(ByVal f As String, ByVal large As Boolean) As Icon
        Dim readIconCount As Integer = 0
        Dim hDummy As IntPtr() = New IntPtr(0) {IntPtr.Zero}
        Dim hIconEx As IntPtr() = New IntPtr(0) {IntPtr.Zero}

        Try
            If (large) Then
                readIconCount = ExtractIconEx(f, 0, hIconEx, hDummy, 1)
            Else
                readIconCount = ExtractIconEx(f, 0, hDummy, hIconEx, 1)
            End If

            If (readIconCount > 0 AndAlso Not hIconEx(0).Equals(IntPtr.Zero)) Then
                Dim extractedIcon As Icon = Icon.FromHandle(hIconEx(0)).Clone()
                Return extractedIcon
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw New ApplicationException("Could not extract icon", ex)
        Finally
            For Each ptr As IntPtr In hIconEx
                If (Not ptr.Equals(IntPtr.Zero)) Then
                    DestroyIcon(ptr)
                End If
            Next ptr

            For Each ptr As IntPtr In hDummy
                If Not (ptr.Equals(IntPtr.Zero)) Then
                    DestroyIcon(ptr)
                End If
            Next ptr
        End Try
    End Function
#End Region
#Region "File Icon extraction"
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
        Dim mKey As String = Nothing
        If IO.File.Exists(argPath) = True Then
            mKey = IO.Path.GetExtension(argPath)
        Else
            mKey = argPath.Replace(".", "")
        End If
        If ilTabControlImages.Images.ContainsKey(mKey) = False Then
            ilTabControlImages.Images.Add(mKey, GetShellIconAsImage(argPath))
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
#Region "Declarations"

    'Variable for whether we are loading a document from the auto backup. Shows the Scintilla whether to register as 
    'text changed when the text of the textbox is changed
    Public CreatingDocumentBackup As Boolean = False

    'Declaration for the line count
    Dim mHwnd As IntPtr
    'So we can pass commands to the selected scintilla without using CType every time
    Public SelScintilla As ScintillaEx
    Friend WithEvents bwLoader As New BackgroundWorker



    'On form closing, we pass all the documents which need to be saved to the save form.
    Public DocsToSave As New Collection

    Public tcFrm As New frmTabControl
    Friend WithEvents dPanel As New DockPanel


    'vtExtender is used for styling.
    Public _vtExtender As vtExtender.vtExtender.vtExtender

    Public Macro As String
    Public MacroRecording As Boolean

    Public AutoCodeDetection As Boolean = True
    Public CodeDetectionRules As New StringCollection

    Public compiler As New Compiler

    Dim StartPage As New frmStartPage

#Region "Settings Variables"
    'Variables for settings (not all settings need variables in the program as they are loaded and saved at runtime depending on whether other variables
    'are true or false (i.e visibility of a control, etc)).
    Public DocumentSwitcher As Boolean

    Public AutoHighlighting As Boolean
    Public AutoHighligtingRules As New StringCollection

    Public ExplorerIntegration As Boolean
    Public CustomExplorerIntegration As String

    Public DocumentTitleBar As Boolean

    Public ShowEOL As Boolean
    Public ShowWhiteSpace As Boolean

    Public LineHighlightColor As Color = Color.LightBlue
    Public ShowLineHighlight As Boolean

    Public ScinColor As Color = Nothing
    Public ScinWordWrap As Boolean
    Public ScinFont As Font = Nothing
    Public FontName As String
    Public FontSize As Integer

    Public ThemeInfoBar As Boolean
    Public ThemeFile As String


    Public RememberSession As Boolean

    Public TabShowClose As Boolean
#End Region
#Region "Linecount Variables"
    'Variable to pass the text of the current scintilla to an alternate thread so that word count can function in a multi-threaded manner.
    Dim docText As String 'Variables for the selected line, the line count, the selected column, the total column, the document length
    'the indent to show line numbers in the margin, and the number of documents open
    Public selLine, lineCount, selCol, totalColls, docLength, indent, notes As Integer
    <DllImport("USER32.dll")> _
    Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, ByVal lParam As IntPtr) As Int32
    End Function
    Const EM_GETLINECOUNT = &HBA
    Public Const EM_LINEFROMCHAR = &HC9
#End Region
#Region "Memory Reducer"
    Friend WithEvents MemReducer As New Timer
    <DllImport("kernel32", EntryPoint:="SetProcessWorkingSetSize")> _
    Private Shared Function ReduceProc(ByVal process As IntPtr, ByVal minimumWorkingSetSize As Integer, ByVal maximumWorkingSetSize As Integer) As Integer
    End Function
    Private Sub MemReducer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MemReducer.Tick
        Using process As Process = process.GetCurrentProcess
            ReduceProc(process.Handle, -1, -1)
        End Using
    End Sub
#End Region
#End Region
#Region "Plugin Declarations"
    Function Plugin(ByVal ByteOfPlugin As Byte(), ByVal ClassName As String) As Object
        Dim J As Reflection.Assembly = Reflection.Assembly.Load(ByteOfPlugin)
        Return J.CreateInstance(Split(J.FullName, ",")(0) & "." & ClassName)
    End Function
    Public PLG As Object
#End Region
#Region "Drag & Drop functionality for the form BUT NOT THE SCINTILLA TEXTBOX"
    Private Sub frmMain_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
        'If it's files...
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            'Get the file paths
            Dim filePaths As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
            'for each filepath..
            For Each fileLoc As String In filePaths
                If File.Exists(fileLoc) Then
                    'check the file exists, and if so, open it.
                    CreateNewDoc(fileLoc)
                End If
            Next fileLoc
        End If
    End Sub

    Private Sub frmMain_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
        'Show the pretty dragover animation.
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
#End Region
#Region "Hotkeys"
    Private Sub frmMain_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'Checks for the tab key
        If e.KeyCode = 9 Then
            'If shift is down too
            If My.Computer.Keyboard.ShiftKeyDown = True Then
                'If the document switcher is enabled in settings
                If DocumentSwitcher = True Then
                    'Center it to the form
                    Dim hi As Integer = 0
                    For Each tb In tcMain.TabPages
                        frmTab.lstMain.Items.Add(tb.Form.Text)
                        hi += 13
                    Next
                    frmTab.lstMain.SelectedIndex = tcMain.TabPages.SelectedIndex
                    If hi >= Screen.PrimaryScreen.Bounds.Height / 1.5 Then
                        hi = Math.Round((Screen.PrimaryScreen.Bounds.Height / 1.5), 13)
                    End If
                    'and show it...
                    frmTab.Show()
                    frmTab.Size = New Size(frmTab.Width, frmTab.Height + hi)
                    frmTab.Location = New Point(Me.Location.X + (Me.Width / 2) - (frmTab.Width / 2), Me.Location.Y + (Me.Height / 2) - (frmTab.Height / 2))
                End If
            End If
        End If
        'If the control keys down
        If My.Computer.Keyboard.CtrlKeyDown Then
            Try
                'These are basically all the hotkeys to select tabs 1 to the the last tab
                If e.KeyCode = Keys.D1 Then
                    tcMain.TabPages(0).Select()
                ElseIf e.KeyCode = Keys.D2 Then
                    tcMain.TabPages(1).Select()
                ElseIf e.KeyCode = Keys.D3 Then
                    tcMain.TabPages(2).Select()
                ElseIf e.KeyCode = Keys.D4 Then
                    tcMain.TabPages(3).Select()
                ElseIf e.KeyCode = Keys.D5 Then
                    tcMain.TabPages(4).Select()
                ElseIf e.KeyCode = Keys.D6 Then
                    tcMain.TabPages(5).Select()
                ElseIf e.KeyCode = Keys.D7 Then
                    tcMain.TabPages(6).Select()
                ElseIf e.KeyCode = Keys.D8 Then
                    tcMain.TabPages(7).Select()
                ElseIf e.KeyCode = Keys.D9 Then
                    tcMain.TabPages(tcMain.TabPages.Count - 1).Select()
                    'CTRL + PageDown to select next/previous tab
                ElseIf e.KeyCode = Keys.PageDown Then
                    tcMain.TabPages(tcMain.TabPages.SelectedIndex() - 1).Select()
                ElseIf e.KeyCode = Keys.PageUp Then
                    tcMain.TabPages(tcMain.TabPages.SelectedIndex() + 1).Select()
                End If
            Catch
            End Try

        End If
    End Sub

#End Region

#Region "Startup & Closing Code"
    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        StartPage.Dispose()

        '   Dim eTxt As String
        '   For i As Integer = 0 To CodeDetectionRules.Count - 1
        ' With CType(CodeDetectionRules(i), CodeDetectionRulesString)
        ' Dim isGot(.RuleStrings.Count) As Boolean
        ' For j As Integer = 0 To .RuleStrings.Count - 1
        ' If eTxt.Contains(.RuleStrings(j)) Then
        ' isGot(i) = True
        ' End If
        ' Next
        ' Dim match As Boolean = True
        ' For Each itm In isGot
        ' If itm = False Then
        ' match = False
        ' End If
        ' Next
        ' If match = True Then
        '
        '        End If
        '        End With
        '        Next



        Try
            'If the sidebar is visible, close it.
            If frmSidebar.Visible = True Then
                frmSidebar.Close()
            End If
            DocsToSave.Clear()
            'For each open document...
            For Each tb In tcMain.Controls(2).Controls
                'See if it has been modified
                If CType(tb.Controls(0), ScintillaEx).WasTextChanged = True Then
                    DocsToSave.Add(tb.Controls(0))
                End If

            Next
            If DocsToSave.Count <> 0 Then
                Dim x = frmSave.ShowDialog
                If x = Windows.Forms.DialogResult.Cancel Then
                    e.Cancel = True
                End If
            End If
            If e.Cancel = False Then
                'If the user has decided to close, then we want to delete all the backup documents that we've created.
                If My.Computer.FileSystem.DirectoryExists(Application.StartupPath & "\Backup") Then
                    My.Computer.FileSystem.DeleteDirectory(Application.StartupPath & "\Backup", FileIO.DeleteDirectoryOption.DeleteAllContents)
                End If
            End If

            'Save all the items on the toolbar to toolbar.nps
            Dim toolBarButtons As String = ""
            For Each itm In msToolbar.Items
                If itm.ToolTipText <> "" Then
                    toolBarButtons &= itm.ToolTipText & "$SPLIT$"
                End If
            Next
            Dim savef As New IO.StreamWriter(Application.StartupPath & "\Settings\Toolbar.nps")
            savef.Write(toolBarButtons)
            savef.Flush()
            savef.Close()
            savef.Dispose()

            'We want to save all the other settings.
            saveSettings()
            SaveRecentItems()
            SaveAutoCodeHiglightingPaste()

            If RememberSession = True Then
                Dim toSave As String = ""
                For Each tb In tcMain.Controls(2).Controls
                    If My.Computer.FileSystem.FileExists(CType(tb.Controls(0), ScintillaEx).SavePath) Then
                        toSave &= CType(tb.Controls(0), ScintillaEx).SavePath & "/split/"
                    End If
                Next
                Dim save2 As New IO.StreamWriter(Application.StartupPath & "\Settings\Session.nps")
                save2.Write(toSave)
                save2.Flush()
                save2.Close()
                save2.Dispose()
            End If

            If AutoHighlighting = True Then
                Dim xmlWr As New XmlTextWriter(Application.StartupPath & "\Settings\Autohighlighting.xml", System.Text.Encoding.Default)
                xmlWr.Formatting = Formatting.Indented
                xmlWr.Indentation = 3
                xmlWr.WriteStartElement("Autos")
                For Each itm In AutoHighligtingRules
                    If itm <> "" Then
                        xmlWr.WriteElementString("Auto", itm)
                    End If
                Next
                xmlWr.WriteEndElement()
                xmlWr.Flush()
                xmlWr.Close()
            End If
        Catch ex As Exception
            'This happens when the user closes so fast that the program has not finished loading (approx 3s)
            MessageBox.Show("Closing failed. Reverting to force close. Error: " & ex.Message, "Error")
            End
        End Try

    End Sub

    Private Sub saveSettings()
        Dim XMLDoc As New XmlTextWriter(Application.StartupPath & "\Settings\Settings.xml", Nothing)
        XMLDoc.Formatting = Formatting.Indented
        XMLDoc.Indentation = 4
        XMLDoc.WriteStartElement("Settings")
        XMLDoc.WriteElementString("ShowToolbar", msToolbar.Visible.ToString)
        XMLDoc.WriteElementString("ShowStatusbar", msInfo.Visible.ToString)
        XMLDoc.WriteElementString("DocumentSwitcher", DocumentSwitcher)
        XMLDoc.WriteElementString("AutoHighlighting", AutoHighlighting)
        XMLDoc.WriteElementString("ExplorerIntegration", ExplorerIntegration)
        XMLDoc.WriteElementString("CustomExplorerIntegration", CustomExplorerIntegration)
        XMLDoc.WriteElementString("RememberSession", RememberSession)
        XMLDoc.WriteElementString("DocumentTitleBar", DocumentTitleBar)
        XMLDoc.WriteElementString("ShowEOL", ShowEOL)
        XMLDoc.WriteElementString("ShowWhiteSpace", ShowWhiteSpace)
        XMLDoc.WriteElementString("LineHighlighting", ShowLineHighlight)
        XMLDoc.WriteElementString("LineHighlightingColor", LineHighlightColor.ToArgb)
        XMLDoc.WriteElementString("WordWrap", ScinWordWrap)
        XMLDoc.WriteElementString("FontName", FontName)
        XMLDoc.WriteElementString("FontSize", FontSize.ToString)
        XMLDoc.WriteElementString("ThemeInfoBar", ThemeInfoBar)
        XMLDoc.WriteElementString("ThemeFile", ThemeFile)

        XMLDoc.WriteEndElement()
        XMLDoc.Flush()
        XMLDoc.Close()
    End Sub

    Private Sub SaveAutoCodeHiglightingPaste()
        Dim xmlDoc As New XmlTextWriter(Application.StartupPath & "\Settings\AutoHiglightingPaste.xml", System.Text.Encoding.ASCII)
        xmlDoc.Formatting = Formatting.Indented
        xmlDoc.Indentation = 2
        xmlDoc.WriteStartElement("AutoCodeHiglightingPaste")
        xmlDoc.WriteElementString("Enabled", AutoCodeDetection)
        For Each itm In CodeDetectionRules
            xmlDoc.WriteElementString("CodeHighlightingPaste", itm)
        Next
        xmlDoc.WriteEndElement()
        xmlDoc.Close()
    End Sub

    Private Sub LoadAutoCodeHighlightingPaste()
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(Application.StartupPath & "\Settings\AutoHiglightingPaste.xml")
        AutoCodeDetection = xmlDoc.GetElementsByTagName("Enabled").Item(0).InnerText
        For Each itm As XmlNode In xmlDoc.GetElementsByTagName("CodeHighlightingPaste")
            CodeDetectionRules.Add(itm.InnerText)
        Next
        If CodeDetectionRules.Count = 0 Then AutoCodeDetection = False
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
     If Application.StartupPath.ToLower = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData).ToLower & "\temp\progpadupdate" Then
            Try
                My.Computer.FileSystem.CopyDirectory(Application.StartupPath, Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) & "\NeoIDE", True)
            Catch
            End Try

            Try
                My.Computer.FileSystem.DeleteDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData).ToLower & "\temp\progpadupdate", FileIO.DeleteDirectoryOption.DeleteAllContents)
            Catch ex As Exception
            End Try
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) & "\NeoIDE\neoide.exe")
            End
        End If
        'First of all, before anything else, load settings.
        loadSettings()
        'If the backup directory is still present, it implies that the program has been terminated prematurely...
        If Process.GetProcessesByName("neoide".ToLower).Count = 1 Or Process.GetCurrentProcess.ProcessName.ToLower = "neoide.vshost" Then
            If My.Computer.FileSystem.DirectoryExists(Application.StartupPath & "\Backup") Then
                frmBackup.ShowHint = DockState.DockLeft
                frmBackup.Show(dPanel)
            End If
        End If

        Dim commandline As Boolean = False
        For Each itm In Environment.GetCommandLineArgs
            Try
                If itm = "/uninstall" Then
                    Dim mbRes As DialogResult = MessageBox.Show("Do you really want to uninstall NeoIDE? Note that you will lose all projects and snippets that you have saved in the \Projects and \Runtime\Codeblocks directories!", "Uninstall?", MessageBoxButtons.YesNo)
                    If mbRes = Windows.Forms.DialogResult.Yes Then
                        Registry.LocalMachine.DeleteSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\NeoIDE")
                        If My.Computer.FileSystem.FileExists(Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) & "\NeoID.lnk") Then
                            My.Computer.FileSystem.DeleteFile(Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) & "\NeoIDE.lnk")
                        End If
                        If My.Computer.FileSystem.FileExists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\NeoIDE.lnk") Then
                            My.Computer.FileSystem.DeleteFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\NeoIDE.lnk")
                        End If
                        If My.Computer.FileSystem.FileExists(Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) & "\Uninstall NeoIDE.lnk") Then
                            My.Computer.FileSystem.DeleteFile(Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) & "\Uninstall NeoIDE.lnk")
                        End If
                        Dim Info As ProcessStartInfo = New ProcessStartInfo()
                        Info.Arguments = "/C ping 1.1.1.1 -n 1 -w 3000 > Nul & rd /s /q """ & Application.StartupPath & """"
                        Info.FileName = "cmd.exe"
                        Process.Start(Info)
                        End
                    End If
                End If
            Catch
            End Try
            Dim cmndLines As Integer = Environment.GetCommandLineArgs.ToArray.Count
            If cmndLines <> 0 Then
                If itm.ToLower.EndsWith("neoide.vshost.exe") = False AndAlso itm.ToLower.ToLower.EndsWith("neoide.exe") = False Then
                    If My.Computer.FileSystem.FileExists(itm) Then
                        commandline = True
                        CreateNewDoc(itm)
                    End If
                End If
            End If
        Next
        If RememberSession = True Then
            Dim loadf As New IO.StreamReader(Application.StartupPath & "\Settings\Session.nps")
            For Each itm In loadf.ReadToEnd.Split("/split/")
                If My.Computer.FileSystem.FileExists(itm.Replace("/split/", "")) = True Then
                    CreateNewDoc(itm.Replace("/split/", ""))
                End If
            Next
            loadf.Close()
            loadf.Dispose()
        End If
        Try
            If AutoHighlighting = True Then
                Dim xmlDoc As New XmlDocument
                xmlDoc.Load(Application.StartupPath & "\Settings\Autohighlighting.xml")
                For Each itm As XmlNode In xmlDoc.GetElementsByTagName("Auto")
                    AutoHighligtingRules.Add(itm.InnerXml)
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        tsFind.Visible = False
        'Allow drag & drop
        Me.AllowDrop = True
        'Use backgroundworker to load additional settings
        bwLoader.RunWorkerAsync()
        'Create a new document
        If commandline = False Then
            tcMain.TabPages.Add(StartPage)
        End If
        
        'Start the memory reducer to bring us down from 15 megs of ram to ~2
        MemReducer.Interval = 2000
        MemReducer.Start()
        ilTabControlImages.Images.Add("blankdoc", Image.FromFile(Application.StartupPath & "\images\page.png"))
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\FirstRun.txt") Then
            frmInstalling.ShowDialog()
        End If
        LoadMacros()
    End Sub

    Public Sub loadSettings()
        'Code to load all of our settings from XMl. Pretty self explanatory.
        'Ignore any errors and just skip to the next setting if null or empty.
        On Error Resume Next

        Dim reader As New IO.StreamReader(Application.StartupPath & "\settings\settings.xml")
        Dim mydoc As New XmlDocument
        mydoc.LoadXml(reader.ReadToEnd)
        If mydoc.GetElementsByTagName("ShowToolbar").Item(0).InnerText = "False" Then
            msToolbar.Visible = False : Else : msToolbar.Visible = True
        End If
        If mydoc.GetElementsByTagName("ShowStatusbar").Item(0).InnerText = "False" Then
            msInfo.Visible = False : Else : msInfo.Visible = True
        End If
        If mydoc.GetElementsByTagName("DocumentSwitcher").Item(0).InnerText = "False" Then
            DocumentSwitcher = False : Else : DocumentSwitcher = True
        End If

        If mydoc.GetElementsByTagName("AutoHighlighting").Item(0).InnerText = "False" Then
            AutoHighlighting = False : Else : AutoHighlighting = True
        End If
        If mydoc.GetElementsByTagName("ExplorerIntegration").Item(0).InnerText = "False" Then
            ExplorerIntegration = False : Else : ExplorerIntegration = True
        End If
        CustomExplorerIntegration = mydoc.GetElementsByTagName("CustomExplorerIntegration").Item(0).InnerText

        If ExplorerIntegration = True Then
            Dim loadf As New IO.StreamReader(Application.StartupPath & "\Settings\ExplorerFileTypes.nps")
            For Each itm In loadf.ReadToEnd.Split("$SPLIT$")
                If itm <> "SPLIT" AndAlso itm <> "" Then
                    ShellMenu.Register(itm, "ProgPad", CustomExplorerIntegration, """" & Application.ExecutablePath & """" & " ""%1""")
                End If
            Next
        Else
            Dim loadf As New IO.StreamReader(Application.StartupPath & "\Settings\ExplorerFileTypes.nps")
            For Each itm In loadf.ReadToEnd.Split("$SPLIT$")
                If itm <> "SPLIT" AndAlso itm <> "" Then
                    ShellMenu.Unregister(itm, "ProgPad")
                End If
            Next
        End If

        If mydoc.GetElementsByTagName("RememberSession").Item(0).InnerText = "False" Then
            RememberSession = False : Else : RememberSession = True
        End If

        If mydoc.GetElementsByTagName("DocumentTitleBar").Item(0).InnerText = "False" Then
            DocumentTitleBar = False : Else : DocumentTitleBar = True
        End If


        If mydoc.GetElementsByTagName("ShowEOL").Item(0).InnerText = "False" Then
            ShowEOL = False : Else : ShowEOL = True : ShowEolToolstripmenuitem.Checked = True
        End If

        If mydoc.GetElementsByTagName("ShowWhiteSpace").Item(0).InnerText = "False" Then
            ShowWhiteSpace = False : Else : ShowWhiteSpace = True : ShowSpaceMarkersToolStripMenuItem.Checked = True
        End If

        If mydoc.GetElementsByTagName("LineHighlighting").Item(0).InnerText = "False" Then
            ShowLineHighlight = False : Else : ShowLineHighlight = True : LineHighlightingToolStripMenuItem.Checked = True
        End If

        LineHighlightColor = Color.FromArgb(mydoc.GetElementsByTagName("LineHighlightingColor").Item(0).InnerText)

        If mydoc.GetElementsByTagName("WordWrap").Item(0).InnerText = "False" Then
            ScinWordWrap = False : Else : ScinWordWrap = True : WordWrapToolStripMenuItem.Checked = True
        End If

        ScinFont = New Font(mydoc.GetElementsByTagName("FontName").Item(0).InnerText, mydoc.GetElementsByTagName("FontSize").Item(0).InnerText)
        FontName = mydoc.GetElementsByTagName("FontName").Item(0).InnerText
        FontSize = mydoc.GetElementsByTagName("FontSize").Item(0).InnerText

        If mydoc.GetElementsByTagName("ThemeInfoBar").Item(0).InnerText = "False" Then
            ThemeInfoBar = False : Else : ThemeInfoBar = True
        End If




        Me.Controls.Add(dPanel)
        tcFrm.Controls.Add(tcMain)
        dPanel.Dock = DockStyle.Fill
        tcMain.Dock = DockStyle.Fill
        dPanel.DocumentStyle = DocumentStyle.DockingSdi
        tcFrm.ShowHint = DockState.Document
        dPanel.BringToFront()
        tcFrm.Show(dPanel)
        tcFrm.BackColor = Color.FromArgb(mydoc.GetElementsByTagName("TabBackgroundColor").Item(0).InnerXml)
        InitializeStyles()

        ThemeFile = mydoc.GetElementsByTagName("ThemeFile").Item(0).InnerXml
        PLG = Plugin(IO.File.ReadAllBytes((mydoc.GetElementsByTagName("ThemeFile").Item(0).InnerXml)), "Theme")
        Me.SuspendLayout()
        PLG.TabControl = tcMain
        PLG.vExt = _vtExtender
        PLG.InitializeTheme()
        Me.ResumeLayout()
        Me.Refresh()



        reader.Close()
        reader.Dispose()
    End Sub



    Public Sub LoadMacros()
        Dim dinfo As New IO.DirectoryInfo(Application.StartupPath & "\Runtime\Macros")
        MacrosToolStripMenuItem.DropDownItems.Clear()
        If dinfo.GetFiles.Count = 0 Then
            MacrosToolStripMenuItem.DropDownItems.Add(NoneToolStripMenuItem1)
        End If
        For Each itm In dinfo.GetFiles
            Dim itName As String = itm.Name.Replace(".npm", "")
            Dim myMacroItem As New MacroItem
            myMacroItem.Text = itName
            myMacroItem.Image = Image.FromFile(Application.StartupPath & "\Images\playmacro.png")
            myMacroItem.ToolTipText = itm.FullName
            MacrosToolStripMenuItem.DropDownItems.Add(myMacroItem)
        Next
    End Sub

    Public Sub LoadRecentItems()
        Dim xDoc As New XmlDocument
        xDoc.Load(Application.StartupPath & "\Settings\Recent.xml")
        For Each itm As XmlNode In xDoc.GetElementsByTagName("Recent")
            Dim myRecentItem As New RecentItem
            myRecentItem.Text = itm.InnerText
            myRecentItem.Image = Image.FromFile(Application.StartupPath & "\Images\doc_single.png")
            RecentToolStripMenuItem.DropDownItems.Add(myRecentItem)
        Next
    End Sub

    Public Sub SaveRecentItems()
        Dim xDoc As New XmlTextWriter(Application.StartupPath & "\Settings\recent.xml", System.Text.Encoding.Unicode)
        xDoc.WriteStartElement("Recents")
        For Each itm In RecentToolStripMenuItem.DropDownItems
            If TypeOf itm Is RecentItem Then
                xDoc.WriteElementString("Recent", itm.Text)
            End If
        Next
        xDoc.WriteEndElement()
        xDoc.Close()
    End Sub

    Public Sub LoadCustomLexers()
        Try
            'Loads all of the custom lexers from the "Custom Lexers" folder by getting all the files in the directory, and adding a new buttonitem for each of them.
            'Note that additional lexers CAN be added by the user if they are in the correct format.
            Dim dinfo As New IO.DirectoryInfo(Application.StartupPath & "\Custom Lexers")
            SyntaxHighlightingToolStripMenuItem.DropDownItems.Clear()
            For Each itm In dinfo.GetFiles
                Dim lexItem As New LexerItem
                lexItem.Text = itm.Name.Replace(".xml", "")
                lexItem.Tag = itm.FullName
                SyntaxHighlightingToolStripMenuItem.DropDownItems.Add(lexItem)
            Next
            SyntaxHighlightingToolStripMenuItem.DropDownItems.Add(CustomfromFileToolStripMenuItem)
            SyntaxHighlightingToolStripMenuItem.DropDownItems.Add(CodeFoldingToolStripMenuItem)
        Catch
        End Try

    End Sub

    Public Sub LoadCodeBlocks()
        On Error Resume Next
        'Loads all of the user-defined code blocks from the "Code Blocks" folder by using a directoryinfo and adding a new buttonitem for each of the files.
        'Also checks if the folder exists (user may not have added any code blocks yet)
        If My.Computer.FileSystem.DirectoryExists(Application.StartupPath & "\Runtime\Code Blocks") = False Then
            MkDir(Application.StartupPath & "\Runtime\Code Blocks")
        End If
        Dim dinfo As New IO.DirectoryInfo(Application.StartupPath & "\Runtime\Code Blocks")
        CodeBlocksToolStripMenuItem.DropDownItems.Clear()
        For Each itm In dinfo.GetFiles
            If itm.Extension = ".npcb" Then
                Dim litm As New CodeBlockItem
                litm.Text = itm.Name.Replace(itm.Extension, "")
                CodeBlocksToolStripMenuItem.DropDownItems.Add(litm)
            End If
        Next
        CodeBlocksToolStripMenuItem.DropDownItems.Add(CodeBlockEditorToolStripMenuItem)
    End Sub
    Private Sub loadImages()
        'Load all the images for the various menus. Pretty self explanatory. Note that program still functions without images, but the Toolbar will not work.
        If My.Computer.FileSystem.DirectoryExists(Application.StartupPath & "\Images") = True Then
            On Error Resume Next
            SaveToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\action_save.gif")
            ConfigurationToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\config.gif")
            tsbCustomize.Image = Image.FromFile(Application.StartupPath & "\Images\layout_edit.png")
            SaveAsToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\script_save.png")
            NewToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\page_new.gif")
            OpenToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\open.gif")
            CloseToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\script_delete.png")
            ExitToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\exit.png")
            UndoToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\undo.png")
            RedoToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\redo.png")
            CutToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\cut.png")
            CopyToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\copy.png")
            PasteToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\paste.png")
            QuickFindToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\find.png")
            FindToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\findwindowed.png")
            FindInFilesToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\findinfiles.png")
            GotoToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\Goto.png")
            ReplaceToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\replace.png")
            DateTimeToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\date.png")
            SymbolToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\symbol.png")
            CodeBlocksToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\codeblock.png")
            LineHighlightingToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\linehighlight.png")
            ShowLineHighlightingToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\visible.png")
            SelectColorToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\script_palette.png")
            ZoomToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\zoom.png")
            ZoomToolStripMenuItem.Text = ""
            EncryptAndCloseSelectedToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\images\lock.png")
            ZoomInToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\zoom_in.png")
            ZoomOutToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\zoom_out.png")
            ResetZoomToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\reset_zoom.png")
            BookmarkManagerToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\tag_blue.png")
            AddBookmarkToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\tag_blue_add.png")
            ShowBookmarkMarginToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\bookmarkMargin.png")
            CodeFoldingToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\script_code.png")

            ShowSpaceMarkersToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\keyboard.png")
            ShowEolToolstripmenuitem.Image = Image.FromFile(Application.StartupPath & "\Images\eol.png")

            SendFeedbackToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\email_error.png")
            AboutToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\help.png")
            EditToolStripMenuItem1.Image = Image.FromFile(Application.StartupPath & "\Images\settings.gif")
            SelectedTextToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\selection.png")
            TextColorToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\color_wheel.png")
            FontToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\font.png")
            BookmarkingToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\images\book.png")
            TopMostToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\images\topmost.png")
            FullScreenToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\images\fullscreen.png")
            ProjectSidebarToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\images\sidebar.png")
            WordWrapToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\images\wordwrap.png")

            PrintToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\printer.png")
            PrintPreviewToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\Printpreview.gif")
            TipsToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\tips.png")

            CutBookmarkedLinesToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\images\cut.png")
            CopyBookmarkedLinesToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\copy.png")
            RemoveAllBookmarksToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\images\dellbookmarks.png")

            ShareToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\share.png")
            MultipleDocumentsToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\doc_multiple.png")
            ThisDocumentToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\doc_single.png")

            FacebookToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\share_facebook_small.png")
            FTPServerToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\share_ftp_small.png")
            LocalhostrToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\Share_localhostr_small.png")

            FTPServerToolStripMenuItemMultiple.Image = Image.FromFile(Application.StartupPath & "\Images\share_ftp_small.png")
            localhostrToolStripMenuItemMultiple.Image = Image.FromFile(Application.StartupPath & "\Images\Share_localhostr_small.png")
            FacebookToolStripMenuItemMultiple.Image = Image.FromFile(Application.StartupPath & "\Images\share_facebook_small.png")

            CheckForUpdatesToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\update.png")
            ExportToHTMLToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\exporthtml.png")

            StartRecordingToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\macro.png")
            StopRecordingToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\macro_stop.png")
            MacrosToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\images\macros.png")
            MacroManagerToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\images\macro_settings.gif")
            RecentToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\images\recentDocs.gif")

            btnRunCode.Image = Image.FromFile(Application.StartupPath & "\images\compiler_debug.png")
            btnAssemblyOptions.Image = Image.FromFile(Application.StartupPath & "\Images\compiler_options.png")

            NewProjectToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\newProject.png")
            btnFindNext.Image = Image.FromFile(Application.StartupPath & "\Images\findnext.png")
            btnFindPrevious.Image = Image.FromFile(Application.StartupPath & "\Images\findprevious.png")
            btnFindHighlightAll.Image = Image.FromFile(Application.StartupPath & "\Images\findHighlight.gif")
            GetAddonsToolStripMenuItem.Image = Image.FromFile(Application.StartupPath & "\Images\PluginManager.png")
        End If
    End Sub

    Public Sub RefreshRuns()
        Try
            'This is the first part of loading all of the custom "Run In" items. the rest of this is multithreaded.
            'This part is just the loading of the items to the menu from the "Runs.xml" file. The backgroundworker handles getting the icons.
            RunToolStripMenuItem.DropDownItems.Clear()
            Dim runs As New Collection
            Dim reader As New IO.StreamReader(Application.StartupPath & "\Settings\Runs.xml")
            Dim mydoc As New XmlDocument
            mydoc.LoadXml(reader.ReadToEnd)
            For Each itm As XmlNode In mydoc.GetElementsByTagName("Run")
                Try
                    Dim itms() As String = itm.InnerText.Split("|")
                    Dim ritm As New RunItem
                    ritm.Tag = itms(0).Substring(0, itms(0).Length - 1)
                    ritm.Tag = ritm.Tag.ToString.Replace("%ProgramFiles%", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles))
                    ritm.Tag = ritm.Tag.ToString.Replace("%Windows%", Environment.GetFolderPath(Environment.SpecialFolder.System).Replace("\System32", ""))
                    ritm.Text = itms(1).Substring(1, itms(1).Length - 1)
                    Try
                        ritm.Image = ExtractIconFromExe(ritm.Tag.ToString, False).ToBitmap
                    Catch
                        ritm.Image = ExtractIconFromExe(ritm.Tag.ToString.ToLower.Replace("\program files (x86)\", "\Program Files\"), False).ToBitmap
                    End Try
                    RunToolStripMenuItem.DropDownItems.Add(ritm)
                Catch
                End Try
            Next
            RunToolStripMenuItem.DropDownItems.Add(EditToolStripMenuItem1)
        Catch
        End Try
    End Sub

    Public Sub LoadToolBar()
        Try
            'This loads all of the items to the toolbar which the user has defined. This does this on a purely Button Text basis. Very inefficient.
            Dim loadf As New IO.StreamReader(Application.StartupPath & "\Settings\Toolbar.nps")
            Dim buts As New Collection
            For Each itm In loadf.ReadToEnd.Split("$SPLIT$")
                For Each diTm As ToolStripMenuItem In msMain.Items
                    For Each subItm In diTm.DropDownItems
                        If itm = subItm.Text Then
                            If IsNothing(subItm.Image) = False Then
                                Dim bitm As New ToolBarCloneItem
                                bitm.Image = subItm.Image
                                bitm.ToolTipText = subItm.Text
                                bitm.CheckOnClick = subItm.CheckOnClick
                                buts.Add(bitm)
                            End If
                        End If
                    Next
                Next
            Next
            For Each itm In buts
                msToolbar.Items.Add(itm)
            Next
            loadf.Close()
            loadf.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub bwLoader_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwLoader.DoWork
        'Loads the images and toolbar in a multithreaded way.
        loadImages()
        LoadToolBar()
        For Each p As Process In Process.GetProcessesByName("cmd")
            If p.MainWindowTitle.Contains("NeoIDE") Then
                p.Kill()
            End If
        Next
        Threading.Thread.Sleep(500)
    End Sub

    Private Sub bwLoader_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwLoader.RunWorkerCompleted
        'After a little while, set the icon, show the bookmark margin, do a word count, load the code blocks, custom lexers and the custom run items.
        Me.Icon = New Icon(Application.StartupPath & "\Images\Mainicon.ico")

        ShowBookmarkMarginToolStripMenuItem.PerformClick()


        tmrWordCount.Start()

        LoadCodeBlocks()
        LoadCustomLexers()
        LoadAutoCodeHighlightingPaste()
        LoadRecentItems()
        RefreshRuns()

        Dim dinfo As New IO.DirectoryInfo(Application.StartupPath & "\Addons")
        For Each fi In dinfo.GetFiles
            If fi.Extension = ".dll" Then
                Dim Addon
                Addon = Plugin(IO.File.ReadAllBytes(fi.FullName), "Addon")
                Me.SuspendLayout()
                Addon.TabControl = tcMain
                Addon.MainMenuStrip = msMain
                Addon.ScintillaContextMenu = cmuScintilla
                Addon.TabContextMenu = cmuTab
                Addon.MainForm = Me
                Addon.DockPanel = dPanel
                Addon.Initialize()
                Me.ResumeLayout()
                Me.Refresh()
            End If
        Next

    End Sub

#End Region
#Region "Theming"

    Public Sub InitializeStyles()
        'Initialize the themes on startup
        _vtExtender = New vtExtender.vtExtender.vtExtender
        _vtExtender.Add(msMain)
        If ThemeInfoBar = True Then
            _vtExtender.Add(msInfo)
        End If
        _vtExtender.Add(cmuScintilla)
        _vtExtender.Add(tsCompiler)
        _vtExtender.Add(tsFind)
        _vtExtender.Add(msToolbar)
        _vtExtender.ToolTipDelayTime = 1500
        _vtExtender.ToolTipVisibleTime = 2000
    End Sub




    'Refresh the various menus & toolstrips so that they reflect the current style.
    Private Sub RefreshStrip()
        msInfo.Refresh()
        msMain.Refresh()
        msToolbar.Refresh()
    End Sub
#End Region

#Region "Text Manipulation"
    Private Sub ChangeToUPPERCASEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeToUPPERCASEToolStripMenuItem.Click
        SelScintilla.Selection.Text = SelScintilla.Selection.Text.ToUpper
    End Sub

    Private Sub ChangeToLOWERCASEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeToLOWERCASEToolStripMenuItem.Click
        SelScintilla.Selection.Text = SelScintilla.Selection.Text.ToLower
    End Sub

    Private Sub ChangeToSentenceCaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeToSentenceCaseToolStripMenuItem.Click
        Dim SentenceCaseText As String = Nothing
        Dim CapNextString As Boolean = False
        Dim sttext As String = SelScintilla.Selection.Text.ToLower
        Dim prevChar1, prevChar2 As Char
        Try
            prevChar1 = SelScintilla.Text.Substring(SelScintilla.Selection.Start - 1, 1)
            prevChar2 = SelScintilla.Text.Substring(SelScintilla.Selection.Start - 2, 1)
        Catch
            CapNextString = True
        End Try
        Dim checked As Boolean = False
        For Each cr In SelScintilla.Selection.Text
            Dim str As String = cr.ToString
            If checked = False Then
                checked = True
                If prevChar1 = "." Or prevChar2 = "." Then
                    CapNextString = True
                End If
            End If
            If CapNextString = True Then
                If str <> " " Then
                    str = str.ToUpper
                    CapNextString = False
                End If
            Else
                str = str.ToLower
            End If
            If str = "." Then
                CapNextString = True
            End If
            SentenceCaseText &= str
        Next
        SelScintilla.Selection.Text = SentenceCaseText

    End Sub

    Private Sub InvertCaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InvertCaseToolStripMenuItem.Click
        On Error Resume Next
        Dim invertedtext As String = Nothing
        For Each cr In SelScintilla.Selection.Text
            Dim str As String = cr.ToString
            If str.ToLower = str Then
                str = str.ToUpper
            Else
                str = str.ToLower
            End If
            invertedtext &= str
        Next
        SelScintilla.Selection.Text = invertedtext

    End Sub

    Private Sub CapitalizeFirstLetterOfEachWordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CapitalizeFirstLetterOfEachWordToolStripMenuItem.Click
        Dim EachWordCapped As String = Nothing
        Dim CapNextString As Boolean = True
        Dim FirsstLetter As Boolean = True
        Dim sttext As String = SelScintilla.Selection.Text.ToLower
        For Each cr In SelScintilla.Selection.Text.ToLower
            Dim str As String = cr.ToString
            If sttext = SelScintilla.Text.ToLower Then
                If FirsstLetter = True Then
                    FirsstLetter = False
                    str = str.ToUpper
                End If
            End If
            If CapNextString = True Then
                str = str.ToUpper
                CapNextString = False
            Else
                str = str.ToLower
            End If
            If str = " " Then
                CapNextString = True
            End If
            EachWordCapped &= str
        Next
        SelScintilla.Selection.Text = EachWordCapped

    End Sub
#End Region
#Region "Autosave"
    Dim autoSaveText As String
    Private Sub tmrExpireAutoSave_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrExpireAutoSave.Tick
        If bwAutoSave.IsBusy = True Then Exit Sub
        SetupSave()
    End Sub

    Private Sub tmrTypingAutoSave_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrTypingAutoSave.Tick
        If bwAutoSave.IsBusy = True Then Exit Sub
        SetupSave()
    End Sub
    Private Sub SetupSave()
        tmrTypingAutoSave.Stop()
        autoSaveText = SelScintilla.Text
        bwAutoSave.RunWorkerAsync()
    End Sub

    Private Sub bwAutoSave_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwAutoSave.DoWork
        Dim fname As String
        Try
            fname = autoSaveText.Substring(0, 20) & " (autosaved)"
        Catch
            Dim theran As New Random
            fname = "Untitled (autosaved) short document - " & theran.Next(5000, 50000000)
        End Try
        fname = fname.Replace("\", "").Replace("/", "").Replace("|", "").Replace("""", "").Replace("?", "").Replace(":", "").Replace("*", "").Replace("<", "").Replace(">", "").Replace(Environment.NewLine, "")
        If My.Computer.FileSystem.DirectoryExists(Application.StartupPath & "\Backup") = False Then
            MkDir(Application.StartupPath & "\Backup")
        End If
        Try
            Dim savef As New IO.StreamWriter(Application.StartupPath & "\Backup\" & fname)
            savef.Write(autoSaveText)
            savef.Flush()
            savef.Close()
            savef.Dispose()
        Catch
            Dim theran As New Random
            fname = "Untitled (autosaved) short document - " & theran.Next(5000, 50000000)
            Dim savef As New IO.StreamWriter(Application.StartupPath & "\Backup\" & fname)
            savef.Write(autoSaveText)
            savef.Flush()
            savef.Close()
            savef.Dispose()
        End Try

    End Sub
#End Region
#Region "Line, char, length Count"
    Private Sub bwWordCount_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwWordCount.DoWork
        If lineCount >= 100000 Then
            indent = 53
        ElseIf lineCount >= 10000 Then
            indent = 43
        ElseIf lineCount >= 1000 Then
            indent = 40
        ElseIf lineCount >= 100 Then
            indent = 30
        ElseIf lineCount >= 10 Then
            indent = 20
        Else
            indent = 10
        End If
        docLength = docText.Length
        lineCount = SendMessage(mHwnd, EM_GETLINECOUNT, 0, 0&)
        selLine = SendMessage(mHwnd.ToInt32, EM_LINEFROMCHAR, -1, 0)
    End Sub

    Private Sub bwWordCount_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwWordCount.RunWorkerCompleted
        SelScintilla.Margins.Margin0.Width = indent
        lblTextLength.Text = "Length: " & docLength
        lblLineCount.Text = "Line Count: " & selLine + 1 & "/" & lineCount
    End Sub

    Private Sub tmrWordCount_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrWordCount.Tick
        Try
            If tcMain.SelectedForm.Text <> "Start Page" Then
                lblColumn.Text = "Column: " & SelScintilla.Lines.Current.SelectionStartPosition - SelScintilla.Lines.Current.StartPosition + 1
                docText = SelScintilla.Text
                lineCount = SelScintilla.Lines.Count
                Try
                    If bwWordCount.IsBusy = False Then
                        bwWordCount.RunWorkerAsync()
                    End If
                Catch ex As Exception

                End Try
            End If
        Catch
        End Try
    End Sub

#End Region

#Region "File Menustrip Item"
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        'Exit.
        Me.Close()
    End Sub

    Private Sub PrintPreviewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPreviewToolStripMenuItem.Click
        'Print Preview dialog...
        SelScintilla.Printing.PrintPreview()
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        'Normal print dialog
        SelScintilla.Printing.Print()
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAsToolStripMenuItem.Click
        'Save the current scintilla, disregarding whether it already has a save path.
        SaveDocument(SelScintilla, "", tcMain.TabPages.SelectedTab)
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        'If the selected scintilla doesn't have a save path, invoke a normal save as, otherwise, save using the savepath and don't bother the user with a dialog.
        If SelScintilla.SavePath = "" Then
            SaveAsToolStripMenuItem.PerformClick()
            Exit Sub
        End If
        SaveDocument(SelScintilla, SelScintilla.SavePath, tcMain.TabPages.SelectedTab)
    End Sub

    Private Sub NewProjectToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NewProjectToolStripMenuItem.Click
        frmNewProject.ShowDialog()
    End Sub

    Public Function SaveDocument(ByVal Scin As ScintillaEx, Optional ByVal SavePath As String = "", Optional ByVal tb As CustomTabControl.TabPage = Nothing) As Boolean
        'What we'll be writing to the file
        Dim txtToWrite As String = Scin.Text
        If SavePath <> "" Then
            'If we already have a save path
            Try
                'Try to save the file using the current encoding.
                Dim writer As New IO.StreamWriter(SavePath, False, Scin.Encoding)
                writer.Write(txtToWrite)
                writer.Flush()
                writer.Close()
                writer.Dispose()
                'Tell the user we've saved.
                lblInfo.Text = "Saved..."
                Scin.WasTextChanged = False
                Dim finfo As New IO.FileInfo(Scin.SavePath)
                Scin.DocumentSize = finfo.Length.ToString
                Try
                    'This is used if we're saving multiple tabs at the same time...
                    tb.Text = SavePath.Substring(SavePath.LastIndexOf("\")).Replace("\", "")
                Catch ex As Exception
                End Try
                Return True
                Dim addTo As Boolean = True
                For Each itm In RecentToolStripMenuItem.DropDownItems
                    If itm.Text = SavePath Then
                        addTo = False
                    End If
                Next
                If addTo = True Then
                    Dim myRecentItem As New RecentItem
                    myRecentItem.Text = SavePath
                    myRecentItem.Image = Image.FromFile(Application.StartupPath & "\Images\doc_single.png")
                    RecentToolStripMenuItem.DropDownItems.Add(myRecentItem)
                End If
                If RecentToolStripMenuItem.DropDownItems.Count > 16 Then
                    RecentToolStripMenuItem.DropDownItems.RemoveAt(0)
                End If
            Catch ex As Exception
                'Show the user an error, most likely if the file is in use.
                MessageBox.Show("An error occured saving the file: " & ex.Message, "Error saving")
                lblInfo.Text = "Error saving..."
                'Return false so whatever is calling this knows that we didn't save due to the fact that there was an error.
                Return False
            End Try
        Else
            'Show a new save file dialog.
            Dim sfd As New SaveFileDialog
            'Define all of the custom filters. That took me a really long time to type out.
            sfd.Filter = "All types|*.*|Normal text file (*.txt)|*.txt|Flash Actionscript file (*.as, *.mx)|*.as;*.mx|Ada file (*.ada, *.ads, *.adb)|*.ada;*.ads;*.adb" & _
                "|Assembly language source file (*.asm)|*.asm|Active Server Pages script file (*.asp)|*.asp|AutoIt (*.au3)|*.au3|Unix script file (*.sh, *.bsh)|*.sh;*.bsh" & _
                "|Batch File (*.bat, *.cmd, *.nt)|*.bat;*.cmd;*.nt|C source file (*.c)|*.c|Categorical Abstract MAchine Language (*.ml, *.mli, *.sml, *.thy)|*.ml;*.mli;*.sml;*.thy" & _
                "|CMAKEFILE (*.cmake)|*.cmake|COmmon Business Orientated Language (*.cbl, *.cbd, *.cdb, *.cdc, *.cob)|*.cbl;*.cbd;*.cdb;*.cdc;*.cob" & _
                "|C++ Source File (*.h, *.cpp, *.hpp, *.hxx, *.cxx, *.cc)|*.h;*.cpp;*.hpp;*.hxx;*.cxx;*.cc|C# Source file (*.cs)|*.cs|Cascade Style Sheets file (*.css)|*.css" & _
                "|D programming language (*.d)|*.d|Diff file (*.diff, *.patch)|*.diff;*.patch|Fortrain source file (*.f, *.for, *.f90, *.f95, *.f2k)|*.f;*.for;*.f90;*.f95;*.f2k" & _
                "|Haskell (*.hs, *.lhs, *.as, *.las)|*.hs;*.lhs;*.as;*.las|Hyper Text Markup Language file (*.htm, *.html, *.shtml, *.shtm, *.xhtml)|*.htm;*.html;*.shtml;*.shtm;*.xhtml)" & _
                "|MS ini file (*.ini, *.inf, *.reg, *.url)|*.ini;*.inf;*.reg;*.url|Inno Setup script (*.jss)|*.jss|Java source file (*.java)|*.java|JavaScript file (*.js)|*.js" & _
                "|JavaServer Pages script file (*.jsp)|*.jsp|KiXtart File (*.kix)|*.kix|List Processing language file (*.lsp, *.lisp)|*.lsp;*.lisp|Lua source file (*.lua)|*.lua" & _
                "|Makefile (*.mak)|*.mak|MATrix LABoratory (*.m)|*.m|MSDOS Stlye/ASCII Art (*.nfo)|*.nfo|Nullsoft Scriptable Install System script file (*.nsi, *.nsh)|*.nsi;*.nsh" & _
                "|Pascal source file (*.pas, *.inc)|*.pas;*.inc|Perl source file (*.pl, *.pm, *.plx)|*.pl;*.pm;*.plx|PJP Hypertext Preprocessor file (*.php, *.php3, *.phtml)|*.php;*.php3;*.phtml" & _
                "|Postscript file (*.ps)|*.ps|Windows PowerShell (*.ps1)|*.ps1|Properties file (*.properties)|*.properties|Python file (*.py, *.pyw)|*.py;*.pyw|R programming language (*.r)|*.r" & _
                "|Windows Resource file (*.rc)|*.rc|Ruby file (*.rb, *.rbw)|*.rb;*.rbw|Scheme file (*.scm, *.smd, *.ss)|*.scm;*.smd;*.ss|Smalltalk file (*.st)|*.st|Structured Query Language file (*.sql)|*.sql" & _
                "|Tool Command Language file (*.tcl)|*.tcl|TeX file (*.tex)|*.tex|Visual Basic file (*.vb, *.vbs)|*.vb;*.vbs|Verilog file (*.v)|*.v|VHSIC Hardware Description Language file (*.vhd, *.vhdl)|*.vhd;*.vhdl" & _
                "|eXtensible Markup Language file (*.xml, *.xsml, *.xsl, *.xsd, *.kml, *.wsdl)|*.xml;*.xsml;*.xsl;*.xsd;*.kml;*.wsdl|YAML Ain't Markup Language (*.yml)|*.yml"
            'If the Scintilla's Savepath is not Nothing (i.e. the user is doing "Save As" on a pre-existing file)
            If Scin.SavePath <> "" Then
                'This took me even longer - a really annoying and fiddly process - this selects the correct save file filter for the file type at hand.
                Select Case Scin.SavePath.Substring(Scin.SavePath.LastIndexOf(".")).ToLower
                    Case ".txt" : sfd.FilterIndex = 2 : Case ".as" : sfd.FilterIndex = 3 : Case ".mx" : sfd.FilterIndex = 3 : Case ".ada" : sfd.FilterIndex = 4
                    Case ".ads" : sfd.FilterIndex = 4 : Case ".adb" : sfd.FilterIndex = 4 : Case ".asm" : sfd.FilterIndex = 5 : Case ".asp" : sfd.FilterIndex = 6
                    Case ".au3" : sfd.FilterIndex = 7 : Case ".sh" : sfd.FilterIndex = 8 : Case ".bsh" : sfd.FilterIndex = 8 : Case ".bat" : sfd.FilterIndex = 9
                    Case ".cmd" : sfd.FilterIndex = 9 : Case ".nt" : sfd.FilterIndex = 9 : Case ".c" : sfd.FilterIndex = 10 : Case ".ml" : sfd.FilterIndex = 11
                    Case ".mli" : sfd.FilterIndex = 11 : Case ".sml" : sfd.FilterIndex = 11 : Case ".thy" : sfd.FilterIndex = 11
                    Case ".cmake" : sfd.FilterIndex = 12 : Case ".cbl" : sfd.FilterIndex = 13 : Case ".cbd" : sfd.FilterIndex = 13 : Case ".cdb" : sfd.FilterIndex = 13
                    Case ".cdc" : sfd.FilterIndex = 13 : Case ".cob" : sfd.FilterIndex = 13 : Case ".h" : sfd.FilterIndex = 14 : Case ".cpp" : sfd.FilterIndex = 14
                    Case ".hpp" : sfd.FilterIndex = 14 : Case ".hxx" : sfd.FilterIndex = 14 : Case ".cxx" : sfd.FilterIndex = 14 : Case ".cc" : sfd.FilterIndex = 14
                    Case ".cs" : sfd.FilterIndex = 15 : Case ".css" : sfd.FilterIndex = 16 : Case ".d" : sfd.FilterIndex = 17 : Case ".diff" : sfd.FilterIndex = 18
                    Case ".patch" : sfd.FilterIndex = 18 : Case ".f" : sfd.FilterIndex = 19 : Case ".for" : sfd.FilterIndex = 19 : Case ".f90" : sfd.FilterIndex = 19
                    Case ".f95" : sfd.FilterIndex = 19 : Case ".f2k" : sfd.FilterIndex = 19 : Case ".hs" : sfd.FilterIndex = 20 : Case ".lhs" : sfd.FilterIndex = 20
                    Case ".as" : sfd.FilterIndex = 20 : Case ".las" : sfd.FilterIndex = 20 : Case ".htm" : sfd.FilterIndex = 21 : Case ".html" : sfd.FilterIndex = 21
                    Case ".shtml" : sfd.FilterIndex = 21 : Case ".shtm" : sfd.FilterIndex = 21 : Case ".xhtml" : sfd.FilterIndex = 21 : Case ".ini" : sfd.FilterIndex = 22
                    Case ".inf" : sfd.FilterIndex = 22 : Case ".reg" : sfd.FilterIndex = 22 : Case ".url" : sfd.FilterIndex = 22 : Case ".jss" : sfd.FilterIndex = 23
                    Case ".java" : sfd.FilterIndex = 24 : Case ".js" : sfd.FilterIndex = 25 : Case ".jsp" : sfd.FilterIndex = 26 : Case ".kix" : sfd.FilterIndex = 27
                    Case ".lsp" : sfd.FilterIndex = 28 : Case ".lisp" : sfd.FilterIndex = 28 : Case ".lua" : sfd.FilterIndex = 29 : Case ".mak" : sfd.FilterIndex = 30
                    Case ".m" : sfd.FilterIndex = 31 : Case ".nfo" : sfd.FilterIndex = 32 : Case ".nsi" : sfd.FilterIndex = 33 : Case ".nsh" : sfd.FilterIndex = 33
                    Case ".pas" : sfd.FilterIndex = 34 : Case ".inc" : sfd.FilterIndex = 34 : Case ".pl" : sfd.FilterIndex = 35 : Case ".pm" : sfd.FilterIndex = 35
                    Case ".plx" : sfd.FilterIndex = 35 : Case ".php" : sfd.FilterIndex = 36 : Case ".php3" : sfd.FilterIndex = 36 : Case ".phtml" : sfd.FilterIndex = 36
                    Case ".ps" : sfd.FilterIndex = 37 : Case ".ps1" : sfd.FilterIndex = 38 : Case ".properties" : sfd.FilterIndex = 39 : Case ".py" : sfd.FilterIndex = 40
                    Case ".pyw" : sfd.FilterIndex = 40 : Case ".r" : sfd.FilterIndex = 41 : Case ".rc" : sfd.FilterIndex = 42 : Case ".rb" : sfd.FilterIndex = 43
                    Case ".rbw" : sfd.FilterIndex = 43 : Case ".scm" : sfd.FilterIndex = 44 : Case ".smd" : sfd.FilterIndex = 44 : Case ".ss" : sfd.FilterIndex = 44
                    Case ".st" : sfd.FilterIndex = 45 : Case ".sql" : sfd.FilterIndex = 46 : Case ".tcl" : sfd.FilterIndex = 47 : Case ".tex" : sfd.FilterIndex = 48
                    Case ".vb" : sfd.FilterIndex = 49 : Case ".vbs" : sfd.FilterIndex = 49 : Case ".v" : sfd.FilterIndex = 50 : Case ".vhd" : sfd.FilterIndex = 51
                    Case ".vhdl" : sfd.FilterIndex = 51 : Case ".xml" : sfd.FilterIndex = 52 : Case ".xsml" : sfd.FilterIndex = 52 : Case ".xsl" : sfd.FilterIndex = 52
                    Case ".xsd" : sfd.FilterIndex = 52 : Case ".kml" : sfd.FilterIndex = 52 : Case ".wsdl" : sfd.FilterIndex = 52 : Case ".yml" : sfd.FilterIndex = 53
                        'If we can't find the file type, just use "All Files".
                    Case Else
                        sfd.FilterIndex = 1
                End Select
                'Get the absolute file name
                Dim finame As String = Scin.SavePath.Substring(Scin.SavePath.LastIndexOf("\")).Replace("\", "")
                If sfd.FilterIndex <> 1 Then
                    'If we're not set to all files, then exclude the extension
                    Dim rep As String = finame.Substring(finame.LastIndexOf("."))
                    sfd.FileName = finame.Replace(rep, "")
                Else
                    'If we are, include it
                    sfd.FileName = finame
                End If
                'Set the initial directory to the parent directory of the save path of the current Scintilla for convenience.
                sfd.InitialDirectory = Scin.SavePath.Replace(sfd.FileName, "")
            Else
                'If we're just doing a normal save as on a document created in scintilla, use ".txt" as the default extension.
                sfd.FilterIndex = 2
            End If
            sfd.Title = Scin.Parent.Text
            If sfd.ShowDialog = DialogResult.OK Then
                Try
      
                    'Try to perform the same process as last time..
                    Dim writer As New IO.StreamWriter(sfd.FileName, False, Scin.Encoding)
                    writer.Write(txtToWrite)
                    writer.Flush()
                    writer.Close()
                    writer.Dispose()
                    lblInfo.Text = "Saved..."
                    Scin.SavePath = sfd.FileName
                    Scin.WasTextChanged = False
                    Dim finfo As New IO.FileInfo(sfd.FileName)
                    Scin.DocumentSize = finfo.Length.ToString
                    Try
                        tb.Form.Text = IO.Path.GetFileName(sfd.FileName)
                        tb.Icon = Icon.FromHandle(New Bitmap(GetShellIconAsImage(sfd.FileName)).GetHicon)
                    Catch ex2 As Exception
                    End Try
                    Dim addTo As Boolean = True
                    For Each itm In RecentToolStripMenuItem.DropDownItems
                        If itm.Text = sfd.FileName Then
                            addTo = False
                        End If
                    Next
                    If addTo = True Then
                        Dim myRecentItem As New RecentItem
                        myRecentItem.Text = sfd.FileName
                        myRecentItem.Image = Image.FromFile(Application.StartupPath & "\Images\doc_single.png")
                        RecentToolStripMenuItem.DropDownItems.Add(myRecentItem)
                    End If
                    If RecentToolStripMenuItem.DropDownItems.Count > 16 Then
                        RecentToolStripMenuItem.DropDownItems.RemoveAt(0)
                    End If

                Catch ex As Exception
                    MessageBox.Show("An error occured saving the file: " & ex.Message, "Error saving")
                    lblInfo.Text = "Error saving..."
                    Return False
                End Try
            Else
                'If the user didn't press OK, return false so whatever is calling this knows that we didn't save.
                Return False
            End If
        End If
    End Function



    Public Sub CreateNewDoc(Optional ByVal path As String = "")
        'Create a new document, with an option to load a file
        'Create a new scintilla
        Dim myScintilla As New ScintillaEx
        'Make sure it occupies the whole tab
        myScintilla.Dock = DockStyle.Fill
        'Set the margins
        myScintilla.Margins.Margin2.Width = 0
        myScintilla.Margins.Margin0.Width = 10
        myScintilla.Margins.Margin3.Width = 0
        myScintilla.Margins.Margin4.Width = 0

        If ShowBookmarkMarginToolStripMenuItem.Checked = True Then
            'If the user wants to show the bookmark margin, then show the bookmark margin...
            myScintilla.Margins.Margin1.Width = 20
            myScintilla.Margins.Margin1.IsMarkerMargin = True
            myScintilla.Margins.Margin1.IsClickable = True
            myScintilla.Margins.Margin1.AutoToggleMarkerNumber = True
        Else
            'Otherwise hide it.
            myScintilla.Margins.Margin1.Width = 0
        End If
        If ScinWordWrap = True Then
            'If the user wants word wrap, enable it.
            myScintilla.LineWrapping.Mode = LineWrappingMode.Word
        End If
        If ScinColor <> Nothing Then
            'If the user has specified a color, use it
            myScintilla.ForeColor = ScinColor
        End If
        If ScinFont IsNot Nothing Then
            'If the user has specified a font, use it.
            myScintilla.Font = ScinFont
        End If
        If ShowEOL = True Then
            myScintilla.EndOfLine.IsVisible = True
        End If
        If ShowWhiteSpace = True Then
            myScintilla.Whitespace.Mode = WhitespaceMode.VisibleAlways
        End If
        myScintilla.ContextMenuStrip = cmuScintilla
        'If the user wants to highlight the selected line, then do
        myScintilla.Caret.HighlightCurrentLine = ShowLineHighlight
        'Set the line highlight to the user defined color.
        myScintilla.Caret.CurrentLineBackgroundColor = LineHighlightColor

        'Tell the program that the current scintilla is the newly created one
        SelScintilla = myScintilla
        'Make sure we know not to prompt to save the document without editing it
        myScintilla.WasTextChanged = False
        'Make sure the handle of the scintilla is set for the word count
        mHwnd = myScintilla.Handle

        'Add one to the number of new documents
        notes += 1
        'Create a new tabpage
        Dim tb As New Form
        AddHandler tb.FormClosing, AddressOf NonSelectedTabClose

        'Set the text to inform the user that it's a new document
        tb.Text = "New - " & notes.ToString
        tb.AccessibleDescription = "SCINFORM"
        tb.Width = 200
        tb.Icon = Icon.FromHandle(New Bitmap(Application.StartupPath & "\images\page.png").GetHicon)


        'Add the scintilla to the tabpage
        tb.Controls.Add(myScintilla)
        'Add the tabpage to the tabcontrol
        Dim x As TabPage = tcMain.TabPages.Add(tb)
        x.Select()
        AddHandler x.MouseEnter, AddressOf TabMouseEnter
        AddHandler x.MouseClick, AddressOf TabMouseDown
        AddHandler x.MouseLeave, AddressOf TabMouseLeave


        'Make sure that the tab is selected
        'Make sure that the scintilla is selected.
        myScintilla.Focus()
        myScintilla.Select()
        If path <> "" Then
            'If there is a document location specified, try to load it
            Try
                Dim addTo As Boolean = True
                For Each itm In RecentToolStripMenuItem.DropDownItems
                    If itm.Text = path Then
                        addTo = False
                    End If
                Next
                If addTo = True Then
                    Dim myRecentItem As New RecentItem
                    myRecentItem.Text = path
                    myRecentItem.Image = Image.FromFile(Application.StartupPath & "\Images\doc_single.png")
                    RecentToolStripMenuItem.DropDownItems.Add(myRecentItem)
                End If
                If RecentToolStripMenuItem.DropDownItems.Count > 16 Then
                    RecentToolStripMenuItem.DropDownItems.RemoveAt(0)
                End If
                Dim loadf As New IO.StreamReader(path)
                'Get the file name alone
                Dim finame As String = path.Substring(path.LastIndexOf("\")).Replace("\", "")
                'If it's too long then cut it short and set the tab text to the file name
                If finame.Length > 30 Then
                    tb.Text = finame.Substring(0, 30) & "..."
                Else
                    tb.Text = finame
                End If
                tb.Tag = path
                'Show the user where the file in the tab is from in the tab tooltip

                'Make sure that the user can see the tooltip

                If CreatingDocumentBackup = False Then
                    'Set the save path for the document as the path that we opened, asssuming we're not loading a backup document.
                    myScintilla.SavePath = path
                End If
                'Set the scintilla text to whatever we read from the file
                myScintilla.Text = loadf.ReadToEnd
                If myScintilla.Text.StartsWith("PROGPADENCRYPT:") Then
                    Dim res As DialogResult = MessageBox.Show("This document has been encrypted. Do you want to decrypt it?", "Encrypted Document", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If res = Windows.Forms.DialogResult.Yes Then
                        frmEncrypt.EncryptMode = False
                        frmEncrypt.ApplicableText = myScintilla.Text
                        frmEncrypt.ShowDialog()
                    End If
                End If
                'Close and dispose with our loader
                loadf.Close()
                loadf.Dispose()

                tb.Icon = Icon.FromHandle(New Bitmap(GetShellIconAsImage(path)).GetHicon)


                If AutoHighlighting = True Then
                    For Each itm In AutoHighligtingRules
                        If path.Contains(".") Then
                            If itm.Contains(path.Substring(path.LastIndexOf("."))) Then
                                For Each ddItm As ToolStripMenuItem In SyntaxHighlightingToolStripMenuItem.DropDownItems
                                    If ddItm.Text = itm.Substring(itm.LastIndexOf("$%$")).Replace("$%$", "") Then
                                        ddItm.PerformClick()
                                    End If
                                Next
                            End If
                        End If
                    Next
                End If
                Dim finfo As New IO.FileInfo(path)
                myScintilla.DocumentSize = finfo.Length.ToString
            Catch ex As Exception
                'If we cant, then tell the user
                MessageBox.Show("There was an error opening the file: " & ex.Message, "Error")
            End Try
            'Make bloody sure that the scintilla knows that we haven't changed the text yet. Had problems with this, but now solved.
            myScintilla.WasTextChanged = False
        End If
        If DocumentTitleBar = True Then
            Me.Text = "NeoIDE - " & tb.Text
        End If
        If CreatingDocumentBackup = True Then
            myScintilla.WasTextChanged = True
        End If

    End Sub


    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        'Create a new document
        CreateNewDoc()
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        'If there's only one document open, then ignore.
        If tcMain.TabPages.Count = 1 Then Exit Sub

        If SelScintilla.WasTextChanged = False Then
            'If the text has not been changed, close the document, and select the previous tab.

            Dim oldindex As Integer = tcMain.TabPages.SelectedIndex
            If oldindex - 1 = -1 Then
                tcMain.TabPages(oldindex).Select()
            Else
                tcMain.TabPages(oldindex - 1).Select()
            End If
            tcMain.TabPages.RemoveAt(oldindex)
            ourPB.Hide()
        Else
            'If the text has been changed, prompt the user to save
            Dim dr As DialogResult = MessageBox.Show("The document: '" & tcMain.SelectedForm.Text & "' has not been saved. Do you want to save it now?", "Document not saved", MessageBoxButtons.YesNoCancel)
            If dr = Windows.Forms.DialogResult.Yes Then
                'If the user says yes
                If SelScintilla.SavePath = "" Then
                    'If the document has not yet been saved before, and thus has no save path, then save the document
                    If SaveDocument(SelScintilla) = True Then
                        'If the document has been saved successfuly, then perform the same procedure
                        Dim oldindex As Integer = tcMain.TabPages.SelectedIndex
                        If oldindex - 1 = -1 Then
                            tcMain.TabPages(oldindex).Select()
                        Else
                            tcMain.TabPages(oldindex - 1).Select()
                        End If
                        tcMain.TabPages.RemoveAt(oldindex)
                        ourPB.Hide()
                    End If
                Else
                    'Otherwise if the document has been saved before, save, but specifying the file path. Then perform the same procedure as before.
                    If SaveDocument(SelScintilla, SelScintilla.SavePath) = True Then
                        Dim oldindex As Integer = tcMain.TabPages.SelectedIndex
                        If oldindex - 1 = -1 Then
                            tcMain.TabPages(oldindex).Select()
                        Else
                            tcMain.TabPages(oldindex - 1).Select()
                        End If
                        tcMain.TabPages.RemoveAt(oldindex)
                        ourPB.Hide()
                    End If
                End If
            ElseIf dr = DialogResult.No Then
                'If the user says no to saving, then just close.
                Dim oldindex As Integer = tcMain.TabPages.SelectedIndex
                If oldindex - 1 = -1 Then
                    tcMain.TabPages(oldindex + 1).Select()
                Else
                    tcMain.TabPages(oldindex - 1).Select()
                End If
                tcMain.TabPages.RemoveAt(oldindex)
                ourPB.Hide()
            End If
        End If
    End Sub

    Private Sub NonSelectedTabClose(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs)
        If tcMain.TabPages.Count <> 1 Then
            Dim formScintilla As ScintillaEx = CType(sender, Form).Controls(0)
            'If the text has not been changed, close the document, and select the previous tab.
            If formScintilla.WasTextChanged = True Then
                'If the text has been changed, prompt the user to save
                Dim dr As DialogResult = MessageBox.Show("The document: '" & sender.Text & "' has not been saved. Do you want to save it now?", "Document not saved", MessageBoxButtons.YesNoCancel)
                If dr = Windows.Forms.DialogResult.Yes Then
                    'If the user says yes
                    If formScintilla.SavePath = "" Then
                        'If the document has not yet been saved before, and thus has no save path, then save the document
                        If SaveDocument(formScintilla) = False Then
                            'If the document has been saved successfuly, then perform the same procedure
                            e.Cancel = True
                        Else
                            ourPB.Hide()
                        End If
                    Else
                        'Otherwise if the document has been saved before, save, but specifying the file path. Then perform the same procedure as before.
                        If SaveDocument(formScintilla, formScintilla.SavePath) = False Then
                            e.Cancel = True
                            ourPB.Hide()
                        Else
                            ourPB.Hide()
                        End If
                    End If
                ElseIf dr = Windows.Forms.DialogResult.Cancel Then
                    e.Cancel = True
                Else
                    ourPB.Hide()
                End If
            Else
                ourPB.Hide()
            End If
        Else
            e.Cancel = True
        End If


    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        'Open a file... show a dialog
        Dim ofd As New OpenFileDialog
        ofd.Title = "Select a file to open"
        ofd.Multiselect = True
        If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
            'If the user says "OK", then create a new document with the filepath from the OpenFileDialog
            For Each itm In ofd.FileNames
                CreateNewDoc(itm)
            Next

        End If
    End Sub

    Private Sub EncryptAndCloseSelectedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EncryptAndCloseSelectedToolStripMenuItem.Click
        If EncryptAndCloseSelectedToolStripMenuItem.Text = "Decrypt Selected" Then
            frmEncrypt.EncryptMode = False
            frmEncrypt.ApplicableText = SelScintilla.Text
            frmEncrypt.ShowDialog()
        Else
            frmEncrypt.EncryptMode = True
            frmEncrypt.ApplicableText = SelScintilla.Text
            frmEncrypt.ShowDialog()
        End If
    End Sub

#Region "Sharing"
    Private Sub ProgrammersCloudToolStripMenuItemMultiple_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub localhostrToolStripMenuItemMultiple_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles localhostrToolStripMenuItemMultiple.Click
        Dim ofd As New OpenFileDialog
        ofd.Title = "Select files to upload..."
        ofd.Filter = "All Files (*.*)|*.*"
        ofd.Multiselect = True
        If ofd.ShowDialog = DialogResult.OK Then
            For Each itm In ofd.FileNames
                Dim lUploader As New frmLocalHostrUploader
                lUploader.fName = itm
                lUploader.ShowDialog()
            Next
        End If
    End Sub

    Private Sub LocalhostrToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LocalhostrToolStripMenuItem.Click
        If SelScintilla.SavePath = "" Or SelScintilla.WasTextChanged = True Then
            Dim mbres As DialogResult = MsgBox("Error - the selected document has not been saved. Save now?", MsgBoxStyle.YesNo, "Error")
            If mbres = DialogResult.Yes Then
                If SaveDocument(SelScintilla, "", tcMain.TabPages.SelectedTab) = True Then
                    Dim lUploader As New frmLocalHostrUploader
                    lUploader.fName = SelScintilla.SavePath
                    lUploader.ShowDialog()
                Else
                    Exit Sub
                End If
            End If
        Else
            Dim lUploader As New frmLocalHostrUploader
            lUploader.fName = SelScintilla.SavePath
            lUploader.ShowDialog()
        End If

    End Sub

#End Region

    Private Sub ExportToHTMLToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExportToHTMLToolStripMenuItem.Click
        Dim ourHTML As String = SelScintilla.ExportHtml()
        Dim sfd As New SaveFileDialog
        sfd.Title = "Export " & tcMain.SelectedForm.Text & " to HTML"
        sfd.Filter = "HTML Files|*.html;*.htm"
        If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim writer As New StreamWriter(sfd.FileName)
            writer.Write(ourHTML)
            writer.Close()
            writer.Dispose()
        End If
    End Sub
#End Region
#Region "Edit Menustrip Item"
    'All of these are pretty basic, you get hte idea... find, cut, copy, paste, etc
    Private Sub FindInFilesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindInFilesToolStripMenuItem.Click
        frmFindInFiles.Show()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem.Click
        SelScintilla.Clipboard.Paste()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripMenuItem.Click
        SelScintilla.Clipboard.Cut()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        SelScintilla.Clipboard.Copy()
    End Sub

    Private Sub UndoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UndoToolStripMenuItem.Click
        SelScintilla.UndoRedo.Undo()
    End Sub

    Private Sub RedoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RedoToolStripMenuItem.Click
        SelScintilla.UndoRedo.Redo()
    End Sub


    Private Sub FindToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindToolStripMenuItem.Click
        SelScintilla.FindReplace.ShowFind()
    End Sub

    Private Sub ReplaceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReplaceToolStripMenuItem.Click
        SelScintilla.FindReplace.ShowReplace()
    End Sub

    Private Sub GotoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GotoToolStripMenuItem.Click
        'Prompt the user to enter a number using an inputbox (yes I know it's old... but it happens to just about work)
        Dim ib As String = Microsoft.VisualBasic.Interaction.InputBox("Please enter line number...", "Enter Line Number...", 0)
        'If the user entered a number, then try to go to that line
        If IsNumeric(ib) = True Then SelScintilla.GoTo.Line(ib - 1)
    End Sub

    Private Sub ReverseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReverseToolStripMenuItem.Click
        'Reverse the currently selected text. Pretty straight forward.
        Dim revstr As String = ""
        For Each itm In SelScintilla.Selection.Text.Reverse
            revstr &= itm
        Next
        SelScintilla.Selection.Text = revstr
    End Sub


#End Region
#Region "Insert Menustrip Item"
    'Just showing more forms here...
    Private Sub CodeBlockEditorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CodeBlockEditorToolStripMenuItem.Click
        frmCodeBlockManager.ShowDialog()
    End Sub

    Private Sub DateTimeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimeToolStripMenuItem.Click
        'Insert the current date using Date.Now.Tostring
        SelScintilla.InsertText(Date.Now.ToString)
    End Sub

    Private Sub SymbolToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SymbolToolStripMenuItem.Click
        frmInsertSymbol.ShowDialog()
    End Sub
#End Region
#Region "View Menustrip item"
    Private Sub ConfigurationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigurationToolStripMenuItem.Click
        Dim fc As New frmConfig
        fc.ShowDialog()


    End Sub

    Private Sub HTMLSidebarToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles HTMLSidebarToolStripMenuItem.Click
        'Show the project sidebar
        frmHTMLSidebar.ShowHint = DockState.DockTop
        frmHTMLSidebar.Show(dPanel)
    End Sub

    Public Sub SetPluginFile(ByVal DllName As String)
        PLG = Plugin(IO.File.ReadAllBytes(DllName), "Theme")
        ThemeFile = DllName
        Me.SuspendLayout()
        PLG.TabControl = tcMain
        PLG.vExt = _vtExtender
        PLG.InitializeTheme()
        Me.ResumeLayout()
        Me.Refresh()
    End Sub
    Private Sub IndicatorsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowEolToolstripmenuitem.Click
        For Each tb In tcMain.Controls(2).Controls
            If tb.AccessibleDescription = "SCINFORM" Then
                ShowEOL = ShowEolToolstripmenuitem.Checked
                CType(tb.Controls(0), ScintillaEx).EndOfLine.IsVisible = ShowEolToolstripmenuitem.Checked

            End If
            '  CType(tb.Controls(0).
        Next
    End Sub

    Private Sub ShowSpaceMarkersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowSpaceMarkersToolStripMenuItem.Click
        For Each tb In tcMain.Controls(2).Controls
            If ShowSpaceMarkersToolStripMenuItem.Checked = True Then
                CType(tb.Controls(0), ScintillaEx).Whitespace.Mode = ScintillaNET.WhitespaceMode.VisibleAlways
                ShowWhiteSpace = True
            Else
                CType(tb.Controls(0).Controls.Item(0), ScintillaEx).Whitespace.Mode = ScintillaNET.WhitespaceMode.Invisible
                ShowWhiteSpace = False
            End If
        Next
    End Sub


    Private Sub FullScreenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FullScreenToolStripMenuItem.Click
        'Show the program full screen without a border, and make sure to show the "X" button to close the full screen interface
        If FullScreenToolStripMenuItem.Checked = True Then
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Me.WindowState = FormWindowState.Maximized
            XToolStripMenuItem.Visible = True
        Else
            'If we're already full screen, then exit full screen
            XToolStripMenuItem.PerformClick()
        End If
    End Sub

    Private Sub TopMostToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TopMostToolStripMenuItem.Click
        'Make the program top most depending on whether the button is checked (auto checks on click)
        Me.TopMost = TopMostToolStripMenuItem.Checked
    End Sub

    Private Sub XToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XToolStripMenuItem.Click
        'Make sure that full screen is not checked, set the border back to normal, and hide the "X" button for full screen mode
        FullScreenToolStripMenuItem.Checked = False
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        Me.WindowState = FormWindowState.Normal
        XToolStripMenuItem.Visible = False
    End Sub

    Private Sub ProjectSidebarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProjectSidebarToolStripMenuItem.Click
        'Show the project sidebar
        frmSidebar.ShowHint = DockState.DockRight
        frmSidebar.Show(dPanel)
    End Sub
#End Region
#Region "Format Menustrip Item"
    Private Sub ShowLineHighlightingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowLineHighlightingToolStripMenuItem.Click
        'Tell each tab whether to show line higlighting. Pretty simple.
        For Each tb As TabPage In tcMain.TabPages
            If ShowLineHighlightingToolStripMenuItem.Checked = False Then
                If tb.Form.AccessibleDescription = "SCINFORM" Then
                    CType(tb.Form.Controls(0), ScintillaEx).Caret.HighlightCurrentLine = False
                    ShowLineHighlight = False
                End If
            Else
                If tb.Form.AccessibleDescription = "SCINFORM" Then
                    CType(tb.Form.Controls(0), ScintillaEx).Caret.HighlightCurrentLine = True
                    ShowLineHighlight = True
                End If
            End If
        Next
    End Sub

    Private Sub SelectColorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectColorToolStripMenuItem.Click
        'Show a color picker dialog
        Dim cpd As New ColorDialog
        'If user presses OKAY
        If cpd.ShowDialog() = DialogResult.OK Then
            'Tell each tab to higlight the current line in that color.
            For Each tb In tcMain.Controls(2).Controls
                If tb.AccessibleDescription = "SCINFORM" Then
                    CType(tb.Controls(0), ScintillaEx).Caret.CurrentLineBackgroundColor = cpd.Color
                    LineHighlightColor = cpd.Color
                End If
            Next
        End If
    End Sub

    Private Sub FontToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FontToolStripMenuItem.Click
        'Show a font dialog
        Dim fDLG As New FontDialog
        'If user presses OKAY
        fDLG.Font = SelScintilla.Font
        If fDLG.ShowDialog = DialogResult.OK Then
            'Tell each tab to use the specified font in the Scintilla.
            For Each tb In tcMain.Controls(2).Controls
                CType(tb.Controls(0), ScintillaEx).Font = fDLG.Font
                FontName = fDLG.Font.Name
                FontSize = fDLG.Font.Size
                ScinFont = fDLG.Font
            Next
        End If
    End Sub

    Private Sub TextColorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextColorToolStripMenuItem.Click
        'Show a color picker dialog
        Dim cdlg As New ColorDialog
        'If user presses OKAY
        If cdlg.ShowDialog = DialogResult.OK Then
            'Tell each tab to use the specified forecolor in the Scintilla.
            For Each tb As TabPage In tcMain.TabPages
                If tb.Form.AccessibleDescription = "SCINFORM" Then
                    CType(tb.Form.Controls(0), ScintillaEx).ForeColor = cdlg.Color
                    ScinColor = cdlg.Color
                End If
            Next
        End If
    End Sub

    Private Sub WordWrapToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WordWrapToolStripMenuItem.Click
        'For each tab, tell it to use word wrap (or not) depending on whether the button is checked (auto check on click)
        For Each tb In tcMain.Controls(2).Controls
            If tb.AccessibleDescription = "SCINFORM" Then
                If WordWrapToolStripMenuItem.Checked = True Then
                    ScinWordWrap = True
                    CType(tb.Controls(0), ScintillaEx).LineWrapping.Mode = LineWrappingMode.Word
                Else
                    ScinWordWrap = False
                    CType(tb.Controls(0), ScintillaEx).LineWrapping.Mode = LineWrappingMode.None
                End If
            End If
        Next
    End Sub
#Region "Bookmarking"
    Private Sub ViewToolStripMenuItem_DropDownOpening(ByVal sender As Object, ByVal e As System.EventArgs) Handles ViewToolStripMenuItem.DropDownOpening
        If tcMain.SelectedForm.Text <> "Start Page" Then
            'As soon as the user hovers over the view toolstripmenuitem, we want the bookmarks item to be expandable, so we have to populate it immediately.
            BookmarkManagerToolStripMenuItem.DropDownItems.Clear()
            'Loop through each line, check if it's bookmarked, and if so, add it to the list.. pretty simple.
            For Each ln As Line In SelScintilla.Lines
                For Each Marker In SelScintilla.Markers.GetMarkers(ln)
                    If SelScintilla.Markers.GetMarkerMask(ln) <> 0 Then
                        Dim tsitem As New BookmarkItem
                        tsitem.Text = "Bookmark - " & ln.Number + 1
                        BookmarkManagerToolStripMenuItem.DropDownItems.Add(tsitem)
                        Exit For
                    End If
                Next
            Next
            'If there are no bookmarks, tell the user
            If BookmarkManagerToolStripMenuItem.DropDownItems.Count = 0 Then
                BookmarkManagerToolStripMenuItem.DropDownItems.Add("None...")
            End If
        End If
    End Sub

    Private Sub AddBookmarkToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddBookmarkToolStripMenuItem.Click
        'Toggle the bookmark for the selected line (the one the carret is on)
        Dim currentLine As ScintillaNET.Line = SelScintilla.Lines.Current
        If SelScintilla.Markers.GetMarkerMask(currentLine) = 0 Then
            currentLine.AddMarker(0)
        Else
            currentLine.DeleteMarker(0)
        End If

        'Show the bookmark margin if it is not visible.
        If ShowBookmarkMarginToolStripMenuItem.Checked = False Then
            ShowBookmarkMarginToolStripMenuItem.PerformClick()
        End If
    End Sub

    Private Sub CutBookmarkedLinesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutBookmarkedLinesToolStripMenuItem.Click
        'Loop through each line, if it is bookmarked, then add it to a list of lines to be cut. Then set the text of the line to nothing, and set the clipboard text to the lines
        Dim toCut As String = ""
        For Each ln As Line In SelScintilla.Lines
            For Each Marker In SelScintilla.Markers.GetMarkers(ln)
                If SelScintilla.Markers.GetMarkerMask(ln) <> 0 Then
                    toCut &= ln.Text
                    ln.Text = ""
                End If
            Next
        Next
        System.Windows.Forms.Clipboard.SetText(toCut)
    End Sub

    Private Sub CopyBookmarkedLinesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyBookmarkedLinesToolStripMenuItem.Click
        'Loop through each line, if it is bookmarked, then add it to a list of lines to be coppied, and set the clipboard text to the lines
        Dim toCopy As String = ""
        For Each ln As Line In SelScintilla.Lines
            For Each Marker In SelScintilla.Markers.GetMarkers(ln)
                If SelScintilla.Markers.GetMarkerMask(ln) <> 0 Then
                    toCopy &= ln.Text
                End If
            Next
        Next
        System.Windows.Forms.Clipboard.SetText(toCopy)
    End Sub

    Private Sub RemoveAllBookmarksToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem.Click
        'Loop through each line, if it is bookmarked, the remove the bookmark.
        For Each ln As Line In SelScintilla.Lines
            For Each Marker In SelScintilla.Markers.GetMarkers(ln)
                If SelScintilla.Markers.GetMarkerMask(ln) <> 0 Then
                    ln.DeleteMarker(0)
                End If
            Next
        Next
    End Sub
    Private Sub ShowBookmarkMarginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowBookmarkMarginToolStripMenuItem.Click
        On Error Resume Next
        For Each tb In tcMain.Controls(2).Controls
            If ShowBookmarkMarginToolStripMenuItem.Checked = True Then
                With CType(tb.Controls(0), ScintillaEx)
                    .Margins.Margin1.Width = 20
                    .Margins.Margin1.IsMarkerMargin = True
                    .Margins.Margin1.IsClickable = True
                    .Margins.Margin1.AutoToggleMarkerNumber = True
                End With
            Else
                With CType(tb.Controls(0), ScintillaEx)
                    .Margins.Margin1.Width = 0
                End With

            End If
        Next
    End Sub
#End Region
#End Region
#Region "Macro menuitem"
    Private Sub StartRecordingToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles StartRecordingToolStripMenuItem.Click
        Macro = ""
        MacroRecording = True
    End Sub

    Private Sub StopRecordingToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles StopRecordingToolStripMenuItem.Click
        Macro = Macro.Replace("16.16.", "16.")
        Macro = Macro.Replace("16.16.", "16.")
        MacroRecording = False
ib:
        Dim ib As String = InputBox("Please enter a title for your macro!", "Macro Title")
        If ib <> "" Then
            Try
                IO.File.WriteAllText(Application.StartupPath & "\Runtime\Macros\" & ib & ".npm", Macro)
            Catch ex As Exception
                MessageBox.Show("Could not save macro, the error returned was: " & ex.Message)
            End Try
        Else
            GoTo ib

        End If

        LoadMacros()
    End Sub

    Private Sub MacroManagerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MacroManagerToolStripMenuItem.Click
        frmMacroManager.ShowDialog()
    End Sub
#End Region
#Region "Encoding Menustrip Item"
    'Change the encoding in the textbox. Simple stuff.
    Private Sub EncodeInANSIToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EncodeInANSIToolStripMenuItem.Click
        SelScintilla.Encoding = System.Text.Encoding.Unicode
    End Sub

    Private Sub UTF8ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UTF8ToolStripMenuItem.Click
        SelScintilla.Encoding = System.Text.Encoding.UTF8
    End Sub

    Private Sub ASCIIToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ASCIIToolStripMenuItem.Click
        SelScintilla.Encoding = System.Text.Encoding.ASCII
    End Sub
#End Region
#Region "Syntax Highlighting Menustrip Item"

    Private Sub PerformHighlighting()
        For Each itm As ToolStripMenuItem In SyntaxHighlightingToolStripMenuItem.DropDownItems
            itm.Checked = False
        Next
        SelScintilla.Folding.IsEnabled = True
        SelScintilla.Margins.Margin2.Width = 20
    End Sub

    Private Sub CustomfromFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomfromFileToolStripMenuItem.Click
        Dim ofd As New OpenFileDialog
        ofd.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*"
        ofd.Title = "Select file..."
        If ofd.ShowDialog = DialogResult.OK Then
            SelScintilla.ConfigurationManager.CustomLocation = ofd.FileName
            SelScintilla.ConfigurationManager.Language = Interaction.InputBox("Please enter the language name:", "Language Name", "...")
            PerformHighlighting()
            SelScintilla.ConfigurationManager.CustomLocation = ofd.FileName
            CustomfromFileToolStripMenuItem.Checked = True
        End If

    End Sub
    Private Sub ExpandAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpandAllToolStripMenuItem.Click
        SelScintilla.NativeInterface.Colourise(0, -1)
        For Each l As Line In SelScintilla.Lines
            If l.IsFoldPoint AndAlso Not l.FoldExpanded Then
                SelScintilla.NativeInterface.ToggleFold(l.Number)
            End If
        Next
    End Sub

    Private Sub CollapseAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CollapseAllToolStripMenuItem.Click
        SelScintilla.NativeInterface.Colourise(0, -1)
        For Each l As Line In SelScintilla.Lines
            If l.IsFoldPoint AndAlso l.FoldExpanded Then
                SelScintilla.NativeInterface.ToggleFold(l.Number)
            End If
        Next
    End Sub
#End Region
#Region "Help Menustrip Item"
    Private Sub SendFeedbackToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendFeedbackToolStripMenuItem.Click
        MessageBox.Show("Please send any feebdack and/or bug reports to Jack Eagles1 on Hackforums or DreamInCode.", "Feedback", MessageBoxButtons.OK)
    End Sub
    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        frmAbout.ShowDialog()
    End Sub

    Private Sub TipsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TipsToolStripMenuItem.Click
        frmTips.ShowDialog()
    End Sub

    Private Sub CheckForUpdatesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CheckForUpdatesToolStripMenuItem.Click
        frmUpdater.ShowDialog()
    End Sub

#End Region
#Region "Zoom menuitem"
    Private Sub ZoomInToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZoomInToolStripMenuItem.Click
        SelScintilla.Zoom += 1
    End Sub

    Private Sub ZoomOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZoomOutToolStripMenuItem.Click
        SelScintilla.Zoom -= 1
    End Sub

    Private Sub ResetZoomToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetZoomToolStripMenuItem.Click
        SelScintilla.Zoom = 0
    End Sub
#End Region
#Region "TabControl Events"

    Private Sub EnableDisableItems(ByVal Enable As Boolean)
        SaveToolStripMenuItem.Enabled = Enable
        SaveAsToolStripMenuItem.Enabled = Enable
        ExportToHTMLToolStripMenuItem.Enabled = Enable
        CloseToolStripMenuItem.Enabled = Enable

        EncryptAndCloseSelectedToolStripMenuItem.Enabled = Enable
        ShareToolStripMenuItem.Enabled = Enable
        PrintPreviewToolStripMenuItem.Enabled = Enable
        PrintToolStripMenuItem.Enabled = Enable
        For Each itm In EditToolStripMenuItem.DropDownItems
            itm.Enabled = Enable
        Next
        For Each itm In InsertToolStripMenuItem.DropDownItems
            itm.Enabled = Enable
        Next
        For Each itm In AddonsToolStripMenuItem.DropDownItems
            itm.Enabled = Enable
        Next
        For Each itm In FormatToolStripMenuItem.DropDownItems
            itm.Enabled = Enable
        Next
        For Each itm In ViewToolStripMenuItem.DropDownItems
            itm.Enabled = Enable
        Next
        For Each itm In MacroToolStripMenuItem.DropDownItems
            itm.Enabled = Enable
        Next
        For Each itm In EncodingToolStripMenuItem.DropDownItems
            itm.Enabled = Enable
        Next
        For Each itm In ZoomToolStripMenuItem.DropDownItems
            itm.Enabled = Enable
        Next
        SyntaxHighlightingToolStripMenuItem.Enabled = Enable
        RunToolStripMenuItem.Enabled = Enable
        cmuTab.Enabled = Enable
        msToolbar.Enabled = Enable
        msInfo.Enabled = Enable
        GetAddonsToolStripMenuItem.Enabled = True
        tmrWordCount.Stop()
    End Sub

    Private Sub tcMain_SelectedTabChanged(sender As Object, e As System.EventArgs) Handles tcMain.SelectedTabChanged
        If CType(tcMain.SelectedForm, Form).Text = "Start Page" Then
            EnableDisableItems(False)
        ElseIf tcMain.SelectedForm.AccessibleDescription = "SCINFORM" Then
      EnableDisableItems(True)
            'Set "SelScintilla" to the currently selected scintilla, meaning we don't have to use a CType each time we refer to it
            SelScintilla = CType(tcMain.SelectedForm.Controls.Item(0), ScintillaEx)
            'Focus the selected scintilla for convenience
            SelScintilla.Focus()
            'Stop any auto save process from happening for the previously selected document. Auto save will re-start for the current document when the user starts typing.
            tmrExpireAutoSave.Stop()
            tmrTypingAutoSave.Stop()
            'Used for the word count
            mHwnd = SelScintilla.Handle
            'Update the info label
            lblInfo.Text = tcMain.SelectedForm.Text


            If DocumentTitleBar = True Then
                Me.Text = "NeoIDE - " & tcMain.SelectedForm.Text
            End If

            'tsCompiler.Visible = SelScintilla.CompilerShowMenu
        End If

    End Sub
#End Region

    'Run menuitem
    Private Sub EditToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem1.Click
        frmRunEditor.ShowDialog()
    End Sub

    'Addons menuitem
    Private Sub GetAddonsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GetAddonsToolStripMenuItem.Click
        frmGetExtensions.ShowDialog()
    End Sub

#Region "Toolbar"
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCustomize.Click
        frmSelector.ShowDialog()
    End Sub


    Public Shared Sub resetStrip()
        ' reset the blend to default
        Dim blend As New Drawing2D.Blend()
        blend.Positions = New Single() {0.0F, 0.4F, 0.5F, 0.8F, 1.0F}
        blend.Factors = New Single() {0.0F, 0.2F, 0.5F, 1.0F, 0.6F}
        With frmMain
            ._vtExtender.ToolStripGradientBlend = blend
            ._vtExtender.StatusStripGradientBlend = blend
            ._vtExtender.MenuStripGradientBlend = blend
            ' reset menu color scheme
            ._vtExtender.MenuBackGroundColor = Color.FromArgb(255, &HF5, &HF5, &HF5)
            ._vtExtender.MenuForeColor = Color.DarkGray
            ._vtExtender.MenuFocusedForeColor = Color.Black
            ._vtExtender.MenuImageMarginGradientBegin = Color.FromArgb(255, &HF5, &HF5, &HF5)
            ._vtExtender.MenuImageMarginGradientEnd = Color.FromArgb(255, &HF5, &HF5, &HF5)
            ._vtExtender.MenuItemForeColor = Color.DarkGray
            ._vtExtender.MenuItemFocusedForeColor = Color.Black
            ._vtExtender.MenuStyle = MenuType.Vista
            ' reset button styles
            ._vtExtender.ButtonBorderColor = Color.DarkGray
            ._vtExtender.ButtonGradientBegin = Color.Silver
            ._vtExtender.ButtonGradientEnd = Color.Black
            ._vtExtender.ButtonForeColor = Color.Black
            ._vtExtender.ButtonFocusedForeColor = Color.CornflowerBlue
        End With
    End Sub
#End Region

    Private Sub btnCloseCompiler_Click(sender As System.Object, e As System.EventArgs) Handles btnCloseCompiler.Click
        tsCompiler.Hide()
    End Sub

#Region "Tab Events"
#Region "Tab Previews"
    Dim ourPB As New PictureBox
    Private Sub TabMouseEnter(sender As Object, e As System.EventArgs)
        Dim ctrl As Control = CType(sender, Control)
        Dim frm As Form = CType(sender.Form, Form)
        Dim thaBm As New Bitmap(frm.Width, frm.Height)
        CType(sender.Form, Form).DrawToBitmap(thaBm, New Rectangle(0, 0, frm.Width, frm.Height))
        ourPB.Image = thaBm
        '   ourPB.SizeMode = PictureBoxSizeMode.StretchImage
        ourPB.Size = New Size(ctrl.Width + 120, 200)
        Dim totHeight As Integer
        If tsCompiler.Visible = True Then
            totHeight += tsCompiler.Height
        Else
            totHeight += msMain.Height + msToolbar.Height
        End If
        ourPB.Location = New Point(ctrl.Location.X, totHeight + ctrl.Height + 8)
        ourPB.Visible = True
        Me.Controls.Add(ourPB)
        ourPB.BringToFront()
        ourPB.BorderStyle = BorderStyle.None
        AddHandler ourPB.Paint, AddressOf TabPreviewPictureBox_Paint
    End Sub
    Private Sub TabMouseLeave(sender As Object, e As System.EventArgs)
        ourPB.Hide()
    End Sub

    Private Sub TabPreviewPictureBox_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs)
        ControlPaint.DrawBorder(e.Graphics, sender.DisplayRectangle, Color.Red, 3, ButtonBorderStyle.Outset, Color.Red, 3, ButtonBorderStyle.Outset, Color.Red, 3, ButtonBorderStyle.Outset, Color.Red, 3, ButtonBorderStyle.Outset)
    End Sub
#End Region
#Region "Tab ContextMenu"
    Private Sub cmuTab_Opening(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles cmuTab.Opening
        If SelScintilla.SavePath <> "" Then
            ShowFileInExplorerToolStripMenuItem.Enabled = True
        Else
            ShowFileInExplorerToolStripMenuItem.Enabled = False
        End If
    End Sub
    Dim ContextScin As ScintillaEx
    Sub TabMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim x As New ContextMenuStrip
            Dim t As ToolStripItem = x.Items.Add("Show file in Explorer", Nothing, AddressOf Closeit)
            ContextScin = CType(CType(sender.Form, Form).Controls(0), ScintillaEx)
            If ContextScin.SavePath <> "" Then
                t.Enabled = True
            Else
                t.Enabled = False
            End If
            t.Tag = sender
            x.Show(sender, e.Location)
        ElseIf e.Button = Windows.Forms.MouseButtons.Middle Then
            sender.Form.Close()
        End If
    End Sub

    Sub Closeit(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Microsoft.VisualBasic.Shell("explorer /e,/select," & ContextScin.SavePath, AppWinStyle.NormalFocus)
        Catch ex As Exception
        End Try
    End Sub
#End Region
#End Region
#Region "Find Bar"
    Private Sub ToolStripButton1_Click_1(sender As System.Object, e As System.EventArgs) Handles btnFindNext.Click
        findNext()
    End Sub

    Private Sub QuickFindToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles QuickFindToolStripMenuItem.Click
        tsFind.Visible = True
        txtFind.Focus()
    End Sub

    Private Sub btnFindPrevious_Click(sender As System.Object, e As System.EventArgs) Handles btnFindPrevious.Click
        findPrevious()
    End Sub

    Private Sub txtFind_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtFind.KeyDown
        Select Case e.KeyCode
            Case Keys.Up
                findPrevious()
                e.Handled = True
                Return
            Case Keys.Down, Keys.Return
                findNext()
                e.Handled = True
                Return
        End Select
    End Sub
    Private Sub btnCloseFindBar_Click(sender As System.Object, e As System.EventArgs) Handles btnCloseFindBar.Click
        tsFind.Hide()
    End Sub

    Private Sub findNext()
        If ((txtFind.Text <> String.Empty) AndAlso (Not SelScintilla Is Nothing)) Then
            Dim range As Range = SelScintilla.FindReplace.FindNext(txtFind.Text, True, SelScintilla.FindReplace.Window.GetSearchFlags)
            If (Not range Is Nothing) Then
                range.Select()
            End If
            moveFormAwayFromSelection()
        End If
    End Sub

    Private Sub findPrevious()
        If ((txtFind.Text <> String.Empty) AndAlso (Not SelScintilla Is Nothing)) Then
            Dim range As Range = SelScintilla.FindReplace.FindPrevious(txtFind.Text, True, SelScintilla.FindReplace.Window.GetSearchFlags)
            If (Not range Is Nothing) Then
                range.Select()
            End If
            moveFormAwayFromSelection()
        End If
    End Sub

    Public Sub moveFormAwayFromSelection()
        If (MyBase.Visible AndAlso (Not SelScintilla Is Nothing)) Then
            Dim position As Integer = SelScintilla.Caret.Position
            Dim x As Integer = SelScintilla.PointXFromPosition(position)
            Dim y As Integer = SelScintilla.PointYFromPosition(position)
            Dim pt As New Point(x, y)
            Dim rectangle As New Rectangle(MyBase.Location, MyBase.Size)
            If rectangle.Contains(pt) Then
                Dim point2 As Point
                If (pt.Y < (Screen.PrimaryScreen.Bounds.Height / 2)) Then
                    point2 = New Point(MyBase.Location.X, (pt.Y + (SelScintilla.Lines.Current.Height * 2)))
                Else
                    point2 = New Point(MyBase.Location.X, ((pt.Y - MyBase.Height) - (SelScintilla.Lines.Current.Height * 2)))
                End If
                MyBase.Location = point2
            End If
        End If
    End Sub

    Private Sub txtFind_TextChanged(sender As Object, e As System.EventArgs) Handles txtFind.TextChanged
        txtFind.BackColor = SystemColors.Window
        If ((txtFind.Text <> String.Empty) AndAlso (Not SelScintilla Is Nothing)) Then
            Dim startPos As Integer = Math.Min(SelScintilla.Caret.Position, SelScintilla.Caret.Anchor)
            Dim range As Range = SelScintilla.FindReplace.Find(startPos, SelScintilla.TextLength, txtFind.Text, SelScintilla.FindReplace.Window.GetSearchFlags)
            If (range Is Nothing) Then
                range = SelScintilla.FindReplace.Find(0, startPos, txtFind.Text, SelScintilla.FindReplace.Window.GetSearchFlags)
            End If
            If (Not range Is Nothing) Then
                range.Select()
            Else
                txtFind.BackColor = Color.Tomato
            End If
            moveFormAwayFromSelection()
        End If
    End Sub

    Private Sub btnFindHighlightAll_Click(sender As System.Object, e As System.EventArgs) Handles btnFindHighlightAll.Click
        If ((txtFind.Text <> String.Empty) AndAlso (Not SelScintilla Is Nothing)) Then
            HighlightAll(SelScintilla.FindReplace.FindAll(txtFind.Text))
        End If
    End Sub

    Public Sub HighlightAll(ByVal foundRanges As IList(Of Range))
        Dim range As Range
        For Each range In foundRanges
            range.SetIndicator(SelScintilla.FindReplace.Indicator.Number)
        Next
    End Sub
#End Region

    Private Sub frmMain_GotFocus(sender As Object, e As System.EventArgs) Handles Me.GotFocus
        If tcMain.SelectedForm.AccessibleDescription = "SCINFORM" Then
            SelScintilla.CheckForFileMods()
        End If
    End Sub

#Region "Scintilla ContextMenu"
    Private Sub BookmarkToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BookmarkToolStripMenuItem.Click
        AddBookmarkToolStripMenuItem.PerformClick()
    End Sub

    Private Sub PasteToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles PasteToolStripMenuItem1.Click
        PasteToolStripMenuItem.PerformClick()
    End Sub

    Private Sub CopyToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles CopyToolStripMenuItem1.Click
        CopyToolStripMenuItem.PerformClick()
    End Sub

    Private Sub CutToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles CutToolStripMenuItem1.Click
        CutToolStripMenuItem.PerformClick()
    End Sub

    Private Sub CommentToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CommentToolStripMenuItem.Click

    End Sub
#End Region


    Private Sub FileToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FileToolStripMenuItem.Click

    End Sub

    Private Sub FileToolStripMenuItem_DropDownOpening(sender As Object, e As System.EventArgs) Handles FileToolStripMenuItem.DropDownOpening
        If SelScintilla.Text.StartsWith("PROGPADENCRYPT:") Then
            EncryptAndCloseSelectedToolStripMenuItem.Text = "Decrypt Selected"
        Else
            EncryptAndCloseSelectedToolStripMenuItem.Text = "Encrypt Selected"
        End If
    End Sub

    Private Sub tcMain_Load(sender As System.Object, e As System.EventArgs) Handles tcMain.Load

    End Sub
End Class
#Region "Custom Controls"
Public Class BookmarkItem
    Inherits ToolStripMenuItem

    Private Sub BookarkItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        frmMain.SelScintilla.GoTo.Line(Me.Text.Substring(Me.Text.LastIndexOf(" - ")).Replace(" - ", "") - 1)
    End Sub
End Class

Public Class RunItem
    Inherits ToolStripMenuItem

    Private Sub RunItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        If frmMain.SelScintilla.SavePath = "" Then
            Dim mbres As DialogResult = MsgBox("Error - the selected document has not been saved. Save now?", MsgBoxStyle.YesNo, "Error")
            If mbres = DialogResult.Yes Then
                If frmMain.SaveDocument(frmMain.SelScintilla, "", frmMain.tcMain.TabPages.SelectedTab) = True Then
                    GoTo run
                Else
                    Exit Sub
                End If
            End If
        ElseIf frmMain.SelScintilla.WasTextChanged = True Then
            Dim mbres As DialogResult = MsgBox("Error - the selected document has not been saved. Save now?", MsgBoxStyle.YesNo, "Error")
            If mbres = DialogResult.Yes Then
                If frmMain.SaveDocument(frmMain.SelScintilla, frmMain.SelScintilla.SavePath, frmMain.tcMain.TabPages.SelectedTab) = True Then
                    GoTo run
                Else
                    Exit Sub
                End If
            End If
        Else
run:
            Me.Tag = Me.Tag.ToString.Replace("%ProgramFiles%", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles))
            Me.Tag = Me.Tag.ToString.Replace("%Windows%", Environment.GetFolderPath(Environment.SpecialFolder.System).Replace("\System32", ""))

            Try
                Process.Start(Me.Tag, """" & frmMain.SelScintilla.SavePath & """")
            Catch
                Process.Start(Me.Tag.ToString.ToLower.Replace("\Program Files (x86)\", "\Program Files\"), """" & frmMain.SelScintilla.SavePath & """")
            End Try
        End If
    End Sub
End Class

Public Class LexerItem
    Inherits ToolStripMenuItem
    Private Sub LexerItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        Dim rdr As New XmlDocument
        rdr.Load(Application.StartupPath & "\Custom Lexers\" & Me.Text & ".xml")
        For Each itm As XmlNode In rdr.ChildNodes
            If itm.OuterXml.Contains("Language Name=") Then
                Dim lastpart As String = itm.OuterXml
                lastpart = lastpart.Replace("<ScintillaNET>", "").Replace("<Language Name=", "")
                Dim langname As String = lastpart.Substring(1, 8)
                langname = langname.Replace(langname.Substring(langname.LastIndexOf("""")), "")
                frmMain.SelScintilla.Font = Nothing
                frmMain.SelScintilla.ForeColor = Nothing
                frmMain.SelScintilla.ConfigurationManager.CustomLocation = Me.Tag
                frmMain.SelScintilla.ConfigurationManager.Language = langname

                frmMain.SelScintilla.Margins.Margin3.IsClickable = True
                frmMain.SelScintilla.Margins.Margin3.IsFoldMargin = True
                frmMain.SelScintilla.Margins.Margin3.Width = 20
                frmMain.SelScintilla.Folding.UseCompactFolding = True
                frmMain.SelScintilla.Folding.IsEnabled = True
                frmMain.SelScintilla.ConfigurationManager.Configure()
                frmMain.SelScintilla.Update()

            End If
        Next


    End Sub
End Class

Public Class CodeBlockItem
    Inherits ToolStripMenuItem
    Private Sub CodeBlockItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        Dim loadf As New IO.StreamReader(Application.StartupPath & "\Runtime\Code Blocks\" & Me.Text & ".npcb")
        frmMain.SelScintilla.Selection.Text &= loadf.ReadToEnd
        loadf.Close()
        loadf.Dispose()
    End Sub
End Class

Public Class ToolBarCloneItem
    Inherits ToolStripMenuItem

    Private Sub ToolBarCloneItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        Try
            For Each itm As ToolStripMenuItem In frmMain.msMain.Items
                For Each subItm In itm.DropDownItems
                    If Me.ToolTipText = subItm.Text Then
                        CType(subItm, ToolStripMenuItem).PerformClick()
                    End If
                Next
            Next
        Catch
        End Try
    End Sub
End Class

Public Class RecentItem
    Inherits ToolStripMenuItem

    Private Sub ToolBarCloneItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        frmMain.CreateNewDoc(Me.Text)
    End Sub
End Class

Public Class MacroItem
    Inherits ToolStripMenuItem

    Private Declare Sub keybd_event Lib "user32" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Integer, ByVal dwExtraInfo As Integer)
    Private Const VK_CAPITAL As Integer = &H14
    Private Const KEYEVENTF_EXTENDEDKEY As Integer = &H1
    Private Const KEYEVENTF_KEYUP As Integer = &H2

    <DllImport("User32.dll")> _
    Public Shared Function ToAscii(ByVal uVirtKey As Integer, ByVal uScanCode As Integer, ByVal lpbKeyState As Byte(), ByVal lpChar As Byte(), ByVal uFlags As Integer) As Integer
    End Function

    <DllImport("User32.dll")> _
    Public Shared Function GetKeyboardState(ByVal pbKeyState As Byte()) As Integer
    End Function

    Public Shared Function GetAsciiCharacter(ByVal uVirtKey As Integer) As Char
        Dim lpKeyState As Byte() = New Byte(255) {}
        GetKeyboardState(lpKeyState)
        Dim lpChar As Byte() = New Byte(1) {}
        If ToAscii(uVirtKey, 0, lpKeyState, lpChar, 0) = 1 Then
            Return Convert.ToChar((lpChar(0)))
        Else
            Return New Char()
        End If
    End Function


    Private Sub BookarkItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        Try
            If Control.IsKeyLocked(Keys.CapsLock) Then
                Call keybd_event(System.Windows.Forms.Keys.CapsLock, &H14, 1, 0)
                Call keybd_event(System.Windows.Forms.Keys.CapsLock, &H14, 3, 0)
                Application.DoEvents()
                Threading.Thread.Sleep(100)
            End If
            Dim EditableMac As String
            Try
                EditableMac = IO.File.ReadAllText(Me.ToolTipText)
            Catch ex As Exception
                MessageBox.Show("The macro contents could not be loaded. The error returned was: " & ex.Message)
                Exit Sub
            End Try

            For i = 0 To EditableMac.Split(".").Count - 1
                Dim itm As String = EditableMac.Split(".")(i)
                frmMain.SelScintilla.Select()
                If IsNumeric(itm.Replace(".", "")) Then
                    If itm = 38 Then
                        SendKeys.Send("{UP}")
                    ElseIf itm = 40 Then
                        SendKeys.Send("{DOWN}")
                    ElseIf itm = 37 Then
                        SendKeys.Send("{LEFT}")
                    ElseIf itm = 39 Then
                        SendKeys.Send("{RIGHT}")
                    ElseIf itm = 34 Then
                        SendKeys.Send("{PGDN}")
                    ElseIf itm = 33 Then
                        SendKeys.Send("{PGUP}")
                    ElseIf itm = 16 Then
                        If i <> EditableMac.Split(".").Count - 1 Then
                            Dim NextChar As String = EditableMac.Split(".")(i + 1)
                            SendKeys.Send("+" & GetAsciiCharacter(NextChar.Replace(".", "")))
                            i += 1
                        End If
                    ElseIf itm = 17 Then
                        If i <> EditableMac.Split(".").Count - 1 Then
                            Dim NextChar As String = EditableMac.Split(".")(i + 1)
                            SendKeys.Send("^" & GetAsciiCharacter(NextChar.Replace(".", "")))
                            i += 1
                        End If
                    Else
                        SendKeys.Send(GetAsciiCharacter(itm.Replace(".", "")))
                    End If
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("There was an error running the macro. The error returned was: " & ex.Message)
            Exit Sub
        End Try
    End Sub
End Class
#End Region
