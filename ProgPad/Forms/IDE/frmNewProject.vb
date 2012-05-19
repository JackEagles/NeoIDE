Imports System.Collections.Specialized

Public Class frmNewProject


    Private Function TrimIllegalNames(ByVal Path As String)
        Return Path.Replace("\", "").Replace("/", "").Replace("|", "").Replace(">", "").Replace("<", "").Replace("*", "").Replace("?", "").Replace("/", "").Replace("""", "")
    End Function

    Private Function TrimIllegalPaths(ByVal Path As String)
        Return Path.Replace("|", "").Replace(">", "").Replace("<", "").Replace("*", "").Replace("?", "").Replace("/", "").Replace("""", "")
    End Function
#Region "Load & Close"
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

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
#End Region
#Region "Project Selector"
    Friend WithEvents tmrDelay As New Timer
    Private Sub lvwMain_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwMain.SelectedIndexChanged
        tmrDelay.Interval = 200
        tmrDelay.Start()
    End Sub

    Private Sub tmrDelay_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrDelay.Tick
        If lvwMain.SelectedIndices.Count <> 0 Then
            tcMain.Controls.Clear()
            tcMain.Controls.AddRange({tbVB, tbCSharp, tbWebsite, tbVBS, tbBatch})
            tcMain.SelectedIndex = lvwMain.SelectedIndices(0)
            Dim toRem As New Collection
            For Each ctrl As System.Windows.Forms.TabPage In tcMain.Controls
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
#End Region
#Region "Project Naming"
    Private Sub txtProjectName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProjectName.GotFocus
        If txtProjectName.Text = "Project Name" Then
            txtProjectName.Text = ""
            txtProjectName.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtProjectName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProjectName.LostFocus
        If txtProjectName.Text = "" Then
            txtProjectName.Text = "Project Name"
            txtProjectName.ForeColor = Color.DarkGray
        End If
    End Sub

    Private Sub txtProjectName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProjectName.TextChanged
        If txtProjectName.Text <> "Project Name" AndAlso TrimIllegalNames(txtProjectName.Text) <> "" Then
            tcMain.Enabled = True
            If IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\NeoIDE Projects") Then
                IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\NeoIDE Projects")
            End If
            txtProjectLocation.ForeColor = Color.Black
            txtProjectLocation.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\NeoIDE Projects\" & TrimIllegalNames(txtProjectName.Text)

            'VB Stuff
            If cbxVBTarget.SelectedIndex = 1 Then
                txtVBIconPath.Text = txtProjectLocation.Text & "\Resources\app.ico"
                txtVBOutputPath.Text = txtProjectLocation.Text & "\Debug\" & TrimIllegalNames(txtProjectName.Text) & ".dll"
            Else
                txtVBIconPath.Text = txtProjectLocation.Text & "\Resources\app.ico"
                txtVBOutputPath.Text = txtProjectLocation.Text & "\Debug\" & TrimIllegalNames(txtProjectName.Text) & ".exe"
            End If

            'C# Stuff
            If cbxCSTarget.SelectedIndex = 1 Then
                txtCSIconPath.Text = txtProjectLocation.Text & "\Resources\app.ico"
                txtCSOutputPath.Text = txtProjectLocation.Text & "\Debug\" & TrimIllegalNames(txtProjectName.Text) & ".dll"
            Else
                txtCSIconPath.Text = txtProjectLocation.Text & "\Resources\app.ico"
                txtCSOutputPath.Text = txtProjectLocation.Text & "\Debug\" & TrimIllegalNames(txtProjectName.Text) & ".exe"
            End If
        Else
            tcMain.Enabled = False
            txtProjectLocation.Text = "" : txtCSIconPath.Text = "" : txtCSOutputPath.Text = "" : txtVBIconPath.Text = "" : txtVBOutputPath.Text = ""
        End If
    End Sub


    Private Sub txtProjectLocation_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProjectLocation.TextChanged
        txtVBIconPath.Text = txtProjectLocation.Text & "\Resources\app.ico"
        txtVBOutputPath.Text = txtProjectLocation.Text & "\Debug\" & TrimIllegalNames(txtProjectName.Text) & ".exe"

        'C# Stuff
        txtCSIconPath.Text = txtProjectLocation.Text & "\Resources\app.ico"
        txtCSOutputPath.Text = txtProjectLocation.Text & "\Debug\" & TrimIllegalNames(txtProjectName.Text) & ".exe"

    End Sub

#End Region

#Region "VB Tab"
    Private Sub btnVBAddReference_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVBAddReference.Click
        Dim ib As String = InputBox("Please type the name of the DLL you want to impor: .NET framework .dlls will work by default, but custom .dlls must have an absolute path. Ensure you add any custom dlls to your assembly's output directory, or the assembly won't run.", "Add an import...", "System.dll")
        Dim add As Boolean = True
        For Each itm In lstVBReferences.Items
            If itm.ToString = ib Then
                add = False
            End If
        Next
        If add = True Then
            If ib.ToLower.EndsWith(".dll") Then
                If ib.Contains(":") Then
                    If IO.File.Exists(ib) Then
                        lstVBReferences.Items.Add(ib)
                    End If
                Else
                    lstVBReferences.Items.Add(ib)
                End If
            End If
        End If
    End Sub

    Private Sub btnVBRemReference_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVBRemReference.Click
        Try
            lstVBReferences.Items.Remove(lstVBReferences.SelectedItem)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnVBSelectOutputPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVBSelectOutputPath.Click
        Dim sfd As New SaveFileDialog
        If cbxVBTarget.SelectedIndex = 1 Then
            sfd.Filter = "Dynamic Link Libraries|*.dll"
        Else
            sfd.Filter = "Executable Files|*.exe"
        End If
        If sfd.ShowDialog = DialogResult.OK Then
            txtVBOutputPath.Text = sfd.FileName
        End If
    End Sub

    Private Sub cbxVBTarget_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxVBTarget.SelectedIndexChanged
        If cbxVBTarget.SelectedIndex = 1 Then
            If txtVBOutputPath.Text.EndsWith(".exe") Then
                txtVBOutputPath.Text = txtVBOutputPath.Text.Substring(0, txtVBOutputPath.Text.Length - 4) & ".dll"
            End If
        Else
            If txtVBOutputPath.Text.EndsWith(".dll") Then
                txtVBOutputPath.Text = txtVBOutputPath.Text.Substring(0, txtVBOutputPath.Text.Length - 4) & ".exe"
            End If
        End If
    End Sub
#End Region

    Private Sub btnVBSelectIconPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVBSelectIconPath.Click
        Dim ofd As New OpenFileDialog
        ofd.Filter = "Icon Files|*.ico"
        If ofd.ShowDialog = DialogResult.OK Then
            txtVBIconPath.Text = ofd.FileName
        End If
    End Sub

    Private Sub txtVBOutputPath_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVBOutputPath.TextChanged
        If TrimIllegalPaths(txtVBOutputPath.Text) <> txtVBOutputPath.Text Then
            txtVBOutputPath.Text = TrimIllegalPaths(txtVBOutputPath.Text)
        End If
    End Sub


#Region "Website Generation"
    Public Pages As New StringCollection
    Private Sub btnAddWebsitePage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddWebsitePage.Click
        Dim ib As String = InputBox("Please enter the name of the page, for example 'contact.htm'. Note that you can include a directory such as '\someproject\main.htm")
        If ib <> "" Then
            If ib.EndsWith(".htm") Or ib.EndsWith(".html") Then
                Pages.Add(ib)
            End If
        End If
    End Sub

#End Region

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim fbd As New FolderBrowserDialog
        fbd.Description = "Please select a folder..."
        If fbd.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtProjectLocation.Text = fbd.SelectedPath & "\" & txtProjectName.Text
        End If
    End Sub

    Private Sub btnCSSelectOutputPath_Click(sender As System.Object, e As System.EventArgs) Handles btnCSSelectOutputPath.Click

    End Sub

    Private Sub btnRemoveWebsitePage_Click(sender As System.Object, e As System.EventArgs) Handles btnRemoveWebsitePage.Click
        lstWebsitePages.Items.Remove(lstWebsitePages.SelectedIndex)
    End Sub

    Private Sub btnCreateProject_Click(sender As System.Object, e As System.EventArgs) Handles btnCreateProject.Click
        IO.Directory.CreateDirectory(txtProjectLocation.Text)

        If tcMain.SelectedTab.Handle = tbVB.Handle Then
            IO.Directory.CreateDirectory(txtVBOutputPath.Text)
            IO.Directory.CreateDirectory(txtProjectLocation.Text & "\Resources\")
            IO.File.Copy(Application.StartupPath & "\Images\app.ico", txtProjectLocation.Text & "\Resources\App.ico")
            frmMain.compiler.Icon = txtProjectLocation.Text & "\Resources\app.ico"
            frmMain.compiler.ExecuteAfterCompiled = True
            frmMain.compiler.Debug = True

        End If
    End Sub
End Class