<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddonButtonContainer
    Inherits System.Windows.Forms.Panel

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
        Me.VScrollBar1 = New System.Windows.Forms.VScrollBar()
        Me.SuspendLayout()
        '
        'VScrollBar1
        '
        Me.VScrollBar1.Dock = System.Windows.Forms.DockStyle.Right
        Me.VScrollBar1.LargeChange = 1
        Me.VScrollBar1.Location = New System.Drawing.Point(683, 0)
        Me.VScrollBar1.Maximum = 0
        Me.VScrollBar1.Name = "VScrollBar1"
        Me.VScrollBar1.Size = New System.Drawing.Size(20, 238)
        Me.VScrollBar1.TabIndex = 0
        '
        'AddonButtonContainer
        '
        Me.Controls.Add(Me.VScrollBar1)
        Me.Size = New System.Drawing.Size(703, 238)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents VScrollBar1 As System.Windows.Forms.VScrollBar

End Class
