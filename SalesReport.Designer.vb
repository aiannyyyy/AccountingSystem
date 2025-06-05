<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SalesReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SalesReport))
        Me.dtpicker1 = New Guna.UI.WinForms.GunaDateTimePicker()
        Me.dtpicker2 = New Guna.UI.WinForms.GunaDateTimePicker()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel2 = New Guna.UI.WinForms.GunaLabel()
        Me.genBtn = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.SuspendLayout()
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
        Me.dtpicker1.Location = New System.Drawing.Point(21, 41)
        Me.dtpicker1.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpicker1.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpicker1.Name = "dtpicker1"
        Me.dtpicker1.OnHoverBaseColor = System.Drawing.Color.White
        Me.dtpicker1.OnHoverBorderColor = System.Drawing.Color.Black
        Me.dtpicker1.OnHoverForeColor = System.Drawing.Color.Black
        Me.dtpicker1.OnPressedColor = System.Drawing.Color.Black
        Me.dtpicker1.Size = New System.Drawing.Size(125, 30)
        Me.dtpicker1.TabIndex = 0
        Me.dtpicker1.Text = "6/5/2025"
        Me.dtpicker1.Value = New Date(2025, 6, 5, 11, 0, 27, 187)
        '
        'dtpicker2
        '
        Me.dtpicker2.BaseColor = System.Drawing.Color.White
        Me.dtpicker2.BorderColor = System.Drawing.Color.Black
        Me.dtpicker2.CustomFormat = Nothing
        Me.dtpicker2.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.dtpicker2.FocusedColor = System.Drawing.Color.Black
        Me.dtpicker2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpicker2.ForeColor = System.Drawing.Color.Black
        Me.dtpicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpicker2.Location = New System.Drawing.Point(171, 41)
        Me.dtpicker2.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpicker2.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpicker2.Name = "dtpicker2"
        Me.dtpicker2.OnHoverBaseColor = System.Drawing.Color.White
        Me.dtpicker2.OnHoverBorderColor = System.Drawing.Color.Black
        Me.dtpicker2.OnHoverForeColor = System.Drawing.Color.Black
        Me.dtpicker2.OnPressedColor = System.Drawing.Color.Black
        Me.dtpicker2.Size = New System.Drawing.Size(125, 30)
        Me.dtpicker2.TabIndex = 1
        Me.dtpicker2.Text = "6/5/2025"
        Me.dtpicker2.Value = New Date(2025, 6, 5, 11, 0, 27, 187)
        '
        'GunaLabel1
        '
        Me.GunaLabel1.AutoSize = True
        Me.GunaLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel1.Location = New System.Drawing.Point(61, 15)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(41, 15)
        Me.GunaLabel1.TabIndex = 2
        Me.GunaLabel1.Text = "FROM"
        '
        'GunaLabel2
        '
        Me.GunaLabel2.AutoSize = True
        Me.GunaLabel2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel2.Location = New System.Drawing.Point(222, 15)
        Me.GunaLabel2.Name = "GunaLabel2"
        Me.GunaLabel2.Size = New System.Drawing.Size(23, 15)
        Me.GunaLabel2.TabIndex = 3
        Me.GunaLabel2.Text = "TO"
        '
        'genBtn
        '
        Me.genBtn.AnimationHoverSpeed = 0.07!
        Me.genBtn.AnimationSpeed = 0.03!
        Me.genBtn.BackColor = System.Drawing.Color.Transparent
        Me.genBtn.BaseColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.genBtn.BorderColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.genBtn.CheckedBaseColor = System.Drawing.Color.Gray
        Me.genBtn.CheckedBorderColor = System.Drawing.Color.Black
        Me.genBtn.CheckedForeColor = System.Drawing.Color.White
        Me.genBtn.CheckedImage = Nothing
        Me.genBtn.CheckedLineColor = System.Drawing.Color.DimGray
        Me.genBtn.DialogResult = System.Windows.Forms.DialogResult.None
        Me.genBtn.FocusedColor = System.Drawing.Color.Empty
        Me.genBtn.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.genBtn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.genBtn.Image = Nothing
        Me.genBtn.ImageSize = New System.Drawing.Size(20, 20)
        Me.genBtn.LineColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.genBtn.Location = New System.Drawing.Point(109, 87)
        Me.genBtn.Name = "genBtn"
        Me.genBtn.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.genBtn.OnHoverBorderColor = System.Drawing.Color.Black
        Me.genBtn.OnHoverForeColor = System.Drawing.Color.Black
        Me.genBtn.OnHoverImage = Nothing
        Me.genBtn.OnHoverLineColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.genBtn.OnPressedColor = System.Drawing.Color.Black
        Me.genBtn.Radius = 2
        Me.genBtn.Size = New System.Drawing.Size(103, 30)
        Me.genBtn.TabIndex = 26
        Me.genBtn.Text = "GENERATE"
        Me.genBtn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.genBtn.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.ClearTypeGridFit
        '
        'SalesReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(318, 137)
        Me.Controls.Add(Me.genBtn)
        Me.Controls.Add(Me.GunaLabel2)
        Me.Controls.Add(Me.GunaLabel1)
        Me.Controls.Add(Me.dtpicker2)
        Me.Controls.Add(Me.dtpicker1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "SalesReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SalesReport"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dtpicker1 As Guna.UI.WinForms.GunaDateTimePicker
    Friend WithEvents dtpicker2 As Guna.UI.WinForms.GunaDateTimePicker
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel2 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents genBtn As Guna.UI.WinForms.GunaAdvenceButton
End Class
