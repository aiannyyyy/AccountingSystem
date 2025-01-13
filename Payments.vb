Imports System.Data.Odbc
Public Class Payments
    Private connString As String = "DSN=dashboard"
    ' Declare class-level variables to store the initial balance
    Private originalBalance As Double
    Private remainingBalance As Double

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
        payments()

        adsLbl.Visible = False
        adsTxt.Visible = False
    End Sub

    Public Sub loaddgv()
        Call connection()
        da = New OdbcDataAdapter("Select * from acccounting order by purchase_date desc", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "acccounting")
        dgv1.DataSource = ds.Tables("acccounting").DefaultView
    End Sub

    'Private Sub codeTxt_TextChanged(sender As Object, e As EventArgs) Handles codeTxt.TextChanged
    '    If String.IsNullOrEmpty(codeTxt.Text) Then
    '        Payments()
    '        ClearFields()
    '        Return
    '    End If

    '    Try
    '        ' Open the connection if it's not already open
    '        If conn.State <> ConnectionState.Open Then
    '            conn.Open()
    '        End If

    '        ' Correct the query to join the tables properly and use parameterized query
    '        Dim query As String = "SELECT fac_code, fac_name, type2 FROM facility_data WHERE fac_code = ?"

    '        Using cmd As New OdbcCommand(query, conn)
    '            cmd.Parameters.AddWithValue("fac_code", codeTxt.Text)

    '            Using rd As OdbcDataReader = cmd.ExecuteReader()
    '                If rd.Read() Then
    '                    ' Ensure the UI update is done on the main thread
    '                    If Me.IsHandleCreated Then
    '                        Me.Invoke(Sub()
    '                                      codeTxt.Text = rd("fac_code").ToString()
    '                                      nameBox.Text = rd("fac_name").ToString()
    '                                      Dim term As Integer

    '                                      Select Case rd("type2").ToString()
    '                                          Case "GOVERNMENT", "LGU"
    '                                              term = 60
    '                                          Case "PRIVATE"
    '                                              term = 45
    '                                          Case Else
    '                                              term = 0 ' default term value if type2 is not matched
    '                                      End Select

    '                                      termBox.Text = term.ToString()
    '                                  End Sub)
    '                    End If
    '                Else
    '                    If Me.IsHandleCreated Then
    '                        Me.Invoke(Sub()
    '                                      nameBox.Clear()
    '                                      termBox.Clear()
    '                                  End Sub)
    '                    End If
    '                End If
    '            End Using
    '        End Using

    '        ' Fetch the accounting records and display in DataGridView
    '        da = New OdbcDataAdapter("SELECT * FROM acccounting WHERE fac_code LIKE ? order by purchase_date desc", conn)
    '        da.SelectCommand.Parameters.AddWithValue("fac_code", "%" & codeTxt.Text & "%")

    '        ds = New DataSet
    '        da.Fill(ds, "acccounting")
    '        dgv1.DataSource = ds.Tables("acccounting").DefaultView



    '        ' Calculate the grand total of total_amount column from the DataSet
    '        Dim grandTotal As Decimal = 0

    '        For Each row As DataRow In ds.Tables("acccounting").Rows
    '            If Not IsDBNull(row("balance")) Then
    '                grandTotal += Convert.ToDecimal(row("balance"))
    '            End If
    '        Next

    '        ' Display the grand total in balanceBox
    '        balanceBox.Text = grandTotal.ToString("F2")

    '        ' Calculate interest and update related fields
    '        CalculateAndUpdateInterest()

    '        adsTxt.Text = 0
    '        baddebtsTxt.Text = 0
    '        wtaxTxt.Text = 0
    '        btaxText.Text = 0


    '    Catch ex As Exception
    '        MessageBox.Show("An error occurred: " & ex.Message)
    '    End Try

    '    ' Automatically select and click the first row in the DataGridView
    '    If dgv1.Rows.Count > 0 Then
    '        dgv1.ClearSelection()
    '        dgv1.Rows(0).Selected = True
    '        dgv1.CurrentCell = dgv1.Rows(0).Cells(0)
    '        dgv1_CellContentClick(dgv1, New DataGridViewCellEventArgs(0, 0))
    '    End If


    '    ' Fetch the accounting records and display in DataGridView
    '    da = New OdbcDataAdapter("SELECT * FROM payments WHERE fac_code LIKE ? order by or_date desc", conn)
    '    da.SelectCommand.Parameters.AddWithValue("fac_code", "%" & codeTxt.Text & "%")

    '    ds = New DataSet
    '    da.Fill(ds, "payments")
    '    dgv2.DataSource = ds.Tables("payments").DefaultView
    'End Sub

    Private Sub codeTxt_TextChanged(sender As Object, e As EventArgs) Handles codeTxt.TextChanged
        If String.IsNullOrEmpty(codeTxt.Text) Then
            payments()
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

            ' Update balanceBox with the grandTotal value
            totalBalance.Text = grandTotal.ToString("F2")

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

    Public Sub newBalance()

    End Sub

    Private Sub interestTxt_TextChanged(sender As Object, e As EventArgs) Handles interestTxt.TextChanged
    End Sub

    Private Sub ClearFields()
        codeTxt.Clear()
        nameBox.Clear()
        termBox.Clear()
        totalBalance.Clear()
        orderTxt.Clear()
        soaTxt.Clear()
        enbsTxt.Clear()
        adsTxt.Clear()
        othersTxt.Clear()
        soamountTxt.Clear()
        dtpicker1.Value = Date.Now
        interestTxt.Clear()
        'subtotalTxt.Clear()
        mopCombo.SelectedIndex = -1
        formCombo.SelectedIndex = -1
        chequeTxt.Clear()
        bankCombo.SelectedIndex = -1
        remTxt.Clear()
        amountpaidTxt.Clear()
        checkBox1.Checked = False
    End Sub

    'Private Sub dgv1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv1.CellContentClick
    '    If e.RowIndex >= 0 AndAlso e.RowIndex < dgv1.Rows.Count Then
    '        soaTxt.Text = dgv1.Rows(e.RowIndex).Cells(0).Value.ToString()
    '        enbsTxt.Text = dgv1.Rows(e.RowIndex).Cells(9).Value.ToString()
    '        adsTxt.Text = dgv1.Rows(e.RowIndex).Cells(15).Value.ToString()

    '        ' Safely parse the date
    '        Dim dateValue As DateTime
    '        If DateTime.TryParse(dgv1.Rows(e.RowIndex).Cells(16).Value.ToString(), dateValue) Then
    '            dtpicker1.Value = dateValue
    '        Else
    '            dtpicker1.Value = DateTime.Now ' Default to current date if parsing fails
    '        End If

    '        ' Parse and format the balance
    '        Dim cellValue As Double
    '        If Double.TryParse(dgv1.Rows(e.RowIndex).Cells(18).Value.ToString(), cellValue) Then
    '            balanceTxt.Text = cellValue.ToString("F2")
    '        Else
    '            balanceTxt.Text = "0.00"
    '        End If

    '        soamountTxt.Text = dgv1.Rows(e.RowIndex).Cells(10).Value.ToString()

    '        ' Recalculate interest and update related fields
    '        CalculateAndUpdateInterest()
    '    End If
    'End Sub
    'Private Sub dgv1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv1.CellContentClick
    '    If e.RowIndex >= 0 AndAlso e.RowIndex < dgv1.Rows.Count Then
    '        soaTxt.Text = dgv1.Rows(e.RowIndex).Cells(0).Value.ToString()
    '        enbsTxt.Text = dgv1.Rows(e.RowIndex).Cells(9).Value.ToString()
    '        adsTxt.Text = dgv1.Rows(e.RowIndex).Cells(15).Value.ToString()

    '        ' Safely parse the date
    '        Dim dateValue As DateTime
    '        If DateTime.TryParse(dgv1.Rows(e.RowIndex).Cells(16).Value.ToString(), dateValue) Then
    '            dtpicker1.Value = dateValue
    '        Else
    '            dtpicker1.Value = DateTime.Now ' Default to current date if parsing fails
    '        End If

    '        ' Parse and format the balance (balanceTxt)
    '        Dim cellValue As Double
    '        If Double.TryParse(dgv1.Rows(e.RowIndex).Cells("balance").Value.ToString(), cellValue) Then
    '            balanceTxt.Text = cellValue.ToString("F2")
    '        Else
    '            balanceTxt.Text = "0.00"
    '        End If

    '        soamountTxt.Text = dgv1.Rows(e.RowIndex).Cells(10).Value.ToString()

    '        ' Recalculate interest and update related fields
    '        CalculateAndUpdateInterest()
    '    End If
    'End Sub

    Private Sub dgv1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv1.CellContentClick
        If e.RowIndex >= 0 AndAlso e.RowIndex < dgv1.Rows.Count Then
            ' Populate other text fields from the clicked row
            soaTxt.Text = dgv1.Rows(e.RowIndex).Cells(0).Value.ToString()
            enbsTxt.Text = dgv1.Rows(e.RowIndex).Cells(9).Value.ToString()
            adsTxt.Text = dgv1.Rows(e.RowIndex).Cells(15).Value.ToString()

            ' Safely parse the date
            Dim dateValue As DateTime
            If DateTime.TryParse(dgv1.Rows(e.RowIndex).Cells(16).Value.ToString(), dateValue) Then
                dtpicker1.Value = dateValue
            Else
                dtpicker1.Value = DateTime.Now ' Default to current date if parsing fails
            End If

            ' Parse and format the balance (balanceTxt)
            Dim cellValue As Double
            If Double.TryParse(dgv1.Rows(e.RowIndex).Cells("balance").Value.ToString(), cellValue) Then
                balanceperSoa.Text = cellValue.ToString("F2")
            Else
                balanceperSoa.Text = "0.00"
            End If

            soamountTxt.Text = dgv1.Rows(e.RowIndex).Cells(10).Value.ToString()

            ' Recalculate interest and update related fields
            CalculateAndUpdateInterest()

            ' Refresh the balance whenever the row is clicked
            RefreshBalance(e.RowIndex)
        End If
    End Sub

    ' Add this helper method to refresh the balance
    Private Sub RefreshBalance(rowIndex As Integer)
        ' Parse and format the balance (balanceTxt) in case it changes dynamically
        Dim cellValue As Double
        If Double.TryParse(dgv1.Rows(rowIndex).Cells("balance").Value.ToString(), cellValue) Then
            balanceperSoa.Text = cellValue.ToString("F2")
        Else
            balanceperSoa.Text = "0.00"
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

    'Private Sub InsertRecord(soaNumber As String, enbs As String, facCode As String, balance As Double, adsAmount As Double, dueDate As Date, soaAmount As Double, interestDate As Date, interest As Double, orDate As Date, orNumber As String, badDebts As Double, businessTax As Double, wtax As Double, others As String, grandTotal As Double, mop As String, fop As String, chequeDetails As String, bank As String, datePayment As Date, datePosted As Date, amountPaid As Double, remarks As String, stopInterest As String, username As String)
    '    ' Prepare the SQL query for inserting the payment record
    '    Dim query As String = $"INSERT INTO payments (soa_number, enbs, fac_code, balance, ads_amount, due_date, soa_amount, interest_date, interest, or_date, or_number, bad_debts, business_tax, wtax, others, grand_total, mop, fop, cheque_details, bank, date_payment, date_posted, amount_paid, remarks, stop_interest, username) " &
    '                      $"VALUES ('{soaNumber}', '{enbs}', '{facCode}', {balance}, {adsAmount}, '{dueDate.ToString("yyyy-MM-dd")}', {soaAmount}, '{interestDate.ToString("yyyy-MM-dd")}', {interest}, '{orDate.ToString("yyyy-MM-dd")}', '{orNumber}', {badDebts}, '{businessTax}', {wtax}, '{others}', {grandTotal}, '{mop}', '{fop}', '{chequeDetails}', '{bank}', '{datePayment.ToString("yyyy-MM-dd")}', '{datePosted.ToString("yyyy-MM-dd")}', {amountPaid}, '{remarks}', '{stopInterest}', '{username}')"

    '    ' Execute the insert query using ExecuteQuery function
    '    ExecuteQuery(query)

    '    ' After inserting, update the accounting balance based on the soa_number
    '    'Dim updateBalanceQuery As String = $"UPDATE acccounting SET balance = balance - {amountPaid} WHERE soa_number = '{soaNumber}'"
    '    Dim updateBalanceQuery As String = $"UPDATE acccounting SET balance = balance - {amountPaid.ToString("F2")} WHERE soa_number = '{soaNumber}'"

    '    ExecuteQuery(updateBalanceQuery)
    'End Sub
    'Private Sub addButton_Click(sender As Object, e As EventArgs) Handles addButton.Click
    '    Dim selectedRow As DataGridViewRow = dgv1.CurrentRow

    '    ' Retrieve input values
    '    Dim soaNumber As String = soaTxt.Text
    '    Dim enbs As String = enbsTxt.Text
    '    Dim facCode As String = codeTxt.Text
    '    Dim balance As Double = Convert.ToDouble(balanceTxt.Text)
    '    'Dim adsAmount As Double = Convert.ToDouble(adsTxt.Text)
    '    Dim adsAmount As Double = If(selectedRow IsNot Nothing AndAlso Not IsDBNull(selectedRow.Cells("ads_amount").Value), Convert.ToDouble(selectedRow.Cells("ads_amount").Value), 0)
    '    Dim dueDate As Date = dtpicker1.Value
    '    Dim soaAmount As Double = Convert.ToDouble(soamountTxt.Text)
    '    Dim interestDate As Date = dtpicker2.Value
    '    Dim interest As Double = Convert.ToDouble(interestTxt.Text)
    '    Dim orDate As Date = dtpicker3.Value
    '    Dim orNumber As String = orderTxt.Text
    '    Dim badDebts As Double = Convert.ToDouble(baddebtsTxt.Text)
    '    Dim businessTax As Double = Convert.ToDouble(btaxText.Text)
    '    Dim wtax As Double = Convert.ToDouble(wtaxTxt.Text)
    '    Dim others As String = othersTxt.Text
    '    Dim grandTotal As Double = Convert.ToDouble(balanceBox.Text)
    '    Dim mop As String = mopCombo.Text
    '    Dim fop As String = formCombo.Text
    '    Dim chequeDetails As String = chequeTxt.Text
    '    Dim bank As String = bankCombo.Text
    '    Dim datePayment As Date = dtpicker4.Value
    '    Dim datePosted As Date = Date.Now ' Assuming current date for datePosted
    '    Dim amountPaid As Double = Convert.ToDouble(amountpaidTxt.Text)
    '    Dim remarks As String = remTxt.Text
    '    Dim stopInterest As String = If(checkBox1.Checked, "STOP INTEREST", String.Empty)
    '    Dim username As String = Login.userTxt.Text

    '    ' Insert the new record into the database
    '    InsertRecord(soaNumber, enbs, facCode, balance, adsAmount, dueDate, soaAmount, interestDate, interest, orDate, orNumber, badDebts, businessTax, wtax, others, grandTotal, mop, fop, chequeDetails, bank, datePayment, datePosted, amountPaid, remarks, stopInterest, username)

    '    ' Notify user of successful insertion
    '    MessageBox.Show("Payment successfully processed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '    loaddgv()
    '    afterPay()
    '    ClearFields()
    'End Sub
    Private Sub InsertRecord(soaNumber As String, enbs As String, facCode As String, balance As Double, adsAmount As Double, dueDate As Date, soaAmount As Double, interestDate As Date, interest As Double, orDate As Date, orNumber As String, badDebts As Double, businessTax As Double, wtax As Double, others As String, grandTotal As Double, mop As String, fop As String, chequeDetails As String, bank As String, datePayment As Date, datePosted As Date, amountPaid As Double, remarks As String, stopInterest As String, username As String)
        ' Prepare the SQL query for inserting the payment record
        Dim query As String = $"INSERT INTO payments (soa_number, enbs, fac_code, balance, ads_amount, due_date, soa_amount, interest_date, interest, or_date, or_number, bad_debts, business_tax, wtax, others, grand_total, mop, fop, cheque_details, bank, date_payment, date_posted, amount_paid, remarks, stop_interest, username) " &
                          $"VALUES ('{soaNumber}', '{enbs}', '{facCode}', {balance.ToString("F2")}, {adsAmount.ToString("F2")}, '{dueDate.ToString("yyyy-MM-dd")}', {soaAmount.ToString("F2")}, '{interestDate.ToString("yyyy-MM-dd")}', {interest.ToString("F2")}, '{orDate.ToString("yyyy-MM-dd")}', '{orNumber}', {badDebts.ToString("F2")}, {businessTax.ToString("F2")}, {wtax.ToString("F2")}, '{others}', {grandTotal.ToString("F2")}, '{mop}', '{fop}', '{chequeDetails}', '{bank}', '{datePayment.ToString("yyyy-MM-dd")}', '{datePosted.ToString("yyyy-MM-dd")}', {amountPaid.ToString("F2")}, '{remarks}', '{stopInterest}', '{username}')"

        ' Execute the insert query using ExecuteQuery function
        ExecuteQuery(query)

        ' After inserting, update the accounting balance based on the soa_number
        Dim updateBalanceQuery As String = $"UPDATE acccounting SET balance = balance - {amountPaid.ToString("F2")} - {badDebts.ToString("F2")} - {businessTax.ToString("F2")} - {wtax.ToString("F2")} WHERE soa_number = '{soaNumber}'"
        ExecuteQuery(updateBalanceQuery)

        Dim updateGrandTotalQuery As String = $"UPDATE payments SET grand_total = grand_total - {amountPaid.ToString("F2")} - {badDebts.ToString("F2")} - {businessTax.ToString("F2")} - {wtax.ToString("F2")} WHERE soa_number = '{soaNumber}'"
        ExecuteQuery(updateGrandTotalQuery)
    End Sub

    Private Sub addButton_Click(sender As Object, e As EventArgs) Handles addButton.Click
        Dim selectedRow As DataGridViewRow = dgv1.CurrentRow

        ' Retrieve input values
        Dim soaNumber As String = soaTxt.Text
        Dim enbs As String = enbsTxt.Text
        Dim facCode As String = codeTxt.Text
        Dim balance As Double = Convert.ToDouble(balanceperSoa.Text)
        Dim adsAmount As Double = If(selectedRow IsNot Nothing AndAlso Not IsDBNull(selectedRow.Cells("ads_amount").Value), Convert.ToDouble(selectedRow.Cells("ads_amount").Value), 0)
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
        Dim grandTotal As Double = Convert.ToDouble(totalBalance.Text)
        Dim mop As String = mopCombo.Text
        Dim fop As String = formCombo.Text
        Dim chequeDetails As String = chequeTxt.Text
        Dim bank As String = bankCombo.Text
        Dim datePayment As Date = dtpicker4.Value
        Dim datePosted As Date = Date.Now ' Assuming current date for datePosted
        Dim amountPaid As Double = Convert.ToDouble(amountpaidTxt.Text)
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
        ''CalculateAndUpdateInterest()
        'balanceperSoa.Text = amountpaidTxt.Text - baddebtsTxt.Text - wtaxTxt.Text - btaxText.Text

        'totalBalance.Text = amountpaidTxt.Text - baddebtsTxt.Text - wtaxTxt.Text - btaxText.Text
    End Sub

    Private Sub btaxText_TextChanged(sender As Object, e As EventArgs) Handles btaxText.TextChanged
        ''CalculateAndUpdateInterest()
        'balanceperSoa.Text = amountpaidTxt.Text - baddebtsTxt.Text - wtaxTxt.Text - btaxText.Text

        'totalBalance.Text = amountpaidTxt.Text - baddebtsTxt.Text - wtaxTxt.Text - btaxText.Text
    End Sub

    Private Sub GunaControlBox1_Click(sender As Object, e As EventArgs) Handles GunaControlBox1.Click
        Application.Exit()
    End Sub

    Private Sub adsTxt_TextChanged(sender As Object, e As EventArgs) Handles adsTxt.TextChanged

    End Sub

    Private Sub formCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles formCombo.SelectedIndexChanged
        ' Disable the TextBox if the selected item is "Disable"
        If formCombo.SelectedItem IsNot Nothing AndAlso formCombo.SelectedItem.ToString() = "CASH" Then
            chequeTxt.Enabled = False
        Else
            chequeTxt.Enabled = True
        End If
    End Sub

    Private Sub balanceBox_TextChanged(sender As Object, e As EventArgs) Handles totalBalance.TextChanged

    End Sub

    Private Sub amountpaidTxt_TextChanged(sender As Object, e As EventArgs) Handles amountpaidTxt.TextChanged
        'balanceperSoa.Text = amountpaidTxt.Text - baddebtsTxt.Text - wtaxTxt.Text - btaxText.Text

        'totalBalance.Text = amountpaidTxt.Text - baddebtsTxt.Text - wtaxTxt.Text - btaxText.Text
    End Sub

    Private Sub TextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles totalBalance.KeyDown, balanceperSoa.KeyDown, baddebtsTxt.KeyDown, btaxText.KeyDown, wtaxTxt.KeyDown, amountpaidTxt.KeyDown
        ' Check if the Enter key was pressed
        If e.KeyCode = Keys.Enter Then
            ' Declare variables for the values in the textboxes
            Dim totalBalanceValue As Decimal
            Dim balancePerSoaValue As Decimal
            Dim badDebtsValue As Decimal
            Dim btaxValue As Decimal
            Dim wtaxValue As Decimal
            Dim amountPaidValue As Decimal

            ' Try to parse the values from the textboxes
            If Decimal.TryParse(totalBalance.Text, totalBalanceValue) AndAlso Decimal.TryParse(balanceperSoa.Text, balancePerSoaValue) _
           AndAlso Decimal.TryParse(baddebtsTxt.Text, badDebtsValue) AndAlso Decimal.TryParse(btaxText.Text, btaxValue) _
           AndAlso Decimal.TryParse(wtaxTxt.Text, wtaxValue) AndAlso Decimal.TryParse(amountpaidTxt.Text, amountPaidValue) Then

                ' Subtract the values from totalBalance and balanceperSoa
                Dim result1 As Decimal = totalBalanceValue - badDebtsValue - btaxValue - wtaxValue - amountPaidValue
                Dim result2 As Decimal = balancePerSoaValue - badDebtsValue - btaxValue - wtaxValue - amountPaidValue

                ' Update totalBalance and balanceperSoa with the new calculated values
                totalBalance.Text = result1.ToString()
                balanceperSoa.Text = result2.ToString()

            Else
                ' If any value is invalid, clear the result textboxes (but don't clear totalBalance and balanceperSoa)
                ' Optionally, you can handle invalid values differently (e.g., show a message to the user)
            End If
        End If
    End Sub

    ' Optionally, handle when the user clears the textboxes (but do not clear totalBalance or balanceperSoa)
    Private Sub TextBox_Leave(sender As Object, e As EventArgs) Handles totalBalance.Leave, balanceperSoa.Leave, baddebtsTxt.Leave, btaxText.Leave, wtaxTxt.Leave, amountpaidTxt.Leave
        ' If any of the input fields are cleared (except totalBalance and balanceperSoa), revert totalBalance and balanceperSoa to original values
        If String.IsNullOrEmpty(baddebtsTxt.Text) OrElse String.IsNullOrEmpty(btaxText.Text) _
       OrElse String.IsNullOrEmpty(wtaxTxt.Text) OrElse String.IsNullOrEmpty(amountpaidTxt.Text) Then
            ' Optionally, you can revert totalBalance and balanceperSoa to some default or original values
            ' For example, setting the values back to what they were initially, or keeping them as is
        End If
    End Sub

    'Private Sub CalculateAndUpdateInterest()
    '    Try
    '        ' Open the connection if it's not already open
    '        If conn.State <> ConnectionState.Open Then
    '            conn.Open()
    '        End If

    '        ' Updated query to join acccounting and facility_data tables
    '        Dim query As String = "SELECT a.sub_total, a.due_date, f.type2 FROM acccounting a INNER JOIN facility_data f ON a.fac_code = f.fac_code WHERE a.fac_code = ?"

    '        Using cmd As New OdbcCommand(query, conn)
    '            cmd.Parameters.AddWithValue("fac_code", codeTxt.Text)

    '            Using rd As OdbcDataReader = cmd.ExecuteReader()
    '                If rd.Read() Then
    '                    ' Ensure the UI update is done on the main thread
    '                    If Me.IsHandleCreated Then
    '                        Me.Invoke(Sub()
    '                                      Dim principal As Double = Convert.ToDouble(rd("sub_total"))
    '                                      Dim dueDate As Date = Convert.ToDateTime(rd("due_date"))
    '                                      Dim dateOfPayment As Date = dtpicker4.Value
    '                                      Dim type2 As String = rd("type2").ToString()

    '                                      ' Check if due date is within the specified range
    '                                      Dim startDate As Date = New Date(2020, 8, 11)
    '                                      Dim endDate As Date = New Date(2023, 11, 1)
    '                                      Dim totalDays As Integer = (dateOfPayment - dueDate).Days
    '                                      Dim percentage As Double = 0.02
    '                                      Dim days As Integer = 30
    '                                      Dim interest As Double = 0

    '                                      If dueDate >= startDate And dueDate <= endDate Then
    '                                          Dim term As Integer
    '                                          Select Case type2
    '                                              Case "GOVERNMENT", "LGU"
    '                                                  term = 30
    '                                              Case "PRIVATE"
    '                                                  term = 15
    '                                              Case Else
    '                                                  term = 0 ' default term value if type2 is not matched
    '                                          End Select

    '                                          interest = (principal * percentage) * (totalDays / days)
    '                                      End If

    '                                      ' Ensure interest is non-negative
    '                                      If interest < 0 Then
    '                                          interest = 0
    '                                      End If

    '                                      interestTxt.Text = interest.ToString("F2")

    '                                  End Sub)
    '                    End If
    '                End If
    '            End Using
    '        End Using
    '    Catch ex As Exception
    '        MessageBox.Show("An error occurred: " & ex.Message)
    '    End Try
    'End Sub
    Private Sub CalculateAndUpdateInterest()
        Try
            ' Open the connection if it's not already open
            If conn.State <> ConnectionState.Open Then
                conn.Open()
            End If

            ' Updated query to join accounting and facility_data tables
            Dim query As String = "SELECT a.sub_total, a.due_date, f.type2 FROM acccounting a " &
                              "INNER JOIN facility_data f ON a.fac_code = f.fac_code " &
                              "WHERE a.fac_code = ?"

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

                                          ' Debugging information
                                          Debug.WriteLine($"Principal: {principal}, Due Date: {dueDate}, " &
                                                      $"Date of Payment: {dateOfPayment}, Type: {type2}")

                                          ' Check if the due date is valid for interest calculation
                                          Dim startDate As Date = New Date(2020, 8, 11)
                                          Dim endDate As Date = New Date(2023, 11, 1)
                                          Dim totalDays As Integer = (dateOfPayment - dueDate).Days
                                          Dim interest As Double = 0

                                          If totalDays > 0 Then
                                              ' Determine the term based on type2
                                              Dim term As Integer
                                              Select Case type2.ToUpper()
                                                  Case "GOVERNMENT", "LGU"
                                                      term = 30
                                                  Case "PRIVATE"
                                                      term = 15
                                                  Case Else
                                                      term = 0 ' Default term for unexpected types
                                              End Select

                                              ' Debugging: Output term and days late
                                              Debug.WriteLine($"Term: {term}, Total Days Late: {totalDays}")

                                              ' Calculate interest if overdue beyond the term
                                              If totalDays > term Then
                                                  Dim percentage As Double = 0.02
                                                  Dim days As Integer = 30
                                                  interest = (principal * percentage) * (totalDays / CDbl(days))
                                              End If
                                          End If

                                          ' Ensure interest is non-negative
                                          If interest < 0 Then
                                              interest = 0
                                          End If

                                          ' Debugging: Output calculated interest
                                          Debug.WriteLine($"Calculated Interest: {interest}")

                                          ' Update the interest text box
                                          interestTxt.Text = interest.ToString("F2")
                                      End Sub)
                        End If
                    Else
                        'MessageBox.Show("No record found for the provided facility code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub dtpicker4_ValueChanged(sender As Object, e As EventArgs) Handles dtpicker4.ValueChanged
        CalculateAndUpdateInterest()
    End Sub

    Private Sub total()
        Dim originalBalance As Double
        Dim remainingBalance As Double

        ' Validate and parse the original balance from balanceBox
        If Not Double.TryParse(totalBalance.Text, originalBalance) Then
            MessageBox.Show("Please enter a valid original balance.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Initialize the remaining balance to the original balance only at the start
        If remainingBalance = 0 OrElse String.IsNullOrEmpty(totalBalance.Text) Then
            remainingBalance = originalBalance
        End If

        ' Validate and parse the amountPaid input, if provided
        Dim amountPaid As Double
        If Double.TryParse(amountpaidTxt.Text, amountPaid) Then
            remainingBalance -= amountPaid
        End If

        ' Validate and parse the badDebts input, if provided
        Dim badDebts As Double
        If Double.TryParse(baddebtsTxt.Text, badDebts) Then
            remainingBalance -= badDebts
        End If

        ' Validate and parse the btax input, if provided
        Dim btax As Double
        If Double.TryParse(btaxText.Text, btax) Then
            remainingBalance -= btax
        End If

        ' Validate and parse the wtax input, if provided
        Dim wtax As Double
        If Double.TryParse(wtaxTxt.Text, wtax) Then
            remainingBalance -= wtax
        End If

        ' Ensure the remaining balance doesn't go negative
        remainingBalance = Math.Max(0, remainingBalance)

        ' Update only the balanceTxt to reflect the current remaining balance
        totalBalance.Text = remainingBalance.ToString("F2")
        ' Do not modify the balanceBox since it represents the original balance
    End Sub

    Private Sub computeBtn_Click(sender As Object, e As EventArgs) Handles computeBtn.Click
        ' Validate and parse the original balance from balancePerSoa
        If Not Double.TryParse(balanceperSoa.Text, originalBalance) Then
            MessageBox.Show("Please enter a valid original balance.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Reset the remaining balance to the original balance each time the button is clicked
        remainingBalance = originalBalance

        ' Validate and parse the amountPaid input, if provided
        Dim amountPaid As Double
        If Double.TryParse(amountpaidTxt.Text, amountPaid) Then
            remainingBalance -= amountPaid
        End If

        ' Validate and parse the badDebts input, if provided
        Dim badDebts As Double
        If Double.TryParse(baddebtsTxt.Text, badDebts) Then
            remainingBalance -= badDebts
        End If

        ' Validate and parse the btax input, if provided
        Dim btax As Double
        If Double.TryParse(btaxText.Text, btax) Then
            remainingBalance -= btax
        End If

        ' Validate and parse the wtax input, if provided
        Dim wtax As Double
        If Double.TryParse(wtaxTxt.Text, wtax) Then
            remainingBalance -= wtax
        End If

        ' Ensure the remaining balance doesn't go negative
        remainingBalance = Math.Max(0, remainingBalance)

        ' Update the balanceperSoa to reflect the current remaining balance
        balanceperSoa.Text = remainingBalance.ToString("F2")
    End Sub

    Private Sub wtaxTxt_TextChanged(sender As Object, e As EventArgs) Handles wtaxTxt.TextChanged
        'balanceperSoa.Text = amountpaidTxt.Text - baddebtsTxt.Text - wtaxTxt.Text - btaxText.Text

        'totalBalance.Text = amountpaidTxt.Text - baddebtsTxt.Text - wtaxTxt.Text - btaxText.Text
    End Sub
End Class

'Private Sub CalculateAndUpdateInterest()
'    Try
'        ' Open the connection if it's not already open
'        If conn.State <> ConnectionState.Open Then
'            conn.Open()
'        End If

'        ' Updated query to join acccounting and facility_data tables
'        Dim query As String = "SELECT a.sub_total, a.due_date, f.type2 FROM acccounting a INNER JOIN facility_data f ON a.fac_code = f.fac_code WHERE a.fac_code = ?"

'        Using cmd As New OdbcCommand(query, conn)
'            cmd.Parameters.AddWithValue("fac_code", codeTxt.Text)

'            Using rd As OdbcDataReader = cmd.ExecuteReader()
'                If rd.Read() Then
'                    ' Ensure the UI update is done on the main thread
'                    If Me.IsHandleCreated Then
'                        Me.Invoke(Sub()
'                                      Dim principal As Double = Convert.ToDouble(rd("sub_total"))
'                                      Dim dueDate As Date = Convert.ToDateTime(rd("due_date"))
'                                      Dim dateOfPayment As Date = dtpicker4.Value
'                                      Dim type2 As String = rd("type2").ToString()

'                                      ' Check if due date is within the specified range
'                                      Dim startDate As Date = New Date(2020, 8, 11)
'                                      Dim endDate As Date = New Date(2023, 11, 1)
'                                      Dim totalDays As Integer = (dateOfPayment - dueDate).Days
'                                      Dim percentage As Double = 0.02
'                                      Dim days As Integer = 30
'                                      Dim interest As Double = 0

'                                      If dueDate >= startDate And dueDate <= endDate Then
'                                          Dim term As Integer
'                                          Select Case type2
'                                              Case "GOVERNMENT", "LGU"
'                                                  term = 30
'                                              Case "PRIVATE"
'                                                  term = 15
'                                              Case Else
'                                                  term = 0 ' default term value if type2 is not matched
'                                          End Select

'                                          interest = (principal * percentage) * (totalDays / days)
'                                      End If

'                                      ' Ensure interest is non-negative
'                                      If interest < 0 Then
'                                          interest = 0
'                                      End If

'                                      interestTxt.Text = interest.ToString("F2")
'                                      ' Update balance and subtotal
'                                      Dim soAmount As Double = 0
'                                      Dim adsAmount As Double = 0
'                                      Dim badDebts As Double = 0
'                                      Dim businessTax As Double = 0

'                                      ' Parse or set default if empty
'                                      Double.TryParse(If(String.IsNullOrWhiteSpace(soamountTxt.Text), "0", soamountTxt.Text), soAmount)
'                                      Double.TryParse(If(String.IsNullOrWhiteSpace(adsTxt.Text), "0", adsTxt.Text), adsAmount)
'                                      Double.TryParse(If(String.IsNullOrWhiteSpace(baddebtsTxt.Text), "0", baddebtsTxt.Text), badDebts)
'                                      Double.TryParse(If(String.IsNullOrWhiteSpace(btaxText.Text), "0", btaxText.Text), businessTax)

'                                      Dim balance As Double = (soAmount + interest + adsAmount) - (badDebts + businessTax)
'                                      balanceTxt.Text = balance.ToString("F2")

'                                  End Sub)
'                    End If
'                End If
'            End Using
'        End Using
'    Catch ex As Exception
'        MessageBox.Show("An error occurred: " & ex.Message)
'    End Try
'End Sub
