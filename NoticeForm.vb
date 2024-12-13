Imports System.Data.Odbc
Public Class NoticeForm
    Private Sub NoticeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        codeTxt.SetOnGotFocus()
        Me.AcceptButton = soaButton
    End Sub

    Private Sub soaButton_Click(sender As Object, e As EventArgs) Handles soaButton.Click
        Dim report As New Notice()

        ' Define the RecordSelectionFormula
        Dim selformula As String = "{acccounting1.fac_code} = '" & codeTxt.Text & "'"
        report.RecordSelectionFormula = selformula

        ' Refresh the report to apply the formula
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