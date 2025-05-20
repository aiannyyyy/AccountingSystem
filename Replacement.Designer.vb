<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Replacement
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Replacement))
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.replace = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.labid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.newlabid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.test_type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.date_replace = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.addButton = New System.Windows.Forms.Button()
        Me.GunaLabel3 = New Guna.UI.WinForms.GunaLabel()
        Me.amountTxt = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel4 = New Guna.UI.WinForms.GunaLabel()
        Me.soaTxt = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel5 = New Guna.UI.WinForms.GunaLabel()
        Me.codeTxt = New Guna.UI.WinForms.GunaTextBox()
        Me.dtpicker2 = New Guna.UI.WinForms.GunaDateTimePicker()
        Me.GunaLabel6 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.replaceCountTxt = New Guna.UI.WinForms.GunaTextBox()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.replace, Me.labid, Me.newlabid, Me.test_type, Me.date_replace})
        Me.dgv1.Location = New System.Drawing.Point(12, 173)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.Size = New System.Drawing.Size(468, 190)
        Me.dgv1.TabIndex = 31
        '
        'replace
        '
        Me.replace.HeaderText = "REPLACE"
        Me.replace.Name = "replace"
        '
        'labid
        '
        Me.labid.DataPropertyName = "labid"
        Me.labid.HeaderText = "LABID"
        Me.labid.Name = "labid"
        '
        'newlabid
        '
        Me.newlabid.DataPropertyName = "newlabid"
        Me.newlabid.HeaderText = "REPLACED"
        Me.newlabid.Name = "newlabid"
        '
        'test_type
        '
        Me.test_type.DataPropertyName = "test_type"
        Me.test_type.HeaderText = "TYPE"
        Me.test_type.Name = "test_type"
        '
        'date_replace
        '
        Me.date_replace.DataPropertyName = "date_replace"
        Me.date_replace.HeaderText = "DATE REPLACE"
        Me.date_replace.Name = "date_replace"
        '
        'addButton
        '
        Me.addButton.Location = New System.Drawing.Point(207, 130)
        Me.addButton.Name = "addButton"
        Me.addButton.Size = New System.Drawing.Size(84, 37)
        Me.addButton.TabIndex = 38
        Me.addButton.Text = "ADD"
        Me.addButton.UseVisualStyleBackColor = True
        '
        'GunaLabel3
        '
        Me.GunaLabel3.AutoSize = True
        Me.GunaLabel3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel3.Location = New System.Drawing.Point(282, 63)
        Me.GunaLabel3.Name = "GunaLabel3"
        Me.GunaLabel3.Size = New System.Drawing.Size(67, 17)
        Me.GunaLabel3.TabIndex = 39
        Me.GunaLabel3.Text = "AMOUNT:"
        '
        'amountTxt
        '
        Me.amountTxt.BackColor = System.Drawing.Color.Black
        Me.amountTxt.BaseColor = System.Drawing.Color.White
        Me.amountTxt.BorderColor = System.Drawing.Color.Black
        Me.amountTxt.BorderSize = 1
        Me.amountTxt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.amountTxt.FocusedBaseColor = System.Drawing.Color.White
        Me.amountTxt.FocusedBorderColor = System.Drawing.Color.Black
        Me.amountTxt.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.amountTxt.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.amountTxt.Location = New System.Drawing.Point(355, 56)
        Me.amountTxt.Name = "amountTxt"
        Me.amountTxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.amountTxt.SelectedText = ""
        Me.amountTxt.Size = New System.Drawing.Size(116, 28)
        Me.amountTxt.TabIndex = 40
        Me.amountTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaLabel4
        '
        Me.GunaLabel4.AutoSize = True
        Me.GunaLabel4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel4.Location = New System.Drawing.Point(18, 21)
        Me.GunaLabel4.Name = "GunaLabel4"
        Me.GunaLabel4.Size = New System.Drawing.Size(93, 17)
        Me.GunaLabel4.TabIndex = 41
        Me.GunaLabel4.Text = "SOA NUMBER:"
        '
        'soaTxt
        '
        Me.soaTxt.BackColor = System.Drawing.Color.Black
        Me.soaTxt.BaseColor = System.Drawing.Color.White
        Me.soaTxt.BorderColor = System.Drawing.Color.Black
        Me.soaTxt.BorderSize = 1
        Me.soaTxt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.soaTxt.FocusedBaseColor = System.Drawing.Color.White
        Me.soaTxt.FocusedBorderColor = System.Drawing.Color.Black
        Me.soaTxt.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.soaTxt.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.soaTxt.Location = New System.Drawing.Point(117, 17)
        Me.soaTxt.Name = "soaTxt"
        Me.soaTxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.soaTxt.SelectedText = ""
        Me.soaTxt.Size = New System.Drawing.Size(116, 28)
        Me.soaTxt.TabIndex = 42
        Me.soaTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaLabel5
        '
        Me.GunaLabel5.AutoSize = True
        Me.GunaLabel5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel5.Location = New System.Drawing.Point(15, 63)
        Me.GunaLabel5.Name = "GunaLabel5"
        Me.GunaLabel5.Size = New System.Drawing.Size(96, 17)
        Me.GunaLabel5.TabIndex = 43
        Me.GunaLabel5.Text = "FACILITY CODE:"
        '
        'codeTxt
        '
        Me.codeTxt.BackColor = System.Drawing.Color.Black
        Me.codeTxt.BaseColor = System.Drawing.Color.White
        Me.codeTxt.BorderColor = System.Drawing.Color.Black
        Me.codeTxt.BorderSize = 1
        Me.codeTxt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.codeTxt.FocusedBaseColor = System.Drawing.Color.White
        Me.codeTxt.FocusedBorderColor = System.Drawing.Color.Black
        Me.codeTxt.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.codeTxt.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.codeTxt.Location = New System.Drawing.Point(117, 56)
        Me.codeTxt.Name = "codeTxt"
        Me.codeTxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.codeTxt.SelectedText = ""
        Me.codeTxt.Size = New System.Drawing.Size(116, 28)
        Me.codeTxt.TabIndex = 44
        Me.codeTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dtpicker2
        '
        Me.dtpicker2.BackColor = System.Drawing.Color.Transparent
        Me.dtpicker2.BaseColor = System.Drawing.Color.White
        Me.dtpicker2.BorderColor = System.Drawing.Color.Black
        Me.dtpicker2.CustomFormat = Nothing
        Me.dtpicker2.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.dtpicker2.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.dtpicker2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpicker2.ForeColor = System.Drawing.Color.Black
        Me.dtpicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpicker2.Location = New System.Drawing.Point(355, 15)
        Me.dtpicker2.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpicker2.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpicker2.Name = "dtpicker2"
        Me.dtpicker2.OnHoverBaseColor = System.Drawing.Color.White
        Me.dtpicker2.OnHoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.dtpicker2.OnHoverForeColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.dtpicker2.OnPressedColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.dtpicker2.Radius = 2
        Me.dtpicker2.Size = New System.Drawing.Size(118, 30)
        Me.dtpicker2.TabIndex = 46
        Me.dtpicker2.Text = "5/30/2024"
        Me.dtpicker2.Value = New Date(2024, 5, 30, 16, 46, 27, 716)
        '
        'GunaLabel6
        '
        Me.GunaLabel6.AutoSize = True
        Me.GunaLabel6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel6.Location = New System.Drawing.Point(241, 21)
        Me.GunaLabel6.Name = "GunaLabel6"
        Me.GunaLabel6.Size = New System.Drawing.Size(108, 17)
        Me.GunaLabel6.TabIndex = 45
        Me.GunaLabel6.Text = "PURCHASE DATE:"
        '
        'GunaLabel1
        '
        Me.GunaLabel1.AutoSize = True
        Me.GunaLabel1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel1.Location = New System.Drawing.Point(15, 101)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(146, 17)
        Me.GunaLabel1.TabIndex = 47
        Me.GunaLabel1.Text = "REPLACEMENT COUNT:"
        '
        'replaceCountTxt
        '
        Me.replaceCountTxt.BackColor = System.Drawing.Color.Black
        Me.replaceCountTxt.BaseColor = System.Drawing.Color.White
        Me.replaceCountTxt.BorderColor = System.Drawing.Color.Black
        Me.replaceCountTxt.BorderSize = 1
        Me.replaceCountTxt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.replaceCountTxt.FocusedBaseColor = System.Drawing.Color.White
        Me.replaceCountTxt.FocusedBorderColor = System.Drawing.Color.Black
        Me.replaceCountTxt.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.replaceCountTxt.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.replaceCountTxt.Location = New System.Drawing.Point(165, 96)
        Me.replaceCountTxt.Name = "replaceCountTxt"
        Me.replaceCountTxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.replaceCountTxt.SelectedText = ""
        Me.replaceCountTxt.Size = New System.Drawing.Size(116, 28)
        Me.replaceCountTxt.TabIndex = 48
        Me.replaceCountTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Replacement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(492, 375)
        Me.Controls.Add(Me.replaceCountTxt)
        Me.Controls.Add(Me.GunaLabel1)
        Me.Controls.Add(Me.dtpicker2)
        Me.Controls.Add(Me.GunaLabel6)
        Me.Controls.Add(Me.codeTxt)
        Me.Controls.Add(Me.GunaLabel5)
        Me.Controls.Add(Me.soaTxt)
        Me.Controls.Add(Me.GunaLabel4)
        Me.Controls.Add(Me.amountTxt)
        Me.Controls.Add(Me.GunaLabel3)
        Me.Controls.Add(Me.addButton)
        Me.Controls.Add(Me.dgv1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Replacement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Replacement"
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgv1 As DataGridView
    Friend WithEvents addButton As Button
    Friend WithEvents GunaLabel3 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents amountTxt As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel4 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents soaTxt As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel5 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents codeTxt As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents dtpicker2 As Guna.UI.WinForms.GunaDateTimePicker
    Friend WithEvents GunaLabel6 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents replace As DataGridViewCheckBoxColumn
    Friend WithEvents labid As DataGridViewTextBoxColumn
    Friend WithEvents newlabid As DataGridViewTextBoxColumn
    Friend WithEvents test_type As DataGridViewTextBoxColumn
    Friend WithEvents date_replace As DataGridViewTextBoxColumn
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents replaceCountTxt As Guna.UI.WinForms.GunaTextBox
End Class
