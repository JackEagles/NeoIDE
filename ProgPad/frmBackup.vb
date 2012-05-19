Imports WeifenLuo.WinFormsUI.Docking

Public Class frmBackup
    Inherits DockContent
    Dim mbcClosing = False
    
    Private Sub frmBackup_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If mbcClosing = False Then
            If e.CloseReason <> CloseReason.WindowsShutDown Then
                Dim mbRes As DialogResult = MessageBox.Show("If you close the backup window, you will not be able to recover the files listed in the backup window. Are you sure you want to close?", "Close?", MessageBoxButtons.YesNo)
                If mbRes = DialogResult.No Then
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub frmBackup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dinfo As New IO.DirectoryInfo(Application.StartupPath & "\Backup")
        MessageBox.Show("NeoIDE was shut down without warning. NeoIDE has recovered " & dinfo.GetFiles.Count.ToString & " files. These are displayed docked to the left of the program. Please recover & save the ones you wish to keep!", "File Recovery", MessageBoxButtons.OK)
        For Each itm In dinfo.GetFiles
            Dim x = lvwMain.Items.Add(itm.Name)
            Dim sz As String = (itm.Length / 1024).ToString
            Try
                x.SubItems.Add(sz.Replace(sz.Substring(sz.LastIndexOf(".")), "") & " KB")
            Catch ex As Exception
                x.SubItems.Add(sz & " KB")
            End Try
            x.SubItems.Add(itm.LastWriteTime.ToString)
        Next
    End Sub

    Private Sub btnRecover_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecover.Click
        For Each itm As ListViewItem In lvwMain.CheckedItems
            frmMain.CreatingDocumentBackup = True
            frmMain.CreateNewDoc(Application.StartupPath & "\Backup\" & itm.Text)
            frmMain.CreatingDocumentBackup = False
        Next
        mbcClosing = True
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        mbcClosing = True
        Me.Close()
    End Sub

    Private Sub lvwMain_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwMain.Resize
        clmnName.Width = Me.Width * 0.5
        clmnSize.Width = Me.Width * 0.15
        clmnDate.Width = Me.Width * 0.35
    End Sub

    Private Sub lvwMain_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwMain.SelectedIndexChanged

    End Sub
End Class