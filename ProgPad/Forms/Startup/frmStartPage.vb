Public Class frmStartPage

    Private Sub frmStartPage_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If frmMain.tcMain.TabPages.Count = 1 AndAlso e.CloseReason <> CloseReason.WindowsShutDown AndAlso e.CloseReason <> CloseReason.MdiFormClosing Then
           e.Cancel = True
        End If
    End Sub

    Private Sub frmStartPage_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Icon = Icon.FromHandle(New Bitmap(Application.StartupPath & "\images\startpage.icon.png").GetHicon)
        rtbChangelog.LoadFile(Application.StartupPath & "\Settings\changelog.rtf")
        ProjectControlContainer1.VScrollBar1.Visible = False
        ProjectControlContainer2.VScrollBar1.Visible = False

        pbIcon.Image = Image.FromFile(Application.StartupPath & "\Images\mainicon.gif")

        Dim OpenProject, CreateProject, NormalEditor As New ProjectControl
        OpenProject.Title.Text = "Open a project"
        OpenProject.ImageBox.Image = Image.FromFile(Application.StartupPath & "\Images\startpage.openproject.png")
        OpenProject.CustomButton1.Visible = False
        CreateProject.Title.Text = "Create a project"
        CreateProject.ImageBox.Image = Image.FromFile(Application.StartupPath & "\Images\startpage.newproject.png")
        AddHandler CreateProject.Click, AddressOf CreateProject_Click
        AddHandler CreateProject.Title.Click, AddressOf CreateProject_Click
        AddHandler CreateProject.ImageBox.Click, AddressOf CreateProject_Click


        NormalEditor.Title.Text = "Create a new file"
        NormalEditor.ImageBox.Image = Image.FromFile(Application.StartupPath & "\Images\startpage.newdocument.png")
        AddHandler NormalEditor.Click, AddressOf CreateNewDocument_Click
        AddHandler NormalEditor.Title.Click, AddressOf CreateNewDocument_Click
        AddHandler NormalEditor.ImageBox.Click, AddressOf CreateNewDocument_Click
        ProjectControlContainer1.Controls.AddRange({OpenProject, CreateProject, NormalEditor})
    End Sub

    Private Sub CreateNewDocument_Click()
        frmMain.CreateNewDoc()
    End Sub

    Private Sub CreateProject_Click()
        frmNewProject.ShowDialog()
    End Sub

    Private Sub Grouper1_Load(sender As System.Object, e As System.EventArgs) Handles Grouper1.Load

    End Sub
End Class