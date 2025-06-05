Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine

Public Class Pos
    Private connString As String = "DSN=dashboard"
    Private conn As New OdbcConnection()
    Private isFirstInput As Boolean = True

    ' Public property to store the fullname
    Public Property FullName As String


    Private addCount As Integer = 0

    Private Sub Pos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        replaceCombo.Items.AddRange({"CONTAMINATED", "INSUFFICIENT"})

        'conn.ConnectionString = "DSN=dashboard" ' Adjust the connection string to your DSN
        Try
            ' Instantiate the connection object
            conn = New OdbcConnection()

            ' Set the connection string
            conn.ConnectionString = "DSN=dashboard" ' Adjust this to match your DSN setup

            ' Test the connection (optional)
            conn.Open()
            'MessageBox.Show("Database connection established successfully!")
            'conn.Close()
        Catch ex As Exception
            MessageBox.Show("Failed to connect to the database: " & ex.Message)
        End Try

        Oracon.ConnectionString = "Data Source=(DESCRIPTION= (ADDRESS=(PROTOCOL=TCP)(HOST=10.1.1.191)(PORT=1521)) (CONNECT_DATA=(SERVICE_NAME=PROD)));User Id=user1;Password=newborn"

        dtpicker1.Value = Date.Now
        dtpicker2.Value = Date.Now

        loaddgv()
        ordertext()

        ' Display the fullname on the label when the form loads
        lblshow.Text = Login.userTxt.Text

        replaceCombo.Enabled = False

        codeTxt.SetOnGotFocus()

        remLbl.Visible = False
        remBox.Visible = False

        'Initialize the replaceTxt to show initial count (0)
        replaceTxt.Text = addCount.ToString()

        replaceCombo.Visible = False
        replaceAdd.Visible = False
        replaceTxt.Visible = False
        replaceCount.Enabled = False

        typeText.Visible = False

        For Each column As DataGridViewColumn In dgv1.Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        adsTxt.Enabled = False
        totalTxt.Enabled = False

        dgv1.ColumnHeadersHeight = 35 ' Set header height to 50 pixels

        dgv1.Columns("soa_txt").Visible = False ' Hide the column
        dgv1.Columns("sub_amount").Visible = False ' Hide the column
        dgv1.Columns("fac_type").Visible = False ' Hide the column
        dgv1.Columns("replace_type").Visible = False ' Hide the column



        excessTxt.Enabled = False

        Timer1.Interval = 1000 ' Update every second
        Timer1.Start() ' Start the timerTimer1.Interval = 1000 ' Update every second
        Timer1.Start() ' Start the timer
    End Sub

    Public Sub ordertext()
        brochureTxt.Enabled = False
        posterTxt.Enabled = False
        dryingTxt.Enabled = False
        replaceTxt.Enabled = False
    End Sub

    'Public Sub loaddgv()
    '    Call connection()
    '    da = New OdbcDataAdapter("Select * from acccounting order by soa_date desc", conn)
    '    ds = New DataSet
    '    ds.Clear()
    '    da.Fill(ds, "acccounting")
    '    dgv1.DataSource = ds.Tables("acccounting").DefaultView
    'End Sub

    'Public Sub loaddgv()
    '    Try
    '        Call connection()
    '        Dim query As String = "SELECT * FROM acccounting ORDER BY soa_date DESC"
    '        Dim da As New OdbcDataAdapter(query, conn)
    '        Dim ds As New DataSet()
    '        ds.Clear()
    '        da.Fill(ds, "acccounting")
    '        dgv1.DataSource = ds.Tables("acccounting").DefaultView
    '    Catch ex As Exception
    '        MessageBox.Show("Error loading data: " & ex.Message)
    '    End Try
    'End Sub

    'Public Sub loaddgv()
    '    Try
    '        Call connection()
    '        Dim query As String = "SELECT * FROM acccounting ORDER BY soa_date DESC"
    '        Dim da As New OdbcDataAdapter(query, conn)
    '        Dim ds As New DataSet()
    '        ds.Clear()
    '        da.Fill(ds, "acccounting")
    '        dgv1.DataSource = ds.Tables("acccounting").DefaultView

    '    Catch ex As Exception
    '        MessageBox.Show("Error loading data: " & ex.Message)
    '    End Try
    'End Sub

    Public Sub loaddgv()
        Try
            Call connection()
            Dim query As String = "SELECT * FROM acccounting WHERE balance <> 0 ORDER BY soa_date DESC"
            Dim da As New OdbcDataAdapter(query, conn)
            Dim ds As New DataSet()
            ds.Clear()
            da.Fill(ds, "acccounting")
            dgv1.DataSource = ds.Tables("acccounting").DefaultView

            ' Disable all rows by making them read-only
            For Each row As DataGridViewRow In dgv1.Rows
                row.ReadOnly = True ' Make each row read-only
            Next

        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message)
        End Try
    End Sub


    'Private Sub codeTxt_TextChanged(sender As Object, e As EventArgs) Handles codeTxt.TextChanged
    '    If String.IsNullOrEmpty(codeTxt.Text) Then
    '        cleartxt()
    '        Return
    '    End If

    '    da = New OdbcDataAdapter("select * from acccounting where fac_code like '%" & codeTxt.Text & "%' order by purchase_date desc", conn)

    '    ds = New DataSet
    '    da.Fill(ds, "acccounting")
    '    dgv1.DataSource = ds.Tables("acccounting").DefaultView


    '    Try
    '        If Oracon.State <> ConnectionState.Open Then
    '            Oracon.Open()
    '        End If

    '        ' Correct the query to join the tables properly and use parameterized query
    '        'Dim query As String = "select fac_code, fac_name, type2 from facility_data where fac_code = ?"

    '        Dim query As String = "SELECT 
    '                                REF_PROVIDER_ADDRESS.PROVIDERID, 
    '                                REF_PROVIDER_ADDRESS.CITY, 
    '                                REF_PROVIDER_ADDRESS.COUNTY, 
    '                                REF_PROVIDER_ADDRESS.DESCR1, 
    '                                REF_TYPE.DESCR
    '                            FROM 
    '                                PHMSDS.REF_PROVIDER_ADDRESS REF_PROVIDER_ADDRESS
    '                                INNER JOIN PHMSDS.REF_PROVIDERTYPE REF_PROVIDERTYPE 
    '                                    ON REF_PROVIDER_ADDRESS.PROVIDERID = REF_PROVIDERTYPE.PROVIDERID
    '                                INNER JOIN PHMSDS.REF_TYPE REF_TYPE 
    '                                    ON REF_PROVIDERTYPE.TYPE = REF_TYPE.TYPE
    '                            WHERE 
    '                                REF_PROVIDER_ADDRESS.COUNTY = 'QUEZON' AND
    '                                REF_PROVIDER_ADDRESS.CITY IN (
    '                                    'UNISAN', 'TAGKAWAYAN', 'SAN FRANCISCO', 'PLARIDEL', 
    '                                    'PEREZ', 'PADRE BURGOS', 'MULANAY', 'MAUBAN', 
    '                                    'LOPEZ', 'GUMACA', 'GUINAYANGAN', 'GENERAL NAKAR', 
    '                                    'GENERAL LUNA', 'CATANAUAN', 'CALAUAG', 'BURDEOS', 
    '                                    'BUENAVISTA', 'ALABAT', 'AGDANGAN', 'JOMALIG', 'PAGBILAO'
    '                                )
    '                            ORDER BY 
    '                                REF_PROVIDER_ADDRESS.PROVIDERID ASC"


    '        Using cmd As New OdbcCommand(query, conn)
    '            cmd.Parameters.AddWithValue("PROVIDERID", codeTxt.Text)

    '            Using rd As OdbcDataReader = cmd.ExecuteReader()
    '                If rd.Read() Then
    '                    ' Ensure the UI update is done on the main thread
    '                    Me.Invoke(Sub()
    '                                  codeTxt.Text = rd("PROVIDERID").ToString()
    '                                  nameBox.Text = rd("DESCR1").ToString()
    '                                  Dim term As Integer

    '                                  Select Case rd("DESCR").ToString()
    '                                      Case "LYING-IN GOV'T", "LGU", "RHU", "DOH", "CITY HEALTH UNIT"
    '                                          term = 60
    '                                      Case "PRIVATE HOSPITAL", "PHYSICIAN", "NP-HOSPITAL", "LYING-IN PRIVATE", "OTHERS"
    '                                          term = 45
    '                                  End Select

    '                                  termBox.Text = term.ToString()

    '                                  ' Get the purchase date from wherever you have it stored
    '                                  Dim purchaseDate As Date = Date.Today ' Example purchase date is today

    '                                  ' Calculate the due date
    '                                  Dim dueDate As Date = purchaseDate.AddDays(term)

    '                                  ' Display the due date in dueTxt
    '                                  dtpicker1.Value = dueDate.ToShortDateString() ' Adjust date format as needed
    '                              End Sub)
    '                Else
    '                    Me.Invoke(Sub()
    '                                  nameBox.Clear()
    '                                  termBox.Clear()
    '                                  dtpicker1.Value = Date.Now.ToShortDateString() ' Set current date if no record is found
    '                              End Sub)
    '                End If
    '            End Using
    '        End Using
    '    Catch ex As Exception
    '        MessageBox.Show("An error occurred: " & ex.Message)
    '    End Try

    '    UpdateDateTimePicker2()
    'End Sub

    'Private Sub codeTxt_TextChanged(sender As Object, e As EventArgs) Handles codeTxt.TextChanged
    '    If String.IsNullOrEmpty(codeTxt.Text) Then
    '        cleartxt()
    '        Return
    '    End If

    '    ' Fetch data from the ODBC source (conn)
    '    Try
    '        If conn.State <> ConnectionState.Open Then
    '            conn.Open()
    '        End If

    '        Dim odbcQuery As String = "SELECT * FROM acccounting WHERE fac_code = ? ORDER BY purchase_date DESC"
    '        Using odbcCmd As New OdbcCommand(odbcQuery, conn)
    '            odbcCmd.Parameters.AddWithValue("fac_code", codeTxt.Text)

    '            Dim odbcAdapter As New OdbcDataAdapter(odbcCmd)
    '            Dim odbcDataSet As New DataSet
    '            odbcAdapter.Fill(odbcDataSet, "acccounting")
    '            dgv1.DataSource = odbcDataSet.Tables("acccounting").DefaultView
    '        End Using
    '    Catch ex As Exception
    '        MessageBox.Show("ODBC Error: " & ex.Message)
    '    End Try

    '    Try
    '        ' Open the Oracle connection if not already open
    '        If Oracon.State <> ConnectionState.Open Then
    '            Oracon.Open()
    '        End If

    '        ' Define the query to fetch provider information
    '        Dim oracleQuery As String = "
    '    SELECT 
    '        REF_PROVIDER_ADDRESS.PROVIDERID, 
    '        REF_PROVIDER_ADDRESS.CITY, 
    '        REF_PROVIDER_ADDRESS.COUNTY, 
    '        REF_PROVIDER_ADDRESS.DESCR1, 
    '        REF_TYPE.DESCR
    '    FROM 
    '        PHMSDS.REF_PROVIDER_ADDRESS 
    '    INNER JOIN 
    '        PHMSDS.REF_PROVIDERTYPE 
    '        ON REF_PROVIDER_ADDRESS.PROVIDERID = REF_PROVIDERTYPE.PROVIDERID
    '    INNER JOIN 
    '        PHMSDS.REF_TYPE 
    '        ON REF_PROVIDERTYPE.TYPE = REF_TYPE.TYPE
    '    WHERE 
    '        REF_PROVIDER_ADDRESS.PROVIDERID = :PROVIDERID
    '    ORDER BY 
    '        REF_PROVIDER_ADDRESS.PROVIDERID ASC"

    '        ' Create and configure the Oracle command
    '        Using oracleCmd As New OracleCommand(oracleQuery, Oracon)
    '            ' Bind the parameter securely
    '            oracleCmd.Parameters.Add(New OracleParameter("PROVIDERID", codeTxt.Text.Trim()))

    '            ' Execute the query and process the results
    '            Using reader As OracleDataReader = oracleCmd.ExecuteReader()
    '                If reader.Read() Then
    '                    ' Extract and validate data from the reader
    '                    Dim providerId As String = If(Not reader.IsDBNull(0), reader("PROVIDERID").ToString(), String.Empty)
    '                    Dim city As String = If(Not reader.IsDBNull(1), reader("CITY").ToString(), String.Empty).ToUpper()
    '                    Dim county As String = If(Not reader.IsDBNull(2), reader("COUNTY").ToString(), String.Empty)
    '                    Dim descr1 As String = If(Not reader.IsDBNull(3), reader("DESCR1").ToString(), String.Empty)
    '                    Dim descr As String = If(Not reader.IsDBNull(4), reader("DESCR").ToString(), String.Empty)

    '                    ' Determine the term based on descr
    '                    Dim term As Integer = If(
    '                {"LYING-IN GOV'T", "LGU", "RHU", "DOH", "CITY HEALTH UNIT", "OTHERS"}.Contains(descr),
    '                60,
    '                45
    '            )

    '                    ' Calculate the due date based on the term
    '                    Dim purchaseDate As Date = Date.Today ' Replace with actual purchase date if available
    '                    Dim dueDate As Date = purchaseDate.AddDays(term)

    '                    ' Update the UI on the main thread
    '                    Me.Invoke(Sub()
    '                                  codeTxt.Text = providerId
    '                                  nameBox.Text = descr1
    '                                  termBox.Text = term.ToString()
    '                                  dtpicker1.Value = dueDate
    '                                  typeText.Text = descr

    '                                  ' Check the lopezCheck if conditions are met
    '                                  Dim targetCounty As String = "QUEZON"
    '                                  Dim targetCities As HashSet(Of String) = New HashSet(Of String) From {
    '                              "UNISAN", "TAGKAWAYAN", "SAN FRANCISCO", "PLARIDEL",
    '                              "PEREZ", "PADRE BURGOS", "MULANAY", "MAUBAN",
    '                              "LOPEZ", "GUMACA", "GUINAYANGAN", "GENERAL NAKAR",
    '                              "GENERAL LUNA", "CATANAUAN", "CALAUAG", "BURDEOS",
    '                              "BUENAVISTA", "ALABAT", "AGDANGAN", "JOMALIG", "PAGBILAO"
    '                          }

    '                                  lopezCheck.Checked = (county = targetCounty AndAlso targetCities.Contains(city))
    '                              End Sub)
    '                Else
    '                    ' No matching record found
    '                    Me.Invoke(Sub()
    '                                  nameBox.Clear()
    '                                  termBox.Clear()
    '                                  dtpicker1.Value = Date.Now
    '                                  lopezCheck.Checked = False
    '                              End Sub)
    '                End If
    '            End Using
    '        End Using
    '    Catch ex As OracleException
    '        MessageBox.Show("Oracle Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Catch ex As Exception
    '        MessageBox.Show("An unexpected error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        ' Ensure the connection is closed
    '        If Oracon.State = ConnectionState.Open Then
    '            Oracon.Close()
    '        End If
    '    End Try

    '    UpdateDateTimePicker2()
    'End Sub

    'Private Sub codeTxt_TextChanged(sender As Object, e As EventArgs) Handles codeTxt.TextChanged
    '    If String.IsNullOrEmpty(codeTxt.Text) Then
    '        cleartxt()
    '        Return
    '    End If

    '    ' Fetch data from the ODBC source (conn)
    '    Try
    '        If conn.State <> ConnectionState.Open Then
    '            conn.Open()
    '        End If

    '        Dim odbcQuery As String = "SELECT * FROM acccounting WHERE fac_code = ? ORDER BY purchase_date DESC"
    '        Using odbcCmd As New OdbcCommand(odbcQuery, conn)
    '            odbcCmd.Parameters.Add(New OdbcParameter("fac_code", codeTxt.Text))

    '            Dim odbcAdapter As New OdbcDataAdapter(odbcCmd)
    '            Dim odbcDataSet As New DataSet
    '            odbcAdapter.Fill(odbcDataSet, "acccounting")
    '            dgv1.DataSource = odbcDataSet.Tables("acccounting").DefaultView

    '            ' Calculate the total excess of a facility
    '            Dim excessTotal As Decimal = 0
    '            For Each row As DataRow In odbcDataSet.Tables("acccounting").Rows
    '                If Not IsDBNull(row("excess")) Then
    '                    excessTotal += Convert.ToDecimal(row("excess"))
    '                End If
    '            Next

    '            ' Update excessTxt with the total excess value
    '            excessTxt.Text = excessTotal.ToString("F2")
    '        End Using

    '        ' Set rows to read-only if "order_type" contains "(Cancelled P.O)"
    '        For Each row As DataGridViewRow In dgv1.Rows
    '            If Not row.IsNewRow AndAlso row.Cells("order_type").Value IsNot Nothing Then
    '                Dim orderType As String = row.Cells("order_type").Value.ToString()
    '                ' Check if the order_type contains "(Cancelled P.O)"
    '                row.ReadOnly = orderType.Contains("(Cancelled SOA)")
    '            End If
    '        Next



    '    Catch ex As Exception
    '        MessageBox.Show("ODBC Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    '    Try
    '        ' Open the Oracle connection if not already open
    '        If Oracon.State <> ConnectionState.Open Then
    '            Oracon.Open()
    '        End If

    '        ' Define the query to fetch provider information
    '        Dim oracleQuery As String = "
    '    SELECT 
    '        REF_PROVIDER_ADDRESS.PROVIDERID, 
    '        REF_PROVIDER_ADDRESS.CITY, 
    '        REF_PROVIDER_ADDRESS.COUNTY, 
    '        REF_PROVIDER_ADDRESS.DESCR1, 
    '        REF_TYPE.DESCR
    '    FROM 
    '        PHMSDS.REF_PROVIDER_ADDRESS 
    '    INNER JOIN 
    '        PHMSDS.REF_PROVIDERTYPE 
    '        ON REF_PROVIDER_ADDRESS.PROVIDERID = REF_PROVIDERTYPE.PROVIDERID
    '    INNER JOIN 
    '        PHMSDS.REF_TYPE 
    '        ON REF_PROVIDERTYPE.TYPE = REF_TYPE.TYPE
    '    WHERE 
    '        REF_PROVIDER_ADDRESS.PROVIDERID = :PROVIDERID
    '    ORDER BY 
    '        REF_PROVIDER_ADDRESS.PROVIDERID ASC"

    '        ' Create and configure the Oracle command
    '        Using oracleCmd As New OracleCommand(oracleQuery, Oracon)
    '            ' Bind the parameter securely
    '            oracleCmd.Parameters.Add(New OracleParameter("PROVIDERID", codeTxt.Text.Trim()))

    '            ' Execute the query and process the results
    '            Using reader As OracleDataReader = oracleCmd.ExecuteReader()
    '                If reader.Read() Then
    '                    ' Extract and validate data from the reader
    '                    Dim providerId As String = If(Not reader.IsDBNull(0), reader("PROVIDERID").ToString(), String.Empty)
    '                    Dim city As String = If(Not reader.IsDBNull(1), reader("CITY").ToString(), String.Empty).ToUpper()
    '                    Dim county As String = If(Not reader.IsDBNull(2), reader("COUNTY").ToString(), String.Empty)
    '                    Dim descr1 As String = If(Not reader.IsDBNull(3), reader("DESCR1").ToString(), String.Empty)
    '                    Dim descr As String = If(Not reader.IsDBNull(4), reader("DESCR").ToString(), String.Empty)

    '                    If providerId = "7345" Then
    '                        descr = "NSC SOUTHERN LUZON"
    '                    End If

    '                    ' Determine the term based on descr
    '                    Dim term As Integer = If(
    '                    {"LYING-IN GOV'T", "LGU", "RHU", "DOH", "CITY HEALTH UNIT"}.Contains(descr),
    '                    60,
    '                    45
    '                )

    '                    ' Calculate the due date based on the term
    '                    Dim purchaseDate As Date = Date.Today ' Replace with actual purchase date if available
    '                    Dim dueDate As Date = purchaseDate.AddDays(term)

    '                    ' Update the UI on the main thread
    '                    Me.Invoke(Sub()
    '                                  codeTxt.Text = providerId
    '                                  nameBox.Text = descr1
    '                                  termBox.Text = term.ToString()
    '                                  dtpicker1.Value = dueDate
    '                                  typeText.Text = descr

    '                                  ' Check the lopezCheck if conditions are met
    '                                  Dim targetCounty As String = "QUEZON"
    '                                  Dim targetCities As HashSet(Of String) = New HashSet(Of String) From {
    '                                  "UNISAN", "TAGKAWAYAN", "SAN FRANCISCO", "PLARIDEL",
    '                                  "PEREZ", "PADRE BURGOS", "MULANAY", "MAUBAN",
    '                                  "LOPEZ", "GUMACA", "GUINAYANGAN", "GENERAL NAKAR",
    '                                  "GENERAL LUNA", "CATANAUAN", "CALAUAG", "BURDEOS",
    '                                  "BUENAVISTA", "ALABAT", "AGDANGAN", "JOMALIG", "PAGBILAO"
    '                              }

    '                                  lopezCheck.Checked = (county = targetCounty AndAlso targetCities.Contains(city))
    '                              End Sub)
    '                Else
    '                    ' No matching record found
    '                    Me.Invoke(Sub()
    '                                  nameBox.Clear()
    '                                  termBox.Clear()
    '                                  dtpicker1.Value = Date.Now
    '                                  lopezCheck.Checked = False
    '                              End Sub)
    '                End If
    '            End Using
    '        End Using
    '    Catch ex As OracleException
    '        MessageBox.Show("Oracle Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Catch ex As Exception
    '        MessageBox.Show("An unexpected error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        ' Ensure the connection is closed
    '        If Oracon.State = ConnectionState.Open Then
    '            Oracon.Close()
    '        End If
    '    End Try

    '    UpdateDateTimePicker2()
    'End Sub

    Private Sub ProcessCode()
        If String.IsNullOrEmpty(codeTxt.Text) Then
            loaddgv()
            cleartxt()
            Return
        End If

        ' --- ODBC Section ---
        Try
            If conn.State <> ConnectionState.Open Then
                conn.Open()
            End If

            Dim odbcQuery As String = "SELECT * FROM acccounting WHERE fac_code = ? ORDER BY purchase_date DESC"
            Using odbcCmd As New OdbcCommand(odbcQuery, conn)
                odbcCmd.Parameters.Add(New OdbcParameter("fac_code", codeTxt.Text))

                Dim odbcAdapter As New OdbcDataAdapter(odbcCmd)
                Dim odbcDataSet As New DataSet
                odbcAdapter.Fill(odbcDataSet, "acccounting")
                dgv1.DataSource = odbcDataSet.Tables("acccounting").DefaultView

                ' Calculate the total excess of a facility
                Dim excessTotal As Decimal = 0
                For Each row As DataRow In odbcDataSet.Tables("acccounting").Rows
                    If Not IsDBNull(row("excess")) Then
                        excessTotal += Convert.ToDecimal(row("excess"))
                    End If
                Next

                ' Update excessTxt with the total excess value
                excessTxt.Text = excessTotal.ToString("N2")
            End Using

            ' Set rows to read-only if "order_type" contains "(Cancelled SOA)"
            For Each row As DataGridViewRow In dgv1.Rows
                If Not row.IsNewRow AndAlso row.Cells("order_type").Value IsNot Nothing Then
                    Dim orderType As String = row.Cells("order_type").Value.ToString()
                    row.ReadOnly = orderType.Contains("(Cancelled SOA)")
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("ODBC Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ' --- Oracle Section ---
        Try
            If Oracon.State <> ConnectionState.Open Then
                Oracon.Open()
            End If

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

            Using oracleCmd As New OracleCommand(oracleQuery, Oracon)
                oracleCmd.Parameters.Add(New OracleParameter("PROVIDERID", codeTxt.Text.Trim()))

                Using reader As OracleDataReader = oracleCmd.ExecuteReader()
                    If reader.Read() Then
                        Dim providerId As String = If(Not reader.IsDBNull(0), reader("PROVIDERID").ToString(), String.Empty)
                        Dim city As String = If(Not reader.IsDBNull(1), reader("CITY").ToString(), String.Empty).ToUpper()
                        Dim county As String = If(Not reader.IsDBNull(2), reader("COUNTY").ToString(), String.Empty)
                        Dim descr1 As String = If(Not reader.IsDBNull(3), reader("DESCR1").ToString(), String.Empty)
                        Dim descr As String = If(Not reader.IsDBNull(4), reader("DESCR").ToString(), String.Empty)

                        If providerId = "7345" Then
                            descr = "NSC SOUTHERN LUZON"
                        End If

                        Dim term As Integer = If(
                        {"LYING-IN GOV'T", "LGU", "RHU", "DOH", "CITY HEALTH UNIT"}.Contains(descr),
                        60,
                        45
                    )

                        Dim purchaseDate As Date = Date.Today ' You can adjust this based on actual data
                        Dim dueDate As Date = purchaseDate.AddDays(term)

                        Me.Invoke(Sub()
                                      codeTxt.Text = providerId
                                      nameBox.Text = descr1
                                      termBox.Text = term.ToString()
                                      dtpicker1.Value = dueDate
                                      typeText.Text = descr

                                      Dim targetCounty As String = "QUEZON"
                                      Dim targetCities As HashSet(Of String) = New HashSet(Of String) From {
                            "UNISAN", "TAGKAWAYAN", "SAN FRANCISCO", "PLARIDEL",
                            "PEREZ", "PADRE BURGOS", "MULANAY", "MAUBAN",
                            "LOPEZ", "GUMACA", "GUINAYANGAN", "GENERAL NAKAR",
                            "GENERAL LUNA", "CATANAUAN", "CALAUAG", "BURDEOS",
                            "BUENAVISTA", "ALABAT", "AGDANGAN", "JOMALIG", "PAGBILAO"
                        }

                                      lopezCheck.Checked = (county = targetCounty AndAlso targetCities.Contains(city))
                                  End Sub)
                    Else
                        Me.Invoke(Sub()
                                      nameBox.Clear()
                                      termBox.Clear()
                                      dtpicker1.Value = Date.Now
                                      lopezCheck.Checked = False
                                  End Sub)
                    End If
                End Using
            End Using
        Catch ex As OracleException
            MessageBox.Show("Oracle Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An unexpected error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Oracon.State = ConnectionState.Open Then
                Oracon.Close()
            End If
        End Try

        UpdateDateTimePicker2()
    End Sub
    Private Sub brochureCheck_CheckedChanged(sender As Object, e As EventArgs) Handles brochureCheck.CheckedChanged
        If brochureCheck.Checked Then
            brochureTxt.Enabled = True
            brochureTxt.SetOnGotFocus()
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
            posterTxt.SetOnGotFocus()
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
            dryingTxt.SetOnGotFocus()
        Else
            dryingTxt.Enabled = False
            dryingTxt.Clear()
            adsTxt.Clear()
            totalTxt.Clear()
        End If
    End Sub

    'Private Sub replaceCheck_CheckedChanged(sender As Object, e As EventArgs) Handles replaceCheck.CheckedChanged
    '    If replaceCheck.Checked Then
    '        replaceTxt.Enabled = True
    '        replaceTxt.SetOnGotFocus()
    '    Else
    '        replaceTxt.Enabled = False
    '        replaceTxt.Clear()
    '        adsTxt.Clear()
    '        totalTxt.Clear()
    '    End If
    'End Sub

    Private Sub computeButton_Click(sender As Object, e As EventArgs) Handles computeButton.Click
        'Dim brochureamount As Double = 0
        'Dim posteramount As Double = 0
        'Dim dryingamount As Double = 0
        'Dim replaceamount As Double = 0

        'Dim brochureCount As Double = 0
        'Dim posterCount As Double = 0
        'Dim replaceCount As Double = 0

        '' Check and parse brochure count
        'If Not String.IsNullOrEmpty(brochureTxt.Text) AndAlso Double.TryParse(brochureTxt.Text, brochureCount) Then
        '    brochureamount = brochureCount * 1.5
        'End If

        '' Check and parse poster count
        'If Not String.IsNullOrEmpty(posterTxt.Text) AndAlso Double.TryParse(posterTxt.Text, posterCount) Then
        '    posteramount = posterCount * 10.0
        '    dryingamount = posterCount * 0.0 ' This will always be 0 as per your code
        'End If

        '' Check and parse replace count
        'If Not String.IsNullOrEmpty(replaceTxt.Text) AndAlso Double.TryParse(replaceTxt.Text, replaceCount) Then
        '    replaceamount = replaceCount * 0.0 ' This will always be 0 as per your code
        'End If

        '' Calculate the total amount
        'Dim totalamount As Double = brochureamount + posteramount + dryingamount + replaceamount

        '' Display the amounts in the appropriate text boxes
        'adsTxt.Text = totalamount.ToString("F2") ' Format as fixed-point number with 1 decimal place

        '' Update totalTxt.Text by adding the value from amountTxt.Text
        'UpdateTotalAmount()
        Dim brochureamount As Double = 0
        Dim posteramount As Double = 0
        Dim dryingamount As Double = 0
        Dim replaceamount As Double = 0

        Dim brochureCount As Double = 0
        Dim posterCount As Double = 0
        Dim replaceCount As Double = 0
        Dim excessAmount As Double = 0
        Dim previousTotal As Double = 0

        ' Parse excess amount
        If Not String.IsNullOrEmpty(excessTxt.Text) Then
            Double.TryParse(excessTxt.Text, excessAmount)
        End If

        ' Parse the previous total from totalTxt (before recomputing)
        If Not String.IsNullOrEmpty(totalTxt.Text) Then
            Double.TryParse(totalTxt.Text, previousTotal)
        End If

        ' Check and parse brochure count
        If Not String.IsNullOrEmpty(brochureTxt.Text) AndAlso Double.TryParse(brochureTxt.Text, brochureCount) Then
            brochureamount = brochureCount * 1.5
        End If

        ' Check and parse poster count
        If Not String.IsNullOrEmpty(posterTxt.Text) AndAlso Double.TryParse(posterTxt.Text, posterCount) Then
            posteramount = posterCount * 10.0
            dryingamount = posterCount * 0.0 ' This remains 0 as per your logic
        End If

        ' Check and parse replace count
        If Not String.IsNullOrEmpty(replaceTxt.Text) AndAlso Double.TryParse(replaceTxt.Text, replaceCount) Then
            replaceamount = replaceCount * 0.0 ' This remains 0 as per your logic
        End If

        ' Compute total amount for the new calculation
        Dim totalAmount As Double = brochureamount + posteramount + dryingamount + replaceamount

        ' Display the computed amount in adsTxt
        adsTxt.Text = totalAmount.ToString("N2") ' Format as fixed-point number with 2 decimal places

        ' Call UpdateTotalAmount to add amountTxt and adsTxt
        UpdateTotalAmount()

        ' Now, deduct the excess amount from the updated total
        Dim updatedTotal As Double = 0
        Double.TryParse(totalTxt.Text, updatedTotal) ' Get updated total from UpdateTotalAmount()
        updatedTotal -= excessAmount ' Deduct excess amount

        ' Ensure the total never goes negative
        If updatedTotal < 0 Then
            updatedTotal = 0
        End If

        ' Display the adjusted total
        totalTxt.Text = updatedTotal.ToString("N2")

        ' If excessAmount was used, reset it to 0 so that it is not deducted multiple times
        If excessAmount > 0 Then
            excessTxt.Text = "0.00"
        End If
    End Sub

    Private Sub replacementCheck_CheckedChanged(sender As Object, e As EventArgs) Handles replacementCheck.CheckedChanged
        Dim foundRow As DataGridViewRow = Nothing

        For Each row As DataGridViewRow In dgv1.Rows
            If row.Cells("fac_code").Value.ToString() = codeTxt.Text Then
                foundRow = row
                Exit For
            End If
        Next

        ' If no record is found, but replacementCheck is checked, open ReplacementForm
        If foundRow Is Nothing Then
            ' Check if the replacementCheck is ticked
            If replacementCheck.Checked Then
                ' Get the next soaNumber from the database
                Dim nextSOANumber As String = GetNextSOANumber()
                Dim codereplace As String = codeTxt.Text
                ' Open the ReplacementForm with a new soaNumber
                Dim replacementForm As New Replacement("", nextSOANumber, codereplace) ' Pass empty currentSOANumber and the nextSOANumber
                If replacementForm.ShowDialog() = DialogResult.OK Then
                    replaceCount.Text = replacementForm.ReplacementCount ' 🔁 <-- This line passes the value!
                End If ' Show the form modally

                'replaceCombo.Enabled = True
                UncheckOtherCheckBoxes(replacementCheck)
                    'CalculateTotalAmount(0)
                    ' Update the total after calculation
                    UpdateTotalAmount()
                    'replacementCheck.Checked = False
                Else

                End If
        Else
            ' If record is found, proceed with the normal process
            Dim currentSOANumber As String = foundRow.Cells("soa_number").Value.ToString()

            ' Check if soaNumber is not empty or null
            If Not String.IsNullOrEmpty(currentSOANumber) Then
                ' Get the next soaNumber from the database
                Dim nextSOANumber As String = GetNextSOANumber()
                Dim codereplace As String = codeTxt.Text
                ' Check if the user ticked the replacement checkbox
                If replacementCheck.Checked Then
                    ' Open the ReplacementForm and pass both currentSOANumber and nextSOANumber
                    Dim replacementForm As New Replacement(currentSOANumber, nextSOANumber, codereplace)
                    replacementForm.ShowDialog() ' Show the form modally
                    replaceCombo.Enabled = True
                    'UncheckOtherCheckBoxes(replacementCheck)
                    'CalculateTotalAmount(0)
                    ' Update the total after calculation
                    UpdateTotalAmount()
                    'replacementCheck.Checked = False

                    'replacementForm.Show()
                Else
                    ' If no replacement is selected, proceed with usual processing
                    ClearTextBoxesIfNoChecks()
                    remLbl.Visible = False
                    replaceCombo.Enabled = False
                    replaceCombo.SelectedIndex = -1
                End If
            Else
                MessageBox.Show("Selected transaction does not have a valid SOA number.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If

    End Sub
    Private Function GetNextSOANumber() As String
        Dim nextSOANumber As String = ""

        ' Define your connection string (adjust DSN as necessary)
        Dim connectionString As String = "DSN=dashboard"

        ' SQL query to get the maximum soa_number from the accounting table
        Dim query As String = "SELECT MAX(CAST(soa_number AS UNSIGNED)) FROM acccounting"  ' Corrected for MySQL

        ' Establish an ODBC connection and execute the query
        Using conn As New OdbcConnection(connectionString)
            Using cmd As New OdbcCommand(query, conn)
                Try
                    conn.Open()
                    Dim result As Object = cmd.ExecuteScalar()

                    ' If result is not DBNull, convert it to an integer and increment by 1
                    If result IsNot DBNull.Value Then
                        nextSOANumber = (Convert.ToInt32(result) + 1).ToString()
                    Else
                        ' If no records are found, start from 1
                        nextSOANumber = "1"
                    End If
                Catch ex As Exception
                    ' Handle any exceptions (e.g., connection errors or SQL issues)
                    MessageBox.Show("Error fetching the next SOA number: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using

        Return nextSOANumber
    End Function

    Public Sub disableAds()
        brochureCheck.Enabled = False
        posterCheck.Enabled = False
        dryingCheck.Enabled = False
        payButton.Enabled = False
        reportButton.Enabled = False
        noticeButton.Enabled = False
        monitoringCheck.Enabled = False
        lopezCheck.Enabled = False
        expiredCheck.Enabled = False
        replacementCheck.Enabled = False
        soaButton.Enabled = False
        brochureTxt.Enabled = False
        posterTxt.Enabled = False
        dryingTxt.Enabled = False
    End Sub

    Public Sub enableAds()
        brochureCheck.Enabled = True
        posterCheck.Enabled = True
        dryingCheck.Enabled = True
        payButton.Enabled = True
        reportButton.Enabled = True
        noticeButton.Enabled = True
        monitoringCheck.Enabled = True
        lopezCheck.Enabled = True
        expiredCheck.Enabled = True
        replacementCheck.Enabled = True
        soaButton.Enabled = True
        brochureTxt.Enabled = True
        posterTxt.Enabled = True
        dryingTxt.Enabled = True
    End Sub

    Private Sub walkCheck_CheckedChanged(sender As Object, e As EventArgs) Handles walkCheck.CheckedChanged
        If walkCheck.Checked Then
            qtyTxt.Text = "1"
            codeTxt.Text = "7345"
            CalculateTotalAmount(1800) ' Ensure unit price 1800 is used
            UncheckOtherCheckBoxes(walkCheck) ' Uncheck other checkboxes
            disableAds()
            ProcessCode
        Else
            codeTxt.Clear()
            ClearTextBoxesIfNoChecks()
            enableAds()
        End If
        UpdateTotalAmount() ' Always update total after change
    End Sub

    Private Sub monitoringCheck_CheckedChanged(sender As Object, e As EventArgs) Handles monitoringCheck.CheckedChanged
        If monitoringCheck.Checked Then
            UncheckOtherCheckBoxes(monitoringCheck)
            CalculateTotalAmount(400)
            ' Update the total after calculation
            UpdateTotalAmount()
        Else
            ClearTextBoxesIfNoChecks()
        End If
    End Sub

    'Private Sub cancelCheck_CheckedChanged(sender As Object, e As EventArgs) Handles cancelCheck.CheckedChanged
    '    If cancelCheck.Checked Then
    '        UncheckOtherCheckBoxes(cancelCheck)
    '        CalculateTotalAmount(0)
    '    Else
    '        ClearTextBoxesIfNoChecks()
    '    End If
    'End Sub

    'Private Sub UncheckOtherCheckBoxes(checkedCheckBox As CheckBox)
    '    For Each chk As CheckBox In {replacementCheck, walkCheck, monitoringCheck, lopezCheck}
    '        If chk IsNot checkedCheckBox AndAlso chk.Checked Then
    '            chk.Checked = False
    '        End If
    '    Next
    'End Sub
    Private Sub UncheckOtherCheckBoxes(checkedCheckBox As CheckBox)
        For Each chk As CheckBox In {walkCheck, monitoringCheck, lopezCheck, expiredCheck}
            If chk IsNot checkedCheckBox AndAlso chk.Checked Then
                chk.Checked = False
            End If
        Next

        ' If no checkboxes are checked, reset to the default calculation
        If Not replacementCheck.Checked AndAlso Not walkCheck.Checked AndAlso Not monitoringCheck.Checked AndAlso Not lopezCheck.Checked AndAlso Not expiredCheck.Checked Then
            CalculateTotalAmount(1750)
            UpdateTotalAmount()
        End If
    End Sub

    'Private Sub ClearTextBoxesIfNoChecks()
    '    If Not replacementCheck.Checked AndAlso Not walkCheck.Checked AndAlso Not monitoringCheck.Checked AndAlso Not lopezCheck.Checked Then
    '        'qtyTxt.Clear()
    '        'amountTxt.Clear()
    '        totalTxt.Clear()
    '    End If
    'End Sub
    Private Sub ClearTextBoxesIfNoChecks()
        If Not replacementCheck.Checked AndAlso Not walkCheck.Checked AndAlso Not monitoringCheck.Checked AndAlso Not lopezCheck.Checked AndAlso Not expiredCheck.Checked Then
            ' If no checkboxes are selected, calculate with default unit price
            CalculateTotalAmount(1750)
            UpdateTotalAmount()
        Else
            totalTxt.Clear()
        End If
    End Sub

    Private Sub qtyTxt_TextChanged(sender As Object, e As EventArgs) Handles qtyTxt.TextChanged
        If String.IsNullOrEmpty(qtyTxt.Text) Then
            isFirstInput = True
            amountTxt.Text = "0.00"   ' Default value for amountTxt
            totalTxt.Text = "0.00"    ' Default value for totalTxt
            Return
        End If

        Dim quantity As Double
        If Not Double.TryParse(qtyTxt.Text, quantity) Then
            ' Show a message if the input is invalid and reset the textbox
            MessageBox.Show("Please enter a valid number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            qtyTxt.Text = "" ' Clear invalid input
            Return
        End If

        ' Perform calculations based on the selected checkbox
        If expiredCheck.Checked Then
            CalculateTotalAmount(15)
        ElseIf walkCheck.Checked Then
            CalculateTotalAmount(1800)
        ElseIf monitoringCheck.Checked Then
            CalculateTotalAmount(400)
        ElseIf lopezCheck.Checked Then
            CalculateTotalAmount(1800)
        Else
            ' Default calculation: multiply by 1750 if no checkbox is selected
            CalculateTotalAmount(1750)
        End If

        ' Update totalTxt.Text by adding the value from adsTxt.Text
        UpdateTotalAmount()
    End Sub

    'Private Sub qtyTxt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles qtyTxt.KeyPress
    '    ' Check if the Enter key is pressed
    '    If e.KeyChar = ChrW(Keys.Enter) Then
    '        Dim quantity As Double

    '        ' Validate the input as a number
    '        If Double.TryParse(qtyTxt.Text, quantity) Then
    '            ' Perform the appropriate calculation based on the selected checkbox
    '            If replacementCheck.Checked Then
    '                CalculateTotalAmount(15)
    '            ElseIf walkCheck.Checked Then
    '                CalculateTotalAmount(1800)
    '            ElseIf monitoringCheck.Checked Then
    '                CalculateTotalAmount(400)
    '            ElseIf lopezCheck.Checked Then
    '                CalculateTotalAmount(1800)
    '            Else
    '                ' Default calculation: multiply by 1750 if no checkbox is selected
    '                amountTxt.Text = (quantity * 1750).ToString("F2") ' Format with 2 decimal places
    '            End If

    '            ' Update totalTxt.Text by adding the value from adsTxt.Text
    '            UpdateTotalAmount()
    '        Else
    '            ' Show a message if the input is invalid
    '            MessageBox.Show("Please enter a valid number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        End If

    '        ' Prevent the beep sound on Enter key press
    '        e.Handled = True
    '    End If

    '    ' Allow only digits and control keys (e.g., Backspace)
    '    If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
    '        e.Handled = True
    '    End If
    'End Sub

    Public Sub CalculateTotalAmount(unitPrice As Double)
        Dim quantity As Double

        ' Parse the quantity from qtyTxt
        If Double.TryParse(qtyTxt.Text, quantity) Then
            ' Calculate the total amount
            Dim totalAmount = quantity * unitPrice

            ' Display the total amount in amountTxt
            amountTxt.Text = totalAmount.ToString("N2") ' Format with 2 decimal places
            adsTxt.Text = "0.00"
        Else

            amountTxt.Text = "0.00"
        End If
    End Sub

    'Private Sub UpdateTotalAmount()
    '    Dim amountValue As Double = 0
    '    Dim adsValue As Double = 0

    '    ' Parse amountTxt.Text
    '    Double.TryParse(amountTxt.Text, amountValue)

    '    ' Parse adsTxt.Text
    '    Double.TryParse(adsTxt.Text, adsValue)

    '    ' Calculate the combined total
    '    Dim combinedTotal = amountValue + adsValue

    '    ' Display the combined total in totalTxt
    '    totalTxt.Text = combinedTotal.ToString("F2") ' Format with 2 decimal places
    'End Sub

    Private Sub UpdateTotalAmount()
        Dim amountValue As Double = 0
        Dim adsValue As Double = 0

        ' Parse amountTxt.Text
        Double.TryParse(amountTxt.Text, amountValue)

        ' Parse adsTxt.Text
        Double.TryParse(adsTxt.Text, adsValue)

        ' Calculate the combined total
        Dim combinedTotal = amountValue + adsValue

        ' Display the combined total in totalTxt
        totalTxt.Text = combinedTotal.ToString("N2") ' Format with 2 decimal places
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
        'cancelCheck.Checked = False
        'replaceCheck.Checked = False
        brochureCheck.Checked = False
        posterCheck.Checked = False
        dryingCheck.Checked = False
        'replaceCheck.Checked = False
        brochureTxt.Text = ""
        posterTxt.Text = ""
        dryingTxt.Text = ""
        replaceTxt.Text = ""
        adsTxt.Text = ""
        totalTxt.Text = ""
        replaceCombo.SelectedIndex = -1
        lopezCheck.Checked = False
        'dgv2.Visible = False
        replaceCount.Text = ""
    End Sub

    Private Function ExecuteQuery(query As String) As Integer
        Using conn As New OdbcConnection(connString)
            Using cmd As New OdbcCommand(query, conn)
                conn.Open()
                Return cmd.ExecuteNonQuery()
            End Using
        End Using
    End Function

    'Private Function InsertRecord(ByRef soatxt As String, soaDate As Date, ordertype As String, code As String, name As String, term As String, purchaseNumber As String, purchaseDate As Date, quantity As Integer, subtotal As Integer, brochure As Integer, poster As Integer, drying As Integer, replace As Integer, ads As Double, dueDate As Date, totalAmount As Double, balance As Double, user As String, subamount As Integer) As Integer
    '    Dim insertQuery As String = "INSERT INTO acccounting (soa_txt, soa_date, order_type, fac_code, facility_name, term, purchase_number, purchase_date, quantity, sub_total, brochure, poster, drying_rack, replacement, ads_amount, due_date, total_amount, balance, username, sub_amount) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
    '    Dim lastInsertedIdQuery As String = "SELECT LAST_INSERT_ID()"

    '    Using conn As New OdbcConnection("DSN=dashboard")
    '        conn.Open()
    '        Dim transaction As OdbcTransaction = conn.BeginTransaction()

    '        Try
    '            Using cmd As New OdbcCommand(insertQuery, conn, transaction)
    '                cmd.Parameters.AddWithValue("soa_txt", soatxt)
    '                cmd.Parameters.AddWithValue("soa_date", soaDate)
    '                cmd.Parameters.AddWithValue("order_type", ordertype)
    '                cmd.Parameters.AddWithValue("fac_code", code)
    '                cmd.Parameters.AddWithValue("facility_name", name)
    '                cmd.Parameters.AddWithValue("term", term)
    '                cmd.Parameters.AddWithValue("purchase_number", purchaseNumber)
    '                cmd.Parameters.AddWithValue("purchase_date", purchaseDate)
    '                cmd.Parameters.AddWithValue("quantity", quantity)
    '                cmd.Parameters.AddWithValue("sub_total", subtotal)
    '                cmd.Parameters.AddWithValue("brochure", brochure)
    '                cmd.Parameters.AddWithValue("poster", poster)
    '                cmd.Parameters.AddWithValue("drying_rack", drying)
    '                cmd.Parameters.AddWithValue("replacement", replace)
    '                cmd.Parameters.AddWithValue("ads_amount", Math.Round(ads, 2))
    '                cmd.Parameters.AddWithValue("due_date", dueDate)
    '                cmd.Parameters.AddWithValue("total_amount", totalAmount)
    '                cmd.Parameters.AddWithValue("balance", balance)
    '                cmd.Parameters.AddWithValue("username", user)
    '                cmd.Parameters.AddWithValue("sub_amount", subamount)

    '                cmd.ExecuteNonQuery()

    '                ' Retrieve last inserted ID
    '                cmd.CommandText = lastInsertedIdQuery
    '                Dim lastInsertedId As Integer = Convert.ToInt32(cmd.ExecuteScalar())

    '                transaction.Commit()
    '                Return lastInsertedId
    '            End Using
    '        Catch ex As Exception
    '            transaction.Rollback()
    '            Throw New Exception("Error during record insertion: " & ex.Message)
    '        End Try
    '    End Using
    'End Function

    'Private Function InsertRecord(ByVal soatxt As String, soaDate As Date, ordertype As String, code As String, name As String, term As String, purchaseNumber As String, purchaseDate As Date, quantity As Integer, subtotal As Integer, brochure As Integer, poster As Integer, drying As Integer, replace As Integer, ads As Double, dueDate As Date, totalAmount As Double, balance As Double, user As String, subamount As Integer) As Integer
    '    Dim insertQuery As String = "INSERT INTO acccounting (soa_number, soa_txt, soa_date, order_type, fac_code, facility_name, term, purchase_number, purchase_date, quantity, sub_total, brochure, poster, drying_rack, replacement, ads_amount, due_date, total_amount, balance, username, sub_amount) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
    '    Dim lastSoaQuery As String = "SELECT soa_number FROM acccounting WHERE LEFT(soa_number, 4) = ? ORDER BY soa_number DESC LIMIT 1"
    '    Dim lastInsertedIdQuery As String = "SELECT LAST_INSERT_ID()"

    '    Dim year As String = purchaseDate.Year.ToString()
    '    Dim newSoaNumber As String = ""

    '    Using conn As New OdbcConnection("DSN=dashboard")
    '        conn.Open()
    '        Dim transaction As OdbcTransaction = conn.BeginTransaction()

    '        Try
    '            ' Get the latest SOA number for the year
    '            Using cmd As New OdbcCommand(lastSoaQuery, conn, transaction)
    '                cmd.Parameters.AddWithValue("year", year)
    '                Dim lastSoa As Object = cmd.ExecuteScalar()

    '                If lastSoa IsNot Nothing Then
    '                    ' Increment the existing SOA number
    '                    Dim lastIncrement As Integer = Convert.ToInt32(lastSoa.ToString().Substring(4)) + 1
    '                    newSoaNumber = year & lastIncrement.ToString("D5")
    '                Else
    '                    ' Start from 1 if no SOA exists for the year
    '                    newSoaNumber = year & "00001"
    '                End If
    '            End Using

    '            ' Assign the new SOA number to soatxt
    '            soatxt = newSoaNumber

    '            ' Insert the record
    '            Using cmd As New OdbcCommand(insertQuery, conn, transaction)
    '                cmd.Parameters.AddWithValue("soa_number", newSoaNumber)
    '                cmd.Parameters.AddWithValue("soa_txt", soatxt)
    '                cmd.Parameters.AddWithValue("soa_date", soaDate.Date)  ' Ensure soa_date is date only (no time)
    '                cmd.Parameters.AddWithValue("order_type", ordertype)
    '                cmd.Parameters.AddWithValue("fac_code", code)
    '                cmd.Parameters.AddWithValue("facility_name", name)
    '                cmd.Parameters.AddWithValue("term", term)
    '                cmd.Parameters.AddWithValue("purchase_number", purchaseNumber)
    '                cmd.Parameters.AddWithValue("purchase_date", purchaseDate.Date)  ' Ensure purchase_date is date only (no time)
    '                cmd.Parameters.AddWithValue("quantity", quantity)
    '                cmd.Parameters.AddWithValue("sub_total", subtotal)
    '                cmd.Parameters.AddWithValue("brochure", brochure)
    '                cmd.Parameters.AddWithValue("poster", poster)
    '                cmd.Parameters.AddWithValue("drying_rack", drying)
    '                cmd.Parameters.AddWithValue("replacement", replace)
    '                cmd.Parameters.AddWithValue("ads_amount", Math.Round(ads, 2))
    '                cmd.Parameters.AddWithValue("due_date", dueDate.Date)  ' Ensure due_date is date only (no time)
    '                cmd.Parameters.AddWithValue("total_amount", totalAmount)
    '                cmd.Parameters.AddWithValue("balance", balance)
    '                cmd.Parameters.AddWithValue("username", user)
    '                cmd.Parameters.AddWithValue("sub_amount", subamount)

    '                cmd.ExecuteNonQuery()

    '                ' Retrieve last inserted ID
    '                cmd.CommandText = lastInsertedIdQuery
    '                Dim lastInsertedId As Integer = Convert.ToInt32(cmd.ExecuteScalar())

    '                transaction.Commit()
    '                Return lastInsertedId
    '            End Using
    '        Catch ex As Exception
    '            transaction.Rollback()
    '            Throw New Exception("Error during record insertion: " & ex.Message)
    '        End Try
    '    End Using
    'End Function

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

    'Private Function InsertRecord(ByRef soatxt As String, soaDate As Date, ordertype As String, code As String, name As String, term As String, purchaseNumber As String, purchaseDate As Date, quantity As Integer, subtotal As Integer, brochure As Integer, poster As Integer, drying As Integer, replace As Integer, ads As Double, dueDate As Date, totalAmount As Double, balance As Double, user As String, subamount As Double, replace_type As String) As Double
    '    Dim insertQuery As String = "INSERT INTO acccounting (soa_number, soa_txt, soa_date, order_type, fac_code, facility_name, term, purchase_number, purchase_date, quantity, sub_total, brochure, poster, drying_rack, replacement, ads_amount, due_date, total_amount, balance, username, sub_amount, replace_type) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
    '    Dim lastSoaQuery As String = "SELECT soa_number FROM acccounting WHERE LEFT(soa_number, 4) = ? ORDER BY soa_number DESC LIMIT 1"
    '    Dim lastInsertedIdQuery As String = "SELECT LAST_INSERT_ID()"

    '    Dim year As String = purchaseDate.Year.ToString()
    '    Dim newSoaNumber As String = ""

    '    Using conn As New OdbcConnection("DSN=dashboard")
    '        conn.Open()
    '        Dim transaction As OdbcTransaction = conn.BeginTransaction()

    '        Try
    '            Using cmd As New OdbcCommand(lastSoaQuery, conn, transaction)
    '                cmd.Parameters.AddWithValue("year", year)
    '                Dim lastSoa As Object = cmd.ExecuteScalar()

    '                If lastSoa IsNot Nothing Then
    '                    Dim lastIncrement As Integer = Convert.ToInt32(lastSoa.ToString().Substring(4)) + 1
    '                    newSoaNumber = year & lastIncrement.ToString("D5")
    '                Else
    '                    newSoaNumber = year & "00001"
    '                End If
    '            End Using

    '            soatxt = newSoaNumber ' Update soatxt directly here

    '            Using cmd As New OdbcCommand(insertQuery, conn, transaction)
    '                cmd.Parameters.AddWithValue("soa_number", newSoaNumber)
    '                cmd.Parameters.AddWithValue("soa_txt", soatxt)
    '                cmd.Parameters.AddWithValue("soa_date", soaDate.Date)
    '                cmd.Parameters.AddWithValue("order_type", ordertype)
    '                cmd.Parameters.AddWithValue("fac_code", code)
    '                cmd.Parameters.AddWithValue("facility_name", name)
    '                cmd.Parameters.AddWithValue("term", term)
    '                cmd.Parameters.AddWithValue("purchase_number", purchaseNumber)
    '                cmd.Parameters.AddWithValue("purchase_date", purchaseDate.Date)
    '                cmd.Parameters.AddWithValue("quantity", quantity)
    '                cmd.Parameters.AddWithValue("sub_total", subtotal)
    '                cmd.Parameters.AddWithValue("brochure", brochure)
    '                cmd.Parameters.AddWithValue("poster", poster)
    '                cmd.Parameters.AddWithValue("drying_rack", drying)
    '                cmd.Parameters.AddWithValue("replacement", replace)
    '                cmd.Parameters.AddWithValue("ads_amount", Math.Round(ads, 2))
    '                cmd.Parameters.AddWithValue("due_date", dueDate.Date)
    '                cmd.Parameters.AddWithValue("total_amount", totalAmount)
    '                cmd.Parameters.AddWithValue("balance", balance)
    '                cmd.Parameters.AddWithValue("username", user)
    '                cmd.Parameters.AddWithValue("sub_amount", subamount)
    '                cmd.Parameters.AddWithValue("replace_type", replace_type)

    '                cmd.ExecuteNonQuery()

    '                cmd.CommandText = lastInsertedIdQuery
    '                Dim lastInsertedId As Integer = Convert.ToInt32(cmd.ExecuteScalar())

    '                transaction.Commit()
    '                Return lastInsertedId
    '            End Using
    '        Catch ex As Exception
    '            transaction.Rollback()
    '            Throw New Exception("Error during record insertion: " & ex.Message)
    '        End Try

    '        ' Get the total quantity (sum of quantity) from replacement_type for a specific SOA number
    '        Dim query1 As String = $"SELECT SUM(quantity) FROM replacement_type WHERE soa_number = '{newSoaNumber}'"
    '        ' Execute the query to get the total quantity as an integer (use ExecuteScalar for execution)
    '        Dim totalQuantity As Integer = ExecuteScalar(query1)

    '        ' Now, update the accounting table with the total quantity
    '        Dim query2 As String = $"UPDATE acccounting SET replacement = {totalQuantity} WHERE soa_number = '{newSoaNumber}'"
    '        ExecuteQuery(query2)
    '    End Using
    'End Function
    'Private Function InsertRecord(ByRef soatxt As String, soaDate As Date, ordertype As String, code As String, name As String, term As String, purchaseNumber As String, purchaseDate As Date, quantity As Integer, subtotal As Integer, brochure As Integer, poster As Integer, drying As Integer, replace As Integer, ads As Double, dueDate As Date, totalAmount As Double, balance As Double, user As String, subamount As Double, replace_type As String) As Double
    '    Dim insertQuery As String = "INSERT INTO acccounting (soa_number, soa_txt, soa_date, order_type, fac_code, facility_name, term, purchase_number, purchase_date, quantity, sub_total, brochure, poster, drying_rack, replacement, ads_amount, due_date, total_amount, balance, username, sub_amount, replace_type) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
    '    Dim lastSoaQuery As String = "SELECT soa_number FROM acccounting WHERE LEFT(soa_number, 4) = ? ORDER BY soa_number DESC LIMIT 1"
    '    Dim lastInsertedIdQuery As String = "SELECT LAST_INSERT_ID()"

    '    Dim year As String = purchaseDate.Year.ToString()
    '    Dim newSoaNumber As String = ""

    '    Using conn As New OdbcConnection("DSN=dashboard")
    '        conn.Open()
    '        Dim transaction As OdbcTransaction = conn.BeginTransaction()

    '        Try
    '            ' Get the last SOA number for the current year
    '            Using cmd As New OdbcCommand(lastSoaQuery, conn, transaction)
    '                cmd.Parameters.AddWithValue("year", year)
    '                Dim lastSoa As Object = cmd.ExecuteScalar()

    '                If lastSoa IsNot Nothing Then
    '                    Dim lastIncrement As Integer = Convert.ToInt32(lastSoa.ToString().Substring(4)) + 1
    '                    newSoaNumber = year & lastIncrement.ToString("D5")
    '                Else
    '                    newSoaNumber = year & "00001"
    '                End If
    '            End Using

    '            soatxt = newSoaNumber ' Update soatxt directly here

    '            ' Insert the new record into the accounting table
    '            Using cmd As New OdbcCommand(insertQuery, conn, transaction)
    '                cmd.Parameters.AddWithValue("soa_number", newSoaNumber)
    '                cmd.Parameters.AddWithValue("soa_txt", soatxt)
    '                cmd.Parameters.AddWithValue("soa_date", soaDate.Date)
    '                cmd.Parameters.AddWithValue("order_type", ordertype)
    '                cmd.Parameters.AddWithValue("fac_code", code)
    '                cmd.Parameters.AddWithValue("facility_name", name)
    '                cmd.Parameters.AddWithValue("term", term)
    '                cmd.Parameters.AddWithValue("purchase_number", purchaseNumber)
    '                cmd.Parameters.AddWithValue("purchase_date", purchaseDate.Date)
    '                cmd.Parameters.AddWithValue("quantity", quantity)
    '                cmd.Parameters.AddWithValue("sub_total", subtotal)
    '                cmd.Parameters.AddWithValue("brochure", brochure)
    '                cmd.Parameters.AddWithValue("poster", poster)
    '                cmd.Parameters.AddWithValue("drying_rack", drying)
    '                cmd.Parameters.AddWithValue("replacement", If(replace = 0, 0, replace)) ' Ensure default to 0 if no replacement is made
    '                cmd.Parameters.AddWithValue("ads_amount", Math.Round(ads, 2))
    '                cmd.Parameters.AddWithValue("due_date", dueDate.Date)
    '                cmd.Parameters.AddWithValue("total_amount", totalAmount)
    '                cmd.Parameters.AddWithValue("balance", balance)
    '                cmd.Parameters.AddWithValue("username", user)
    '                cmd.Parameters.AddWithValue("sub_amount", subamount)
    '                cmd.Parameters.AddWithValue("replace_type", replace_type)

    '                cmd.ExecuteNonQuery()

    '                cmd.CommandText = lastInsertedIdQuery
    '                Dim lastInsertedId As Integer = Convert.ToInt32(cmd.ExecuteScalar())

    '                transaction.Commit()
    '                Return lastInsertedId
    '            End Using
    '        Catch ex As Exception
    '            transaction.Rollback()
    '            Throw New Exception("Error during record insertion: " & ex.Message)
    '        End Try

    '        ' Get the total quantity (sum of quantity) from replacement_type for a specific SOA number
    '        Dim query1 As String = $"SELECT SUM(quantity) FROM replacement_type WHERE soa_number = '{newSoaNumber}'"
    '        ' Execute the query to get the total quantity as an integer (use ExecuteScalar for execution)
    '        Dim totalQuantity As Integer = ExecuteScalar(query1)

    '        ' Now, update the accounting table with the total quantity
    '        ' If no quantity found, ensure that it defaults to 0
    '        If totalQuantity = 0 Then totalQuantity = 0

    '        Dim query2 As String = $"UPDATE acccounting SET replacement = {totalQuantity} WHERE soa_number = '{newSoaNumber}'"
    '        ExecuteQuery(query2)
    '    End Using
    'End Function

    'Private Function InsertRecord(ByRef soatxt As String, soaDate As DateTime, ordertype As String, code As String, name As String, term As String, purchaseNumber As String, purchaseDate As DateTime, quantity As Integer, subtotal As Integer, brochure As Integer, poster As Integer, drying As Integer, replace As Integer, ads As Double, dueDate As Date, totalAmount As Double, balance As Double, user As String, subamount As Double, replace_type As String, type2 As String, date_modified As DateTime) As Double
    '    Dim insertQuery As String = "INSERT INTO acccounting (soa_number, soa_txt, soa_date, order_type, fac_code, facility_name, term, purchase_number, purchase_date, quantity, sub_total, brochure, poster, drying_rack, replacement, ads_amount, due_date, total_amount, balance, username, sub_amount, replace_type, type, date_modified) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
    '    Dim lastSoaQuery As String = "SELECT soa_number FROM acccounting WHERE LEFT(soa_number, 4) = ? ORDER BY soa_number DESC LIMIT 1"
    '    Dim lastInsertedIdQuery As String = "SELECT LAST_INSERT_ID()"

    '    Dim year As String = purchaseDate.Year.ToString()
    '    Dim newSoaNumber As String = ""

    '    Using conn As New OdbcConnection("DSN=dashboard")
    '        conn.Open()
    '        Dim transaction As OdbcTransaction = conn.BeginTransaction()

    '        Try
    '            ' Generate new SOA number
    '            Using cmd As New OdbcCommand(lastSoaQuery, conn, transaction)
    '                cmd.Parameters.AddWithValue("year", year)
    '                Dim lastSoa As Object = cmd.ExecuteScalar()

    '                If lastSoa IsNot Nothing Then
    '                    Dim lastIncrement As Integer = Convert.ToInt32(lastSoa.ToString().Substring(4)) + 1
    '                    newSoaNumber = year & lastIncrement.ToString("D5")
    '                Else
    '                    newSoaNumber = year & "00001"
    '                End If
    '            End Using

    '            soatxt = newSoaNumber

    '            ' Insert record
    '            Using cmd As New OdbcCommand(insertQuery, conn, transaction)
    '                cmd.Parameters.AddWithValue("soa_number", newSoaNumber)
    '                cmd.Parameters.AddWithValue("soa_txt", soatxt)
    '                cmd.Parameters.AddWithValue("soa_date", soaDate.Datetime)
    '                cmd.Parameters.AddWithValue("order_type", ordertype)
    '                cmd.Parameters.AddWithValue("fac_code", code)
    '                cmd.Parameters.AddWithValue("facility_name", name)
    '                cmd.Parameters.AddWithValue("term", term)
    '                cmd.Parameters.AddWithValue("purchase_number", purchaseNumber)
    '                cmd.Parameters.AddWithValue("purchase_date", purchaseDate.Datetime)
    '                cmd.Parameters.AddWithValue("quantity", quantity)
    '                cmd.Parameters.AddWithValue("sub_total", subtotal)
    '                cmd.Parameters.AddWithValue("brochure", brochure)
    '                cmd.Parameters.AddWithValue("poster", poster)
    '                cmd.Parameters.AddWithValue("drying_rack", drying)
    '                cmd.Parameters.AddWithValue("replacement", replace)
    '                cmd.Parameters.AddWithValue("ads_amount", Math.Round(ads, 2))
    '                cmd.Parameters.AddWithValue("due_date", dueDate.Datetime)
    '                cmd.Parameters.AddWithValue("total_amount", totalAmount)
    '                cmd.Parameters.AddWithValue("balance", balance)
    '                cmd.Parameters.AddWithValue("username", user)
    '                cmd.Parameters.AddWithValue("sub_amount", subamount)
    '                cmd.Parameters.AddWithValue("replace_type", replace_type)
    '                cmd.Parameters.AddWithValue("type", type2)
    '                cmd.Parameters.AddWithValue("date_modified", date_modified)

    '                cmd.ExecuteNonQuery()

    '                cmd.CommandText = lastInsertedIdQuery
    '                Dim lastInsertedId As Integer = Convert.ToInt32(cmd.ExecuteScalar())

    '                ' Update replacement total in accounting table
    '                Dim query1 As String = "SELECT COALESCE(SUM(quantity), 0) FROM replacement_type WHERE soa_number = ?"
    '                Dim totalQuantity As Integer

    '                Using cmd2 As New OdbcCommand(query1, conn, transaction)
    '                    cmd2.Parameters.AddWithValue("soa_number", newSoaNumber)
    '                    totalQuantity = Convert.ToInt32(cmd2.ExecuteScalar())
    '                End Using

    '                Dim query2 As String = "UPDATE acccounting SET replacement = ? WHERE soa_number = ?"
    '                Using cmd3 As New OdbcCommand(query2, conn, transaction)
    '                    cmd3.Parameters.AddWithValue("replacement", totalQuantity)
    '                    cmd3.Parameters.AddWithValue("soa_number", newSoaNumber)
    '                    cmd3.ExecuteNonQuery()
    '                End Using

    '                'this is for when a replacement_type has a price and need to add to the balance
    '                ' First, calculate the total price from the replacement_type table
    '                Dim query3 As String = "SELECT COALESCE(SUM(total_price), 0) FROM replacement_type WHERE soa_number = ?"
    '                Dim totalPrice As Double

    '                Using cmd4 As New OdbcCommand(query3, conn, transaction)
    '                    cmd4.Parameters.AddWithValue("soa_number", newSoaNumber)
    '                    totalPrice = Convert.ToDouble(cmd4.ExecuteScalar())
    '                End Using

    '                ' Add the total price to the current balance
    '                Dim newBalance As Double = balance + totalPrice

    '                ' Update the balance in the acccounting table
    '                Dim updateBalanceQuery As String = "UPDATE acccounting SET balance = ? WHERE soa_number = ?"
    '                Using cmd5 As New OdbcCommand(updateBalanceQuery, conn, transaction)
    '                    cmd5.Parameters.AddWithValue("balance", newBalance)
    '                    cmd5.Parameters.AddWithValue("soa_number", newSoaNumber)
    '                    cmd5.ExecuteNonQuery()
    '                End Using


    '                transaction.Commit()
    '                Return lastInsertedId
    '            End Using
    '        Catch ex As Exception
    '            transaction.Rollback()
    '            Throw New Exception("Error during record insertion: " & ex.Message)
    '        Finally
    '            conn.Close()
    '        End Try
    '    End Using
    'End Function

    Private Function InsertRecord(ByRef soatxt As String, soaDate As DateTime, ordertype As String, code As String, name As String, term As String, purchaseNumber As String, purchaseDate As DateTime, quantity As Integer, subtotal As Double, brochure As Integer, poster As Integer, drying As Integer, replace As Integer, ads As Double, dueDate As DateTime, totalAmount As Double, balance As Double, user As String, subamount As Double, replace_type As String, type2 As String, date_modified As DateTime, modified_by As String, excess As Double) As Double
        Dim insertQuery As String = "INSERT INTO acccounting (soa_number, soa_txt, soa_date, order_type, fac_code, facility_name, term, purchase_number, purchase_date, quantity, sub_total, brochure, poster, drying_rack, replacement, ads_amount, due_date, total_amount, balance, username, sub_amount, replace_type, type, date_modified, modified_by, excess) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
        Dim lastSoaQuery As String = "SELECT soa_number FROM acccounting WHERE LEFT(soa_number, 4) = ? ORDER BY soa_number DESC LIMIT 1"
        Dim lastInsertedIdQuery As String = "SELECT LAST_INSERT_ID()"

        Dim year As String = purchaseDate.Year.ToString()
        Dim newSoaNumber As String = ""

        Using conn As New OdbcConnection("DSN=dashboard")
            conn.Open()
            Dim transaction As OdbcTransaction = conn.BeginTransaction()

            Try
                ' Generate new SOA number
                Using cmd As New OdbcCommand(lastSoaQuery, conn, transaction)
                    cmd.Parameters.AddWithValue("@year", year)
                    Dim lastSoa As Object = cmd.ExecuteScalar()

                    If lastSoa IsNot Nothing Then
                        Dim lastIncrement As Integer = Convert.ToInt32(lastSoa.ToString().Substring(4)) + 1
                        newSoaNumber = year & lastIncrement.ToString("D5")
                    Else
                        newSoaNumber = year & "00001"
                    End If
                End Using

                soatxt = newSoaNumber

                ' Insert record
                Using cmd As New OdbcCommand(insertQuery, conn, transaction)
                    cmd.Parameters.AddWithValue("@soa_number", newSoaNumber)
                    cmd.Parameters.AddWithValue("@soa_txt", soatxt)
                    'cmd.Parameters.AddWithValue("@soa_date", soaDate.Date)
                    cmd.Parameters.AddWithValue("@soa_date", DateTime.Now)
                    cmd.Parameters.AddWithValue("@order_type", ordertype)
                    cmd.Parameters.AddWithValue("@fac_code", code)
                    cmd.Parameters.AddWithValue("@facility_name", name)
                    cmd.Parameters.AddWithValue("@term", term)
                    cmd.Parameters.AddWithValue("@purchase_number", purchaseNumber)
                    'cmd.Parameters.AddWithValue("@purchase_date", purchaseDate.Date)
                    cmd.Parameters.AddWithValue("@purchase_date", dtpicker2.Value)
                    cmd.Parameters.AddWithValue("@quantity", quantity)
                    cmd.Parameters.AddWithValue("@sub_total", subtotal)
                    cmd.Parameters.AddWithValue("@brochure", brochure)
                    cmd.Parameters.AddWithValue("@poster", poster)
                    cmd.Parameters.AddWithValue("@drying_rack", drying)
                    cmd.Parameters.AddWithValue("@replacement", If(replace = -1, DBNull.Value, replace))
                    cmd.Parameters.AddWithValue("@ads_amount", ads)
                    'cmd.Parameters.AddWithValue("@due_date", dueDate.Date)
                    cmd.Parameters.AddWithValue("@due_date", dtpicker1.Value)
                    cmd.Parameters.AddWithValue("@total_amount", totalAmount)
                    cmd.Parameters.AddWithValue("@balance", balance)
                    cmd.Parameters.AddWithValue("@username", user)
                    cmd.Parameters.AddWithValue("@sub_amount", subamount)
                    cmd.Parameters.AddWithValue("@replace_type", replace_type)
                    cmd.Parameters.AddWithValue("@type", type2)
                    cmd.Parameters.AddWithValue("@date_modified", DateTime.Now)
                    cmd.Parameters.AddWithValue("@modified_by", modified_by)
                    cmd.Parameters.AddWithValue("@excess", excess)

                    cmd.ExecuteNonQuery()

                    cmd.CommandText = lastInsertedIdQuery
                    Dim lastInsertedId As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                    ' Update replacement total in accounting table
                    Dim query1 As String = "SELECT COALESCE(SUM(quantity), 0) FROM replacement_type WHERE soa_number = ?"
                    Dim totalQuantity As Integer

                    Using cmd2 As New OdbcCommand(query1, conn, transaction)
                        cmd2.Parameters.AddWithValue("soa_number", newSoaNumber)
                        totalQuantity = Convert.ToInt32(cmd2.ExecuteScalar())
                    End Using

                    Dim query2 As String = "UPDATE acccounting SET replacement = ? WHERE soa_number = ?"
                    Using cmd3 As New OdbcCommand(query2, conn, transaction)
                        cmd3.Parameters.AddWithValue("replacement", totalQuantity)
                        cmd3.Parameters.AddWithValue("soa_number", newSoaNumber)
                        cmd3.ExecuteNonQuery()
                    End Using

                    'this is for when a replacement_type has a price and need to add to the balance
                    ' First, calculate the total price from the replacement_type table
                    Dim query3 As String = "SELECT COALESCE(SUM(total_price), 0) FROM replacement_type WHERE soa_number = ?"
                    Dim totalPrice As Double

                    Using cmd4 As New OdbcCommand(query3, conn, transaction)
                        cmd4.Parameters.AddWithValue("soa_number", newSoaNumber)
                        totalPrice = Convert.ToDouble(cmd4.ExecuteScalar())
                    End Using

                    ' Add the total price to the current balance
                    Dim newBalance As Double = balance + totalPrice

                    ' Update the balance in the acccounting table
                    Dim updateBalanceQuery As String = "UPDATE acccounting SET balance = ? WHERE soa_number = ?"
                    Using cmd5 As New OdbcCommand(updateBalanceQuery, conn, transaction)
                        cmd5.Parameters.AddWithValue("balance", newBalance)
                        cmd5.Parameters.AddWithValue("soa_number", newSoaNumber)
                        cmd5.ExecuteNonQuery()
                    End Using

                    Dim updateExcessQuery As String = "UPDATE payments SET excess = ? WHERE fac_code = ? AND excess <> ''"

                    Using cmd6 As New OdbcCommand(updateExcessQuery, conn, transaction)
                        cmd6.Parameters.AddWithValue("excess", excessTxt.Text)
                        cmd6.Parameters.AddWithValue("fac_code", codeTxt.Text)
                        cmd6.ExecuteNonQuery()
                    End Using

                    Dim updateExcess As String = "UPDATE acccounting SET excess = ? WHERE fac_code = ? AND excess <> ''"

                    Using cmd7 As New OdbcCommand(updateExcess, conn, transaction)
                        cmd7.Parameters.AddWithValue("excess", excessTxt.Text)
                        cmd7.Parameters.AddWithValue("fac_code", codeTxt.Text)
                        cmd7.ExecuteNonQuery()
                    End Using

                    transaction.Commit()
                    Return lastInsertedId
                End Using
            Catch ex As Exception
                transaction.Rollback()
                Throw New Exception("Error during record insertion: " & ex.Message)
            Finally
                conn.Close()
            End Try
        End Using
    End Function

    'Private Function InsertRecord(ByRef soatxt As String, soaDate As DateTime, ordertype As String, code As String, name As String, term As String, purchaseNumber As String, purchaseDate As DateTime, quantity As Integer, subtotal As Double, brochure As Integer, poster As Integer, drying As Integer, replace As Integer, ads As Double, dueDate As DateTime, totalAmount As Double, balance As Double, user As String, subamount As Double, replace_type As String, type2 As String, date_modified As DateTime, modified_by As String, excess As Double) As Double
    '    Dim insertQuery As String = "INSERT INTO acccounting (soa_number, soa_txt, soa_date, order_type, fac_code, facility_name, term, purchase_number, purchase_date, quantity, sub_total, brochure, poster, drying_rack, replacement, ads_amount, due_date, total_amount, balance, username, sub_amount, replace_type, type, date_modified, modified_by, excess) VALUES (NULL, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
    '    Dim lastInsertedIdQuery As String = "SELECT LAST_INSERT_ID()"

    '    ' We will let the database auto-increment the soa_number field as it's a primary key
    '    ' The soatxt parameter will still be used for the soa_txt field

    '    Using conn As New OdbcConnection("DSN=dashboard")
    '        conn.Open()
    '        Dim transaction As OdbcTransaction = conn.BeginTransaction()

    '        Try
    '            ' Insert record
    '            Using cmd As New OdbcCommand(insertQuery, conn, transaction)
    '                ' Don't set soa_number parameter as it's now auto-incremented by MySQL
    '                cmd.Parameters.AddWithValue("@soa_txt", soatxt)
    '                'cmd.Parameters.AddWithValue("@soa_date", soaDate.Date)
    '                cmd.Parameters.AddWithValue("@soa_date", DateTime.Now)
    '                cmd.Parameters.AddWithValue("@order_type", ordertype)
    '                cmd.Parameters.AddWithValue("@fac_code", code)
    '                cmd.Parameters.AddWithValue("@facility_name", name)
    '                cmd.Parameters.AddWithValue("@term", term)
    '                cmd.Parameters.AddWithValue("@purchase_number", purchaseNumber)
    '                'cmd.Parameters.AddWithValue("@purchase_date", purchaseDate.Date)
    '                cmd.Parameters.AddWithValue("@purchase_date", dtpicker2.Value)
    '                cmd.Parameters.AddWithValue("@quantity", quantity)
    '                cmd.Parameters.AddWithValue("@sub_total", subtotal)
    '                cmd.Parameters.AddWithValue("@brochure", brochure)
    '                cmd.Parameters.AddWithValue("@poster", poster)
    '                cmd.Parameters.AddWithValue("@drying_rack", drying)
    '                cmd.Parameters.AddWithValue("@replacement", If(replace = -1, DBNull.Value, replace))
    '                cmd.Parameters.AddWithValue("@ads_amount", ads)
    '                'cmd.Parameters.AddWithValue("@due_date", dueDate.Date)
    '                cmd.Parameters.AddWithValue("@due_date", dtpicker1.Value)
    '                cmd.Parameters.AddWithValue("@total_amount", totalAmount)
    '                cmd.Parameters.AddWithValue("@balance", balance)
    '                cmd.Parameters.AddWithValue("@username", user)
    '                cmd.Parameters.AddWithValue("@sub_amount", subamount)
    '                cmd.Parameters.AddWithValue("@replace_type", replace_type)
    '                cmd.Parameters.AddWithValue("@type", type2)
    '                cmd.Parameters.AddWithValue("@date_modified", DateTime.Now)
    '                cmd.Parameters.AddWithValue("@modified_by", modified_by)
    '                cmd.Parameters.AddWithValue("@excess", excess)

    '                cmd.ExecuteNonQuery()

    '                cmd.CommandText = lastInsertedIdQuery
    '                Dim lastInsertedId As Integer = Convert.ToInt32(cmd.ExecuteScalar())

    '                ' Also update soatxt reference parameter so calling code knows the new SOA number
    '                soatxt = lastInsertedId.ToString()

    '                ' Update replacement total in accounting table
    '                Dim query1 As String = "SELECT COALESCE(SUM(quantity), 0) FROM replacement_type WHERE soa_number = ?"
    '                Dim totalQuantity As Integer

    '                Using cmd2 As New OdbcCommand(query1, conn, transaction)
    '                    cmd2.Parameters.AddWithValue("soa_number", lastInsertedId.ToString())
    '                    totalQuantity = Convert.ToInt32(cmd2.ExecuteScalar())
    '                End Using

    '                Dim query2 As String = "UPDATE acccounting SET replacement = ? WHERE soa_number = ?"
    '                Using cmd3 As New OdbcCommand(query2, conn, transaction)
    '                    cmd3.Parameters.AddWithValue("replacement", totalQuantity)
    '                    cmd3.Parameters.AddWithValue("soa_number", lastInsertedId.ToString())
    '                    cmd3.ExecuteNonQuery()
    '                End Using

    '                'this is for when a replacement_type has a price and need to add to the balance
    '                ' First, calculate the total price from the replacement_type table
    '                Dim query3 As String = "SELECT COALESCE(SUM(total_price), 0) FROM replacement_type WHERE soa_number = ?"
    '                Dim totalPrice As Double

    '                Using cmd4 As New OdbcCommand(query3, conn, transaction)
    '                    cmd4.Parameters.AddWithValue("soa_number", lastInsertedId.ToString())
    '                    totalPrice = Convert.ToDouble(cmd4.ExecuteScalar())
    '                End Using

    '                ' Add the total price to the current balance
    '                Dim newBalance As Double = balance + totalPrice

    '                ' Update the balance in the acccounting table
    '                Dim updateBalanceQuery As String = "UPDATE acccounting SET balance = ? WHERE soa_number = ?"
    '                Using cmd5 As New OdbcCommand(updateBalanceQuery, conn, transaction)
    '                    cmd5.Parameters.AddWithValue("balance", newBalance)
    '                    cmd5.Parameters.AddWithValue("soa_number", lastInsertedId.ToString())
    '                    cmd5.ExecuteNonQuery()
    '                End Using

    '                Dim updateExcessQuery As String = "UPDATE payments SET excess = ? WHERE fac_code = ? AND excess <> ''"

    '                Using cmd6 As New OdbcCommand(updateExcessQuery, conn, transaction)
    '                    cmd6.Parameters.AddWithValue("excess", excessTxt.Text)
    '                    cmd6.Parameters.AddWithValue("fac_code", codeTxt.Text)
    '                    cmd6.ExecuteNonQuery()
    '                End Using

    '                Dim updateExcess As String = "UPDATE acccounting SET excess = ? WHERE fac_code = ? AND excess <> ''"

    '                Using cmd7 As New OdbcCommand(updateExcess, conn, transaction)
    '                    cmd7.Parameters.AddWithValue("excess", excessTxt.Text)
    '                    cmd7.Parameters.AddWithValue("fac_code", codeTxt.Text)
    '                    cmd7.ExecuteNonQuery()
    '                End Using

    '                transaction.Commit()
    '                Return lastInsertedId
    '            End Using
    '        Catch ex As Exception
    '            transaction.Rollback()
    '            Throw New Exception("Error during record insertion: " & ex.Message)
    '        Finally
    '            conn.Close()
    '        End Try
    '    End Using
    'End Function
    Private Sub addButton_Click(sender As Object, e As EventArgs) Handles addButton.Click
        ' Check if any row is marked for cancellation
        Dim isAnyChecked As Boolean = dgv1.Rows.Cast(Of DataGridViewRow)().
                                  Any(Function(row) Not row.IsNewRow AndAlso Convert.ToBoolean(row.Cells("cancelPo").Value))

        ' Show a confirmation prompt before proceeding with either action
        If isAnyChecked Then
            ' If cancellation is required, ask user for confirmation
            If MessageBox.Show("Are you sure you want to cancel the selected purchase orders?", "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                CancelPurchaseOrders()  ' Proceed with cancellation
                cleartxt()  ' Clear fields after successful cancellation
                loaddgv()  ' Reload the DataGridView to reflect the changes
                Payments.loaddgv()
                Payments.payments()
            End If
        Else
            ' If adding a new order, ask user for confirmation
            If MessageBox.Show("Are all entries correct?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                AddNewOrder()  ' Proceed with adding the new order
                cleartxt()  ' Clear fields after successful addition
                loaddgv()  ' Reload the DataGridView to reflect the changes
                Payments.loaddgv()
                Payments.payments()
            End If
        End If

        ' Reset button text and hide the remark section
        addButton.Text = "ADD"
        remLbl.Visible = False
        remBox.Visible = False
        replacementCheck.Checked = False
        'Payments.loaddgv()
    End Sub

    Private Sub CancelPurchaseOrders()
        ' Check if remBox has a value before proceeding
        If String.IsNullOrWhiteSpace(remBox.Text) Then
            MessageBox.Show("Please enter remarks before cancelling the SOA", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        For Each row As DataGridViewRow In dgv1.Rows.Cast(Of DataGridViewRow)().
        Where(Function(r) Not r.IsNewRow AndAlso Convert.ToBoolean(r.Cells("cancelPo").Value))

            Try
                row.Cells("total_amount").Value = 0
                row.Cells("balance").Value = 0
                row.Cells("remarks").Value = remBox.Text
                row.Cells("order_type").Value &= " (Cancelled SOA)"
                row.Cells("date_modified").Value = DateTime.Now

                SaveCancellationToDatabase(remBox.Text, row.Cells("soa_number").Value.ToString(), DateTime.Now, Login.userTxt.Text)
                MessageBox.Show("Cancelled SOA")
            Catch ex As Exception
                MessageBox.Show("An error occurred during cancellation: " & ex.Message)
            End Try
        Next
    End Sub

    Private Sub AddNewOrder()
        Try
            If Not ValidateFields() Then Exit Sub
            'If MessageBox.Show("Are all entries correct?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

            Dim orderType As String = DetermineOrderType()
            Dim soatxt As String = InsertOrder(orderType)

            GenerateReport(soatxt, orderType)

            'cleartxt()

        Catch ex As Exception
            MessageBox.Show("An error occurred during adding: " & ex.Message)
        End Try
    End Sub

    Private Function DetermineOrderType() As String
        If walkCheck.Checked Then Return "ENBS."
        If monitoringCheck.Checked Then Return "Monitoring"
        If expiredCheck.Checked Then Return "ENBS Expired Filter Card"
        If lopezCheck.Checked Then Return "ENBS."
        Return "ENBS"
    End Function

    Private Function InsertOrder(orderType As String) As String
        Dim soatxt As String = ""

        ' Format double values safely
        Dim formattedAds As Double = Convert.ToDouble(adsTxt.Text)
        Dim formattedTotal As Double = Convert.ToDouble(totalTxt.Text)
        Dim formattedBalance As Double = Convert.ToDouble(totalTxt.Text)

        Dim replace As Integer = -1
        If replaceCombo.SelectedItem IsNot Nothing Then
            Integer.TryParse(replaceCombo.SelectedItem.ToString(), replace)
        End If

        Dim excess As Double = "0.00"

        '' Insert the formatted values into the database
        'Dim soaNumber As Integer = InsertRecord(soatxt, Date.Now.Date, orderType, codeTxt.Text, nameBox.Text, termBox.Text,
        '                                    purchaseBox.Text, dtpicker2.Value.Date, Integer.Parse(qtyTxt.Text),
        '                                    Convert.ToDouble(amountTxt.Text), ParseOrZero(brochureTxt.Text), ParseOrZero(posterTxt.Text),
        '                                    ParseOrZero(dryingTxt.Text), replace,
        '                                    formattedAds, dtpicker1.Value.Date,
        '                                    formattedTotal, formattedBalance,
        '                                    Login.userTxt.Text, Convert.ToDouble(amountTxt.Text), replace.ToString(), typeText.Text, DateTime.Now)

        Dim soaNumber As Integer = InsertRecord(soatxt, DateTime.Now, orderType, codeTxt.Text, nameBox.Text, termBox.Text,
             purchaseBox.Text, dtpicker2.Value, Integer.Parse(qtyTxt.Text),
             Double.Parse(amountTxt.Text), ParseOrZero(brochureTxt.Text), ParseOrZero(posterTxt.Text),
             ParseOrZero(dryingTxt.Text), ParseOrZero(replaceTxt.Text),
             formattedAds, dtpicker1.Value,
             formattedTotal, formattedBalance,
             Login.userTxt.Text, Double.Parse(amountTxt.Text), replace, typeText.Text, DateTime.Now, Login.userTxt.Text, excess)


        UpdateSoaTxt(soatxt, soaNumber)

        MessageBox.Show("Saved Successfully!")
        Return soatxt  ' Return the updated SOA text
    End Function


    Private Sub GenerateReport(soaTxt As String, orderType As String)
        Dim report As Object

        If lopezCheck.Checked OrElse walkCheck.Checked Then
            report = New StatementOfAccountWithServiceFee()
        Else
            report = New StatementOfAccount()
        End If

        report.RecordSelectionFormula = "{acccounting1.soa_txt} = '" & soaTxt & "'"
        report.Refresh()

        Dim reportForm As New Form With {
        .WindowState = FormWindowState.Maximized
    }

        Dim crystalReportViewer As New CrystalDecisions.Windows.Forms.CrystalReportViewer With {
        .ReportSource = report,
        .Dock = DockStyle.Fill
    }

        reportForm.Controls.Add(crystalReportViewer)
        reportForm.Show()
    End Sub

    Private Function ParseOrZero(value As String) As Integer
        Return If(String.IsNullOrEmpty(value), 0, Integer.Parse(value))
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

    Private Sub SaveCancellationToDatabase(remarks As String, soaNumber As String, date_modified As DateTime, modified_by As String)
        Try
            ' Establish the database connection
            Using conn As New OdbcConnection("DSN=dashboard")
                conn.Open()

                ' Corrected SQL query with proper placeholders
                Dim query As String = "UPDATE acccounting SET total_amount = 0, balance = 0, remarks = ?, order_type = CONCAT(order_type, ' (Cancelled SOA)'), date_modified = ?, modified_by = ? WHERE soa_number = ?"

                ' Create the command and add parameters in the correct order
                Using cmd As New OdbcCommand(query, conn)
                    cmd.Parameters.AddWithValue("?", remarks)          ' First ?
                    cmd.Parameters.AddWithValue("?", date_modified)    ' Second ?
                    cmd.Parameters.AddWithValue("?", modified_by)
                    cmd.Parameters.AddWithValue("?", soaNumber)        ' Third ?

                    ' Execute the update command
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Database update failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function ValidateFields() As Boolean
        Dim errorMessage As String = "Please input required fields first."

        ' Check if any of the fields are blank in a single statement
        If String.IsNullOrWhiteSpace(codeTxt.Text) OrElse
           String.IsNullOrWhiteSpace(nameBox.Text) OrElse
           String.IsNullOrWhiteSpace(termBox.Text) Then

            ' Show the message box and return False if any field is blank
            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        ' Return True if all fields are filled
        Return True
    End Function


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
        conn.Close()
        conn.Dispose()

        Application.Exit()
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
            ' Update the total after calculation
            UpdateTotalAmount()
        Else
            ClearTextBoxesIfNoChecks()
        End If
    End Sub

    Private Sub noticeButton_Click(sender As Object, e As EventArgs) Handles noticeButton.Click
    End Sub

    Private Sub codeTxt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles codeTxt.KeyPress
        ' Allow digits and control keys (backspace, delete, etc.)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

        ' Limit input to 4 characters
        If codeTxt.Text.Length >= 4 AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub ConfirmSelection()
        If String.IsNullOrEmpty(replaceCombo.Text) OrElse replaceCombo.SelectedIndex = -1 Then
            MessageBox.Show("Please select an item from the ComboBox before proceeding.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
        End If
    End Sub

    Private Sub replaceCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles replaceCombo.SelectedIndexChanged

    End Sub

    Private Sub homeBtn_Click(sender As Object, e As EventArgs)
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub UpdateDateTimePicker2()
        Try
            ' Get the base date from DateTimePicker1
            Dim baseDate As DateTime = dtpicker2.Value

            ' Get the number of days from TextBox1
            Dim daysToAdd As Integer
            If Integer.TryParse(termBox.Text, daysToAdd) Then
                ' Add the days to the base date and set it to DateTimePicker2
                dtpicker1.Value = baseDate.AddDays(daysToAdd)
            Else
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dtpicker2_ValueChanged(sender As Object, e As EventArgs) Handles dtpicker2.ValueChanged
        'UpdateDateTimePicker2()
    End Sub

    ' Handle the CurrentCellDirtyStateChanged event to commit changes immediately when a checkbox is clicked
    Private Sub dgv1_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgv1.CurrentCellDirtyStateChanged
        'If dgv1.CurrentCell IsNot Nothing AndAlso dgv1.CurrentCell.ColumnIndex = 0 Then ' Replace 0 with your checkbox column index
        '    dgv1.CommitEdit(DataGridViewDataErrorContexts.Commit)
        'End If
        If dgv1.CurrentCell IsNot Nothing AndAlso dgv1.CurrentCell.ColumnIndex = 0 Then ' Replace 0 with your checkbox column index
            ' Commit the edit to ensure the first click is immediately reflected
            dgv1.EndEdit()
        End If
    End Sub

    ' Handle the CellValueChanged event to update the button text and ensure only one checkbox is checked
    Private Sub dgv1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv1.CellValueChanged
        ' Ensure we are working on the checkbox column
        If e.ColumnIndex = 0 Then ' Replace 0 with your checkbox column index
            ' Allow only one checkbox to be checked at a time
            For Each row As DataGridViewRow In dgv1.Rows
                If row.Index <> e.RowIndex AndAlso Convert.ToBoolean(row.Cells(0).Value) Then
                    row.Cells(0).Value = False
                End If
            Next

            ' Update the button text
            If dgv1.Rows.Cast(Of DataGridViewRow)().Any(Function(r) Convert.ToBoolean(r.Cells(0).Value)) Then
                addButton.Text = "CANCEL"
                remLbl.Visible = True
                remBox.Visible = True
            Else
                addButton.Text = "ADD"
                remLbl.Visible = False
                remBox.Visible = False
                'cleartxt()
            End If
        End If
    End Sub

    Private Sub dgv1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv1.CellContentClick
        ' Check if the clicked row index is valid and the DataGridView has rows
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 AndAlso dgv1.Rows.Count > 0 Then
            Try
                ' Check if the clicked column is the "cancelPo" checkbox column
                If dgv1.Columns(e.ColumnIndex).Name = "cancelPo" Then
                    ' Get the checkbox value for the clicked row
                    Dim isChecked As Boolean = Convert.ToBoolean(dgv1.Rows(e.RowIndex).Cells("cancelPo").Value)

                    If isChecked Then
                        ' Proceed with the code if the checkbox is ticked
                        codeTxt.Text = dgv1.Rows(e.RowIndex).Cells("fac_code").Value.ToString()
                        nameBox.Text = dgv1.Rows(e.RowIndex).Cells("facility_name").Value.ToString()
                        termBox.Text = dgv1.Rows(e.RowIndex).Cells("term").Value.ToString()
                        purchaseBox.Text = dgv1.Rows(e.RowIndex).Cells("purchase_number").Value.ToString()
                        qtyTxt.Text = dgv1.Rows(e.RowIndex).Cells("quantity").Value.ToString()
                        amountTxt.Text = dgv1.Rows(e.RowIndex).Cells("sub_total").Value.ToString()
                        dtpicker2.Value = Convert.ToDateTime(dgv1.Rows(e.RowIndex).Cells("purchase_date").Value)
                        dtpicker1.Value = Convert.ToDateTime(dgv1.Rows(e.RowIndex).Cells("due_date").Value)
                        brochureTxt.Text = dgv1.Rows(e.RowIndex).Cells("brochure").Value.ToString()
                        posterTxt.Text = dgv1.Rows(e.RowIndex).Cells("poster").Value.ToString()
                        dryingTxt.Text = dgv1.Rows(e.RowIndex).Cells("drying_rack").Value.ToString()
                        replaceTxt.Text = dgv1.Rows(e.RowIndex).Cells("replacement").Value.ToString()
                        adsTxt.Text = dgv1.Rows(e.RowIndex).Cells("ads_amount").Value.ToString()
                        totalTxt.Text = dgv1.Rows(e.RowIndex).Cells("total_amount").Value.ToString()
                        totalTxt.Text = dgv1.Rows(e.RowIndex).Cells("balance").Value.ToString()

                        disableColumns()
                    Else
                        ' Optional: Handle cases when the checkbox is unchecked
                        'MessageBox.Show("The checkbox is not ticked.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            Catch ex As Exception
                'MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' Method to Disable Specific Columns
    Private Sub disableColumns()
        ' Example: Disabling specific columns by name
        dgv1.Columns("fac_code").ReadOnly = True
        dgv1.Columns("facility_name").ReadOnly = True
        dgv1.Columns("order_type").ReadOnly = True
        dgv1.Columns("term").ReadOnly = True
        dgv1.Columns("purchase_number").ReadOnly = True
        dgv1.Columns("quantity").ReadOnly = True
        dgv1.Columns("sub_total").ReadOnly = True
        dgv1.Columns("purchase_date").ReadOnly = True
        dgv1.Columns("due_date").ReadOnly = True
        dgv1.Columns("brochure").ReadOnly = True
        dgv1.Columns("poster").ReadOnly = True
        dgv1.Columns("drying_rack").ReadOnly = True
        dgv1.Columns("replacement").ReadOnly = True
        dgv1.Columns("ads_amount").ReadOnly = True
        dgv1.Columns("total_amount").ReadOnly = True
        dgv1.Columns("balance").ReadOnly = True
    End Sub

    Private Sub dgv1_BindingContextChanged(sender As Object, e As EventArgs) Handles dgv1.BindingContextChanged
        ' Set the format for the columns to display two decimal places
        dgv1.Columns("ads_amount").DefaultCellStyle.Format = "N2" ' Replace "adsColumn" with your actual column name for ads
        dgv1.Columns("total_amount").DefaultCellStyle.Format = "N2" ' Replace "totalColumn" with your actual column name for total amount
        dgv1.Columns("balance").DefaultCellStyle.Format = "N2" ' Replace "balanceColumn" with your actual column name for balance
    End Sub

    Private Sub expiredCheck_CheckedChanged(sender As Object, e As EventArgs) Handles expiredCheck.CheckedChanged
        If expiredCheck.Checked Then
            UncheckOtherCheckBoxes(expiredCheck)
            CalculateTotalAmount(15)
            ' Update the total after calculation
            UpdateTotalAmount()

        Else
            ClearTextBoxesIfNoChecks()
        End If
    End Sub

    Private Sub replaceAdd_Click(sender As Object, e As EventArgs) Handles replaceAdd.Click

    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub totalTxt_TextChanged(sender As Object, e As EventArgs) Handles totalTxt.TextChanged

    End Sub

    Private Sub grpBox_Click(sender As Object, e As EventArgs) Handles grpBox.Click

    End Sub

    Private Sub purchaseBox_TextChanged(sender As Object, e As EventArgs) Handles purchaseBox.TextChanged
        purchaseBox.Text = purchaseBox.Text.ToUpper()
        purchaseBox.SelectionStart = purchaseBox.Text.Length ' Keeps cursor at the end
    End Sub

    Private Sub remBox_TextChanged(sender As Object, e As EventArgs) Handles remBox.TextChanged
        remBox.Text = remBox.Text.ToUpper()
        remBox.SelectionStart = remBox.Text.Length ' Keeps cursor at the end
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim pstTime As DateTime = DateTime.UtcNow.AddHours(8) ' Convert UTC to PST (UTC+8)
        dtLabel.Text = "Date Today: " & pstTime.ToString("yyyy-MM-dd") & " Time Today: " & pstTime.ToString("HH:mm:ss") & " PST"
    End Sub

    Private Sub codeTxt_KeyDown(sender As Object, e As KeyEventArgs) Handles codeTxt.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True ' Prevents the beep sound
            ProcessCode()
            purchaseBox.Focus()
        Else
            loaddgv()
        End If
    End Sub

    Private Sub purchaseBox_KeyDown(sender As Object, e As KeyEventArgs) Handles purchaseBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            qtyTxt.Focus()
        End If
    End Sub

    Private Sub codeTxt_TextChanged(sender As Object, e As EventArgs) Handles codeTxt.TextChanged
    End Sub

    Private Sub salesReportBtn_Click(sender As Object, e As EventArgs) Handles salesReportBtn.Click
        SalesReport.Show()
    End Sub

    'Public Sub loaddgv2()
    '    Call connection()
    '    da = New OdbcDataAdapter("Select replace_type from replace_type_components", conn)
    '    ds = New DataSet
    '    ds.Clear()
    '    da.Fill(ds, "replace_type_components")
    '    dgv2.DataSource = ds.Tables("replace_type_components").DefaultView
    'End Sub
End Class


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

'Try
'    Check If the button Is in CANCEL mode
'    If addButton.Text = "CANCEL" Then
'        Handle cancellation And save to the database
'        If SaveCancellationToDatabase(remBox.Text, codeTxt.Text) Then
'            MessageBox.Show("Cancelled P.O Succeed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
'        Else
'            MessageBox.Show("Failed to cancel PO. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'            Exit Sub
'        End If

'        Reset the button text And hide relevant elements
'        addButton.Text = "ADD"
'        remLbl.Visible = False
'        remBox.Visible = False

'        Clear Input fields And refresh DataGridView
'        cleartxt()
'        loaddgv()
'        Exit Sub
'    End If

'    Validate the fields before proceeding
'    If Not ValidateFields() Then
'        Exit Sub
'    End If

'    Confirm all entries are correct
'    Dim confirmResult As DialogResult = MessageBox.Show("Are all entries correct?",
'                                                   "Confirmation",
'                                                   MessageBoxButtons.YesNo,
'                                                   MessageBoxIcon.Question)

'    If confirmResult = DialogResult.No Then
'        MessageBox.Show("Operation canceled. Please check your input and try again.",
'                    "Operation Canceled",
'                    MessageBoxButtons.OK,
'                    MessageBoxIcon.Exclamation)
'        Exit Sub
'    End If

'    Handle additional checks for replacement
'    If replacementCheck.Checked Then
'        If String.IsNullOrEmpty(replaceCombo.Text) OrElse replaceCombo.SelectedIndex = -1 Then
'            MessageBox.Show("Please select a replacement option before proceeding.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'            Exit Sub
'        End If
'    End If

'    Prepare Data for insertion
'    Dim soatxt As String ' Declare soatxt here
'    Dim soaDate As Date = Date.Now
'    Dim ordertype As String = ""

'    Determine order type
'    If walkCheck.Checked Then
'        ordertype = "ENBS"
'    ElseIf monitoringCheck.Checked Then
'        ordertype = "Monitoring"
'    ElseIf replacementCheck.Checked Then
'        ordertype = "ENBS-Replacement -" + replaceCombo.SelectedItem.ToString()
'    ElseIf lopezCheck.Checked Then
'        ordertype = "ENBS"
'    Else
'        ordertype = "ENBS"
'    End If

'    Gather Input data
'    Dim code As String = codeTxt.Text
'    Dim name As String = nameBox.Text
'    Dim term As String = termBox.Text
'    Dim purchaseNumber As String = purchaseBox.Text
'    Dim purchaseDate As Date = dtpicker2.Value
'    Dim quantity As Integer = Integer.Parse(qtyTxt.Text)
'    Dim subtotal As Integer = Integer.Parse(amountTxt.Text)
'    Dim brochure As Integer = If(String.IsNullOrEmpty(brochureTxt.Text), 0, Integer.Parse(brochureTxt.Text))
'    Dim poster As Integer = If(String.IsNullOrEmpty(posterTxt.Text), 0, Integer.Parse(posterTxt.Text))
'    Dim drying As Integer = If(String.IsNullOrEmpty(dryingTxt.Text), 0, Integer.Parse(dryingTxt.Text))
'    Dim replace As Integer = If(String.IsNullOrEmpty(replaceTxt.Text), 0, Integer.Parse(replaceTxt.Text))
'    Dim ads As Double = Double.Parse(adsTxt.Text)
'    Dim dueDate As Date = dtpicker1.Value
'    Dim totalAmount As Double = Double.Parse(totalTxt.Text)
'    Dim balance As Double = Double.Parse(totalTxt.Text)
'    Dim user As String = Login.userTxt.Text
'    Dim subamount As Integer = amountTxt.Text

'    Insert record into the database
'    Dim soaNumber As Integer = InsertRecord("", soaDate, ordertype, code, name, term, purchaseNumber, purchaseDate, quantity, subtotal, brochure, poster, drying, replace, ads, dueDate, totalAmount, balance, user, subamount)

'    Assign the generated soa_number to soatxt
'    soatxt = soaNumber.ToString()

'    Update the soa_txt field in the database
'    UpdateSoaTxt(soatxt, soaNumber)

'    MessageBox.Show("Insert Successfully!")

'    If walkCheck.Checked Then
'        Generate the Crystal Report
'        Dim report As New StatementOfAccount()
'        Dim selformula As String = "{acccounting1.soa_txt} = '" & soatxt & "'"
'        report.RecordSelectionFormula = selformula

'        Refresh the report to load data
'        report.Refresh()

'        Dim reportForm As New Form
'        Dim crystalReportViewer As New CrystalDecisions.Windows.Forms.CrystalReportViewer
'        crystalReportViewer.ReportSource = report
'        crystalReportViewer.Dock = DockStyle.Fill
'        reportForm.Controls.Add(crystalReportViewer)
'        reportForm.WindowState = FormWindowState.Maximized
'        reportForm.Show()
'    ElseIf monitoringCheck.Checked Then
'        Generate the Crystal Report
'        Dim report As New StatementOfAccount()
'        Dim selformula As String = "{acccounting1.soa_txt} = '" & soatxt & "'"
'        report.RecordSelectionFormula = selformula

'        Refresh the report to load data
'        report.Refresh()

'        Dim reportForm As New Form
'        Dim crystalReportViewer As New CrystalDecisions.Windows.Forms.CrystalReportViewer
'        crystalReportViewer.ReportSource = report
'        crystalReportViewer.Dock = DockStyle.Fill
'        reportForm.Controls.Add(crystalReportViewer)
'        reportForm.WindowState = FormWindowState.Maximized
'        reportForm.Show()
'    ElseIf replacementCheck.Checked Then
'        Generate the Crystal Report
'        Dim report As New StatementOfAccount()
'        Dim selformula As String = "{acccounting1.soa_txt} = '" & soatxt & "'"
'        report.RecordSelectionFormula = selformula

'        Refresh the report to load data
'        report.Refresh()

'        Dim reportForm As New Form
'        Dim crystalReportViewer As New CrystalDecisions.Windows.Forms.CrystalReportViewer
'        crystalReportViewer.ReportSource = report
'        crystalReportViewer.Dock = DockStyle.Fill
'        reportForm.Controls.Add(crystalReportViewer)
'        reportForm.WindowState = FormWindowState.Maximized
'        reportForm.Show()
'    ElseIf lopezCheck.Checked Then
'        Generate the Crystal Report
'        Dim report As New StatementOfAccountWithServiceFee()
'        Dim selformula As String = "{acccounting1.soa_txt} = '" & soatxt & "'"
'        report.RecordSelectionFormula = selformula

'        Refresh the report to load data
'        report.Refresh()

'        Dim reportForm As New Form
'        Dim crystalReportViewer As New CrystalDecisions.Windows.Forms.CrystalReportViewer
'        crystalReportViewer.ReportSource = report
'        crystalReportViewer.Dock = DockStyle.Fill
'        reportForm.Controls.Add(crystalReportViewer)
'        reportForm.WindowState = FormWindowState.Maximized
'        reportForm.Show()
'    Else
'        Generate the Crystal Report
'        Dim report As New StatementOfAccount()
'        Dim selformula As String = "{acccounting1.soa_txt} = '" & soatxt & "'"
'        report.RecordSelectionFormula = selformula

'        Refresh the report to load data
'        report.Refresh()

'        Dim reportForm As New Form
'        Dim crystalReportViewer As New CrystalDecisions.Windows.Forms.CrystalReportViewer
'        crystalReportViewer.ReportSource = report
'        crystalReportViewer.Dock = DockStyle.Fill
'        reportForm.Controls.Add(crystalReportViewer)
'        reportForm.WindowState = FormWindowState.Maximized
'        reportForm.Show()
'    End If

'    Clear Input fields And refresh data grid view
'    cleartxt()
'    loaddgv()
'Catch ex As Exception
'    MessageBox.Show("An error occurred: " & ex.Message)
'End Try


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



'Private Sub addButton_Click(sender As Object, e As EventArgs) Handles addButton.Click
'    Try
'        ' Validate the fields before proceeding
'        If Not ValidateFields() Then
'            ' Stop execution if validation fails
'            Exit Sub
'        End If

'        ' Confirm all entries are correct
'        Dim confirmResult As DialogResult = MessageBox.Show("Are all entries correct?",
'                                                       "Confirmation",
'                                                       MessageBoxButtons.YesNo,
'                                                       MessageBoxIcon.Question)

'        If confirmResult = DialogResult.No Then
'            ' User wants to cancel the operation
'            MessageBox.Show("Operation canceled. Please check your input and try again.",
'                        "Operation Canceled",
'                        MessageBoxButtons.OK,
'                        MessageBoxIcon.Exclamation)
'            Exit Sub
'        End If

'        If replacementCheck.Checked Then
'            If String.IsNullOrEmpty(replaceCombo.Text) OrElse replaceCombo.SelectedIndex = -1 Then
'                MessageBox.Show("Please select a replacement option before proceeding.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'                Exit Sub
'            End If
'        End If

'        Dim soatxt As String ' Declare soatxt here
'        Dim soaDate As Date = Date.Now
'        Dim ordertype As String = ""

'        If walkCheck.Checked Then
'            ordertype = "ENBS"
'        ElseIf monitoringCheck.Checked Then
'            ordertype = "Monitoring"
'        ElseIf replacementCheck.Checked Then
'            ordertype = "ENBS-Replacement -" + replaceCombo.SelectedItem.ToString()
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
'        Else
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
'        End If

'        ' Clear input fields and refresh data grid view
'        cleartxt()
'        loaddgv()
'    Catch ex As Exception
'        MessageBox.Show("An error occurred: " & ex.Message)
'    End Try
'End Sub


'For Each row As DataGridViewRow In dgv1.Rows
'    If row.IsNewRow Then Continue For

'    Dim isCancelChecked As Boolean = Convert.ToBoolean(row.Cells("cancelPo").Value)

'    Try
'        If isCancelChecked Then
'            row.Cells("total_amount").Value = 0
'            row.Cells("balance").Value = 0
'            Dim remarks As String = remBox.Text
'            row.Cells("remarks").Value = remarks
'            row.Cells("order_type").Value &= " (Cancelled P.O)"

'            ' Update database
'            Dim facCode As String = row.Cells("fac_code").Value.ToString()
'            SaveCancellationToDatabase(remarks, facCode)
'        Else
'            ' Validate the fields before proceeding
'            If Not ValidateFields() Then
'                Exit Sub
'            End If
'            ' Confirm all entries are correct
'            Dim confirmResult As DialogResult = MessageBox.Show("Are all entries correct?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
'            If confirmResult = DialogResult.No Then
'                MessageBox.Show("Operation canceled. Please check your input and try again.", "Operation Canceled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
'                Exit Sub
'            End If

'            ' Handle additional checks for replacement
'            If replacementCheck.Checked Then
'                If String.IsNullOrEmpty(replaceCombo.Text) OrElse replaceCombo.SelectedIndex = -1 Then
'                    MessageBox.Show("Please select a replacement option before proceeding.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'                    Exit Sub
'                End If
'            End If

'            ' Prepare data for insertion
'            Dim soatxt As String
'            Dim soaDate As Date = Date.Now
'            Dim ordertype As String = ""

'            ' Determine order type
'            If walkCheck.Checked Then
'                ordertype = "ENBS"
'            ElseIf monitoringCheck.Checked Then
'                ordertype = "Monitoring"
'            ElseIf replacementCheck.Checked Then
'                ordertype = "ENBS-Replacement -" + replaceCombo.SelectedItem.ToString()
'            ElseIf lopezCheck.Checked Then
'                ordertype = "ENBS"
'            Else
'                ordertype = "ENBS"
'            End If

'            ' Gather input data
'            Dim code As String = codeTxt.Text
'            Dim name As String = nameBox.Text
'            Dim term As String = termBox.Text
'            Dim purchaseNumber As String = purchaseBox.Text
'            Dim purchaseDate As Date = dtpicker2.Value
'            Dim quantity As Integer = Integer.Parse(qtyTxt.Text)
'            Dim subtotal As Integer = Integer.Parse(amountTxt.Text)
'            Dim brochure As Integer = If(String.IsNullOrEmpty(brochureTxt.Text), 0, Integer.Parse(brochureTxt.Text))
'            Dim poster As Integer = If(String.IsNullOrEmpty(posterTxt.Text), 0, Integer.Parse(posterTxt.Text))
'            Dim drying As Integer = If(String.IsNullOrEmpty(dryingTxt.Text), 0, Integer.Parse(dryingTxt.Text))
'            Dim replace As Integer = If(String.IsNullOrEmpty(replaceTxt.Text), 0, Integer.Parse(replaceTxt.Text))
'            Dim ads As Double = Double.Parse(adsTxt.Text)
'            Dim dueDate As Date = dtpicker1.Value
'            Dim totalAmount As Double = Double.Parse(totalTxt.Text)
'            Dim balance As Double = Double.Parse(totalTxt.Text)
'            Dim user As String = Login.userTxt.Text
'            Dim subamount As Integer = amountTxt.Text

'            ' Insert record into the database
'            Dim soaNumber As Integer = InsertRecord("", soaDate, ordertype, code, name, term, purchaseNumber, purchaseDate, quantity, subtotal, brochure, poster, drying, replace, ads, dueDate, totalAmount, balance, user, subamount)

'            ' Assign the generated soa_number to soatxt
'            soatxt = soaNumber.ToString()

'            ' Update the soa_txt field in the database
'            UpdateSoaTxt(soatxt, soaNumber)

'            MessageBox.Show("Insert Successfully!")

'            If walkCheck.Checked Then
'                ' Generate the Crystal Report
'                Dim report As New StatementOfAccount()
'                Dim selformula As String = "{acccounting1.soa_txt} = '" & soatxt & "'"
'                report.RecordSelectionFormula = selformula

'                ' Refresh the report to load data
'                report.Refresh()

'                Dim reportForm As New Form
'                Dim crystalReportViewer As New CrystalDecisions.Windows.Forms.CrystalReportViewer
'                crystalReportViewer.ReportSource = report
'                crystalReportViewer.Dock = DockStyle.Fill
'                reportForm.Controls.Add(crystalReportViewer)
'                reportForm.WindowState = FormWindowState.Maximized
'                reportForm.Show()
'            ElseIf monitoringCheck.Checked Then
'                ' Generate the Crystal Report
'                Dim report As New StatementOfAccount()
'                Dim selformula As String = "{acccounting1.soa_txt} = '" & soatxt & "'"
'                report.RecordSelectionFormula = selformula

'                ' Refresh the report to load data
'                report.Refresh()

'                Dim reportForm As New Form
'                Dim crystalReportViewer As New CrystalDecisions.Windows.Forms.CrystalReportViewer
'                crystalReportViewer.ReportSource = report
'                crystalReportViewer.Dock = DockStyle.Fill
'                reportForm.Controls.Add(crystalReportViewer)
'                reportForm.WindowState = FormWindowState.Maximized
'                reportForm.Show()
'            ElseIf replacementCheck.Checked Then
'                ' Generate the Crystal Report
'                Dim report As New StatementOfAccount()
'                Dim selformula As String = "{acccounting1.soa_txt} = '" & soatxt & "'"
'                report.RecordSelectionFormula = selformula

'                ' Refresh the report to load data
'                report.Refresh()

'                Dim reportForm As New Form
'                Dim crystalReportViewer As New CrystalDecisions.Windows.Forms.CrystalReportViewer
'                crystalReportViewer.ReportSource = report
'                crystalReportViewer.Dock = DockStyle.Fill
'                reportForm.Controls.Add(crystalReportViewer)
'                reportForm.WindowState = FormWindowState.Maximized
'                reportForm.Show()
'            ElseIf lopezCheck.Checked Then
'                ' Generate the Crystal Report
'                Dim report As New StatementOfAccountWithServiceFee()
'                Dim selformula As String = "{acccounting1.soa_txt} = '" & soatxt & "'"
'                report.RecordSelectionFormula = selformula

'                ' Refresh the report to load data
'                report.Refresh()

'                Dim reportForm As New Form
'                Dim crystalReportViewer As New CrystalDecisions.Windows.Forms.CrystalReportViewer
'                crystalReportViewer.ReportSource = report
'                crystalReportViewer.Dock = DockStyle.Fill
'                reportForm.Controls.Add(crystalReportViewer)
'                reportForm.WindowState = FormWindowState.Maximized
'                reportForm.Show()
'            Else
'                ' Generate the Crystal Report
'                Dim report As New StatementOfAccount()
'                Dim selformula As String = "{acccounting1.soa_txt} = '" & soatxt & "'"
'                report.RecordSelectionFormula = selformula

'                ' Refresh the report to load data
'                report.Refresh()

'                Dim reportForm As New Form
'                Dim crystalReportViewer As New CrystalDecisions.Windows.Forms.CrystalReportViewer
'                crystalReportViewer.ReportSource = report
'                crystalReportViewer.Dock = DockStyle.Fill
'                reportForm.Controls.Add(crystalReportViewer)
'                reportForm.WindowState = FormWindowState.Maximized
'                reportForm.Show()
'            End If

'            '' Clear input fields and refresh data grid view
'            'cleartxt()
'            'loaddgv()
'        End If

'        ' Reset the button text and hide relevant elements
'        addButton.Text = "ADD"
'        remLbl.Visible = False
'        remBox.Visible = False

'        MessageBox.Show("Cancelled P.O.")

'        ' Clear input fields and refresh DataGridView
'        cleartxt()
'        loaddgv()
'        Exit Sub
'    Catch ex As Exception
'        MessageBox.Show("An error occurred: " & ex.Message)
'    End Try
'Next

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


'Private Sub addButton_Click(sender As Object, e As EventArgs) Handles addButton.Click
'    ' Check if any row has the cancelPo checkbox checked
'    Dim isAnyChecked As Boolean = dgv1.Rows.Cast(Of DataGridViewRow)().
'                                  Any(Function(row) Not row.IsNewRow AndAlso Convert.ToBoolean(row.Cells("cancelPo").Value))

'    If isAnyChecked Then
'        ' Perform P.O cancellation operation
'        For Each row As DataGridViewRow In dgv1.Rows
'            If row.IsNewRow Then Continue For

'            Dim isCancelChecked As Boolean = Convert.ToBoolean(row.Cells("cancelPo").Value)

'            If isCancelChecked Then
'                Try
'                    ' Cancel the P.O by setting amount and balance to 0
'                    row.Cells("total_amount").Value = 0
'                    row.Cells("balance").Value = 0
'                    Dim remarks As String = remBox.Text
'                    row.Cells("remarks").Value = remarks
'                    row.Cells("order_type").Value &= " (Cancelled P.O)"

'                    ' Update database to reflect cancellation
'                    Dim facCode As String = row.Cells("fac_code").Value.ToString()
'                    SaveCancellationToDatabase(remarks, facCode)

'                    MessageBox.Show("Cancelled P.O.")

'                    ' Clear input fields and refresh DataGridView
'                    cleartxt()
'                    loaddgv()

'                Catch ex As Exception
'                    MessageBox.Show("An error occurred during cancellation: " & ex.Message)
'                End Try
'            End If
'        Next
'    Else
'        ' Run Add method if no cancellation checkbox is checked
'        Try
'            ' Validate input fields before proceeding
'            If Not ValidateFields() Then Exit Sub

'            ' Confirm all data entries
'            Dim confirmResult As DialogResult = MessageBox.Show("Are all entries correct?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
'            If confirmResult = DialogResult.No Then Exit Sub

'            ' Prepare data for insertion
'            Dim soatxt As String
'            Dim soaDate As Date = Date.Now.Date ' Use .Date to strip time
'            Dim ordertype As String = ""

'            ' Determine order type
'            If walkCheck.Checked Then
'                ordertype = "ENBS"
'            ElseIf monitoringCheck.Checked Then
'                ordertype = "Monitoring"
'            ElseIf replacementCheck.Checked Then
'                ordertype = "ENBS-Replacement -" + replaceCombo.SelectedItem.ToString()
'            ElseIf lopezCheck.Checked Then
'                ordertype = "ENBS"
'            Else
'                ordertype = "ENBS"
'            End If

'            ' Gather input data
'            Dim code As String = codeTxt.Text
'            Dim name As String = nameBox.Text
'            Dim term As String = termBox.Text
'            Dim purchaseNumber As String = purchaseBox.Text
'            Dim purchaseDate As Date = dtpicker2.Value.Date ' Use .Date to strip time
'            Dim quantity As Integer = Integer.Parse(qtyTxt.Text)
'            Dim subtotal As Integer = Integer.Parse(amountTxt.Text)
'            Dim brochure As Integer = If(String.IsNullOrEmpty(brochureTxt.Text), 0, Integer.Parse(brochureTxt.Text))
'            Dim poster As Integer = If(String.IsNullOrEmpty(posterTxt.Text), 0, Integer.Parse(posterTxt.Text))
'            Dim drying As Integer = If(String.IsNullOrEmpty(dryingTxt.Text), 0, Integer.Parse(dryingTxt.Text))
'            Dim replace As Integer = If(String.IsNullOrEmpty(replaceTxt.Text), 0, Integer.Parse(replaceTxt.Text))
'            Dim ads As Double = Double.Parse(adsTxt.Text)
'            Dim dueDate As Date = dtpicker1.Value.Date ' Use .Date to strip time
'            Dim totalAmount As Double = Double.Parse(totalTxt.Text)
'            Dim balance As Double = Double.Parse(totalTxt.Text)
'            Dim user As String = Login.userTxt.Text
'            Dim subamount As Integer = Integer.Parse(amountTxt.Text)

'            ' Insert record into the database
'            Dim soaNumber As Integer = InsertRecord("", soaDate, ordertype, code, name, term, purchaseNumber, purchaseDate, quantity, subtotal, brochure, poster, drying, replace, ads, dueDate, totalAmount, balance, user, subamount)

'            ' Assign the generated soa_number to soatxt
'            soatxt = soaNumber.ToString()

'            ' Update the soa_txt field in the database
'            UpdateSoaTxt(soatxt, soaNumber)

'            MessageBox.Show("Insert Successfully!")


'            If walkCheck.Checked Then
'                ' Generate the Crystal Report
'                Dim report As New StatementOfAccount()
'                Dim selformula As String = "{acccounting1.soa_txt} = '" & soatxt & "'"
'                report.RecordSelectionFormula = selformula

'                ' Refresh the report to load data

'                report.Refresh()

'                Dim reportForm As New Form
'                Dim crystalReportViewer As New CrystalDecisions.Windows.Forms.CrystalReportViewer
'                crystalReportViewer.ReportSource = report
'                crystalReportViewer.Dock = DockStyle.Fill
'                reportForm.Controls.Add(crystalReportViewer)
'                reportForm.WindowState = FormWindowState.Maximized
'                reportForm.Show()
'            ElseIf monitoringCheck.Checked Then
'                ' Generate the Crystal Report
'                Dim report As New StatementOfAccount()
'                Dim selformula As String = "{acccounting1.soa_txt} = '" & soatxt & "'"
'                report.RecordSelectionFormula = selformula

'                ' Refresh the report to load data

'                report.Refresh()

'                Dim reportForm As New Form
'                Dim crystalReportViewer As New CrystalDecisions.Windows.Forms.CrystalReportViewer
'                crystalReportViewer.ReportSource = report
'                crystalReportViewer.Dock = DockStyle.Fill
'                reportForm.Controls.Add(crystalReportViewer)
'                reportForm.WindowState = FormWindowState.Maximized
'                reportForm.Show()
'            ElseIf replacementCheck.Checked Then
'                ' Generate the Crystal Report
'                Dim report As New StatementOfAccount()
'                Dim selformula As String = "{acccounting1.soa_txt} = '" & soatxt & "'"
'                report.RecordSelectionFormula = selformula

'                ' Refresh the report to load data
'                report.Refresh()

'                Dim reportForm As New Form
'                Dim crystalReportViewer As New CrystalDecisions.Windows.Forms.CrystalReportViewer
'                crystalReportViewer.ReportSource = report
'                crystalReportViewer.Dock = DockStyle.Fill
'                reportForm.Controls.Add(crystalReportViewer)
'                reportForm.WindowState = FormWindowState.Maximized
'                reportForm.Show()
'            ElseIf lopezCheck.Checked Then
'                ' Generate the Crystal Report
'                Dim report As New StatementOfAccountWithServiceFee()
'                Dim selformula As String = "{acccounting1.soa_txt} = '" & soatxt & "'"
'                report.RecordSelectionFormula = selformula

'                ' Refresh the report to load data
'                report.Refresh()

'                Dim reportForm As New Form
'                Dim crystalReportViewer As New CrystalDecisions.Windows.Forms.CrystalReportViewer
'                crystalReportViewer.ReportSource = report
'                crystalReportViewer.Dock = DockStyle.Fill
'                reportForm.Controls.Add(crystalReportViewer)
'                reportForm.WindowState = FormWindowState.Maximized
'                reportForm.Show()
'            Else
'                ' Generate the Crystal Report
'                Dim report As New StatementOfAccount()
'                Dim selformula As String = "{acccounting1.soa_txt} = '" & soatxt & "'"
'                report.RecordSelectionFormula = selformula

'                ' Refresh the report to load data
'                report.Refresh()

'                Dim reportForm As New Form
'                Dim crystalReportViewer As New CrystalDecisions.Windows.Forms.CrystalReportViewer
'                crystalReportViewer.ReportSource = report
'                crystalReportViewer.Dock = DockStyle.Fill
'                reportForm.Controls.Add(crystalReportViewer)
'                reportForm.WindowState = FormWindowState.Maximized
'                reportForm.Show()
'            End If

'            ' Clear input fields and refresh data grid view
'            cleartxt()
'            loaddgv()

'        Catch ex As Exception
'            MessageBox.Show("An error occurred during adding: " & ex.Message)
'        End Try
'    End If

'    ' Reset button state
'    addButton.Text = "ADD"
'    remLbl.Visible = False
'    remBox.Visible = False
'End Sub


'Private Function InsertOrder(orderType As String) As String
'    Dim soaNumber As Integer = InsertRecord("", Date.Now.Date, orderType, codeTxt.Text, nameBox.Text, termBox.Text,
'                                        purchaseBox.Text, dtpicker2.Value.Date, Integer.Parse(qtyTxt.Text),
'                                        Integer.Parse(amountTxt.Text), ParseOrZero(brochureTxt.Text), ParseOrZero(posterTxt.Text),
'                                        ParseOrZero(dryingTxt.Text), ParseOrZero(replaceTxt.Text),
'                                        Double.Parse(adsTxt.Text), dtpicker1.Value.Date,
'                                        Double.Parse(totalTxt.Text), Double.Parse(totalTxt.Text),
'                                        Login.userTxt.Text, Integer.Parse(amountTxt.Text))

'    UpdateSoaTxt(soaNumber.ToString(), soaNumber)
'    MessageBox.Show("Insert Successfully!")
'    Return soaNumber.ToString()
'End Function


'Private Sub addButton_Click(sender As Object, e As EventArgs) Handles addButton.Click
'    Dim isAnyChecked As Boolean = dgv1.Rows.Cast(Of DataGridViewRow)().
'                              Any(Function(row) Not row.IsNewRow AndAlso Convert.ToBoolean(row.Cells("cancelPo").Value))

'    If isAnyChecked Then
'        CancelPurchaseOrders()
'        cleartxt()
'        loaddgv()
'    Else
'        AddNewOrder()
'        cleartxt()
'        loaddgv()
'    End If

'    addButton.Text = "ADD"
'    remLbl.Visible = False
'    remBox.Visible = False
'End Sub

'If String.IsNullOrEmpty(qtyTxt.Text) Then
'    isFirstInput = True
'    amountTxt.Text = "0.00"   ' Default value for amountTxt
'    totalTxt.Text = "0.00"    ' Default value for totalTxt
'    Return
'End If

'Dim quantity As Double
'If Not Double.TryParse(qtyTxt.Text, quantity) Then
'    ' Show a message if the input is invalid and reset the textbox
'    MessageBox.Show("Please enter a valid number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'    qtyTxt.Text = "" ' Clear invalid input
'    Return
'End If

'' Perform calculations based on the selected checkbox
'If replacementCheck.Checked Then
'    CalculateTotalAmount(15)
'ElseIf walkCheck.Checked Then
'    CalculateTotalAmount(1750)
'ElseIf monitoringCheck.Checked Then
'    CalculateTotalAmount(400)
'ElseIf lopezCheck.Checked Then
'    CalculateTotalAmount(1800)
'Else
'    ' Default calculation: multiply by 1750 if no checkbox is selected
'    amountTxt.Text = (quantity * 1750).ToString("F2") ' Format with 2 decimal places
'End If

'' Update totalTxt.Text by adding the value from adsTxt.Text
'UpdateTotalAmount()

'Private Sub CancelPurchaseOrders()
'    For Each row As DataGridViewRow In dgv1.Rows.Cast(Of DataGridViewRow)().Where(Function(r) Not r.IsNewRow AndAlso Convert.ToBoolean(r.Cells("cancelPo").Value))
'        Try
'            row.Cells("total_amount").Value = 0
'            row.Cells("balance").Value = 0
'            row.Cells("remarks").Value = remBox.Text
'            row.Cells("order_type").Value &= " (Cancelled P.O)"

'            SaveCancellationToDatabase(remBox.Text, row.Cells("fac_code").Value.ToString())
'            MessageBox.Show("Cancelled P.O.")
'        Catch ex As Exception
'            MessageBox.Show("An error occurred during cancellation: " & ex.Message)
'        End Try
'    Next
'End Sub



