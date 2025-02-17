Imports System.Data.Odbc
Public Class Login
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        userTxt.Text = "Username"
        userTxt.ForeColor = Color.DarkGray
        pwTxt.Text = "Password"
        pwTxt.ForeColor = Color.DarkGray

        userTxt.SetOnGotFocus()
        Me.AcceptButton = loginBtn
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
                Pos.Show()
                Me.Hide()
            ElseIf userName = "ACCOUNTANT" OrElse userName = "ACCOUNTING ASSISTANT" Then
                Pos.Show()
                Me.Hide()
            ElseIf userName = "CASHIER" OrElse userName = "COLLECTIONS" Then
                Payments.Show()
                Me.Hide()
            End If
        Else
            MsgBox("Login Failed. Username or password is incorrect.")
            pwTxt.Clear() ' Clear the password textbox
        End If

        dr.Close() ' Close the data dr
        cmd.Dispose() ' Dispose of the command object
    End Sub

    Private Sub pwTxt_GotFocus(sender As Object, e As EventArgs) Handles pwTxt.GotFocus
        If pwTxt.Text = "Password" Then
            pwTxt.Text = ""
            pwTxt.PasswordChar = "*"
            pwTxt.ForeColor = Color.Black
        End If
    End Sub

    Private Sub pwTxt_LostFocus(sender As Object, e As EventArgs) Handles pwTxt.LostFocus
        If pwTxt.Text = "" Then
            pwTxt.Text = "Password"
            pwTxt.PasswordChar = "*"
            pwTxt.ForeColor = Color.DarkGray
        End If
    End Sub

    Private Sub userTxt_GotFocus(sender As Object, e As EventArgs) Handles userTxt.GotFocus
        If userTxt.Text = "Username" Then
            userTxt.Text = ""
            userTxt.ForeColor = Color.Black
        End If
    End Sub

    Private Sub userTxt_LostFocus(sender As Object, e As EventArgs) Handles userTxt.LostFocus
        If userTxt.Text = "" Then
            userTxt.Text = "Username"
            userTxt.ForeColor = Color.DarkGray
        End If
    End Sub

    Private Sub loginBtn_Click(sender As Object, e As EventArgs) Handles loginBtn.Click
        Login()
    End Sub
End Class