Imports System.Xml

Public Class frmEditHiglightingType
    Dim PropExit As Boolean = False
    Public CodeDetection As Boolean
    Private Sub frmEditHiglightingType_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub frmEditHiglightingType_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = New Icon(Application.StartupPath & "\Images\Mainicon.ico")
        For Each itm As ToolStripMenuItem In frmMain.SyntaxHighlightingToolStripMenuItem.DropDownItems
            If itm.Text <> "Custom (from file)" AndAlso itm.Text <> "Code Folding" Then
                cbxHighlighting.Items.Add(itm.Text)
            End If
        Next
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim xmlDoc As New XmlDocument
        If CodeDetection = True Then
            frmMain.CodeDetectionRules.Add(txtFileType.Text & "`" & cbxHighlighting.SelectedItem.ToString)
            Dim lvwItm = frmConfig.lvwCodeDetection.Items.Add(txtFileType.Text)
            lvwItm.SubItems.Add(cbxHighlighting.SelectedItem.ToString)
        Else
            frmMain.AutoHighligtingRules.Add(txtFileType.Text & "$%$" & cbxHighlighting.SelectedItem.ToString)
            Dim lvwItm = frmConfig.lvwHighlighting.Items.Add(txtFileType.Text)
            lvwItm.SubItems.Add(cbxHighlighting.SelectedItem.ToString)
        End If
          frmConfig.HighlightDialogClose = True
        Me.Close()
    End Sub

    Private Sub cbxHighlighting_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbxHighlighting.SelectedIndexChanged
    
    End Sub
End Class