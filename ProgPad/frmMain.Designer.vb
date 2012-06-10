<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.msInfo = New System.Windows.Forms.StatusStrip()
        Me.lblTextLength = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblColumn = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblLineCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.bwWordCount = New System.ComponentModel.BackgroundWorker()
        Me.tmrWordCount = New System.Windows.Forms.Timer(Me.components)
        Me.tmrTypingAutoSave = New System.Windows.Forms.Timer(Me.components)
        Me.tmrExpireAutoSave = New System.Windows.Forms.Timer(Me.components)
        Me.bwAutoSave = New System.ComponentModel.BackgroundWorker()
        Me.msToolbar = New System.Windows.Forms.ToolStrip()
        Me.tsbCustomize = New System.Windows.Forms.ToolStripButton()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearRecentItemsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToHTMLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EncryptAndCloseSelectedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShareToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ThisDocumentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LocalhostrToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FTPServerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FacebookToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MultipleDocumentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.localhostrToolStripMenuItemMultiple = New System.Windows.Forms.ToolStripMenuItem()
        Me.FTPServerToolStripMenuItemMultiple = New System.Windows.Forms.ToolStripMenuItem()
        Me.FacebookToolStripMenuItemMultiple = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintPreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UndoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RedoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.QuickFindToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FindToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FindInFilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReplaceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GotoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.SelectedTextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReverseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeToUPPERCASEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeToLOWERCASEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeToSentenceCaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InvertCaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CapitalizeFirstLetterOfEachWordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InsertToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DateTimeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SymbolToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CodeBlocksToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CodeBlockEditorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WindowsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HTMLSidebarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProjectSidebarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TopMostToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FullScreenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowEolToolstripmenuitem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowSpaceMarkersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompilerToolbarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LineHighlightingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowLineHighlightingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BookmarkingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowBookmarkMarginToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddBookmarkToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BookmarkManagerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NoneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CutBookmarkedLinesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyBookmarkedLinesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveAllBookmarksToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfigurationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FormatToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FontToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TextColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WordWrapToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RunToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EncodingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EncodeInANSIToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UTF8ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ASCIIToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SyntaxHighlightingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomfromFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CodeFoldingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExpandAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CollapseAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckForUpdatesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SendFeedbackToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TipsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.XToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZoomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZoomInToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZoomOutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetZoomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.msMain = New System.Windows.Forms.MenuStrip()
        Me.MacroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StartRecordingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StopRecordingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MacrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NoneToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MacroManagerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddonsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GetAddonsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ilTabControlImages = New System.Windows.Forms.ImageList(Me.components)
        Me.tsFind = New System.Windows.Forms.ToolStrip()
        Me.txtFind = New System.Windows.Forms.ToolStripTextBox()
        Me.btnCloseFindBar = New System.Windows.Forms.ToolStripButton()
        Me.btnFindNext = New System.Windows.Forms.ToolStripButton()
        Me.btnFindPrevious = New System.Windows.Forms.ToolStripButton()
        Me.btnFindHighlightAll = New System.Windows.Forms.ToolStripButton()
        Me.tsCompiler = New System.Windows.Forms.ToolStrip()
        Me.btnRunCode = New System.Windows.Forms.ToolStripButton()
        Me.btnCompilerNetFramework = New System.Windows.Forms.ToolStripDropDownButton()
        Me.Framework20ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Framework30ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Framework35ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Framework40ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAssemblyOptions = New System.Windows.Forms.ToolStripButton()
        Me.btnCloseCompiler = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripDropDownButton2 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnyCPUToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItaniumToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tcMain = New CustomTabControl.TabControl()
        Me.cmuTab = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowFileInExplorerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmuScintilla = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CutToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.InsertToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ThisLineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BookmarkToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CommentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.msInfo.SuspendLayout()
        Me.msToolbar.SuspendLayout()
        Me.msMain.SuspendLayout()
        Me.tsFind.SuspendLayout()
        Me.tsCompiler.SuspendLayout()
        Me.cmuTab.SuspendLayout()
        Me.cmuScintilla.SuspendLayout()
        Me.SuspendLayout()
        '
        'msInfo
        '
        Me.msInfo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblTextLength, Me.lblColumn, Me.lblLineCount, Me.lblInfo})
        Me.msInfo.Location = New System.Drawing.Point(0, 477)
        Me.msInfo.Name = "msInfo"
        Me.msInfo.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.msInfo.Size = New System.Drawing.Size(839, 22)
        Me.msInfo.TabIndex = 0
        Me.msInfo.Text = "ToolStrip1"
        '
        'lblTextLength
        '
        Me.lblTextLength.Name = "lblTextLength"
        Me.lblTextLength.Size = New System.Drawing.Size(50, 17)
        Me.lblTextLength.Text = "Length: "
        '
        'lblColumn
        '
        Me.lblColumn.Name = "lblColumn"
        Me.lblColumn.Size = New System.Drawing.Size(28, 17)
        Me.lblColumn.Text = "Col:"
        '
        'lblLineCount
        '
        Me.lblLineCount.Name = "lblLineCount"
        Me.lblLineCount.Size = New System.Drawing.Size(71, 17)
        Me.lblLineCount.Text = "Line Count: "
        '
        'lblInfo
        '
        Me.lblInfo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.RightToLeftAutoMirrorImage = True
        Me.lblInfo.Size = New System.Drawing.Size(675, 17)
        Me.lblInfo.Spring = True
        Me.lblInfo.Text = "Ready"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'bwWordCount
        '
        '
        'tmrWordCount
        '
        Me.tmrWordCount.Interval = 1
        '
        'tmrTypingAutoSave
        '
        Me.tmrTypingAutoSave.Interval = 20000
        '
        'tmrExpireAutoSave
        '
        Me.tmrExpireAutoSave.Interval = 120000
        '
        'bwAutoSave
        '
        '
        'msToolbar
        '
        Me.msToolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.msToolbar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbCustomize})
        Me.msToolbar.Location = New System.Drawing.Point(0, 24)
        Me.msToolbar.Name = "msToolbar"
        Me.msToolbar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.msToolbar.Size = New System.Drawing.Size(839, 25)
        Me.msToolbar.TabIndex = 3
        Me.msToolbar.Text = "ToolStrip1"
        '
        'tsbCustomize
        '
        Me.tsbCustomize.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCustomize.Name = "tsbCustomize"
        Me.tsbCustomize.Size = New System.Drawing.Size(23, 22)
        Me.tsbCustomize.ToolTipText = "Customize"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.NewProjectToolStripMenuItem, Me.OpenToolStripMenuItem, Me.RecentToolStripMenuItem, Me.ToolStripSeparator4, Me.SaveToolStripMenuItem, Me.SaveAsToolStripMenuItem, Me.ExportToHTMLToolStripMenuItem, Me.ToolStripSeparator6, Me.CloseToolStripMenuItem, Me.EncryptAndCloseSelectedToolStripMenuItem, Me.ShareToolStripMenuItem, Me.ToolStripSeparator7, Me.PrintPreviewToolStripMenuItem, Me.PrintToolStripMenuItem, Me.ToolStripSeparator5, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.ShortcutKeyDisplayString = ""
        Me.NewToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'NewProjectToolStripMenuItem
        '
        Me.NewProjectToolStripMenuItem.Name = "NewProjectToolStripMenuItem"
        Me.NewProjectToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewProjectToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.NewProjectToolStripMenuItem.Text = "New Project"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.OpenToolStripMenuItem.Text = "Open"
        '
        'RecentToolStripMenuItem
        '
        Me.RecentToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearRecentItemsToolStripMenuItem})
        Me.RecentToolStripMenuItem.Name = "RecentToolStripMenuItem"
        Me.RecentToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.RecentToolStripMenuItem.Text = "Recent"
        '
        'ClearRecentItemsToolStripMenuItem
        '
        Me.ClearRecentItemsToolStripMenuItem.Name = "ClearRecentItemsToolStripMenuItem"
        Me.ClearRecentItemsToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.ClearRecentItemsToolStripMenuItem.Text = "Clear Recent Items"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(213, 6)
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.SaveAsToolStripMenuItem.Text = "Save As"
        '
        'ExportToHTMLToolStripMenuItem
        '
        Me.ExportToHTMLToolStripMenuItem.Name = "ExportToHTMLToolStripMenuItem"
        Me.ExportToHTMLToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.ExportToHTMLToolStripMenuItem.Text = "Export to HTML"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(213, 6)
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.CloseToolStripMenuItem.Text = "Close Selected"
        '
        'EncryptAndCloseSelectedToolStripMenuItem
        '
        Me.EncryptAndCloseSelectedToolStripMenuItem.Name = "EncryptAndCloseSelectedToolStripMenuItem"
        Me.EncryptAndCloseSelectedToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.EncryptAndCloseSelectedToolStripMenuItem.Text = "Encrypt Selected"
        '
        'ShareToolStripMenuItem
        '
        Me.ShareToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ThisDocumentToolStripMenuItem, Me.MultipleDocumentsToolStripMenuItem})
        Me.ShareToolStripMenuItem.Name = "ShareToolStripMenuItem"
        Me.ShareToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.ShareToolStripMenuItem.Text = "Share Selected"
        '
        'ThisDocumentToolStripMenuItem
        '
        Me.ThisDocumentToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LocalhostrToolStripMenuItem, Me.FTPServerToolStripMenuItem, Me.FacebookToolStripMenuItem})
        Me.ThisDocumentToolStripMenuItem.Name = "ThisDocumentToolStripMenuItem"
        Me.ThisDocumentToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.ThisDocumentToolStripMenuItem.Text = "This Document"
        '
        'LocalhostrToolStripMenuItem
        '
        Me.LocalhostrToolStripMenuItem.Name = "LocalhostrToolStripMenuItem"
        Me.LocalhostrToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.LocalhostrToolStripMenuItem.Text = "localhostr"
        '
        'FTPServerToolStripMenuItem
        '
        Me.FTPServerToolStripMenuItem.Enabled = False
        Me.FTPServerToolStripMenuItem.Name = "FTPServerToolStripMenuItem"
        Me.FTPServerToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.FTPServerToolStripMenuItem.Text = "FTP Server"
        '
        'FacebookToolStripMenuItem
        '
        Me.FacebookToolStripMenuItem.Enabled = False
        Me.FacebookToolStripMenuItem.Name = "FacebookToolStripMenuItem"
        Me.FacebookToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.FacebookToolStripMenuItem.Text = "Facebook"
        '
        'MultipleDocumentsToolStripMenuItem
        '
        Me.MultipleDocumentsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.localhostrToolStripMenuItemMultiple, Me.FTPServerToolStripMenuItemMultiple, Me.FacebookToolStripMenuItemMultiple})
        Me.MultipleDocumentsToolStripMenuItem.Name = "MultipleDocumentsToolStripMenuItem"
        Me.MultipleDocumentsToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.MultipleDocumentsToolStripMenuItem.Text = "Multiple Documents"
        '
        'localhostrToolStripMenuItemMultiple
        '
        Me.localhostrToolStripMenuItemMultiple.Name = "localhostrToolStripMenuItemMultiple"
        Me.localhostrToolStripMenuItemMultiple.Size = New System.Drawing.Size(129, 22)
        Me.localhostrToolStripMenuItemMultiple.Text = "localhostr"
        '
        'FTPServerToolStripMenuItemMultiple
        '
        Me.FTPServerToolStripMenuItemMultiple.Enabled = False
        Me.FTPServerToolStripMenuItemMultiple.Name = "FTPServerToolStripMenuItemMultiple"
        Me.FTPServerToolStripMenuItemMultiple.Size = New System.Drawing.Size(129, 22)
        Me.FTPServerToolStripMenuItemMultiple.Text = "FTP Server"
        '
        'FacebookToolStripMenuItemMultiple
        '
        Me.FacebookToolStripMenuItemMultiple.Enabled = False
        Me.FacebookToolStripMenuItemMultiple.Name = "FacebookToolStripMenuItemMultiple"
        Me.FacebookToolStripMenuItemMultiple.Size = New System.Drawing.Size(129, 22)
        Me.FacebookToolStripMenuItemMultiple.Text = "Facebook"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(213, 6)
        '
        'PrintPreviewToolStripMenuItem
        '
        Me.PrintPreviewToolStripMenuItem.Name = "PrintPreviewToolStripMenuItem"
        Me.PrintPreviewToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.PrintPreviewToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.PrintPreviewToolStripMenuItem.Text = "Print Preview"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(213, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.ShortcutKeyDisplayString = "Alt+F4"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UndoToolStripMenuItem, Me.RedoToolStripMenuItem, Me.ToolStripSeparator1, Me.PasteToolStripMenuItem, Me.CutToolStripMenuItem, Me.CopyToolStripMenuItem, Me.ToolStripSeparator2, Me.QuickFindToolStripMenuItem, Me.FindToolStripMenuItem, Me.FindInFilesToolStripMenuItem, Me.ReplaceToolStripMenuItem, Me.GotoToolStripMenuItem, Me.ToolStripSeparator3, Me.SelectedTextToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'UndoToolStripMenuItem
        '
        Me.UndoToolStripMenuItem.Name = "UndoToolStripMenuItem"
        Me.UndoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.UndoToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.UndoToolStripMenuItem.Text = "Undo"
        '
        'RedoToolStripMenuItem
        '
        Me.RedoToolStripMenuItem.Name = "RedoToolStripMenuItem"
        Me.RedoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
        Me.RedoToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.RedoToolStripMenuItem.Text = "Redo"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(194, 6)
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.PasteToolStripMenuItem.Text = "Paste"
        '
        'CutToolStripMenuItem
        '
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        Me.CutToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.CutToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.CutToolStripMenuItem.Text = "Cut"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(194, 6)
        '
        'QuickFindToolStripMenuItem
        '
        Me.QuickFindToolStripMenuItem.Name = "QuickFindToolStripMenuItem"
        Me.QuickFindToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.QuickFindToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.QuickFindToolStripMenuItem.Text = "Quick Find"
        '
        'FindToolStripMenuItem
        '
        Me.FindToolStripMenuItem.Name = "FindToolStripMenuItem"
        Me.FindToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.FindToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.FindToolStripMenuItem.Text = "Find"
        '
        'FindInFilesToolStripMenuItem
        '
        Me.FindInFilesToolStripMenuItem.Name = "FindInFilesToolStripMenuItem"
        Me.FindInFilesToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Alt) _
            Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.FindInFilesToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.FindInFilesToolStripMenuItem.Text = "Find in files"
        '
        'ReplaceToolStripMenuItem
        '
        Me.ReplaceToolStripMenuItem.Name = "ReplaceToolStripMenuItem"
        Me.ReplaceToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.ReplaceToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.ReplaceToolStripMenuItem.Text = "Replace"
        '
        'GotoToolStripMenuItem
        '
        Me.GotoToolStripMenuItem.Name = "GotoToolStripMenuItem"
        Me.GotoToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.GotoToolStripMenuItem.Text = "GoTo"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(194, 6)
        '
        'SelectedTextToolStripMenuItem
        '
        Me.SelectedTextToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReverseToolStripMenuItem, Me.ChangeToUPPERCASEToolStripMenuItem, Me.ChangeToLOWERCASEToolStripMenuItem, Me.ChangeToSentenceCaseToolStripMenuItem, Me.InvertCaseToolStripMenuItem, Me.CapitalizeFirstLetterOfEachWordToolStripMenuItem})
        Me.SelectedTextToolStripMenuItem.Name = "SelectedTextToolStripMenuItem"
        Me.SelectedTextToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.SelectedTextToolStripMenuItem.Text = "Selected Text"
        '
        'ReverseToolStripMenuItem
        '
        Me.ReverseToolStripMenuItem.Name = "ReverseToolStripMenuItem"
        Me.ReverseToolStripMenuItem.Size = New System.Drawing.Size(250, 22)
        Me.ReverseToolStripMenuItem.Text = "Reverse"
        '
        'ChangeToUPPERCASEToolStripMenuItem
        '
        Me.ChangeToUPPERCASEToolStripMenuItem.Name = "ChangeToUPPERCASEToolStripMenuItem"
        Me.ChangeToUPPERCASEToolStripMenuItem.Size = New System.Drawing.Size(250, 22)
        Me.ChangeToUPPERCASEToolStripMenuItem.Text = "Change to UPPER CASE"
        '
        'ChangeToLOWERCASEToolStripMenuItem
        '
        Me.ChangeToLOWERCASEToolStripMenuItem.Name = "ChangeToLOWERCASEToolStripMenuItem"
        Me.ChangeToLOWERCASEToolStripMenuItem.Size = New System.Drawing.Size(250, 22)
        Me.ChangeToLOWERCASEToolStripMenuItem.Text = "Change to LOWER CASE"
        '
        'ChangeToSentenceCaseToolStripMenuItem
        '
        Me.ChangeToSentenceCaseToolStripMenuItem.Name = "ChangeToSentenceCaseToolStripMenuItem"
        Me.ChangeToSentenceCaseToolStripMenuItem.Size = New System.Drawing.Size(250, 22)
        Me.ChangeToSentenceCaseToolStripMenuItem.Text = "Change to Sentence case"
        '
        'InvertCaseToolStripMenuItem
        '
        Me.InvertCaseToolStripMenuItem.Name = "InvertCaseToolStripMenuItem"
        Me.InvertCaseToolStripMenuItem.Size = New System.Drawing.Size(250, 22)
        Me.InvertCaseToolStripMenuItem.Text = "Invert Case"
        '
        'CapitalizeFirstLetterOfEachWordToolStripMenuItem
        '
        Me.CapitalizeFirstLetterOfEachWordToolStripMenuItem.Name = "CapitalizeFirstLetterOfEachWordToolStripMenuItem"
        Me.CapitalizeFirstLetterOfEachWordToolStripMenuItem.Size = New System.Drawing.Size(250, 22)
        Me.CapitalizeFirstLetterOfEachWordToolStripMenuItem.Text = "Capitalize first letter of each word"
        '
        'InsertToolStripMenuItem
        '
        Me.InsertToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DateTimeToolStripMenuItem, Me.SymbolToolStripMenuItem, Me.CodeBlocksToolStripMenuItem})
        Me.InsertToolStripMenuItem.Name = "InsertToolStripMenuItem"
        Me.InsertToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.InsertToolStripMenuItem.Text = "Insert"
        '
        'DateTimeToolStripMenuItem
        '
        Me.DateTimeToolStripMenuItem.Name = "DateTimeToolStripMenuItem"
        Me.DateTimeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.DateTimeToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.DateTimeToolStripMenuItem.Text = "Date && Time"
        '
        'SymbolToolStripMenuItem
        '
        Me.SymbolToolStripMenuItem.Name = "SymbolToolStripMenuItem"
        Me.SymbolToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.SymbolToolStripMenuItem.Text = "Symbol"
        '
        'CodeBlocksToolStripMenuItem
        '
        Me.CodeBlocksToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CodeBlockEditorToolStripMenuItem})
        Me.CodeBlocksToolStripMenuItem.Name = "CodeBlocksToolStripMenuItem"
        Me.CodeBlocksToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.CodeBlocksToolStripMenuItem.Text = "Code Blocks"
        '
        'CodeBlockEditorToolStripMenuItem
        '
        Me.CodeBlockEditorToolStripMenuItem.Name = "CodeBlockEditorToolStripMenuItem"
        Me.CodeBlockEditorToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.CodeBlockEditorToolStripMenuItem.Text = "Code Block Editor"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WindowsToolStripMenuItem, Me.TopMostToolStripMenuItem, Me.FullScreenToolStripMenuItem, Me.ShowEolToolstripmenuitem, Me.ShowSpaceMarkersToolStripMenuItem, Me.CompilerToolbarToolStripMenuItem, Me.LineHighlightingToolStripMenuItem, Me.BookmarkingToolStripMenuItem, Me.ConfigurationToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'WindowsToolStripMenuItem
        '
        Me.WindowsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HTMLSidebarToolStripMenuItem, Me.ProjectSidebarToolStripMenuItem})
        Me.WindowsToolStripMenuItem.Name = "WindowsToolStripMenuItem"
        Me.WindowsToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.WindowsToolStripMenuItem.Text = "Windows"
        '
        'HTMLSidebarToolStripMenuItem
        '
        Me.HTMLSidebarToolStripMenuItem.Name = "HTMLSidebarToolStripMenuItem"
        Me.HTMLSidebarToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.HTMLSidebarToolStripMenuItem.Text = "HTML Sidebar"
        '
        'ProjectSidebarToolStripMenuItem
        '
        Me.ProjectSidebarToolStripMenuItem.Name = "ProjectSidebarToolStripMenuItem"
        Me.ProjectSidebarToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.ProjectSidebarToolStripMenuItem.Text = "Project Sidebar"
        '
        'TopMostToolStripMenuItem
        '
        Me.TopMostToolStripMenuItem.CheckOnClick = True
        Me.TopMostToolStripMenuItem.Name = "TopMostToolStripMenuItem"
        Me.TopMostToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.TopMostToolStripMenuItem.Text = "Top Most"
        '
        'FullScreenToolStripMenuItem
        '
        Me.FullScreenToolStripMenuItem.CheckOnClick = True
        Me.FullScreenToolStripMenuItem.Name = "FullScreenToolStripMenuItem"
        Me.FullScreenToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.FullScreenToolStripMenuItem.Text = "Full Screen"
        '
        'ShowEolToolstripmenuitem
        '
        Me.ShowEolToolstripmenuitem.CheckOnClick = True
        Me.ShowEolToolstripmenuitem.Name = "ShowEolToolstripmenuitem"
        Me.ShowEolToolstripmenuitem.Size = New System.Drawing.Size(216, 22)
        Me.ShowEolToolstripmenuitem.Text = "Show EOL"
        '
        'ShowSpaceMarkersToolStripMenuItem
        '
        Me.ShowSpaceMarkersToolStripMenuItem.CheckOnClick = True
        Me.ShowSpaceMarkersToolStripMenuItem.Name = "ShowSpaceMarkersToolStripMenuItem"
        Me.ShowSpaceMarkersToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.ShowSpaceMarkersToolStripMenuItem.Text = "Show White Space markers"
        '
        'CompilerToolbarToolStripMenuItem
        '
        Me.CompilerToolbarToolStripMenuItem.Name = "CompilerToolbarToolStripMenuItem"
        Me.CompilerToolbarToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.CompilerToolbarToolStripMenuItem.Text = "Compiler Toolbar"
        '
        'LineHighlightingToolStripMenuItem
        '
        Me.LineHighlightingToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowLineHighlightingToolStripMenuItem, Me.SelectColorToolStripMenuItem})
        Me.LineHighlightingToolStripMenuItem.Name = "LineHighlightingToolStripMenuItem"
        Me.LineHighlightingToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.LineHighlightingToolStripMenuItem.Text = "Line Highlighting"
        '
        'ShowLineHighlightingToolStripMenuItem
        '
        Me.ShowLineHighlightingToolStripMenuItem.Checked = True
        Me.ShowLineHighlightingToolStripMenuItem.CheckOnClick = True
        Me.ShowLineHighlightingToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ShowLineHighlightingToolStripMenuItem.Name = "ShowLineHighlightingToolStripMenuItem"
        Me.ShowLineHighlightingToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.ShowLineHighlightingToolStripMenuItem.Text = "Show line Highlighting"
        '
        'SelectColorToolStripMenuItem
        '
        Me.SelectColorToolStripMenuItem.Name = "SelectColorToolStripMenuItem"
        Me.SelectColorToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.SelectColorToolStripMenuItem.Text = "Select default Color"
        '
        'BookmarkingToolStripMenuItem
        '
        Me.BookmarkingToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowBookmarkMarginToolStripMenuItem, Me.AddBookmarkToolStripMenuItem, Me.BookmarkManagerToolStripMenuItem, Me.CutBookmarkedLinesToolStripMenuItem, Me.CopyBookmarkedLinesToolStripMenuItem, Me.RemoveAllBookmarksToolStripMenuItem})
        Me.BookmarkingToolStripMenuItem.Name = "BookmarkingToolStripMenuItem"
        Me.BookmarkingToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.BookmarkingToolStripMenuItem.Text = "Bookmarking"
        '
        'ShowBookmarkMarginToolStripMenuItem
        '
        Me.ShowBookmarkMarginToolStripMenuItem.CheckOnClick = True
        Me.ShowBookmarkMarginToolStripMenuItem.Name = "ShowBookmarkMarginToolStripMenuItem"
        Me.ShowBookmarkMarginToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.ShowBookmarkMarginToolStripMenuItem.Text = "Show bookmark margin"
        '
        'AddBookmarkToolStripMenuItem
        '
        Me.AddBookmarkToolStripMenuItem.Name = "AddBookmarkToolStripMenuItem"
        Me.AddBookmarkToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.AddBookmarkToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.AddBookmarkToolStripMenuItem.Text = "Toggle Bookmark"
        '
        'BookmarkManagerToolStripMenuItem
        '
        Me.BookmarkManagerToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NoneToolStripMenuItem})
        Me.BookmarkManagerToolStripMenuItem.Name = "BookmarkManagerToolStripMenuItem"
        Me.BookmarkManagerToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.BookmarkManagerToolStripMenuItem.Text = "Bookmarks"
        '
        'NoneToolStripMenuItem
        '
        Me.NoneToolStripMenuItem.Name = "NoneToolStripMenuItem"
        Me.NoneToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.NoneToolStripMenuItem.Text = "None..."
        '
        'CutBookmarkedLinesToolStripMenuItem
        '
        Me.CutBookmarkedLinesToolStripMenuItem.Name = "CutBookmarkedLinesToolStripMenuItem"
        Me.CutBookmarkedLinesToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.CutBookmarkedLinesToolStripMenuItem.Text = "Cut bookmarked lines"
        '
        'CopyBookmarkedLinesToolStripMenuItem
        '
        Me.CopyBookmarkedLinesToolStripMenuItem.Name = "CopyBookmarkedLinesToolStripMenuItem"
        Me.CopyBookmarkedLinesToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.CopyBookmarkedLinesToolStripMenuItem.Text = "Copy bookmarked lines"
        '
        'RemoveAllBookmarksToolStripMenuItem
        '
        Me.RemoveAllBookmarksToolStripMenuItem.Name = "RemoveAllBookmarksToolStripMenuItem"
        Me.RemoveAllBookmarksToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.RemoveAllBookmarksToolStripMenuItem.Text = "Remove all bookmarks"
        '
        'ConfigurationToolStripMenuItem
        '
        Me.ConfigurationToolStripMenuItem.Name = "ConfigurationToolStripMenuItem"
        Me.ConfigurationToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.ConfigurationToolStripMenuItem.Text = "Configuration"
        '
        'FormatToolStripMenuItem
        '
        Me.FormatToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FontToolStripMenuItem, Me.TextColorToolStripMenuItem, Me.WordWrapToolStripMenuItem})
        Me.FormatToolStripMenuItem.Name = "FormatToolStripMenuItem"
        Me.FormatToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.FormatToolStripMenuItem.Text = "Format"
        '
        'FontToolStripMenuItem
        '
        Me.FontToolStripMenuItem.Name = "FontToolStripMenuItem"
        Me.FontToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.FontToolStripMenuItem.Text = "Font"
        '
        'TextColorToolStripMenuItem
        '
        Me.TextColorToolStripMenuItem.Name = "TextColorToolStripMenuItem"
        Me.TextColorToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.TextColorToolStripMenuItem.Text = "Text Color"
        '
        'WordWrapToolStripMenuItem
        '
        Me.WordWrapToolStripMenuItem.CheckOnClick = True
        Me.WordWrapToolStripMenuItem.Name = "WordWrapToolStripMenuItem"
        Me.WordWrapToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.WordWrapToolStripMenuItem.Text = "Word Wrap"
        '
        'RunToolStripMenuItem
        '
        Me.RunToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem1})
        Me.RunToolStripMenuItem.Name = "RunToolStripMenuItem"
        Me.RunToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.RunToolStripMenuItem.Text = "Run in"
        '
        'EditToolStripMenuItem1
        '
        Me.EditToolStripMenuItem1.Name = "EditToolStripMenuItem1"
        Me.EditToolStripMenuItem1.Size = New System.Drawing.Size(103, 22)
        Me.EditToolStripMenuItem1.Text = "Edit..."
        '
        'EncodingToolStripMenuItem
        '
        Me.EncodingToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EncodeInANSIToolStripMenuItem, Me.UTF8ToolStripMenuItem, Me.ASCIIToolStripMenuItem})
        Me.EncodingToolStripMenuItem.Name = "EncodingToolStripMenuItem"
        Me.EncodingToolStripMenuItem.Size = New System.Drawing.Size(69, 20)
        Me.EncodingToolStripMenuItem.Text = "Encoding"
        '
        'EncodeInANSIToolStripMenuItem
        '
        Me.EncodeInANSIToolStripMenuItem.Name = "EncodeInANSIToolStripMenuItem"
        Me.EncodeInANSIToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.EncodeInANSIToolStripMenuItem.Text = "Unicode"
        '
        'UTF8ToolStripMenuItem
        '
        Me.UTF8ToolStripMenuItem.Name = "UTF8ToolStripMenuItem"
        Me.UTF8ToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.UTF8ToolStripMenuItem.Text = "UTF8"
        '
        'ASCIIToolStripMenuItem
        '
        Me.ASCIIToolStripMenuItem.Name = "ASCIIToolStripMenuItem"
        Me.ASCIIToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.ASCIIToolStripMenuItem.Text = "ASCII"
        '
        'SyntaxHighlightingToolStripMenuItem
        '
        Me.SyntaxHighlightingToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CustomfromFileToolStripMenuItem, Me.CodeFoldingToolStripMenuItem})
        Me.SyntaxHighlightingToolStripMenuItem.Name = "SyntaxHighlightingToolStripMenuItem"
        Me.SyntaxHighlightingToolStripMenuItem.Size = New System.Drawing.Size(123, 20)
        Me.SyntaxHighlightingToolStripMenuItem.Text = "Syntax Highlighting"
        '
        'CustomfromFileToolStripMenuItem
        '
        Me.CustomfromFileToolStripMenuItem.Name = "CustomfromFileToolStripMenuItem"
        Me.CustomfromFileToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.CustomfromFileToolStripMenuItem.Text = "Custom (from file)"
        '
        'CodeFoldingToolStripMenuItem
        '
        Me.CodeFoldingToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExpandAllToolStripMenuItem, Me.CollapseAllToolStripMenuItem})
        Me.CodeFoldingToolStripMenuItem.Name = "CodeFoldingToolStripMenuItem"
        Me.CodeFoldingToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.CodeFoldingToolStripMenuItem.Text = "Code Folding"
        '
        'ExpandAllToolStripMenuItem
        '
        Me.ExpandAllToolStripMenuItem.Name = "ExpandAllToolStripMenuItem"
        Me.ExpandAllToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.ExpandAllToolStripMenuItem.Text = "Expand All"
        '
        'CollapseAllToolStripMenuItem
        '
        Me.CollapseAllToolStripMenuItem.Name = "CollapseAllToolStripMenuItem"
        Me.CollapseAllToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.CollapseAllToolStripMenuItem.Text = "Collapse All"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem, Me.CheckForUpdatesToolStripMenuItem, Me.SendFeedbackToolStripMenuItem, Me.TipsToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(24, 20)
        Me.HelpToolStripMenuItem.Text = "?"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'CheckForUpdatesToolStripMenuItem
        '
        Me.CheckForUpdatesToolStripMenuItem.Name = "CheckForUpdatesToolStripMenuItem"
        Me.CheckForUpdatesToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.CheckForUpdatesToolStripMenuItem.Text = "Check for Updates"
        '
        'SendFeedbackToolStripMenuItem
        '
        Me.SendFeedbackToolStripMenuItem.Name = "SendFeedbackToolStripMenuItem"
        Me.SendFeedbackToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.SendFeedbackToolStripMenuItem.Text = "Send Feedback"
        '
        'TipsToolStripMenuItem
        '
        Me.TipsToolStripMenuItem.Name = "TipsToolStripMenuItem"
        Me.TipsToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.TipsToolStripMenuItem.Text = "Tips"
        '
        'XToolStripMenuItem
        '
        Me.XToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.XToolStripMenuItem.Name = "XToolStripMenuItem"
        Me.XToolStripMenuItem.Size = New System.Drawing.Size(26, 20)
        Me.XToolStripMenuItem.Text = "X"
        Me.XToolStripMenuItem.Visible = False
        '
        'ZoomToolStripMenuItem
        '
        Me.ZoomToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ZoomToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ZoomInToolStripMenuItem, Me.ZoomOutToolStripMenuItem, Me.ResetZoomToolStripMenuItem})
        Me.ZoomToolStripMenuItem.Name = "ZoomToolStripMenuItem"
        Me.ZoomToolStripMenuItem.Size = New System.Drawing.Size(51, 20)
        Me.ZoomToolStripMenuItem.Text = "Zoom"
        '
        'ZoomInToolStripMenuItem
        '
        Me.ZoomInToolStripMenuItem.Name = "ZoomInToolStripMenuItem"
        Me.ZoomInToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl++"
        Me.ZoomInToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Oemplus), System.Windows.Forms.Keys)
        Me.ZoomInToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.ZoomInToolStripMenuItem.Text = "Zoom In"
        '
        'ZoomOutToolStripMenuItem
        '
        Me.ZoomOutToolStripMenuItem.Name = "ZoomOutToolStripMenuItem"
        Me.ZoomOutToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+-"
        Me.ZoomOutToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.OemMinus), System.Windows.Forms.Keys)
        Me.ZoomOutToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.ZoomOutToolStripMenuItem.Text = "Zoom Out"
        '
        'ResetZoomToolStripMenuItem
        '
        Me.ResetZoomToolStripMenuItem.Name = "ResetZoomToolStripMenuItem"
        Me.ResetZoomToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D0), System.Windows.Forms.Keys)
        Me.ResetZoomToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.ResetZoomToolStripMenuItem.Text = "Reset Zoom"
        '
        'msMain
        '
        Me.msMain.BackColor = System.Drawing.SystemColors.Control
        Me.msMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.InsertToolStripMenuItem, Me.ViewToolStripMenuItem, Me.FormatToolStripMenuItem, Me.MacroToolStripMenuItem, Me.RunToolStripMenuItem, Me.EncodingToolStripMenuItem, Me.SyntaxHighlightingToolStripMenuItem, Me.AddonsToolStripMenuItem, Me.HelpToolStripMenuItem, Me.XToolStripMenuItem, Me.ZoomToolStripMenuItem})
        Me.msMain.Location = New System.Drawing.Point(0, 0)
        Me.msMain.Name = "msMain"
        Me.msMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.msMain.Size = New System.Drawing.Size(839, 24)
        Me.msMain.TabIndex = 1
        Me.msMain.Text = "MenuStrip1"
        '
        'MacroToolStripMenuItem
        '
        Me.MacroToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StartRecordingToolStripMenuItem, Me.StopRecordingToolStripMenuItem, Me.MacrosToolStripMenuItem, Me.MacroManagerToolStripMenuItem})
        Me.MacroToolStripMenuItem.Name = "MacroToolStripMenuItem"
        Me.MacroToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.MacroToolStripMenuItem.Text = "Macro"
        '
        'StartRecordingToolStripMenuItem
        '
        Me.StartRecordingToolStripMenuItem.Name = "StartRecordingToolStripMenuItem"
        Me.StartRecordingToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.StartRecordingToolStripMenuItem.Text = "Start Recording"
        '
        'StopRecordingToolStripMenuItem
        '
        Me.StopRecordingToolStripMenuItem.Name = "StopRecordingToolStripMenuItem"
        Me.StopRecordingToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.StopRecordingToolStripMenuItem.Text = "Stop Recording"
        '
        'MacrosToolStripMenuItem
        '
        Me.MacrosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NoneToolStripMenuItem1})
        Me.MacrosToolStripMenuItem.Name = "MacrosToolStripMenuItem"
        Me.MacrosToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.MacrosToolStripMenuItem.Text = "Macros"
        '
        'NoneToolStripMenuItem1
        '
        Me.NoneToolStripMenuItem1.Name = "NoneToolStripMenuItem1"
        Me.NoneToolStripMenuItem1.Size = New System.Drawing.Size(112, 22)
        Me.NoneToolStripMenuItem1.Text = "None..."
        '
        'MacroManagerToolStripMenuItem
        '
        Me.MacroManagerToolStripMenuItem.Name = "MacroManagerToolStripMenuItem"
        Me.MacroManagerToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.MacroManagerToolStripMenuItem.Text = "Macro Manager"
        '
        'AddonsToolStripMenuItem
        '
        Me.AddonsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GetAddonsToolStripMenuItem})
        Me.AddonsToolStripMenuItem.Name = "AddonsToolStripMenuItem"
        Me.AddonsToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.AddonsToolStripMenuItem.Text = "Addons"
        '
        'GetAddonsToolStripMenuItem
        '
        Me.GetAddonsToolStripMenuItem.Name = "GetAddonsToolStripMenuItem"
        Me.GetAddonsToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.GetAddonsToolStripMenuItem.Text = "Addon Manager"
        '
        'ilTabControlImages
        '
        Me.ilTabControlImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit
        Me.ilTabControlImages.ImageSize = New System.Drawing.Size(16, 16)
        Me.ilTabControlImages.TransparentColor = System.Drawing.Color.Transparent
        '
        'tsFind
        '
        Me.tsFind.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tsFind.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsFind.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.txtFind, Me.btnCloseFindBar, Me.btnFindNext, Me.btnFindPrevious, Me.btnFindHighlightAll})
        Me.tsFind.Location = New System.Drawing.Point(0, 452)
        Me.tsFind.Name = "tsFind"
        Me.tsFind.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.tsFind.Size = New System.Drawing.Size(839, 25)
        Me.tsFind.TabIndex = 5
        Me.tsFind.Text = "ToolStrip1"
        '
        'txtFind
        '
        Me.txtFind.Name = "txtFind"
        Me.txtFind.Size = New System.Drawing.Size(300, 25)
        '
        'btnCloseFindBar
        '
        Me.btnCloseFindBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnCloseFindBar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnCloseFindBar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCloseFindBar.Name = "btnCloseFindBar"
        Me.btnCloseFindBar.Size = New System.Drawing.Size(40, 22)
        Me.btnCloseFindBar.Text = "Close"
        Me.btnCloseFindBar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'btnFindNext
        '
        Me.btnFindNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnFindNext.Image = CType(resources.GetObject("btnFindNext.Image"), System.Drawing.Image)
        Me.btnFindNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFindNext.Name = "btnFindNext"
        Me.btnFindNext.Size = New System.Drawing.Size(23, 22)
        Me.btnFindNext.ToolTipText = "Find Next"
        '
        'btnFindPrevious
        '
        Me.btnFindPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnFindPrevious.Image = CType(resources.GetObject("btnFindPrevious.Image"), System.Drawing.Image)
        Me.btnFindPrevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFindPrevious.Name = "btnFindPrevious"
        Me.btnFindPrevious.Size = New System.Drawing.Size(23, 22)
        Me.btnFindPrevious.ToolTipText = "Find Previous"
        '
        'btnFindHighlightAll
        '
        Me.btnFindHighlightAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnFindHighlightAll.Image = CType(resources.GetObject("btnFindHighlightAll.Image"), System.Drawing.Image)
        Me.btnFindHighlightAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFindHighlightAll.Name = "btnFindHighlightAll"
        Me.btnFindHighlightAll.Size = New System.Drawing.Size(23, 22)
        Me.btnFindHighlightAll.ToolTipText = "Highlight All"
        '
        'tsCompiler
        '
        Me.tsCompiler.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnRunCode, Me.btnCompilerNetFramework, Me.btnAssemblyOptions, Me.btnCloseCompiler, Me.ToolStripDropDownButton1, Me.ToolStripDropDownButton2})
        Me.tsCompiler.Location = New System.Drawing.Point(0, 49)
        Me.tsCompiler.Name = "tsCompiler"
        Me.tsCompiler.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.tsCompiler.Size = New System.Drawing.Size(839, 25)
        Me.tsCompiler.TabIndex = 6
        Me.tsCompiler.Text = "ToolStrip1"
        Me.tsCompiler.Visible = False
        '
        'btnRunCode
        '
        Me.btnRunCode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnRunCode.Image = CType(resources.GetObject("btnRunCode.Image"), System.Drawing.Image)
        Me.btnRunCode.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRunCode.Name = "btnRunCode"
        Me.btnRunCode.Size = New System.Drawing.Size(23, 22)
        Me.btnRunCode.Text = "Run"
        '
        'btnCompilerNetFramework
        '
        Me.btnCompilerNetFramework.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnCompilerNetFramework.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Framework20ToolStripMenuItem, Me.Framework30ToolStripMenuItem, Me.Framework35ToolStripMenuItem, Me.Framework40ToolStripMenuItem})
        Me.btnCompilerNetFramework.Image = CType(resources.GetObject("btnCompilerNetFramework.Image"), System.Drawing.Image)
        Me.btnCompilerNetFramework.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCompilerNetFramework.Name = "btnCompilerNetFramework"
        Me.btnCompilerNetFramework.Size = New System.Drawing.Size(107, 22)
        Me.btnCompilerNetFramework.Text = ".NET Framework"
        '
        'Framework20ToolStripMenuItem
        '
        Me.Framework20ToolStripMenuItem.Name = "Framework20ToolStripMenuItem"
        Me.Framework20ToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.Framework20ToolStripMenuItem.Text = "Framework 2.0"
        '
        'Framework30ToolStripMenuItem
        '
        Me.Framework30ToolStripMenuItem.Name = "Framework30ToolStripMenuItem"
        Me.Framework30ToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.Framework30ToolStripMenuItem.Text = "Framework 3.0"
        '
        'Framework35ToolStripMenuItem
        '
        Me.Framework35ToolStripMenuItem.Name = "Framework35ToolStripMenuItem"
        Me.Framework35ToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.Framework35ToolStripMenuItem.Text = "Framework 3.5"
        '
        'Framework40ToolStripMenuItem
        '
        Me.Framework40ToolStripMenuItem.Name = "Framework40ToolStripMenuItem"
        Me.Framework40ToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.Framework40ToolStripMenuItem.Text = "Framework 4.0"
        '
        'btnAssemblyOptions
        '
        Me.btnAssemblyOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnAssemblyOptions.Image = CType(resources.GetObject("btnAssemblyOptions.Image"), System.Drawing.Image)
        Me.btnAssemblyOptions.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAssemblyOptions.Name = "btnAssemblyOptions"
        Me.btnAssemblyOptions.Size = New System.Drawing.Size(23, 22)
        Me.btnAssemblyOptions.Text = "Assembly Options"
        '
        'btnCloseCompiler
        '
        Me.btnCloseCompiler.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnCloseCompiler.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnCloseCompiler.Image = CType(resources.GetObject("btnCloseCompiler.Image"), System.Drawing.Image)
        Me.btnCloseCompiler.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCloseCompiler.Name = "btnCloseCompiler"
        Me.btnCloseCompiler.Size = New System.Drawing.Size(40, 22)
        Me.btnCloseCompiler.Text = "Close"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2, Me.ToolStripMenuItem4})
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(55, 22)
        Me.ToolStripDropDownButton1.Text = "Debug"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(113, 22)
        Me.ToolStripMenuItem2.Text = "Debug"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(113, 22)
        Me.ToolStripMenuItem4.Text = "Release"
        '
        'ToolStripDropDownButton2
        '
        Me.ToolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem3, Me.AnyCPUToolStripMenuItem, Me.ItaniumToolStripMenuItem})
        Me.ToolStripDropDownButton2.Image = CType(resources.GetObject("ToolStripDropDownButton2.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton2.Name = "ToolStripDropDownButton2"
        Me.ToolStripDropDownButton2.Size = New System.Drawing.Size(37, 22)
        Me.ToolStripDropDownButton2.Text = "x86"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(118, 22)
        Me.ToolStripMenuItem1.Text = "x86"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(118, 22)
        Me.ToolStripMenuItem3.Text = "x64"
        '
        'AnyCPUToolStripMenuItem
        '
        Me.AnyCPUToolStripMenuItem.Name = "AnyCPUToolStripMenuItem"
        Me.AnyCPUToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.AnyCPUToolStripMenuItem.Text = "AnyCPU"
        '
        'ItaniumToolStripMenuItem
        '
        Me.ItaniumToolStripMenuItem.Name = "ItaniumToolStripMenuItem"
        Me.ItaniumToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.ItaniumToolStripMenuItem.Text = "Itanium"
        '
        'tcMain
        '
        Me.tcMain.Alignment = CustomTabControl.TabControl.TabAlignment.Top
        Me.tcMain.BackgroundHatch = System.Drawing.Drawing2D.HatchStyle.LargeGrid
        Me.tcMain.ControlButtonBackLowColor = System.Drawing.Color.Empty
        Me.tcMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcMain.Location = New System.Drawing.Point(0, 49)
        Me.tcMain.MenuRenderer = Nothing
        Me.tcMain.Name = "tcMain"
        Me.tcMain.Size = New System.Drawing.Size(839, 403)
        Me.tcMain.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None
        Me.tcMain.TabBorderEnhanceWeight = CustomTabControl.TabControl.Weight.Medium
        Me.tcMain.TabCloseButtonImage = Nothing
        Me.tcMain.TabCloseButtonImageDisabled = Nothing
        Me.tcMain.TabCloseButtonImageHot = Nothing
        Me.tcMain.TabIndex = 4
        Me.tcMain.TabsDirection = CustomTabControl.TabControl.FlowDirection.LeftToRight
        Me.tcMain.UseBackgroundHatch = False
        '
        'cmuTab
        '
        Me.cmuTab.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowFileInExplorerToolStripMenuItem})
        Me.cmuTab.Name = "cmuTab"
        Me.cmuTab.Size = New System.Drawing.Size(181, 26)
        '
        'ShowFileInExplorerToolStripMenuItem
        '
        Me.ShowFileInExplorerToolStripMenuItem.Name = "ShowFileInExplorerToolStripMenuItem"
        Me.ShowFileInExplorerToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ShowFileInExplorerToolStripMenuItem.Text = "Show file in Explorer"
        '
        'cmuScintilla
        '
        Me.cmuScintilla.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CutToolStripMenuItem1, Me.CopyToolStripMenuItem1, Me.PasteToolStripMenuItem1, Me.InsertToolStripMenuItem1, Me.ThisLineToolStripMenuItem})
        Me.cmuScintilla.Name = "ContextMenuStrip1"
        Me.cmuScintilla.Size = New System.Drawing.Size(153, 136)
        '
        'CutToolStripMenuItem1
        '
        Me.CutToolStripMenuItem1.Name = "CutToolStripMenuItem1"
        Me.CutToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.CutToolStripMenuItem1.Text = "Cut"
        '
        'CopyToolStripMenuItem1
        '
        Me.CopyToolStripMenuItem1.Name = "CopyToolStripMenuItem1"
        Me.CopyToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.CopyToolStripMenuItem1.Text = "Copy"
        '
        'PasteToolStripMenuItem1
        '
        Me.PasteToolStripMenuItem1.Name = "PasteToolStripMenuItem1"
        Me.PasteToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.PasteToolStripMenuItem1.Text = "Paste"
        '
        'InsertToolStripMenuItem1
        '
        Me.InsertToolStripMenuItem1.Enabled = False
        Me.InsertToolStripMenuItem1.Name = "InsertToolStripMenuItem1"
        Me.InsertToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.InsertToolStripMenuItem1.Text = "Insert"
        '
        'ThisLineToolStripMenuItem
        '
        Me.ThisLineToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BookmarkToolStripMenuItem, Me.CommentToolStripMenuItem})
        Me.ThisLineToolStripMenuItem.Name = "ThisLineToolStripMenuItem"
        Me.ThisLineToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ThisLineToolStripMenuItem.Text = "This Line"
        '
        'BookmarkToolStripMenuItem
        '
        Me.BookmarkToolStripMenuItem.Name = "BookmarkToolStripMenuItem"
        Me.BookmarkToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.BookmarkToolStripMenuItem.Text = "Toggle Bookmark"
        '
        'CommentToolStripMenuItem
        '
        Me.CommentToolStripMenuItem.Name = "CommentToolStripMenuItem"
        Me.CommentToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.CommentToolStripMenuItem.Text = "Comment"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(839, 499)
        Me.Controls.Add(Me.tcMain)
        Me.Controls.Add(Me.tsCompiler)
        Me.Controls.Add(Me.tsFind)
        Me.Controls.Add(Me.msToolbar)
        Me.Controls.Add(Me.msMain)
        Me.Controls.Add(Me.msInfo)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.msMain
        Me.Name = "frmMain"
        Me.Text = "NeoIDE"
        Me.msInfo.ResumeLayout(False)
        Me.msInfo.PerformLayout()
        Me.msToolbar.ResumeLayout(False)
        Me.msToolbar.PerformLayout()
        Me.msMain.ResumeLayout(False)
        Me.msMain.PerformLayout()
        Me.tsFind.ResumeLayout(False)
        Me.tsFind.PerformLayout()
        Me.tsCompiler.ResumeLayout(False)
        Me.tsCompiler.PerformLayout()
        Me.cmuTab.ResumeLayout(False)
        Me.cmuScintilla.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bwWordCount As System.ComponentModel.BackgroundWorker
    Friend WithEvents tmrWordCount As System.Windows.Forms.Timer
    Friend WithEvents tmrTypingAutoSave As System.Windows.Forms.Timer
    Friend WithEvents tmrExpireAutoSave As System.Windows.Forms.Timer
    Friend WithEvents bwAutoSave As System.ComponentModel.BackgroundWorker
    Friend WithEvents msToolbar As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbCustomize As System.Windows.Forms.ToolStripButton
    Friend WithEvents msInfo As System.Windows.Forms.StatusStrip
    Friend WithEvents lblTextLength As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblColumn As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblLineCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblInfo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tcMain As CustomTabControl.TabControl
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintPreviewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UndoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RedoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FindToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FindInFilesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReplaceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GotoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SelectedTextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReverseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangeToUPPERCASEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangeToLOWERCASEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangeToSentenceCaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InvertCaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CapitalizeFirstLetterOfEachWordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InsertToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DateTimeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SymbolToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CodeBlocksToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CodeBlockEditorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TopMostToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FullScreenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowEolToolstripmenuitem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowSpaceMarkersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LineHighlightingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowLineHighlightingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectColorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BookmarkingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowBookmarkMarginToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddBookmarkToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BookmarkManagerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NoneToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CutBookmarkedLinesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyBookmarkedLinesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoveAllBookmarksToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConfigurationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FormatToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FontToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TextColorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WordWrapToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RunToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EncodingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EncodeInANSIToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UTF8ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ASCIIToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SyntaxHighlightingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomfromFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CodeFoldingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExpandAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CollapseAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SendFeedbackToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TipsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents XToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZoomToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZoomInToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZoomOutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResetZoomToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msMain As System.Windows.Forms.MenuStrip
    Friend WithEvents EncryptAndCloseSelectedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ilTabControlImages As System.Windows.Forms.ImageList
    Friend WithEvents ShareToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ThisDocumentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FacebookToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LocalhostrToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FTPServerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MultipleDocumentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FacebookToolStripMenuItemMultiple As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FTPServerToolStripMenuItemMultiple As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CheckForUpdatesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RecentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearRecentItemsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExportToHTMLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MacroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StartRecordingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StopRecordingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MacrosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MacroManagerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NoneToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsFind As System.Windows.Forms.ToolStrip
    Friend WithEvents txtFind As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsCompiler As System.Windows.Forms.ToolStrip
    Friend WithEvents btnRunCode As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCompilerNetFramework As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents Framework20ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Framework30ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Framework35ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Framework40ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnAssemblyOptions As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCloseFindBar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCloseCompiler As System.Windows.Forms.ToolStripButton
    Friend WithEvents CompilerToolbarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewProjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmuTab As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ShowFileInExplorerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripDropDownButton2 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnyCPUToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItaniumToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnFindNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnFindPrevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnFindHighlightAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents QuickFindToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HTMLSidebarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProjectSidebarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddonsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmuScintilla As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents GetAddonsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents localhostrToolStripMenuItemMultiple As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CutToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InsertToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ThisLineToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BookmarkToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CommentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
