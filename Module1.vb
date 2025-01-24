Imports System.Data.Odbc
Module Module1
    Public da As OdbcDataAdapter
    Public ds As DataSet
    Public str As String
    Public conn As New OdbcConnection("DSN=dashboard")
    Public dr As OdbcDataReader
    Public table As New DataTable
    Public cmd As New OdbcCommand
    Public builder As New OdbcCommandBuilder

    Public Oracon As New OracleConnection
    Public oraCmd As New OracleCommand
    Public oraDa As New OracleDataAdapter

    'Public Sub connection()
    '    If conn.State = ConnectionState.Closed Then
    '        conn.Open()
    '    End If
    'End Sub
    Public Sub connection()
        Try
            ' Initialize if conn is not already set
            If conn Is Nothing Then
                conn = New OdbcConnection("DSN=dashboard")
            End If

            ' Open the connection if it is closed
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
        Catch ex As Exception
            MessageBox.Show("Error opening database connection: " & ex.Message)
        End Try
    End Sub


End Module
