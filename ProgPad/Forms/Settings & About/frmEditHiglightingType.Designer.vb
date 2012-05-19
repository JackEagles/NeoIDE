<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditHiglightingType
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
        Me.cbxHighlighting = New System.Windows.Forms.ComboBox()
        Me.txtFileType = New System.Windows.Forms.TextBox()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.lblFileType = New System.Windows.Forms.Label()
        Me.lblHiglighting = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cbxHighlighting
        '
        Me.cbxHighlighting.FormattingEnabled = True
        Me.cbxHighlighting.Location = New System.Drawing.Point(71, 69)
        Me.cbxHighlighting.Name = "cbxHighlighting"
        Me.cbxHighlighting.Size = New System.Drawing.Size(228, 21)
        Me.cbxHighlighting.TabIndex = 0
        '
        'txtFileType
        '
        Me.txtFileType.Location = New System.Drawing.Point(71, 43)
        Me.txtFileType.Name = "txtFileType"
        Me.txtFileType.Size = New System.Drawing.Size(228, 20)
        Me.txtFileType.TabIndex = 1
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.Location = New System.Drawing.Point(7, 4)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(263, 26)
        Me.lblInfo.TabIndex = 2
        Me.lblInfo.Text = "Please select the file extension and higlighing type you" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "would like to be applie" & _
    "d by default:"
        '
        'lblFileType
        '
        Me.lblFileType.AutoSize = True
        Me.lblFileType.Location = New System.Drawing.Point(7, 46)
        Me.lblFileType.Name = "lblFileType"
        Me.lblFileType.Size = New System.Drawing.Size(53, 13)
        Me.lblFileType.TabIndex = 3
        Me.lblFileType.Text = "File Type:"
        '
        'lblHiglighting
        '
        Me.lblHiglighting.AutoSize = True
        Me.lblHiglighting.Location = New System.Drawing.Point(6, 72)
        Me.lblHiglighting.Name = "lblHiglighting"
        Me.lblHiglighting.Size = New System.Drawing.Size(65, 13)
        Me.lblHiglighting.TabIndex = 4
        Me.lblHiglighting.Text = "Highlighting:"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(224, 96)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(143, 96)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmEditHiglightingType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(305, 121)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lblHiglighting)
        Me.Controls.Add(Me.lblFileType)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.txtFileType)
        Me.Controls.Add(Me.cbxHighlighting)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEditHiglightingType"
        Me.Text = "Add/Edit Auto higlighting"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbxHighlighting As System.Windows.Forms.ComboBox
    Friend WithEvents txtFileType As System.Windows.Forms.TextBox
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents lblFileType As System.Windows.Forms.Label
    Friend WithEvents lblHiglighting As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
