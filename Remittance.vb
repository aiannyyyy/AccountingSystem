Imports System.Data.Odbc

Public Class Remittance
    Private connString As String = "DSN=dashboard"
    Private Sub txtDenomination_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt1.KeyPress, txt2.KeyPress, txt3.KeyPress, txt4.KeyPress, txt5.KeyPress, txt6.KeyPress, txt7.KeyPress, txt8.KeyPress, txt9.KeyPress, txt10.KeyPress
        ' Allow only numbers and control keys (like backspace)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Remittance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt1.SetOnGotFocus()

        Me.AcceptButton = doneBtn
    End Sub

    Private Function ExecuteQuery(query As String, parameters As List(Of OdbcParameter)) As Integer
        Using conn As New OdbcConnection(connString)
            Using cmd As New OdbcCommand(query, conn)
                conn.Open()
                cmd.Parameters.AddRange(parameters.ToArray()) ' Apply parameters
                Return cmd.ExecuteNonQuery()
            End Using
        End Using
    End Function

    Private Sub InsertRecord(oneK As Integer, fiveH As Integer, twoH As Integer, oneH As Integer, fifty As Integer, twenty As Integer, ten As Integer, fiveP As Integer, oneP As Integer, cents As Integer, date_posted As Date)
        Dim query As String = "INSERT INTO daily_remittance (one_thousand, five_hundred, two_hundred, one_hundred, fifty_pesos, twenty_pesos, ten_pesos, five_pesos, one_peso, cents, date_posted) " &
                          "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"

        Dim parameters As New List(Of OdbcParameter) From {
        New OdbcParameter("?", oneK),
        New OdbcParameter("?", fiveH),
        New OdbcParameter("?", twoH),
        New OdbcParameter("?", oneH),
        New OdbcParameter("?", fifty),
        New OdbcParameter("?", twenty),
        New OdbcParameter("?", ten),
        New OdbcParameter("?", fiveP),
        New OdbcParameter("?", oneP),
        New OdbcParameter("?", cents),
        New OdbcParameter("?", date_posted)
    }

        ExecuteQuery(query, parameters)
    End Sub

    Private Sub doneBtn_Click(sender As Object, e As EventArgs) Handles doneBtn.Click
        Try
            ' Convert input values safely; if empty, default to 0
            Dim oneK As Integer = If(String.IsNullOrWhiteSpace(txt1.Text), 0, Integer.Parse(txt1.Text))
            Dim fiveH As Integer = If(String.IsNullOrWhiteSpace(txt2.Text), 0, Integer.Parse(txt2.Text))
            Dim twoH As Integer = If(String.IsNullOrWhiteSpace(txt3.Text), 0, Integer.Parse(txt3.Text))
            Dim oneH As Integer = If(String.IsNullOrWhiteSpace(txt4.Text), 0, Integer.Parse(txt4.Text))
            Dim fifty As Integer = If(String.IsNullOrWhiteSpace(txt5.Text), 0, Integer.Parse(txt5.Text))
            Dim twenty As Integer = If(String.IsNullOrWhiteSpace(txt6.Text), 0, Integer.Parse(txt6.Text))
            Dim ten As Integer = If(String.IsNullOrWhiteSpace(txt7.Text), 0, Integer.Parse(txt7.Text))
            Dim fiveP As Integer = If(String.IsNullOrWhiteSpace(txt8.Text), 0, Integer.Parse(txt8.Text))
            Dim oneP As Integer = If(String.IsNullOrWhiteSpace(txt9.Text), 0, Integer.Parse(txt9.Text))
            Dim cents As Integer = If(String.IsNullOrWhiteSpace(txt10.Text), 0, Integer.Parse(txt10.Text))

            ' Get current timestamp
            Dim date_posted As DateTime = Date.Now

            ' Insert record
            InsertRecord(oneK, fiveH, twoH, oneH, fifty, twenty, ten, fiveP, oneP, cents, date_posted)

            MessageBox.Show("Insert Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            generatereport(date_posted)
            clear()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub generatereport(date_posted As Date)
        Dim report As New DailyRemittance

        ' Convert date to Crystal Reports format (yyyy, MM, dd)
        Dim selformula1 As String = "{daily_remittance1.date_posted} = Date(" & date_posted.Year & ", " & date_posted.Month & ", " & date_posted.Day & ")"

        ' Apply main report selection formula
        report.RecordSelectionFormula = selformula1

        ' Apply filter to the subreport named "subreport"
        report.Subreports("subreport").RecordSelectionFormula = "{payments1.fop} = 'CHECK' " &
            "AND {payments1.date_posted} IN DateTime(" & date_posted.Year & ", " & date_posted.Month & ", " & date_posted.Day & ", 00, 00, 00) " &
            "TO DateTime(" & date_posted.Year & ", " & date_posted.Month & ", " & date_posted.Day & ", 23, 59, 59)"

        ' Refresh the report
        report.Refresh()

        ' Create a new form to display the report
        Dim reportForm1 As New Form
        Dim crystalReportViewer1 As New CrystalDecisions.Windows.Forms.CrystalReportViewer

        ' Configure the CrystalReportViewer
        crystalReportViewer1.ReportSource = report
        crystalReportViewer1.Dock = DockStyle.Fill

        ' Add the viewer to the form
        reportForm1.Controls.Add(crystalReportViewer1)
        reportForm1.WindowState = FormWindowState.Maximized

        ' Show the form
        reportForm1.Show()
    End Sub

    Public Sub clear()
        txt1.Clear()
        txt2.Clear()
        txt3.Clear()
        txt4.Clear()
        txt5.Clear()
        txt6.Clear()
        txt7.Clear()
        txt8.Clear()
        txt9.Clear()
        txt10.Clear()
    End Sub

End Class