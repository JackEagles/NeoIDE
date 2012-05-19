<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBackup
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

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
        Me.clmnName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clmnSize = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clmnDate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnRecover = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lvwMain
        '
        Me.lvwMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwMain.CheckBoxes = True
        Me.lvwMain.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clmnName, Me.clmnSize, Me.clmnDate})
        Me.lvwMain.FullRowSelect = True
        Me.lvwMain.Location = New System.Drawing.Point(1, 0)
        Me.lvwMain.Name = "lvwMain"
        Me.lvwMain.Size = New System.Drawing.Size(334, 416)
        Me.lvwMain.TabIndex = 1
        Me.lvwMain.UseCompatibleStateImageBehavior = False
        Me.lvwMain.View = System.Windows.Forms.View.Details
        '
        'clmnName
        '
        Me.clmnName.Text = "File Name:"
        Me.clmnName.Width = 162
        '
        'clmnSize
        '
        Me.clmnSize.Text = "Size"
        '
        'clmnDate
        '
        Me.clmnDate.Text = "Date Created"
        Me.clmnDate.Width = 108
        '
        'btnRecover
        '
        Me.btnRecover.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRecover.Location = New System.Drawing.Point(217, 422)
        Me.btnRecover.Name = "btnRecover"
        Me.btnRecover.Size = New System.Drawing.Size(116, 23)
        Me.btnRecover.TabIndex = 2
        Me.btnRecover.Text = "Recover Checked"
        Me.btnRecover.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(157, 422)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(57, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmBackup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(335, 448)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnRecover)
        Me.Controls.Add(Me.lvwMain)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBackup"
        Me.Text = "Recover Lost Documents"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lvwMain As System.Windows.Forms.ListView
    Friend WithEvents clmnName As System.Windows.Forms.ColumnHeader
    Friend WithEvents clmnSize As System.Windows.Forms.ColumnHeader
    Friend WithEvents clmnDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnRecover As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
