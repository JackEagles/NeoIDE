Imports ScintillaNet
Imports System.IO

Public Class ScintillaEx
    Inherits ScintillaNet.Scintilla
    Public WasTextChanged As Boolean
    Public SavePath As String
    Public DocumentSize As Integer
    Public PromptOnExternal As Boolean = True
    Public IsBackupDocument As Boolean



    Private Sub ScintillaEx_BeforeTextInsert(ByVal sender As Object, ByVal e As ScintillaNET.TextModifiedEventArgs) Handles Me.BeforeTextInsert
        If frmMain.AutoCodeDetection = True Then
            If e.Length > 200 Then
                If Me.Text.Length < 20 Then
                    For Each itm In frmMain.CodeDetectionRules
                        Dim lexerType As String = itm.Substring(itm.LastIndexOf("`"))
                        itm = itm.Replace(lexerType, "")
                        If e.Text.ToLower.StartsWith(itm.ToLower) Then
                            For Each ddItm As ToolStripMenuItem In frmMain.SyntaxHighlightingToolStripMenuItem.DropDownItems
                                If ddItm.Text = lexerType.Substring(1, lexerType.Length - 1) Then
                                    ddItm.PerformClick()
                                End If
                            Next
                        End If
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub ScintillaEx_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If frmMain.MacroRecording = True Then
            If My.Computer.Keyboard.CapsLock = True AndAlso e.Shift = True Then
                MessageBox.Show("Warning: Using the capslock key in conjunction to the shift key while recording macros is likely to cause cataclysmic fuckups. For this reason, recording has been stopped. This issue is being addressed.")
                frmMain.MacroRecording = False
                Exit Sub
            ElseIf e.Shift = True Then
                frmMain.Macro &= "16." & Convert.ToInt32(e.KeyCode) & "."
            ElseIf e.Control = True Then
                frmMain.Macro &= "17." & Convert.ToInt32(e.KeyCode) & "."
            ElseIf My.Computer.Keyboard.CapsLock = True Then
                frmMain.Macro &= "16." & Convert.ToInt32(e.KeyCode) & "."
            Else
                If Convert.ToInt32(e.KeyCode) <> 16 Then
                    frmMain.Macro &= Convert.ToInt32(e.KeyCode) & "."
                End If
            End If
        End If
    End Sub

    Private Sub ScintillaEx_MarginClick(ByVal sender As Object, ByVal e As ScintillaNET.MarginClickEventArgs) Handles Me.MarginClick
        Dim currentLine As ScintillaNET.Line = e.Line
        If e.Margin.AutoToggleMarkerNumber = True Then
            If Me.Markers.GetMarkerMask(currentLine) = 0 Then
                currentLine.AddMarker(0)
            Else
                currentLine.DeleteMarker(0)
            End If
        End If
    End Sub
    Dim tchanges As Integer = 0
    Public Sub New()
        Me.AllowDrop = True
    End Sub
    Dim chngs As Integer = 0

    Private Sub ScintillaEx_SelectionChanged(sender As Object, e As System.EventArgs) Handles Me.SelectionChanged

        Try
            Dim x As String = Me.GetCurrentLine.Substring(0, Me.Lines.Current.SelectionStartPosition - Me.Lines.Current.StartPosition)
            Dim flam As String = Me.GetCurrentLine.Substring(Me.Lines.Current.SelectionStartPosition - Me.Lines.Current.StartPosition, Me.Lines.Current.Length - 1 - Me.Lines.Current.SelectionStartPosition - Me.Lines.Current.StartPosition)

            Dim firstOccurance As String = x.Substring(x.LastIndexOf("<"))
            flam = flam.Substring(0, flam.IndexOf(">"))
            frmMain.Text = firstOccurance & flam
        Catch
        End Try
    End Sub

    Private Sub ScintillaEx_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.TextChanged
        WasTextChanged = True

        If Me.SavePath <> "" Then
            tchanges += 1
            If tchanges = 1 Then
                If SavePath.StartsWith(Application.StartupPath & "\Backup") = False Then
                    WasTextChanged = False
                End If
            End If
        End If
        frmMain.tmrTypingAutoSave.Stop()
        frmMain.tmrTypingAutoSave.Start()
        If frmMain.tmrExpireAutoSave.Enabled = False Then
            frmMain.tmrExpireAutoSave.Start()
        End If
        frmMain.tmrWordCount.Start()
        '     If frmSidebar.Visible = True Then
        ' If frmSidebar.projType = frmSidebar.ProjectType.HTML Then

        '        End If
        '        End If


    End Sub

End Class
