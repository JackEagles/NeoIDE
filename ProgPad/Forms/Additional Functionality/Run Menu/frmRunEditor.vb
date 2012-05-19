Imports System.Xml

Public Class frmRunEditor
    Public Sub RefreshRuns()
        lvwMain.Items.Clear()
        Dim runs As New Collection
        Dim reader As New IO.StreamReader(Application.StartupPath & "\Settings\Runs.xml")
        Dim mydoc As New XmlDocument
        mydoc.LoadXml(reader.ReadToEnd)
        For Each itm As XmlNode In mydoc.GetElementsByTagName("Run")
            Dim itms() As String = itm.InnerText.Split("|")
            Dim lvwItm = lvwMain.Items.Add(itms(1))
            lvwItm.SubItems.Add(itms(0))
        Next
        reader.Close()
        reader.Dispose()
    End Sub
    Private Sub frmRunEditor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = New Icon(Application.StartupPath & "\Images\Mainicon.ico")
        RefreshRuns()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        frmAddRun.ShowDialog()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Dim Title As String = lvwMain.SelectedItems.Item(0).SubItems(1).Text & "|" & lvwMain.SelectedItems.Item(0).Text
        Dim runs As New Collection

        Dim reader As New IO.StreamReader(Application.StartupPath & "\Settings\Runs.xml")
        Dim mydoc As New XmlDocument
        mydoc.LoadXml(reader.ReadToEnd)
        For Each itm As XmlNode In mydoc.GetElementsByTagName("Run")
            runs.Add(itm)
        Next
        reader.Close()
        reader.Dispose()

        Dim myXmlWriter As New XmlTextWriter(Application.StartupPath & "\Settings\Runs.xml", Nothing)
        myXmlWriter.Formatting = Formatting.Indented
        myXmlWriter.WriteStartElement("Runs")
        For Each itm As XmlNode In runs
            If itm.ChildNodes.Item(0).InnerText <> Title Then
                myXmlWriter.WriteElementString(itm.Name, itm.InnerText)
            End If
        Next
        myXmlWriter.WriteEndElement()
        myXmlWriter.Close()
        RefreshRuns()
    End Sub
End Class