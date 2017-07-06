Module Functions

    Public rs As New ADODB.Recordset
    Public con As String = "Driver={MySQL ODBC 5.3 ANSI Driver};Server=localhost;Database=catering;Uid=root;Password='';"

    Public Function login(username As String, password As String, directedForm As Form)
        Dim str As String = "select * from users where username ='" & username & "' and password ='" & "SHA1(" & password & ")" & "'"
        rs.Open(str, con)
        If Not rs.EOF Then
            MsgBox("Login Successfully")
            directedForm.Show()
            Form1.Hide()
        Else
            MsgBox("Invalid credentials")
        End If
        rs.Close()
        Return Nothing
    End Function


    Public Function dataGrid(tableName As String, dg As DataGridView, options As Dictionary(Of String, Array))
        'creating the columnName
        Dim fieldName As Array
        For Each dataField In options("fieldName")
            Dim col As New DataGridViewTextBoxColumn
            col.Name = dataField
            dg.Columns.Add(col)

        Next
        Dim cols As New DataGridViewTextBoxColumn
        cols.Name = "Actionn"
        dg.Columns.Add(cols)
        Dim query As String = "select * from " & tableName
        rs.Open(query, con)

        Do Until rs.EOF
            Dim addRow As New ArrayList
            For Each dataField In options("fieldName")
                addRow.Add(rs("" & dataField & "").Value)
            Next
            Dim btn As New DataGridViewButtonColumn
            btn.Text = "Click Here"
            btn.Name = "btn"
            btn.UseColumnTextForButtonValue = True

            dg.Columns.Insert(2, btn)
            dg.Rows.Add(addRow.ToArray)

            rs.MoveNext()
        Loop
        rs.con()

    End Function

End Module
