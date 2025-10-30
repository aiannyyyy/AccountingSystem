Imports System.Data.Odbc
Public Class QuantityForm
    Private connString As String = "DSN=dashboard"
    Private _currentSOANumber As String

    Public Sub New(currentSOANumber As String)
        InitializeComponent()
        _currentSOANumber = currentSOANumber
    End Sub

    Private Sub QuantityForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        totalTxt.Enabled = False
        totalTxt2.Enabled = False

        soaTxt.Text = _currentSOANumber
    End Sub

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

    Private Sub NumbersOnly_KeyPress(sender As Object, e As KeyPressEventArgs) _
    Handles qty3_1.KeyPress, qty3_2.KeyPress, qty3_3.KeyPress, qty3_4.KeyPress,
            qty3_5.KeyPress, qty4_1.KeyPress, qty4_2.KeyPress, qty4_3.KeyPress,
            qty4_4.KeyPress, qty4_5.KeyPress, price3_1.KeyPress, price3_2.KeyPress, price3_3.KeyPress, price3_4.KeyPress,
            price3_5.KeyPress, price4_1.KeyPress, price4_2.KeyPress, price4_3.KeyPress,
            price4_4.KeyPress, price4_5.KeyPress

        ' Allow only digits, backspace, and one decimal point
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        End If

        ' Prevent more than one decimal point
        Dim txt As TextBox = CType(sender, TextBox)
        If e.KeyChar = "."c AndAlso txt.Text.Contains(".") Then
            e.Handled = True
        End If
    End Sub

    Public Sub calculateAll()
        Try

            ' Get quantity values from textboxes
            Dim q1 As Decimal = If(Decimal.TryParse(qty3_1.Text, q1), q1, 0)
            Dim q2 As Decimal = If(Decimal.TryParse(qty3_2.Text, q2), q2, 0)
            Dim q3 As Decimal = If(Decimal.TryParse(qty3_3.Text, q3), q3, 0)
            Dim q4 As Decimal = If(Decimal.TryParse(qty3_4.Text, q4), q4, 0)
            Dim q5 As Decimal = If(Decimal.TryParse(qty3_5.Text, q5), q5, 0)

            ' Get total3 and total4 values (user input)
            Dim t1 As Decimal = If(Decimal.TryParse(price3_1.Text, t1), t1, 0)
            Dim t2 As Decimal = If(Decimal.TryParse(price3_2.Text, t2), t2, 0)
            Dim t3 As Decimal = If(Decimal.TryParse(price3_3.Text, t3), t3, 0)
            Dim t4 As Decimal = If(Decimal.TryParse(price3_4.Text, t4), t4, 0)
            Dim t5 As Decimal = If(Decimal.TryParse(price3_5.Text, t4), t5, 0)

            ' Calculate totals (qty * price/constant)
            Dim calcTotal1 As Decimal = q1 * t1
            Dim calcTotal2 As Decimal = q2 * t2
            Dim calcTotal3 As Decimal = q3 * t3
            Dim calcTotal4 As Decimal = q4 * t4
            Dim calcTotal5 As Decimal = q5 * t5

            ' Display calculated totals in textboxes
            price3_1.Text = calcTotal1.ToString("F2")
            price3_2.Text = calcTotal2.ToString("F2")
            price3_3.Text = calcTotal3.ToString("F2")
            price3_4.Text = calcTotal4.ToString("F2")
            price3_5.Text = calcTotal5.ToString("F2")

            ' Calculate and display grand total
            Dim grandTotal As Decimal = calcTotal1 + calcTotal2 + calcTotal3 + calcTotal4 + calcTotal5
            totalTxt.Text = grandTotal.ToString("F2")

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Public Sub calculateAll2()
        Try

            ' Get quantity values from textboxes
            Dim q1 As Decimal = If(Decimal.TryParse(qty4_1.Text, q1), q1, 0)
            Dim q2 As Decimal = If(Decimal.TryParse(qty4_2.Text, q2), q2, 0)
            Dim q3 As Decimal = If(Decimal.TryParse(qty4_3.Text, q3), q3, 0)
            Dim q4 As Decimal = If(Decimal.TryParse(qty4_4.Text, q4), q4, 0)
            Dim q5 As Decimal = If(Decimal.TryParse(qty4_5.Text, q5), q5, 0)

            ' Get total3 and total4 values (user input)
            Dim t1 As Decimal = If(Decimal.TryParse(price4_1.Text, t1), t1, 0)
            Dim t2 As Decimal = If(Decimal.TryParse(price4_2.Text, t2), t2, 0)
            Dim t3 As Decimal = If(Decimal.TryParse(price4_3.Text, t3), t3, 0)
            Dim t4 As Decimal = If(Decimal.TryParse(price4_4.Text, t4), t4, 0)
            Dim t5 As Decimal = If(Decimal.TryParse(price4_5.Text, t4), t5, 0)

            ' Calculate totals (qty * price/constant)
            Dim calcTotal1 As Decimal = q1 * t1
            Dim calcTotal2 As Decimal = q2 * t2
            Dim calcTotal3 As Decimal = q3 * t3
            Dim calcTotal4 As Decimal = q4 * t4
            Dim calcTotal5 As Decimal = q5 * t5

            ' Display calculated totals in textboxes
            price4_1.Text = calcTotal1.ToString("F2")
            price4_2.Text = calcTotal2.ToString("F2")
            price4_3.Text = calcTotal3.ToString("F2")
            price4_4.Text = calcTotal4.ToString("F2")
            price4_5.Text = calcTotal5.ToString("F2")

            ' Calculate and display grand total
            Dim grandTotal As Decimal = calcTotal1 + calcTotal2 + calcTotal3 + calcTotal4 + calcTotal5
            totalTxt2.Text = grandTotal.ToString("F2")

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub
    Public Sub clearAll()
        qty3_1.Clear()
        qty3_2.Clear()
        qty3_3.Clear()
        qty3_4.Clear()
        qty3_1.Clear()
        price3_1.Clear()
        price3_2.Clear()
        price3_3.Clear()
        price3_4.Clear()
        price3_5.Clear()
        totalTxt.Clear()
    End Sub

    Public Sub clearAll2()
        qty4_1.Clear()
        qty4_2.Clear()
        qty4_3.Clear()
        qty4_4.Clear()
        qty4_1.Clear()
        price4_1.Clear()
        price4_2.Clear()
        price4_3.Clear()
        price4_4.Clear()
        price4_5.Clear()
        totalTxt2.Clear()
    End Sub

    Private Sub computeBtn1_Click(sender As Object, e As EventArgs) Handles computeBtn1.Click
        calculateAll()
    End Sub

    Private Sub clrButton1_Click(sender As Object, e As EventArgs) Handles clrButton1.Click
        clearAll()
    End Sub

    Private Sub computeBtn2_Click(sender As Object, e As EventArgs) Handles computeBtn2.Click
        calculateAll2()
    End Sub

    Private Sub clrButton2_Click(sender As Object, e As EventArgs) Handles clrButton2.Click
        clearAll2()
    End Sub

    Private Function InsertRecord(soa_txt As String,
                                  qty3_1 As Integer, qty3_2 As Integer, qty3_3 As Integer, qty3_4 As Integer, qty3_5 As Integer,
                                  price3_1 As Double, price3_2 As Double, price3_3 As Double, price3_4 As Double, price3_5 As Double,
                                  qty4_1 As Integer, qty4_2 As Integer, qty4_3 As Integer, qty4_4 As Integer, qty4_5 As Integer,
                                  price4_1 As Double, price4_2 As Double, price4_3 As Double, price4_4 As Double, price4_5 As Double,
                                  total1 As Double, total2 As Double) As Boolean

        ' ✅ FIXED: Added table name and corrected SQL syntax
        Dim insertQuery As String = "INSERT INTO quantity " &
            "(soa_txt, qty3_1, qty3_2, qty3_3, qty3_4, qty3_5, price3_1, price3_2, price3_3, price3_4, price3_5, " &
            "qty4_1, qty4_2, qty4_3, qty4_4, qty4_5, price4_1, price4_2, price4_3, price4_4, price4_5, total1, total2) " &
            "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"

        Try
            Using conn As New OdbcConnection(connString)
                conn.Open()
                Using cmd As New OdbcCommand(insertQuery, conn)
                    ' Add parameters in correct order
                    cmd.Parameters.AddWithValue("@soa_txt", soa_txt)

                    cmd.Parameters.AddWithValue("@qty3_1", qty3_1)
                    cmd.Parameters.AddWithValue("@qty3_2", qty3_2)
                    cmd.Parameters.AddWithValue("@qty3_3", qty3_3)
                    cmd.Parameters.AddWithValue("@qty3_4", qty3_4)
                    cmd.Parameters.AddWithValue("@qty3_5", qty3_5)

                    cmd.Parameters.AddWithValue("@price3_1", price3_1)
                    cmd.Parameters.AddWithValue("@price3_2", price3_2)
                    cmd.Parameters.AddWithValue("@price3_3", price3_3)
                    cmd.Parameters.AddWithValue("@price3_4", price3_4)
                    cmd.Parameters.AddWithValue("@price3_5", price3_5)

                    cmd.Parameters.AddWithValue("@qty4_1", qty4_1)
                    cmd.Parameters.AddWithValue("@qty4_2", qty4_2)
                    cmd.Parameters.AddWithValue("@qty4_3", qty4_3)
                    cmd.Parameters.AddWithValue("@qty4_4", qty4_4)
                    cmd.Parameters.AddWithValue("@qty4_5", qty4_5)

                    cmd.Parameters.AddWithValue("@price4_1", price4_1)
                    cmd.Parameters.AddWithValue("@price4_2", price4_2)
                    cmd.Parameters.AddWithValue("@price4_3", price4_3)
                    cmd.Parameters.AddWithValue("@price4_4", price4_4)
                    cmd.Parameters.AddWithValue("@price4_5", price4_5)

                    cmd.Parameters.AddWithValue("@total1", total1)
                    cmd.Parameters.AddWithValue("@total2", total2)

                    cmd.ExecuteNonQuery()
                    Return True
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error inserting record: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function


    Private Sub addButton_Click(sender As Object, e As EventArgs) Handles addButton.Click
        ' Helper function to safely convert TextBox values
        Dim getInt = Function(txt As TextBox) As Integer
                         If String.IsNullOrWhiteSpace(txt.Text) Then
                             Return 0
                         Else
                             Return Convert.ToInt32(txt.Text)
                         End If
                     End Function

        Dim getDouble = Function(txt As TextBox) As Double
                            If String.IsNullOrWhiteSpace(txt.Text) Then
                                Return 0.0
                            Else
                                Return Convert.ToDouble(txt.Text)
                            End If
                        End Function

        ' If soaTxt.Text = "Current SOA Number: 202503387"
        Dim soaNumberOnly As String = soaTxt.Text.Replace("Current SOA Number: ", "").Trim()

        Dim success = InsertRecord(
        soa_txt:=soaNumberOnly,
        qty3_1:=getInt(qty3_1),
        qty3_2:=getInt(qty3_2),
        qty3_3:=getInt(qty3_3),
        qty3_4:=getInt(qty3_4),
        qty3_5:=getInt(qty3_5),
        price3_1:=getDouble(price3_1),
        price3_2:=getDouble(price3_2),
        price3_3:=getDouble(price3_3),
        price3_4:=getDouble(price3_4),
        price3_5:=getDouble(price3_5),
        qty4_1:=getInt(qty4_1),
        qty4_2:=getInt(qty4_2),
        qty4_3:=getInt(qty4_3),
        qty4_4:=getInt(qty4_4),
        qty4_5:=getInt(qty4_5),
        price4_1:=getDouble(price4_1),
        price4_2:=getDouble(price4_2),
        price4_3:=getDouble(price4_3),
        price4_4:=getDouble(price4_4),
        price4_5:=getDouble(price4_5),
        total1:=getDouble(totalTxt),
        total2:=getDouble(totalTxt2)
    )

        If success Then
            MessageBox.Show("Record added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            clearAll()
            clearAll2()
        End If
    End Sub
End Class