<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSidebar
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

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
        Me.treeMain = New System.Windows.Forms.TreeView()
        Me.cmuMain = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenInToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DefaultEditorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfigureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowInExplorerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.RemoveFromProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CreateFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.RenameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PropertiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.NewProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddFilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ilMain = New System.Windows.Forms.ImageList(Me.components)
        Me.cmuMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'treeMain
        '
        Me.treeMain.AllowDrop = True
        Me.treeMain.ContextMenuStrip = Me.cmuMain
        Me.treeMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.treeMain.ImageIndex = 0
        Me.treeMain.ImageList = Me.ilMain
        Me.treeMain.Location = New System.Drawing.Point(0, 0)
        Me.treeMain.Name = "treeMain"
        Me.treeMain.SelectedImageIndex = 0
        Me.treeMain.Size = New System.Drawing.Size(263, 606)
        Me.treeMain.TabIndex = 1
        '
        'cmuMain
        '
        Me.cmuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.OpenInToolStripMenuItem, Me.ShowInExplorerToolStripMenuItem, Me.ToolStripSeparator2, Me.RemoveFromProjectToolStripMenuItem, Me.ToolStripSeparator1, Me.CreateFileToolStripMenuItem, Me.CreateFolderToolStripMenuItem, Me.ToolStripSeparator3, Me.RenameToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.PropertiesToolStripMenuItem, Me.ToolStripSeparator4, Me.NewProjectToolStripMenuItem, Me.OpenProjectToolStripMenuItem, Me.AddFolderToolStripMenuItem, Me.AddFilesToolStripMenuItem, Me.SaveProjectToolStripMenuItem, Me.CloseToolStripMenuItem})
        Me.cmuMain.Name = "cmuMain"
        Me.cmuMain.Size = New System.Drawing.Size(211, 358)
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.OpenToolStripMenuItem.Text = "Open"
        '
        'OpenInToolStripMenuItem
        '
        Me.OpenInToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DefaultEditorToolStripMenuItem, Me.ConfigureToolStripMenuItem})
        Me.OpenInToolStripMenuItem.Enabled = False
        Me.OpenInToolStripMenuItem.Name = "OpenInToolStripMenuItem"
        Me.OpenInToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.OpenInToolStripMenuItem.Text = "Open in..."
        '
        'DefaultEditorToolStripMenuItem
        '
        Me.DefaultEditorToolStripMenuItem.Name = "DefaultEditorToolStripMenuItem"
        Me.DefaultEditorToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.DefaultEditorToolStripMenuItem.Text = "Default Editor"
        '
        'ConfigureToolStripMenuItem
        '
        Me.ConfigureToolStripMenuItem.Name = "ConfigureToolStripMenuItem"
        Me.ConfigureToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.ConfigureToolStripMenuItem.Text = "Configure"
        '
        'ShowInExplorerToolStripMenuItem
        '
        Me.ShowInExplorerToolStripMenuItem.Name = "ShowInExplorerToolStripMenuItem"
        Me.ShowInExplorerToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.ShowInExplorerToolStripMenuItem.Text = "Show in Explorer"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(207, 6)
        '
        'RemoveFromProjectToolStripMenuItem
        '
        Me.RemoveFromProjectToolStripMenuItem.Name = "RemoveFromProjectToolStripMenuItem"
        Me.RemoveFromProjectToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.RemoveFromProjectToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.RemoveFromProjectToolStripMenuItem.Text = "Remove from project"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(207, 6)
        '
        'CreateFileToolStripMenuItem
        '
        Me.CreateFileToolStripMenuItem.Enabled = False
        Me.CreateFileToolStripMenuItem.Name = "CreateFileToolStripMenuItem"
        Me.CreateFileToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.CreateFileToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.CreateFileToolStripMenuItem.Text = "Create File"
        '
        'CreateFolderToolStripMenuItem
        '
        Me.CreateFolderToolStripMenuItem.Enabled = False
        Me.CreateFolderToolStripMenuItem.Name = "CreateFolderToolStripMenuItem"
        Me.CreateFolderToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.CreateFolderToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.CreateFolderToolStripMenuItem.Text = "Create Folder"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(207, 6)
        '
        'RenameToolStripMenuItem
        '
        Me.RenameToolStripMenuItem.Name = "RenameToolStripMenuItem"
        Me.RenameToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.RenameToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.RenameToolStripMenuItem.Text = "Rename"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Delete), System.Windows.Forms.Keys)
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'PropertiesToolStripMenuItem
        '
        Me.PropertiesToolStripMenuItem.Name = "PropertiesToolStripMenuItem"
        Me.PropertiesToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F3), System.Windows.Forms.Keys)
        Me.PropertiesToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.PropertiesToolStripMenuItem.Text = "Properties"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(207, 6)
        '
        'NewProjectToolStripMenuItem
        '
        Me.NewProjectToolStripMenuItem.Name = "NewProjectToolStripMenuItem"
        Me.NewProjectToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.NewProjectToolStripMenuItem.Text = "New Project"
        '
        'OpenProjectToolStripMenuItem
        '
        Me.OpenProjectToolStripMenuItem.Name = "OpenProjectToolStripMenuItem"
        Me.OpenProjectToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.OpenProjectToolStripMenuItem.Text = "Open Project"
        '
        'AddFolderToolStripMenuItem
        '
        Me.AddFolderToolStripMenuItem.Name = "AddFolderToolStripMenuItem"
        Me.AddFolderToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.AddFolderToolStripMenuItem.Text = "Add Folder"
        '
        'AddFilesToolStripMenuItem
        '
        Me.AddFilesToolStripMenuItem.Name = "AddFilesToolStripMenuItem"
        Me.AddFilesToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.AddFilesToolStripMenuItem.Text = "Add File(s)"
        '
        'SaveProjectToolStripMenuItem
        '
        Me.SaveProjectToolStripMenuItem.Name = "SaveProjectToolStripMenuItem"
        Me.SaveProjectToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.SaveProjectToolStripMenuItem.Text = "Save Project"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'ilMain
        '
        Me.ilMain.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit
        Me.ilMain.ImageSize = New System.Drawing.Size(16, 16)
        Me.ilMain.TransparentColor = System.Drawing.Color.Transparent
        '
        'frmSidebar
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(263, 606)
        Me.Controls.Add(Me.treeMain)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmSidebar"
        Me.Text = "Project Sidebar"
        Me.cmuMain.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents treeMain As System.Windows.Forms.TreeView
    Friend WithEvents cmuMain As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenInToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DefaultEditorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConfigureToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowInExplorerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RemoveFromProjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CreateFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreateFolderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RenameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PropertiesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NewProjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenProjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddFolderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddFilesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveProjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ilMain As System.Windows.Forms.ImageList
End Class
