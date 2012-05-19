<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFindResults
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

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
        Me.tvMain = New System.Windows.Forms.TreeView()
        Me.cmuMain = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OpenSelectedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowFilePathsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowInExplorerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmuMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'tvMain
        '
        Me.tvMain.ContextMenuStrip = Me.cmuMain
        Me.tvMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvMain.Location = New System.Drawing.Point(0, 0)
        Me.tvMain.Name = "tvMain"
        Me.tvMain.Size = New System.Drawing.Size(827, 211)
        Me.tvMain.TabIndex = 0
        '
        'cmuMain
        '
        Me.cmuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenSelectedToolStripMenuItem, Me.ShowFilePathsToolStripMenuItem, Me.ShowInExplorerToolStripMenuItem})
        Me.cmuMain.Name = "cmuMain"
        Me.cmuMain.Size = New System.Drawing.Size(162, 92)
        '
        'OpenSelectedToolStripMenuItem
        '
        Me.OpenSelectedToolStripMenuItem.Name = "OpenSelectedToolStripMenuItem"
        Me.OpenSelectedToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.OpenSelectedToolStripMenuItem.Text = "Open Selected"
        '
        'ShowFilePathsToolStripMenuItem
        '
        Me.ShowFilePathsToolStripMenuItem.CheckOnClick = True
        Me.ShowFilePathsToolStripMenuItem.Name = "ShowFilePathsToolStripMenuItem"
        Me.ShowFilePathsToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.ShowFilePathsToolStripMenuItem.Text = "Show File Paths"
        '
        'ShowInExplorerToolStripMenuItem
        '
        Me.ShowInExplorerToolStripMenuItem.Name = "ShowInExplorerToolStripMenuItem"
        Me.ShowInExplorerToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.ShowInExplorerToolStripMenuItem.Text = "Show in Explorer"
        '
        'frmFindResults
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(827, 211)
        Me.Controls.Add(Me.tvMain)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmFindResults"
        Me.Text = "Find Results"
        Me.cmuMain.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tvMain As System.Windows.Forms.TreeView
    Friend WithEvents cmuMain As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ShowFilePathsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenSelectedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowInExplorerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
