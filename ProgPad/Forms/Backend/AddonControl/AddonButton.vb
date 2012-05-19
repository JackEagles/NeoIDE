Imports System.Drawing.Drawing2D

Public Class AddonButton

    Dim mouseIn As Boolean
    Private Sub AddonButton_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        tmrFade.Start()
    End Sub

    Private Sub tmrFade_Tick(sender As System.Object, e As System.EventArgs) Handles tmrFade.Tick
        Dim ptc As Point = Me.PointToClient(Control.MousePosition)
        mouseIn = Me.ClientRectangle.Contains(ptc)
        If mouseIn = True Then
            If Me.BackColor = Color.White Then
                Me.BackColor = Color.FromArgb(255, 250, 211)
            ElseIf Me.BackColor = Color.FromArgb(255, 250, 211) Then
                Me.BackColor = Color.FromArgb(255, 243, 190)
            ElseIf Me.BackColor = Color.FromArgb(255, 243, 190) Then
                Me.BackColor = Color.FromArgb(255, 236, 162)
            End If
        ElseIf mouseIn = False Then
            If Me.BackColor = Color.FromArgb(255, 236, 162) Then
                Me.BackColor = Color.FromArgb(255, 243, 190)
            ElseIf Me.BackColor = Color.FromArgb(255, 243, 190) Then
                Me.BackColor = Color.FromArgb(255, 250, 211)
            ElseIf Me.BackColor = Color.FromArgb(255, 250, 211) Then
                Me.BackColor = Color.White
            End If
        End If
    End Sub

    Private Sub AddonButton_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        If mouseIn = True Then
            ControlPaint.DrawBorder(e.Graphics, Me.DisplayRectangle, Color.Orange, ButtonBorderStyle.Solid)
        End If
    End Sub
End Class


