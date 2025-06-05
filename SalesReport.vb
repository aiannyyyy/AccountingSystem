Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Windows.Forms
Imports System.Data.Odbc

Public Class SalesReport
    Private Sub genBtn_Click(sender As Object, e As EventArgs) Handles genBtn.Click
        ' Inside your method or event handler
        Dim report As New ReportDocument()
        Dim reportPath As String = IO.Path.Combine(Application.StartupPath, "Report", "sales_report.rpt")

        Try
            ' Load the Crystal Report file
            report.Load(reportPath)

            ' Get dates from pickers and strip time component
            Dim startDate As Date = dtpicker1.Value.Date
            Dim endDate As Date = dtpicker2.Value.Date

            ' Build selection formula to include the entire range, from 00:00:00 to 23:59:59
            Dim selectionFormula As String = String.Format(
        "{{acccounting.soa_date}} in DateTime({0}, {1}, {2}, 0, 0, 0) to DateTime({3}, {4}, {5}, 23, 59, 59)",
        startDate.Year, startDate.Month, startDate.Day,
        endDate.Year, endDate.Month, endDate.Day
    )
            report.RecordSelectionFormula = selectionFormula

            ' Show report in a form with CrystalReportViewer
            Dim reportForm As New Form With {
        .WindowState = FormWindowState.Maximized,
        .Text = "Sales Report"
    }

            Dim crystalReportViewer As New CrystalReportViewer With {
        .Dock = DockStyle.Fill,
        .ReportSource = report
    }

            crystalReportViewer.RefreshReport()
            reportForm.Controls.Add(crystalReportViewer)
            reportForm.Show()

        Catch ex As Exception
            MessageBox.Show("Failed to load report: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SalesReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpicker1.Value = Date.Now
        dtpicker2.Value = Date.Now
    End Sub
End Class