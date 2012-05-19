<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCodeBlockManager
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
        Me.scDisplay = New ScintillaNet.Scintilla()
        Me.lstMain = New System.Windows.Forms.ListBox()
        Me.tmrSave = New System.Windows.Forms.Timer(Me.components)
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnRemoveSelected = New System.Windows.Forms.Button()
        CType(Me.scDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'scDisplay
        '
        Me.scDisplay.Location = New System.Drawing.Point(204, 12)
        Me.scDisplay.Margins.Margin0.Width = 50
        Me.scDisplay.Name = "scDisplay"
        Me.scDisplay.Size = New System.Drawing.Size(711, 381)
        Me.scDisplay.Styles.BraceBad.FontName = "Verdana"
        Me.scDisplay.Styles.BraceLight.FontName = "Verdana"
        Me.scDisplay.Styles.ControlChar.FontName = "Verdana"
        Me.scDisplay.Styles.Default.FontName = "Verdana"
        Me.scDisplay.Styles.IndentGuide.FontName = "Verdana"
        Me.scDisplay.Styles.LastPredefined.FontName = "Verdana"
        Me.scDisplay.Styles.LineNumber.FontName = "Verdana"
        Me.scDisplay.Styles.Max.FontName = "Verdana"
        Me.scDisplay.TabIndex = 0
        '
        'lstMain
        '
        Me.lstMain.FormattingEnabled = True
        Me.lstMain.Location = New System.Drawing.Point(12, 12)
        Me.lstMain.Name = "lstMain"
        Me.lstMain.Size = New System.Drawing.Size(186, 381)
        Me.lstMain.TabIndex = 1
        '
        'tmrSave
        '
        Me.tmrSave.Interval = 500
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(12, 398)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnRemoveSelected
        '
        Me.btnRemoveSelected.Location = New System.Drawing.Point(93, 399)
        Me.btnRemoveSelected.Name = "btnRemoveSelected"
        Me.btnRemoveSelected.Size = New System.Drawing.Size(105, 23)
        Me.btnRemoveSelected.TabIndex = 3
        Me.btnRemoveSelected.Text = "Remove Selected"
        Me.btnRemoveSelected.UseVisualStyleBackColor = True
        '
        'frmCodeBlockManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(927, 425)
        Me.Controls.Add(Me.btnRemoveSelected)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.lstMain)
        Me.Controls.Add(Me.scDisplay)
        Me.Name = "frmCodeBlockManager"
        Me.Text = "Code Block Manager"
        CType(Me.scDisplay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents scDisplay As ScintillaNet.Scintilla
    Friend WithEvents lstMain As System.Windows.Forms.ListBox
    Friend WithEvents tmrSave As System.Windows.Forms.Timer
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnRemoveSelected As System.Windows.Forms.Button
End Class
