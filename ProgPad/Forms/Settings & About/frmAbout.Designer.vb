<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbout
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
        Dim ListViewItem11 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"EthernalCompiler - CodeDom Compiler", "Ethernal Five on HackForums"}, -1)
        Dim ListViewItem12 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"vtExtender -ToolStrip Extension Class", "John Underhill (Steppenwolfe)"}, -1)
        Dim ListViewItem13 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Icons", "Softicons.com"}, -1)
        Dim ListViewItem14 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"localhostr Uploading", "Perplexity and idb on HackForums"}, -1)
        Dim ListViewItem15 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Document compression and encryption", "SevenZipSharp and 7zip"}, -1)
        Dim ListViewItem16 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Extended TabControl", "http://www.codeproject.com/Articles/91387/Painting-Your-Own-Tabs-Second-Edition"}, -1)
        Dim ListViewItem17 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Docking", "http://sourceforge.net/projects/dockpanelsuite/"}, -1)
        Dim ListViewItem18 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Color Picker ComboBox", "http://www.codeproject.com/Articles/29824/ColorPicker-ColorPicker-with-a-compact-" & _
                "footprint-V"}, -1)
        Dim ListViewItem19 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"FTP Library", "http://ftplib.codeplex.com/"}, -1)
        Dim ListViewItem20 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Shell Icon Retrieval", "http://glassocean.net/Fhow-to-create-a-treeview-file-browser-component-in-vb-net-" & _
                "part-2"}, -1)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbout))
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.pbMain = New System.Windows.Forms.PictureBox()
        Me.lvwCodeInfo = New System.Windows.Forms.ListView()
        Me.clmnName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clmnBy = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtChangelog = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.pbMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblMsg
        '
        Me.lblMsg.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMsg.Font = New System.Drawing.Font("Cooper Black", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsg.Location = New System.Drawing.Point(12, 6)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(384, 23)
        Me.lblMsg.TabIndex = 15
        Me.lblMsg.Text = "NeoIDE"
        Me.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbMain
        '
        Me.pbMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pbMain.ImageLocation = ""
        Me.pbMain.Location = New System.Drawing.Point(12, 32)
        Me.pbMain.Name = "pbMain"
        Me.pbMain.Size = New System.Drawing.Size(166, 134)
        Me.pbMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbMain.TabIndex = 28
        Me.pbMain.TabStop = False
        '
        'lvwCodeInfo
        '
        Me.lvwCodeInfo.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clmnName, Me.clmnBy})
        Me.lvwCodeInfo.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem11, ListViewItem12, ListViewItem13, ListViewItem14, ListViewItem15, ListViewItem16, ListViewItem17, ListViewItem18, ListViewItem19, ListViewItem20})
        Me.lvwCodeInfo.Location = New System.Drawing.Point(12, 368)
        Me.lvwCodeInfo.Name = "lvwCodeInfo"
        Me.lvwCodeInfo.Size = New System.Drawing.Size(384, 167)
        Me.lvwCodeInfo.TabIndex = 31
        Me.lvwCodeInfo.UseCompatibleStateImageBehavior = False
        Me.lvwCodeInfo.View = System.Windows.Forms.View.Details
        '
        'clmnName
        '
        Me.clmnName.Text = "Name:"
        Me.clmnName.Width = 198
        '
        'clmnBy
        '
        Me.clmnBy.Text = "By/Website:"
        Me.clmnBy.Width = 511
        '
        'txtChangelog
        '
        Me.txtChangelog.Location = New System.Drawing.Point(12, 175)
        Me.txtChangelog.Multiline = True
        Me.txtChangelog.Name = "txtChangelog"
        Me.txtChangelog.ReadOnly = True
        Me.txtChangelog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtChangelog.Size = New System.Drawing.Size(384, 167)
        Me.txtChangelog.TabIndex = 34
        Me.txtChangelog.Text = resources.GetString("txtChangelog.Text")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 352)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 13)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "My thanks go out to:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(187, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(173, 13)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Written by: Ingenuity/Jack Eagles1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(187, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 13)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Version: v1.0a"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(187, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "Version: v1.0a"
        '
        'frmAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(410, 547)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lvwCodeInfo)
        Me.Controls.Add(Me.txtChangelog)
        Me.Controls.Add(Me.pbMain)
        Me.Controls.Add(Me.lblMsg)
        Me.Name = "frmAbout"
        Me.Text = "About"
        CType(Me.pbMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents pbMain As System.Windows.Forms.PictureBox
    Friend WithEvents lvwCodeInfo As System.Windows.Forms.ListView
    Friend WithEvents clmnName As System.Windows.Forms.ColumnHeader
    Friend WithEvents clmnBy As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtChangelog As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
