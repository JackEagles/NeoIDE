Public Class AlertControl
    Public Sub New(ByVal Message As String, MessageFont As Font, ByVal BackColor As Color, Optional ByVal ControHeight As Integer = 35, Optional ByVal MessageYPos As Integer = 5)

        InitializeComponent()
        Me.AutoSize = False
        Me.Dock = DockStyle.Top
        Me.Label1.Font = MessageFont
        Me.Label1.Text = Message
        Me.BackColor = BackColor
        Me.Height = ControHeight
        Me.Location = New Point(Me.Location.X, MessageYPos)
        Command1.Height = ControHeight - 5
        Command2.Height = ControHeight - 5

    End Sub



    Private Sub AlertControl_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub


End Class
