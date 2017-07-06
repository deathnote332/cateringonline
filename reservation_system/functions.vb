﻿Module functions

    Public colNames As Array
    Public dataFieldName As Array

    'connection
    Public conType As String = "mysql"
    Dim host As String = "localhost"
    Dim hostName As String = "root"
    Dim hostpassword As String = ""
    Dim dbName As String = "catering"
    Dim rs As New ADODB.Recordset

    Public field As New Dictionary(Of String, String)

    ' Dim con As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\john.inhog\Desktop\sample.mdb"
    '    Public con As String = "Driver={MySQL ODBC 5.3 ANSI Driver};Server=localhost;Database=catering;Uid=root;Password='';"

    Public Function connection()
        Dim con As String = ""
        If (conType.Equals("mysql")) Then
            con = "Driver={MySQL ODBC 5.3 ANSI Driver};Server=" & host & ";Uid=" & hostName & ";Password=" & hostpassword & ";Database=" & dbName & ""
        ElseIf (conType.Equals("access")) Then
            con = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\john.inhog\Desktop\sample.mdb"
        End If
        Return con
    End Function



    Public Function dataGrid(dg As DataGridView, options As Dictionary(Of String, Array), con As String, tableName As String)

        For Each colName In options("colName")
            Dim col As New DataGridViewTextBoxColumn
            col.Name = colName
            dg.Columns.Add(col)
        Next

        rs.Open("select * from '" & tableName & "'", connection(), 2, 2)

        Do Until rs.EOF
            Dim dataList As New ArrayList
            For Each fieldName In options("dataFieldName")
                dataList.Add(rs("" & fieldName & "").Value)
            Next
            dg.Rows.Add(dataList.ToArray)
            rs.MoveNext()
        Loop
        rs.Close()

        dg.AutoResizeColumns()

    End Function

    Public Function delete(id As String)

        rs.Open("delete * from users where id=" & id & "", connection(), 2, 2)


    End Function

    Public Function Add(fields As Dictionary(Of String, String), tableName As String)
        rs.Open("select * from " & tableName & "", connection(), 2, 2)
        rs.AddNew()
        For Each dic As KeyValuePair(Of String, String) In fields
            rs(dic.Key).Value = dic.Value

        Next
        rs.Update()
        rs.Close()

        fields.Clear()

    End Function

    Public Function Update(fields As Dictionary(Of String, String), tableName As String)
        rs.Open("select * from " & tableName & "", connection(), 2, 2)

        For Each dic As KeyValuePair(Of String, String) In fields
            rs(dic.Key).Value = dic.Value

        Next
        rs.Update()
        rs.Close()

        fields.Clear()

    End Function



End Module
