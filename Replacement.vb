Imports System.Data.Odbc

Public Class Replacement
    Private connString As String = "DSN=dashboard"

    Private _currentSOANumber As String
    Private _nextSOANumber As String
    Private _codeReplace As String

    ' Create an instance of Pos form (assuming it's in the same project)
    Dim Pos As New Pos()

    Public ReadOnly Property ReplacementCount As String
        Get
            Return replaceCountTxt.Text
        End Get
    End Property


    ' Constructor that accepts both the current And Next SOA numbers
    Public Sub New(currentSOANumber As String, nextSOANumber As String, codereplace As String)
        InitializeComponent()
        _currentSOANumber = currentSOANumber
        _nextSOANumber = nextSOANumber
        _codeReplace = codereplace
        Me.connString = connString
    End Sub

    Private Sub Replacement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize the form when it's loaded
        dtpicker2.Value = Date.Now
        codeTxt.Text = _codeReplace
        soaTxt.Text = _nextSOANumber

        amountTxt.Text = "0.00"

        ' Automatically filter based on the value of codeTxt
        If Not String.IsNullOrEmpty(codeTxt.Text) Then
            FilterDataGrid(codeTxt.Text)
        End If

        replaceCountTxt.Enabled = False
        codeTxt.Enabled = False
        amountTxt.Enabled = False
        soaTxt.Enabled = False
        dtpicker2.Enabled = False
    End Sub

    ' Your FilterDataGrid method (same as before)
    Public Sub FilterDataGrid(facCode As String)
        ' Filter the DataGridView based on facCode
        Try
            If conn.State <> ConnectionState.Open Then
                conn.Open()
            End If

            'Dim odbcQuery As String = "SELECT labid, newlabid, test_type, date_replace FROM replacement WHERE fac_code = ? order by date_replace desc"
            Dim odbcQuery As String = "SELECT labid, newlabid, test_type, date_replace " &
                          "FROM replacement " &
                          "WHERE fac_code = ? " &
                          "  AND replacement <> 'REPLACED' " &
                          "  AND NOT ((replacement IS NULL OR replacement = '') " &
                          "           AND ntreplace = 'IRREPLACABLE') " &
                          "ORDER BY date_replace DESC"

            Using odbcCmd As New OdbcCommand(odbcQuery, conn)
                odbcCmd.Parameters.AddWithValue("@fac_code", facCode)

                Dim odbcAdapter As New OdbcDataAdapter(odbcCmd)
                Dim odbcDataSet As New DataSet
                odbcAdapter.Fill(odbcDataSet, "replacement")
                dgv1.DataSource = odbcDataSet.Tables("replacement").DefaultView
            End Using
        Catch ex As Exception
            MessageBox.Show("ODBC Error: " & ex.Message)
        End Try
    End Sub

    ' Function to execute a query that doesn't return any results (like UPDATE, INSERT)
    Private Function ExecuteQuery(query As String) As Integer
        Try
            Using conn As New OdbcConnection(connString)
                Using cmd As New OdbcCommand(query, conn)
                    conn.Open()
                    Return cmd.ExecuteNonQuery() ' Execute the query and return affected rows
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error executing query: " & ex.Message)
        End Try
    End Function

    ' Function to execute a query that returns a scalar value (like SUM, COUNT, etc.)
    Public Function ExecuteScalar(query As String) As Integer
        Dim result As Integer = 0
        Try
            Using connection As New OdbcConnection(connString)
                connection.Open()
                Using command As New OdbcCommand(query, connection)
                    result = Convert.ToInt32(command.ExecuteScalar()) ' Get the first column of the first row
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error executing query: " & ex.Message)
        End Try
        Return result
    End Function

    ' Function to insert a new replacement record
    Private Sub InsertRecord(facCode As String, soaNumber As String, replaceType As String, purchaseDate As Date, quantity As Integer, unitPrice As Decimal, totalPrice As Decimal, labid As String, newlabid As String)
        ' Ensure quantity is Integer and unitPrice is Decimal
        Dim query As String = $"INSERT INTO replacement_type (fac_code, soa_number, replace_type, purchase_date, quantity, unit_price, total_price, labid, newlabid) " &
                          $"VALUES ('{facCode}', '{soaNumber}', '{replaceType}', '{purchaseDate.ToString("yyyy-MM-dd")}', '{quantity}', '{unitPrice}', '{totalPrice}', '{labid}', '{newlabid}')"
        ExecuteQuery(query)
    End Sub

    ' Event handler for the Add Button to insert a new record
    Private Sub addButton_Click(sender As Object, e As EventArgs) Handles addButton.Click
        Dim facCode As String = codeTxt.Text
        Dim soaNumber As String = soaTxt.Text
        Dim purchaseDate As Date = dtpicker2.Value
        Dim quantity As Integer = 1 ' Fixed quantity of 1
        Dim unitPrice As Decimal

        ' Validate if amountTxt contains a valid decimal
        If Not Decimal.TryParse(amountTxt.Text, unitPrice) Then
            MessageBox.Show("Invalid amount entered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim totalPrice As Decimal = quantity * unitPrice ' Calculate total price
        Dim selectedRows As New List(Of DataGridViewRow)

        ' Loop through all rows in the DataGridView to find checked rows
        For Each row As DataGridViewRow In dgv1.Rows
            Dim checkboxChecked As Boolean = Convert.ToBoolean(row.Cells("replace").Value)
            If checkboxChecked Then
                selectedRows.Add(row)
            End If
        Next

        If selectedRows.Count > 0 Then
            ' Loop through all selected rows and insert records
            For Each row As DataGridViewRow In selectedRows
                Dim replaceType As String = row.Cells("test_type").Value.ToString()
                Dim labid As String = row.Cells("labid").Value.ToString()
                Dim newlabid As String = row.Cells("newlabid").Value.ToString()

                ' Insert the new record for each selected row
                InsertRecord(facCode, soaNumber, replaceType, purchaseDate, quantity, unitPrice, totalPrice, labid, newlabid)

                ' Update replacement table, setting replacement to "REPLACED"
                updateRecord(labid, soaNumber)
            Next

            MessageBox.Show("Insert Success!")
            FilterDataGrid(facCode)

            Me.DialogResult = DialogResult.OK
            Me.Close()


            ' Clear checkboxes after processing
            For Each row As DataGridViewRow In dgv1.Rows
                row.Cells("replace").Value = False
            Next
        Else
            MessageBox.Show("No checkboxes are selected. Please select at least one record to add.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub updateRecord(labid As String, remarks As String)
        Dim query2 As String = "UPDATE replacement SET replacement = 'REPLACED', remarks = ? WHERE labid = ?"

        Using conn As New OdbcConnection("DSN=dashboard")
            conn.Open()
            Using cmd As New OdbcCommand(query2, conn)
                cmd.Parameters.AddWithValue("@remarks", remarks)
                cmd.Parameters.AddWithValue("@labid", labid)

                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                If rowsAffected > 0 Then
                    'MessageBox.Show("Update Success!")
                Else
                    MessageBox.Show("No records updated. LabID not found.")
                End If
            End Using
        End Using
    End Sub

    ' Find column index by name (case-insensitive)
    Private Function GetColumnIndexByName(grid As DataGridView, columnName As String) As Integer
        For Each col As DataGridViewColumn In grid.Columns
            If String.Compare(col.Name, columnName, True) = 0 Then
                Return col.Index
            End If
        Next
        Return -1 ' Column not found
    End Function

    ' Then in your event handler:
    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv1.CellValueChanged
        Dim replaceColIndex As Integer = GetColumnIndexByName(dgv1, "replace")
        If replaceColIndex >= 0 AndAlso e.ColumnIndex = replaceColIndex Then
            UpdateReplaceCount()
        End If
    End Sub

    ' Ensures checkbox clicks are committed immediately
    Private Sub DataGridView1_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgv1.CurrentCellDirtyStateChanged
        If dgv1.IsCurrentCellDirty Then
            dgv1.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    ' Method to count how many checkboxes are checked
    Private Sub UpdateReplaceCount()
        Dim count As Integer = 0

        For Each row As DataGridViewRow In dgv1.Rows
            If Not row.IsNewRow AndAlso Convert.ToBoolean(row.Cells("replace").Value) = True Then
                count += 1
            End If
        Next

        replaceCountTxt.Text = count.ToString()
    End Sub

End Class
