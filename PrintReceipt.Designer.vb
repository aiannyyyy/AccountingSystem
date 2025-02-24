<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintReceipt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PrintReceipt))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.orTxt = New Guna.UI.WinForms.GunaLineTextBox()
        Me.genBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(47, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Enter OR Number"
        '
        'orTxt
        '
        Me.orTxt.BackColor = System.Drawing.Color.White
        Me.orTxt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.orTxt.FocusedLineColor = System.Drawing.Color.Black
        Me.orTxt.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.orTxt.LineColor = System.Drawing.Color.Black
        Me.orTxt.Location = New System.Drawing.Point(59, 46)
        Me.orTxt.Name = "orTxt"
        Me.orTxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.orTxt.SelectedText = ""
        Me.orTxt.Size = New System.Drawing.Size(103, 32)
        Me.orTxt.TabIndex = 1
        Me.orTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'genBtn
        '
        Me.genBtn.Location = New System.Drawing.Point(59, 84)
        Me.genBtn.Name = "genBtn"
        Me.genBtn.Size = New System.Drawing.Size(93, 33)
        Me.genBtn.TabIndex = 2
        Me.genBtn.Text = "GENERATE"
        Me.genBtn.UseVisualStyleBackColor = True
        '
        'PrintReceipt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(220, 129)
        Me.Controls.Add(Me.genBtn)
        Me.Controls.Add(Me.orTxt)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "PrintReceipt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Print Receipt"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents orTxt As Guna.UI.WinForms.GunaLineTextBox
    Friend WithEvents genBtn As Button
End Class
