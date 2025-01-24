Imports System.Data.Odbc

Public Class ReplacementForm
    Private connString As String = "DSN=dashboard"

    Private _currentSOANumber As String
    Private _nextSOANumber As String

    ' Create an instance of Pos form (assuming it's in the same project)
    Dim Pos As New Pos()

    ' Constructor that accepts both the current And Next SOA numbers
    Public Sub New(currentSOANumber As String, nextSOANumber As String)
        InitializeComponent()
        _currentSOANumber = currentSOANumber
        _nextSOANumber = nextSOANumber
        Me.connString = connString
    End Sub

    Private Sub Replacement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize the form when it's loaded
        dtpicker2.Value = Date.Now
        codeTxt.Text = Pos.codeTxt.Text
        soaTxt.Text = _nextSOANumber
        replaceCombo.Items.AddRange({"CONTAMINATED", "INSUFFICIENT"})
        loaddgv() ' Load the DataGridView with existing replacement data
    End Sub

    ' Loads data from the database into the DataGridView
    Public Sub loaddgv()
        Call connection()
        Dim query As String = "SELECT * FROM replacement_type ORDER BY purchase_date DESC"

        Dim dtAdapter As New OdbcDataAdapter(query, connString)
        Dim dtDatatable As New DataTable

        Try
            dtAdapter.Fill(dtDatatable)
            dgv1.DataSource = dtDatatable
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message)
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
    Private Sub InsertRecord(facCode As String, soaNumber As String, replaceType As String, purchaseDate As Date, quantity As Integer, unitPrice As Decimal, totalPrice As Decimal)
        ' Ensure quantity is Integer and unitPrice is Decimal
        Dim query As String = $"INSERT INTO replacement_type (fac_code, soa_number, replace_type, purchase_date, quantity, unit_price, total_price) " &
                          $"VALUES ('{facCode}', '{soaNumber}', '{replaceType}', '{purchaseDate.ToString("yyyy-MM-dd")}', {quantity}, {unitPrice}, {totalPrice})"
        ExecuteQuery(query)
    End Sub


    ' Event handler for the Add Button to insert a new record
    Private Sub addButton_Click(sender As Object, e As EventArgs) Handles addButton.Click
        Dim facCode As String = codeTxt.Text
        Dim soaNumber As String = soaTxt.Text
        Dim replaceType As String = replaceCombo.SelectedItem.ToString
        Dim purchaseDate As Date = dtpicker2.Value
        Dim quantity As Integer = Convert.ToInt32(quantityTxt.Text) ' Convert quantity to Integer
        Dim unitPrice As Decimal = Convert.ToDecimal(amountTxt.Text) ' Convert unitPrice to Decimal
        Dim totalPrice As Decimal = quantity * unitPrice ' Calculate totalPrice

        ' Insert the new record
        InsertRecord(facCode, soaNumber, replaceType, purchaseDate, quantity, unitPrice, totalPrice)
        MessageBox.Show("Insert Success!")
        loaddgv() ' Reload the DataGridView with updated data

    End Sub
End Class
