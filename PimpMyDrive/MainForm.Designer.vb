<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.cbAbout = New System.Windows.Forms.Button()
        Me.tooltipMain = New System.Windows.Forms.ToolTip(Me.components)
        Me.lbSeparator = New System.Windows.Forms.Label()
        Me.cbApply = New System.Windows.Forms.Button()
        Me.cbDrives = New System.Windows.Forms.ComboBox()
        Me.cbRefresh = New System.Windows.Forms.Button()
        Me.tbLabel = New System.Windows.Forms.TextBox()
        Me.pbIcon = New System.Windows.Forms.PictureBox()
        Me.lbLabel = New System.Windows.Forms.Label()
        Me.lbDelete = New System.Windows.Forms.Label()
        Me.lbAdd = New System.Windows.Forms.Label()
        Me.cbClear = New System.Windows.Forms.Button()
        Me.cbExit = New System.Windows.Forms.Button()
        Me.lbDrives = New System.Windows.Forms.Label()
        CType(Me.pbIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbAbout
        '
        Me.cbAbout.Cursor = System.Windows.Forms.Cursors.Help
        Me.cbAbout.Location = New System.Drawing.Point(366, 96)
        Me.cbAbout.Name = "cbAbout"
        Me.cbAbout.Size = New System.Drawing.Size(64, 23)
        Me.cbAbout.TabIndex = 8
        Me.cbAbout.Text = "?"
        Me.cbAbout.UseVisualStyleBackColor = True
        '
        'lbSeparator
        '
        Me.lbSeparator.AutoSize = True
        Me.lbSeparator.ForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.lbSeparator.Location = New System.Drawing.Point(-23, 77)
        Me.lbSeparator.Name = "lbSeparator"
        Me.lbSeparator.Size = New System.Drawing.Size(523, 13)
        Me.lbSeparator.TabIndex = 10
        Me.lbSeparator.Text = "_________________________________________________________________________________" & _
            "_____"
        '
        'cbApply
        '
        Me.cbApply.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.cbApply.Location = New System.Drawing.Point(12, 96)
        Me.cbApply.Name = "cbApply"
        Me.cbApply.Size = New System.Drawing.Size(283, 23)
        Me.cbApply.TabIndex = 6
        Me.cbApply.Text = "Apply"
        Me.cbApply.UseVisualStyleBackColor = True
        '
        'cbDrives
        '
        Me.cbDrives.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDrives.FormattingEnabled = True
        Me.cbDrives.Location = New System.Drawing.Point(54, 13)
        Me.cbDrives.Name = "cbDrives"
        Me.cbDrives.Size = New System.Drawing.Size(240, 21)
        Me.cbDrives.TabIndex = 0
        '
        'cbRefresh
        '
        Me.cbRefresh.Location = New System.Drawing.Point(303, 12)
        Me.cbRefresh.Name = "cbRefresh"
        Me.cbRefresh.Size = New System.Drawing.Size(53, 23)
        Me.cbRefresh.TabIndex = 1
        Me.cbRefresh.Text = "Refresh"
        Me.cbRefresh.UseVisualStyleBackColor = True
        '
        'tbLabel
        '
        Me.tbLabel.Location = New System.Drawing.Point(53, 57)
        Me.tbLabel.Name = "tbLabel"
        Me.tbLabel.Size = New System.Drawing.Size(241, 20)
        Me.tbLabel.TabIndex = 2
        '
        'pbIcon
        '
        Me.pbIcon.BackColor = System.Drawing.Color.Transparent
        Me.pbIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbIcon.Location = New System.Drawing.Point(366, 13)
        Me.pbIcon.Name = "pbIcon"
        Me.pbIcon.Size = New System.Drawing.Size(64, 64)
        Me.pbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbIcon.TabIndex = 27
        Me.pbIcon.TabStop = False
        '
        'lbLabel
        '
        Me.lbLabel.AutoSize = True
        Me.lbLabel.Location = New System.Drawing.Point(9, 60)
        Me.lbLabel.Name = "lbLabel"
        Me.lbLabel.Size = New System.Drawing.Size(39, 13)
        Me.lbLabel.TabIndex = 28
        Me.lbLabel.Text = "Label :"
        '
        'lbDelete
        '
        Me.lbDelete.BackColor = System.Drawing.Color.Transparent
        Me.lbDelete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDelete.Location = New System.Drawing.Point(410, 57)
        Me.lbDelete.Name = "lbDelete"
        Me.lbDelete.Size = New System.Drawing.Size(20, 20)
        Me.lbDelete.TabIndex = 5
        Me.lbDelete.Text = "❌"
        Me.lbDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbAdd
        '
        Me.lbAdd.BackColor = System.Drawing.Color.Transparent
        Me.lbAdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbAdd.Location = New System.Drawing.Point(366, 57)
        Me.lbAdd.Name = "lbAdd"
        Me.lbAdd.Size = New System.Drawing.Size(20, 20)
        Me.lbAdd.TabIndex = 4
        Me.lbAdd.Text = "➕"
        Me.lbAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbClear
        '
        Me.cbClear.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.cbClear.Location = New System.Drawing.Point(303, 55)
        Me.cbClear.Name = "cbClear"
        Me.cbClear.Size = New System.Drawing.Size(53, 23)
        Me.cbClear.TabIndex = 3
        Me.cbClear.Text = "Clear"
        Me.cbClear.UseVisualStyleBackColor = True
        '
        'cbExit
        '
        Me.cbExit.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.cbExit.Location = New System.Drawing.Point(303, 96)
        Me.cbExit.Name = "cbExit"
        Me.cbExit.Size = New System.Drawing.Size(53, 23)
        Me.cbExit.TabIndex = 7
        Me.cbExit.Text = "Exit"
        Me.cbExit.UseVisualStyleBackColor = True
        '
        'lbDrives
        '
        Me.lbDrives.AutoSize = True
        Me.lbDrives.Location = New System.Drawing.Point(9, 16)
        Me.lbDrives.Name = "lbDrives"
        Me.lbDrives.Size = New System.Drawing.Size(38, 13)
        Me.lbDrives.TabIndex = 29
        Me.lbDrives.Text = "Drive :"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(444, 125)
        Me.Controls.Add(Me.lbDrives)
        Me.Controls.Add(Me.cbExit)
        Me.Controls.Add(Me.cbClear)
        Me.Controls.Add(Me.lbAdd)
        Me.Controls.Add(Me.lbDelete)
        Me.Controls.Add(Me.lbLabel)
        Me.Controls.Add(Me.tbLabel)
        Me.Controls.Add(Me.cbRefresh)
        Me.Controls.Add(Me.cbDrives)
        Me.Controls.Add(Me.cbAbout)
        Me.Controls.Add(Me.cbApply)
        Me.Controls.Add(Me.pbIcon)
        Me.Controls.Add(Me.lbSeparator)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.Text = "PimpMyDrive"
        CType(Me.pbIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbAbout As System.Windows.Forms.Button
    Friend WithEvents tooltipMain As System.Windows.Forms.ToolTip
    Friend WithEvents lbSeparator As System.Windows.Forms.Label
    Friend WithEvents cbApply As System.Windows.Forms.Button
    Friend WithEvents cbDrives As System.Windows.Forms.ComboBox
    Friend WithEvents cbRefresh As System.Windows.Forms.Button
    Friend WithEvents tbLabel As System.Windows.Forms.TextBox
    Friend WithEvents pbIcon As System.Windows.Forms.PictureBox
    Friend WithEvents lbLabel As System.Windows.Forms.Label
    Friend WithEvents lbDelete As System.Windows.Forms.Label
    Friend WithEvents lbAdd As System.Windows.Forms.Label
    Friend WithEvents cbClear As System.Windows.Forms.Button
    Friend WithEvents cbExit As System.Windows.Forms.Button
    Friend WithEvents lbDrives As System.Windows.Forms.Label

End Class
