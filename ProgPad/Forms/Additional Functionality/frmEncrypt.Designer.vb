<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEncrypt
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSalt = New System.Windows.Forms.TextBox()
        Me.lblSalt = New System.Windows.Forms.Label()
        Me.txtInitVector = New System.Windows.Forms.TextBox()
        Me.lblInitVector = New System.Windows.Forms.Label()
        Me.btnEncrypt = New System.Windows.Forms.Button()
        Me.cbxHash = New System.Windows.Forms.ComboBox()
        Me.lblHashAlgorithm = New System.Windows.Forms.Label()
        Me.chkAdvanced = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(107, 37)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtPassword.Size = New System.Drawing.Size(241, 20)
        Me.txtPassword.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(347, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Please enter applicable values below and perform encryption/decryption"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Password:"
        '
        'txtSalt
        '
        Me.txtSalt.Location = New System.Drawing.Point(107, 95)
        Me.txtSalt.Name = "txtSalt"
        Me.txtSalt.Size = New System.Drawing.Size(241, 20)
        Me.txtSalt.TabIndex = 3
        Me.txtSalt.Text = "t3Nv4r4E9vsjFEkQrfCgVhQXXvrLwEY5yCqaQ6cwjZfvJtwx"
        '
        'lblSalt
        '
        Me.lblSalt.AutoSize = True
        Me.lblSalt.Location = New System.Drawing.Point(9, 98)
        Me.lblSalt.Name = "lblSalt"
        Me.lblSalt.Size = New System.Drawing.Size(28, 13)
        Me.lblSalt.TabIndex = 4
        Me.lblSalt.Text = "Salt:"
        '
        'txtInitVector
        '
        Me.txtInitVector.Location = New System.Drawing.Point(107, 121)
        Me.txtInitVector.Name = "txtInitVector"
        Me.txtInitVector.Size = New System.Drawing.Size(241, 20)
        Me.txtInitVector.TabIndex = 5
        Me.txtInitVector.Text = "8267135479704886"
        '
        'lblInitVector
        '
        Me.lblInitVector.AutoSize = True
        Me.lblInitVector.Location = New System.Drawing.Point(9, 124)
        Me.lblInitVector.Name = "lblInitVector"
        Me.lblInitVector.Size = New System.Drawing.Size(98, 13)
        Me.lblInitVector.TabIndex = 6
        Me.lblInitVector.Text = "Initialization Vector:"
        '
        'btnEncrypt
        '
        Me.btnEncrypt.Location = New System.Drawing.Point(273, 174)
        Me.btnEncrypt.Name = "btnEncrypt"
        Me.btnEncrypt.Size = New System.Drawing.Size(75, 23)
        Me.btnEncrypt.TabIndex = 7
        Me.btnEncrypt.Text = "Encrypt"
        Me.btnEncrypt.UseVisualStyleBackColor = True
        '
        'cbxHash
        '
        Me.cbxHash.FormattingEnabled = True
        Me.cbxHash.Items.AddRange(New Object() {"SHA1 (more secure, slower)", "MD5 (less secure, faster)"})
        Me.cbxHash.Location = New System.Drawing.Point(107, 147)
        Me.cbxHash.Name = "cbxHash"
        Me.cbxHash.Size = New System.Drawing.Size(241, 21)
        Me.cbxHash.TabIndex = 8
        '
        'lblHashAlgorithm
        '
        Me.lblHashAlgorithm.AutoSize = True
        Me.lblHashAlgorithm.Location = New System.Drawing.Point(9, 150)
        Me.lblHashAlgorithm.Name = "lblHashAlgorithm"
        Me.lblHashAlgorithm.Size = New System.Drawing.Size(81, 13)
        Me.lblHashAlgorithm.TabIndex = 9
        Me.lblHashAlgorithm.Text = "Hash Algorithm:"
        '
        'chkAdvanced
        '
        Me.chkAdvanced.AutoSize = True
        Me.chkAdvanced.Location = New System.Drawing.Point(12, 63)
        Me.chkAdvanced.Name = "chkAdvanced"
        Me.chkAdvanced.Size = New System.Drawing.Size(144, 17)
        Me.chkAdvanced.TabIndex = 10
        Me.chkAdvanced.Text = "Modify Advanced Values"
        Me.chkAdvanced.UseVisualStyleBackColor = True
        '
        'frmEncrypt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(360, 202)
        Me.Controls.Add(Me.chkAdvanced)
        Me.Controls.Add(Me.lblHashAlgorithm)
        Me.Controls.Add(Me.cbxHash)
        Me.Controls.Add(Me.btnEncrypt)
        Me.Controls.Add(Me.txtInitVector)
        Me.Controls.Add(Me.lblInitVector)
        Me.Controls.Add(Me.txtSalt)
        Me.Controls.Add(Me.lblSalt)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEncrypt"
        Me.Text = "Encrypt/Decrypt Document"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSalt As System.Windows.Forms.TextBox
    Friend WithEvents lblSalt As System.Windows.Forms.Label
    Friend WithEvents txtInitVector As System.Windows.Forms.TextBox
    Friend WithEvents lblInitVector As System.Windows.Forms.Label
    Friend WithEvents btnEncrypt As System.Windows.Forms.Button
    Friend WithEvents cbxHash As System.Windows.Forms.ComboBox
    Friend WithEvents lblHashAlgorithm As System.Windows.Forms.Label
    Friend WithEvents chkAdvanced As System.Windows.Forms.CheckBox

End Class