<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInstalling
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
        Me.rbInstall = New System.Windows.Forms.RadioButton()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.rbPortable = New System.Windows.Forms.RadioButton()
        Me.txtInstallLocation = New System.Windows.Forms.TextBox()
        Me.lblInstLoc = New System.Windows.Forms.Label()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.chkInstallFeatures = New System.Windows.Forms.CheckBox()
        Me.btnProceed = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'rbInstall
        '
        Me.rbInstall.AutoSize = True
        Me.rbInstall.Checked = True
        Me.rbInstall.Location = New System.Drawing.Point(21, 34)
        Me.rbInstall.Name = "rbInstall"
        Me.rbInstall.Size = New System.Drawing.Size(52, 17)
        Me.rbInstall.TabIndex = 0
        Me.rbInstall.TabStop = True
        Me.rbInstall.Text = "Install"
        Me.rbInstall.UseVisualStyleBackColor = True
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.Location = New System.Drawing.Point(12, 9)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(343, 13)
        Me.lblInfo.TabIndex = 1
        Me.lblInfo.Text = "Please select whether you would like to install NeoIDE or not:"
        '
        'rbPortable
        '
        Me.rbPortable.AutoSize = True
        Me.rbPortable.Location = New System.Drawing.Point(21, 117)
        Me.rbPortable.Name = "rbPortable"
        Me.rbPortable.Size = New System.Drawing.Size(162, 17)
        Me.rbPortable.TabIndex = 2
        Me.rbPortable.Text = "Use as a portable application"
        Me.rbPortable.UseVisualStyleBackColor = True
        '
        'txtInstallLocation
        '
        Me.txtInstallLocation.Location = New System.Drawing.Point(119, 60)
        Me.txtInstallLocation.Name = "txtInstallLocation"
        Me.txtInstallLocation.Size = New System.Drawing.Size(217, 20)
        Me.txtInstallLocation.TabIndex = 3
        '
        'lblInstLoc
        '
        Me.lblInstLoc.AutoSize = True
        Me.lblInstLoc.Location = New System.Drawing.Point(32, 63)
        Me.lblInstLoc.Name = "lblInstLoc"
        Me.lblInstLoc.Size = New System.Drawing.Size(81, 13)
        Me.lblInstLoc.TabIndex = 4
        Me.lblInstLoc.Text = "Install Location:"
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(342, 60)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(36, 20)
        Me.btnBrowse.TabIndex = 5
        Me.btnBrowse.Text = "..."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'chkInstallFeatures
        '
        Me.chkInstallFeatures.AutoSize = True
        Me.chkInstallFeatures.Location = New System.Drawing.Point(35, 86)
        Me.chkInstallFeatures.Name = "chkInstallFeatures"
        Me.chkInstallFeatures.Size = New System.Drawing.Size(185, 17)
        Me.chkInstallFeatures.TabIndex = 6
        Me.chkInstallFeatures.Text = "Create shortcuts, install entry, etc."
        Me.chkInstallFeatures.UseVisualStyleBackColor = True
        '
        'btnProceed
        '
        Me.btnProceed.Location = New System.Drawing.Point(304, 114)
        Me.btnProceed.Name = "btnProceed"
        Me.btnProceed.Size = New System.Drawing.Size(74, 20)
        Me.btnProceed.TabIndex = 7
        Me.btnProceed.Text = "Proceed"
        Me.btnProceed.UseVisualStyleBackColor = True
        '
        'frmInstalling
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(400, 146)
        Me.Controls.Add(Me.btnProceed)
        Me.Controls.Add(Me.chkInstallFeatures)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.lblInstLoc)
        Me.Controls.Add(Me.txtInstallLocation)
        Me.Controls.Add(Me.rbPortable)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.rbInstall)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInstalling"
        Me.Text = "First run Preferences"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rbInstall As System.Windows.Forms.RadioButton
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents rbPortable As System.Windows.Forms.RadioButton
    Friend WithEvents txtInstallLocation As System.Windows.Forms.TextBox
    Friend WithEvents lblInstLoc As System.Windows.Forms.Label
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents chkInstallFeatures As System.Windows.Forms.CheckBox
    Friend WithEvents btnProceed As System.Windows.Forms.Button
End Class
