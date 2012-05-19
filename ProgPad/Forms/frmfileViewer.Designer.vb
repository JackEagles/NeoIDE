<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmfileViewer
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
        Me.lvwMain = New System.Windows.Forms.ListView()
        Me.SuspendLayout()
        '
        'lvwMain
        '
        Me.lvwMain.Location = New System.Drawing.Point(12, 12)
        Me.lvwMain.Name = "lvwMain"
        Me.lvwMain.Size = New System.Drawing.Size(588, 330)
        Me.lvwMain.TabIndex = 0
        Me.lvwMain.UseCompatibleStateImageBehavior = False
        '
        'frmfileViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(612, 373)
        Me.Controls.Add(Me.lvwMain)
        Me.Name = "frmfileViewer"
        Me.Text = "Programmer's Cloud - My Files"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lvwMain As System.Windows.Forms.ListView
End Class
