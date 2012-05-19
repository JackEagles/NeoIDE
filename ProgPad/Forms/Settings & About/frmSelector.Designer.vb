<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelector
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
        Me.components = New System.ComponentModel.Container()
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Toolbar")
        Me.cbxItms = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tvMain = New System.Windows.Forms.TreeView()
        Me.ilMain = New System.Windows.Forms.ImageList(Me.components)
        Me.lblItemsToAdd = New System.Windows.Forms.Label()
        Me.lblToolbar = New System.Windows.Forms.Label()
        Me.tvToolbar = New System.Windows.Forms.TreeView()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cbxItms
        '
        Me.cbxItms.FormattingEnabled = True
        Me.cbxItms.Location = New System.Drawing.Point(141, 30)
        Me.cbxItms.Name = "cbxItms"
        Me.cbxItms.Size = New System.Drawing.Size(163, 21)
        Me.cbxItms.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Choose commands from:"
        '
        'tvMain
        '
        Me.tvMain.ImageIndex = 0
        Me.tvMain.ImageList = Me.ilMain
        Me.tvMain.Location = New System.Drawing.Point(15, 58)
        Me.tvMain.Name = "tvMain"
        Me.tvMain.SelectedImageIndex = 0
        Me.tvMain.Size = New System.Drawing.Size(289, 248)
        Me.tvMain.TabIndex = 2
        '
        'ilMain
        '
        Me.ilMain.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ilMain.ImageSize = New System.Drawing.Size(16, 16)
        Me.ilMain.TransparentColor = System.Drawing.Color.Transparent
        '
        'lblItemsToAdd
        '
        Me.lblItemsToAdd.AutoSize = True
        Me.lblItemsToAdd.Location = New System.Drawing.Point(12, 12)
        Me.lblItemsToAdd.Name = "lblItemsToAdd"
        Me.lblItemsToAdd.Size = New System.Drawing.Size(68, 13)
        Me.lblItemsToAdd.TabIndex = 3
        Me.lblItemsToAdd.Text = "Items to add:"
        '
        'lblToolbar
        '
        Me.lblToolbar.AutoSize = True
        Me.lblToolbar.Location = New System.Drawing.Point(366, 12)
        Me.lblToolbar.Name = "lblToolbar"
        Me.lblToolbar.Size = New System.Drawing.Size(146, 13)
        Me.lblToolbar.TabIndex = 4
        Me.lblToolbar.Text = "Items currently on the toolbar:"
        '
        'tvToolbar
        '
        Me.tvToolbar.Location = New System.Drawing.Point(369, 33)
        Me.tvToolbar.Name = "tvToolbar"
        TreeNode1.Name = "ndToolbar"
        TreeNode1.Text = "Toolbar"
        Me.tvToolbar.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1})
        Me.tvToolbar.Size = New System.Drawing.Size(289, 273)
        Me.tvToolbar.TabIndex = 5
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(310, 131)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(53, 23)
        Me.btnAdd.TabIndex = 6
        Me.btnAdd.Text = "-->"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(310, 160)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(53, 23)
        Me.btnRemove.TabIndex = 7
        Me.btnRemove.Text = "<--"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'frmSelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(666, 318)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.tvToolbar)
        Me.Controls.Add(Me.lblToolbar)
        Me.Controls.Add(Me.lblItemsToAdd)
        Me.Controls.Add(Me.tvMain)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbxItms)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "frmSelector"
        Me.Text = "Select Toolbar Items"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbxItms As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tvMain As System.Windows.Forms.TreeView
    Friend WithEvents ilMain As System.Windows.Forms.ImageList
    Friend WithEvents lblItemsToAdd As System.Windows.Forms.Label
    Friend WithEvents lblToolbar As System.Windows.Forms.Label
    Friend WithEvents tvToolbar As System.Windows.Forms.TreeView
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
End Class
