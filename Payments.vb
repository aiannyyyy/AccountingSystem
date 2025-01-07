Imports System.Data.Odbc
Public Class Payments
    Private connString As String = "DSN=dashboard"
    Private originalBalance As Double = 0
    Private Sub Payments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        codeTxt.SetOnGotFocus()
        mopCombo.Items.AddRange({"BANK TO BANK", "WALK IN"})
        formCombo.Items.AddRange({"CASH", "CHECK"})
        bankCombo.Items.AddRange({"BPI", "LANDBANK", "PNB"})
        dtpicker2.Value = Date.Now
        dtpicker3.Value = Date.Now
        dtpicker4.Value = Date.Now
        dtpicker5.Value = Date.Now

        lblshow.Text = "PAYMENTS | USER: " + Login.userTxt.Text + ""

        loaddgv()
        Payments()
    End Sub

    Public Sub loaddgv()
        Call connection()
        da = New OdbcDataAdapter("Select * from acccounting order by purchase_date desc", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "acccounting")
        dgv1.DataSource = ds.Tables("acccounting").DefaultView
    End Sub

    Private Sub codeTxt_TextChanged(sender As Object, e As EventArgs) Handles codeTxt.TextChanged
        If String.IsNullOrEmpty(codeTxt.Text) Then
            Payments()
            ClearFields()
            Return
        End If

        Try
            ' Open the connection if it's not already open
            If conn.State <> ConnectionState.Open Then
                conn.Open()
            End If

            ' Correct the query to join the tables properly and use parameterized query
            Dim query As String = "SELECT fac_code, fac_name, type2 FROM facility_data WHERE fac_code = ?"

            Using cmd As New OdbcCommand(query, conn)
                cmd.Parameters.AddWithValue("fac_code", codeTxt.Text)

                Using rd As OdbcDataReader = cmd.ExecuteReader()
                    If rd.Read() Then
                        ' Ensure the UI update is done on the main thread
                        If Me.IsHandleCreated Then
                            Me.Invoke(Sub()
                                          codeTxt.Text = rd("fac_code").ToString()
                                          nameBox.Text = rd("fac_name").ToString()
                                          Dim term As Integer

                                          Select Case rd("type2").ToString()
                                              Case "GOVERNMENT", "LGU"
                                                  term = 60
                                              Case "PRIVATE"
                                                  term = 45
                                              Case Else
                                                  term = 0 ' default term value if type2 is not matched
                                          End Select

                                          termBox.Text = term.ToString()
                                      End Sub)
                        End If
                    Else
                        If Me.IsHandleCreated Then
                            Me.Invoke(Sub()
                                          nameBox.Clear()
                                          termBox.Clear()
                                      End Sub)
                        End If
                    End If
                End Using
            End Using

            ' Fetch the accounting records and display in DataGridView
            da = New OdbcDataAdapter("SELECT * FROM acccounting WHERE fac_code LIKE ? order by purchase_date desc", conn)
            da.SelectCommand.Parameters.AddWithValue("fac_code", "%" & codeTxt.Text & "%")

            ds = New DataSet
            da.Fill(ds, "acccounting")
            dgv1.DataSource = ds.Tables("acccounting").DefaultView



            ' Calculate the grand total of total_amount column from the DataSet
            Dim grandTotal As Decimal = 0

            For Each row As DataRow In ds.Tables("acccounting").Rows
                If Not IsDBNull(row("balance")) Then
                    grandTotal += Convert.ToDecimal(row("balance"))
                End If
            Next

            ' Display the grand total in balanceBox
            balanceBox.Text = grandTotal.ToString()

            ' Calculate interest and update related fields
            CalculateAndUpdateInterest()

            adsTxt.Text = 0
            baddebtsTxt.Text = 0
            wtaxTxt.Text = 0
            btaxText.Text = 0


        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try

        ' Automatically select and click the first row in the DataGridView
        If dgv1.Rows.Count > 0 Then
            dgv1.ClearSelection()
            dgv1.Rows(0).Selected = True
            dgv1.CurrentCell = dgv1.Rows(0).Cells(0)
            dgv1_CellContentClick(dgv1, New DataGridViewCellEventArgs(0, 0))
        End If


        ' Fetch the accounting records and display in DataGridView
        da = New OdbcDataAdapter("SELECT * FROM payments WHERE fac_code LIKE ? order by or_date desc", conn)
        da.SelectCommand.Parameters.AddWithValue("fac_code", "%" & codeTxt.Text & "%")

        ds = New DataSet
        da.Fill(ds, "payments")
        dgv2.DataSource = ds.Tables("payments").DefaultView
    End Sub

    Private Sub interestTxt_TextChanged(sender As Object, e As EventArgs) Handles interestTxt.TextChanged
        CalculateAndUpdateInterest()
    End Sub

    Private Sub CalculateAndUpdateInterest()
        Try
            ' Open the connection if it's not already open
            If conn.State <> ConnectionState.Open Then
                conn.Open()
            End If

            ' Updated query to join acccounting and facility_data tables
            Dim query As String = "SELECT a.sub_total, a.due_date, f.type2 FROM acccounting a INNER JOIN facility_data f ON a.fac_code = f.fac_code WHERE a.fac_code = ?"

            Using cmd As New OdbcCommand(query, conn)
                cmd.Parameters.AddWithValue("fac_code", codeTxt.Text)

                Using rd As OdbcDataReader = cmd.ExecuteReader()
                    If rd.Read() Then
                        ' Ensure the UI update is done on the main thread
                        If Me.IsHandleCreated Then
                            Me.Invoke(Sub()
                                          Dim principal As Double = Convert.ToDouble(rd("sub_total"))
                                          Dim dueDate As Date = Convert.ToDateTime(rd("due_date"))
                                          Dim dateOfPayment As Date = dtpicker4.Value
                                          Dim type2 As String = rd("type2").ToString()

                                          ' Check if due date is within the specified range
                                          Dim startDate As Date = New Date(2020, 8, 11)
                                          Dim endDate As Date = New Date(2023, 11, 1)
                                          Dim totalDays As Integer = (dateOfPayment - dueDate).Days
                                          Dim percentage As Double = 0.02
                                          Dim days As Integer = 30
                                          Dim interest As Double = 0

                                          If dueDate >= startDate And dueDate <= endDate Then
                                              Dim term As Integer
                                              Select Case type2
                                                  Case "GOVERNMENT", "LGU"
                                                      term = 30
                                                  Case "PRIVATE"
                                                      term = 15
                                                  Case Else
                                                      term = 0 ' default term value if type2 is not matched
                                              End Select

                                              interest = (principal * percentage) * (totalDays / days)
                                          End If

                                          ' Ensure interest is non-negative
                                          If interest < 0 Then
                                              interest = 0
                                          End If

                                          interestTxt.Text = interest.ToString("F2")

                                          ' Update balance and subtotal
                                          Dim soAmount As Double
                                          Dim adsAmount As Double
                                          Dim badDebts As Double
                                          Dim businessTax As Double

                                          If Double.TryParse(soamountTxt.Text, soAmount) AndAlso Double.TryParse(adsTxt.Text, adsAmount) AndAlso Double.TryParse(baddebtsTxt.Text, badDebts) AndAlso Double.TryParse(btaxText.Text, businessTax) Then
                                              Dim balance As Double = (soAmount + interest + adsAmount) - (badDebts + businessTax)
                                              subtotalTxt.Text = balance.ToString("F2")
                                          Else
                                              'MessageBox.Show("Invalid amount in one or more fields")
                                          End If
                                      End Sub)
                        End If
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Sub

    Private Sub ClearFields()
        codeTxt.Clear()
        nameBox.Clear()
        termBox.Clear()
        balanceBox.Clear()
        orderTxt.Clear()
        soaTxt.Clear()
        enbsTxt.Clear()
        adsTxt.Clear()
        othersTxt.Clear()
        soamountTxt.Clear()
        dtpicker1.Value = Date.Now
        interestTxt.Clear()
        subtotalTxt.Clear()
        mopCombo.SelectedIndex = -1
        formCombo.SelectedIndex = -1
        chequeTxt.Clear()
        bankCombo.SelectedIndex = -1
        remTxt.Clear()
        amountpaidTxt.Clear()
        checkBox1.Checked = False
    End Sub

    Private Sub dgv1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv1.CellContentClick
        If e.RowIndex >= 0 AndAlso e.RowIndex < dgv1.Rows.Count Then
            soaTxt.Text = dgv1.Rows(e.RowIndex).Cells(0).Value.ToString()
            enbsTxt.Text = dgv1.Rows(e.RowIndex).Cells(9).Value.ToString()
            adsTxt.Text = dgv1.Rows(e.RowIndex).Cells(15).Value.ToString()
            dtpicker1.Value = Convert.ToDateTime(dgv1.Rows(e.RowIndex).Cells(16).Value)
            soamountTxt.Text = dgv1.Rows(e.RowIndex).Cells(10).Value.ToString()

            ' Recalculate interest and update related fields
            CalculateAndUpdateInterest()
        End If
    End Sub
    Public Sub payments()
        Call connection()
        da = New OdbcDataAdapter("Select * from payments order by or_date desc", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "payments")
        dgv2.DataSource = ds.Tables("payments").DefaultView
    End Sub

    Public Sub afterPay()
        ' Fetch the accounting records and display in DataGridView
        da = New OdbcDataAdapter("SELECT * FROM payments WHERE fac_code LIKE ? order by or_date desc", conn)
        da.SelectCommand.Parameters.AddWithValue("fac_code", "%" & codeTxt.Text & "%")

        ds = New DataSet
        da.Fill(ds, "payments")
        dgv2.DataSource = ds.Tables("payments").DefaultView
    End Sub

    Private Function ExecuteQuery(query As String) As Integer
        Using conn As New OdbcConnection(connString)
            Using cmd As New OdbcCommand(query, conn)
                conn.Open()
                Return cmd.ExecuteNonQuery()
            End Using
        End Using
    End Function

    'Private Sub InsertRecord(soaNumber As String, enbs As String, facCode As String, balance As Double, adsAmount As Double, dueDate As Date, soaAmount As Double, interestDate As Date, interest As Double, orDate As Date, orNumber As String, badDebts As Double, businessTax As Double, wtax As Double, others As String, grandTotal As Double, mop As String, fop As String, chequeDetails As String, bank As String, datePayment As Date, datePosted As Date, amountPaid As Integer, remarks As String, stopInterest As String, username As String)
    '    Dim query As String = $"INSERT INTO payments (soa_number, enbs, fac_code, balance, ads_amount, due_date, soa_amount, interest_date, interest, or_date, or_number, bad_debts, business_tax, wtax, others, grand_total, mop, fop, cheque_details, bank, date_payment, date_posted, amount_paid, remarks, stop_interest, username) " &
    '                          $"VALUES ('{soaNumber}', '{enbs}', '{facCode}', {balance}, {adsAmount}, '{dueDate.ToString("yyyy-MM-dd")}', {soaAmount}, '{interestDate.ToString("yyyy-MM-dd")}', {interest}, '{orDate.ToString("yyyy-MM-dd")}', '{orNumber}', {badDebts}, '{businessTax}', {wtax}, '{others}', {grandTotal}, '{mop}', '{fop}', '{chequeDetails}', '{bank}', '{datePayment.ToString("yyyy-MM-dd")}', '{datePosted.ToString("yyyy-MM-dd")}', {amountPaid}, '{remarks}', '{stopInterest}', '{username}')"
    '    ExecuteQuery(query)
    'End Sub

    Private Sub InsertRecord(soaNumber As String, enbs As String, facCode As String, balance As Double, adsAmount As Double, dueDate As Date, soaAmount As Double, interestDate As Date, interest As Double, orDate As Date, orNumber As String, badDebts As Double, businessTax As Double, wtax As Double, others As String, grandTotal As Double, mop As String, fop As String, chequeDetails As String, bank As String, datePayment As Date, datePosted As Date, amountPaid As Integer, remarks As String, stopInterest As String, username As String)
        ' Prepare the SQL query for inserting the payment record
        Dim query As String = $"INSERT INTO payments (soa_number, enbs, fac_code, balance, ads_amount, due_date, soa_amount, interest_date, interest, or_date, or_number, bad_debts, business_tax, wtax, others, grand_total, mop, fop, cheque_details, bank, date_payment, date_posted, amount_paid, remarks, stop_interest, username) " &
                          $"VALUES ('{soaNumber}', '{enbs}', '{facCode}', {balance}, {adsAmount}, '{dueDate.ToString("yyyy-MM-dd")}', {soaAmount}, '{interestDate.ToString("yyyy-MM-dd")}', {interest}, '{orDate.ToString("yyyy-MM-dd")}', '{orNumber}', {badDebts}, '{businessTax}', {wtax}, '{others}', {grandTotal}, '{mop}', '{fop}', '{chequeDetails}', '{bank}', '{datePayment.ToString("yyyy-MM-dd")}', '{datePosted.ToString("yyyy-MM-dd")}', {amountPaid}, '{remarks}', '{stopInterest}', '{username}')"

        ' Execute the insert query using ExecuteQuery function
        ExecuteQuery(query)

        ' After inserting, update the accounting balance based on the soa_number
        Dim updateBalanceQuery As String = $"UPDATE acccounting SET balance = balance - {amountPaid} WHERE soa_number = '{soaNumber}'"
        ExecuteQuery(updateBalanceQuery)
    End Sub
    Private Sub addButton_Click(sender As Object, e As EventArgs) Handles addButton.Click
        ' Retrieve input values
        Dim soaNumber As String = soaTxt.Text
        Dim enbs As String = enbsTxt.Text
        Dim facCode As String = codeTxt.Text
        Dim balance As Double = Convert.ToDouble(balanceBox.Text)
        Dim adsAmount As Double = Convert.ToDouble(adsTxt.Text)
        Dim dueDate As Date = dtpicker1.Value
        Dim soaAmount As Double = Convert.ToDouble(soamountTxt.Text)
        Dim interestDate As Date = dtpicker2.Value
        Dim interest As Double = Convert.ToDouble(interestTxt.Text)
        Dim orDate As Date = dtpicker3.Value
        Dim orNumber As String = orderTxt.Text
        Dim badDebts As Double = Convert.ToDouble(baddebtsTxt.Text)
        Dim businessTax As Double = Convert.ToDouble(btaxText.Text)
        Dim wtax As Double = Convert.ToDouble(wtaxTxt.Text)
        Dim others As String = othersTxt.Text
        Dim grandTotal As Double = Convert.ToDouble(subtotalTxt.Text)
        Dim mop As String = mopCombo.Text
        Dim fop As String = formCombo.Text
        Dim chequeDetails As String = chequeTxt.Text
        Dim bank As String = bankCombo.Text
        Dim datePayment As Date = dtpicker4.Value
        Dim datePosted As Date = Date.Now ' Assuming current date for datePosted
        Dim amountPaid As Integer = Convert.ToDouble(amountpaidTxt.Text)
        Dim remarks As String = remTxt.Text
        Dim stopInterest As String = If(checkBox1.Checked, "STOP INTEREST", String.Empty)
        Dim username As String = Login.userTxt.Text

        ' Insert the new record into the database
        InsertRecord(soaNumber, enbs, facCode, balance, adsAmount, dueDate, soaAmount, interestDate, interest, orDate, orNumber, badDebts, businessTax, wtax, others, grandTotal, mop, fop, chequeDetails, bank, datePayment, datePosted, amountPaid, remarks, stopInterest, username)

        ' Notify user of successful insertion
        MessageBox.Show("Payment successfully processed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        loaddgv()
        afterPay()
        ClearFields()
    End Sub

    Private Sub orderButton_Click(sender As Object, e As EventArgs) Handles orderButton.Click
        Pos.Show()
        Me.Hide()
    End Sub

    Private Sub baddebtsTxt_TextChanged(sender As Object, e As EventArgs) Handles baddebtsTxt.TextChanged
        CalculateAndUpdateInterest()
    End Sub

    Private Sub btaxText_TextChanged(sender As Object, e As EventArgs) Handles btaxText.TextChanged
        CalculateAndUpdateInterest()
    End Sub

    Private Sub GunaControlBox1_Click(sender As Object, e As EventArgs) Handles GunaControlBox1.Click
        Application.Exit()
    End Sub

    Private Sub adsTxt_TextChanged(sender As Object, e As EventArgs) Handles adsTxt.TextChanged

    End Sub

    Private Sub homeBtn_Click(sender As Object, e As EventArgs) Handles homeBtn.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub formCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles formCombo.SelectedIndexChanged

    End Sub

    Private Sub balanceBox_TextChanged(sender As Object, e As EventArgs) Handles balanceBox.TextChanged

    End Sub

    Private Sub amountpaidTxt_TextChanged(sender As Object, e As EventArgs) Handles amountpaidTxt.TextChanged
        ' Store the initial balance once, when the balanceBox is first populated
        If originalBalance = 0 AndAlso Not String.IsNullOrEmpty(balanceBox.Text) Then
            Double.TryParse(balanceBox.Text, originalBalance)
        End If

        ' Check if the entered amount is a valid number
        Dim amountPaid As Double
        If Double.TryParse(amountpaidTxt.Text, amountPaid) Then
            ' Calculate the remaining balance
            Dim remainingBalance As Double = originalBalance - amountPaid

            ' Prevent negative balance
            If remainingBalance < 0 Then
                remainingBalance = 0
            End If

            ' Update the balanceBox with the new balance
            balanceBox.Text = remainingBalance.ToString("F2")
        Else
            ' If the amount paid box is empty, reset the balance to the original value
            If String.IsNullOrEmpty(amountpaidTxt.Text) Then
                balanceBox.Text = originalBalance.ToString("F2")
            End If
        End If
    End Sub
End Class