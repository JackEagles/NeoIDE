<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProjectControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ImageBox = New System.Windows.Forms.PictureBox()
        Me.tmrFade = New System.Windows.Forms.Timer(Me.components)
        Me.Title = New System.Windows.Forms.Label()
        Me.CustomButton1 = New System.Windows.Forms.Button()
        CType(Me.ImageBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageBox
        '
        Me.ImageBox.Location = New System.Drawing.Point(3, 2)
        Me.ImageBox.Name = "ImageBox"
        Me.ImageBox.Size = New System.Drawing.Size(32, 32)
        Me.ImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ImageBox.TabIndex = 5
        Me.ImageBox.TabStop = False
        '
        'tmrFade
        '
        Me.tmrFade.Interval = 20
        '
        'Title
        '
        Me.Title.AutoSize = True
        Me.Title.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Title.ForeColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.Title.Location = New System.Drawing.Point(39, 6)
        Me.Title.Name = "Title"
        Me.Title.Size = New System.Drawing.Size(180, 24)
        Me.Title.TabIndex = 6
        Me.Title.Text = "AddonName Addon"
        '
        'CustomButton1
        '
        Me.CustomButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CustomButton1.FlatAppearance.BorderSize = 0
        Me.CustomButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CustomButton1.Location = New System.Drawing.Point(402, 6)
        Me.CustomButton1.Name = "CustomButton1"
        Me.CustomButton1.Size = New System.Drawing.Size(24, 23)
        Me.CustomButton1.TabIndex = 7
        Me.CustomButton1.UseVisualStyleBackColor = False
        '
        'ProjectControl
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.CustomButton1)
        Me.Controls.Add(Me.Title)
        Me.Controls.Add(Me.ImageBox)
        Me.Name = "ProjectControl"
        Me.Size = New System.Drawing.Size(433, 36)
        CType(Me.ImageBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ImageBox As System.Windows.Forms.PictureBox
    Friend WithEvents tmrFade As System.Windows.Forms.Timer
    Friend WithEvents Title As System.Windows.Forms.Label
    Friend WithEvents CustomButton1 As System.Windows.Forms.Button

End Class
