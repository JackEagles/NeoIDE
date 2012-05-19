Imports WeifenLuo.WinFormsUI.Docking

Public Class frmHTMLSidebar
    Inherits DockContent



    Public Shared Function HTMLEncodeSpecialChars(text As String) As String
        Dim sb As New System.Text.StringBuilder()

        Dim i As Integer
        Dim charArray() As Char = text.ToCharArray()
        ' display contents of charArray
        For i = 0 To charArray.Length - 1
            sb.Append((String.Format("&#{0};", Asc(charArray(i)))))
        Next
        Return sb.ToString()
    End Function

    Private Sub frmHTMLSidebar_LocationChanged(sender As Object, e As System.EventArgs) Handles Me.LocationChanged

    End Sub

    Private Sub frmHTMLSidebar_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class