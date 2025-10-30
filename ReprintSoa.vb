Public Class ReprintSoa
    Private Sub soaButton_Click(sender As Object, e As EventArgs) Handles soaButton.Click
        ' Assuming you are checking the value of the first row and the fourth column
        Dim rowIndex As Integer = 0 ' Change this to the row you want to check
        'Dim cellValue As String = Pos.dgv1.Rows(rowIndex).Cells(3).Value.ToString()
        Dim cellValue As String = Pos.dgv1.Rows(rowIndex).Cells("order_type").Value.ToString()
        Dim cellValue1 As String = Pos.dgv1.Rows(rowIndex).Cells("fac_code").Value.ToString()


        If cellValue = "ENBS" OrElse cellValue = "Monitoring" OrElse cellValue = "ENBS Expired Filter Card" Then
            Dim report As New StatementOfAccount()
            Dim selformula As String = "{acccounting1.soa_txt} = '" & soaTxt.Text & "'"
            report.RecordSelectionFormula = selformula

            ' Refresh the report to load data
            report.Refresh()

            Dim reportForm As New Form
            Dim crystalReportViewer As New CrystalDecisions.Windows.Forms.CrystalReportViewer
            crystalReportViewer.ReportSource = report
            crystalReportViewer.Dock = DockStyle.Fill
            reportForm.Controls.Add(crystalReportViewer)
            reportForm.WindowState = FormWindowState.Maximized
            reportForm.Show()
        ElseIf cellValue = "COURIER" Then
            ' Generate the Crystal Report
            Dim report2 As New StatementOfAccountCourier
            Dim selformula2 As String = "{acccounting1.soa_txt} = '" & soaTxt.Text & "'"
            report2.RecordSelectionFormula = selformula2

            ' Refresh the report to load data
            report2.Refresh()

            Dim reportForm2 As New Form
            Dim crystalReportViewer2 As New CrystalDecisions.Windows.Forms.CrystalReportViewer
            crystalReportViewer2.ReportSource = report2 ' Corrected this line
            crystalReportViewer2.Dock = DockStyle.Fill
            reportForm2.Controls.Add(crystalReportViewer2) ' Corrected this line
            reportForm2.WindowState = FormWindowState.Maximized
            reportForm2.Show()
        Else
            ' Generate the Crystal Report
            Dim report1 As New StatementOfAccountWithServiceFee()
            Dim selformula1 As String = "{acccounting1.soa_txt} = '" & soaTxt.Text & "'"
            report1.RecordSelectionFormula = selformula1

            ' Refresh the report to load data
            report1.Refresh()

            Dim reportForm1 As New Form
            Dim crystalReportViewer1 As New CrystalDecisions.Windows.Forms.CrystalReportViewer
            crystalReportViewer1.ReportSource = report1 ' Corrected this line
            crystalReportViewer1.Dock = DockStyle.Fill
            reportForm1.Controls.Add(crystalReportViewer1) ' Corrected this line
            reportForm1.WindowState = FormWindowState.Maximized
            reportForm1.Show()
        End If

        soaTxt.Clear()
    End Sub

    Private Sub ReprintSoa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call connection()

        Me.AcceptButton = soaButton

        soaTxt.SetOnGotFocus()
    End Sub
End Class