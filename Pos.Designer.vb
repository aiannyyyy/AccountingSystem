<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Pos
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Pos))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GunaElipse1 = New Guna.UI.WinForms.GunaElipse(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblshow = New Guna.UI.WinForms.GunaLabel()
        Me.GunaControlBox3 = New Guna.UI.WinForms.GunaControlBox()
        Me.GunaControlBox2 = New Guna.UI.WinForms.GunaControlBox()
        Me.GunaControlBox1 = New Guna.UI.WinForms.GunaControlBox()
        Me.GunaDragControl1 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.grpBox = New Guna.UI.WinForms.GunaGroupBox()
        Me.GunaLabel10 = New Guna.UI.WinForms.GunaLabel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.addButton = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.noticeButton = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.reportButton = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.payButton = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.soaButton = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.dtpicker1 = New Guna.UI.WinForms.GunaDateTimePicker()
        Me.amountTxt = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel9 = New Guna.UI.WinForms.GunaLabel()
        Me.qtyTxt = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel8 = New Guna.UI.WinForms.GunaLabel()
        Me.grpOrders = New Guna.UI.WinForms.GunaGroupBox()
        Me.GunaLabel11 = New Guna.UI.WinForms.GunaLabel()
        Me.computeButton = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.dryingTxt = New Guna.UI.WinForms.GunaTextBox()
        Me.posterTxt = New Guna.UI.WinForms.GunaTextBox()
        Me.totalTxt = New Guna.UI.WinForms.GunaTextBox()
        Me.adsTxt = New Guna.UI.WinForms.GunaTextBox()
        Me.brochureTxt = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel7 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel6 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel5 = New Guna.UI.WinForms.GunaLabel()
        Me.dryingCheck = New System.Windows.Forms.CheckBox()
        Me.posterCheck = New System.Windows.Forms.CheckBox()
        Me.brochureCheck = New System.Windows.Forms.CheckBox()
        Me.dtpicker2 = New Guna.UI.WinForms.GunaDateTimePicker()
        Me.GunaLabel4 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel3 = New Guna.UI.WinForms.GunaLabel()
        Me.purchaseBox = New Guna.UI.WinForms.GunaLineTextBox()
        Me.GunaLabel2 = New Guna.UI.WinForms.GunaLabel()
        Me.termBox = New Guna.UI.WinForms.GunaTextBox()
        Me.nameBox = New Guna.UI.WinForms.GunaTextBox()
        Me.codeTxt = New Guna.UI.WinForms.GunaLineTextBox()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.replaceTxt = New Guna.UI.WinForms.GunaTextBox()
        Me.lopezCheck = New System.Windows.Forms.CheckBox()
        Me.replacementCheck = New System.Windows.Forms.CheckBox()
        Me.walkCheck = New System.Windows.Forms.CheckBox()
        Me.monitoringCheck = New System.Windows.Forms.CheckBox()
        Me.dgv1 = New Guna.UI.WinForms.GunaDataGridView()
        Me.cancelPo = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.soa_number = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.order_type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fac_code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.facility_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.term = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.purchase_number = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.purchase_date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sub_total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.brochure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.poster = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.drying_rack = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.replacement = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ads_amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.due_date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.total_amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.balance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.username = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.replaceAdd = New System.Windows.Forms.Button()
        Me.expiredCheck = New System.Windows.Forms.CheckBox()
        Me.remBox = New Guna.UI.WinForms.GunaTextBox()
        Me.remLbl = New Guna.UI.WinForms.GunaLabel()
        Me.replaceCombo = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.CachedStatementOfAccount1 = New AccountingSystem.CachedStatementOfAccount()
        Me.typeText = New Guna.UI.WinForms.GunaTextBox()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpBox.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.grpOrders.SuspendLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GunaElipse1
        '
        Me.GunaElipse1.TargetControl = Me
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.lblshow)
        Me.Panel1.Controls.Add(Me.GunaControlBox3)
        Me.Panel1.Controls.Add(Me.GunaControlBox2)
        Me.Panel1.Controls.Add(Me.GunaControlBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1047, 34)
        Me.Panel1.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(8, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(31, 26)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'lblshow
        '
        Me.lblshow.AutoSize = True
        Me.lblshow.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblshow.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.lblshow.Location = New System.Drawing.Point(44, 8)
        Me.lblshow.Name = "lblshow"
        Me.lblshow.Size = New System.Drawing.Size(83, 17)
        Me.lblshow.TabIndex = 4
        Me.lblshow.Text = "GunaLabel10"
        '
        'GunaControlBox3
        '
        Me.GunaControlBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaControlBox3.AnimationHoverSpeed = 0.07!
        Me.GunaControlBox3.AnimationSpeed = 0.03!
        Me.GunaControlBox3.IconColor = System.Drawing.Color.White
        Me.GunaControlBox3.IconSize = 15.0!
        Me.GunaControlBox3.Location = New System.Drawing.Point(1013, 1)
        Me.GunaControlBox3.Name = "GunaControlBox3"
        Me.GunaControlBox3.OnHoverBackColor = System.Drawing.Color.FromArgb(CType(CType(164, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.GunaControlBox3.OnHoverIconColor = System.Drawing.Color.White
        Me.GunaControlBox3.OnPressedColor = System.Drawing.Color.Black
        Me.GunaControlBox3.Size = New System.Drawing.Size(30, 30)
        Me.GunaControlBox3.TabIndex = 3
        '
        'GunaControlBox2
        '
        Me.GunaControlBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaControlBox2.AnimationHoverSpeed = 0.07!
        Me.GunaControlBox2.AnimationSpeed = 0.03!
        Me.GunaControlBox2.ControlBoxType = Guna.UI.WinForms.FormControlBoxType.MinimizeBox
        Me.GunaControlBox2.IconColor = System.Drawing.Color.White
        Me.GunaControlBox2.IconSize = 15.0!
        Me.GunaControlBox2.Location = New System.Drawing.Point(941, 1)
        Me.GunaControlBox2.Name = "GunaControlBox2"
        Me.GunaControlBox2.OnHoverBackColor = System.Drawing.Color.FromArgb(CType(CType(164, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.GunaControlBox2.OnHoverIconColor = System.Drawing.Color.White
        Me.GunaControlBox2.OnPressedColor = System.Drawing.Color.Black
        Me.GunaControlBox2.Size = New System.Drawing.Size(30, 30)
        Me.GunaControlBox2.TabIndex = 2
        '
        'GunaControlBox1
        '
        Me.GunaControlBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaControlBox1.AnimationHoverSpeed = 0.07!
        Me.GunaControlBox1.AnimationSpeed = 0.03!
        Me.GunaControlBox1.ControlBoxType = Guna.UI.WinForms.FormControlBoxType.MaximizeBox
        Me.GunaControlBox1.Enabled = False
        Me.GunaControlBox1.IconColor = System.Drawing.Color.White
        Me.GunaControlBox1.IconSize = 15.0!
        Me.GunaControlBox1.Location = New System.Drawing.Point(977, 1)
        Me.GunaControlBox1.Name = "GunaControlBox1"
        Me.GunaControlBox1.OnHoverBackColor = System.Drawing.Color.FromArgb(CType(CType(164, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.GunaControlBox1.OnHoverIconColor = System.Drawing.Color.White
        Me.GunaControlBox1.OnPressedColor = System.Drawing.Color.Black
        Me.GunaControlBox1.Size = New System.Drawing.Size(30, 30)
        Me.GunaControlBox1.TabIndex = 1
        '
        'GunaDragControl1
        '
        Me.GunaDragControl1.TargetControl = Me.Panel1
        '
        'grpBox
        '
        Me.grpBox.BackColor = System.Drawing.Color.Transparent
        Me.grpBox.BaseColor = System.Drawing.Color.Transparent
        Me.grpBox.BorderColor = System.Drawing.Color.Black
        Me.grpBox.Controls.Add(Me.GunaLabel10)
        Me.grpBox.Controls.Add(Me.Panel3)
        Me.grpBox.Controls.Add(Me.dtpicker1)
        Me.grpBox.Controls.Add(Me.amountTxt)
        Me.grpBox.Controls.Add(Me.GunaLabel9)
        Me.grpBox.Controls.Add(Me.qtyTxt)
        Me.grpBox.Controls.Add(Me.GunaLabel8)
        Me.grpBox.Controls.Add(Me.walkCheck)
        Me.grpBox.Controls.Add(Me.grpOrders)
        Me.grpBox.Controls.Add(Me.dtpicker2)
        Me.grpBox.Controls.Add(Me.GunaLabel4)
        Me.grpBox.Controls.Add(Me.GunaLabel3)
        Me.grpBox.Controls.Add(Me.purchaseBox)
        Me.grpBox.Controls.Add(Me.GunaLabel2)
        Me.grpBox.Controls.Add(Me.termBox)
        Me.grpBox.Controls.Add(Me.nameBox)
        Me.grpBox.Controls.Add(Me.codeTxt)
        Me.grpBox.Controls.Add(Me.GunaLabel1)
        Me.grpBox.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpBox.LineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grpBox.Location = New System.Drawing.Point(20, 43)
        Me.grpBox.Name = "grpBox"
        Me.grpBox.Size = New System.Drawing.Size(1007, 250)
        Me.grpBox.TabIndex = 3
        Me.grpBox.TextLocation = New System.Drawing.Point(10, 8)
        '
        'GunaLabel10
        '
        Me.GunaLabel10.AutoSize = True
        Me.GunaLabel10.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel10.ForeColor = System.Drawing.Color.White
        Me.GunaLabel10.Location = New System.Drawing.Point(7, 6)
        Me.GunaLabel10.Name = "GunaLabel10"
        Me.GunaLabel10.Size = New System.Drawing.Size(127, 17)
        Me.GunaLabel10.TabIndex = 5
        Me.GunaLabel10.Text = "CUSTOMER DETAILS"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.addButton)
        Me.Panel3.Controls.Add(Me.noticeButton)
        Me.Panel3.Controls.Add(Me.reportButton)
        Me.Panel3.Controls.Add(Me.payButton)
        Me.Panel3.Controls.Add(Me.soaButton)
        Me.Panel3.Location = New System.Drawing.Point(28, 189)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(395, 48)
        Me.Panel3.TabIndex = 25
        '
        'addButton
        '
        Me.addButton.AnimationHoverSpeed = 0.07!
        Me.addButton.AnimationSpeed = 0.03!
        Me.addButton.BackColor = System.Drawing.Color.Transparent
        Me.addButton.BaseColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.addButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.addButton.CheckedBaseColor = System.Drawing.Color.Gray
        Me.addButton.CheckedBorderColor = System.Drawing.Color.Black
        Me.addButton.CheckedForeColor = System.Drawing.Color.White
        Me.addButton.CheckedImage = Nothing
        Me.addButton.CheckedLineColor = System.Drawing.Color.DimGray
        Me.addButton.DialogResult = System.Windows.Forms.DialogResult.None
        Me.addButton.FocusedColor = System.Drawing.Color.Empty
        Me.addButton.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.addButton.Image = Nothing
        Me.addButton.ImageSize = New System.Drawing.Size(20, 20)
        Me.addButton.LineColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.addButton.Location = New System.Drawing.Point(10, 9)
        Me.addButton.Name = "addButton"
        Me.addButton.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.addButton.OnHoverBorderColor = System.Drawing.Color.Black
        Me.addButton.OnHoverForeColor = System.Drawing.Color.Black
        Me.addButton.OnHoverImage = Nothing
        Me.addButton.OnHoverLineColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.addButton.OnPressedColor = System.Drawing.Color.Black
        Me.addButton.Radius = 2
        Me.addButton.Size = New System.Drawing.Size(60, 30)
        Me.addButton.TabIndex = 20
        Me.addButton.Text = "ADD"
        Me.addButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.addButton.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.ClearTypeGridFit
        '
        'noticeButton
        '
        Me.noticeButton.AnimationHoverSpeed = 0.07!
        Me.noticeButton.AnimationSpeed = 0.03!
        Me.noticeButton.BackColor = System.Drawing.Color.Transparent
        Me.noticeButton.BaseColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.noticeButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.noticeButton.CheckedBaseColor = System.Drawing.Color.Gray
        Me.noticeButton.CheckedBorderColor = System.Drawing.Color.Black
        Me.noticeButton.CheckedForeColor = System.Drawing.Color.White
        Me.noticeButton.CheckedImage = Nothing
        Me.noticeButton.CheckedLineColor = System.Drawing.Color.DimGray
        Me.noticeButton.DialogResult = System.Windows.Forms.DialogResult.None
        Me.noticeButton.FocusedColor = System.Drawing.Color.Empty
        Me.noticeButton.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.noticeButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.noticeButton.Image = Nothing
        Me.noticeButton.ImageSize = New System.Drawing.Size(20, 20)
        Me.noticeButton.LineColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.noticeButton.Location = New System.Drawing.Point(322, 9)
        Me.noticeButton.Name = "noticeButton"
        Me.noticeButton.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.noticeButton.OnHoverBorderColor = System.Drawing.Color.Black
        Me.noticeButton.OnHoverForeColor = System.Drawing.Color.Black
        Me.noticeButton.OnHoverImage = Nothing
        Me.noticeButton.OnHoverLineColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.noticeButton.OnPressedColor = System.Drawing.Color.Black
        Me.noticeButton.Radius = 2
        Me.noticeButton.Size = New System.Drawing.Size(65, 30)
        Me.noticeButton.TabIndex = 24
        Me.noticeButton.Text = "NOTICE"
        Me.noticeButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.noticeButton.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.ClearTypeGridFit
        '
        'reportButton
        '
        Me.reportButton.AnimationHoverSpeed = 0.07!
        Me.reportButton.AnimationSpeed = 0.03!
        Me.reportButton.BackColor = System.Drawing.Color.Transparent
        Me.reportButton.BaseColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.reportButton.BorderColor = System.Drawing.Color.Black
        Me.reportButton.CheckedBaseColor = System.Drawing.Color.Gray
        Me.reportButton.CheckedBorderColor = System.Drawing.Color.Black
        Me.reportButton.CheckedForeColor = System.Drawing.Color.White
        Me.reportButton.CheckedImage = Nothing
        Me.reportButton.CheckedLineColor = System.Drawing.Color.DimGray
        Me.reportButton.DialogResult = System.Windows.Forms.DialogResult.None
        Me.reportButton.FocusedColor = System.Drawing.Color.Empty
        Me.reportButton.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reportButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.reportButton.Image = Nothing
        Me.reportButton.ImageSize = New System.Drawing.Size(20, 20)
        Me.reportButton.LineColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.reportButton.Location = New System.Drawing.Point(248, 9)
        Me.reportButton.Name = "reportButton"
        Me.reportButton.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.reportButton.OnHoverBorderColor = System.Drawing.Color.Black
        Me.reportButton.OnHoverForeColor = System.Drawing.Color.Black
        Me.reportButton.OnHoverImage = Nothing
        Me.reportButton.OnHoverLineColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.reportButton.OnPressedColor = System.Drawing.Color.Black
        Me.reportButton.Radius = 2
        Me.reportButton.Size = New System.Drawing.Size(68, 30)
        Me.reportButton.TabIndex = 23
        Me.reportButton.Text = "REPORT"
        Me.reportButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.reportButton.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.ClearTypeGridFit
        '
        'payButton
        '
        Me.payButton.AnimationHoverSpeed = 0.07!
        Me.payButton.AnimationSpeed = 0.03!
        Me.payButton.BackColor = System.Drawing.Color.Transparent
        Me.payButton.BaseColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.payButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.payButton.CheckedBaseColor = System.Drawing.Color.Gray
        Me.payButton.CheckedBorderColor = System.Drawing.Color.Black
        Me.payButton.CheckedForeColor = System.Drawing.Color.White
        Me.payButton.CheckedImage = Nothing
        Me.payButton.CheckedLineColor = System.Drawing.Color.DimGray
        Me.payButton.DialogResult = System.Windows.Forms.DialogResult.None
        Me.payButton.FocusedColor = System.Drawing.Color.Empty
        Me.payButton.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.payButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.payButton.Image = Nothing
        Me.payButton.ImageSize = New System.Drawing.Size(20, 20)
        Me.payButton.LineColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.payButton.Location = New System.Drawing.Point(167, 9)
        Me.payButton.Name = "payButton"
        Me.payButton.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.payButton.OnHoverBorderColor = System.Drawing.Color.Black
        Me.payButton.OnHoverForeColor = System.Drawing.Color.Black
        Me.payButton.OnHoverImage = Nothing
        Me.payButton.OnHoverLineColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.payButton.OnPressedColor = System.Drawing.Color.Black
        Me.payButton.Radius = 2
        Me.payButton.Size = New System.Drawing.Size(75, 30)
        Me.payButton.TabIndex = 22
        Me.payButton.Text = "PAYMENTS"
        Me.payButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.payButton.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.ClearTypeGridFit
        '
        'soaButton
        '
        Me.soaButton.AnimationHoverSpeed = 0.07!
        Me.soaButton.AnimationSpeed = 0.03!
        Me.soaButton.BackColor = System.Drawing.Color.Transparent
        Me.soaButton.BaseColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.soaButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.soaButton.CheckedBaseColor = System.Drawing.Color.Gray
        Me.soaButton.CheckedBorderColor = System.Drawing.Color.Black
        Me.soaButton.CheckedForeColor = System.Drawing.Color.White
        Me.soaButton.CheckedImage = Nothing
        Me.soaButton.CheckedLineColor = System.Drawing.Color.DimGray
        Me.soaButton.DialogResult = System.Windows.Forms.DialogResult.None
        Me.soaButton.FocusedColor = System.Drawing.Color.Empty
        Me.soaButton.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.soaButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.soaButton.Image = Nothing
        Me.soaButton.ImageSize = New System.Drawing.Size(20, 20)
        Me.soaButton.LineColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.soaButton.Location = New System.Drawing.Point(76, 9)
        Me.soaButton.Name = "soaButton"
        Me.soaButton.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.soaButton.OnHoverBorderColor = System.Drawing.Color.Black
        Me.soaButton.OnHoverForeColor = System.Drawing.Color.Black
        Me.soaButton.OnHoverImage = Nothing
        Me.soaButton.OnHoverLineColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.soaButton.OnPressedColor = System.Drawing.Color.Black
        Me.soaButton.Radius = 2
        Me.soaButton.Size = New System.Drawing.Size(85, 30)
        Me.soaButton.TabIndex = 21
        Me.soaButton.Text = "REPRINT SOA"
        Me.soaButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.soaButton.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.ClearTypeGridFit
        '
        'dtpicker1
        '
        Me.dtpicker1.BackColor = System.Drawing.Color.Transparent
        Me.dtpicker1.BaseColor = System.Drawing.Color.White
        Me.dtpicker1.BorderColor = System.Drawing.Color.Black
        Me.dtpicker1.CustomFormat = Nothing
        Me.dtpicker1.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.dtpicker1.Enabled = False
        Me.dtpicker1.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.dtpicker1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpicker1.ForeColor = System.Drawing.Color.Black
        Me.dtpicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpicker1.Location = New System.Drawing.Point(382, 143)
        Me.dtpicker1.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpicker1.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpicker1.Name = "dtpicker1"
        Me.dtpicker1.OnHoverBaseColor = System.Drawing.Color.White
        Me.dtpicker1.OnHoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.dtpicker1.OnHoverForeColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.dtpicker1.OnPressedColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.dtpicker1.Radius = 2
        Me.dtpicker1.Size = New System.Drawing.Size(118, 30)
        Me.dtpicker1.TabIndex = 24
        Me.dtpicker1.Text = "5/30/2024"
        Me.dtpicker1.Value = New Date(2024, 5, 30, 16, 46, 27, 716)
        '
        'amountTxt
        '
        Me.amountTxt.BackColor = System.Drawing.Color.Black
        Me.amountTxt.BaseColor = System.Drawing.Color.White
        Me.amountTxt.BorderColor = System.Drawing.Color.Black
        Me.amountTxt.BorderSize = 1
        Me.amountTxt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.amountTxt.Enabled = False
        Me.amountTxt.FocusedBaseColor = System.Drawing.Color.White
        Me.amountTxt.FocusedBorderColor = System.Drawing.Color.Black
        Me.amountTxt.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.amountTxt.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.amountTxt.Location = New System.Drawing.Point(373, 107)
        Me.amountTxt.Name = "amountTxt"
        Me.amountTxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.amountTxt.SelectedText = ""
        Me.amountTxt.Size = New System.Drawing.Size(123, 27)
        Me.amountTxt.TabIndex = 22
        Me.amountTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaLabel9
        '
        Me.GunaLabel9.AutoSize = True
        Me.GunaLabel9.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel9.Location = New System.Drawing.Point(405, 82)
        Me.GunaLabel9.Name = "GunaLabel9"
        Me.GunaLabel9.Size = New System.Drawing.Size(58, 15)
        Me.GunaLabel9.TabIndex = 21
        Me.GunaLabel9.Text = "AMOUNT"
        '
        'qtyTxt
        '
        Me.qtyTxt.BackColor = System.Drawing.Color.Black
        Me.qtyTxt.BaseColor = System.Drawing.Color.White
        Me.qtyTxt.BorderColor = System.Drawing.Color.Black
        Me.qtyTxt.BorderSize = 1
        Me.qtyTxt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.qtyTxt.FocusedBaseColor = System.Drawing.Color.White
        Me.qtyTxt.FocusedBorderColor = System.Drawing.Color.Black
        Me.qtyTxt.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.qtyTxt.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.qtyTxt.Location = New System.Drawing.Point(293, 107)
        Me.qtyTxt.Name = "qtyTxt"
        Me.qtyTxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.qtyTxt.SelectedText = ""
        Me.qtyTxt.Size = New System.Drawing.Size(74, 27)
        Me.qtyTxt.TabIndex = 20
        Me.qtyTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaLabel8
        '
        Me.GunaLabel8.AutoSize = True
        Me.GunaLabel8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel8.Location = New System.Drawing.Point(297, 82)
        Me.GunaLabel8.Name = "GunaLabel8"
        Me.GunaLabel8.Size = New System.Drawing.Size(63, 15)
        Me.GunaLabel8.TabIndex = 20
        Me.GunaLabel8.Text = "QUANTITY"
        '
        'grpOrders
        '
        Me.grpOrders.BackColor = System.Drawing.Color.Transparent
        Me.grpOrders.BaseColor = System.Drawing.Color.White
        Me.grpOrders.BorderColor = System.Drawing.Color.Gainsboro
        Me.grpOrders.Controls.Add(Me.typeText)
        Me.grpOrders.Controls.Add(Me.GunaLabel11)
        Me.grpOrders.Controls.Add(Me.computeButton)
        Me.grpOrders.Controls.Add(Me.dryingTxt)
        Me.grpOrders.Controls.Add(Me.posterTxt)
        Me.grpOrders.Controls.Add(Me.totalTxt)
        Me.grpOrders.Controls.Add(Me.adsTxt)
        Me.grpOrders.Controls.Add(Me.brochureTxt)
        Me.grpOrders.Controls.Add(Me.GunaLabel7)
        Me.grpOrders.Controls.Add(Me.GunaLabel6)
        Me.grpOrders.Controls.Add(Me.GunaLabel5)
        Me.grpOrders.Controls.Add(Me.dryingCheck)
        Me.grpOrders.Controls.Add(Me.posterCheck)
        Me.grpOrders.Controls.Add(Me.brochureCheck)
        Me.grpOrders.ForeColor = System.Drawing.Color.Black
        Me.grpOrders.LineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grpOrders.Location = New System.Drawing.Point(515, 72)
        Me.grpOrders.Name = "grpOrders"
        Me.grpOrders.Size = New System.Drawing.Size(489, 182)
        Me.grpOrders.TabIndex = 10
        Me.grpOrders.TextLocation = New System.Drawing.Point(10, 8)
        '
        'GunaLabel11
        '
        Me.GunaLabel11.AutoSize = True
        Me.GunaLabel11.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel11.ForeColor = System.Drawing.Color.White
        Me.GunaLabel11.Location = New System.Drawing.Point(5, 6)
        Me.GunaLabel11.Name = "GunaLabel11"
        Me.GunaLabel11.Size = New System.Drawing.Size(57, 17)
        Me.GunaLabel11.TabIndex = 26
        Me.GunaLabel11.Text = "ORDERS"
        '
        'computeButton
        '
        Me.computeButton.AnimationHoverSpeed = 0.07!
        Me.computeButton.AnimationSpeed = 0.03!
        Me.computeButton.BackColor = System.Drawing.Color.Transparent
        Me.computeButton.BaseColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.computeButton.BorderColor = System.Drawing.Color.Black
        Me.computeButton.CheckedBaseColor = System.Drawing.Color.Gray
        Me.computeButton.CheckedBorderColor = System.Drawing.Color.Black
        Me.computeButton.CheckedForeColor = System.Drawing.Color.Black
        Me.computeButton.CheckedImage = Nothing
        Me.computeButton.CheckedLineColor = System.Drawing.Color.DimGray
        Me.computeButton.DialogResult = System.Windows.Forms.DialogResult.None
        Me.computeButton.FocusedColor = System.Drawing.Color.Empty
        Me.computeButton.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.computeButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.computeButton.Image = Nothing
        Me.computeButton.ImageSize = New System.Drawing.Size(20, 20)
        Me.computeButton.LineColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.computeButton.Location = New System.Drawing.Point(329, 121)
        Me.computeButton.Name = "computeButton"
        Me.computeButton.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.computeButton.OnHoverBorderColor = System.Drawing.Color.Black
        Me.computeButton.OnHoverForeColor = System.Drawing.Color.Black
        Me.computeButton.OnHoverImage = Nothing
        Me.computeButton.OnHoverLineColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.computeButton.OnPressedColor = System.Drawing.Color.Black
        Me.computeButton.Radius = 2
        Me.computeButton.Size = New System.Drawing.Size(119, 42)
        Me.computeButton.TabIndex = 19
        Me.computeButton.Text = "COMPUTE"
        Me.computeButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.computeButton.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.ClearTypeGridFit
        '
        'dryingTxt
        '
        Me.dryingTxt.BackColor = System.Drawing.Color.Black
        Me.dryingTxt.BaseColor = System.Drawing.Color.White
        Me.dryingTxt.BorderColor = System.Drawing.Color.Black
        Me.dryingTxt.BorderSize = 1
        Me.dryingTxt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.dryingTxt.FocusedBaseColor = System.Drawing.Color.White
        Me.dryingTxt.FocusedBorderColor = System.Drawing.Color.Black
        Me.dryingTxt.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.dryingTxt.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dryingTxt.Location = New System.Drawing.Point(288, 68)
        Me.dryingTxt.Name = "dryingTxt"
        Me.dryingTxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dryingTxt.SelectedText = ""
        Me.dryingTxt.Size = New System.Drawing.Size(84, 26)
        Me.dryingTxt.TabIndex = 17
        Me.dryingTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'posterTxt
        '
        Me.posterTxt.BackColor = System.Drawing.Color.Black
        Me.posterTxt.BaseColor = System.Drawing.Color.White
        Me.posterTxt.BorderColor = System.Drawing.Color.Black
        Me.posterTxt.BorderSize = 1
        Me.posterTxt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.posterTxt.FocusedBaseColor = System.Drawing.Color.White
        Me.posterTxt.FocusedBorderColor = System.Drawing.Color.Black
        Me.posterTxt.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.posterTxt.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.posterTxt.Location = New System.Drawing.Point(198, 68)
        Me.posterTxt.Name = "posterTxt"
        Me.posterTxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.posterTxt.SelectedText = ""
        Me.posterTxt.Size = New System.Drawing.Size(84, 26)
        Me.posterTxt.TabIndex = 16
        Me.posterTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'totalTxt
        '
        Me.totalTxt.BackColor = System.Drawing.Color.Black
        Me.totalTxt.BaseColor = System.Drawing.Color.White
        Me.totalTxt.BorderColor = System.Drawing.Color.Black
        Me.totalTxt.BorderSize = 1
        Me.totalTxt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.totalTxt.FocusedBaseColor = System.Drawing.Color.White
        Me.totalTxt.FocusedBorderColor = System.Drawing.Color.Black
        Me.totalTxt.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.totalTxt.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.totalTxt.Location = New System.Drawing.Point(104, 145)
        Me.totalTxt.Name = "totalTxt"
        Me.totalTxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.totalTxt.SelectedText = ""
        Me.totalTxt.Size = New System.Drawing.Size(178, 26)
        Me.totalTxt.TabIndex = 15
        Me.totalTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'adsTxt
        '
        Me.adsTxt.BackColor = System.Drawing.Color.Black
        Me.adsTxt.BaseColor = System.Drawing.Color.White
        Me.adsTxt.BorderColor = System.Drawing.Color.Black
        Me.adsTxt.BorderSize = 1
        Me.adsTxt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.adsTxt.FocusedBaseColor = System.Drawing.Color.White
        Me.adsTxt.FocusedBorderColor = System.Drawing.Color.Black
        Me.adsTxt.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.adsTxt.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.adsTxt.Location = New System.Drawing.Point(104, 106)
        Me.adsTxt.Name = "adsTxt"
        Me.adsTxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.adsTxt.SelectedText = ""
        Me.adsTxt.Size = New System.Drawing.Size(178, 26)
        Me.adsTxt.TabIndex = 14
        Me.adsTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'brochureTxt
        '
        Me.brochureTxt.BackColor = System.Drawing.Color.Black
        Me.brochureTxt.BaseColor = System.Drawing.Color.White
        Me.brochureTxt.BorderColor = System.Drawing.Color.Black
        Me.brochureTxt.BorderSize = 1
        Me.brochureTxt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.brochureTxt.FocusedBaseColor = System.Drawing.Color.White
        Me.brochureTxt.FocusedBorderColor = System.Drawing.Color.Black
        Me.brochureTxt.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.brochureTxt.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.brochureTxt.Location = New System.Drawing.Point(104, 68)
        Me.brochureTxt.Name = "brochureTxt"
        Me.brochureTxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.brochureTxt.SelectedText = ""
        Me.brochureTxt.Size = New System.Drawing.Size(84, 26)
        Me.brochureTxt.TabIndex = 11
        Me.brochureTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaLabel7
        '
        Me.GunaLabel7.AutoSize = True
        Me.GunaLabel7.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel7.Location = New System.Drawing.Point(8, 150)
        Me.GunaLabel7.Name = "GunaLabel7"
        Me.GunaLabel7.Size = New System.Drawing.Size(85, 15)
        Me.GunaLabel7.TabIndex = 13
        Me.GunaLabel7.Text = "GRAND TOTAL:"
        '
        'GunaLabel6
        '
        Me.GunaLabel6.AutoSize = True
        Me.GunaLabel6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel6.Location = New System.Drawing.Point(8, 115)
        Me.GunaLabel6.Name = "GunaLabel6"
        Me.GunaLabel6.Size = New System.Drawing.Size(86, 15)
        Me.GunaLabel6.TabIndex = 12
        Me.GunaLabel6.Text = "ADS AMOUNT:"
        '
        'GunaLabel5
        '
        Me.GunaLabel5.AutoSize = True
        Me.GunaLabel5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel5.Location = New System.Drawing.Point(8, 76)
        Me.GunaLabel5.Name = "GunaLabel5"
        Me.GunaLabel5.Size = New System.Drawing.Size(88, 15)
        Me.GunaLabel5.TabIndex = 11
        Me.GunaLabel5.Text = "TOTAL ORDERS:"
        '
        'dryingCheck
        '
        Me.dryingCheck.AutoSize = True
        Me.dryingCheck.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dryingCheck.Location = New System.Drawing.Point(283, 39)
        Me.dryingCheck.Name = "dryingCheck"
        Me.dryingCheck.Size = New System.Drawing.Size(95, 17)
        Me.dryingCheck.TabIndex = 2
        Me.dryingCheck.Text = "DRYING RACK"
        Me.dryingCheck.UseVisualStyleBackColor = True
        '
        'posterCheck
        '
        Me.posterCheck.AutoSize = True
        Me.posterCheck.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.posterCheck.Location = New System.Drawing.Point(207, 39)
        Me.posterCheck.Name = "posterCheck"
        Me.posterCheck.Size = New System.Drawing.Size(66, 17)
        Me.posterCheck.TabIndex = 1
        Me.posterCheck.Text = "POSTER"
        Me.posterCheck.UseVisualStyleBackColor = True
        '
        'brochureCheck
        '
        Me.brochureCheck.AutoSize = True
        Me.brochureCheck.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.brochureCheck.Location = New System.Drawing.Point(104, 39)
        Me.brochureCheck.Name = "brochureCheck"
        Me.brochureCheck.Size = New System.Drawing.Size(84, 17)
        Me.brochureCheck.TabIndex = 0
        Me.brochureCheck.Text = "BROCHURE"
        Me.brochureCheck.UseVisualStyleBackColor = True
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
        Me.dtpicker2.Location = New System.Drawing.Point(158, 140)
        Me.dtpicker2.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpicker2.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpicker2.Name = "dtpicker2"
        Me.dtpicker2.OnHoverBaseColor = System.Drawing.Color.White
        Me.dtpicker2.OnHoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.dtpicker2.OnHoverForeColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.dtpicker2.OnPressedColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.dtpicker2.Radius = 2
        Me.dtpicker2.Size = New System.Drawing.Size(118, 30)
        Me.dtpicker2.TabIndex = 9
        Me.dtpicker2.Text = "5/30/2024"
        Me.dtpicker2.Value = New Date(2024, 5, 30, 16, 46, 27, 716)
        '
        'GunaLabel4
        '
        Me.GunaLabel4.AutoSize = True
        Me.GunaLabel4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel4.Location = New System.Drawing.Point(24, 145)
        Me.GunaLabel4.Name = "GunaLabel4"
        Me.GunaLabel4.Size = New System.Drawing.Size(108, 17)
        Me.GunaLabel4.TabIndex = 7
        Me.GunaLabel4.Text = "PURCHASE DATE:"
        '
        'GunaLabel3
        '
        Me.GunaLabel3.AutoSize = True
        Me.GunaLabel3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel3.Location = New System.Drawing.Point(295, 149)
        Me.GunaLabel3.Name = "GunaLabel3"
        Me.GunaLabel3.Size = New System.Drawing.Size(70, 17)
        Me.GunaLabel3.TabIndex = 6
        Me.GunaLabel3.Text = "DUE DATE:"
        '
        'purchaseBox
        '
        Me.purchaseBox.BackColor = System.Drawing.Color.White
        Me.purchaseBox.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.purchaseBox.FocusedLineColor = System.Drawing.Color.Black
        Me.purchaseBox.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.purchaseBox.LineColor = System.Drawing.Color.Black
        Me.purchaseBox.Location = New System.Drawing.Point(162, 89)
        Me.purchaseBox.Name = "purchaseBox"
        Me.purchaseBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.purchaseBox.SelectedText = ""
        Me.purchaseBox.Size = New System.Drawing.Size(114, 26)
        Me.purchaseBox.TabIndex = 5
        Me.purchaseBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaLabel2
        '
        Me.GunaLabel2.AutoSize = True
        Me.GunaLabel2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel2.Location = New System.Drawing.Point(24, 98)
        Me.GunaLabel2.Name = "GunaLabel2"
        Me.GunaLabel2.Size = New System.Drawing.Size(131, 17)
        Me.GunaLabel2.TabIndex = 4
        Me.GunaLabel2.Text = "PURCHASE NUMBER:"
        '
        'termBox
        '
        Me.termBox.BaseColor = System.Drawing.Color.White
        Me.termBox.BorderColor = System.Drawing.Color.Black
        Me.termBox.BorderSize = 1
        Me.termBox.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.termBox.Enabled = False
        Me.termBox.FocusedBaseColor = System.Drawing.Color.White
        Me.termBox.FocusedBorderColor = System.Drawing.Color.Black
        Me.termBox.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.termBox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.termBox.Location = New System.Drawing.Point(929, 35)
        Me.termBox.Name = "termBox"
        Me.termBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.termBox.SelectedText = ""
        Me.termBox.Size = New System.Drawing.Size(49, 33)
        Me.termBox.TabIndex = 3
        Me.termBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'nameBox
        '
        Me.nameBox.BackColor = System.Drawing.Color.Black
        Me.nameBox.BaseColor = System.Drawing.Color.White
        Me.nameBox.BorderColor = System.Drawing.Color.Black
        Me.nameBox.BorderSize = 1
        Me.nameBox.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.nameBox.Enabled = False
        Me.nameBox.FocusedBaseColor = System.Drawing.Color.White
        Me.nameBox.FocusedBorderColor = System.Drawing.Color.Black
        Me.nameBox.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.nameBox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.nameBox.Location = New System.Drawing.Point(280, 35)
        Me.nameBox.Name = "nameBox"
        Me.nameBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.nameBox.SelectedText = ""
        Me.nameBox.Size = New System.Drawing.Size(634, 33)
        Me.nameBox.TabIndex = 2
        '
        'codeTxt
        '
        Me.codeTxt.BackColor = System.Drawing.Color.White
        Me.codeTxt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.codeTxt.FocusedLineColor = System.Drawing.Color.Black
        Me.codeTxt.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.codeTxt.LineColor = System.Drawing.Color.Black
        Me.codeTxt.Location = New System.Drawing.Point(165, 42)
        Me.codeTxt.Name = "codeTxt"
        Me.codeTxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.codeTxt.SelectedText = ""
        Me.codeTxt.Size = New System.Drawing.Size(86, 26)
        Me.codeTxt.TabIndex = 1
        Me.codeTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaLabel1
        '
        Me.GunaLabel1.AutoSize = True
        Me.GunaLabel1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel1.Location = New System.Drawing.Point(25, 51)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(96, 17)
        Me.GunaLabel1.TabIndex = 0
        Me.GunaLabel1.Text = "FACILITY CODE:"
        '
        'replaceTxt
        '
        Me.replaceTxt.BackColor = System.Drawing.Color.Black
        Me.replaceTxt.BaseColor = System.Drawing.Color.White
        Me.replaceTxt.BorderColor = System.Drawing.Color.Black
        Me.replaceTxt.BorderSize = 1
        Me.replaceTxt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.replaceTxt.FocusedBaseColor = System.Drawing.Color.White
        Me.replaceTxt.FocusedBorderColor = System.Drawing.Color.Black
        Me.replaceTxt.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.replaceTxt.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.replaceTxt.Location = New System.Drawing.Point(740, 5)
        Me.replaceTxt.Name = "replaceTxt"
        Me.replaceTxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.replaceTxt.SelectedText = ""
        Me.replaceTxt.Size = New System.Drawing.Size(46, 26)
        Me.replaceTxt.TabIndex = 18
        Me.replaceTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lopezCheck
        '
        Me.lopezCheck.AutoSize = True
        Me.lopezCheck.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lopezCheck.Location = New System.Drawing.Point(115, 10)
        Me.lopezCheck.Name = "lopezCheck"
        Me.lopezCheck.Size = New System.Drawing.Size(106, 17)
        Me.lopezCheck.TabIndex = 24
        Me.lopezCheck.Text = "LOPEZ QUEZON"
        Me.lopezCheck.UseVisualStyleBackColor = True
        '
        'replacementCheck
        '
        Me.replacementCheck.AutoSize = True
        Me.replacementCheck.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.replacementCheck.Location = New System.Drawing.Point(370, 10)
        Me.replacementCheck.Name = "replacementCheck"
        Me.replacementCheck.Size = New System.Drawing.Size(103, 17)
        Me.replacementCheck.TabIndex = 20
        Me.replacementCheck.Text = "REPLACEMENT "
        Me.replacementCheck.UseVisualStyleBackColor = True
        '
        'walkCheck
        '
        Me.walkCheck.AutoSize = True
        Me.walkCheck.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.walkCheck.ForeColor = System.Drawing.Color.White
        Me.walkCheck.Location = New System.Drawing.Point(158, 6)
        Me.walkCheck.Name = "walkCheck"
        Me.walkCheck.Size = New System.Drawing.Size(119, 17)
        Me.walkCheck.TabIndex = 21
        Me.walkCheck.Text = "WALK - IN PATIENT"
        Me.walkCheck.UseVisualStyleBackColor = True
        '
        'monitoringCheck
        '
        Me.monitoringCheck.AutoSize = True
        Me.monitoringCheck.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.monitoringCheck.Location = New System.Drawing.Point(13, 10)
        Me.monitoringCheck.Name = "monitoringCheck"
        Me.monitoringCheck.Size = New System.Drawing.Size(96, 17)
        Me.monitoringCheck.TabIndex = 22
        Me.monitoringCheck.Text = "MONITORING"
        Me.monitoringCheck.UseVisualStyleBackColor = True
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dgv1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv1.BackgroundColor = System.Drawing.Color.White
        Me.dgv1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgv1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgv1.ColumnHeadersHeight = 21
        Me.dgv1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cancelPo, Me.soa_number, Me.Column2, Me.order_type, Me.fac_code, Me.facility_name, Me.term, Me.purchase_number, Me.purchase_date, Me.quantity, Me.sub_total, Me.brochure, Me.poster, Me.drying_rack, Me.replacement, Me.ads_amount, Me.due_date, Me.total_amount, Me.balance, Me.username, Me.remarks})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(243, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv1.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgv1.EnableHeadersVisualStyles = False
        Me.dgv1.GridColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.dgv1.Location = New System.Drawing.Point(23, 336)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.RowHeadersVisible = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgv1.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv1.Size = New System.Drawing.Size(1004, 295)
        Me.dgv1.TabIndex = 16
        Me.dgv1.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.WhiteGrid
        Me.dgv1.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.dgv1.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.dgv1.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.dgv1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.dgv1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.dgv1.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.dgv1.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.dgv1.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.White
        Me.dgv1.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised
        Me.dgv1.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgv1.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black
        Me.dgv1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.dgv1.ThemeStyle.HeaderStyle.Height = 21
        Me.dgv1.ThemeStyle.ReadOnly = False
        Me.dgv1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.dgv1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgv1.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgv1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black
        Me.dgv1.ThemeStyle.RowsStyle.Height = 22
        Me.dgv1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.dgv1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black
        '
        'cancelPo
        '
        Me.cancelPo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.cancelPo.HeaderText = "CANCEL P.O"
        Me.cancelPo.Name = "cancelPo"
        Me.cancelPo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cancelPo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.cancelPo.Width = 95
        '
        'soa_number
        '
        Me.soa_number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.soa_number.DataPropertyName = "soa_number"
        Me.soa_number.HeaderText = "SOA NUMBER"
        Me.soa_number.Name = "soa_number"
        Me.soa_number.Width = 110
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column2.DataPropertyName = "soa_date"
        Me.Column2.HeaderText = "SOA DATE"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 88
        '
        'order_type
        '
        Me.order_type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.order_type.DataPropertyName = "order_type"
        Me.order_type.HeaderText = "TYPE"
        Me.order_type.Name = "order_type"
        Me.order_type.Width = 59
        '
        'fac_code
        '
        Me.fac_code.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.fac_code.DataPropertyName = "fac_code"
        Me.fac_code.HeaderText = "FACILITY CODE"
        Me.fac_code.Name = "fac_code"
        Me.fac_code.Width = 114
        '
        'facility_name
        '
        Me.facility_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.facility_name.DataPropertyName = "facility_name"
        Me.facility_name.HeaderText = "FACILITY NAME"
        Me.facility_name.Name = "facility_name"
        Me.facility_name.Width = 117
        '
        'term
        '
        Me.term.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.term.DataPropertyName = "term"
        Me.term.HeaderText = "TERM"
        Me.term.Name = "term"
        Me.term.Width = 64
        '
        'purchase_number
        '
        Me.purchase_number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.purchase_number.DataPropertyName = "purchase_number"
        Me.purchase_number.HeaderText = "PURCHASE NUMBER"
        Me.purchase_number.Name = "purchase_number"
        Me.purchase_number.Width = 147
        '
        'purchase_date
        '
        Me.purchase_date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.purchase_date.DataPropertyName = "purchase_date"
        Me.purchase_date.HeaderText = "PURCHASE DATE"
        Me.purchase_date.Name = "purchase_date"
        Me.purchase_date.Width = 125
        '
        'quantity
        '
        Me.quantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.quantity.DataPropertyName = "quantity"
        Me.quantity.HeaderText = "QUANTITY"
        Me.quantity.Name = "quantity"
        Me.quantity.Width = 92
        '
        'sub_total
        '
        Me.sub_total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.sub_total.DataPropertyName = "sub_total"
        Me.sub_total.HeaderText = "SUB TOTAL"
        Me.sub_total.Name = "sub_total"
        Me.sub_total.Width = 95
        '
        'brochure
        '
        Me.brochure.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.brochure.DataPropertyName = "brochure"
        Me.brochure.HeaderText = "BROCHURE"
        Me.brochure.Name = "brochure"
        Me.brochure.Width = 96
        '
        'poster
        '
        Me.poster.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.poster.DataPropertyName = "poster"
        Me.poster.HeaderText = "POSTER"
        Me.poster.Name = "poster"
        Me.poster.Width = 76
        '
        'drying_rack
        '
        Me.drying_rack.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.drying_rack.DataPropertyName = "drying_rack"
        Me.drying_rack.HeaderText = "DRYING RACK"
        Me.drying_rack.Name = "drying_rack"
        Me.drying_rack.Width = 112
        '
        'replacement
        '
        Me.replacement.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.replacement.DataPropertyName = "replacement"
        Me.replacement.HeaderText = "REPLACEMENT"
        Me.replacement.Name = "replacement"
        Me.replacement.Width = 113
        '
        'ads_amount
        '
        Me.ads_amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ads_amount.DataPropertyName = "ads_amount"
        Me.ads_amount.HeaderText = "ADS AMOUNT"
        Me.ads_amount.Name = "ads_amount"
        Me.ads_amount.Width = 112
        '
        'due_date
        '
        Me.due_date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.due_date.DataPropertyName = "due_date"
        Me.due_date.HeaderText = "DUE DATE"
        Me.due_date.Name = "due_date"
        Me.due_date.Width = 88
        '
        'total_amount
        '
        Me.total_amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.total_amount.DataPropertyName = "total_amount"
        Me.total_amount.HeaderText = "TOTAL AMOUNT"
        Me.total_amount.Name = "total_amount"
        Me.total_amount.Width = 124
        '
        'balance
        '
        Me.balance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.balance.DataPropertyName = "balance"
        Me.balance.HeaderText = "BALANCE"
        Me.balance.Name = "balance"
        Me.balance.Width = 84
        '
        'username
        '
        Me.username.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.username.DataPropertyName = "username"
        Me.username.HeaderText = "USERNAME"
        Me.username.Name = "username"
        Me.username.Width = 96
        '
        'remarks
        '
        Me.remarks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.remarks.DataPropertyName = "remarks"
        Me.remarks.HeaderText = "REMARKS"
        Me.remarks.Name = "remarks"
        Me.remarks.Width = 88
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel4.Controls.Add(Me.replaceAdd)
        Me.Panel4.Controls.Add(Me.expiredCheck)
        Me.Panel4.Controls.Add(Me.replaceTxt)
        Me.Panel4.Controls.Add(Me.remBox)
        Me.Panel4.Controls.Add(Me.remLbl)
        Me.Panel4.Controls.Add(Me.replaceCombo)
        Me.Panel4.Controls.Add(Me.lopezCheck)
        Me.Panel4.Controls.Add(Me.replacementCheck)
        Me.Panel4.Controls.Add(Me.monitoringCheck)
        Me.Panel4.Location = New System.Drawing.Point(23, 294)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1001, 36)
        Me.Panel4.TabIndex = 17
        '
        'replaceAdd
        '
        Me.replaceAdd.Location = New System.Drawing.Point(659, 7)
        Me.replaceAdd.Name = "replaceAdd"
        Me.replaceAdd.Size = New System.Drawing.Size(75, 23)
        Me.replaceAdd.TabIndex = 28
        Me.replaceAdd.Text = "ADD"
        Me.replaceAdd.UseVisualStyleBackColor = True
        '
        'expiredCheck
        '
        Me.expiredCheck.AutoSize = True
        Me.expiredCheck.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.expiredCheck.Location = New System.Drawing.Point(235, 9)
        Me.expiredCheck.Name = "expiredCheck"
        Me.expiredCheck.Size = New System.Drawing.Size(124, 17)
        Me.expiredCheck.TabIndex = 27
        Me.expiredCheck.Text = "NEARLY EXPIRED FC"
        Me.expiredCheck.UseVisualStyleBackColor = True
        '
        'remBox
        '
        Me.remBox.BackColor = System.Drawing.Color.Black
        Me.remBox.BaseColor = System.Drawing.Color.White
        Me.remBox.BorderColor = System.Drawing.Color.Black
        Me.remBox.BorderSize = 1
        Me.remBox.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.remBox.FocusedBaseColor = System.Drawing.Color.White
        Me.remBox.FocusedBorderColor = System.Drawing.Color.Black
        Me.remBox.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.remBox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.remBox.Location = New System.Drawing.Point(867, 3)
        Me.remBox.Multiline = True
        Me.remBox.Name = "remBox"
        Me.remBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.remBox.SelectedText = ""
        Me.remBox.Size = New System.Drawing.Size(131, 28)
        Me.remBox.TabIndex = 26
        '
        'remLbl
        '
        Me.remLbl.AutoSize = True
        Me.remLbl.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.remLbl.Location = New System.Drawing.Point(792, 9)
        Me.remLbl.Name = "remLbl"
        Me.remLbl.Size = New System.Drawing.Size(69, 17)
        Me.remLbl.TabIndex = 26
        Me.remLbl.Text = "REMARKS:"
        '
        'replaceCombo
        '
        Me.replaceCombo.FormattingEnabled = True
        Me.replaceCombo.Location = New System.Drawing.Point(557, 8)
        Me.replaceCombo.Name = "replaceCombo"
        Me.replaceCombo.Size = New System.Drawing.Size(96, 21)
        Me.replaceCombo.TabIndex = 25
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(1042, 34)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(71, 619)
        Me.Panel2.TabIndex = 27
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel5.Location = New System.Drawing.Point(-67, 34)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(71, 619)
        Me.Panel5.TabIndex = 28
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel6.Location = New System.Drawing.Point(0, 649)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1047, 39)
        Me.Panel6.TabIndex = 29
        '
        'typeText
        '
        Me.typeText.BackColor = System.Drawing.Color.Black
        Me.typeText.BaseColor = System.Drawing.Color.White
        Me.typeText.BorderColor = System.Drawing.Color.Black
        Me.typeText.BorderSize = 1
        Me.typeText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.typeText.FocusedBaseColor = System.Drawing.Color.White
        Me.typeText.FocusedBorderColor = System.Drawing.Color.Black
        Me.typeText.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.typeText.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.typeText.Location = New System.Drawing.Point(288, 0)
        Me.typeText.Multiline = True
        Me.typeText.Name = "typeText"
        Me.typeText.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.typeText.SelectedText = ""
        Me.typeText.Size = New System.Drawing.Size(131, 28)
        Me.typeText.TabIndex = 29
        '
        'Pos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1047, 654)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.dgv1)
        Me.Controls.Add(Me.grpBox)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Pos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pos"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpBox.ResumeLayout(False)
        Me.grpBox.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.grpOrders.ResumeLayout(False)
        Me.grpOrders.PerformLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GunaElipse1 As Guna.UI.WinForms.GunaElipse
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblshow As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaControlBox3 As Guna.UI.WinForms.GunaControlBox
    Friend WithEvents GunaControlBox2 As Guna.UI.WinForms.GunaControlBox
    Friend WithEvents GunaControlBox1 As Guna.UI.WinForms.GunaControlBox
    Friend WithEvents GunaDragControl1 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents dgv1 As Guna.UI.WinForms.GunaDataGridView
    Friend WithEvents grpBox As Guna.UI.WinForms.GunaGroupBox
    Friend WithEvents GunaLabel10 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents noticeButton As Guna.UI.WinForms.GunaAdvenceButton
    Friend WithEvents reportButton As Guna.UI.WinForms.GunaAdvenceButton
    Friend WithEvents payButton As Guna.UI.WinForms.GunaAdvenceButton
    Friend WithEvents soaButton As Guna.UI.WinForms.GunaAdvenceButton
    Friend WithEvents addButton As Guna.UI.WinForms.GunaAdvenceButton
    Friend WithEvents dtpicker1 As Guna.UI.WinForms.GunaDateTimePicker
    Friend WithEvents lopezCheck As CheckBox
    Friend WithEvents replacementCheck As CheckBox
    Friend WithEvents walkCheck As CheckBox
    Friend WithEvents monitoringCheck As CheckBox
    Friend WithEvents amountTxt As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel9 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents qtyTxt As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel8 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents grpOrders As Guna.UI.WinForms.GunaGroupBox
    Friend WithEvents GunaLabel11 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents computeButton As Guna.UI.WinForms.GunaAdvenceButton
    Friend WithEvents replaceTxt As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents dryingTxt As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents posterTxt As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents totalTxt As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents adsTxt As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents brochureTxt As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel7 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel6 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel5 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents dryingCheck As CheckBox
    Friend WithEvents posterCheck As CheckBox
    Friend WithEvents brochureCheck As CheckBox
    Friend WithEvents dtpicker2 As Guna.UI.WinForms.GunaDateTimePicker
    Friend WithEvents GunaLabel4 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel3 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents purchaseBox As Guna.UI.WinForms.GunaLineTextBox
    Friend WithEvents GunaLabel2 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents termBox As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents nameBox As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents codeTxt As Guna.UI.WinForms.GunaLineTextBox
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents replaceCombo As ComboBox
    Friend WithEvents remBox As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents remLbl As Guna.UI.WinForms.GunaLabel
    Friend WithEvents cancelPo As DataGridViewCheckBoxColumn
    Friend WithEvents soa_number As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents order_type As DataGridViewTextBoxColumn
    Friend WithEvents fac_code As DataGridViewTextBoxColumn
    Friend WithEvents facility_name As DataGridViewTextBoxColumn
    Friend WithEvents term As DataGridViewTextBoxColumn
    Friend WithEvents purchase_number As DataGridViewTextBoxColumn
    Friend WithEvents purchase_date As DataGridViewTextBoxColumn
    Friend WithEvents quantity As DataGridViewTextBoxColumn
    Friend WithEvents sub_total As DataGridViewTextBoxColumn
    Friend WithEvents brochure As DataGridViewTextBoxColumn
    Friend WithEvents poster As DataGridViewTextBoxColumn
    Friend WithEvents drying_rack As DataGridViewTextBoxColumn
    Friend WithEvents replacement As DataGridViewTextBoxColumn
    Friend WithEvents ads_amount As DataGridViewTextBoxColumn
    Friend WithEvents due_date As DataGridViewTextBoxColumn
    Friend WithEvents total_amount As DataGridViewTextBoxColumn
    Friend WithEvents balance As DataGridViewTextBoxColumn
    Friend WithEvents username As DataGridViewTextBoxColumn
    Friend WithEvents remarks As DataGridViewTextBoxColumn
    Friend WithEvents expiredCheck As CheckBox
    Friend WithEvents replaceAdd As Button
    Friend WithEvents CachedStatementOfAccount1 As CachedStatementOfAccount
    Friend WithEvents typeText As Guna.UI.WinForms.GunaTextBox
End Class
