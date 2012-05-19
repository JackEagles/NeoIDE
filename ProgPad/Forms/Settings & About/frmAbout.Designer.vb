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
        Me.components = New System.ComponentModel.Container()
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"EthernalCompiler - CodeDom Compiler", "Ethernal Five on HackForums"}, -1)
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"vtExtender -ToolStrip Extension Class", "John Underhill (Steppenwolfe)"}, -1)
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Icons", "Softicons.com"}, -1)
        Dim ListViewItem4 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"localhostr Uploading", "Perplexity and idb on HackForums"}, -1)
        Dim ListViewItem5 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Document compression and encryption", "SevenZipSharp and 7zip"}, -1)
        Dim ListViewItem6 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Extended TabControl", "http://www.codeproject.com/Articles/91387/Painting-Your-Own-Tabs-Second-Edition"}, -1)
        Dim ListViewItem7 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Docking", "http://sourceforge.net/projects/dockpanelsuite/"}, -1)
        Dim ListViewItem8 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Color Picker ComboBox", "http://www.codeproject.com/Articles/29824/ColorPicker-ColorPicker-with-a-compact-" & _
                        "footprint-V"}, -1)
        Dim ListViewItem9 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"FTP Library", "http://ftplib.codeplex.com/"}, -1)
        Dim ListViewItem10 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Shell Icon Retrieval", "http://glassocean.net/Fhow-to-create-a-treeview-file-browser-component-in-vb-net-" & _
                        "part-2"}, -1)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbout))
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tmrScroll = New System.Windows.Forms.Timer(Me.components)
        Me.pbMain = New System.Windows.Forms.PictureBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lvwCodeInfo = New System.Windows.Forms.ListView()
        Me.clmnName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clmnBy = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnCodeInfo = New System.Windows.Forms.Button()
        Me.btnChangelog = New System.Windows.Forms.Button()
        Me.txtChangelog = New System.Windows.Forms.TextBox()
        CType(Me.pbMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblMsg
        '
        Me.lblMsg.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMsg.Font = New System.Drawing.Font("Cooper Black", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsg.Location = New System.Drawing.Point(12, 236)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(738, 23)
        Me.lblMsg.TabIndex = 15
        Me.lblMsg.Text = "NeoIDE v0.5"
        Me.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Font = New System.Drawing.Font("Cooper Black", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 336)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(738, 18)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "TextMate"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.Font = New System.Drawing.Font("Cooper Black", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 301)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(738, 18)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Credits for ideas go to:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Font = New System.Drawing.Font("Cooper Black", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 267)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(738, 18)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Written by Jack Eagles1"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Cooper Black", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 319)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(738, 18)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Notepad++"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tmrScroll
        '
        Me.tmrScroll.Enabled = True
        Me.tmrScroll.Interval = 20
        '
        'pbMain
        '
        Me.pbMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pbMain.ImageLocation = ""
        Me.pbMain.Location = New System.Drawing.Point(12, 12)
        Me.pbMain.Name = "pbMain"
        Me.pbMain.Size = New System.Drawing.Size(739, 134)
        Me.pbMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbMain.TabIndex = 28
        Me.pbMain.TabStop = False
        '
        'Label10
        '
        Me.Label10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.Font = New System.Drawing.Font("Cooper Black", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(12, 354)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(738, 18)
        Me.Label10.TabIndex = 29
        Me.Label10.Text = "QuickSharp"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Font = New System.Drawing.Font("Cooper Black", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 382)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(738, 18)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Based on Scintilla.NET"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lvwCodeInfo
        '
        Me.lvwCodeInfo.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clmnName, Me.clmnBy})
        Me.lvwCodeInfo.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2, ListViewItem3, ListViewItem4, ListViewItem5, ListViewItem6, ListViewItem7, ListViewItem8, ListViewItem9, ListViewItem10})
        Me.lvwCodeInfo.Location = New System.Drawing.Point(12, 152)
        Me.lvwCodeInfo.Name = "lvwCodeInfo"
        Me.lvwCodeInfo.Size = New System.Drawing.Size(739, 167)
        Me.lvwCodeInfo.TabIndex = 31
        Me.lvwCodeInfo.UseCompatibleStateImageBehavior = False
        Me.lvwCodeInfo.View = System.Windows.Forms.View.Details
        Me.lvwCodeInfo.Visible = False
        '
        'clmnName
        '
        Me.clmnName.Text = "Name:"
        Me.clmnName.Width = 221
        '
        'clmnBy
        '
        Me.clmnBy.Text = "By/Website:"
        Me.clmnBy.Width = 511
        '
        'btnCodeInfo
        '
        Me.btnCodeInfo.Location = New System.Drawing.Point(16, 15)
        Me.btnCodeInfo.Name = "btnCodeInfo"
        Me.btnCodeInfo.Size = New System.Drawing.Size(75, 23)
        Me.btnCodeInfo.TabIndex = 32
        Me.btnCodeInfo.Text = "Code Info"
        Me.btnCodeInfo.UseVisualStyleBackColor = True
        '
        'btnChangelog
        '
        Me.btnChangelog.Location = New System.Drawing.Point(669, 15)
        Me.btnChangelog.Name = "btnChangelog"
        Me.btnChangelog.Size = New System.Drawing.Size(75, 23)
        Me.btnChangelog.TabIndex = 33
        Me.btnChangelog.Text = "Change log"
        Me.btnChangelog.UseVisualStyleBackColor = True
        '
        'txtChangelog
        '
        Me.txtChangelog.Location = New System.Drawing.Point(12, 152)
        Me.txtChangelog.Multiline = True
        Me.txtChangelog.Name = "txtChangelog"
        Me.txtChangelog.ReadOnly = True
        Me.txtChangelog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtChangelog.Size = New System.Drawing.Size(738, 167)
        Me.txtChangelog.TabIndex = 34
        Me.txtChangelog.Text = resources.GetString("txtChangelog.Text")
        Me.txtChangelog.Visible = False
        '
        'frmAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(756, 318)
        Me.Controls.Add(Me.lvwCodeInfo)
        Me.Controls.Add(Me.txtChangelog)
        Me.Controls.Add(Me.btnChangelog)
        Me.Controls.Add(Me.btnCodeInfo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.pbMain)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmAbout"
        Me.Text = "About"
        CType(Me.pbMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tmrScroll As System.Windows.Forms.Timer
    Friend WithEvents pbMain As System.Windows.Forms.PictureBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lvwCodeInfo As System.Windows.Forms.ListView
    Friend WithEvents clmnName As System.Windows.Forms.ColumnHeader
    Friend WithEvents clmnBy As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnCodeInfo As System.Windows.Forms.Button
    Friend WithEvents btnChangelog As System.Windows.Forms.Button
    Friend WithEvents txtChangelog As System.Windows.Forms.TextBox
End Class
