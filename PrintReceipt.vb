Public Class PrintReceipt
    Private Sub genBtn_Click(sender As Object, e As EventArgs) Handles genBtn.Click
        ' Create a new instance of the report
        Dim report As New ReceiptNoLines()

        ' Get the selected date from dtpicker4
        Dim selectedOr As String = orTxt.Text


        ' Main Report Filter: Only "WALK IN" payments
        Dim mainFormula As String = "{payments1.or_number} = '" & selectedOr & "'"

        ' Apply the formulas
        report.RecordSelectionFormula = mainFormula

        ' Refresh the report to apply the selection formulas
        report.Refresh()

        ' Create a new form to display the report
        Dim reportForm As New Form()
        Dim crystalReportViewer As New CrystalDecisions.Windows.Forms.CrystalReportViewer()

        ' Configure the CrystalReportViewer
        crystalReportViewer.ReportSource = report
        crystalReportViewer.Dock = DockStyle.Fill

        ' Add the viewer to the form
        reportForm.Controls.Add(crystalReportViewer)
        reportForm.WindowState = FormWindowState.Maximized

        ' Show the form
        reportForm.Show()
    End Sub
End Class