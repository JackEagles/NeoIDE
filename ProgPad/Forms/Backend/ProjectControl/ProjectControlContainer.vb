Public Class ProjectControlContainer
    Inherits Panel
    Private Sub AddonButtonContainer_ControlAdded(sender As Object, e As System.Windows.Forms.ControlEventArgs) Handles Me.ControlAdded
        If TypeOf e.Control Is ProjectControl Then
            Me.Invalidate()
            e.Control.Dock = DockStyle.Top
            e.Control.BringToFront()
            e.Control.Size = New Size(e.Control.Width, 36)
            VScrollBar1.Maximum += (Me.Controls.Count - 1)
            Me.Refresh()
        End If
    End Sub

    Private Sub VScrollBar1_Scroll(sender As System.Object, e As System.Windows.Forms.ScrollEventArgs) Handles VScrollBar1.Scroll
        Dim ctrlOnes As Integer = 0
        For i As Integer = 0 To Me.Controls.Count - 1
            Dim itm As Control = Me.Controls(i)
            If TypeOf itm Is ProjectControl Then
                Dim ourITM As ProjectControl = itm
                ourITM.Dock = DockStyle.None
                ourITM.Location = New Point(ourITM.Location.X, -VScrollBar1.Value * 3 + ctrlOnes * 50)
                ctrlOnes += 1
            End If
        Next
    End Sub
End Class
