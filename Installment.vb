' Refined Installment class with checkbox handling, interest recalculation, grand total update, and partial payment logic

Imports System.Data.Odbc

Public Class Installment
    Private connString As String = "DSN=dashboard"
    Private conn As New OdbcConnection(connString)

    Private Sub Installment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        codeTxt.Select()
        comboMonths.Items.AddRange({"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        UpdateGrandTotal()

        loadinstallmentdetails()

        partialTxt.Text = "0.00"
    End Sub

    Private Sub codeTxt_TextChanged(sender As Object, e As EventArgs) Handles codeTxt.TextChanged
        If String.IsNullOrWhiteSpace(codeTxt.Text) Then
            dgv1.DataSource = Nothing
            Return
        End If
        LoadSOAData()
        SyncCheckBoxes()
    End Sub

    Private Sub dtpicker1_ValueChanged(sender As Object, e As EventArgs) Handles dtpicker1.ValueChanged
        If Not String.IsNullOrWhiteSpace(codeTxt.Text) Then
            LoadSOAData()
            SyncCheckBoxes()
        End If
    End Sub

    Private Sub LoadSOAData()
        Try
            If conn.State <> ConnectionState.Open Then conn.Open()

            Dim query As String = "SELECT fac_code, purchase_number, soa_txt, due_date, total_amount FROM test_acccounting WHERE fac_code = ? ORDER BY soa_txt DESC"
            Using cmd As New OdbcCommand(query, conn)
                cmd.Parameters.AddWithValue("fac_code", codeTxt.Text.Trim())
                Dim adapter As New OdbcDataAdapter(cmd)
                Dim ds As New DataSet()
                adapter.Fill(ds, "soa")
                Dim dt As DataTable = ds.Tables("soa")

                If Not dt.Columns.Contains("interest") Then dt.Columns.Add("interest", GetType(Double))
                If Not dt.Columns.Contains("total") Then dt.Columns.Add("total", GetType(Double))

                For Each row As DataRow In dt.Rows
                    Dim totalAmount As Double = If(IsDBNull(row("total_amount")), 0, Convert.ToDouble(row("total_amount")))
                    Dim dueDate As Date = If(IsDBNull(row("due_date")), Date.Today, Convert.ToDateTime(row("due_date")))
                    Dim daysOverdue As Integer = Math.Max(0, (dtpicker1.Value.Date - dueDate.Date).Days)
                    Dim monthsOverdue As Double = daysOverdue / 30.0
                    Dim interest As Double = If(daysOverdue > 0, (totalAmount * 0.02) * monthsOverdue, 0)

                    row("interest") = Math.Round(interest, 2)
                    row("total") = Math.Round(totalAmount + interest, 2)
                Next

                dgv1.DataSource = dt.DefaultView
                dgv1.Columns("interest").DefaultCellStyle.Format = "N2"
                dgv1.Columns("total").DefaultCellStyle.Format = "N2"
                dgv1.Columns("total_amount").DefaultCellStyle.Format = "N2"
                dgv1.Columns("due_date").DefaultCellStyle.Format = "MM/dd/yyyy"
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading SOA data: " & ex.Message)
        End Try
    End Sub

    Private Sub dgv1_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgv1.CurrentCellDirtyStateChanged
        If dgv1.IsCurrentCellDirty Then
            dgv1.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub dgv1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv1.CellValueChanged
        If e.ColumnIndex = dgv1.Columns("check_box").Index Then
            Dim row As DataGridViewRow = dgv1.Rows(e.RowIndex)
            Dim isChecked As Boolean = Convert.ToBoolean(row.Cells("check_box").Value)

            Dim values(dgv1.Columns.Count - 2) As Object
            For i As Integer = 1 To dgv1.Columns.Count - 1
                values(i - 1) = row.Cells(i).Value
            Next

            If isChecked Then
                If Not IsRowInDgv2(values) Then
                    dgv2.Rows.Add(values)
                End If
            Else
                RemoveRowFromDgv2(values)
            End If
        End If

        If dgv2.Columns.Contains("Column2") Then
            dgv2.Sort(dgv2.Columns("Column2"), System.ComponentModel.ListSortDirection.Descending)
        End If

        UpdateGrandTotal()
        UpdateUnpaidOnly()
        UpdateWithInterest()
    End Sub

    Private Function IsRowInDgv2(values() As Object) As Boolean
        For Each row As DataGridViewRow In dgv2.Rows
            Dim match As Boolean = True
            For i As Integer = 0 To values.Length - 1
                If Not Object.Equals(row.Cells(i).Value, values(i)) Then
                    match = False
                    Exit For
                End If
            Next
            If match Then Return True
        Next
        Return False
    End Function

    Private Sub RemoveRowFromDgv2(values() As Object)
        For Each row As DataGridViewRow In dgv2.Rows
            Dim match As Boolean = True
            For i As Integer = 0 To values.Length - 1
                If Not Object.Equals(row.Cells(i).Value, values(i)) Then
                    match = False
                    Exit For
                End If
            Next
            If match Then
                dgv2.Rows.Remove(row)
                Exit For
            End If
        Next
    End Sub

    Private Sub SyncCheckBoxes()
        For Each row1 As DataGridViewRow In dgv1.Rows
            If row1.IsNewRow Then Continue For

            Dim values(dgv1.Columns.Count - 2) As Object
            For i As Integer = 1 To dgv1.Columns.Count - 1
                values(i - 1) = row1.Cells(i).Value
            Next

            row1.Cells("check_box").Value = IsRowInDgv2(values)
        Next
    End Sub

    Private Sub UpdateGrandTotal()
        Dim total As Decimal = 0

        For Each row As DataGridViewRow In dgv2.Rows
            If Not row.IsNewRow Then
                Dim value As Decimal = 0
                Decimal.TryParse(Convert.ToString(row.Cells("Column6").Value), value)
                total += value
            End If
        Next

        grandTotal.Text = total.ToString("N2")
    End Sub

    Private Sub UpdateUnpaidOnly()
        Dim unpaidTotal As Decimal = 0

        For Each row As DataGridViewRow In dgv2.Rows
            If Not row.IsNewRow Then
                Dim value As Decimal = 0
                Decimal.TryParse(Convert.ToString(row.Cells("Column4").Value), value)
                unpaidTotal += value
            End If
        Next

        lblUnpaid.Text = unpaidTotal.ToString("N2") ' <- Make sure lblUnpaid is a Label on your form
    End Sub

    Private Sub UpdateWithInterest()
        Dim unpaidInterest As Decimal = 0

        For Each row As DataGridViewRow In dgv2.Rows
            If Not row.IsNewRow Then
                Dim value As Decimal = 0
                Decimal.TryParse(Convert.ToString(row.Cells("Column5").Value), value)
                unpaidInterest += value
            End If
        Next

        lblInterest.Text = unpaidInterest.ToString("N2") ' <- Make sure lblUnpaid is a Label on your form
    End Sub

    ' Executes a SQL command and returns affected rows
    Private Function ExecuteQuery(query As String) As Integer
        Using conn As New OdbcConnection(connString)
            Using cmd As New OdbcCommand(query, conn)
                conn.Open()
                Return cmd.ExecuteNonQuery()
            End Using
        End Using
    End Function

    ' Gets the next incremental code like INS0001, INS0002, ...
    Private Function GetNextInstallmentCode() As String
        Dim lastCode As String = ""
        Dim query As String = "SELECT installment_code FROM installment ORDER BY id DESC LIMIT 1"

        Using conn As New OdbcConnection(connString)
            Using cmd As New OdbcCommand(query, conn)
                conn.Open()
                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing Then
                    lastCode = result.ToString()
                End If
            End Using
        End Using

        Dim nextNumber As Integer = 1
        If lastCode.StartsWith("INS") AndAlso lastCode.Length >= 7 Then
            Dim numericPart As String = lastCode.Substring(3)
            If Integer.TryParse(numericPart, nextNumber) Then
                nextNumber += 1
            End If
        End If

        Return "INS" & nextNumber.ToString("D4")
    End Function

    ' Inserts a record into installment table and returns number of rows affected
    Private Function InsertRecord(code As String, faccode As String, or_number As String, soa_number As String, dueDate As Date, unpaid As Decimal, interest As Decimal, totalBalance As Decimal, partialPayment As Decimal, grandTotal As Decimal, dateAsOf As Date, months As Integer) As Integer
        Dim query As String = $"INSERT INTO installment (installment_code, facility_code, purchase_number, soa_number, due_date, unpaid_amount, interest, total_balance, partial_payment, grand_total, dateAsOf, months) " &
                              $"VALUES ('{code}', '{faccode}', '{or_number}', '{soa_number}', '{dueDate:yyyy-MM-dd HH:mm:ss}', {unpaid:F2}, {interest:F2}, {totalBalance:F2}, {partialPayment:F2}, {grandTotal:F2}, '{dateAsOf:yyyy-MM-dd HH:mm:ss}', '{months}')"
        Return ExecuteQuery(query)
    End Function

    ' Main button click

    Public Sub cleartext()
        codeTxt.Clear()
        dtpicker1.Value = Date.Now
        comboMonths.SelectedIndex = -1
        partialTxt.Clear()
        lblUnpaid.Text = "0.00"
        lblInterest.Text = "0.00"
        grandTotal.Clear()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If dgv2.Rows.Count = 0 Then
            MessageBox.Show("Please select SOA(s) first.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim paymentAmount As Decimal = 0
        If Not Decimal.TryParse(partialTxt.Text, paymentAmount) Then
            MessageBox.Show("Invalid partial payment input.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' ✅ Allow zero payment (no blocking condition here)

        ' Validate months selection
        Dim months As Integer
        If Not Integer.TryParse(comboMonths.Text, months) OrElse months <= 0 Then
            MessageBox.Show("Please select a valid number of months.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim installmentCode As String = GetNextInstallmentCode()

        Dim totalGrandTotal As Decimal = Convert.ToDecimal(grandTotal.Text)
        Dim remainingGrandTotal As Decimal = totalGrandTotal - paymentAmount
        Dim originalPaymentAmount As Decimal = paymentAmount
        Dim insertSuccess As Boolean = False

        'For Each row As DataGridViewRow In dgv2.Rows
        '    ' ✅ If paymentAmount = 0, still allow record with 0 partial payment
        '    Dim faccode As String = row.Cells("Column7").Value.ToString
        '    Dim total As Decimal = Convert.ToDecimal(row.Cells("Column6").Value)
        '    Dim unpaid As Decimal = Convert.ToDecimal(row.Cells("Column4").Value)
        '    Dim interest As Decimal = Convert.ToDecimal(row.Cells("Column5").Value)
        '    Dim soaNumber As String = row.Cells("Column2").Value.ToString()
        '    Dim purchaseNumber As String = row.Cells("Column1").Value.ToString()
        '    Dim dueDate As Date = Convert.ToDateTime(row.Cells("Column3").Value)

        '    Dim payAmount As Decimal = Math.Min(paymentAmount, total)

        '    ' Insert even if payAmount is 0
        '    Dim result As Integer = InsertRecord(installmentCode, faccode, purchaseNumber, soaNumber, dueDate, unpaid, interest, total, payAmount, remainingGrandTotal, dtpicker1.Value, months)

        '    If result > 0 Then
        '        insertSuccess = True
        '    Else
        '        MessageBox.Show("Failed to insert installment. Schedule will not be saved.", "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        Return
        '    End If

        '    paymentAmount -= payAmount
        'Next
        For Each row As DataGridViewRow In dgv2.Rows
            Dim faccode As String = row.Cells("Column7").Value.ToString()
            Dim total As Decimal = Convert.ToDecimal(row.Cells("Column6").Value)
            Dim unpaid As Decimal = Convert.ToDecimal(row.Cells("Column4").Value)
            Dim interest As Decimal = Convert.ToDecimal(row.Cells("Column5").Value)
            Dim soaNumber As String = row.Cells("Column2").Value.ToString()
            Dim purchaseNumber As String = row.Cells("Column1").Value.ToString()
            Dim dueDate As Date = Convert.ToDateTime(row.Cells("Column3").Value)

            ' Total this row needs
            Dim rowTotalDue As Decimal = interest + unpaid

            ' Calculate payment applied to interest
            Dim interestPaid As Decimal = Math.Min(paymentAmount, interest)
            paymentAmount -= interestPaid

            ' Calculate remaining payment to apply to grand total
            Dim grandTotalPaid As Decimal = 0
            If paymentAmount > 0 Then
                grandTotalPaid = Math.Min(paymentAmount, unpaid)
                paymentAmount -= grandTotalPaid
            End If

            ' Insert into installment (unpaid and interest remain full for reference)
            Dim result As Integer = InsertRecord(
        installmentCode, faccode, purchaseNumber, soaNumber, dueDate,
        unpaid, interest, total,
        interestPaid + grandTotalPaid,
        remainingGrandTotal,
        dtpicker1.Value, months
    )

            If result > 0 Then
                insertSuccess = True
            Else
                MessageBox.Show("Failed to insert installment. Schedule will not be saved.", "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        Next

        ' Always insert schedule even if partial is 0
        If insertSuccess Then
            Try
                Dim remainingBalance As Decimal = If(remainingGrandTotal > 0, remainingGrandTotal, originalPaymentAmount)
                Dim monthlyDue As Decimal = Math.Round(remainingBalance / months, 2)
                Dim startDate As Date = dtpicker1.Value

                For i As Integer = 1 To months
                    Dim scheduleDate As Date = startDate.AddMonths(i)
                    Dim query As String = $"INSERT INTO installment_schedule (installment_code, month_number, due_date, due_amount) " &
                                      $"VALUES ('{installmentCode}', {i}, '{scheduleDate:yyyy-MM-dd}', {monthlyDue:F2})"

                    Dim scheduleResult As Integer = ExecuteQuery(query)
                    If scheduleResult <= 0 Then
                        MessageBox.Show($"Failed to insert schedule for month {i}.", "Schedule Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If
                Next

                MessageBox.Show("Installment and schedule saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cleartext()
                loadinstallmentdetails()
            Catch ex As Exception
                MessageBox.Show("Failed to insert schedule: " & ex.Message, "Schedule Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("No installment records were inserted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Public Sub loadinstallmentdetails()
        Try
            Call connection()
            Dim query As String = "SELECT " &
            "i.installment_code AS 'Installment Code', " &
            "i.facility_code AS 'Facility Code', " &
            "i.purchase_number AS 'Purchase Number', " &
            "i.soa_number AS 'SOA Number', " &
            "FORMAT(i.unpaid_amount, 2) AS 'Unpaid Amount', " &
            "FORMAT(i.interest, 2) AS 'Interest', " &
            "FORMAT(i.total_balance, 2) AS 'Total Balance', " &
            "FORMAT(i.partial_payment, 2) AS 'Partial Payment', " &
            "FORMAT(i.grand_total, 2) AS 'Grand Total', " &
            "i.months AS 'Total Months', " &
            "s.month_number AS 'Month #', " &
            "DATE_FORMAT(s.due_date, '%m/%d/%Y') AS 'Schedule Due Date', " &
            "FORMAT(s.due_amount, 2) AS 'Monthly Due', " &
            "CASE WHEN s.is_paid = 1 THEN 'Paid' ELSE 'Unpaid' END AS 'Status', " &
            "CASE WHEN s.paid_date IS NOT NULL THEN DATE_FORMAT(s.paid_date, '%m/%d/%Y') ELSE '' END AS 'Paid Date' " &
            "FROM installment i " &
            "LEFT JOIN installment_schedule s ON i.installment_code = s.installment_code " &
            "ORDER BY i.installment_code, s.month_number"

            Using da As New OdbcDataAdapter(query, conn)
                Dim ds As New DataSet()
                ds.Clear()
                da.Fill(ds, "detailed_combined")
                dgv3.DataSource = ds.Tables("detailed_combined").DefaultView
            End Using

            dgv3.ReadOnly = True

        Catch ex As Exception
            MessageBox.Show("Error loading detailed combined installment details: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

End Class