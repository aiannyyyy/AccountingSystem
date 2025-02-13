Imports System.Data.Odbc
Public Class DailySales

    Private Sub addButton_Click(sender As Object, e As EventArgs) Handles addButton.Click
        ' Create a new instance of the report
        Dim report As New DailyReport()

        ' Get the selected date from dtpicker4
        Dim selectedDate As DateTime = dtpicker1.Value

        ' Format the date for Crystal Reports selection formula
        Dim formattedDate As String = "DateTime(" & selectedDate.Year & ", " & selectedDate.Month & ", " & selectedDate.Day & ","

        ' Main Report Filter: Only "WALK IN" payments
        Dim mainFormula As String = "{payments1.date_posted} >= " & formattedDate & "00, 00, 00) " &
                                    "AND {payments1.date_posted} <= " & formattedDate & "23, 59, 59) " &
                                    "AND {payments1.mop} = 'WALK IN'"

        ' Sub-Report Filter: Exclude "WALK IN" payments
        Dim subFormula As String = "{payments1.date_posted} >= " & formattedDate & "00, 00, 00) " &
                                   "AND {payments1.date_posted} <= " & formattedDate & "23, 59, 59) " &
                                   "AND {payments1.mop} <> 'WALK IN'"

        ' Apply the formulas
        report.RecordSelectionFormula = mainFormula

        ' Apply formula to the sub-report (DailyReport1)
        report.Subreports("DailyReport1").RecordSelectionFormula = subFormula

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

    Private Sub DailySales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpicker1.Value = Date.Now
    End Sub
End Class