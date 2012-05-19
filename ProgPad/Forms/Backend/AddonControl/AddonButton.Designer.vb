<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddonButton
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
        Me.Title = New System.Windows.Forms.Label()
        Me.Installed = New System.Windows.Forms.Label()
        Me.pnlLabelContainer = New System.Windows.Forms.Panel()
        Me.Description = New System.Windows.Forms.Label()
        Me.ImageBox = New System.Windows.Forms.PictureBox()
        Me.tmrFade = New System.Windows.Forms.Timer(Me.components)
        Me.pnlLabelContainer.SuspendLayout()
        CType(Me.ImageBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Title
        '
        Me.Title.AutoSize = True
        Me.Title.Dock = System.Windows.Forms.DockStyle.Left
        Me.Title.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Title.ForeColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.Title.Location = New System.Drawing.Point(0, 0)
        Me.Title.Name = "Title"
        Me.Title.Size = New System.Drawing.Size(180, 24)
        Me.Title.TabIndex = 1
        Me.Title.Text = "AddonName Addon"
        '
        'Installed
        '
        Me.Installed.AutoSize = True
        Me.Installed.Dock = System.Windows.Forms.DockStyle.Left
        Me.Installed.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.Installed.ForeColor = System.Drawing.Color.FromArgb(CType(CType(117, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.Installed.Location = New System.Drawing.Point(180, 0)
        Me.Installed.Name = "Installed"
        Me.Installed.Size = New System.Drawing.Size(94, 24)
        Me.Installed.TabIndex = 2
        Me.Installed.Text = "-  Installed"
        '
        'pnlLabelContainer
        '
        Me.pnlLabelContainer.Controls.Add(Me.Installed)
        Me.pnlLabelContainer.Controls.Add(Me.Title)
        Me.pnlLabelContainer.Location = New System.Drawing.Point(52, 2)
        Me.pnlLabelContainer.Name = "pnlLabelContainer"
        Me.pnlLabelContainer.Size = New System.Drawing.Size(567, 30)
        Me.pnlLabelContainer.TabIndex = 3
        '
        'Description
        '
        Me.Description.AutoSize = True
        Me.Description.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Description.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Description.Location = New System.Drawing.Point(54, 26)
        Me.Description.Name = "Description"
        Me.Description.Size = New System.Drawing.Size(456, 18)
        Me.Description.TabIndex = 4
        Me.Description.Text = "The AddonName addon implements AddonFunctionality into NeoIDE"
        '
        'ImageBox
        '
        Me.ImageBox.Location = New System.Drawing.Point(3, 1)
        Me.ImageBox.Name = "ImageBox"
        Me.ImageBox.Size = New System.Drawing.Size(48, 48)
        Me.ImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ImageBox.TabIndex = 5
        Me.ImageBox.TabStop = False
        '
        'tmrFade
        '
        Me.tmrFade.Interval = 20
        '
        'AddonButton
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.ImageBox)
        Me.Controls.Add(Me.Description)
        Me.Controls.Add(Me.pnlLabelContainer)
        Me.Name = "AddonButton"
        Me.Size = New System.Drawing.Size(676, 48)
        Me.pnlLabelContainer.ResumeLayout(False)
        Me.pnlLabelContainer.PerformLayout()
        CType(Me.ImageBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Title As System.Windows.Forms.Label
    Friend WithEvents Installed As System.Windows.Forms.Label
    Friend WithEvents pnlLabelContainer As System.Windows.Forms.Panel
    Friend WithEvents Description As System.Windows.Forms.Label
    Friend WithEvents ImageBox As System.Windows.Forms.PictureBox
    Friend WithEvents tmrFade As System.Windows.Forms.Timer

End Class
