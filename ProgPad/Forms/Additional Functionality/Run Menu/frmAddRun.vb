Imports System.Xml

Public Class frmAddRun

    Private Sub frmAddRun_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frmMain.RefreshRuns()
    End Sub

    Private Sub frmAddRun_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Icon = New Icon(Application.StartupPath & "\Images\Mainicon.ico")

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
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
            myXmlWriter.WriteElementString(itm.Name, itm.InnerText)
        Next
        myXmlWriter.WriteElementString("Run", txtPath.Text & " | " & txtName.Text)
        myXmlWriter.WriteEndElement()
        myXmlWriter.Close()
        Me.Close()
        frmRunEditor.RefreshRuns()
        frmMain.RefreshRuns()

    End Sub

    Private Sub btnChooseFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChooseFile.Click
        Dim ofd As New OpenFileDialog
        ofd.Title = "Select a program..."
        ofd.Filter = "Executable Files (*.exe)|*.exe|All Files (*.*)|*.*"
        If ofd.ShowDialog = DialogResult.OK Then
            txtPath.Text = ofd.FileName
        End If

    End Sub

    Private Sub txtPath_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPath.TextChanged
        CheckTextBox()
    End Sub

    Private Sub CheckTextBox()
        If txtName.Text = "" Then Exit Sub
        txtName.Text = txtName.Text.Replace("|", "").Replace("""", "").Replace("<", "").Replace(">", "").Replace("/", "").Replace("\", "")
        If txtName.Text.Contains("|") = False Then
            If IO.File.Exists(txtPath.Text) = True Then
                btnAdd.Enabled = True
            Else
                If txtPath.Text.Contains("%") = True Then
                    btnAdd.Enabled = True
                End If
            End If
        Else
            btnAdd.Enabled = False
        End If

    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
        txtPath.Text = ""
        txtName.Text = ""
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
        CheckTextBox()
    End Sub
End Class