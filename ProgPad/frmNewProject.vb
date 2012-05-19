Public Class frmNewProject
    Friend WithEvents tmrDelay As New Timer
    Private Sub frmNewProject_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ilMain.Images.Add("vbProject", Image.FromFile(Application.StartupPath & "\Images\ProjectVB.png"))
        ilMain.Images.Add("csProject", Image.FromFile(Application.StartupPath & "\Images\ProjectC#.png"))
        ilMain.Images.Add("VBSProject", Image.FromFile(Application.StartupPath & "\Images\ProjectVBS.png"))
        ilMain.Images.Add("BATProject", Image.FromFile(Application.StartupPath & "\Images\ProjectBat.png"))
        ilMain.Images.Add("WEBProject", Image.FromFile(Application.StartupPath & "\Images\ProjectWebsite.png"))
        lvwMain.LargeImageList = ilMain
        Dim LvwItm1, LvwItm2, LvwItm3, LvwItm4, LvwItm5, LvwItm6 As New ListViewItem
        LvwItm1.Text = "VB Project"
        LvwItm1.ImageKey = "vbProject"
        lvwMain.Items.Add(LvwItm1)
        LvwItm2.Text = "C# Project"
        LvwItm2.ImageKey = "csProject"
        lvwMain.Items.Add(LvwItm2)
        LvwItm5.Text = "Website"
        LvwItm5.ImageKey = "WEBProject"
        lvwMain.Items.Add(LvwItm5)
        LvwItm3.Text = "VBS Project"
        LvwItm3.ImageKey = "vbsProject"
        lvwMain.Items.Add(LvwItm3)
        LvwItm4.Text = "BAT Project"
        LvwItm4.ImageKey = "BATProject"
        lvwMain.Items.Add(LvwItm4)
        lvwMain.Items(0).Selected = True
        tcMain.Controls.Clear()
        cbxCSTarget.SelectedIndex = 0
        cbxVBTarget.SelectedIndex = 0
        cbxVBFramework.SelectedIndex = 2
        cbxCSFramework.SelectedIndex = 2

    End Sub


    Private Sub lvwMain_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvwMain.SelectedIndexChanged
        tmrDelay.Interval = 200
        tmrDelay.Start()
    End Sub

    Private Sub tmrDelay_Tick(sender As Object, e As System.EventArgs) Handles tmrDelay.Tick
        If lvwMain.SelectedIndices.Count <> 0 Then
            tcMain.Controls.Clear()
            tcMain.Controls.AddRange({tbVB, tbCSharp, tbWebsite, tbVBS, tbBatch})
            tcMain.SelectedIndex = lvwMain.SelectedIndices(0)
            Dim toRem As New Collection
            For Each ctrl As TabPage In tcMain.Controls
                If ctrl.Handle <> tcMain.SelectedTab.Handle Then
                    toRem.Add(ctrl)
                End If
            Next
            For Each itm In toRem
                tcMain.Controls.Remove(itm)
            Next
        End If
        tmrDelay.Stop()
    End Sub

    Private Sub txtProjectName_GotFocus(sender As Object, e As System.EventArgs) Handles txtProjectName.GotFocus
        If txtProjectName.Text = "Project Name" Then
            txtProjectName.Text = ""
            txtProjectName.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtProjectName_LostFocus(sender As Object, e As System.EventArgs) Handles txtProjectName.LostFocus
        If txtProjectName.Text = "" Then
            txtProjectName.Text = "Project Name"
            txtProjectName.ForeColor = Color.DarkGray
        End If
    End Sub

    Private Sub txtProjectName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtProjectName.TextChanged
        If txtProjectName.Text <> "Project Name" AndAlso TrimIllegalPaths(txtProjectName.Text) <> "" Then
            tcMain.Enabled = True
            If IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\NeoIDE Projects") Then
                IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\NeoIDE Projects")
            End If
            txtProjectLocation.ForeColor = Color.Black
            txtProjectLocation.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\NeoIDE Projects\" & TrimIllegalPaths(txtProjectName.Text)




            'VB Stuff
            txtVBIconPath.Text = txtProjectLocation.Text & "\Resources\app.ico"
            txtVBOutputPath.Text = txtProjectLocation.Text & "\Debug\" & TrimIllegalPaths(txtProjectName.Text) & ".exe"

            'C# Stuff
            txtCSIconPath.Text = txtProjectLocation.Text & "\Resources\app.ico"
            txtCSOutputPath.Text = txtProjectLocation.Text & "\Debug\" & TrimIllegalPaths(txtProjectName.Text) & ".exe"

        Else
            tcMain.Enabled = False
        End If
    End Sub

    Private Function TrimIllegalPaths(ByVal Path As String)
        Return Path.Replace("\", "").Replace("/", "").Replace("|", "").Replace(">", "").Replace("<", "").Replace("*", "").Replace("?", "").Replace("/", "").Replace("""", "")
    End Function

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
End Class