Imports System.ComponentModel

Public Class frmInsertSymbol
    Private Sub frmInsertSymbol_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = New Icon(Application.StartupPath & "\Images\Mainicon.ico")
        Dim loadf As New IO.StreamReader(Application.StartupPath & "\Settings\Symbols.nps")

        For Each itm In loadf.ReadToEnd.Split(Environment.NewLine)
            lvwMain.Items.Add(itm)
        Next
    End Sub

    Private Sub lvwMain_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwMain.DoubleClick
        frmMain.SelScintilla.InsertText(lvwMain.SelectedItems.Item(0).Text)
    End Sub

    Private Sub lvwMain_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwMain.SelectedIndexChanged

    End Sub

End Class