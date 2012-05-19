Public Class frmSave

    Private Sub frmSave_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If mClose = False Then
            e.Cancel = True
            MessageBox.Show("You still have pending save operations. Please select the items you wish to save and click 'Save Checked'. Otherwise click 'Discard All' or 'Cancel'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub frmSave_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clbToSave.Items.Clear()
        For Each itm In frmMain.DocsToSave
            If CType(itm, ScintillaEx).SavePath <> "" Then
                clbToSave.Items.Add(CType(itm, ScintillaEx).SavePath & " - " & itm.Handle.ToInt32)
            Else
                If itm.Text.Length > 40 Then
                    clbToSave.Items.Add("New Document: " & itm.Text.Substring(0, 40).Replace(Environment.NewLine, "") & "..." & " - " & itm.Handle.ToInt32)
                Else
                    clbToSave.Items.Add("New Document: " & itm.Text.Replace(Environment.NewLine, "") & " - " & itm.Handle.ToInt32)
                End If
            End If
        Next
        For i As Integer = 0 To clbToSave.Items.Count - 1
            clbToSave.SetItemChecked(i, True)
        Next
    End Sub


    '     Dim mbresult As DialogResult = MessageBox.Show("The document: '" & tb.Text & "' has not been saved. Do you want to save it now?", "Document not Saved", MessageBoxButtons.YesNoCancel)
    '     If mbresult = Windows.Forms.DialogResult.Yes Then
    '         If CType(tb.Controls.Item(0), ScintillaEx).SavePath <> "" Then
    '             If SaveDocument(CType(tb.Controls.Item(0), ScintillaEx), CType(tb.Controls.Item(0), ScintillaEx).SavePath) = False Then
    '                 e.Cancel = True
    '             End If
    '         Else
    '             If SaveDocument(CType(tb.Controls.Item(0), ScintillaEx)) = False Then
    '                 e.Cancel = True
    '             End If
    '         End If
    '     ElseIf mbresult = DialogResult.Cancel Then
    '         e.Cancel = True
    '        Exit Sub
    '   End If

    Private Sub clbToSave_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clbToSave.SelectedIndexChanged

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        mClose = True
        Me.Close()
    End Sub

    Private Sub btnDiscard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDiscard.Click
        mClose = True
        Me.Close()
    End Sub
    Dim mClose As Boolean = True

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        mClose = True

        For Each itm In clbToSave.CheckedItems
            Dim handle As String = itm.ToString.Substring(itm.ToString.LastIndexOf(" - ")).Replace(" - ", "")

            For Each tb In frmMain.tcMain.Controls(2).Controls
                If CType(tb.Controls(0), ScintillaEx).Handle.ToInt32 = handle Then

                    If My.Computer.FileSystem.FileExists(itm.ToString.Replace(" - " & handle, "")) Then
                        If frmMain.SaveDocument(CType(tb.Controls.Item(0), ScintillaEx), itm.ToString.Replace(" - " & handle, "")) = False Then
                            mClose = False
                        End If
                    Else
                        If frmMain.SaveDocument(CType(tb.Controls.Item(0), ScintillaEx)) = False Then
                            mClose = False
                        End If
                    End If
                End If
            Next
        Next
        If mClose = True Then
            Me.Close()
        End If
    End Sub
End Class