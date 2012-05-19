Public Class frmCodeDomOptions

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim ib As String = InputBox("Please enter the name of the reference you want to add, for instance 'System.Windows.Forms.dll", "Add a reference", "System.Windows.Forms.dll")
        lstReferences.Items.Add(ib)
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        lstReferences.Items.Remove(lstReferences.SelectedItem)

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim sfd As New SaveFileDialog
        If cbxTarget.SelectedIndex = 1 Then
            sfd.Filter = "Dynamic Link Libraries|*.dll"
        Else
            sfd.Filter = "Executable Files|*.exe"
        End If
        If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtOutputPath.Text = sfd.FileName
        End If
    End Sub

    Private Sub frmCodeDomOptions_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Icon = New Icon(Application.StartupPath & "\Images\Mainicon.ico")
        cbxTarget.SelectedIndex = 0
    End Sub

    'Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
    '    If cbxTarget.SelectedIndex = 0 Then
    '        frmMain.SelScintilla.CompilerApplicationType = "Console"
    '        If txtOutputPath.Text.EndsWith(".exe") = False Then
    '            Exit Sub
    '        End If
    '    ElseIf cbxTarget.SelectedIndex = 1 Then
    '        frmMain.SelScintilla.CompilerApplicationType = "Library"
    '        If txtOutputPath.Text.EndsWith(".dll") = False Then
    '            Exit Sub
    '        End If
    '    ElseIf cbxTarget.SelectedIndex = 2 Then
    '        frmMain.SelScintilla.CompilerApplicationType = "WinForms"
    '        If txtOutputPath.Text.EndsWith(".exe") = False Then
    '            Exit Sub
    '        End If
    '    End If

    '    Dim ref As String = ""
    '    For Each itm In lstReferences.Items
    '        ref &= itm & " "
    '    Next
    '    ref = ref.Substring(0, ref.Length - 1)
    '    frmMain.SelScintilla.CompilerReferences = ref.Split(" ")
    '    frmMain.compiler.Platform = Platform.AnyCPU
    '    frmMain.SelScintilla.CompilerIconPath = txtIconPath.Text
    '    frmMain.SelScintilla.CompilerOutPath = txtOutputPath.Text
    '    Dim lineColl As New Collection
    '    For Each ln As ScintillaNET.Line In frmMain.SelScintilla.Lines
    '        If ln.Text.Replace(" ", "").StartsWith("Imports") Then
    '            ln.Text = ""
    '        End If
    '    Next
    '    frmMain.SelScintilla.GoTo.Line(0)
    '    For Each itm In lstReferences.Items
    '        frmMain.SelScintilla.InsertText("Imports " & itm.ToString.ToLower.Replace(".dll", "") & Environment.NewLine)
    '    Next
    '    Me.Close()
    'End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim ofd As New OpenFileDialog
        ofd.Filter = "Icon Files|*.ico"
        ofd.Title = "Select an icon"
        If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtIconPath.Text = ofd.FileName
        End If
    End Sub

    Private Sub txtOutputPath_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtOutputPath.TextChanged
     
    End Sub
End Class