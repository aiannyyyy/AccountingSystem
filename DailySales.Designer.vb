<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DailySales
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DailySales))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpicker1 = New Guna.UI.WinForms.GunaDateTimePicker()
        Me.addButton = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Select Date"
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
        Me.dtpicker1.Location = New System.Drawing.Point(39, 28)
        Me.dtpicker1.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpicker1.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpicker1.Name = "dtpicker1"
        Me.dtpicker1.OnHoverBaseColor = System.Drawing.Color.White
        Me.dtpicker1.OnHoverBorderColor = System.Drawing.Color.Black
        Me.dtpicker1.OnHoverForeColor = System.Drawing.Color.Black
        Me.dtpicker1.OnPressedColor = System.Drawing.Color.Black
        Me.dtpicker1.Size = New System.Drawing.Size(112, 24)
        Me.dtpicker1.TabIndex = 46
        Me.dtpicker1.Text = "6/27/2024"
        Me.dtpicker1.Value = New Date(2024, 6, 27, 11, 13, 18, 226)
        '
        'addButton
        '
        Me.addButton.AnimationHoverSpeed = 0.07!
        Me.addButton.AnimationSpeed = 0.03!
        Me.addButton.BackColor = System.Drawing.Color.Transparent
        Me.addButton.BaseColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.addButton.BorderColor = System.Drawing.Color.Black
        Me.addButton.CheckedBaseColor = System.Drawing.Color.Gray
        Me.addButton.CheckedBorderColor = System.Drawing.Color.Black
        Me.addButton.CheckedForeColor = System.Drawing.Color.White
        Me.addButton.CheckedImage = Nothing
        Me.addButton.CheckedLineColor = System.Drawing.Color.DimGray
        Me.addButton.DialogResult = System.Windows.Forms.DialogResult.None
        Me.addButton.FocusedColor = System.Drawing.Color.Empty
        Me.addButton.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addButton.ForeColor = System.Drawing.Color.Black
        Me.addButton.Image = Nothing
        Me.addButton.ImageSize = New System.Drawing.Size(20, 20)
        Me.addButton.LineColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.addButton.Location = New System.Drawing.Point(50, 56)
        Me.addButton.Name = "addButton"
        Me.addButton.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.addButton.OnHoverBorderColor = System.Drawing.Color.Black
        Me.addButton.OnHoverForeColor = System.Drawing.Color.Black
        Me.addButton.OnHoverImage = Nothing
        Me.addButton.OnHoverLineColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.addButton.OnPressedColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.addButton.Radius = 2
        Me.addButton.Size = New System.Drawing.Size(86, 30)
        Me.addButton.TabIndex = 47
        Me.addButton.Text = "GENERATE"
        Me.addButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.addButton.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.ClearTypeGridFit
        '
        'DailySales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(186, 93)
        Me.Controls.Add(Me.addButton)
        Me.Controls.Add(Me.dtpicker1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "DailySales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Daily Sales Report"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents dtpicker1 As Guna.UI.WinForms.GunaDateTimePicker
    Friend WithEvents addButton As Guna.UI.WinForms.GunaAdvenceButton
End Class
