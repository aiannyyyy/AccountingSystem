Imports System.Data.Odbc
Public Class Payments
    Private connString As String = "DSN=dashboard"
    ' Declare class-level variables to store the initial balance
    Private originalBalance As Double
    Private remainingBalance As Double

    ' Variable to store the last value of codeTxt.Text
    Private lastCodeTxtValue As String = String.Empty
    Private Sub Payments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Oracon.ConnectionString = "Data Source=(DESCRIPTION= (ADDRESS=(PROTOCOL=TCP)(HOST=10.1.1.191)(PORT=1521)) (CONNECT_DATA=(SERVICE_NAME=PROD)));User Id=user1;Password=newborn"

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

        For Each column As DataGridViewColumn In dgv2.Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next

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
            interestTxt.Clear()
            payments()
            ClearFields()
            Return
        End If

        Try
            ' Open the Oracle connection if not already open
            If Oracon.State <> ConnectionState.Open Then
                Oracon.Open()
            End If

            ' Correct the query to join the tables properly and use parameterized query
            'Dim query As String = "SELECT fac_code, fac_name, type2 FROM facility_data WHERE fac_code = ?"

            ' Define the query to fetch provider information
            Dim oracleQuery As String = "
        SELECT 
            REF_PROVIDER_ADDRESS.PROVIDERID, 
            REF_PROVIDER_ADDRESS.CITY, 
            REF_PROVIDER_ADDRESS.COUNTY, 
            REF_PROVIDER_ADDRESS.DESCR1, 
            REF_TYPE.DESCR
        FROM 
            PHMSDS.REF_PROVIDER_ADDRESS 
        INNER JOIN 
            PHMSDS.REF_PROVIDERTYPE 
            ON REF_PROVIDER_ADDRESS.PROVIDERID = REF_PROVIDERTYPE.PROVIDERID
        INNER JOIN 
            PHMSDS.REF_TYPE 
            ON REF_PROVIDERTYPE.TYPE = REF_TYPE.TYPE
        WHERE 
            REF_PROVIDER_ADDRESS.PROVIDERID = :PROVIDERID
        ORDER BY 
            REF_PROVIDER_ADDRESS.PROVIDERID ASC"

            Using cmd As New OracleCommand(oracleQuery, Oracon)
                ' Bind the parameter securely
                cmd.Parameters.Add(New OracleParameter("PROVIDERID", codeTxt.Text.Trim()))
                'cmd.Parameters.AddWithValue("PROVIDERID", codeTxt.Text)
                ' Execute the query and process the results
                Using reader As OracleDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        ' Extract and validate data from the reader
                        Dim providerId As String = If(Not reader.IsDBNull(0), reader("PROVIDERID").ToString(), String.Empty)
                        Dim city As String = If(Not reader.IsDBNull(1), reader("CITY").ToString(), String.Empty).ToUpper()
                        Dim county As String = If(Not reader.IsDBNull(2), reader("COUNTY").ToString(), String.Empty)
                        Dim descr1 As String = If(Not reader.IsDBNull(3), reader("DESCR1").ToString(), String.Empty)
                        Dim descr As String = If(Not reader.IsDBNull(4), reader("DESCR").ToString(), String.Empty)

                        ' Determine the term based on descr
                        Dim term As Integer = If(
                        {"LYING-IN GOV'T", "LGU", "RHU", "DOH", "CITY HEALTH UNIT", "OTHERS"}.Contains(descr),
                        60,
                        45
                    )

                        ' Calculate the due date based on the term
                        Dim purchaseDate As Date = Date.Today ' Replace with actual purchase date if available
                        Dim dueDate As Date = purchaseDate.AddDays(term)

                        If providerId = "7345" Then
                            mopCombo.SelectedItem = "WALK IN"
                        Else
                            mopCombo.SelectedIndex = -1
                        End If

                        ' Update the UI on the main thread
                        Me.Invoke(Sub()
                                      codeTxt.Text = providerId
                                      nameBox.Text = descr1
                                      termBox.Text = term.ToString()
                                      dtpicker1.Value = dueDate
                                      interestTxt.Text = "0.00"
                                      baddebtsTxt.Text = "0.00"
                                      btaxText.Text = "0.00"
                                      wtaxTxt.Text = "0.00"

                                  End Sub)
                    Else
                        ' No matching record found
                        Me.Invoke(Sub()
                                      nameBox.Clear()
                                      termBox.Clear()
                                      dtpicker1.Value = Date.Now
                                      interestTxt.Clear()
                                      baddebtsTxt.Clear()
                                      btaxText.Clear()
                                      wtaxTxt.Clear()
                                  End Sub)
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
        stopInterestCheck.Checked = False
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

    'Private Sub dgv1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv1.CellContentClick
    '    If e.RowIndex >= 0 AndAlso e.RowIndex < dgv1.Rows.Count Then
    '        ' Populate other text fields from the clicked row
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
    '            balanceperSoa.Text = cellValue.ToString("F2")
    '        Else
    '            balanceperSoa.Text = "0.00"
    '        End If

    '        soamountTxt.Text = dgv1.Rows(e.RowIndex).Cells(10).Value.ToString()

    '        ' Recalculate interest and update related fields
    '        CalculateAndUpdateInterest()

    '        ' Refresh the balance whenever the row is clicked
    '        RefreshBalance(e.RowIndex)
    '    End If
    'End Sub
    Private Sub dgv1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv1.CellContentClick
        'If e.RowIndex >= 0 AndAlso e.RowIndex < dgv1.Rows.Count Then

        '    nameBox.Text = dgv1.Rows(e.RowIndex).Cells(5).Value.ToString()
        '    termBox.Text = dgv1.Rows(e.RowIndex).Cells(6).Value.ToString()

        '    totalBalance.Text = dgv1.Rows(e.RowIndex).Cells(18).Value.ToString()
        '    ' Populate other text fields from the clicked row
        '    soaTxt.Text = dgv1.Rows(e.RowIndex).Cells(0).Value.ToString()
        '    enbsTxt.Text = dgv1.Rows(e.RowIndex).Cells(9).Value.ToString()
        '    adsTxt.Text = dgv1.Rows(e.RowIndex).Cells(15).Value.ToString()

        '    ' Safely parse the date
        '    Dim dateValue As DateTime
        '    If DateTime.TryParse(dgv1.Rows(e.RowIndex).Cells(16).Value.ToString(), dateValue) Then
        '        dtpicker1.Value = dateValue
        '    Else
        '        dtpicker1.Value = DateTime.Now ' Default to current date if parsing fails
        '    End If



        '    ' Parse and format the balance (balanceTxt)
        '    Dim cellValue As Double
        '    If Double.TryParse(dgv1.Rows(e.RowIndex).Cells("balance").Value.ToString(), cellValue) Then
        '        balanceperSoa.Text = cellValue.ToString("F2")
        '    Else
        '        balanceperSoa.Text = "0.00"
        '    End If

        '    soamountTxt.Text = dgv1.Rows(e.RowIndex).Cells(10).Value.ToString()

        '    interestTxt.Text = "0.00"
        '    baddebtsTxt.Text = "0.00"
        '    btaxText.Text = "0.00"
        '    wtaxTxt.Text = "0.00"

        '    ' Recalculate interest and update related fields
        '    'CalculateAndUpdateInterest()

        '    ' Refresh the balance whenever the row is clicked
        '    RefreshBalance(e.RowIndex)

        '    ' Update balanceperSoa to include interest
        '    UpdateBalanceWithInterest(cellValue) ' Call the function to add the interest
        'End If
        If e.RowIndex >= 0 AndAlso e.RowIndex < dgv1.Rows.Count Then
            ' Populate fields from the clicked row
            nameBox.Text = dgv1.Rows(e.RowIndex).Cells(5).Value.ToString()
            termBox.Text = dgv1.Rows(e.RowIndex).Cells(6).Value.ToString()
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

            ' Get the balance of the selected row
            Dim cellValue As Double
            If Double.TryParse(dgv1.Rows(e.RowIndex).Cells("balance").Value.ToString(), cellValue) Then
                balanceperSoa.Text = cellValue.ToString("F2")
            Else
                balanceperSoa.Text = "0.00"
            End If

            If dgv1.Rows(e.RowIndex).Cells("facility_code").Value.ToString() = "7345" Then
                mopCombo.SelectedItem = "WALK IN"
            Else
                mopCombo.SelectedIndex = -1
            End If

            soamountTxt.Text = dgv1.Rows(e.RowIndex).Cells(10).Value.ToString()
            interestTxt.Text = "0.00"
            baddebtsTxt.Text = "0.00"
            btaxText.Text = "0.00"
            wtaxTxt.Text = "0.00"

            ' Get the facility code from the clicked row
            Dim selectedFacilityCode As String = dgv1.Rows(e.RowIndex).Cells("facility_code").Value.ToString()

            ' Compute total balance for this facility
            totalBalance.Text = ComputeTotalBalance(selectedFacilityCode).ToString("F2")

            ' Refresh the balance
            RefreshBalance(e.RowIndex)

            ' Update balanceperSoa to include interest
            UpdateBalanceWithInterest(cellValue)
        End If
    End Sub

    Private Function ComputeTotalBalance(facilityCode As String) As Double
        Dim total As Double = 0.0

        For Each row As DataGridViewRow In dgv1.Rows
            ' Ensure the row is not a new row (avoid empty rows)
            If Not row.IsNewRow AndAlso row.Cells("facility_code").Value.ToString() = facilityCode Then
                Dim balance As Double
                If Double.TryParse(row.Cells("balance").Value.ToString(), balance) Then
                    total += balance
                End If
            End If
        Next

        Return total
    End Function

    Private Sub UpdateBalanceWithInterest(balance As Double)
        'Dim interest As Double
        '' Attempt to parse the interest value from the interestTxt text box
        'If Double.TryParse(interestTxt.Text, interest) Then
        '    ' Add interest to the balance and update the display
        '    balanceperSoa.Text = (balance + interest).ToString("F2")
        'Else
        '    ' If interest is not a valid number, just display the balance
        '    balanceperSoa.Text = balance.ToString("F2")
        'End If

        Dim interest As Double

        ' Store the original balance only if it's not set
        If originalBalance = 0 Then
            originalBalance = balance
        End If

        ' Attempt to parse the interest value from the interestTxt text box
        If Double.TryParse(interestTxt.Text, interest) Then
            ' Add interest to the balance and update the display
            balanceperSoa.Text = (balance + interest).ToString("F2")
        Else
            ' If interest is not a valid number, just display the balance
            balanceperSoa.Text = balance.ToString("F2")
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
    'Private Sub InsertRecord(soaNumber As String, enbs As String, facCode As String, balance As Double, adsAmount As Double, dueDate As Date, soaAmount As Double, interestDate As Date, interest As Double, orDate As Date, orNumber As String, badDebts As Double, businessTax As Double, wtax As Double, others As String, grandTotal As Double, mop As String, fop As String, chequeDetails As String, bank As String, datePayment As Date, datePosted As Date, amountPaid As Double, remarks As String, stopInterest As String, username As String)
    '    ' Prepare the SQL query for inserting the payment record
    '    Dim query As String = $"INSERT INTO payments (soa_number, enbs, fac_code, balance, ads_amount, due_date, soa_amount, interest_date, interest, or_date, or_number, bad_debts, business_tax, wtax, others, grand_total, mop, fop, cheque_details, bank, date_payment, date_posted, amount_paid, remarks, stop_interest, username) " &
    '                      $"VALUES ('{soaNumber}', '{enbs}', '{facCode}', {balance.ToString("F2")}, {adsAmount.ToString("F2")}, '{dueDate.ToString("yyyy-MM-dd")}', {soaAmount.ToString("F2")}, '{interestDate.ToString("yyyy-MM-dd")}', {interest.ToString("F2")}, '{orDate.ToString("yyyy-MM-dd")}', '{orNumber}', {badDebts.ToString("F2")}, {businessTax.ToString("F2")}, {wtax.ToString("F2")}, '{others}', {grandTotal.ToString("F2")}, '{mop}', '{fop}', '{chequeDetails}', '{bank}', '{datePayment.ToString("yyyy-MM-dd")}', '{datePosted.ToString("yyyy-MM-dd")}', {amountPaid.ToString("F2")}, '{remarks}', '{stopInterest}', '{username}')"

    '    ' Execute the insert query using ExecuteQuery function
    '    ExecuteQuery(query)

    '    ' After inserting, update the accounting balance based on the soa_number
    '    Dim updateBalanceQuery As String = $"UPDATE acccounting SET balance = balance - {amountPaid.ToString("F2")} - {badDebts.ToString("F2")} - {businessTax.ToString("F2")} - {wtax.ToString("F2")} WHERE soa_number = '{soaNumber}'"
    '    ExecuteQuery(updateBalanceQuery)

    '    Dim updateGrandTotalQuery As String = $"UPDATE payments SET grand_total = grand_total - {amountPaid.ToString("F2")} - {badDebts.ToString("F2")} - {businessTax.ToString("F2")} - {wtax.ToString("F2")} WHERE soa_number = '{soaNumber}'"
    '    ExecuteQuery(updateGrandTotalQuery)
    'End Sub

    'Private Sub InsertRecord(soaNumber As String, enbs As String, facCode As String, balance As Double, adsAmount As Double, dueDate As Date, soaAmount As Double, interestDate As Date, interest As Double, paid_interest As Double, orDate As Date, orNumber As String, badDebts As Double, businessTax As Double, wtax As Double, others As String, grandTotal As Double, mop As String, fop As String, chequeDetails As String, bank As String, datePayment As Date, datePosted As Date, amountPaid As Double, remarks As String, stopInterest As String, username As String)
    '    ' Prepare the SQL query for inserting the payment record
    '    Dim query As String = $"INSERT INTO payments (soa_number, enbs, fac_code, balance, ads_amount, due_date, soa_amount, interest_date, interest, paid_interest, or_date, or_number, bad_debts, business_tax, wtax, others, grand_total, mop, fop, cheque_details, bank, date_payment, date_posted, amount_paid, remarks, stop_interest, username) " &
    '                      $"VALUES ('{soaNumber}', '{enbs}', '{facCode}', {balance.ToString("F2")}, {adsAmount.ToString("F2")}, '{dueDate.ToString("yyyy-MM-dd")}', {soaAmount.ToString("F2")}, '{interestDate.ToString("yyyy-MM-dd")}', {interest.ToString("F2")}, {paid_interest.ToString("F2")}, '{orDate.ToString("yyyy-MM-dd")}', '{orNumber}', {badDebts.ToString("F2")}, {businessTax.ToString("F2")}, {wtax.ToString("F2")}, '{others}', {grandTotal.ToString("F2")}, '{mop}', '{fop}', '{chequeDetails}', '{bank}', '{datePayment.ToString("yyyy-MM-dd")}', '{datePosted.ToString("yyyy-MM-dd")}', {amountPaid.ToString("F2")}, '{remarks}', '{stopInterest}', '{username}')"

    '    ' Execute the insert query using ExecuteQuery function
    '    ExecuteQuery(query)

    '    ' After inserting, calculate the remaining amount after paying interest for balance update
    '    Dim remainingAmount As Double = amountPaid - interest

    '    ' Update the accounting balance based on the soa_number
    '    Dim updateBalanceQuery As String = $"UPDATE acccounting SET balance = balance - {remainingAmount.ToString("F2")} - {badDebts.ToString("F2")} - {businessTax.ToString("F2")} - {wtax.ToString("F2")} WHERE soa_number = '{soaNumber}'"
    '    ExecuteQuery(updateBalanceQuery)

    '    ' Update the grand total in the payments table after the payment
    '    ' Only deduct amount paid and other applicable fees (not the remaining amount after interest)
    '    Dim updateGrandTotalQuery As String = $"UPDATE payments SET grand_total = grand_total - {amountPaid.ToString("F2")} - {badDebts.ToString("F2")} - {businessTax.ToString("F2")} - {wtax.ToString("F2")} WHERE soa_number = '{soaNumber}'"
    '    ExecuteQuery(updateGrandTotalQuery)

    '    ' Update the interest to 0 after the payment
    '    Dim updateInterestQuery As String = $"UPDATE payments SET interest = 0 WHERE soa_number = '{soaNumber}'"
    '    ExecuteQuery(updateInterestQuery)
    'End Sub
    Private Sub InsertRecord(soaNumber As String, enbs As String, facCode As String, balance As Double, adsAmount As Double, dueDate As Date, soaAmount As Double, interestDate As Date, interest As Double, paid_interest As Double, orDate As Date, orNumber As String, badDebts As Double, businessTax As Double, wtax As Double, others As String, grandTotal As Double, mop As String, fop As String, chequeDetails As String, bank As String, datePayment As Date, datePosted As Date, amountPaid As Double, remarks As String, username As String)
        ' Prepare the SQL query for inserting the payment record
        'Dim query As String = $"INSERT INTO payments (soa_number, enbs, fac_code, balance, ads_amount, due_date, soa_amount, interest_date, interest, paid_interest, or_date, or_number, bad_debts, business_tax, wtax, others, grand_total, mop, fop, cheque_details, bank, date_payment, date_posted, amount_paid, remarks, stop_interest, username) " &
        '              $"VALUES ('{soaNumber}', '{enbs}', '{facCode}', {balance.ToString("F2")}, {adsAmount.ToString("F2")}, '{dueDate.ToString("yyyy-MM-dd")}', {soaAmount.ToString("F2")}, '{interestDate.ToString("yyyy-MM-dd")}', {interest.ToString("F2")}, 0.00, '{orDate.ToString("yyyy-MM-dd")}', '{orNumber}', {badDebts.ToString("F2")}, {businessTax.ToString("F2")}, {wtax.ToString("F2")}, '{others}', {grandTotal.ToString("F2")}, '{mop}', '{fop}', '{chequeDetails}', '{bank}', '{datePayment.ToString("yyyy-MM-dd")}', '{datePosted.ToString("yyyy-MM-dd")}', {amountPaid.ToString("F2")}, '{remarks}', '{stopInterest}', '{username}')"

        Dim query As String = $"INSERT INTO payments (soa_number, enbs, fac_code, balance, ads_amount, due_date, soa_amount, interest_date, interest, paid_interest, or_date, or_number, bad_debts, business_tax, wtax, others, grand_total, mop, fop, cheque_details, bank, date_payment, date_posted, amount_paid, remarks, username) " &
                  $"VALUES ('{soaNumber}', '{enbs}', '{facCode}', {balance.ToString("F2")}, {adsAmount.ToString("F2")}, '{dueDate.ToString("yyyy-MM-dd HH:mm:ss")}', {soaAmount.ToString("F2")}, '{interestDate.ToString("yyyy-MM-dd HH:mm:ss")}', {interest.ToString("F2")}, 0.00, '{orDate.ToString("yyyy-MM-dd HH:mm:ss")}', '{orNumber}', {badDebts.ToString("F2")}, {businessTax.ToString("F2")}, {wtax.ToString("F2")}, '{others}', {grandTotal.ToString("F2")}, '{mop}', '{fop}', '{chequeDetails}', '{bank}', '{datePayment.ToString("yyyy-MM-dd HH:mm:ss")}', '{datePosted.ToString("yyyy-MM-dd HH:mm:ss")}', {amountPaid.ToString("F2")}, '{remarks}', '{username}')"


        ' Execute the insert query using ExecuteQuery function
        ExecuteQuery(query)

        ' Update the paid_interest with the current interest value and set interest to 0
        Dim updateInterestPaidQuery As String = $"UPDATE payments SET paid_interest = interest, interest = 0.00 WHERE soa_number = '{soaNumber}'"
        ExecuteQuery(updateInterestPaidQuery)

        ' Calculate the remaining amount after paying interest for balance update
        Dim remainingAmount As Double = amountPaid - interest

        ' Update the accounting balance based on the soa_number
        Dim updateBalanceQuery As String = $"UPDATE acccounting SET balance = balance - {remainingAmount.ToString("F2")} - {badDebts.ToString("F2")} - {businessTax.ToString("F2")} - {wtax.ToString("F2")} WHERE soa_number = '{soaNumber}'"
        ExecuteQuery(updateBalanceQuery)

        ' Update the grand total in the payments table after the payment
        Dim updateGrandTotalQuery As String = $"UPDATE payments SET grand_total = grand_total - {amountPaid.ToString("F2")} - {badDebts.ToString("F2")} - {businessTax.ToString("F2")} - {wtax.ToString("F2")} WHERE soa_number = '{soaNumber}'"
        ExecuteQuery(updateGrandTotalQuery)
    End Sub

    Private Sub addButton_Click(sender As Object, e As EventArgs) Handles addButton.Click
        '' Ask for confirmation before inserting the record
        'Dim result As DialogResult = MessageBox.Show("Are you sure you want to process the payment?", "Confirm Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        'If result = DialogResult.Yes Then
        '    ' Proceed with record insertion if Yes is clicked
        '    Dim selectedRow As DataGridViewRow = dgv1.CurrentRow

        '    ' Retrieve input values
        '    Dim soaNumber As String = soaTxt.Text
        '    Dim enbs As String = enbsTxt.Text
        '    Dim facCode As String = codeTxt.Text

        '    ' Get previous balance from DataGridView
        '    Dim previousBalance As Double = If(selectedRow IsNot Nothing AndAlso Not IsDBNull(selectedRow.Cells("balance").Value), Convert.ToDouble(selectedRow.Cells("balance").Value), 0)

        '    ' Get amount paid and deductions
        '    Dim amountPaid As Double = Convert.ToDouble(amountpaidTxt.Text)
        '    Dim wtax As Double = Convert.ToDouble(wtaxTxt.Text)
        '    Dim badDebts As Double = Convert.ToDouble(baddebtsTxt.Text)
        '    Dim interest As Double = If(Double.TryParse(interestTxt.Text, interest), interest, 0.0)
        '    Dim businessTax As Double = Convert.ToDouble(btaxText.Text)

        '    ' Compute new balance
        '    Dim balance As Double = previousBalance - amountPaid - wtax - badDebts - interest - businessTax

        '    ' Ensure balance does not go below zero
        '    If balance < 0 Then
        '        balance = 0
        '    End If

        '    ' Other required values
        '    Dim adsAmount As Double = If(selectedRow IsNot Nothing AndAlso Not IsDBNull(selectedRow.Cells("ads_amount").Value), Convert.ToDouble(selectedRow.Cells("ads_amount").Value), 0)
        '    Dim dueDate As Date = dtpicker1.Value
        '    Dim soaAmount As Double = Convert.ToDouble(soamountTxt.Text)
        '    Dim interestDate As Date = dtpicker2.Value
        '    Dim paid_interest As Double
        '    Dim orDate As Date = dtpicker3.Value
        '    Dim orNumber As String = orderTxt.Text
        '    Dim others As String = othersTxt.Text
        '    Dim grandTotal As Double = Convert.ToDouble(totalBalance.Text)
        '    Dim mop As String = mopCombo.Text
        '    Dim fop As String = formCombo.Text
        '    Dim chequeDetails As String = chequeTxt.Text
        '    Dim bank As String = bankCombo.Text
        '    Dim datePayment As Date = dtpicker4.Value
        '    Dim datePosted As Date = Date.Now ' Assuming current date for datePosted
        '    Dim remarks As String = remTxt.Text
        '    Dim stopInterest As String = If(Me.stopInterestCheck.Checked, "STOP INTEREST", String.Empty)
        '    Dim username As String = Login.userTxt.Text

        '    'If Not stopInterestCheck.Checked Then
        '    '    CalculateAndUpdateInterest()
        '    'End If

        '    ' Insert the new record into the database
        '    InsertRecord(soaNumber, enbs, facCode, balance, adsAmount, dueDate, soaAmount, interestDate, interest, paid_interest, orDate, orNumber, badDebts, businessTax, wtax, others, grandTotal, mop, fop, chequeDetails, bank, datePayment, datePosted, amountPaid, remarks, stopInterest, username)

        '    ' Notify user of successful insertion
        '    MessageBox.Show("Payment successfully processed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        '    ' Refresh data and clear fields
        '    loaddgv()
        '    afterPay()
        '    ClearFields()
        'Else
        '    ' If No is clicked, do nothing (keep fields unchanged)
        '    MessageBox.Show("Payment processing canceled.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If
        ' Ask for confirmation before inserting the record
        Dim result As DialogResult = MessageBox.Show("Are all entries correct?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            ' Proceed with record insertion if Yes is clicked
            Dim selectedRow As DataGridViewRow = dgv1.CurrentRow

            ' Retrieve input values
            Dim soaNumber As String = soaTxt.Text
            Dim enbs As String = enbsTxt.Text
            Dim facCode As String = If(Not String.IsNullOrEmpty(codeTxt.Text),
                           codeTxt.Text,
                           If(dgv1.CurrentRow IsNot Nothing AndAlso
                              dgv1.CurrentRow.Cells("facility_code").Value IsNot DBNull.Value,
                              dgv1.CurrentRow.Cells("facility_code").Value.ToString(),
                              String.Empty))

            ' Get previous balance from DataGridView, defaulting to 0 if null
            Dim previousBalance As Double = 0
            If selectedRow IsNot Nothing AndAlso Not IsDBNull(selectedRow.Cells("balance").Value) Then
                Double.TryParse(selectedRow.Cells("balance").Value.ToString(), previousBalance)
            End If

            ' Convert input values, defaulting to 0 if empty or invalid
            Dim amountPaid As Double = 0
            Double.TryParse(amountpaidTxt.Text, amountPaid)

            Dim wtax As Double = 0
            Double.TryParse(wtaxTxt.Text, wtax)

            Dim badDebts As Double = 0
            Double.TryParse(baddebtsTxt.Text, badDebts)

            Dim interest As Double = 0
            Double.TryParse(interestTxt.Text, interest)

            Dim businessTax As Double = 0
            Double.TryParse(btaxText.Text, businessTax)

            ' Compute new balance
            Dim balance As Double = previousBalance - amountPaid - wtax - badDebts - interest - businessTax

            ' Ensure balance does not go below zero
            If balance < 0 Then balance = 0

            ' Other required values with default values
            Dim adsAmount As Double = 0
            If selectedRow IsNot Nothing AndAlso Not IsDBNull(selectedRow.Cells("ads_amount").Value) Then
                Double.TryParse(selectedRow.Cells("ads_amount").Value.ToString(), adsAmount)
            End If

            Dim soaAmount As Double = 0
            Double.TryParse(soamountTxt.Text, soaAmount)

            Dim paid_interest As Double = 0 ' Default paid interest

            Dim grandTotal As Double = 0
            Double.TryParse(totalBalance.Text, grandTotal)

            ' Get other string and date values
            Dim dueDate As Date = dtpicker1.Value
            Dim interestDate As Date = dtpicker2.Value
            Dim orDate As Date = dtpicker3.Value
            Dim orNumber As String = orderTxt.Text
            Dim others As String = othersTxt.Text
            Dim mop As String = mopCombo.Text
            Dim fop As String = formCombo.Text
            Dim chequeDetails As String = chequeTxt.Text
            Dim bank As String = bankCombo.Text
            Dim datePayment As Date = dtpicker4.Value
            Dim datePosted As Date = Date.Now ' Use current date for datePosted
            Dim remarks As String = remTxt.Text
            'Dim stopInterest As String = If(stopInterestCheck.Checked, "STOP INTEREST", String.Empty)
            Dim username As String = Login.userTxt.Text

            ' Insert the new record into the database
            InsertRecord(soaNumber, enbs, facCode, balance, adsAmount, dueDate, soaAmount, interestDate, interest, paid_interest, orDate, orNumber, badDebts, businessTax, wtax, others, grandTotal, mop, fop, chequeDetails, bank, datePayment, datePosted, amountPaid, remarks, username)

            ' Notify user of successful insertion
            MessageBox.Show("Payment successfully processed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Refresh data and clear fields
            loaddgv()
            afterPay()
            ClearFields()
            Pos.loaddgv()
        Else
        End If
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
        conn.Close()
        conn.Dispose()

        Application.Exit()
    End Sub

    Private Sub adsTxt_TextChanged(sender As Object, e As EventArgs) Handles adsTxt.TextChanged

    End Sub

    Private Sub formCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles formCombo.SelectedIndexChanged
        ' Disable the TextBox if the selected item is "Disable"
        If formCombo.SelectedItem IsNot Nothing AndAlso formCombo.SelectedItem.ToString() = "CASH" Then
            chequeTxt.Enabled = False
            bankCombo.Enabled = False
        Else
            chequeTxt.Enabled = True
            bankCombo.Enabled = True
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
    'Private Sub CalculateAndUpdateInterest()
    '    Try
    '        ' Open the connection if it's not already open
    '        If conn.State <> ConnectionState.Open Then
    '            conn.Open()
    '        End If

    '        ' Updated query to join accounting and facility_data tables
    '        Dim query As String = "SELECT a.sub_total, a.due_date, f.type2 FROM acccounting a " &
    '                          "INNER JOIN facility_data f ON a.fac_code = f.fac_code " &
    '                          "WHERE a.fac_code = ?"

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

    '                                      ' Debugging information
    '                                      Debug.WriteLine($"Principal: {principal}, Due Date: {dueDate}, " &
    '                                                  $"Date of Payment: {dateOfPayment}, Type: {type2}")

    '                                      ' Date range for term-based calculation
    '                                      Dim startDate As Date = New Date(2020, 8, 11)
    '                                      Dim endDate As Date = New Date(2023, 11, 1)

    '                                      Dim totalDays As Integer = (dateOfPayment - dueDate).Days
    '                                      Dim interest As Double = 0

    '                                      If totalDays > 0 Then
    '                                          ' Determine the term and calculation type
    '                                          Dim term As Integer
    '                                          Dim percentage As Double = 0.02 ' 2% monthly interest
    '                                          Dim dailyRate As Double = percentage / 30 ' Daily rate (2% / 30 days)

    '                                          If dueDate >= startDate AndAlso dueDate <= endDate Then
    '                                              ' Term-based process
    '                                              Select Case type2.ToUpper()
    '                                                  Case "GOVERNMENT", "LGU"
    '                                                      term = 30
    '                                                  Case "PRIVATE"
    '                                                      term = 15
    '                                                  Case Else
    '                                                      term = 0 ' Default term for unexpected types
    '                                              End Select
    '                                          Else
    '                                              ' Flat interest with no specific term
    '                                              term = 0
    '                                          End If

    '                                          ' Accumulate interest for each day beyond the term
    '                                          For dayCounter As Integer = term + 1 To totalDays
    '                                              interest += principal * dailyRate
    '                                              principal += principal * dailyRate ' Compound the principal
    '                                          Next

    '                                      End If

    '                                      ' Ensure interest is non-negative
    '                                      If interest < 0 Then
    '                                          interest = 0
    '                                      End If

    '                                      ' Debugging: Output calculated interest
    '                                      Debug.WriteLine($"Calculated Interest: {interest}")

    '                                      ' Update the interest text box
    '                                      interestTxt.Text = interest.ToString("F2")
    '                                  End Sub)
    '                    End If
    '                Else
    '                    MessageBox.Show("No record found for the provided facility code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                End If
    '            End Using
    '        End Using
    '    Catch ex As Exception
    '        MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
    Private Sub CalculateAndUpdateInterest()
        Try
            ' Open the connection if it's not already open
            If conn.State <> ConnectionState.Open Then
                conn.Open()
            End If

            ' Query to fetch data from accounting and facility_data tables
            Dim query As String = "SELECT sub_total, due_date, type FROM acccounting WHERE fac_code = ?"

            Using cmd As New OdbcCommand(query, conn)
                cmd.Parameters.AddWithValue("fac_code", codeTxt.Text)

                Using rd As OdbcDataReader = cmd.ExecuteReader()
                    If rd.Read() Then
                        ' Fetch data from database
                        Dim principal As Double = Convert.ToDouble(rd("sub_total"))
                        Dim dueDate As Date = Convert.ToDateTime(rd("due_date"))
                        Dim dateOfPayment As Date = dtpicker4.Value
                        Dim type2 As String = rd("type").ToString().ToUpper()

                        ' Initialize variables for calculations
                        Dim termDays As Integer
                        Dim interest As Double = 0

                        ' Set term days based on type2
                        If type2 = "GOVERNMENT" OrElse type2 = "LGU" Then
                            termDays = 30 ' 30 days for GOVERNMENT or LGU
                        ElseIf type2 = "PRIVATE" Then
                            termDays = 15 ' 15 days for PRIVATE
                        Else
                            termDays = 0 ' Default term for other types
                        End If

                        ' Calculate total days overdue
                        Dim totalDays As Integer = (dateOfPayment - dueDate).Days

                        ' Calculate overdue days beyond term (even if it's only 1 day overdue)
                        Dim overdueDays As Integer = If(totalDays > 0, totalDays, 0) ' At least 1 day overdue triggers interest

                        ' Interest formula (based on overdue days and monthly rate)
                        If overdueDays > 0 Then
                            Dim interestRate As Double = 0.02 ' 2% interest rate monthly
                            interest = (principal * interestRate) * (overdueDays / 30)
                        End If

                        ' Ensure non-negative interest
                        If interest < 0 Then
                            interest = 0
                        End If

                        ' Update UI fields
                        interestTxt.Text = interest.ToString("F2")
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
        'CalculateAndUpdateInterest()
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

    Private Sub computeBtn_Click(sender As Object, e As EventArgs)
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

    Private Sub computeInterest_Click(sender As Object, e As EventArgs) Handles computeInterest.Click
        ' Check if the value of codeTxt has changed
        If codeTxt.Text <> lastCodeTxtValue Then
            Try
                ' Perform the calculation and update interest
                CalculateAndUpdateInterest()

                ' Parse the current balance value
                Dim currentBalance As Double
                If Double.TryParse(balanceperSoa.Text, currentBalance) Then
                    ' Update the balance with the calculated interest
                    UpdateBalanceWithInterest(currentBalance)
                Else
                    ' If parsing fails, log or handle the error
                    ' No MessageBox here, just silent handling
                End If

                ' Update the lastCodeTxtValue with the current value
                lastCodeTxtValue = codeTxt.Text
            Catch ex As Exception
                ' Handle any potential errors during the calculation process
                ' No MessageBox here, just silent handling
            End Try
        End If
        ' If no change, nothing happens, no calculation, no message
    End Sub

    Private Sub stopInterestCheck_CheckedChanged(sender As Object, e As EventArgs) Handles stopInterestCheck.CheckedChanged
        'If stopInterestCheck.Checked = True Then
        '    interestTxt.Text = "0.00"
        'Else
        '    CalculateAndUpdateInterest()
        'End If
        If stopInterestCheck.Checked = True Then
            interestTxt.Text = "0.00"
            balanceperSoa.Text = originalBalance.ToString("F2") ' Restore original balance
        Else
            ' Restore balance first before adding interest
            CalculateAndUpdateInterest()
            UpdateBalanceWithInterest(originalBalance)
        End If
    End Sub

    Private Sub remTxt_TextChanged(sender As Object, e As EventArgs) Handles remTxt.TextChanged
        remTxt.Text = remTxt.Text.ToUpper()
        remTxt.SelectionStart = remTxt.Text.Length ' Keeps cursor at the end
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
