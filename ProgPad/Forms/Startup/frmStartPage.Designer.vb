<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStartPage
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
        Me.pbIcon = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.rtbChangelog = New NeoIDE.ExtendedRichTextBox()
        Me.Grouper2 = New NeoIDE.CodeVendor.Controls.Grouper()
        Me.ProjectControlContainer2 = New NeoIDE.ProjectControlContainer()
        Me.Grouper1 = New NeoIDE.CodeVendor.Controls.Grouper()
        Me.ProjectControlContainer1 = New NeoIDE.ProjectControlContainer()
        CType(Me.pbIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grouper2.SuspendLayout()
        Me.Grouper1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbIcon
        '
        Me.pbIcon.Location = New System.Drawing.Point(12, 12)
        Me.pbIcon.Name = "pbIcon"
        Me.pbIcon.Size = New System.Drawing.Size(159, 159)
        Me.pbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbIcon.TabIndex = 4
        Me.pbIcon.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(159, 159)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'rtbChangelog
        '
        Me.rtbChangelog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbChangelog.Location = New System.Drawing.Point(470, 12)
        Me.rtbChangelog.Name = "rtbChangelog"
        CharStyle1.Bold = False
        CharStyle1.Italic = False
        CharStyle1.Link = False
        CharStyle1.Strikeout = False
        CharStyle1.Underline = False
        Me.rtbChangelog.SelectionCharStyle = CharStyle1
        Me.rtbChangelog.SelectionFont2 = New System.Drawing.Font("Microsoft Sans Serif", 5.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Inch)
        ParaLineSpacing1.ExactSpacing = 0
        ParaLineSpacing1.SpacingStyle = NeoIDE.ExtendedRichTextBox.ParaLineSpacing.LineSpacingStyle.Unknown
        Me.rtbChangelog.SelectionLineSpacing = ParaLineSpacing1
        ParaListStyle1.BulletCharCode = CType(0, Short)
        ParaListStyle1.NumberingStart = CType(0, Short)
        ParaListStyle1.Style = NeoIDE.ExtendedRichTextBox.ParaListStyle.ListStyle.NumberAndParenthesis
        ParaListStyle1.Type = NeoIDE.ExtendedRichTextBox.ParaListStyle.ListType.None
        Me.rtbChangelog.SelectionListType = ParaListStyle1
        Me.rtbChangelog.SelectionOffsetType = NeoIDE.ExtendedRichTextBox.OffsetType.None
        Me.rtbChangelog.SelectionSpaceAfter = 0
        Me.rtbChangelog.SelectionSpaceBefore = 0
        Me.rtbChangelog.Size = New System.Drawing.Size(354, 377)
        Me.rtbChangelog.TabIndex = 7
        Me.rtbChangelog.Text = ""
        '
        'Grouper2
        '
        Me.Grouper2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Grouper2.BackgroundColor = System.Drawing.Color.White
        Me.Grouper2.BackgroundGradientColor = System.Drawing.Color.White
        Me.Grouper2.BackgroundGradientMode = NeoIDE.CodeVendor.Controls.Grouper.GroupBoxGradientMode.None
        Me.Grouper2.BorderColor = System.Drawing.Color.Black
        Me.Grouper2.BorderThickness = 1.0!
        Me.Grouper2.Controls.Add(Me.ProjectControlContainer2)
        Me.Grouper2.CustomGroupBoxColor = System.Drawing.Color.White
        Me.Grouper2.GroupImage = Nothing
        Me.Grouper2.GroupTitle = "Recent Projects:"
        Me.Grouper2.Location = New System.Drawing.Point(12, 164)
        Me.Grouper2.Name = "Grouper2"
        Me.Grouper2.Padding = New System.Windows.Forms.Padding(20)
        Me.Grouper2.PaintGroupBox = False
        Me.Grouper2.RoundCorners = 10
        Me.Grouper2.ShadowColor = System.Drawing.Color.DarkGray
        Me.Grouper2.ShadowControl = False
        Me.Grouper2.ShadowThickness = 3
        Me.Grouper2.Size = New System.Drawing.Size(449, 225)
        Me.Grouper2.TabIndex = 6
        '
        'ProjectControlContainer2
        '
        Me.ProjectControlContainer2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProjectControlContainer2.Location = New System.Drawing.Point(8, 26)
        Me.ProjectControlContainer2.Name = "ProjectControlContainer2"
        Me.ProjectControlContainer2.Size = New System.Drawing.Size(431, 187)
        Me.ProjectControlContainer2.TabIndex = 1
        '
        'Grouper1
        '
        Me.Grouper1.BackgroundColor = System.Drawing.Color.White
        Me.Grouper1.BackgroundGradientColor = System.Drawing.Color.White
        Me.Grouper1.BackgroundGradientMode = NeoIDE.CodeVendor.Controls.Grouper.GroupBoxGradientMode.None
        Me.Grouper1.BorderColor = System.Drawing.Color.Black
        Me.Grouper1.BorderThickness = 1.0!
        Me.Grouper1.Controls.Add(Me.ProjectControlContainer1)
        Me.Grouper1.CustomGroupBoxColor = System.Drawing.Color.White
        Me.Grouper1.GroupImage = Nothing
        Me.Grouper1.GroupTitle = "Tasks:"
        Me.Grouper1.Location = New System.Drawing.Point(177, 15)
        Me.Grouper1.Name = "Grouper1"
        Me.Grouper1.Padding = New System.Windows.Forms.Padding(20)
        Me.Grouper1.PaintGroupBox = False
        Me.Grouper1.RoundCorners = 10
        Me.Grouper1.ShadowColor = System.Drawing.Color.DarkGray
        Me.Grouper1.ShadowControl = False
        Me.Grouper1.ShadowThickness = 3
        Me.Grouper1.Size = New System.Drawing.Size(287, 145)
        Me.Grouper1.TabIndex = 5
        '
        'ProjectControlContainer1
        '
        Me.ProjectControlContainer1.Location = New System.Drawing.Point(6, 24)
        Me.ProjectControlContainer1.Name = "ProjectControlContainer1"
        Me.ProjectControlContainer1.Size = New System.Drawing.Size(275, 111)
        Me.ProjectControlContainer1.TabIndex = 0
        '
        'frmStartPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(836, 401)
        Me.Controls.Add(Me.rtbChangelog)
        Me.Controls.Add(Me.Grouper2)
        Me.Controls.Add(Me.Grouper1)
        Me.Controls.Add(Me.pbIcon)
        Me.Name = "frmStartPage"
        Me.Text = "Start Page"
        CType(Me.pbIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grouper2.ResumeLayout(False)
        Me.Grouper1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbIcon As System.Windows.Forms.PictureBox
    Friend WithEvents Grouper1 As NeoIDE.CodeVendor.Controls.Grouper
    Friend WithEvents ProjectControlContainer1 As NeoIDE.ProjectControlContainer
    Friend WithEvents Grouper2 As NeoIDE.CodeVendor.Controls.Grouper
    Friend WithEvents ProjectControlContainer2 As NeoIDE.ProjectControlContainer
    Friend WithEvents rtbChangelog As NeoIDE.ExtendedRichTextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
