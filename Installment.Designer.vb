<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Installment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Installment))
        Me.codeTxt = New Guna.UI.WinForms.GunaLineTextBox()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.dgv2 = New System.Windows.Forms.DataGridView()
        Me.GunaLabel2 = New Guna.UI.WinForms.GunaLabel()
        Me.dtpicker1 = New Guna.UI.WinForms.GunaDateTimePicker()
        Me.GunaLabel3 = New Guna.UI.WinForms.GunaLabel()
        Me.comboMonths = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaLabel4 = New Guna.UI.WinForms.GunaLabel()
        Me.partialTxt = New Guna.UI.WinForms.GunaLineTextBox()
        Me.GunaLabel5 = New Guna.UI.WinForms.GunaLabel()
        Me.grandTotal = New Guna.UI.WinForms.GunaLineTextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GunaLabel6 = New Guna.UI.WinForms.GunaLabel()
        Me.lblUnpaid = New Guna.UI.WinForms.GunaLabel()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GunaLabel7 = New Guna.UI.WinForms.GunaLabel()
        Me.dgv3 = New System.Windows.Forms.DataGridView()
        Me.check_box = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.facility_code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.purchase_number = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.soa_txt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.due_date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.total_amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.interest = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GunaLabel8 = New Guna.UI.WinForms.GunaLabel()
        Me.lblInterest = New Guna.UI.WinForms.GunaLabel()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'codeTxt
        '
        Me.codeTxt.BackColor = System.Drawing.Color.White
        Me.codeTxt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.codeTxt.FocusedLineColor = System.Drawing.Color.Black
        Me.codeTxt.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.codeTxt.LineColor = System.Drawing.Color.Black
        Me.codeTxt.Location = New System.Drawing.Point(134, 14)
        Me.codeTxt.Name = "codeTxt"
        Me.codeTxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.codeTxt.SelectedText = ""
        Me.codeTxt.Size = New System.Drawing.Size(75, 26)
        Me.codeTxt.TabIndex = 4
        Me.codeTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaLabel1
        '
        Me.GunaLabel1.AutoSize = True
        Me.GunaLabel1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel1.Location = New System.Drawing.Point(12, 18)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(96, 17)
        Me.GunaLabel1.TabIndex = 3
        Me.GunaLabel1.Text = "FACILITY CODE:"
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.check_box, Me.facility_code, Me.purchase_number, Me.soa_txt, Me.due_date, Me.total_amount, Me.interest, Me.total})
        Me.dgv1.Location = New System.Drawing.Point(13, 107)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.Size = New System.Drawing.Size(619, 168)
        Me.dgv1.TabIndex = 5
        '
        'dgv2
        '
        Me.dgv2.AllowUserToAddRows = False
        Me.dgv2.AllowUserToDeleteRows = False
        Me.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column7, Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6})
        Me.dgv2.Location = New System.Drawing.Point(13, 291)
        Me.dgv2.Name = "dgv2"
        Me.dgv2.ReadOnly = True
        Me.dgv2.Size = New System.Drawing.Size(619, 184)
        Me.dgv2.TabIndex = 6
        '
        'GunaLabel2
        '
        Me.GunaLabel2.AutoSize = True
        Me.GunaLabel2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel2.Location = New System.Drawing.Point(262, 21)
        Me.GunaLabel2.Name = "GunaLabel2"
        Me.GunaLabel2.Size = New System.Drawing.Size(43, 17)
        Me.GunaLabel2.TabIndex = 16
        Me.GunaLabel2.Text = "AS OF"
        '
        'dtpicker1
        '
        Me.dtpicker1.BaseColor = System.Drawing.Color.White
        Me.dtpicker1.BorderColor = System.Drawing.Color.Black
        Me.dtpicker1.CustomFormat = Nothing
        Me.dtpicker1.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.dtpicker1.FocusedColor = System.Drawing.Color.Black
        Me.dtpicker1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpicker1.ForeColor = System.Drawing.Color.Black
        Me.dtpicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpicker1.Location = New System.Drawing.Point(311, 14)
        Me.dtpicker1.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpicker1.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpicker1.Name = "dtpicker1"
        Me.dtpicker1.OnHoverBaseColor = System.Drawing.Color.White
        Me.dtpicker1.OnHoverBorderColor = System.Drawing.Color.Black
        Me.dtpicker1.OnHoverForeColor = System.Drawing.Color.Black
        Me.dtpicker1.OnPressedColor = System.Drawing.Color.Black
        Me.dtpicker1.Size = New System.Drawing.Size(112, 30)
        Me.dtpicker1.TabIndex = 17
        Me.dtpicker1.Text = "6/25/2025"
        Me.dtpicker1.Value = New Date(2025, 6, 25, 14, 21, 19, 735)
        '
        'GunaLabel3
        '
        Me.GunaLabel3.AutoSize = True
        Me.GunaLabel3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel3.Location = New System.Drawing.Point(469, 23)
        Me.GunaLabel3.Name = "GunaLabel3"
        Me.GunaLabel3.Size = New System.Drawing.Size(66, 17)
        Me.GunaLabel3.TabIndex = 18
        Me.GunaLabel3.Text = "MONTHS:"
        '
        'comboMonths
        '
        Me.comboMonths.BackColor = System.Drawing.Color.Transparent
        Me.comboMonths.BaseColor = System.Drawing.Color.White
        Me.comboMonths.BorderColor = System.Drawing.Color.Black
        Me.comboMonths.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.comboMonths.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboMonths.FocusedColor = System.Drawing.Color.Empty
        Me.comboMonths.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.comboMonths.ForeColor = System.Drawing.Color.Black
        Me.comboMonths.FormattingEnabled = True
        Me.comboMonths.Location = New System.Drawing.Point(541, 18)
        Me.comboMonths.Name = "comboMonths"
        Me.comboMonths.OnHoverItemBaseColor = System.Drawing.Color.Black
        Me.comboMonths.OnHoverItemForeColor = System.Drawing.Color.White
        Me.comboMonths.Radius = 3
        Me.comboMonths.Size = New System.Drawing.Size(58, 26)
        Me.comboMonths.TabIndex = 44
        '
        'GunaLabel4
        '
        Me.GunaLabel4.AutoSize = True
        Me.GunaLabel4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel4.Location = New System.Drawing.Point(12, 77)
        Me.GunaLabel4.Name = "GunaLabel4"
        Me.GunaLabel4.Size = New System.Drawing.Size(116, 17)
        Me.GunaLabel4.TabIndex = 45
        Me.GunaLabel4.Text = "PARTIAL PAYMENT:"
        '
        'partialTxt
        '
        Me.partialTxt.BackColor = System.Drawing.Color.White
        Me.partialTxt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.partialTxt.FocusedLineColor = System.Drawing.Color.Black
        Me.partialTxt.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.partialTxt.LineColor = System.Drawing.Color.Black
        Me.partialTxt.Location = New System.Drawing.Point(134, 72)
        Me.partialTxt.Name = "partialTxt"
        Me.partialTxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.partialTxt.SelectedText = ""
        Me.partialTxt.Size = New System.Drawing.Size(70, 26)
        Me.partialTxt.TabIndex = 46
        Me.partialTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaLabel5
        '
        Me.GunaLabel5.AutoSize = True
        Me.GunaLabel5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel5.Location = New System.Drawing.Point(261, 77)
        Me.GunaLabel5.Name = "GunaLabel5"
        Me.GunaLabel5.Size = New System.Drawing.Size(94, 17)
        Me.GunaLabel5.TabIndex = 47
        Me.GunaLabel5.Text = "GRAND TOTAL:"
        '
        'grandTotal
        '
        Me.grandTotal.BackColor = System.Drawing.Color.White
        Me.grandTotal.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.grandTotal.Enabled = False
        Me.grandTotal.FocusedLineColor = System.Drawing.Color.Black
        Me.grandTotal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.grandTotal.LineColor = System.Drawing.Color.Black
        Me.grandTotal.Location = New System.Drawing.Point(361, 75)
        Me.grandTotal.Name = "grandTotal"
        Me.grandTotal.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.grandTotal.SelectedText = ""
        Me.grandTotal.Size = New System.Drawing.Size(83, 26)
        Me.grandTotal.TabIndex = 48
        Me.grandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(538, 62)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(96, 36)
        Me.Button1.TabIndex = 49
        Me.Button1.Text = "SAVE"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GunaLabel6
        '
        Me.GunaLabel6.AutoSize = True
        Me.GunaLabel6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel6.Location = New System.Drawing.Point(13, 51)
        Me.GunaLabel6.Name = "GunaLabel6"
        Me.GunaLabel6.Size = New System.Drawing.Size(95, 17)
        Me.GunaLabel6.TabIndex = 50
        Me.GunaLabel6.Text = "TOTAL UNPAID:"
        '
        'lblUnpaid
        '
        Me.lblUnpaid.AutoSize = True
        Me.lblUnpaid.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnpaid.Location = New System.Drawing.Point(136, 53)
        Me.lblUnpaid.Name = "lblUnpaid"
        Me.lblUnpaid.Size = New System.Drawing.Size(32, 17)
        Me.lblUnpaid.TabIndex = 51
        Me.lblUnpaid.Text = "0.00"
        '
        'Column7
        '
        Me.Column7.HeaderText = "FACILITY CODE"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "P.O NO."
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "SOA NO."
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "DUE DATE"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "UNPAID AMOUNT"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "INTEREST"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "TOTAL AMOUNT"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'GunaLabel7
        '
        Me.GunaLabel7.AutoSize = True
        Me.GunaLabel7.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel7.Location = New System.Drawing.Point(12, 484)
        Me.GunaLabel7.Name = "GunaLabel7"
        Me.GunaLabel7.Size = New System.Drawing.Size(140, 17)
        Me.GunaLabel7.TabIndex = 52
        Me.GunaLabel7.Text = "INSTALLMENT DETAILS"
        '
        'dgv3
        '
        Me.dgv3.AllowUserToAddRows = False
        Me.dgv3.AllowUserToDeleteRows = False
        Me.dgv3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv3.Location = New System.Drawing.Point(13, 513)
        Me.dgv3.Name = "dgv3"
        Me.dgv3.ReadOnly = True
        Me.dgv3.Size = New System.Drawing.Size(619, 184)
        Me.dgv3.TabIndex = 53
        '
        'check_box
        '
        Me.check_box.HeaderText = ""
        Me.check_box.Name = "check_box"
        Me.check_box.Width = 25
        '
        'facility_code
        '
        Me.facility_code.DataPropertyName = "fac_code"
        Me.facility_code.HeaderText = "FACILITY CODE"
        Me.facility_code.Name = "facility_code"
        '
        'purchase_number
        '
        Me.purchase_number.DataPropertyName = "purchase_number"
        Me.purchase_number.HeaderText = "P.O NO."
        Me.purchase_number.Name = "purchase_number"
        '
        'soa_txt
        '
        Me.soa_txt.DataPropertyName = "soa_txt"
        Me.soa_txt.HeaderText = "SOA NO."
        Me.soa_txt.Name = "soa_txt"
        '
        'due_date
        '
        Me.due_date.DataPropertyName = "due_date"
        Me.due_date.HeaderText = "DUE DATE"
        Me.due_date.Name = "due_date"
        '
        'total_amount
        '
        Me.total_amount.DataPropertyName = "total_amount"
        Me.total_amount.HeaderText = "UNPAID AMOUNT"
        Me.total_amount.Name = "total_amount"
        '
        'interest
        '
        Me.interest.DataPropertyName = "interest"
        Me.interest.HeaderText = "INTEREST"
        Me.interest.Name = "interest"
        '
        'total
        '
        Me.total.DataPropertyName = "total"
        Me.total.HeaderText = "TOTAL AMOUNT"
        Me.total.Name = "total"
        '
        'GunaLabel8
        '
        Me.GunaLabel8.AutoSize = True
        Me.GunaLabel8.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel8.Location = New System.Drawing.Point(249, 53)
        Me.GunaLabel8.Name = "GunaLabel8"
        Me.GunaLabel8.Size = New System.Drawing.Size(106, 17)
        Me.GunaLabel8.TabIndex = 54
        Me.GunaLabel8.Text = "TOTAL INTEREST:"
        '
        'lblInterest
        '
        Me.lblInterest.AutoSize = True
        Me.lblInterest.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInterest.Location = New System.Drawing.Point(361, 54)
        Me.lblInterest.Name = "lblInterest"
        Me.lblInterest.Size = New System.Drawing.Size(32, 17)
        Me.lblInterest.TabIndex = 55
        Me.lblInterest.Text = "0.00"
        '
        'Installment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(648, 709)
        Me.Controls.Add(Me.lblInterest)
        Me.Controls.Add(Me.GunaLabel8)
        Me.Controls.Add(Me.dgv3)
        Me.Controls.Add(Me.GunaLabel7)
        Me.Controls.Add(Me.lblUnpaid)
        Me.Controls.Add(Me.GunaLabel6)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.grandTotal)
        Me.Controls.Add(Me.GunaLabel5)
        Me.Controls.Add(Me.partialTxt)
        Me.Controls.Add(Me.GunaLabel4)
        Me.Controls.Add(Me.comboMonths)
        Me.Controls.Add(Me.GunaLabel3)
        Me.Controls.Add(Me.dtpicker1)
        Me.Controls.Add(Me.GunaLabel2)
        Me.Controls.Add(Me.dgv2)
        Me.Controls.Add(Me.dgv1)
        Me.Controls.Add(Me.codeTxt)
        Me.Controls.Add(Me.GunaLabel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Installment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Installment"
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents codeTxt As Guna.UI.WinForms.GunaLineTextBox
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents dgv1 As DataGridView
    Friend WithEvents dgv2 As DataGridView
    Friend WithEvents GunaLabel2 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents dtpicker1 As Guna.UI.WinForms.GunaDateTimePicker
    Friend WithEvents GunaLabel3 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents comboMonths As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaLabel4 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents partialTxt As Guna.UI.WinForms.GunaLineTextBox
    Friend WithEvents GunaLabel5 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents grandTotal As Guna.UI.WinForms.GunaLineTextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents GunaLabel6 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents lblUnpaid As Guna.UI.WinForms.GunaLabel
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents GunaLabel7 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents dgv3 As DataGridView
    Friend WithEvents check_box As DataGridViewCheckBoxColumn
    Friend WithEvents facility_code As DataGridViewTextBoxColumn
    Friend WithEvents purchase_number As DataGridViewTextBoxColumn
    Friend WithEvents soa_txt As DataGridViewTextBoxColumn
    Friend WithEvents due_date As DataGridViewTextBoxColumn
    Friend WithEvents total_amount As DataGridViewTextBoxColumn
    Friend WithEvents interest As DataGridViewTextBoxColumn
    Friend WithEvents total As DataGridViewTextBoxColumn
    Friend WithEvents GunaLabel8 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents lblInterest As Guna.UI.WinForms.GunaLabel
End Class
