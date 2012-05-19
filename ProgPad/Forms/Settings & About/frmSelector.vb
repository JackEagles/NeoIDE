Public Class frmSelector

    Private Sub frmSelector_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub frmSelector_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ilMain.Images.Add("blnk", New Icon(Application.StartupPath & "\Images\blank.ico"))
        For Each itm As ToolStripMenuItem In frmMain.msMain.Items
            cbxItms.Items.Add(itm.Text)
        Next
        cbxItms.SelectedIndex = 0
        For Each itm In frmMain.msToolbar.Items
            Dim nd As New TreeNode
            If itm.Text <> "" Then
                nd.Text = itm.Text
            Else
                nd.Text = itm.ToolTipText
            End If
            nd.ImageKey = "blnk"

            tvToolbar.Nodes(0).Nodes.Add(nd)
        Next
        tvToolbar.ExpandAll()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxItms.SelectedIndexChanged
        On Error Resume Next

        tvMain.Nodes.Clear()
        For Each itm As ToolStripMenuItem In frmMain.msMain.Items
            If itm.Text = cbxItms.SelectedItem.ToString Then
                Dim nd As New TreeNode
                nd.ImageIndex = Nothing
                nd.Text = itm.Text
                tvMain.Nodes.Add(nd)
                For Each dropdown In itm.DropDownItems
                    If TypeOf (dropdown) Is ToolStripMenuItem Then

                        ilMain.Images.Add(dropdown.Text, dropdown.Image)
                        Dim nd2 As New TreeNode
                        nd2.Text = dropdown.Text
                        nd2.ImageKey = dropdown.Text

                        tvMain.Nodes(0).Nodes.Add(nd2)
                    End If
                Next
            End If
        Next

        tvMain.ExpandAll()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        For Each itm In frmMain.msToolbar.Items
            If itm.ToolTipText = tvMain.SelectedNode.Text Then
                Exit Sub
            End If
        Next
        If tvMain.SelectedNode.Nodes.Count = 0 Then
            tvToolbar.Nodes(0).Nodes.Add(tvMain.SelectedNode.Clone)
        Else
            Exit Sub
        End If

        Dim buts As New Collection
        For Each itm As ToolStripMenuItem In frmMain.msMain.Items
            For Each subItm In itm.DropDownItems
                If tvMain.SelectedNode.Text = subItm.Text Then
                    Dim bitm As New ToolBarCloneItem
                    bitm.Image = subItm.Image
                    bitm.ToolTipText = subItm.Text
                    bitm.CheckOnClick = subItm.CheckOnClick
                    buts.Add(bitm)
                End If
            Next
        Next
        For Each itm In buts
            frmMain.msToolbar.Items.Add(itm)
        Next
        tvToolbar.ExpandAll()
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Try
            Dim toRemove As New Collection
            For Each itm In frmMain.msToolbar.Items
                If itm.ToolTipText = tvToolbar.SelectedNode.Text Then
                    toRemove.Add(itm)
                End If
            Next

            frmMain.msMain.SuspendLayout()
            For Each itm In toRemove
                CType(itm, ToolBarCloneItem).Image = Nothing
                CType(itm, ToolBarCloneItem).Text = ""
                CType(itm, ToolBarCloneItem).ToolTipText = ""
                frmMain.msMain.Items.Remove(CType(itm, ToolBarCloneItem))
            Next
            frmMain.msMain.ResumeLayout()
            frmMain.msMain.PerformLayout()
            frmMain.msMain.Refresh()

            tvToolbar.Nodes.Remove(tvToolbar.SelectedNode)
        Catch
            MessageBox.Show("Cannot remove the 'Customize' item", "Error", MessageBoxButtons.YesNo)
        End Try

    End Sub

    Private Sub tvMain_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvMain.AfterSelect
        e.Node.ImageKey = e.Node.Text
    End Sub
End Class
