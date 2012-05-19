Imports WeifenLuo.WinFormsUI.Docking

Public Class frmFindResults
    Inherits DockContent

    Private Sub frmFindResults_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ShowFilePathsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowFilePathsToolStripMenuItem.Click
        If ShowFilePathsToolStripMenuItem.Checked = True Then
            For Each itm As TreeNode In tvMain.Nodes
                itm.Text = itm.ToolTipText
            Next
        Else
            For Each itm As TreeNode In tvMain.Nodes
                itm.Text = itm.ToolTipText.Substring(itm.ToolTipText.LastIndexOf("\")).Replace("\", "")
            Next
        End If

    End Sub

    Private Sub OpenSelectedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenSelectedToolStripMenuItem.Click
        Dim tcDocked As Boolean = False
        If Me.DockState = WeifenLuo.WinFormsUI.Docking.DockState.DockRightAutoHide Then
            Me.DockState = WeifenLuo.WinFormsUI.Docking.DockState.DockRight
            tcDocked = True
        End If
        frmMain.CreateNewDoc(tvMain.SelectedNode.ToolTipText.ToString)
        If tcDocked = True Then
            Me.DockState = WeifenLuo.WinFormsUI.Docking.DockState.DockRightAutoHide
        End If
    End Sub

    Private Sub tvMain_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tvMain.MouseDown
        If e.Button = MouseButtons.Right Then
            tvMain.SelectedNode = tvMain.GetNodeAt(e.Location)
        End If
    End Sub

    Private Sub ShowInExplorerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ShowInExplorerToolStripMenuItem.Click
        Process.Start(tvMain.SelectedNode.ToolTipText.ToString.Substring(0, tvMain.SelectedNode.ToolTipText.LastIndexOf("\")))
    End Sub
End Class