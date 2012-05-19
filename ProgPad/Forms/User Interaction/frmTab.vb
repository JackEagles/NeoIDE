Public Class frmTab
    Private Sub frmTab_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = 9 Then
            Try
                lstMain.SelectedIndex += 1
            Catch
                lstMain.SelectedIndex = 0
            End Try
            Exit Sub
        End If
      
        frmMain.tcMain.TabPages(lstMain.SelectedIndex).Select()
        Me.Close()
    End Sub
    Private Sub lstMain_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstMain.LostFocus
        Me.Close()
    End Sub

    Private Sub frmTab_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = New Icon(Application.StartupPath & "\Images\Mainicon.ico")

    End Sub

    Private Sub frmTab_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
 
    End Sub

    Private Sub frmTab_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        frmMain.tcMain.TabPages(lstMain.SelectedIndex).Select()
        Me.Close()
    End Sub
End Class