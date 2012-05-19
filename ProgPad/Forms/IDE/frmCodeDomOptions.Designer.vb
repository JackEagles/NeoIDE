<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCodeDomOptions
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
        Me.txtOutputPath = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtIconPath = New System.Windows.Forms.TextBox()
        Me.lstReferences = New System.Windows.Forms.ListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbxTarget = New System.Windows.Forms.ComboBox()
        Me.cbxLanguage = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtOutputPath
        '
        Me.txtOutputPath.Location = New System.Drawing.Point(77, 88)
        Me.txtOutputPath.Name = "txtOutputPath"
        Me.txtOutputPath.Size = New System.Drawing.Size(266, 20)
        Me.txtOutputPath.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Output Path:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(349, 85)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(34, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(349, 111)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(34, 23)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 117)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Icon Path:"
        '
        'txtIconPath
        '
        Me.txtIconPath.Location = New System.Drawing.Point(77, 114)
        Me.txtIconPath.Name = "txtIconPath"
        Me.txtIconPath.Size = New System.Drawing.Size(266, 20)
        Me.txtIconPath.TabIndex = 3
        '
        'lstReferences
        '
        Me.lstReferences.FormattingEnabled = True
        Me.lstReferences.Location = New System.Drawing.Point(77, 140)
        Me.lstReferences.Name = "lstReferences"
        Me.lstReferences.Size = New System.Drawing.Size(306, 82)
        Me.lstReferences.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 140)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "References:"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(77, 228)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(119, 23)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "Add"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(202, 228)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(119, 23)
        Me.Button4.TabIndex = 9
        Me.Button4.Text = "Remove Selected"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(481, 254)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(105, 23)
        Me.Button5.TabIndex = 10
        Me.Button5.Text = "Create"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(4, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Target:"
        '
        'cbxTarget
        '
        Me.cbxTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxTarget.FormattingEnabled = True
        Me.cbxTarget.Items.AddRange(New Object() {"Console  Application", "Class Library", "WinForms Application"})
        Me.cbxTarget.Location = New System.Drawing.Point(77, 61)
        Me.cbxTarget.Name = "cbxTarget"
        Me.cbxTarget.Size = New System.Drawing.Size(306, 21)
        Me.cbxTarget.TabIndex = 12
        '
        'cbxLanguage
        '
        Me.cbxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxLanguage.FormattingEnabled = True
        Me.cbxLanguage.Items.AddRange(New Object() {"Console  Application", "Class Library", "WinForms Application"})
        Me.cbxLanguage.Location = New System.Drawing.Point(77, 34)
        Me.cbxLanguage.Name = "cbxLanguage"
        Me.cbxLanguage.Size = New System.Drawing.Size(306, 21)
        Me.cbxLanguage.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(4, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Language:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(77, 8)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(509, 20)
        Me.TextBox1.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Project Name:"
        '
        'frmCodeDomOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(594, 286)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.cbxLanguage)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cbxTarget)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lstReferences)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtIconPath)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtOutputPath)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCodeDomOptions"
        Me.Text = "Create a Project"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtOutputPath As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtIconPath As System.Windows.Forms.TextBox
    Friend WithEvents lstReferences As System.Windows.Forms.ListBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbxTarget As System.Windows.Forms.ComboBox
    Friend WithEvents cbxLanguage As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
