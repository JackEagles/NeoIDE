<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AlertControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Command2 = New System.Windows.Forms.Button()
        Me.Command1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Message"
        '
        'Command2
        '
        Me.Command2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Command2.Location = New System.Drawing.Point(525, 2)
        Me.Command2.Name = "Command2"
        Me.Command2.Size = New System.Drawing.Size(70, 31)
        Me.Command2.TabIndex = 1
        Me.Command2.Text = "Yes"
        Me.Command2.UseVisualStyleBackColor = True
        '
        'Command1
        '
        Me.Command1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Command1.Location = New System.Drawing.Point(449, 2)
        Me.Command1.Name = "Command1"
        Me.Command1.Size = New System.Drawing.Size(70, 31)
        Me.Command1.TabIndex = 2
        Me.Command1.Text = "No"
        Me.Command1.UseVisualStyleBackColor = True
        '
        'AlertControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.Command2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "AlertControl"
        Me.Size = New System.Drawing.Size(598, 35)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Command2 As System.Windows.Forms.Button
    Friend WithEvents Command1 As System.Windows.Forms.Button

End Class
