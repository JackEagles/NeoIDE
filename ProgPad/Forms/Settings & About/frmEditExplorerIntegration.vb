Public Class frmEditExplorerIntegration

    Private Sub frmEditExplorerIntegration_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim savef As New IO.StreamWriter(Application.StartupPath & "\Settings\Explorerfiletypes.nps")
        Dim toWrite As String = ""
        For Each itm In txtFileTypes.Lines
            toWrite &= itm & "$SPLIT$"
        Next
        savef.Write(toWrite)
        savef.Flush()
        savef.Close()
        savef.Dispose()

    End Sub

    Private Sub frmEditExplorerIntegration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtFileTypes.Text = ""
        Me.Icon = New Icon(Application.StartupPath & "\Images\Mainicon.ico")
        Dim loadf As New IO.StreamReader(Application.StartupPath & "\Settings\Explorerfiletypes.nps")
        For Each itm In loadf.ReadToEnd.Split("$SPLIT$")
            If itm <> "SPLIT" Then
                txtFileTypes.Text &= itm & Environment.NewLine
            End If
        Next
        loadf.Close()
        loadf.Dispose()
    End Sub
End Class