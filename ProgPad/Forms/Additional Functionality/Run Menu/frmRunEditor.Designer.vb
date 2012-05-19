<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRunEditor
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
        Me.lvwMain = New System.Windows.Forms.ListView()
        Me.hdrTitle = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.hdrPath = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lvwMain
        '
        Me.lvwMain.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwMain.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.hdrTitle, Me.hdrPath})
        Me.lvwMain.FullRowSelect = True
        Me.lvwMain.Location = New System.Drawing.Point(0, 0)
        Me.lvwMain.MultiSelect = False
        Me.lvwMain.Name = "lvwMain"
        Me.lvwMain.Size = New System.Drawing.Size(694, 175)
        Me.lvwMain.TabIndex = 0
        Me.lvwMain.UseCompatibleStateImageBehavior = False
        Me.lvwMain.View = System.Windows.Forms.View.Details
        '
        'hdrTitle
        '
        Me.hdrTitle.Text = "Program Name"
        Me.hdrTitle.Width = 172
        '
        'hdrPath
        '
        Me.hdrPath.Text = "Location"
        Me.hdrPath.Width = 517
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(484, 181)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(102, 24)
        Me.btnRemove.TabIndex = 6
        Me.btnRemove.Text = "Remove Selected"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(592, 181)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(102, 24)
        Me.btnAdd.TabIndex = 8
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(376, 181)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(102, 24)
        Me.btnExit.TabIndex = 9
        Me.btnExit.Text = "Close"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmRunEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(695, 210)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.lvwMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "frmRunEditor"
        Me.Text = "Run Editor"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lvwMain As System.Windows.Forms.ListView
    Friend WithEvents hdrTitle As System.Windows.Forms.ColumnHeader
    Friend WithEvents hdrPath As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
End Class
