<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewProject
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
        Me.lvwMain = New System.Windows.Forms.ListView()
        Me.ilMain = New System.Windows.Forms.ImageList(Me.components)
        Me.btnCreateProject = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.txtProjectName = New System.Windows.Forms.TextBox()
        Me.txtProjectLocation = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.tcMain = New System.Windows.Forms.TabControl()
        Me.tbVB = New System.Windows.Forms.TabPage()
        Me.cbxVBFramework = New System.Windows.Forms.ComboBox()
        Me.lblVBFramework = New System.Windows.Forms.Label()
        Me.chkVBCodeGeneration = New System.Windows.Forms.CheckBox()
        Me.cbxVBTarget = New System.Windows.Forms.ComboBox()
        Me.lblVBAppType = New System.Windows.Forms.Label()
        Me.btnVBRemReference = New System.Windows.Forms.Button()
        Me.btnVBAddReference = New System.Windows.Forms.Button()
        Me.lblVBReferences = New System.Windows.Forms.Label()
        Me.lstVBReferences = New System.Windows.Forms.ListBox()
        Me.btnVBSelectIconPath = New System.Windows.Forms.Button()
        Me.lblVBIconPath = New System.Windows.Forms.Label()
        Me.txtVBIconPath = New System.Windows.Forms.TextBox()
        Me.btnVBSelectOutputPath = New System.Windows.Forms.Button()
        Me.lblVBOuptutPath = New System.Windows.Forms.Label()
        Me.txtVBOutputPath = New System.Windows.Forms.TextBox()
        Me.tbCSharp = New System.Windows.Forms.TabPage()
        Me.cbxCSFramework = New System.Windows.Forms.ComboBox()
        Me.lblCSFramework = New System.Windows.Forms.Label()
        Me.chkCSCodeGeneration = New System.Windows.Forms.CheckBox()
        Me.cbxCSTarget = New System.Windows.Forms.ComboBox()
        Me.lblCSAppType = New System.Windows.Forms.Label()
        Me.btnCSRemReference = New System.Windows.Forms.Button()
        Me.btnCSAddReference = New System.Windows.Forms.Button()
        Me.lblCSReferences = New System.Windows.Forms.Label()
        Me.lstCSReferences = New System.Windows.Forms.ListBox()
        Me.lblCSIconPath = New System.Windows.Forms.Label()
        Me.txtCSIconPath = New System.Windows.Forms.TextBox()
        Me.lblCSOutpuPath = New System.Windows.Forms.Label()
        Me.txtCSOutputPath = New System.Windows.Forms.TextBox()
        Me.tbBatch = New System.Windows.Forms.TabPage()
        Me.chkBatchCodeGeneration = New System.Windows.Forms.CheckBox()
        Me.tbVBS = New System.Windows.Forms.TabPage()
        Me.chkVBSCodeGeneration = New System.Windows.Forms.CheckBox()
        Me.tbWebsite = New System.Windows.Forms.TabPage()
        Me.btnRemoveWebsitePage = New System.Windows.Forms.Button()
        Me.btnAddWebsitePage = New System.Windows.Forms.Button()
        Me.chkCSSGeneration = New System.Windows.Forms.CheckBox()
        Me.chkSeparateCSS = New System.Windows.Forms.RadioButton()
        Me.chkCSSIntegrated = New System.Windows.Forms.RadioButton()
        Me.lblWebsiteInfo = New System.Windows.Forms.Label()
        Me.lstWebsitePages = New System.Windows.Forms.ListBox()
        Me.chkWebsiteCodeGeneration = New System.Windows.Forms.CheckBox()
        Me.tcMain.SuspendLayout()
        Me.tbVB.SuspendLayout()
        Me.tbCSharp.SuspendLayout()
        Me.tbBatch.SuspendLayout()
        Me.tbVBS.SuspendLayout()
        Me.tbWebsite.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvwMain
        '
        Me.lvwMain.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lvwMain.Location = New System.Drawing.Point(12, 12)
        Me.lvwMain.MultiSelect = False
        Me.lvwMain.Name = "lvwMain"
        Me.lvwMain.Size = New System.Drawing.Size(540, 100)
        Me.lvwMain.TabIndex = 0
        Me.lvwMain.UseCompatibleStateImageBehavior = False
        '
        'ilMain
        '
        Me.ilMain.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ilMain.ImageSize = New System.Drawing.Size(64, 64)
        Me.ilMain.TransparentColor = System.Drawing.Color.Transparent
        '
        'btnCreateProject
        '
        Me.btnCreateProject.Location = New System.Drawing.Point(412, 447)
        Me.btnCreateProject.Name = "btnCreateProject"
        Me.btnCreateProject.Size = New System.Drawing.Size(140, 23)
        Me.btnCreateProject.TabIndex = 11
        Me.btnCreateProject.Text = "Create Project"
        Me.btnCreateProject.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(12, 447)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(140, 23)
        Me.Button3.TabIndex = 13
        Me.Button3.Text = "Cancel"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'txtProjectName
        '
        Me.txtProjectName.ForeColor = System.Drawing.Color.DarkGray
        Me.txtProjectName.Location = New System.Drawing.Point(12, 118)
        Me.txtProjectName.Name = "txtProjectName"
        Me.txtProjectName.Size = New System.Drawing.Size(540, 20)
        Me.txtProjectName.TabIndex = 14
        Me.txtProjectName.Text = "Project Name"
        '
        'txtProjectLocation
        '
        Me.txtProjectLocation.ForeColor = System.Drawing.Color.DarkGray
        Me.txtProjectLocation.Location = New System.Drawing.Point(12, 144)
        Me.txtProjectLocation.Name = "txtProjectLocation"
        Me.txtProjectLocation.Size = New System.Drawing.Size(498, 20)
        Me.txtProjectLocation.TabIndex = 15
        Me.txtProjectLocation.Text = "Project Location"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(516, 142)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(36, 23)
        Me.Button1.TabIndex = 16
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'tcMain
        '
        Me.tcMain.Controls.Add(Me.tbVB)
        Me.tcMain.Controls.Add(Me.tbCSharp)
        Me.tcMain.Controls.Add(Me.tbBatch)
        Me.tcMain.Controls.Add(Me.tbVBS)
        Me.tcMain.Controls.Add(Me.tbWebsite)
        Me.tcMain.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.tcMain.ItemSize = New System.Drawing.Size(101, 20)
        Me.tcMain.Location = New System.Drawing.Point(12, 170)
        Me.tcMain.Name = "tcMain"
        Me.tcMain.SelectedIndex = 0
        Me.tcMain.Size = New System.Drawing.Size(540, 271)
        Me.tcMain.TabIndex = 17
        '
        'tbVB
        '
        Me.tbVB.Controls.Add(Me.cbxVBFramework)
        Me.tbVB.Controls.Add(Me.lblVBFramework)
        Me.tbVB.Controls.Add(Me.chkVBCodeGeneration)
        Me.tbVB.Controls.Add(Me.cbxVBTarget)
        Me.tbVB.Controls.Add(Me.lblVBAppType)
        Me.tbVB.Controls.Add(Me.btnVBRemReference)
        Me.tbVB.Controls.Add(Me.btnVBAddReference)
        Me.tbVB.Controls.Add(Me.lblVBReferences)
        Me.tbVB.Controls.Add(Me.lstVBReferences)
        Me.tbVB.Controls.Add(Me.btnVBSelectIconPath)
        Me.tbVB.Controls.Add(Me.lblVBIconPath)
        Me.tbVB.Controls.Add(Me.txtVBIconPath)
        Me.tbVB.Controls.Add(Me.btnVBSelectOutputPath)
        Me.tbVB.Controls.Add(Me.lblVBOuptutPath)
        Me.tbVB.Controls.Add(Me.txtVBOutputPath)
        Me.tbVB.Location = New System.Drawing.Point(4, 24)
        Me.tbVB.Name = "tbVB"
        Me.tbVB.Padding = New System.Windows.Forms.Padding(3)
        Me.tbVB.Size = New System.Drawing.Size(532, 243)
        Me.tbVB.TabIndex = 0
        Me.tbVB.Text = "VB Project Options"
        Me.tbVB.UseVisualStyleBackColor = True
        '
        'cbxVBFramework
        '
        Me.cbxVBFramework.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxVBFramework.FormattingEnabled = True
        Me.cbxVBFramework.Items.AddRange(New Object() {".NET Framework 2.0", ".NET Framework 3.0", ".NET Framework 3.5", ".NET Framework 4.0"})
        Me.cbxVBFramework.Location = New System.Drawing.Point(80, 33)
        Me.cbxVBFramework.Name = "cbxVBFramework"
        Me.cbxVBFramework.Size = New System.Drawing.Size(446, 21)
        Me.cbxVBFramework.TabIndex = 29
        '
        'lblVBFramework
        '
        Me.lblVBFramework.AutoSize = True
        Me.lblVBFramework.Location = New System.Drawing.Point(7, 36)
        Me.lblVBFramework.Name = "lblVBFramework"
        Me.lblVBFramework.Size = New System.Drawing.Size(62, 13)
        Me.lblVBFramework.TabIndex = 28
        Me.lblVBFramework.Text = "Framework:"
        '
        'chkVBCodeGeneration
        '
        Me.chkVBCodeGeneration.AutoSize = True
        Me.chkVBCodeGeneration.Checked = True
        Me.chkVBCodeGeneration.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkVBCodeGeneration.Location = New System.Drawing.Point(370, 218)
        Me.chkVBCodeGeneration.Name = "chkVBCodeGeneration"
        Me.chkVBCodeGeneration.Size = New System.Drawing.Size(156, 17)
        Me.chkVBCodeGeneration.TabIndex = 27
        Me.chkVBCodeGeneration.Text = "Automatic Code Generation"
        Me.chkVBCodeGeneration.UseVisualStyleBackColor = True
        '
        'cbxVBTarget
        '
        Me.cbxVBTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxVBTarget.FormattingEnabled = True
        Me.cbxVBTarget.Items.AddRange(New Object() {"Console  Application", "Class Library", "WinForms Application"})
        Me.cbxVBTarget.Location = New System.Drawing.Point(80, 6)
        Me.cbxVBTarget.Name = "cbxVBTarget"
        Me.cbxVBTarget.Size = New System.Drawing.Size(446, 21)
        Me.cbxVBTarget.TabIndex = 26
        '
        'lblVBAppType
        '
        Me.lblVBAppType.AutoSize = True
        Me.lblVBAppType.Location = New System.Drawing.Point(7, 9)
        Me.lblVBAppType.Name = "lblVBAppType"
        Me.lblVBAppType.Size = New System.Drawing.Size(56, 13)
        Me.lblVBAppType.TabIndex = 25
        Me.lblVBAppType.Text = "App Type:"
        '
        'btnVBRemReference
        '
        Me.btnVBRemReference.Location = New System.Drawing.Point(205, 214)
        Me.btnVBRemReference.Name = "btnVBRemReference"
        Me.btnVBRemReference.Size = New System.Drawing.Size(119, 23)
        Me.btnVBRemReference.TabIndex = 24
        Me.btnVBRemReference.Text = "Remove Selected"
        Me.btnVBRemReference.UseVisualStyleBackColor = True
        '
        'btnVBAddReference
        '
        Me.btnVBAddReference.Location = New System.Drawing.Point(80, 214)
        Me.btnVBAddReference.Name = "btnVBAddReference"
        Me.btnVBAddReference.Size = New System.Drawing.Size(119, 23)
        Me.btnVBAddReference.TabIndex = 23
        Me.btnVBAddReference.Text = "Add"
        Me.btnVBAddReference.UseVisualStyleBackColor = True
        '
        'lblVBReferences
        '
        Me.lblVBReferences.AutoSize = True
        Me.lblVBReferences.Location = New System.Drawing.Point(6, 113)
        Me.lblVBReferences.Name = "lblVBReferences"
        Me.lblVBReferences.Size = New System.Drawing.Size(65, 13)
        Me.lblVBReferences.TabIndex = 22
        Me.lblVBReferences.Text = "References:"
        '
        'lstVBReferences
        '
        Me.lstVBReferences.FormattingEnabled = True
        Me.lstVBReferences.Items.AddRange(New Object() {"System.dll", "System.Core.dll", "System.Data.dll", "System.Deployment.dll", "System.Drawing.dll", "System.Windows.Forms.dll", "System.Xml.dll", "System.Xml.Linq.dll"})
        Me.lstVBReferences.Location = New System.Drawing.Point(80, 113)
        Me.lstVBReferences.Name = "lstVBReferences"
        Me.lstVBReferences.Size = New System.Drawing.Size(446, 95)
        Me.lstVBReferences.TabIndex = 21
        '
        'btnVBSelectIconPath
        '
        Me.btnVBSelectIconPath.Location = New System.Drawing.Point(492, 84)
        Me.btnVBSelectIconPath.Name = "btnVBSelectIconPath"
        Me.btnVBSelectIconPath.Size = New System.Drawing.Size(34, 23)
        Me.btnVBSelectIconPath.TabIndex = 20
        Me.btnVBSelectIconPath.Text = "..."
        Me.btnVBSelectIconPath.UseVisualStyleBackColor = True
        '
        'lblVBIconPath
        '
        Me.lblVBIconPath.AutoSize = True
        Me.lblVBIconPath.Location = New System.Drawing.Point(7, 89)
        Me.lblVBIconPath.Name = "lblVBIconPath"
        Me.lblVBIconPath.Size = New System.Drawing.Size(56, 13)
        Me.lblVBIconPath.TabIndex = 19
        Me.lblVBIconPath.Text = "Icon Path:"
        '
        'txtVBIconPath
        '
        Me.txtVBIconPath.Location = New System.Drawing.Point(80, 86)
        Me.txtVBIconPath.Name = "txtVBIconPath"
        Me.txtVBIconPath.Size = New System.Drawing.Size(406, 20)
        Me.txtVBIconPath.TabIndex = 18
        '
        'btnVBSelectOutputPath
        '
        Me.btnVBSelectOutputPath.Location = New System.Drawing.Point(492, 58)
        Me.btnVBSelectOutputPath.Name = "btnVBSelectOutputPath"
        Me.btnVBSelectOutputPath.Size = New System.Drawing.Size(34, 23)
        Me.btnVBSelectOutputPath.TabIndex = 17
        Me.btnVBSelectOutputPath.Text = "..."
        Me.btnVBSelectOutputPath.UseVisualStyleBackColor = True
        '
        'lblVBOuptutPath
        '
        Me.lblVBOuptutPath.AutoSize = True
        Me.lblVBOuptutPath.Location = New System.Drawing.Point(7, 63)
        Me.lblVBOuptutPath.Name = "lblVBOuptutPath"
        Me.lblVBOuptutPath.Size = New System.Drawing.Size(67, 13)
        Me.lblVBOuptutPath.TabIndex = 16
        Me.lblVBOuptutPath.Text = "Output Path:"
        '
        'txtVBOutputPath
        '
        Me.txtVBOutputPath.Location = New System.Drawing.Point(80, 60)
        Me.txtVBOutputPath.Name = "txtVBOutputPath"
        Me.txtVBOutputPath.Size = New System.Drawing.Size(406, 20)
        Me.txtVBOutputPath.TabIndex = 15
        '
        'tbCSharp
        '
        Me.tbCSharp.Controls.Add(Me.cbxCSFramework)
        Me.tbCSharp.Controls.Add(Me.lblCSFramework)
        Me.tbCSharp.Controls.Add(Me.chkCSCodeGeneration)
        Me.tbCSharp.Controls.Add(Me.cbxCSTarget)
        Me.tbCSharp.Controls.Add(Me.lblCSAppType)
        Me.tbCSharp.Controls.Add(Me.btnCSRemReference)
        Me.tbCSharp.Controls.Add(Me.btnCSAddReference)
        Me.tbCSharp.Controls.Add(Me.lblCSReferences)
        Me.tbCSharp.Controls.Add(Me.lstCSReferences)
        Me.tbCSharp.Controls.Add(Me.lblCSIconPath)
        Me.tbCSharp.Controls.Add(Me.txtCSIconPath)
        Me.tbCSharp.Controls.Add(Me.lblCSOutpuPath)
        Me.tbCSharp.Controls.Add(Me.txtCSOutputPath)
        Me.tbCSharp.Location = New System.Drawing.Point(4, 24)
        Me.tbCSharp.Name = "tbCSharp"
        Me.tbCSharp.Padding = New System.Windows.Forms.Padding(3)
        Me.tbCSharp.Size = New System.Drawing.Size(532, 243)
        Me.tbCSharp.TabIndex = 1
        Me.tbCSharp.Text = "C# Project Options"
        Me.tbCSharp.UseVisualStyleBackColor = True
        '
        'cbxCSFramework
        '
        Me.cbxCSFramework.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCSFramework.FormattingEnabled = True
        Me.cbxCSFramework.Items.AddRange(New Object() {".NET Framework 2.0", ".NET Framework 3.0", ".NET Framework 3.5", ".NET Framework 4.0"})
        Me.cbxCSFramework.Location = New System.Drawing.Point(80, 33)
        Me.cbxCSFramework.Name = "cbxCSFramework"
        Me.cbxCSFramework.Size = New System.Drawing.Size(446, 21)
        Me.cbxCSFramework.TabIndex = 42
        '
        'lblCSFramework
        '
        Me.lblCSFramework.AutoSize = True
        Me.lblCSFramework.Location = New System.Drawing.Point(7, 36)
        Me.lblCSFramework.Name = "lblCSFramework"
        Me.lblCSFramework.Size = New System.Drawing.Size(62, 13)
        Me.lblCSFramework.TabIndex = 41
        Me.lblCSFramework.Text = "Framework:"
        '
        'chkCSCodeGeneration
        '
        Me.chkCSCodeGeneration.AutoSize = True
        Me.chkCSCodeGeneration.Checked = True
        Me.chkCSCodeGeneration.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCSCodeGeneration.Location = New System.Drawing.Point(370, 218)
        Me.chkCSCodeGeneration.Name = "chkCSCodeGeneration"
        Me.chkCSCodeGeneration.Size = New System.Drawing.Size(156, 17)
        Me.chkCSCodeGeneration.TabIndex = 40
        Me.chkCSCodeGeneration.Text = "Automatic Code Generation"
        Me.chkCSCodeGeneration.UseVisualStyleBackColor = True
        '
        'cbxCSTarget
        '
        Me.cbxCSTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCSTarget.FormattingEnabled = True
        Me.cbxCSTarget.Items.AddRange(New Object() {"Console  Application", "Class Library", "WinForms Application"})
        Me.cbxCSTarget.Location = New System.Drawing.Point(80, 6)
        Me.cbxCSTarget.Name = "cbxCSTarget"
        Me.cbxCSTarget.Size = New System.Drawing.Size(446, 21)
        Me.cbxCSTarget.TabIndex = 39
        '
        'lblCSAppType
        '
        Me.lblCSAppType.AutoSize = True
        Me.lblCSAppType.Location = New System.Drawing.Point(7, 9)
        Me.lblCSAppType.Name = "lblCSAppType"
        Me.lblCSAppType.Size = New System.Drawing.Size(56, 13)
        Me.lblCSAppType.TabIndex = 38
        Me.lblCSAppType.Text = "App Type:"
        '
        'btnCSRemReference
        '
        Me.btnCSRemReference.Location = New System.Drawing.Point(205, 214)
        Me.btnCSRemReference.Name = "btnCSRemReference"
        Me.btnCSRemReference.Size = New System.Drawing.Size(119, 23)
        Me.btnCSRemReference.TabIndex = 37
        Me.btnCSRemReference.Text = "Remove Selected"
        Me.btnCSRemReference.UseVisualStyleBackColor = True
        '
        'btnCSAddReference
        '
        Me.btnCSAddReference.Location = New System.Drawing.Point(80, 214)
        Me.btnCSAddReference.Name = "btnCSAddReference"
        Me.btnCSAddReference.Size = New System.Drawing.Size(119, 23)
        Me.btnCSAddReference.TabIndex = 36
        Me.btnCSAddReference.Text = "Add"
        Me.btnCSAddReference.UseVisualStyleBackColor = True
        '
        'lblCSReferences
        '
        Me.lblCSReferences.AutoSize = True
        Me.lblCSReferences.Location = New System.Drawing.Point(6, 113)
        Me.lblCSReferences.Name = "lblCSReferences"
        Me.lblCSReferences.Size = New System.Drawing.Size(65, 13)
        Me.lblCSReferences.TabIndex = 35
        Me.lblCSReferences.Text = "References:"
        '
        'lstCSReferences
        '
        Me.lstCSReferences.FormattingEnabled = True
        Me.lstCSReferences.Items.AddRange(New Object() {"System.dll", "System.Core.dll", "System.Data.dll", "System.Deployment.dll", "System.Drawing.dll", "System.Windows.Forms.dll", "System.Xml.dll", "System.Xml.Linq.dll"})
        Me.lstCSReferences.Location = New System.Drawing.Point(80, 113)
        Me.lstCSReferences.Name = "lstCSReferences"
        Me.lstCSReferences.Size = New System.Drawing.Size(446, 95)
        Me.lstCSReferences.TabIndex = 34
        '
        'lblCSIconPath
        '
        Me.lblCSIconPath.AutoSize = True
        Me.lblCSIconPath.Location = New System.Drawing.Point(7, 89)
        Me.lblCSIconPath.Name = "lblCSIconPath"
        Me.lblCSIconPath.Size = New System.Drawing.Size(56, 13)
        Me.lblCSIconPath.TabIndex = 33
        Me.lblCSIconPath.Text = "Icon Path:"
        '
        'txtCSIconPath
        '
        Me.txtCSIconPath.Location = New System.Drawing.Point(80, 86)
        Me.txtCSIconPath.Name = "txtCSIconPath"
        Me.txtCSIconPath.Size = New System.Drawing.Size(446, 20)
        Me.txtCSIconPath.TabIndex = 32
        '
        'lblCSOutpuPath
        '
        Me.lblCSOutpuPath.AutoSize = True
        Me.lblCSOutpuPath.Location = New System.Drawing.Point(7, 63)
        Me.lblCSOutpuPath.Name = "lblCSOutpuPath"
        Me.lblCSOutpuPath.Size = New System.Drawing.Size(67, 13)
        Me.lblCSOutpuPath.TabIndex = 31
        Me.lblCSOutpuPath.Text = "Output Path:"
        '
        'txtCSOutputPath
        '
        Me.txtCSOutputPath.Location = New System.Drawing.Point(80, 60)
        Me.txtCSOutputPath.Name = "txtCSOutputPath"
        Me.txtCSOutputPath.Size = New System.Drawing.Size(446, 20)
        Me.txtCSOutputPath.TabIndex = 30
        '
        'tbBatch
        '
        Me.tbBatch.Controls.Add(Me.chkBatchCodeGeneration)
        Me.tbBatch.Location = New System.Drawing.Point(4, 24)
        Me.tbBatch.Name = "tbBatch"
        Me.tbBatch.Padding = New System.Windows.Forms.Padding(3)
        Me.tbBatch.Size = New System.Drawing.Size(532, 243)
        Me.tbBatch.TabIndex = 2
        Me.tbBatch.Text = "Batch File Options"
        Me.tbBatch.UseVisualStyleBackColor = True
        '
        'chkBatchCodeGeneration
        '
        Me.chkBatchCodeGeneration.AutoSize = True
        Me.chkBatchCodeGeneration.Checked = True
        Me.chkBatchCodeGeneration.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBatchCodeGeneration.Location = New System.Drawing.Point(6, 6)
        Me.chkBatchCodeGeneration.Name = "chkBatchCodeGeneration"
        Me.chkBatchCodeGeneration.Size = New System.Drawing.Size(156, 17)
        Me.chkBatchCodeGeneration.TabIndex = 41
        Me.chkBatchCodeGeneration.Text = "Automatic Code Generation"
        Me.chkBatchCodeGeneration.UseVisualStyleBackColor = True
        '
        'tbVBS
        '
        Me.tbVBS.Controls.Add(Me.chkVBSCodeGeneration)
        Me.tbVBS.Location = New System.Drawing.Point(4, 24)
        Me.tbVBS.Name = "tbVBS"
        Me.tbVBS.Padding = New System.Windows.Forms.Padding(3)
        Me.tbVBS.Size = New System.Drawing.Size(532, 243)
        Me.tbVBS.TabIndex = 3
        Me.tbVBS.Text = "VBS File Options"
        Me.tbVBS.UseVisualStyleBackColor = True
        '
        'chkVBSCodeGeneration
        '
        Me.chkVBSCodeGeneration.AutoSize = True
        Me.chkVBSCodeGeneration.Checked = True
        Me.chkVBSCodeGeneration.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkVBSCodeGeneration.Location = New System.Drawing.Point(6, 6)
        Me.chkVBSCodeGeneration.Name = "chkVBSCodeGeneration"
        Me.chkVBSCodeGeneration.Size = New System.Drawing.Size(156, 17)
        Me.chkVBSCodeGeneration.TabIndex = 42
        Me.chkVBSCodeGeneration.Text = "Automatic Code Generation"
        Me.chkVBSCodeGeneration.UseVisualStyleBackColor = True
        '
        'tbWebsite
        '
        Me.tbWebsite.Controls.Add(Me.btnRemoveWebsitePage)
        Me.tbWebsite.Controls.Add(Me.btnAddWebsitePage)
        Me.tbWebsite.Controls.Add(Me.chkCSSGeneration)
        Me.tbWebsite.Controls.Add(Me.chkSeparateCSS)
        Me.tbWebsite.Controls.Add(Me.chkCSSIntegrated)
        Me.tbWebsite.Controls.Add(Me.lblWebsiteInfo)
        Me.tbWebsite.Controls.Add(Me.lstWebsitePages)
        Me.tbWebsite.Controls.Add(Me.chkWebsiteCodeGeneration)
        Me.tbWebsite.Location = New System.Drawing.Point(4, 24)
        Me.tbWebsite.Name = "tbWebsite"
        Me.tbWebsite.Padding = New System.Windows.Forms.Padding(3)
        Me.tbWebsite.Size = New System.Drawing.Size(532, 243)
        Me.tbWebsite.TabIndex = 4
        Me.tbWebsite.Text = "Website Options"
        Me.tbWebsite.UseVisualStyleBackColor = True
        '
        'btnRemoveWebsitePage
        '
        Me.btnRemoveWebsitePage.Location = New System.Drawing.Point(128, 98)
        Me.btnRemoveWebsitePage.Name = "btnRemoveWebsitePage"
        Me.btnRemoveWebsitePage.Size = New System.Drawing.Size(119, 23)
        Me.btnRemoveWebsitePage.TabIndex = 49
        Me.btnRemoveWebsitePage.Text = "Remove Selected"
        Me.btnRemoveWebsitePage.UseVisualStyleBackColor = True
        '
        'btnAddWebsitePage
        '
        Me.btnAddWebsitePage.Location = New System.Drawing.Point(3, 98)
        Me.btnAddWebsitePage.Name = "btnAddWebsitePage"
        Me.btnAddWebsitePage.Size = New System.Drawing.Size(119, 23)
        Me.btnAddWebsitePage.TabIndex = 48
        Me.btnAddWebsitePage.Text = "Add"
        Me.btnAddWebsitePage.UseVisualStyleBackColor = True
        '
        'chkCSSGeneration
        '
        Me.chkCSSGeneration.AutoSize = True
        Me.chkCSSGeneration.Checked = True
        Me.chkCSSGeneration.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCSSGeneration.Location = New System.Drawing.Point(6, 153)
        Me.chkCSSGeneration.Name = "chkCSSGeneration"
        Me.chkCSSGeneration.Size = New System.Drawing.Size(125, 17)
        Me.chkCSSGeneration.TabIndex = 47
        Me.chkCSSGeneration.Text = "Generate CSS Styles"
        Me.chkCSSGeneration.UseVisualStyleBackColor = True
        '
        'chkSeparateCSS
        '
        Me.chkSeparateCSS.AutoSize = True
        Me.chkSeparateCSS.Location = New System.Drawing.Point(156, 176)
        Me.chkSeparateCSS.Name = "chkSeparateCSS"
        Me.chkSeparateCSS.Size = New System.Drawing.Size(206, 17)
        Me.chkSeparateCSS.TabIndex = 46
        Me.chkSeparateCSS.Text = "Generate a separate CSS file for styles"
        Me.chkSeparateCSS.UseVisualStyleBackColor = True
        '
        'chkCSSIntegrated
        '
        Me.chkCSSIntegrated.AutoSize = True
        Me.chkCSSIntegrated.Checked = True
        Me.chkCSSIntegrated.Location = New System.Drawing.Point(27, 176)
        Me.chkCSSIntegrated.Name = "chkCSSIntegrated"
        Me.chkCSSIntegrated.Size = New System.Drawing.Size(123, 17)
        Me.chkCSSIntegrated.TabIndex = 45
        Me.chkCSSIntegrated.TabStop = True
        Me.chkCSSIntegrated.Text = "Use integrated styles"
        Me.chkCSSIntegrated.UseVisualStyleBackColor = True
        '
        'lblWebsiteInfo
        '
        Me.lblWebsiteInfo.AutoSize = True
        Me.lblWebsiteInfo.Location = New System.Drawing.Point(2, 5)
        Me.lblWebsiteInfo.Name = "lblWebsiteInfo"
        Me.lblWebsiteInfo.Size = New System.Drawing.Size(366, 13)
        Me.lblWebsiteInfo.TabIndex = 44
        Me.lblWebsiteInfo.Text = "Please add the names of webpages which you want to create in this project:"
        '
        'lstWebsitePages
        '
        Me.lstWebsitePages.FormattingEnabled = True
        Me.lstWebsitePages.Items.AddRange(New Object() {"index.html"})
        Me.lstWebsitePages.Location = New System.Drawing.Point(3, 23)
        Me.lstWebsitePages.Name = "lstWebsitePages"
        Me.lstWebsitePages.Size = New System.Drawing.Size(520, 69)
        Me.lstWebsitePages.TabIndex = 43
        '
        'chkWebsiteCodeGeneration
        '
        Me.chkWebsiteCodeGeneration.AutoSize = True
        Me.chkWebsiteCodeGeneration.Checked = True
        Me.chkWebsiteCodeGeneration.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkWebsiteCodeGeneration.Location = New System.Drawing.Point(6, 129)
        Me.chkWebsiteCodeGeneration.Name = "chkWebsiteCodeGeneration"
        Me.chkWebsiteCodeGeneration.Size = New System.Drawing.Size(215, 17)
        Me.chkWebsiteCodeGeneration.TabIndex = 42
        Me.chkWebsiteCodeGeneration.Text = "Automatic Webpage && Code Generation"
        Me.chkWebsiteCodeGeneration.UseVisualStyleBackColor = True
        '
        'frmNewProject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(564, 480)
        Me.Controls.Add(Me.tcMain)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtProjectLocation)
        Me.Controls.Add(Me.txtProjectName)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.btnCreateProject)
        Me.Controls.Add(Me.lvwMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNewProject"
        Me.Text = "Create a new project"
        Me.tcMain.ResumeLayout(False)
        Me.tbVB.ResumeLayout(False)
        Me.tbVB.PerformLayout()
        Me.tbCSharp.ResumeLayout(False)
        Me.tbCSharp.PerformLayout()
        Me.tbBatch.ResumeLayout(False)
        Me.tbBatch.PerformLayout()
        Me.tbVBS.ResumeLayout(False)
        Me.tbVBS.PerformLayout()
        Me.tbWebsite.ResumeLayout(False)
        Me.tbWebsite.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvwMain As System.Windows.Forms.ListView
    Friend WithEvents ilMain As System.Windows.Forms.ImageList
    Friend WithEvents btnCreateProject As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents txtProjectName As System.Windows.Forms.TextBox
    Friend WithEvents txtProjectLocation As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents tcMain As System.Windows.Forms.TabControl
    Friend WithEvents tbVB As System.Windows.Forms.TabPage
    Friend WithEvents tbCSharp As System.Windows.Forms.TabPage
    Friend WithEvents tbBatch As System.Windows.Forms.TabPage
    Friend WithEvents tbVBS As System.Windows.Forms.TabPage
    Friend WithEvents tbWebsite As System.Windows.Forms.TabPage
    Friend WithEvents chkVBCodeGeneration As System.Windows.Forms.CheckBox
    Friend WithEvents cbxVBTarget As System.Windows.Forms.ComboBox
    Friend WithEvents lblVBAppType As System.Windows.Forms.Label
    Friend WithEvents btnVBRemReference As System.Windows.Forms.Button
    Friend WithEvents btnVBAddReference As System.Windows.Forms.Button
    Friend WithEvents lblVBReferences As System.Windows.Forms.Label
    Friend WithEvents lstVBReferences As System.Windows.Forms.ListBox
    Friend WithEvents btnVBSelectIconPath As System.Windows.Forms.Button
    Friend WithEvents lblVBIconPath As System.Windows.Forms.Label
    Friend WithEvents txtVBIconPath As System.Windows.Forms.TextBox
    Friend WithEvents btnVBSelectOutputPath As System.Windows.Forms.Button
    Friend WithEvents lblVBOuptutPath As System.Windows.Forms.Label
    Friend WithEvents txtVBOutputPath As System.Windows.Forms.TextBox
    Friend WithEvents chkBatchCodeGeneration As System.Windows.Forms.CheckBox
    Friend WithEvents chkVBSCodeGeneration As System.Windows.Forms.CheckBox
    Friend WithEvents btnRemoveWebsitePage As System.Windows.Forms.Button
    Friend WithEvents btnAddWebsitePage As System.Windows.Forms.Button
    Friend WithEvents chkCSSGeneration As System.Windows.Forms.CheckBox
    Friend WithEvents chkSeparateCSS As System.Windows.Forms.RadioButton
    Friend WithEvents chkCSSIntegrated As System.Windows.Forms.RadioButton
    Friend WithEvents lblWebsiteInfo As System.Windows.Forms.Label
    Friend WithEvents lstWebsitePages As System.Windows.Forms.ListBox
    Friend WithEvents chkWebsiteCodeGeneration As System.Windows.Forms.CheckBox
    Friend WithEvents cbxVBFramework As System.Windows.Forms.ComboBox
    Friend WithEvents lblVBFramework As System.Windows.Forms.Label
    Friend WithEvents cbxCSFramework As System.Windows.Forms.ComboBox
    Friend WithEvents lblCSFramework As System.Windows.Forms.Label
    Friend WithEvents chkCSCodeGeneration As System.Windows.Forms.CheckBox
    Friend WithEvents cbxCSTarget As System.Windows.Forms.ComboBox
    Friend WithEvents lblCSAppType As System.Windows.Forms.Label
    Friend WithEvents btnCSRemReference As System.Windows.Forms.Button
    Friend WithEvents btnCSAddReference As System.Windows.Forms.Button
    Friend WithEvents lblCSReferences As System.Windows.Forms.Label
    Friend WithEvents lstCSReferences As System.Windows.Forms.ListBox
    Friend WithEvents lblCSIconPath As System.Windows.Forms.Label
    Friend WithEvents txtCSIconPath As System.Windows.Forms.TextBox
    Friend WithEvents lblCSOutpuPath As System.Windows.Forms.Label
    Friend WithEvents txtCSOutputPath As System.Windows.Forms.TextBox
End Class
