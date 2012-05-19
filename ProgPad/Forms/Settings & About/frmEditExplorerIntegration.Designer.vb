<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditExplorerIntegration
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
        Me.txtFileTypes = New System.Windows.Forms.TextBox()
        Me.lblMain = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtFileTypes
        '
        Me.txtFileTypes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFileTypes.Location = New System.Drawing.Point(12, 36)
        Me.txtFileTypes.Multiline = True
        Me.txtFileTypes.Name = "txtFileTypes"
        Me.txtFileTypes.Size = New System.Drawing.Size(268, 215)
        Me.txtFileTypes.TabIndex = 0
        '
        'lblMain
        '
        Me.lblMain.AutoSize = True
        Me.lblMain.Location = New System.Drawing.Point(11, 4)
        Me.lblMain.Name = "lblMain"
        Me.lblMain.Size = New System.Drawing.Size(272, 26)
        Me.lblMain.TabIndex = 1
        Me.lblMain.Text = "Please enter the file types below which you would like to" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "add the ""Open with Pro" & _
            "grammer's Pad"" menuitem to:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(27, 254)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(235, 48)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Knowledge of file associations is" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "reccommended   before   editing " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the above se" & _
            "ttings!"
        '
        'frmEditExplorerIntegration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 305)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblMain)
        Me.Controls.Add(Me.txtFileTypes)
        Me.Name = "frmEditExplorerIntegration"
        Me.Text = "Edit Explorer Integration"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtFileTypes As System.Windows.Forms.TextBox
    Friend WithEvents lblMain As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
