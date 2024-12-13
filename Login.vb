Imports System.Data.Odbc
Public Class Login
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Login()
        Dim cmd As OdbcCommand
        Call connection()
        Dim query As String = "SELECT * FROM user WHERE username = '" & userTxt.Text & "' AND password = '" & pwTxt.Text & "'"
        cmd = New OdbcCommand(query, conn)
        dr = cmd.ExecuteReader()

        If dr.HasRows Then
            dr.Read() ' Move to the first row
            Dim userName As String = dr("position").ToString() ' Assuming 'position' is the correct column for the user's role/name
            Dim fullname As String = dr("name").ToString()
            MsgBox("Login Successful. Welcome, " & userName & "!")

            If userName = "Administrator" OrElse userName = "MIS OFFICER" OrElse userName = "FIRST VERIFIER" Then
                Form1.Show()
                Me.Hide()
            ElseIf userName = "ACCOUNTANT" OrElse userName = "ACCOUNTING ASSISTANT" Then
                Form1.Show()
                Me.Hide()
            End If
        Else
            MsgBox("Login Failed. Username or password is incorrect.")
            'pwTxt.Clear() ' Clear the password textbox
        End If

        dr.Close() ' Close the data dr
        cmd.Dispose() ' Dispose of the command object
    End Sub
End Class