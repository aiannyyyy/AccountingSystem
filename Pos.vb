Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine

Public Class Pos
    Private connString As String = "DSN=dashboard"
    Private conn As New OdbcConnection()
    Private isFirstInput As Boolean = True

    ' Public property to store the fullname
    Public Property FullName As String

    Private Sub Pos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        replaceCombo.Items.AddRange({"Contaminated", "Insufficient"})

        conn.ConnectionString = "DSN=dashboard" ' Adjust the connection string to your DSN

        dtpicker1.Value = Date.Now
        dtpicker2.Value = Date.Now

        loaddgv()
        ordertext()

        ' Display the fullname on the label when the form loads
        lblshow.Text = "POINT OF SALE | USER: " & Login.userTxt.Text

        replaceCombo.Enabled = False

        codeTxt.SetOnGotFocus()
    End Sub
    Public Sub ordertext()
        brochureTxt.Enabled = False
        posterTxt.Enabled = False
        dryingTxt.Enabled = False
        replaceTxt.Enabled = False
    End Sub

    Public Sub loaddgv()
        Call connection()
        da = New OdbcDataAdapter("Select * from acccounting order by soa_date desc", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "acccounting")
        dgv1.DataSource = ds.Tables("acccounting").DefaultView
    End Sub

    Private Sub codeTxt_TextChanged(sender As Object, e As EventArgs) Handles codeTxt.TextChanged
        If String.IsNullOrEmpty(codeTxt.Text) Then
            Return
        End If

        da = New OdbcDataAdapter("select * from acccounting where fac_code like '%" & codeTxt.Text & "%'", conn)

        ds = New DataSet
        da.Fill(ds, "acccounting")
        dgv1.DataSource = ds.Tables("acccounting").DefaultView


        Try
            If conn.State <> ConnectionState.Open Then
                conn.Open()
            End If

            ' Correct the query to join the tables properly and use parameterized query
            Dim query As String = "select fac_code, fac_name, type2 from facility_data where fac_code = ?"

            Using cmd As New OdbcCommand(query, conn)
                cmd.Parameters.AddWithValue("fac_code", codeTxt.Text)

                Using rd As OdbcDataReader = cmd.ExecuteReader()
                    If rd.Read() Then
                        ' Ensure the UI update is done on the main thread
                        Me.Invoke(Sub()
                                      codeTxt.Text = rd("fac_code").ToString()
                                      nameBox.Text = rd("fac_name").ToString()
                                      Dim term As Integer

                                      Select Case rd("type2").ToString()
                                          Case "GOVERNMENT", "LGU"
                                              term = 60
                                          Case "PRIVATE"
                                              term = 45
                                      End Select

                                      termBox.Text = term.ToString()

                                      ' Get the purchase date from wherever you have it stored
                                      Dim purchaseDate As Date = Date.Today ' Example purchase date is today

                                      ' Calculate the due date
                                      Dim dueDate As Date = purchaseDate.AddDays(term)

                                      ' Display the due date in dueTxt
                                      dtpicker1.Value = dueDate.ToShortDateString() ' Adjust date format as needed
                                  End Sub)
                    Else
                        Me.Invoke(Sub()
                                      nameBox.Clear()
                                      termBox.Clear()
                                      dtpicker1.Value = Date.Now.ToShortDateString() ' Set current date if no record is found
                                  End Sub)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Sub

    Private Sub brochureCheck_CheckedChanged(sender As Object, e As EventArgs) Handles brochureCheck.CheckedChanged
        If brochureCheck.Checked Then
            brochureTxt.Enabled = True
        Else
            brochureTxt.Enabled = False
            brochureTxt.Clear()
            adsTxt.Clear()
            totalTxt.Clear()
        End If
    End Sub

    Private Sub posterCheck_CheckedChanged(sender As Object, e As EventArgs) Handles posterCheck.CheckedChanged
        If posterCheck.Checked Then
            posterTxt.Enabled = True
        Else
            posterTxt.Enabled = False
            posterTxt.Clear()
            adsTxt.Clear()
            totalTxt.Clear()
        End If
    End Sub

    Private Sub dryingCheck_CheckedChanged(sender As Object, e As EventArgs) Handles dryingCheck.CheckedChanged
        If dryingCheck.Checked Then
            dryingTxt.Enabled = True
        Else
            dryingTxt.Enabled = False
            dryingTxt.Clear()
            adsTxt.Clear()
            totalTxt.Clear()
        End If
    End Sub

    Private Sub replaceCheck_CheckedChanged(sender As Object, e As EventArgs) Handles replaceCheck.CheckedChanged
        If replaceCheck.Checked Then
            replaceTxt.Enabled = True
        Else
            replaceTxt.Enabled = False
            replaceTxt.Clear()
            adsTxt.Clear()
            totalTxt.Clear()
        End If
    End Sub

    Private Sub computeButton_Click(sender As Object, e As EventArgs) Handles computeButton.Click
        Dim brochureamount As Double = 0
        Dim posteramount As Double = 0
        Dim dryingamount As Double = 0
        Dim replaceamount As Double = 0

        Dim brochureCount As Double = 0
        Dim posterCount As Double = 0
        Dim replaceCount As Double = 0

        ' Check and parse brochure count
        If Not String.IsNullOrEmpty(brochureTxt.Text) AndAlso Double.TryParse(brochureTxt.Text, brochureCount) Then
            brochureamount = brochureCount * 1.5
        End If

        ' Check and parse poster count
        If Not String.IsNullOrEmpty(posterTxt.Text) AndAlso Double.TryParse(posterTxt.Text, posterCount) Then
            posteramount = posterCount * 10.0
            dryingamount = posterCount * 0.0 ' This will always be 0 as per your code
        End If

        ' Check and parse replace count
        If Not String.IsNullOrEmpty(replaceTxt.Text) AndAlso Double.TryParse(replaceTxt.Text, replaceCount) Then
            replaceamount = replaceCount * 0.0 ' This will always be 0 as per your code
        End If

        ' Calculate the total amount
        Dim totalamount As Double = brochureamount + posteramount + dryingamount + replaceamount

        ' Display the amounts in the appropriate text boxes
        adsTxt.Text = totalamount.ToString() ' Format as fixed-point number with 1 decimal place

        ' Update totalTxt.Text by adding the value from amountTxt.Text
        UpdateTotalAmount()
    End Sub

    Private Sub replacementCheck_CheckedChanged(sender As Object, e As EventArgs) Handles replacementCheck.CheckedChanged
        If replacementCheck.Checked Then
            replaceCombo.Enabled = True
            UncheckOtherCheckBoxes(replacementCheck)
            CalculateTotalAmount(15)
        Else
            ClearTextBoxesIfNoChecks()
            replaceCombo.Enabled = False
            replaceCombo.SelectedIndex = -1
        End If
    End Sub

    Private Sub walkCheck_CheckedChanged(sender As Object, e As EventArgs) Handles walkCheck.CheckedChanged
        If walkCheck.Checked Then
            UncheckOtherCheckBoxes(walkCheck)
            CalculateTotalAmount(1750)
        Else
            ClearTextBoxesIfNoChecks()
        End If
    End Sub

    Private Sub monitoringCheck_CheckedChanged(sender As Object, e As EventArgs) Handles monitoringCheck.CheckedChanged
        If monitoringCheck.Checked Then
            UncheckOtherCheckBoxes(monitoringCheck)
            CalculateTotalAmount(400)
        Else
            ClearTextBoxesIfNoChecks()
        End If
    End Sub

    Private Sub cancelCheck_CheckedChanged(sender As Object, e As EventArgs) Handles cancelCheck.CheckedChanged
        If cancelCheck.Checked Then
            UncheckOtherCheckBoxes(cancelCheck)
            CalculateTotalAmount(0)
        Else
            ClearTextBoxesIfNoChecks()
        End If
    End Sub

    Private Sub UncheckOtherCheckBoxes(checkedCheckBox As CheckBox)
        For Each chk As CheckBox In {replacementCheck, walkCheck, monitoringCheck, cancelCheck, lopezCheck}
            If chk IsNot checkedCheckBox AndAlso chk.Checked Then
                chk.Checked = False
            End If
        Next
    End Sub

    Private Sub ClearTextBoxesIfNoChecks()
        If Not replacementCheck.Checked AndAlso Not walkCheck.Checked AndAlso Not monitoringCheck.Checked AndAlso Not cancelCheck.Checked AndAlso Not lopezCheck.Checked Then
            qtyTxt.Clear()
            amountTxt.Clear()
            totalTxt.Clear()
        End If
    End Sub

    Private Sub qtyTxt_TextChanged(sender As Object, e As EventArgs) Handles qtyTxt.TextChanged
        ' Reset isFirstInput and set defaults if the textbox is cleared
        If String.IsNullOrEmpty(qtyTxt.Text) Then
            isFirstInput = True
            amountTxt.Text = "0"   ' Default value for amountTxt
            totalTxt.Text = "0.00" ' Default value for totalTxt
        End If

        If String.IsNullOrEmpty(qtyTxt.Text) Then
            isFirstInput = True
        End If

        ' Determine which checkbox is checked and calculate accordingly
        If replacementCheck.Checked Then
            CalculateTotalAmount(15)
        ElseIf walkCheck.Checked Then
            CalculateTotalAmount(1750)
        ElseIf monitoringCheck.Checked Then
            CalculateTotalAmount(400)
        ElseIf cancelCheck.Checked Then
            CalculateTotalAmount(0)
        ElseIf lopezCheck.Checked Then
            CalculateTotalAmount(1800)
        End If

        ' Update totalTxt.Text by adding the value from adsTxt.Text
        UpdateTotalAmount()
    End Sub

    Private Sub qtyTxt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles qtyTxt.KeyPress
        '' Check if the Enter key is pressed
        'If e.KeyChar = ChrW(Keys.Enter) Then
        '    If isFirstInput AndAlso Double.TryParse(qtyTxt.Text, Nothing) Then
        '        ' First valid input: multiply quantity by 1750 and set amountTxt.Text
        '        Dim quantity As Double
        '        If Double.TryParse(qtyTxt.Text, quantity) Then
        '            amountTxt.Text = (quantity * 1750).ToString()
        '        End If
        '        isFirstInput = False
        '    Else
        '        ' Perform the appropriate calculation based on the selected checkbox
        '        If replacementCheck.Checked Then
        '            CalculateTotalAmount(15)
        '        ElseIf walkCheck.Checked Then
        '            CalculateTotalAmount(1800)
        '        ElseIf monitoringCheck.Checked Then
        '            CalculateTotalAmount(400)
        '        ElseIf cancelCheck.Checked Then
        '            CalculateTotalAmount(0)
        '        ElseIf lopezCheck.Checked Then
        '            CalculateTotalAmount(1800)
        '        End If
        '    End If

        '    ' Update totalTxt.Text by adding the value from adsTxt.Text
        '    UpdateTotalAmount()

        '    ' Prevent the beep sound on Enter key press
        '    e.Handled = True
        'End If

        ' Check if the Enter key is pressed
        If e.KeyChar = ChrW(Keys.Enter) Then
            Dim quantity As Double

            ' Validate the input as a number
            If Double.TryParse(qtyTxt.Text, quantity) Then
                ' Perform the appropriate calculation based on the selected checkbox
                If replacementCheck.Checked Then
                    CalculateTotalAmount(15)
                ElseIf walkCheck.Checked Then
                    CalculateTotalAmount(1800)
                ElseIf monitoringCheck.Checked Then
                    CalculateTotalAmount(400)
                ElseIf cancelCheck.Checked Then
                    CalculateTotalAmount(0)
                ElseIf lopezCheck.Checked Then
                    CalculateTotalAmount(1800)
                Else
                    ' Default calculation: multiply by 1750 if no checkbox is selected
                    amountTxt.Text = (quantity * 1750).ToString ' Format with 2 decimal places
                End If

                ' Update totalTxt.Text by adding the value from adsTxt.Text
                UpdateTotalAmount()
            Else
                ' Show a message if the input is invalid
                MessageBox.Show("Please enter a valid number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            ' Prevent the beep sound on Enter key press
            e.Handled = True
        End If

        ' Allow only digits and control keys (e.g., Backspace)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Public Sub CalculateTotalAmount(unitPrice As Double)
        'Dim quantity As Double
        'Dim totalAmount As Double

        '' Parse the quantity from qtyTxt
        'If Double.TryParse(qtyTxt.Text, quantity) Then
        '    ' Calculate the total amount
        '    totalAmount = quantity * unitPrice

        '    ' Display the total amount in amountTxt
        '    amountTxt.Text = totalAmount.ToString() ' Format as fixed-point number with 1 decimal place
        'Else
        '    amountTxt.Text = "0"
        'End If

        '' Update totalTxt.Text by adding the value from adsTxt.Text
        'UpdateTotalAmount()
        Dim quantity As Double

        ' Parse the quantity from qtyTxt
        If Double.TryParse(qtyTxt.Text, quantity) Then
            ' Calculate the total amount
            Dim totalAmount = quantity * unitPrice

            ' Display the total amount in amountTxt
            amountTxt.Text = totalAmount.ToString() ' Format with 2 decimal places
        Else
            amountTxt.Text = "0"
        End If
    End Sub

    Private Sub UpdateTotalAmount()
        'Dim amountValue As Double = 0
        'Dim adsValue As Double = 0

        '' Parse amountTxt.Text
        'If Not String.IsNullOrEmpty(amountTxt.Text) AndAlso Double.TryParse(amountTxt.Text, amountValue) Then
        '    ' Value parsed successfully
        'End If

        '' Parse adsTxt.Text
        'If Not String.IsNullOrEmpty(adsTxt.Text) AndAlso Double.TryParse(adsTxt.Text, adsValue) Then
        '    ' Value parsed successfully
        'End If

        '' Calculate the combined total
        'Dim combinedTotal As Double = amountValue + adsValue

        '' Display the combined total in totalTxt
        'totalTxt.Text = combinedTotal.ToString("F2") ' Format as fixed-point number with 2 decimal places

        Dim amountValue As Double = 0
        Dim adsValue As Double = 0

        ' Parse amountTxt.Text
        Double.TryParse(amountTxt.Text, amountValue)

        ' Parse adsTxt.Text
        Double.TryParse(adsTxt.Text, adsValue)

        ' Calculate the combined total
        Dim combinedTotal = amountValue + adsValue

        ' Display the combined total in totalTxt
        totalTxt.Text = combinedTotal.ToString("F2") ' Format with 2 decimal places
    End Sub

    Public Sub cleartxt()
        codeTxt.Text = ""
        purchaseBox.Text = ""
        nameBox.Text = ""
        termBox.Text = ""
        dtpicker1.Value = Date.Now
        dtpicker2.Value = Date.Now
        qtyTxt.Text = ""
        amountTxt.Text = ""
        walkCheck.Checked = False
        monitoringCheck.Checked = False
        cancelCheck.Checked = False
        replaceCheck.Checked = False
        brochureCheck.Checked = False
        posterCheck.Checked = False
        dryingCheck.Checked = False
        replaceCheck.Checked = False
        brochureTxt.Text = ""
        posterTxt.Text = ""
        dryingTxt.Text = ""
        replaceTxt.Text = ""
        adsTxt.Text = ""
        totalTxt.Text = ""
    End Sub

    Private Function ExecuteQuery(query As String) As Integer
        Using conn As New OdbcConnection(connString)
            Using cmd As New OdbcCommand(query, conn)
                conn.Open()
                Return cmd.ExecuteNonQuery()
            End Using
        End Using
    End Function

    'Private Function InsertRecord(ByRef soatxt As String, soaDate As Date, ordertype As String, code As String, name As String, term As String, purchaseNumber As String, purchaseDate As Date, quantity As Integer, subtotal As Integer, brochure As Integer, poster As Integer, drying As Integer, replace As Integer, ads As Integer, dueDate As Date, totalAmount As Double, balance As Double, user As String, subamount As Integer) As Integer
    '    Dim insertQuery As String = "INSERT INTO acccounting (soa_txt, soa_date, order_type, fac_code, facility_name, term, purchase_number, purchase_date, quantity, sub_total, brochure, poster, drying_rack, replacement, ads_amount, due_date, total_amount, balance, username, sub_amount) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
    '    Dim lastInsertedIdQuery As String = "SELECT LAST_INSERT_ID()"

    '    Using conn As New OdbcConnection("DSN=dashboard")
    '        Using cmd As New OdbcCommand(insertQuery, conn)
    '            ' Convert soa_number to string and assign it to soa_txt
    '            Dim soaNumberParameter As New OdbcParameter("soa_txt", OdbcType.VarChar)
    '            soaNumberParameter.Value = soatxt
    '            cmd.Parameters.Add(soaNumberParameter)

    '            cmd.Parameters.Add(New OdbcParameter("soa_date", OdbcType.Date)).Value = soaDate
    '            cmd.Parameters.Add(New OdbcParameter("order_type", OdbcType.VarChar)).Value = ordertype
    '            cmd.Parameters.Add(New OdbcParameter("fac_code", OdbcType.VarChar)).Value = code
    '            cmd.Parameters.Add(New OdbcParameter("facility_name", OdbcType.VarChar)).Value = name
    '            cmd.Parameters.Add(New OdbcParameter("term", OdbcType.VarChar)).Value = term
    '            cmd.Parameters.Add(New OdbcParameter("purchase_number", OdbcType.VarChar)).Value = purchaseNumber
    '            cmd.Parameters.Add(New OdbcParameter("purchase_date", OdbcType.Date)).Value = purchaseDate
    '            cmd.Parameters.Add(New OdbcParameter("quantity", OdbcType.Int)).Value = quantity
    '            cmd.Parameters.Add(New OdbcParameter("sub_total", OdbcType.Int)).Value = subtotal
    '            cmd.Parameters.Add(New OdbcParameter("brochure", OdbcType.Int)).Value = brochure
    '            cmd.Parameters.Add(New OdbcParameter("poster", OdbcType.Int)).Value = poster
    '            cmd.Parameters.Add(New OdbcParameter("drying_rack", OdbcType.Int)).Value = drying
    '            cmd.Parameters.Add(New OdbcParameter("replacement", OdbcType.Int)).Value = replace
    '            cmd.Parameters.Add(New OdbcParameter("ads_amount", OdbcType.Double)).Value = ads
    '            cmd.Parameters.Add(New OdbcParameter("due_date", OdbcType.Date)).Value = dueDate
    '            cmd.Parameters.Add(New OdbcParameter("total_amount", OdbcType.Double)).Value = totalAmount
    '            cmd.Parameters.Add(New OdbcParameter("balance", OdbcType.Double)).Value = balance
    '            cmd.Parameters.Add(New OdbcParameter("username", OdbcType.VarChar)).Value = user
    '            cmd.Parameters.Add(New OdbcParameter("sub_amount", OdbcType.Double)).Value = subamount
    '            conn.Open()
    '            cmd.ExecuteNonQuery()

    '            cmd.CommandText = lastInsertedIdQuery
    '            Dim lastInsertedId As Integer = Convert.ToInt32(cmd.ExecuteScalar())

    '            Return lastInsertedId

    '        End Using
    '    End Using
    'End Function

    Private Function InsertRecord(ByRef soatxt As String, soaDate As Date, ordertype As String, code As String, name As String, term As String, purchaseNumber As String, purchaseDate As Date, quantity As Integer, subtotal As Integer, brochure As Integer, poster As Integer, drying As Integer, replace As Integer, ads As Double, dueDate As Date, totalAmount As Double, balance As Double, user As String, subamount As Integer) As Integer
        Dim insertQuery As String = "INSERT INTO acccounting (soa_txt, soa_date, order_type, fac_code, facility_name, term, purchase_number, purchase_date, quantity, sub_total, brochure, poster, drying_rack, replacement, ads_amount, due_date, total_amount, balance, username, sub_amount) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
        Dim lastInsertedIdQuery As String = "SELECT LAST_INSERT_ID()"

        Using conn As New OdbcConnection("DSN=dashboard")
            Using cmd As New OdbcCommand(insertQuery, conn)
                ' Convert soa_number to string and assign it to soa_txt
                Dim soaNumberParameter As New OdbcParameter("soa_txt", OdbcType.VarChar)
                soaNumberParameter.Value = soatxt
                cmd.Parameters.Add(soaNumberParameter)

                cmd.Parameters.Add(New OdbcParameter("soa_date", OdbcType.Date)).Value = soaDate
                cmd.Parameters.Add(New OdbcParameter("order_type", OdbcType.VarChar)).Value = ordertype
                cmd.Parameters.Add(New OdbcParameter("fac_code", OdbcType.VarChar)).Value = code
                cmd.Parameters.Add(New OdbcParameter("facility_name", OdbcType.VarChar)).Value = name
                cmd.Parameters.Add(New OdbcParameter("term", OdbcType.VarChar)).Value = term
                cmd.Parameters.Add(New OdbcParameter("purchase_number", OdbcType.VarChar)).Value = purchaseNumber
                cmd.Parameters.Add(New OdbcParameter("purchase_date", OdbcType.Date)).Value = purchaseDate
                cmd.Parameters.Add(New OdbcParameter("quantity", OdbcType.Int)).Value = quantity
                cmd.Parameters.Add(New OdbcParameter("sub_total", OdbcType.Int)).Value = subtotal
                cmd.Parameters.Add(New OdbcParameter("brochure", OdbcType.Int)).Value = brochure
                cmd.Parameters.Add(New OdbcParameter("poster", OdbcType.Int)).Value = poster
                cmd.Parameters.Add(New OdbcParameter("drying_rack", OdbcType.Int)).Value = drying
                cmd.Parameters.Add(New OdbcParameter("replacement", OdbcType.Int)).Value = replace

                ' Round the ads amount to 2 decimal places before insertion
                cmd.Parameters.Add(New OdbcParameter("ads_amount", OdbcType.Double)).Value = Math.Round(ads, 2)

                cmd.Parameters.Add(New OdbcParameter("due_date", OdbcType.Date)).Value = dueDate
                cmd.Parameters.Add(New OdbcParameter("total_amount", OdbcType.Double)).Value = totalAmount
                cmd.Parameters.Add(New OdbcParameter("balance", OdbcType.Double)).Value = balance
                cmd.Parameters.Add(New OdbcParameter("username", OdbcType.VarChar)).Value = user
                cmd.Parameters.Add(New OdbcParameter("sub_amount", OdbcType.Double)).Value = subamount

                conn.Open()
                cmd.ExecuteNonQuery()

                cmd.CommandText = lastInsertedIdQuery
                Dim lastInsertedId As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                Return lastInsertedId
            End Using
        End Using
    End Function

    'Private Sub addButton_Click(sender As Object, e As EventArgs) Handles addButton.Click
    '    Try
    '        ' Validate the fields before proceeding
    '        If Not ValidateFields() Then
    '            ' Stop execution if validation fails
    '            Exit Sub
    '        End If

    '        Dim soatxt As String ' Declare soatxt here
    '        Dim soaDate As Date = Date.Now
    '        Dim ordertype As String = ""

    '        If walkCheck.Checked Then
    '            ordertype = "ENBS"
    '        ElseIf monitoringCheck.Checked Then
    '            ordertype = "Monitoring"
    '        ElseIf replacementCheck.Checked Then
    '            ordertype = "ENBS-Replacement of Expired Filter Card"
    '        ElseIf lopezCheck.Checked Then
    '            ordertype = "ENBS"
    '        Else
    '            ordertype = "ENBS"
    '        End If

    '        Dim code As String = codeTxt.Text
    '        Dim name As String = nameBox.Text
    '        Dim term As String = termBox.Text
    '        Dim purchaseNumber As String = purchaseBox.Text
    '        Dim purchaseDate As Date = dtpicker2.Value
    '        Dim quantity As Integer = Integer.Parse(qtyTxt.Text)
    '        Dim subtotal As Integer = Integer.Parse(amountTxt.Text)
    '        Dim brochure As Integer = If(String.IsNullOrEmpty(brochureTxt.Text), 0, Integer.Parse(brochureTxt.Text))
    '        Dim poster As Integer = If(String.IsNullOrEmpty(posterTxt.Text), 0, Integer.Parse(posterTxt.Text))
    '        Dim drying As Integer = If(String.IsNullOrEmpty(dryingTxt.Text), 0, Integer.Parse(dryingTxt.Text))
    '        Dim replace As Integer = If(String.IsNullOrEmpty(replaceTxt.Text), 0, Integer.Parse(replaceTxt.Text))
    '        Dim ads As Double = Double.Parse(adsTxt.Text)
    '        Dim dueDate As Date = dtpicker1.Value
    '        Dim totalAmount As Double = Double.Parse(totalTxt.Text)
    '        Dim balance As Double = Double.Parse(totalTxt.Text) ' Assuming balanceTxt should be used here
    '        Dim user As String = Login.userTxt.Text
    '        Dim subamount As Integer = amountTxt.Text

    '        ' Insert the record
    '        Dim soaNumber As Integer = InsertRecord("", soaDate, ordertype, code, name, term, purchaseNumber, purchaseDate, quantity, subtotal, brochure, poster, drying, replace, ads, dueDate, totalAmount, balance, user, subamount)

    '        ' Assign the generated soa_number to soatxt
    '        soatxt = soaNumber.ToString()

    '        ' Update the soa_txt field in the database
    '        UpdateSoaTxt(soatxt, soaNumber)

    '        MessageBox.Show("Insert Successfully!")

    '        If walkCheck.Checked Then
    '            ' Generate the Crystal Report
    '            Dim report As New StatementOfAccount()
    '            Dim selformula As String = "{acccounting1.soa_txt} = '" & soatxt & "'"
    '            report.RecordSelectionFormula = selformula

    '            ' Refresh the report to load data
    '            report.Refresh()

    '            Dim reportForm As New Form
    '            Dim crystalReportViewer As New CrystalDecisions.Windows.Forms.CrystalReportViewer
    '            crystalReportViewer.ReportSource = report
    '            crystalReportViewer.Dock = DockStyle.Fill
    '            reportForm.Controls.Add(crystalReportViewer)
    '            reportForm.WindowState = FormWindowState.Maximized
    '            reportForm.Show()
    '        ElseIf monitoringCheck.Checked Then
    '            ' Generate the Crystal Report
    '            Dim report As New StatementOfAccount()
    '            Dim selformula As String = "{acccounting1.soa_txt} = '" & soatxt & "'"
    '            report.RecordSelectionFormula = selformula

    '            ' Refresh the report to load data
    '            report.Refresh()

    '            Dim reportForm As New Form
    '            Dim crystalReportViewer As New CrystalDecisions.Windows.Forms.CrystalReportViewer
    '            crystalReportViewer.ReportSource = report
    '            crystalReportViewer.Dock = DockStyle.Fill
    '            reportForm.Controls.Add(crystalReportViewer)
    '            reportForm.WindowState = FormWindowState.Maximized
    '            reportForm.Show()
    '        ElseIf replacementCheck.Checked Then
    '            ' Generate the Crystal Report
    '            Dim report As New StatementOfAccount()
    '            Dim selformula As String = "{acccounting1.soa_txt} = '" & soatxt & "'"
    '            report.RecordSelectionFormula = selformula

    '            ' Refresh the report to load data
    '            report.Refresh()

    '            Dim reportForm As New Form
    '            Dim crystalReportViewer As New CrystalDecisions.Windows.Forms.CrystalReportViewer
    '            crystalReportViewer.ReportSource = report
    '            crystalReportViewer.Dock = DockStyle.Fill
    '            reportForm.Controls.Add(crystalReportViewer)
    '            reportForm.WindowState = FormWindowState.Maximized
    '            reportForm.Show()
    '        ElseIf lopezCheck.Checked Then
    '            ' Generate the Crystal Report
    '            Dim report As New StatementOfAccountWithServiceFee()
    '            Dim selformula As String = "{acccounting1.soa_txt} = '" & soatxt & "'"
    '            report.RecordSelectionFormula = selformula

    '            ' Refresh the report to load data
    '            report.Refresh()

    '            Dim reportForm As New Form
    '            Dim crystalReportViewer As New CrystalDecisions.Windows.Forms.CrystalReportViewer
    '            crystalReportViewer.ReportSource = report
    '            crystalReportViewer.Dock = DockStyle.Fill
    '            reportForm.Controls.Add(crystalReportViewer)
    '            reportForm.WindowState = FormWindowState.Maximized
    '            reportForm.Show()
    '        End If


    '        ' Clear input fields and refresh data grid view
    '        cleartxt()
    '        loaddgv()
    '    Catch ex As Exception
    '        MessageBox.Show("An error occurred: " & ex.Message)
    '    End Try
    'End Sub

    Private Sub addButton_Click(sender As Object, e As EventArgs) Handles addButton.Click
        Try
            ' Validate the fields before proceeding
            ' Validate the fields before proceeding
            If Not ValidateFields() Then
                ' Stop execution if validation fails
                Exit Sub
            End If

            ' Confirm all entries are correct
            Dim confirmResult As DialogResult = MessageBox.Show("Are all entries correct?",
                                                           "Confirmation",
                                                           MessageBoxButtons.YesNo,
                                                           MessageBoxIcon.Question)

            If confirmResult = DialogResult.No Then
                ' User wants to cancel the operation
                MessageBox.Show("Operation canceled. Please check your input and try again.",
                            "Operation Canceled",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Dim soatxt As String ' Declare soatxt here
            Dim soaDate As Date = Date.Now
            Dim ordertype As String = ""

            If walkCheck.Checked Then
                ordertype = "ENBS"
            ElseIf monitoringCheck.Checked Then
                ordertype = "Monitoring"
            ElseIf replacementCheck.Checked Then
                ordertype = "ENBS-Replacement " + replaceCombo.SelectedItem.ToString()
            ElseIf lopezCheck.Checked Then
                ordertype = "ENBS"
            Else
                ordertype = "ENBS"
            End If

            Dim code As String = codeTxt.Text
            Dim name As String = nameBox.Text
            Dim term As String = termBox.Text
            Dim purchaseNumber As String = purchaseBox.Text
            Dim purchaseDate As Date = dtpicker2.Value
            Dim quantity As Integer = Integer.Parse(qtyTxt.Text)
            Dim subtotal As Integer = Integer.Parse(amountTxt.Text)
            Dim brochure As Integer = If(String.IsNullOrEmpty(brochureTxt.Text), 0, Integer.Parse(brochureTxt.Text))
            Dim poster As Integer = If(String.IsNullOrEmpty(posterTxt.Text), 0, Integer.Parse(posterTxt.Text))
            Dim drying As Integer = If(String.IsNullOrEmpty(dryingTxt.Text), 0, Integer.Parse(dryingTxt.Text))
            Dim replace As Integer = If(String.IsNullOrEmpty(replaceTxt.Text), 0, Integer.Parse(replaceTxt.Text))
            Dim ads As Double = Double.Parse(adsTxt.Text)
            Dim dueDate As Date = dtpicker1.Value
            Dim totalAmount As Double = Double.Parse(totalTxt.Text)
            Dim balance As Double = Double.Parse(totalTxt.Text) ' Assuming balanceTxt should be used here
            Dim user As String = Login.userTxt.Text
            Dim subamount As Integer = amountTxt.Text

            ' Insert the record
            Dim soaNumber As Integer = InsertRecord("", soaDate, ordertype, code, name, term, purchaseNumber, purchaseDate, quantity, subtotal, brochure, poster, drying, replace, ads, dueDate, totalAmount, balance, user, subamount)

            ' Assign the generated soa_number to soatxt
            soatxt = soaNumber.ToString()

            ' Update the soa_txt field in the database
            UpdateSoaTxt(soatxt, soaNumber)

            MessageBox.Show("Insert Successfully!")

            If walkCheck.Checked Then
                ' Generate the Crystal Report
                Dim report As New StatementOfAccount()
                Dim selformula As String = "{acccounting1.soa_txt} = '" & soatxt & "'"
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
            ElseIf monitoringCheck.Checked Then
                ' Generate the Crystal Report
                Dim report As New StatementOfAccount()
                Dim selformula As String = "{acccounting1.soa_txt} = '" & soatxt & "'"
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
            ElseIf replacementCheck.Checked Then
                ' Generate the Crystal Report
                Dim report As New StatementOfAccount()
                Dim selformula As String = "{acccounting1.soa_txt} = '" & soatxt & "'"
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
            ElseIf lopezCheck.Checked Then
                ' Generate the Crystal Report
                Dim report As New StatementOfAccountWithServiceFee()
                Dim selformula As String = "{acccounting1.soa_txt} = '" & soatxt & "'"
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
            Else
                ' Generate the Crystal Report
                Dim report As New StatementOfAccount()
                Dim selformula As String = "{acccounting1.soa_txt} = '" & soatxt & "'"
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
            End If


            ' Clear input fields and refresh data grid view
            cleartxt()
            loaddgv()
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Sub

    Private Function ValidateFields() As Boolean
        Dim errorMessage As String = "Please input required fields first."

        ' Check if any of the fields are blank in a single statement
        If String.IsNullOrWhiteSpace(codeTxt.Text) OrElse
           String.IsNullOrWhiteSpace(nameBox.Text) OrElse
           String.IsNullOrWhiteSpace(termBox.Text) OrElse
           String.IsNullOrWhiteSpace(purchaseBox.Text) Then

            ' Show the message box and return False if any field is blank
            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        ' Return True if all fields are filled
        Return True
    End Function

    Private Sub UpdateSoaTxt(ByVal soatxt As String, ByVal soaNumber As Integer)
        Dim updateQuery As String = "UPDATE acccounting SET soa_txt = ? WHERE soa_number = ?"

        Using conn As New OdbcConnection("DSN=dashboard")
            Using cmd As New OdbcCommand(updateQuery, conn)
                cmd.Parameters.Add(New OdbcParameter("soa_txt", OdbcType.VarChar)).Value = soatxt
                cmd.Parameters.Add(New OdbcParameter("soa_number", OdbcType.Int)).Value = soaNumber

                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub
    Private Sub brochureTxt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles brochureTxt.KeyPress
        If Char.IsControl(e.KeyChar) Then
            Return
        End If

        ' Allow only numeric input
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub posterTxt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles posterTxt.KeyPress
        If Char.IsControl(e.KeyChar) Then
            Return
        End If

        ' Allow only numeric input
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub dryingTxt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dryingTxt.KeyPress
        If Char.IsControl(e.KeyChar) Then
            Return
        End If

        ' Allow only numeric input
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub replaceTxt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles replaceTxt.KeyPress
        If Char.IsControl(e.KeyChar) Then
            Return
        End If

        ' Allow only numeric input
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub GunaControlBox3_Click(sender As Object, e As EventArgs) Handles GunaControlBox3.Click
    End Sub

    Private Sub payButton_Click(sender As Object, e As EventArgs) Handles payButton.Click
        Payments.Show()
        Me.Hide()
    End Sub

    Private Sub soaButton_Click(sender As Object, e As EventArgs) Handles soaButton.Click
        ReprintSoa.Show()
    End Sub

    Private Sub lopezCheck_CheckedChanged(sender As Object, e As EventArgs) Handles lopezCheck.CheckedChanged
        If lopezCheck.Checked Then
            UncheckOtherCheckBoxes(lopezCheck)
            CalculateTotalAmount(1800)
        Else
            ClearTextBoxesIfNoChecks()
        End If
    End Sub

    Private Sub noticeButton_Click(sender As Object, e As EventArgs) Handles noticeButton.Click
        NoticeForm.Show()
    End Sub

    Private Sub codeTxt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles codeTxt.KeyPress
        ' Allow only digits and control keys (e.g., Backspace)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub


End Class