<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfig
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnGeneral = New System.Windows.Forms.ToolStripButton()
        Me.btnHighlighting = New System.Windows.Forms.ToolStripButton()
        Me.btnIntegration = New System.Windows.Forms.ToolStripButton()
        Me.btnEditing = New System.Windows.Forms.ToolStripButton()
        Me.tcSettings = New System.Windows.Forms.TabControl()
        Me.tbMain = New System.Windows.Forms.TabPage()
        Me.gbAccessibility = New System.Windows.Forms.GroupBox()
        Me.chkDisableDocSwitcher = New System.Windows.Forms.CheckBox()
        Me.gbTabControl = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblDesignTheme = New System.Windows.Forms.LinkLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnInstallTheme = New System.Windows.Forms.Button()
        Me.btnGetTheme = New System.Windows.Forms.Button()
        Me.lstTheme = New System.Windows.Forms.ListBox()
        Me.chkStatusBarVisible = New System.Windows.Forms.CheckBox()
        Me.chkToolbarVisible = New System.Windows.Forms.CheckBox()
        Me.tbhighlighting = New System.Windows.Forms.TabPage()
        Me.btnEditCodeDetection = New System.Windows.Forms.Button()
        Me.btnRemoveCodeDetection = New System.Windows.Forms.Button()
        Me.btnAddCodeDetection = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.lvwCodeDetection = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnEditHighlighting = New System.Windows.Forms.Button()
        Me.btnRemoveHighlighting = New System.Windows.Forms.Button()
        Me.btnAddHighlighting = New System.Windows.Forms.Button()
        Me.chkAutoHiglighting = New System.Windows.Forms.CheckBox()
        Me.lvwHighlighting = New System.Windows.Forms.ListView()
        Me.clmnExtension = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clmnLexerName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tbIntegration = New System.Windows.Forms.TabPage()
        Me.btnFileTypes = New System.Windows.Forms.Button()
        Me.chkDocumentTitleBar = New System.Windows.Forms.CheckBox()
        Me.chkRememberSession = New System.Windows.Forms.CheckBox()
        Me.txtCustomExplorerIntegration = New System.Windows.Forms.TextBox()
        Me.chkCustomExplorerIntegration = New System.Windows.Forms.CheckBox()
        Me.chkExplorerIntegration = New System.Windows.Forms.CheckBox()
        Me.tbEditing = New System.Windows.Forms.TabPage()
        Me.ttMain = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1.SuspendLayout()
        Me.tcSettings.SuspendLayout()
        Me.tbMain.SuspendLayout()
        Me.gbAccessibility.SuspendLayout()
        Me.gbTabControl.SuspendLayout()
        Me.tbhighlighting.SuspendLayout()
        Me.tbIntegration.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGeneral, Me.btnHighlighting, Me.btnIntegration, Me.btnEditing, Me.ToolStripButton1})
        Me.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(139, 398)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnGeneral
        '
        Me.btnGeneral.Checked = True
        Me.btnGeneral.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnGeneral.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnGeneral.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGeneral.Name = "btnGeneral"
        Me.btnGeneral.Size = New System.Drawing.Size(136, 19)
        Me.btnGeneral.Text = "Look && Feel"
        Me.btnGeneral.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnHighlighting
        '
        Me.btnHighlighting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnHighlighting.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnHighlighting.Name = "btnHighlighting"
        Me.btnHighlighting.Size = New System.Drawing.Size(136, 19)
        Me.btnHighlighting.Text = "Syntax Highlighting"
        Me.btnHighlighting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnIntegration
        '
        Me.btnIntegration.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnIntegration.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnIntegration.Name = "btnIntegration"
        Me.btnIntegration.Size = New System.Drawing.Size(136, 19)
        Me.btnIntegration.Text = "Behaviour && Integration"
        Me.btnIntegration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnEditing
        '
        Me.btnEditing.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnEditing.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEditing.Name = "btnEditing"
        Me.btnEditing.Size = New System.Drawing.Size(136, 19)
        Me.btnEditing.Text = "Editing"
        Me.btnEditing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tcSettings
        '
        Me.tcSettings.Controls.Add(Me.tbMain)
        Me.tcSettings.Controls.Add(Me.tbhighlighting)
        Me.tcSettings.Controls.Add(Me.tbIntegration)
        Me.tcSettings.Controls.Add(Me.tbEditing)
        Me.tcSettings.Location = New System.Drawing.Point(134, -23)
        Me.tcSettings.Name = "tcSettings"
        Me.tcSettings.SelectedIndex = 0
        Me.tcSettings.Size = New System.Drawing.Size(610, 425)
        Me.tcSettings.TabIndex = 1
        '
        'tbMain
        '
        Me.tbMain.BackColor = System.Drawing.SystemColors.Control
        Me.tbMain.Controls.Add(Me.gbAccessibility)
        Me.tbMain.Location = New System.Drawing.Point(4, 22)
        Me.tbMain.Name = "tbMain"
        Me.tbMain.Padding = New System.Windows.Forms.Padding(3)
        Me.tbMain.Size = New System.Drawing.Size(602, 399)
        Me.tbMain.TabIndex = 0
        Me.tbMain.Text = "Main"
        '
        'gbAccessibility
        '
        Me.gbAccessibility.Controls.Add(Me.chkDisableDocSwitcher)
        Me.gbAccessibility.Controls.Add(Me.gbTabControl)
        Me.gbAccessibility.Controls.Add(Me.chkStatusBarVisible)
        Me.gbAccessibility.Controls.Add(Me.chkToolbarVisible)
        Me.gbAccessibility.Location = New System.Drawing.Point(15, 6)
        Me.gbAccessibility.Name = "gbAccessibility"
        Me.gbAccessibility.Size = New System.Drawing.Size(574, 381)
        Me.gbAccessibility.TabIndex = 0
        Me.gbAccessibility.TabStop = False
        Me.gbAccessibility.Text = "Accessibility:"
        '
        'chkDisableDocSwitcher
        '
        Me.chkDisableDocSwitcher.AutoSize = True
        Me.chkDisableDocSwitcher.Location = New System.Drawing.Point(9, 63)
        Me.chkDisableDocSwitcher.Name = "chkDisableDocSwitcher"
        Me.chkDisableDocSwitcher.Size = New System.Drawing.Size(206, 17)
        Me.chkDisableDocSwitcher.TabIndex = 5
        Me.chkDisableDocSwitcher.Text = "Enable document switcher (shift + tab)"
        Me.chkDisableDocSwitcher.UseVisualStyleBackColor = True
        '
        'gbTabControl
        '
        Me.gbTabControl.Controls.Add(Me.Button1)
        Me.gbTabControl.Controls.Add(Me.lblDesignTheme)
        Me.gbTabControl.Controls.Add(Me.Label1)
        Me.gbTabControl.Controls.Add(Me.btnInstallTheme)
        Me.gbTabControl.Controls.Add(Me.btnGetTheme)
        Me.gbTabControl.Controls.Add(Me.lstTheme)
        Me.gbTabControl.Location = New System.Drawing.Point(9, 86)
        Me.gbTabControl.Name = "gbTabControl"
        Me.gbTabControl.Size = New System.Drawing.Size(475, 289)
        Me.gbTabControl.TabIndex = 4
        Me.gbTabControl.TabStop = False
        Me.gbTabControl.Text = "Theme"
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(149, 255)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(103, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Remove Selected"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblDesignTheme
        '
        Me.lblDesignTheme.AutoSize = True
        Me.lblDesignTheme.Location = New System.Drawing.Point(3, 260)
        Me.lblDesignTheme.Name = "lblDesignTheme"
        Me.lblDesignTheme.Size = New System.Drawing.Size(121, 13)
        Me.lblDesignTheme.TabIndex = 4
        Me.lblDesignTheme.TabStop = True
        Me.lblDesignTheme.Text = "Design your own theme!"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(464, 26)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Please select a theme from the list below. It will be automatically applied when " & _
    "you close the form." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Plase note that some times require the program to restart b" & _
    "efore showing the tabcontrol properly."
        '
        'btnInstallTheme
        '
        Me.btnInstallTheme.Location = New System.Drawing.Point(258, 255)
        Me.btnInstallTheme.Name = "btnInstallTheme"
        Me.btnInstallTheme.Size = New System.Drawing.Size(87, 23)
        Me.btnInstallTheme.TabIndex = 2
        Me.btnInstallTheme.Text = "Install Theme"
        Me.btnInstallTheme.UseVisualStyleBackColor = True
        '
        'btnGetTheme
        '
        Me.btnGetTheme.Location = New System.Drawing.Point(351, 255)
        Me.btnGetTheme.Name = "btnGetTheme"
        Me.btnGetTheme.Size = New System.Drawing.Size(118, 23)
        Me.btnGetTheme.TabIndex = 1
        Me.btnGetTheme.Text = "Get Themes (online)"
        Me.btnGetTheme.UseVisualStyleBackColor = True
        '
        'lstTheme
        '
        Me.lstTheme.FormattingEnabled = True
        Me.lstTheme.Location = New System.Drawing.Point(6, 50)
        Me.lstTheme.Name = "lstTheme"
        Me.lstTheme.Size = New System.Drawing.Size(463, 199)
        Me.lstTheme.TabIndex = 0
        '
        'chkStatusBarVisible
        '
        Me.chkStatusBarVisible.AutoSize = True
        Me.chkStatusBarVisible.Location = New System.Drawing.Point(9, 42)
        Me.chkStatusBarVisible.Name = "chkStatusBarVisible"
        Me.chkStatusBarVisible.Size = New System.Drawing.Size(105, 17)
        Me.chkStatusBarVisible.TabIndex = 3
        Me.chkStatusBarVisible.Text = "Show Status Bar"
        Me.chkStatusBarVisible.UseVisualStyleBackColor = True
        '
        'chkToolbarVisible
        '
        Me.chkToolbarVisible.AutoSize = True
        Me.chkToolbarVisible.Location = New System.Drawing.Point(9, 22)
        Me.chkToolbarVisible.Name = "chkToolbarVisible"
        Me.chkToolbarVisible.Size = New System.Drawing.Size(92, 17)
        Me.chkToolbarVisible.TabIndex = 0
        Me.chkToolbarVisible.Text = "Show Toolbar"
        Me.chkToolbarVisible.UseVisualStyleBackColor = True
        '
        'tbhighlighting
        '
        Me.tbhighlighting.BackColor = System.Drawing.SystemColors.Control
        Me.tbhighlighting.Controls.Add(Me.btnEditCodeDetection)
        Me.tbhighlighting.Controls.Add(Me.btnRemoveCodeDetection)
        Me.tbhighlighting.Controls.Add(Me.btnAddCodeDetection)
        Me.tbhighlighting.Controls.Add(Me.CheckBox1)
        Me.tbhighlighting.Controls.Add(Me.lvwCodeDetection)
        Me.tbhighlighting.Controls.Add(Me.btnEditHighlighting)
        Me.tbhighlighting.Controls.Add(Me.btnRemoveHighlighting)
        Me.tbhighlighting.Controls.Add(Me.btnAddHighlighting)
        Me.tbhighlighting.Controls.Add(Me.chkAutoHiglighting)
        Me.tbhighlighting.Controls.Add(Me.lvwHighlighting)
        Me.tbhighlighting.Location = New System.Drawing.Point(4, 22)
        Me.tbhighlighting.Name = "tbhighlighting"
        Me.tbhighlighting.Padding = New System.Windows.Forms.Padding(3)
        Me.tbhighlighting.Size = New System.Drawing.Size(602, 399)
        Me.tbhighlighting.TabIndex = 1
        Me.tbhighlighting.Text = "Syntax Highlighting"
        '
        'btnEditCodeDetection
        '
        Me.btnEditCodeDetection.Location = New System.Drawing.Point(104, 342)
        Me.btnEditCodeDetection.Name = "btnEditCodeDetection"
        Me.btnEditCodeDetection.Size = New System.Drawing.Size(75, 23)
        Me.btnEditCodeDetection.TabIndex = 9
        Me.btnEditCodeDetection.Text = "Edit"
        Me.btnEditCodeDetection.UseVisualStyleBackColor = True
        '
        'btnRemoveCodeDetection
        '
        Me.btnRemoveCodeDetection.Location = New System.Drawing.Point(185, 342)
        Me.btnRemoveCodeDetection.Name = "btnRemoveCodeDetection"
        Me.btnRemoveCodeDetection.Size = New System.Drawing.Size(75, 23)
        Me.btnRemoveCodeDetection.TabIndex = 8
        Me.btnRemoveCodeDetection.Text = "Remove"
        Me.btnRemoveCodeDetection.UseVisualStyleBackColor = True
        '
        'btnAddCodeDetection
        '
        Me.btnAddCodeDetection.Location = New System.Drawing.Point(23, 342)
        Me.btnAddCodeDetection.Name = "btnAddCodeDetection"
        Me.btnAddCodeDetection.Size = New System.Drawing.Size(75, 23)
        Me.btnAddCodeDetection.TabIndex = 7
        Me.btnAddCodeDetection.Text = "Add"
        Me.btnAddCodeDetection.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(23, 193)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(459, 17)
        Me.CheckBox1.TabIndex = 6
        Me.CheckBox1.Text = "Enable automatic syntax highlighting when text pasted into the editor contains ce" & _
    "rtain strings"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'lvwCodeDetection
        '
        Me.lvwCodeDetection.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lvwCodeDetection.FullRowSelect = True
        Me.lvwCodeDetection.Location = New System.Drawing.Point(23, 211)
        Me.lvwCodeDetection.MultiSelect = False
        Me.lvwCodeDetection.Name = "lvwCodeDetection"
        Me.lvwCodeDetection.Size = New System.Drawing.Size(566, 125)
        Me.lvwCodeDetection.TabIndex = 5
        Me.lvwCodeDetection.UseCompatibleStateImageBehavior = False
        Me.lvwCodeDetection.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "String"
        Me.ColumnHeader1.Width = 179
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Lexer Name"
        Me.ColumnHeader2.Width = 382
        '
        'btnEditHighlighting
        '
        Me.btnEditHighlighting.Location = New System.Drawing.Point(104, 155)
        Me.btnEditHighlighting.Name = "btnEditHighlighting"
        Me.btnEditHighlighting.Size = New System.Drawing.Size(75, 23)
        Me.btnEditHighlighting.TabIndex = 4
        Me.btnEditHighlighting.Text = "Edit"
        Me.btnEditHighlighting.UseVisualStyleBackColor = True
        '
        'btnRemoveHighlighting
        '
        Me.btnRemoveHighlighting.Location = New System.Drawing.Point(185, 155)
        Me.btnRemoveHighlighting.Name = "btnRemoveHighlighting"
        Me.btnRemoveHighlighting.Size = New System.Drawing.Size(75, 23)
        Me.btnRemoveHighlighting.TabIndex = 3
        Me.btnRemoveHighlighting.Text = "Remove"
        Me.btnRemoveHighlighting.UseVisualStyleBackColor = True
        '
        'btnAddHighlighting
        '
        Me.btnAddHighlighting.Location = New System.Drawing.Point(23, 155)
        Me.btnAddHighlighting.Name = "btnAddHighlighting"
        Me.btnAddHighlighting.Size = New System.Drawing.Size(75, 23)
        Me.btnAddHighlighting.TabIndex = 2
        Me.btnAddHighlighting.Text = "Add"
        Me.btnAddHighlighting.UseVisualStyleBackColor = True
        '
        'chkAutoHiglighting
        '
        Me.chkAutoHiglighting.AutoSize = True
        Me.chkAutoHiglighting.Location = New System.Drawing.Point(23, 6)
        Me.chkAutoHiglighting.Name = "chkAutoHiglighting"
        Me.chkAutoHiglighting.Size = New System.Drawing.Size(346, 17)
        Me.chkAutoHiglighting.TabIndex = 1
        Me.chkAutoHiglighting.Text = "Enable automatic syntax highlighting on opening certain documents:"
        Me.chkAutoHiglighting.UseVisualStyleBackColor = True
        '
        'lvwHighlighting
        '
        Me.lvwHighlighting.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clmnExtension, Me.clmnLexerName})
        Me.lvwHighlighting.FullRowSelect = True
        Me.lvwHighlighting.Location = New System.Drawing.Point(23, 24)
        Me.lvwHighlighting.MultiSelect = False
        Me.lvwHighlighting.Name = "lvwHighlighting"
        Me.lvwHighlighting.Size = New System.Drawing.Size(566, 125)
        Me.lvwHighlighting.TabIndex = 0
        Me.lvwHighlighting.UseCompatibleStateImageBehavior = False
        Me.lvwHighlighting.View = System.Windows.Forms.View.Details
        '
        'clmnExtension
        '
        Me.clmnExtension.Text = "File Extension"
        Me.clmnExtension.Width = 179
        '
        'clmnLexerName
        '
        Me.clmnLexerName.Text = "Lexer Name"
        Me.clmnLexerName.Width = 382
        '
        'tbIntegration
        '
        Me.tbIntegration.BackColor = System.Drawing.SystemColors.Control
        Me.tbIntegration.Controls.Add(Me.btnFileTypes)
        Me.tbIntegration.Controls.Add(Me.chkDocumentTitleBar)
        Me.tbIntegration.Controls.Add(Me.chkRememberSession)
        Me.tbIntegration.Controls.Add(Me.txtCustomExplorerIntegration)
        Me.tbIntegration.Controls.Add(Me.chkCustomExplorerIntegration)
        Me.tbIntegration.Controls.Add(Me.chkExplorerIntegration)
        Me.tbIntegration.Location = New System.Drawing.Point(4, 22)
        Me.tbIntegration.Name = "tbIntegration"
        Me.tbIntegration.Padding = New System.Windows.Forms.Padding(3)
        Me.tbIntegration.Size = New System.Drawing.Size(602, 399)
        Me.tbIntegration.TabIndex = 3
        Me.tbIntegration.Text = "Explorer Integration"
        '
        'btnFileTypes
        '
        Me.btnFileTypes.Location = New System.Drawing.Point(398, 2)
        Me.btnFileTypes.Name = "btnFileTypes"
        Me.btnFileTypes.Size = New System.Drawing.Size(75, 23)
        Me.btnFileTypes.TabIndex = 5
        Me.btnFileTypes.Text = "File Types..."
        Me.btnFileTypes.UseVisualStyleBackColor = True
        '
        'chkDocumentTitleBar
        '
        Me.chkDocumentTitleBar.AutoSize = True
        Me.chkDocumentTitleBar.Location = New System.Drawing.Point(15, 113)
        Me.chkDocumentTitleBar.Name = "chkDocumentTitleBar"
        Me.chkDocumentTitleBar.Size = New System.Drawing.Size(170, 17)
        Me.chkDocumentTitleBar.TabIndex = 4
        Me.chkDocumentTitleBar.Text = "Show document title in title bar"
        Me.chkDocumentTitleBar.UseVisualStyleBackColor = True
        '
        'chkRememberSession
        '
        Me.chkRememberSession.AutoSize = True
        Me.chkRememberSession.Location = New System.Drawing.Point(15, 90)
        Me.chkRememberSession.Name = "chkRememberSession"
        Me.chkRememberSession.Size = New System.Drawing.Size(177, 17)
        Me.chkRememberSession.TabIndex = 3
        Me.chkRememberSession.Text = "Remember Session for next time"
        Me.chkRememberSession.UseVisualStyleBackColor = True
        '
        'txtCustomExplorerIntegration
        '
        Me.txtCustomExplorerIntegration.Location = New System.Drawing.Point(44, 52)
        Me.txtCustomExplorerIntegration.Name = "txtCustomExplorerIntegration"
        Me.txtCustomExplorerIntegration.Size = New System.Drawing.Size(326, 20)
        Me.txtCustomExplorerIntegration.TabIndex = 2
        Me.txtCustomExplorerIntegration.Text = "Open with NeoIDE"
        '
        'chkCustomExplorerIntegration
        '
        Me.chkCustomExplorerIntegration.AutoSize = True
        Me.chkCustomExplorerIntegration.Location = New System.Drawing.Point(44, 29)
        Me.chkCustomExplorerIntegration.Name = "chkCustomExplorerIntegration"
        Me.chkCustomExplorerIntegration.Size = New System.Drawing.Size(115, 17)
        Me.chkCustomExplorerIntegration.TabIndex = 1
        Me.chkCustomExplorerIntegration.Text = "Customize this item"
        Me.chkCustomExplorerIntegration.UseVisualStyleBackColor = True
        '
        'chkExplorerIntegration
        '
        Me.chkExplorerIntegration.AutoSize = True
        Me.chkExplorerIntegration.Location = New System.Drawing.Point(15, 6)
        Me.chkExplorerIntegration.Name = "chkExplorerIntegration"
        Me.chkExplorerIntegration.Size = New System.Drawing.Size(331, 17)
        Me.chkExplorerIntegration.TabIndex = 0
        Me.chkExplorerIntegration.Text = "Integrate NeoIDE into Windows Explorer using a right click menu"
        Me.chkExplorerIntegration.UseVisualStyleBackColor = True
        '
        'tbEditing
        '
        Me.tbEditing.BackColor = System.Drawing.SystemColors.Control
        Me.tbEditing.Location = New System.Drawing.Point(4, 22)
        Me.tbEditing.Name = "tbEditing"
        Me.tbEditing.Padding = New System.Windows.Forms.Padding(3)
        Me.tbEditing.Size = New System.Drawing.Size(602, 399)
        Me.tbEditing.TabIndex = 4
        Me.tbEditing.Text = "Editing"
        '
        'ttMain
        '
        Me.ttMain.AutomaticDelay = 100
        Me.ttMain.AutoPopDelay = 10000
        Me.ttMain.InitialDelay = 100
        Me.ttMain.ReshowDelay = 20
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(136, 19)
        Me.ToolStripButton1.Text = "Extensions"
        Me.ToolStripButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(739, 398)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.tcSettings)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmConfig"
        Me.Text = "NeoIDE Configuration"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.tcSettings.ResumeLayout(False)
        Me.tbMain.ResumeLayout(False)
        Me.gbAccessibility.ResumeLayout(False)
        Me.gbAccessibility.PerformLayout()
        Me.gbTabControl.ResumeLayout(False)
        Me.gbTabControl.PerformLayout()
        Me.tbhighlighting.ResumeLayout(False)
        Me.tbhighlighting.PerformLayout()
        Me.tbIntegration.ResumeLayout(False)
        Me.tbIntegration.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnGeneral As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnHighlighting As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnIntegration As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEditing As System.Windows.Forms.ToolStripButton
    Friend WithEvents tcSettings As System.Windows.Forms.TabControl
    Friend WithEvents tbMain As System.Windows.Forms.TabPage
    Friend WithEvents gbAccessibility As System.Windows.Forms.GroupBox
    Friend WithEvents chkDisableDocSwitcher As System.Windows.Forms.CheckBox
    Friend WithEvents gbTabControl As System.Windows.Forms.GroupBox
    Friend WithEvents chkStatusBarVisible As System.Windows.Forms.CheckBox
    Friend WithEvents chkToolbarVisible As System.Windows.Forms.CheckBox
    Friend WithEvents tbhighlighting As System.Windows.Forms.TabPage
    Friend WithEvents tbIntegration As System.Windows.Forms.TabPage
    Friend WithEvents tbEditing As System.Windows.Forms.TabPage
    Friend WithEvents chkAutoHiglighting As System.Windows.Forms.CheckBox
    Friend WithEvents lvwHighlighting As System.Windows.Forms.ListView
    Friend WithEvents clmnExtension As System.Windows.Forms.ColumnHeader
    Friend WithEvents clmnLexerName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chkExplorerIntegration As System.Windows.Forms.CheckBox
    Friend WithEvents txtCustomExplorerIntegration As System.Windows.Forms.TextBox
    Friend WithEvents chkCustomExplorerIntegration As System.Windows.Forms.CheckBox
    Friend WithEvents chkDocumentTitleBar As System.Windows.Forms.CheckBox
    Friend WithEvents chkRememberSession As System.Windows.Forms.CheckBox
    Friend WithEvents btnEditHighlighting As System.Windows.Forms.Button
    Friend WithEvents btnRemoveHighlighting As System.Windows.Forms.Button
    Friend WithEvents btnAddHighlighting As System.Windows.Forms.Button
    Friend WithEvents btnFileTypes As System.Windows.Forms.Button
    Friend WithEvents ttMain As System.Windows.Forms.ToolTip
    Friend WithEvents btnEditCodeDetection As System.Windows.Forms.Button
    Friend WithEvents btnRemoveCodeDetection As System.Windows.Forms.Button
    Friend WithEvents btnAddCodeDetection As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents lvwCodeDetection As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblDesignTheme As System.Windows.Forms.LinkLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnInstallTheme As System.Windows.Forms.Button
    Friend WithEvents btnGetTheme As System.Windows.Forms.Button
    Friend WithEvents lstTheme As System.Windows.Forms.ListBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
End Class
