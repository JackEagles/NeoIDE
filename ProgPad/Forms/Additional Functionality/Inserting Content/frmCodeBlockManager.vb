Public Class frmCodeBlockManager

    Private Sub frmCodeBlockManager_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frmMain.loadCodeBlocks()
        Me.Dispose()
    End Sub

    Private Sub frmCodeBlockManager_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = New Icon(Application.StartupPath & "\Images\Mainicon.ico")
        Try
            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Runtime\Code Blocks\") = False Then
                MkDir(Application.StartupPath & "\Runtime\Code Blocks\")
            End If
        Catch ex As Exception
        End Try
        Try
            Dim dinfo As New IO.DirectoryInfo(Application.StartupPath & "\Runtime\Code Blocks\")
            For Each itm In dinfo.GetFiles
                If itm.Extension = ".npcb" Then
                    lstMain.Items.Add(itm.Name.Replace(itm.Extension, ""))
                End If
            Next
            lstMain.SelectedIndex = 0
        Catch
        End Try
    End Sub

    Private Sub tmrSave_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrSave.Tick
        tmrSave.Stop()
        On Error Resume Next
        Dim save As New IO.StreamWriter(Application.StartupPath & "\Runtime\Code Blocks\" & lstMain.SelectedItem.ToString & ".npcb")
        save.Write(scDisplay.Text)
        save.Close()
        save.Dispose()
    End Sub

    Private Sub scDisplay_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles scDisplay.TextChanged
        tmrSave.Start()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim ib As String = InputBox("Please enter a name for your Code Block", "Code Block Name", "")
        ib = ib.Replace("\", "").Replace("/", "").Replace("|", "").Replace("<", "").Replace(">", "").Replace(":", "").Replace("*", "").Replace("""", "").Replace("?", "")
        If ib <> "" Then
            lstMain.Items.Add(ib)
            scDisplay.Text = ""
            tmrSave.Start()
            lstMain.SelectedIndex = lstMain.Items.Count - 1
        End If
    End Sub

    Private Sub lstMain_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstMain.SelectedIndexChanged
        On Error Resume Next
        Dim loader As New IO.StreamReader(Application.StartupPath & "\Runtime\Code Blocks\" & lstMain.SelectedItem.ToString & ".npcb")
        scDisplay.Text = loader.ReadToEnd
        loader.Close()
        loader.Dispose()
    End Sub

    Private Sub btnRemoveSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveSelected.Click
        On Error Resume Next
        My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Runtime\Code Blocks\" & lstMain.SelectedItem.ToString & ".npcb")
        lstMain.Items.RemoveAt(lstMain.SelectedIndex)
        scDisplay.Text = ""
        lstMain.SelectedIndex = lstMain.Items.Count - 1
    End Sub
End Class