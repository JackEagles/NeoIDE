<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTab
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
        Me.lstMain = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'lstMain
        '
        Me.lstMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstMain.FormattingEnabled = True
        Me.lstMain.Location = New System.Drawing.Point(0, 0)
        Me.lstMain.Name = "lstMain"
        Me.lstMain.Size = New System.Drawing.Size(398, 4)
        Me.lstMain.TabIndex = 0
        '
        'frmTab
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(398, 4)
        Me.ControlBox = False
        Me.Controls.Add(Me.lstMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "frmTab"
        Me.Opacity = 0.9R
        Me.ShowIcon = False
        Me.Text = "Document Switcher"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstMain As System.Windows.Forms.ListBox
End Class
