Public Class frmMacroManager

    Private Sub frmMacroManager_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frmMain.LoadMacros()
        Me.Dispose()
    End Sub

    Private Sub frmMacroManager_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Icon = New Icon(Application.StartupPath & "\Images\Mainicon.ico")
        Dim dinfo As New IO.DirectoryInfo(Application.StartupPath & "\Runtime\Macros")
        For Each itm In dinfo.GetFiles
            lstMacros.Items.Add(itm.Name.Replace(".npm", ""))
        Next
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Runtime\Macros\" & lstMacros.SelectedItem.ToString & ".npm")
            lstMacros.Items.Clear()
            Dim dinfo As New IO.DirectoryInfo(Application.StartupPath & "\Runtime\Macros")
            For Each itm In dinfo.GetFiles
                lstMacros.Items.Add(itm.Name.Replace(".npm", ""))
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class