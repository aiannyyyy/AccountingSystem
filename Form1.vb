Imports System.Globalization
Imports System.Data.Odbc
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'userLbl.Text = "Welcome, " + Login.userTxtBox.Text


        UpdateTime()

        ' Optionally, set a timer to update the time every second
        Dim timer As New Timer()
        timer.Interval = 1000 ' Update every second
        AddHandler timer.Tick, AddressOf Timer1_Tick
        timer.Start()


        'loaddgv1()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ' Update the label with the current time
        UpdateTime()
    End Sub

    Private Sub UpdateTime()
        ' Get the current time
        Dim now As DateTime = DateTime.Now

        ' Format the date and time with timezone info
        ' Note: PST is a fixed time zone; you might need to handle daylight saving time or other variations.
        Dim formattedTime As String = now.ToString("MMMM d, yyyy h:mm:ss tt") & " PST"

        ' Update the label's text
        dtimeLbl.Text = formattedTime
    End Sub

    Public Sub loaddgv1()
        Call connection()
        Dim query As String = "
    SELECT 
        fd.HospitalName,
        mt.DueDate,
        pd.AmountPaid,
        mt.Status
    FROM 
        MainTable mt
        JOIN FacilityDetails fd ON mt.FacilityID = fd.FacilityID
        JOIN TransactionType tt ON mt.TransactionTypeID = tt.TransactionTypeID
        LEFT JOIN PaymentDetails pd ON mt.PaymentDetailsID = pd.PaymentDetailsID
        LEFT JOIN TaxDetails td ON mt.TaxDetailsID = td.TaxDetailsID"

        da = New OdbcDataAdapter(query, conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds)
        dgv1.DataSource = ds.Tables(0).DefaultView
    End Sub
End Class
