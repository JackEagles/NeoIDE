Public Class frmConfig

    Public HighlightDialogClose As Boolean = False
    Dim theThemeFile As String = frmMain.ThemeFile.Substring(frmMain.ThemeFile.LastIndexOf("\")).Replace("\", "")
    Private Sub ToolStrip1_ItemClicked(ByVal sender As Global.System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked
        For Each itm As ToolStripButton In ToolStrip1.Items
            itm.Checked = False
            If itm.Text = e.ClickedItem.Text Then
                itm.Checked = True
            End If
        Next
    End Sub

    Private Sub btnGeneral_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGeneral.Click
        tcSettings.SelectedIndex = 0
    End Sub

    Private Sub btnHighlighting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHighlighting.Click
        tcSettings.SelectedIndex = 1
    End Sub

    Private Sub btnIntegration_Click(ByVal sender As System.Object, ByVal e As Global.System.EventArgs) Handles btnIntegration.Click
        tcSettings.SelectedIndex = 2
    End Sub

    Private Sub btnEditing_Click(ByVal sender As Global.System.Object, ByVal e As Global.System.EventArgs) Handles btnEditing.Click
        tcSettings.SelectedIndex = 3
    End Sub

    Private Sub frmConfig_Load(ByVal sender As Global.System.Object, ByVal e As Global.System.EventArgs) Handles MyBase.Load
        Dim dinfo As New IO.DirectoryInfo(Application.StartupPath & "\Themes")

        For Each itm In dinfo.GetFiles
            lstTheme.Items.Add(itm.Name.Replace(".dll", "").Replace("_", " "))
        Next
        For i As Integer = 0 To lstTheme.Items.Count - 1
            If lstTheme.Items(i) = theThemeFile.Replace(".dll", "").Replace("_", " ") Then
                lstTheme.SelectedIndex = i
            End If
        Next
        Me.Icon = New Icon(Application.StartupPath & "\Images\Mainicon.ico")
        chkStatusBarVisible.Checked = frmMain.msInfo.Visible
        chkToolbarVisible.Checked = frmMain.msToolbar.Visible
        chkDisableDocSwitcher.Checked = frmMain.DocumentSwitcher
        frmMain.resetStrip()
        chkExplorerIntegration.Checked = frmMain.ExplorerIntegration
        txtCustomExplorerIntegration.Text = frmMain.CustomExplorerIntegration
        chkCustomExplorerIntegration.Enabled = chkExplorerIntegration.Checked
        If txtCustomExplorerIntegration.Text <> "Open with NeoIDE" Then
            chkCustomExplorerIntegration.Checked = True
            txtCustomExplorerIntegration.Enabled = True
        Else
            chkCustomExplorerIntegration.Checked = False
            txtCustomExplorerIntegration.Enabled = False
        End If

        chkRememberSession.Checked = frmMain.RememberSession
        chkDocumentTitleBar.Checked = frmMain.DocumentTitleBar
        chkAutoHiglighting.Checked = frmMain.AutoHighlighting
        If frmMain.AutoHighlighting = True Then
            For Each itm In frmMain.AutoHighligtingRules
                Dim lName As String = itm.Substring(itm.LastIndexOf("$%$"))
                Dim lExt As String = itm.Replace(lName, "")
                lName = lName.Replace("$%$", "")
                Dim lvwItm = lvwHighlighting.Items.Add(lExt)
                lvwItm.SubItems.Add(lName)
            Next
        End If


        CheckBox1.Checked = frmMain.AutoCodeDetection
        For Each itm In frmMain.CodeDetectionRules
            Dim lasptart As String = itm.Substring(itm.LastIndexOf("`"))
            Dim firstpart As String = itm.Replace(lasptart, "")
            lasptart = lasptart.Replace("`", "")
            Dim lvwItm As New ListViewItem
            lvwItm.Text = firstpart
            lvwItm.SubItems.Add(lasptart)
            lvwCodeDetection.Items.Add(lvwItm)
        Next


    End Sub



    Private Sub frmConfig_FormClosing(ByVal sender As Object, ByVal e As Global.System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        frmMain.AutoCodeDetection = CheckBox1.Checked
        frmMain.msInfo.Visible = chkStatusBarVisible.Checked
        frmMain.msToolbar.Visible = chkToolbarVisible.Checked
        frmMain.DocumentSwitcher = chkDisableDocSwitcher.Checked



  

        frmMain.ExplorerIntegration = chkExplorerIntegration.Checked

        If chkExplorerIntegration.Checked = True Then
    Dim loadf As New IO.StreamReader(Application.StartupPath & "\Settings\ExplorerFileTypes.nps")
            For Each itm In loadf.ReadToEnd.Split("$SPLIT$")
                If itm <> "SPLIT" AndAlso itm <> "" Then
                    ShellMenu.Register(itm, "ProgPad", txtCustomExplorerIntegration.Text, """" & Application.ExecutablePath & """" & " ""%1""")
                End If
            Next
        Else
    Dim loadf As New IO.StreamReader(Application.StartupPath & "\Settings\ExplorerFileTypes.nps")
            For Each itm In loadf.ReadToEnd.Split("$SPLIT$")
                If itm <> "SPLIT" AndAlso itm <> "" Then
                    ShellMenu.Unregister(itm, "ProgPad")
                End If
            Next

        End If
        frmMain.CustomExplorerIntegration = txtCustomExplorerIntegration.Text
        frmMain.RememberSession = chkRememberSession.Checked
        frmMain.DocumentTitleBar = chkDocumentTitleBar.Checked
        frmMain.AutoHighlighting = chkAutoHiglighting.Checked

        Me.Dispose()
    End Sub

    Private Sub chkCustomExplorerIntegration_CheckedChanged(ByVal sender As Global.System.Object, ByVal e As Global.System.EventArgs) Handles chkCustomExplorerIntegration.CheckedChanged
        txtCustomExplorerIntegration.Enabled = chkCustomExplorerIntegration.Checked
    End Sub

    Private Sub chkExplorerIntegration_CheckedChanged(ByVal sender As Global.System.Object, ByVal e As Global.System.EventArgs) Handles chkExplorerIntegration.CheckedChanged
        txtCustomExplorerIntegration.Enabled = chkCustomExplorerIntegration.Checked
        chkCustomExplorerIntegration.Enabled = chkExplorerIntegration.Checked
    End Sub

    Private Sub btnAddHighlighting_Click(ByVal sender As Global.System.Object, ByVal e As Global.System.EventArgs) Handles btnAddHighlighting.Click
        frmEditHiglightingType.ShowDialog()
    End Sub
    Private Sub btnEditHighlighting_Click(ByVal sender As Global.System.Object, ByVal e As Global.System.EventArgs) Handles btnEditHighlighting.Click
        frmEditHiglightingType.txtFileType.Text = lvwHighlighting.SelectedItems(0).Text
        frmEditHiglightingType.cbxHighlighting.Text = lvwHighlighting.SelectedItems(0).SubItems(1).Text
        HighlightDialogClose = False
        frmEditHiglightingType.ShowDialog()
        If HighlightDialogClose = True Then
            frmMain.AutoHighligtingRules.Remove(lvwHighlighting.SelectedItems(0).Text & "$%$" & lvwHighlighting.SelectedItems(0).SubItems(1).Text)
            lvwHighlighting.Items.Remove(lvwHighlighting.SelectedItems.Item(0))
        End If
    End Sub

    Private Sub lvwHighlighting_SelectedIndexChanged(ByVal sender As Global.System.Object, ByVal e As Global.System.EventArgs) Handles lvwHighlighting.SelectedIndexChanged

    End Sub

    Private Sub btnRemoveHighlighting_Click(ByVal sender As Global.System.Object, ByVal e As Global.System.EventArgs) Handles btnRemoveHighlighting.Click
        frmMain.AutoHighligtingRules.Remove(lvwHighlighting.SelectedItems(0).Text & "$%$" & lvwHighlighting.SelectedItems(0).SubItems(1).Text)
        lvwHighlighting.Items.Remove(lvwHighlighting.SelectedItems.Item(0))
    End Sub

    Private Sub btnFileTypes_Click(ByVal sender As Global.System.Object, ByVal e As Global.System.EventArgs) Handles btnFileTypes.Click
        frmEditExplorerIntegration.ShowDialog()
    End Sub

    Private Sub btnAddCodeDetection_Click(sender As System.Object, e As System.EventArgs) Handles btnAddCodeDetection.Click
        Dim cbd As New frmEditHiglightingType
        cbd.lblInfo.Text = "Please type the auto detect string you want to add and select " & Environment.NewLine & "the language!"
        cbd.lblFileType.Text = "String:"
        cbd.CodeDetection = True
        cbd.Show()
    End Sub

    Private Sub btnEditCodeDetection_Click(sender As System.Object, e As System.EventArgs) Handles btnEditCodeDetection.Click
        Try
            Dim feh As New frmEditHiglightingType
            feh.txtFileType.Text = lvwCodeDetection.SelectedItems(0).Text
            feh.cbxHighlighting.Text = lvwCodeDetection.SelectedItems(0).SubItems(1).Text
            feh.lblInfo.Text = "Please type the auto detect string you want to add and select " & Environment.NewLine & "the language!"
            feh.lblFileType.Text = "String:"
            feh.CodeDetection = True
            HighlightDialogClose = False
            feh.ShowDialog()
            If HighlightDialogClose = True Then
                frmMain.CodeDetectionRules.Remove(lvwCodeDetection.SelectedItems(0).Text & "`" & lvwCodeDetection.SelectedItems(0).SubItems(1).Text)
                lvwHighlighting.Items.Remove(lvwCodeDetection.SelectedItems.Item(0))
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnRemoveCodeDetection_Click(sender As System.Object, e As System.EventArgs) Handles btnRemoveCodeDetection.Click
        frmMain.CodeDetectionRules.Remove(lvwCodeDetection.SelectedItems(0).Text & "`" & lvwCodeDetection.SelectedItems(0).SubItems(1).Text)
        lvwCodeDetection.Items.Remove(lvwCodeDetection.SelectedItems.Item(0))

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnGetTheme.Click
        frmdownloadtheme.showdialog()
        lstTheme.Items.Clear()
        Dim dinfo As New IO.DirectoryInfo(Application.StartupPath & "\Themes")
        For Each itm In dinfo.GetFiles
            lstTheme.Items.Add(itm.Name.Replace(".dll", "").Replace("_", " "))
        Next
        For i As Integer = 0 To lstTheme.Items.Count - 1
            If lstTheme.Items(i) = theThemeFile.Replace(".dll", "").Replace("_", " ") Then
                lstTheme.SelectedIndex = i
            End If
        Next
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles btnInstallTheme.Click
        Dim ofd As New OpenFileDialog
        ofd.Filter = "DLL Files|*.dll"
        If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
            IO.File.Copy(ofd.FileName, Application.StartupPath & "\Themes\" & ofd.FileName.Substring(ofd.FileName.LastIndexOf("\")).Replace("\", ""))
            lstTheme.Items.Clear()
            Dim dinfo As New IO.DirectoryInfo(Application.StartupPath & "\Themes")
            For Each itm In dinfo.GetFiles
                lstTheme.Items.Add(itm.Name.Replace(".dll", "").Replace("_", " "))
            Next
            For i As Integer = 0 To lstTheme.Items.Count - 1
                If lstTheme.Items(i) = theThemeFile.Replace(".dll", "").Replace("_", " ") Then
                    lstTheme.SelectedIndex = i
                End If
            Next
        End If
    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If lstTheme.Items.Count <> 1 Then
            IO.File.Delete(Application.StartupPath & "\Themes\" & lstTheme.SelectedItem.ToString.Replace(" ", "_") & ".dll")
            Dim dinfo As New IO.DirectoryInfo(Application.StartupPath & "\Themes")
            lstTheme.Items.Clear()
            For Each itm In dinfo.GetFiles
                lstTheme.Items.Add(itm.Name.Replace(".dll", "").Replace("_", " "))
            Next
            lstTheme.SelectedIndex = 0
        End If

    End Sub

    Private Sub lstTheme_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstTheme.SelectedIndexChanged
        Button1.Enabled = True

    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        tcSettings.SelectedIndex = 4
    End Sub
End Class