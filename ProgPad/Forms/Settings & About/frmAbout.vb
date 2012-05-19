Public Class frmAbout

    Private Sub tmrScroll_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrScroll.Tick
        For Each ctl In Me.Controls
            If TypeOf ctl Is Label Then
                Dim x As Label = DirectCast(ctl, Label)
                Select Case x.Location.Y
                    Case pbMain.Location.Y + pbMain.Height - 15 To pbMain.Location.Y + pbMain.Height - 7
                        x.ForeColor = Color.Gainsboro
                    Case pbMain.Location.Y + pbMain.Height - 6 To pbMain.Location.Y + pbMain.Height - 3
                        x.ForeColor = Color.LightGray
                    Case pbMain.Location.Y + pbMain.Height - 2 To pbMain.Location.Y + pbMain.Height
                        x.ForeColor = Color.Silver
                    Case pbMain.Location.Y + pbMain.Height + 1 To pbMain.Location.Y + pbMain.Height + 3
                        x.ForeColor = Color.DarkGray
                    Case pbMain.Location.Y + pbMain.Height + 4 To pbMain.Location.Y + pbMain.Height + 7
                        x.ForeColor = Color.Gray
                    Case pbMain.Location.Y + pbMain.Height + 8 To pbMain.Location.Y + pbMain.Height + 11
                        x.ForeColor = Color.DimGray
                    Case 350 To 355
                        x.ForeColor = Color.DimGray
                    Case 356 To 360
                        x.ForeColor = Color.Gray
                    Case 361 To 365
                        x.ForeColor = Color.DarkGray
                    Case 366 To 370
                        x.ForeColor = Color.Silver
                    Case 371 To 375
                        x.ForeColor = Color.LightGray
                    Case 376 To 380
                        x.ForeColor = Color.Gainsboro
                    Case Else
                        x.ForeColor = Me.ForeColor
                End Select
                x.Location = New Point(x.Location.X, x.Location.Y - 1)
                If x.Location.Y < pbMain.Location.Y + pbMain.Height - 15 Then
                    x.Location = New Point(x.Location.X, Me.Height + 150)
                End If
            End If
        Next


    End Sub



    Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pbMain.BackgroundImage = Image.FromFile(Application.StartupPath & "\Images\Mainicon.png")
        Me.Icon = New Icon(Application.StartupPath & "\Images\Mainicon.ico")
        lblMsg.Text = "NeoIDE v" & My.Settings.Version
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub
    Dim codeinfo As Boolean
    Private Sub btnCodeInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCodeInfo.Click
        If codeinfo = False Then
            codeinfo = True
        ElseIf codeinfo = True Then
            codeinfo = False
        End If
        lvwCodeInfo.Visible = codeinfo
        txtChangelog.Visible = False
        tmrScroll.Enabled = Not codeinfo
    End Sub

    Dim changelog As Boolean

    Private Sub btnChangelog_Click(sender As System.Object, e As System.EventArgs) Handles btnChangelog.Click
        If changelog = False Then
            changelog = True
        ElseIf changelog = True Then
            changelog = False
        End If
        lvwCodeInfo.Visible = False
        txtChangelog.Visible = changelog
        tmrScroll.Enabled = Not changelog

    End Sub
End Class