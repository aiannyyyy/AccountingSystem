<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NoticeForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NoticeForm))
        Me.GunaElipse1 = New Guna.UI.WinForms.GunaElipse(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GunaControlBox3 = New Guna.UI.WinForms.GunaControlBox()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.codeTxt = New Guna.UI.WinForms.GunaLineTextBox()
        Me.soaButton = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.GunaDragControl1 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GunaElipse1
        '
        Me.GunaElipse1.TargetControl = Me
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Panel1.Controls.Add(Me.GunaControlBox3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(222, 32)
        Me.Panel1.TabIndex = 0
        '
        'GunaControlBox3
        '
        Me.GunaControlBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaControlBox3.AnimationHoverSpeed = 0.07!
        Me.GunaControlBox3.AnimationSpeed = 0.03!
        Me.GunaControlBox3.IconColor = System.Drawing.Color.White
        Me.GunaControlBox3.IconSize = 15.0!
        Me.GunaControlBox3.Location = New System.Drawing.Point(189, 2)
        Me.GunaControlBox3.Name = "GunaControlBox3"
        Me.GunaControlBox3.OnHoverBackColor = System.Drawing.Color.FromArgb(CType(CType(164, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.GunaControlBox3.OnHoverIconColor = System.Drawing.Color.White
        Me.GunaControlBox3.OnPressedColor = System.Drawing.Color.Black
        Me.GunaControlBox3.Size = New System.Drawing.Size(30, 30)
        Me.GunaControlBox3.TabIndex = 4
        '
        'GunaLabel1
        '
        Me.GunaLabel1.AutoSize = True
        Me.GunaLabel1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel1.Location = New System.Drawing.Point(39, 45)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(141, 17)
        Me.GunaLabel1.TabIndex = 3
        Me.GunaLabel1.Text = "ENTER FACILITY CODE"
        '
        'codeTxt
        '
        Me.codeTxt.BackColor = System.Drawing.Color.White
        Me.codeTxt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.codeTxt.FocusedLineColor = System.Drawing.Color.Black
        Me.codeTxt.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codeTxt.LineColor = System.Drawing.Color.Black
        Me.codeTxt.Location = New System.Drawing.Point(30, 76)
        Me.codeTxt.Name = "codeTxt"
        Me.codeTxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.codeTxt.SelectedText = ""
        Me.codeTxt.Size = New System.Drawing.Size(160, 28)
        Me.codeTxt.TabIndex = 24
        Me.codeTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'soaButton
        '
        Me.soaButton.AnimationHoverSpeed = 0.07!
        Me.soaButton.AnimationSpeed = 0.03!
        Me.soaButton.BackColor = System.Drawing.Color.Transparent
        Me.soaButton.BaseColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.soaButton.BorderColor = System.Drawing.Color.Black
        Me.soaButton.CheckedBaseColor = System.Drawing.Color.Gray
        Me.soaButton.CheckedBorderColor = System.Drawing.Color.Black
        Me.soaButton.CheckedForeColor = System.Drawing.Color.White
        Me.soaButton.CheckedImage = Nothing
        Me.soaButton.CheckedLineColor = System.Drawing.Color.DimGray
        Me.soaButton.DialogResult = System.Windows.Forms.DialogResult.None
        Me.soaButton.FocusedColor = System.Drawing.Color.Empty
        Me.soaButton.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.soaButton.ForeColor = System.Drawing.Color.White
        Me.soaButton.Image = Nothing
        Me.soaButton.ImageSize = New System.Drawing.Size(20, 20)
        Me.soaButton.LineColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.soaButton.Location = New System.Drawing.Point(62, 116)
        Me.soaButton.Name = "soaButton"
        Me.soaButton.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.soaButton.OnHoverBorderColor = System.Drawing.Color.Black
        Me.soaButton.OnHoverForeColor = System.Drawing.Color.Black
        Me.soaButton.OnHoverImage = Nothing
        Me.soaButton.OnHoverLineColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.soaButton.OnPressedColor = System.Drawing.Color.Black
        Me.soaButton.Radius = 2
        Me.soaButton.Size = New System.Drawing.Size(93, 30)
        Me.soaButton.TabIndex = 25
        Me.soaButton.Text = "GENERATE"
        Me.soaButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.soaButton.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.ClearTypeGridFit
        '
        'GunaDragControl1
        '
        Me.GunaDragControl1.TargetControl = Me.Panel1
        '
        'NoticeForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(222, 164)
        Me.Controls.Add(Me.soaButton)
        Me.Controls.Add(Me.codeTxt)
        Me.Controls.Add(Me.GunaLabel1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "NoticeForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NoticeForm"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GunaElipse1 As Guna.UI.WinForms.GunaElipse
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GunaControlBox3 As Guna.UI.WinForms.GunaControlBox
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents codeTxt As Guna.UI.WinForms.GunaLineTextBox
    Friend WithEvents soaButton As Guna.UI.WinForms.GunaAdvenceButton
    Friend WithEvents GunaDragControl1 As Guna.UI.WinForms.GunaDragControl
End Class
