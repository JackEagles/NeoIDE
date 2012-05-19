<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGetExtensions
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
        Dim CharStyle1 As NeoIDE.ExtendedRichTextBox.CharStyle = New NeoIDE.ExtendedRichTextBox.CharStyle()
        Dim ParaLineSpacing1 As NeoIDE.ExtendedRichTextBox.ParaLineSpacing = New NeoIDE.ExtendedRichTextBox.ParaLineSpacing()
        Dim ParaListStyle1 As NeoIDE.ExtendedRichTextBox.ParaListStyle = New NeoIDE.ExtendedRichTextBox.ParaListStyle()
        Me.tcMain = New System.Windows.Forms.TabControl()
        Me.tbAddons = New System.Windows.Forms.TabPage()
        Me.tbThemes = New System.Windows.Forms.TabPage()
        Me.tbInstalled = New System.Windows.Forms.TabPage()
        Me.tcInstalled = New System.Windows.Forms.TabControl()
        Me.tbInstalledAddons = New System.Windows.Forms.TabPage()
        Me.tvInstalledAddons = New System.Windows.Forms.TreeView()
        Me.tbInstalledThemes = New System.Windows.Forms.TabPage()
        Me.tbAddonDetails = New System.Windows.Forms.TabPage()
        Me.lblPreview = New System.Windows.Forms.Label()
        Me.lblAuthor = New System.Windows.Forms.LinkLabel()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.lblAddonDescription = New System.Windows.Forms.Label()
        Me.lblAddonName = New System.Windows.Forms.Label()
        Me.btnInstallAddon = New System.Windows.Forms.Button()
        Me.pbAddonLargeImage = New System.Windows.Forms.PictureBox()
        Me.tbDownloadingAddon = New System.Windows.Forms.TabPage()
        Me.txtAddonEvents = New System.Windows.Forms.TextBox()
        Me.lblDownloaded = New System.Windows.Forms.Label()
        Me.lblDownloadingAddon = New System.Windows.Forms.Label()
        Me.pbAddonDownloading = New System.Windows.Forms.ProgressBar()
        Me.tbDownloadingTheme = New System.Windows.Forms.TabPage()
        Me.pbLoadingPlugins = New System.Windows.Forms.ProgressBar()
        Me.lblDownloading = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnUninstallSelected = New System.Windows.Forms.Button()
        Me.AddonContainer = New NeoIDE.AddonButtonContainer()
        Me.ThemeContainer = New NeoIDE.AddonButtonContainer()
        Me.txtAddonDescription = New NeoIDE.ExtendedRichTextBox()
        Me.tcMain.SuspendLayout()
        Me.tbAddons.SuspendLayout()
        Me.tbThemes.SuspendLayout()
        Me.tbInstalled.SuspendLayout()
        Me.tcInstalled.SuspendLayout()
        Me.tbInstalledAddons.SuspendLayout()
        Me.tbAddonDetails.SuspendLayout()
        CType(Me.pbAddonLargeImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbDownloadingAddon.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcMain
        '
        Me.tcMain.Controls.Add(Me.tbAddons)
        Me.tcMain.Controls.Add(Me.tbThemes)
        Me.tcMain.Controls.Add(Me.tbInstalled)
        Me.tcMain.Controls.Add(Me.tbAddonDetails)
        Me.tcMain.Controls.Add(Me.tbDownloadingAddon)
        Me.tcMain.Controls.Add(Me.tbDownloadingTheme)
        Me.tcMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcMain.Location = New System.Drawing.Point(0, 0)
        Me.tcMain.Name = "tcMain"
        Me.tcMain.SelectedIndex = 0
        Me.tcMain.Size = New System.Drawing.Size(811, 301)
        Me.tcMain.TabIndex = 0
        '
        'tbAddons
        '
        Me.tbAddons.Controls.Add(Me.AddonContainer)
        Me.tbAddons.Location = New System.Drawing.Point(4, 22)
        Me.tbAddons.Name = "tbAddons"
        Me.tbAddons.Padding = New System.Windows.Forms.Padding(3)
        Me.tbAddons.Size = New System.Drawing.Size(803, 275)
        Me.tbAddons.TabIndex = 0
        Me.tbAddons.Text = "Get Addons"
        Me.tbAddons.UseVisualStyleBackColor = True
        '
        'tbThemes
        '
        Me.tbThemes.Controls.Add(Me.ThemeContainer)
        Me.tbThemes.Location = New System.Drawing.Point(4, 22)
        Me.tbThemes.Name = "tbThemes"
        Me.tbThemes.Padding = New System.Windows.Forms.Padding(3)
        Me.tbThemes.Size = New System.Drawing.Size(803, 275)
        Me.tbThemes.TabIndex = 1
        Me.tbThemes.Text = "Get Themes"
        Me.tbThemes.UseVisualStyleBackColor = True
        '
        'tbInstalled
        '
        Me.tbInstalled.Controls.Add(Me.tcInstalled)
        Me.tbInstalled.Location = New System.Drawing.Point(4, 22)
        Me.tbInstalled.Name = "tbInstalled"
        Me.tbInstalled.Padding = New System.Windows.Forms.Padding(3)
        Me.tbInstalled.Size = New System.Drawing.Size(803, 275)
        Me.tbInstalled.TabIndex = 3
        Me.tbInstalled.Text = "Installed Themes && Addons"
        Me.tbInstalled.UseVisualStyleBackColor = True
        '
        'tcInstalled
        '
        Me.tcInstalled.Controls.Add(Me.tbInstalledAddons)
        Me.tcInstalled.Controls.Add(Me.tbInstalledThemes)
        Me.tcInstalled.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcInstalled.Location = New System.Drawing.Point(3, 3)
        Me.tcInstalled.Name = "tcInstalled"
        Me.tcInstalled.SelectedIndex = 0
        Me.tcInstalled.Size = New System.Drawing.Size(797, 269)
        Me.tcInstalled.TabIndex = 0
        '
        'tbInstalledAddons
        '
        Me.tbInstalledAddons.Controls.Add(Me.btnUninstallSelected)
        Me.tbInstalledAddons.Controls.Add(Me.Button1)
        Me.tbInstalledAddons.Controls.Add(Me.tvInstalledAddons)
        Me.tbInstalledAddons.Location = New System.Drawing.Point(4, 22)
        Me.tbInstalledAddons.Name = "tbInstalledAddons"
        Me.tbInstalledAddons.Padding = New System.Windows.Forms.Padding(3)
        Me.tbInstalledAddons.Size = New System.Drawing.Size(789, 243)
        Me.tbInstalledAddons.TabIndex = 0
        Me.tbInstalledAddons.Text = "Installed Addons"
        Me.tbInstalledAddons.UseVisualStyleBackColor = True
        '
        'tvInstalledAddons
        '
        Me.tvInstalledAddons.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tvInstalledAddons.Location = New System.Drawing.Point(3, 3)
        Me.tvInstalledAddons.Name = "tvInstalledAddons"
        Me.tvInstalledAddons.Size = New System.Drawing.Size(783, 209)
        Me.tvInstalledAddons.TabIndex = 0
        '
        'tbInstalledThemes
        '
        Me.tbInstalledThemes.Location = New System.Drawing.Point(4, 22)
        Me.tbInstalledThemes.Name = "tbInstalledThemes"
        Me.tbInstalledThemes.Padding = New System.Windows.Forms.Padding(3)
        Me.tbInstalledThemes.Size = New System.Drawing.Size(789, 243)
        Me.tbInstalledThemes.TabIndex = 1
        Me.tbInstalledThemes.Text = "Installed Themes"
        Me.tbInstalledThemes.UseVisualStyleBackColor = True
        '
        'tbAddonDetails
        '
        Me.tbAddonDetails.Controls.Add(Me.lblPreview)
        Me.tbAddonDetails.Controls.Add(Me.lblAuthor)
        Me.tbAddonDetails.Controls.Add(Me.btnBack)
        Me.tbAddonDetails.Controls.Add(Me.lblAddonDescription)
        Me.tbAddonDetails.Controls.Add(Me.lblAddonName)
        Me.tbAddonDetails.Controls.Add(Me.txtAddonDescription)
        Me.tbAddonDetails.Controls.Add(Me.btnInstallAddon)
        Me.tbAddonDetails.Controls.Add(Me.pbAddonLargeImage)
        Me.tbAddonDetails.Location = New System.Drawing.Point(4, 22)
        Me.tbAddonDetails.Name = "tbAddonDetails"
        Me.tbAddonDetails.Padding = New System.Windows.Forms.Padding(3)
        Me.tbAddonDetails.Size = New System.Drawing.Size(803, 275)
        Me.tbAddonDetails.TabIndex = 2
        Me.tbAddonDetails.Text = "Addon Details"
        Me.tbAddonDetails.UseVisualStyleBackColor = True
        '
        'lblPreview
        '
        Me.lblPreview.AutoSize = True
        Me.lblPreview.Location = New System.Drawing.Point(4, 2)
        Me.lblPreview.Name = "lblPreview"
        Me.lblPreview.Size = New System.Drawing.Size(48, 13)
        Me.lblPreview.TabIndex = 7
        Me.lblPreview.Text = "Preview:"
        '
        'lblAuthor
        '
        Me.lblAuthor.AutoSize = True
        Me.lblAuthor.Location = New System.Drawing.Point(267, 42)
        Me.lblAuthor.Name = "lblAuthor"
        Me.lblAuthor.Size = New System.Drawing.Size(41, 13)
        Me.lblAuthor.TabIndex = 6
        Me.lblAuthor.TabStop = True
        Me.lblAuthor.Text = "Author:"
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(580, 247)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(105, 25)
        Me.btnBack.TabIndex = 5
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'lblAddonDescription
        '
        Me.lblAddonDescription.AutoSize = True
        Me.lblAddonDescription.Location = New System.Drawing.Point(267, 61)
        Me.lblAddonDescription.Name = "lblAddonDescription"
        Me.lblAddonDescription.Size = New System.Drawing.Size(63, 13)
        Me.lblAddonDescription.TabIndex = 4
        Me.lblAddonDescription.Text = "Description:"
        '
        'lblAddonName
        '
        Me.lblAddonName.AutoSize = True
        Me.lblAddonName.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddonName.Location = New System.Drawing.Point(265, 14)
        Me.lblAddonName.Name = "lblAddonName"
        Me.lblAddonName.Size = New System.Drawing.Size(130, 25)
        Me.lblAddonName.TabIndex = 3
        Me.lblAddonName.Text = "AddonName"
        '
        'btnInstallAddon
        '
        Me.btnInstallAddon.Location = New System.Drawing.Point(690, 247)
        Me.btnInstallAddon.Name = "btnInstallAddon"
        Me.btnInstallAddon.Size = New System.Drawing.Size(105, 25)
        Me.btnInstallAddon.TabIndex = 1
        Me.btnInstallAddon.Text = "Install"
        Me.btnInstallAddon.UseVisualStyleBackColor = True
        '
        'pbAddonLargeImage
        '
        Me.pbAddonLargeImage.Location = New System.Drawing.Point(7, 16)
        Me.pbAddonLargeImage.Name = "pbAddonLargeImage"
        Me.pbAddonLargeImage.Size = New System.Drawing.Size(256, 256)
        Me.pbAddonLargeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbAddonLargeImage.TabIndex = 0
        Me.pbAddonLargeImage.TabStop = False
        '
        'tbDownloadingAddon
        '
        Me.tbDownloadingAddon.Controls.Add(Me.txtAddonEvents)
        Me.tbDownloadingAddon.Controls.Add(Me.lblDownloaded)
        Me.tbDownloadingAddon.Controls.Add(Me.lblDownloadingAddon)
        Me.tbDownloadingAddon.Controls.Add(Me.pbAddonDownloading)
        Me.tbDownloadingAddon.Location = New System.Drawing.Point(4, 22)
        Me.tbDownloadingAddon.Name = "tbDownloadingAddon"
        Me.tbDownloadingAddon.Padding = New System.Windows.Forms.Padding(3)
        Me.tbDownloadingAddon.Size = New System.Drawing.Size(803, 275)
        Me.tbDownloadingAddon.TabIndex = 4
        Me.tbDownloadingAddon.Text = "Downloading && Installing Addon"
        Me.tbDownloadingAddon.UseVisualStyleBackColor = True
        '
        'txtAddonEvents
        '
        Me.txtAddonEvents.Location = New System.Drawing.Point(8, 35)
        Me.txtAddonEvents.Multiline = True
        Me.txtAddonEvents.Name = "txtAddonEvents"
        Me.txtAddonEvents.Size = New System.Drawing.Size(787, 195)
        Me.txtAddonEvents.TabIndex = 4
        '
        'lblDownloaded
        '
        Me.lblDownloaded.AutoSize = True
        Me.lblDownloaded.Location = New System.Drawing.Point(6, 233)
        Me.lblDownloaded.Name = "lblDownloaded"
        Me.lblDownloaded.Size = New System.Drawing.Size(126, 13)
        Me.lblDownloaded.TabIndex = 3
        Me.lblDownloaded.Text = "Downloaded: 0kb/327kb"
        '
        'lblDownloadingAddon
        '
        Me.lblDownloadingAddon.AutoSize = True
        Me.lblDownloadingAddon.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDownloadingAddon.Location = New System.Drawing.Point(5, 8)
        Me.lblDownloadingAddon.Name = "lblDownloadingAddon"
        Me.lblDownloadingAddon.Size = New System.Drawing.Size(126, 24)
        Me.lblDownloadingAddon.TabIndex = 2
        Me.lblDownloadingAddon.Text = "Downloading:"
        '
        'pbAddonDownloading
        '
        Me.pbAddonDownloading.Location = New System.Drawing.Point(8, 249)
        Me.pbAddonDownloading.Name = "pbAddonDownloading"
        Me.pbAddonDownloading.Size = New System.Drawing.Size(789, 23)
        Me.pbAddonDownloading.TabIndex = 1
        '
        'tbDownloadingTheme
        '
        Me.tbDownloadingTheme.Location = New System.Drawing.Point(4, 22)
        Me.tbDownloadingTheme.Name = "tbDownloadingTheme"
        Me.tbDownloadingTheme.Padding = New System.Windows.Forms.Padding(3)
        Me.tbDownloadingTheme.Size = New System.Drawing.Size(803, 275)
        Me.tbDownloadingTheme.TabIndex = 5
        Me.tbDownloadingTheme.Text = "Downloading && Installing theme"
        Me.tbDownloadingTheme.UseVisualStyleBackColor = True
        '
        'pbLoadingPlugins
        '
        Me.pbLoadingPlugins.Location = New System.Drawing.Point(708, 2)
        Me.pbLoadingPlugins.MarqueeAnimationSpeed = 70
        Me.pbLoadingPlugins.Name = "pbLoadingPlugins"
        Me.pbLoadingPlugins.Size = New System.Drawing.Size(100, 17)
        Me.pbLoadingPlugins.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbLoadingPlugins.TabIndex = 2
        '
        'lblDownloading
        '
        Me.lblDownloading.AutoSize = True
        Me.lblDownloading.Location = New System.Drawing.Point(591, 4)
        Me.lblDownloading.Name = "lblDownloading"
        Me.lblDownloading.Size = New System.Drawing.Size(117, 13)
        Me.lblDownloading.TabIndex = 3
        Me.lblDownloading.Text = "Downloading addon list"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(3, 215)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(130, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Check for Updates"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnUninstallSelected
        '
        Me.btnUninstallSelected.Location = New System.Drawing.Point(139, 215)
        Me.btnUninstallSelected.Name = "btnUninstallSelected"
        Me.btnUninstallSelected.Size = New System.Drawing.Size(130, 23)
        Me.btnUninstallSelected.TabIndex = 2
        Me.btnUninstallSelected.Text = "Uninstall Selected"
        Me.btnUninstallSelected.UseVisualStyleBackColor = True
        '
        'AddonContainer
        '
        Me.AddonContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AddonContainer.Location = New System.Drawing.Point(3, 3)
        Me.AddonContainer.Name = "AddonContainer"
        Me.AddonContainer.Size = New System.Drawing.Size(797, 269)
        Me.AddonContainer.TabIndex = 0
        '
        'ThemeContainer
        '
        Me.ThemeContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ThemeContainer.Location = New System.Drawing.Point(3, 3)
        Me.ThemeContainer.Name = "ThemeContainer"
        Me.ThemeContainer.Size = New System.Drawing.Size(797, 269)
        Me.ThemeContainer.TabIndex = 1
        '
        'txtAddonDescription
        '
        Me.txtAddonDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddonDescription.Location = New System.Drawing.Point(270, 77)
        Me.txtAddonDescription.Name = "txtAddonDescription"
        Me.txtAddonDescription.ReadOnly = True
        CharStyle1.Bold = False
        CharStyle1.Italic = False
        CharStyle1.Link = False
        CharStyle1.Strikeout = False
        CharStyle1.Underline = False
        Me.txtAddonDescription.SelectionCharStyle = CharStyle1
        Me.txtAddonDescription.SelectionFont2 = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Inch)
        ParaLineSpacing1.ExactSpacing = 0
        ParaLineSpacing1.SpacingStyle = NeoIDE.ExtendedRichTextBox.ParaLineSpacing.LineSpacingStyle.Unknown
        Me.txtAddonDescription.SelectionLineSpacing = ParaLineSpacing1
        ParaListStyle1.BulletCharCode = CType(0, Short)
        ParaListStyle1.NumberingStart = CType(0, Short)
        ParaListStyle1.Style = NeoIDE.ExtendedRichTextBox.ParaListStyle.ListStyle.NumberAndParenthesis
        ParaListStyle1.Type = NeoIDE.ExtendedRichTextBox.ParaListStyle.ListType.None
        Me.txtAddonDescription.SelectionListType = ParaListStyle1
        Me.txtAddonDescription.SelectionOffsetType = NeoIDE.ExtendedRichTextBox.OffsetType.None
        Me.txtAddonDescription.SelectionSpaceAfter = 0
        Me.txtAddonDescription.SelectionSpaceBefore = 0
        Me.txtAddonDescription.Size = New System.Drawing.Size(525, 167)
        Me.txtAddonDescription.TabIndex = 2
        Me.txtAddonDescription.Text = ""
        '
        'frmGetExtensions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(811, 301)
        Me.Controls.Add(Me.lblDownloading)
        Me.Controls.Add(Me.pbLoadingPlugins)
        Me.Controls.Add(Me.tcMain)
        Me.Name = "frmGetExtensions"
        Me.Text = "Manage Addons & Themes for NeoIDE"
        Me.tcMain.ResumeLayout(False)
        Me.tbAddons.ResumeLayout(False)
        Me.tbThemes.ResumeLayout(False)
        Me.tbInstalled.ResumeLayout(False)
        Me.tcInstalled.ResumeLayout(False)
        Me.tbInstalledAddons.ResumeLayout(False)
        Me.tbAddonDetails.ResumeLayout(False)
        Me.tbAddonDetails.PerformLayout()
        CType(Me.pbAddonLargeImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbDownloadingAddon.ResumeLayout(False)
        Me.tbDownloadingAddon.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tcMain As System.Windows.Forms.TabControl
    Friend WithEvents tbAddons As System.Windows.Forms.TabPage
    Friend WithEvents AddonContainer As NeoIDE.AddonButtonContainer
    Friend WithEvents tbThemes As System.Windows.Forms.TabPage
    Friend WithEvents ThemeContainer As NeoIDE.AddonButtonContainer
    Friend WithEvents tbAddonDetails As System.Windows.Forms.TabPage
    Friend WithEvents btnInstallAddon As System.Windows.Forms.Button
    Friend WithEvents pbAddonLargeImage As System.Windows.Forms.PictureBox
    Friend WithEvents txtAddonDescription As NeoIDE.ExtendedRichTextBox
    Friend WithEvents lblAddonDescription As System.Windows.Forms.Label
    Friend WithEvents lblAddonName As System.Windows.Forms.Label
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents pbLoadingPlugins As System.Windows.Forms.ProgressBar
    Friend WithEvents lblDownloading As System.Windows.Forms.Label
    Friend WithEvents lblAuthor As System.Windows.Forms.LinkLabel
    Friend WithEvents lblPreview As System.Windows.Forms.Label
    Friend WithEvents tbInstalled As System.Windows.Forms.TabPage
    Friend WithEvents tbDownloadingAddon As System.Windows.Forms.TabPage
    Friend WithEvents tbDownloadingTheme As System.Windows.Forms.TabPage
    Friend WithEvents tcInstalled As System.Windows.Forms.TabControl
    Friend WithEvents tbInstalledAddons As System.Windows.Forms.TabPage
    Friend WithEvents tvInstalledAddons As System.Windows.Forms.TreeView
    Friend WithEvents tbInstalledThemes As System.Windows.Forms.TabPage
    Friend WithEvents lblDownloaded As System.Windows.Forms.Label
    Friend WithEvents lblDownloadingAddon As System.Windows.Forms.Label
    Friend WithEvents pbAddonDownloading As System.Windows.Forms.ProgressBar
    Friend WithEvents txtAddonEvents As System.Windows.Forms.TextBox
    Friend WithEvents btnUninstallSelected As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
