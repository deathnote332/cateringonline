Imports System.IO

Module functions

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

    Public dataGridField As New Dictionary(Of String, Array)

    Public clearField As Array

    ' Dim con As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\john.inhog\Desktop\sample.mdb"
    '    Public con As String = "Driver={MySQL ODBC 5.3 ANSI Driver};Server=localhost;Database=catering;Uid=root;Password='';"

    Public Function connection()
        Dim con As String = ""
        If (conType.Equals("mysql")) Then
            con = "Driver={MySQL ODBC 5.3 ANSI Driver};Server=" & host & ";Uid=" & hostName & ";Password=" & hostpassword & ";Database=" & dbName & ""
        ElseIf (conType.Equals("access")) Then
            con = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Jampol\Documents\Visual Studio 2012\Projects\cateringonline\sample.mdb"
        End If
        Return con
    End Function


    Public Function login(username As String, password As String)
        rs.Open("select * from users where username = '" & username & "' and password='" & password & "'")
        If Not rs.EOF Then
            MsgBox("Login Successfully", vbInformation, "Success")
        Else
            MsgBox("Invalid credentials", vbCritical, "Error")
        End If
        rs.Close()
    End Function

    Public Function dataGrid(dg As DataGridView, options As Dictionary(Of String, Array), tableName As String)
        dg.Columns.Clear()
        For Each colName In options("colName")
            Dim col As New DataGridViewTextBoxColumn
            col.Name = colName
            dg.Columns.Add(col)
        Next

        rs.Open("select * from " & tableName & "", connection(), 2, 2)
        dg.Rows.Clear()
        Do Until rs.EOF
            Dim dataList As New ArrayList
            For Each fieldName In options("dataFieldName")
                If (fieldName.Equals("event_id")) Then
                    Dim rs1 As New ADODB.Recordset
                    rs1.Open("select * from events where id=" & rs(fieldName).Value & "", connection(), 2, 2)
                    dataList.Add(rs1("event_name").Value)
                    rs1.Close()
                ElseIf (fieldName.Equals("image")) Then
                    
                    dataList.Add(System.Text.Encoding.Unicode.GetString(rs(fieldName).Value))
                Else

                    dataList.Add(rs(fieldName).Value)
                End If

            Next
            dg.Rows.Add(dataList.ToArray)
            rs.MoveNext()
        Loop
        rs.Close()
        options.Clear()
        dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dg.AllowUserToAddRows = False
        dg.AllowUserToDeleteRows = False
        dg.AllowUserToOrderColumns = False
        dg.AllowUserToResizeColumns = False
        dg.AllowUserToResizeRows = False


    End Function

    Public Function delete(tableName As String, id As String)
        rs.Open("select * from " & tableName & " where id=" & id & "", connection(), 2, 2)
        rs.Delete()
        rs.Close()
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

    Public Function Updates(fields As Dictionary(Of String, String), tableName As String, Optional ByVal query As String = "")
        rs.Open("select * from " & tableName & " " & query & "", connection(), 2, 2)
        For Each dic As KeyValuePair(Of String, String) In fields
            rs(dic.Key).Value = dic.Value
        Next
        rs.Update()
        rs.Close()
        fields.Clear()
    End Function

    
    Public Function getCombo(tableName As String, cb As ComboBox, Optional ByVal query As String = "")
        Dim combodic As New Dictionary(Of String, String)

        rs.Open("select * from " & tableName & " " & query & "", connection(), 2, 2)

        cb.Items.Clear()
        Do Until rs.EOF
            cb.Items.Add(New DictionaryEntry(rs("" & tableName.Substring(0, tableName.Length - 1) & "_name").Value(), rs("id").Value()))
            rs.MoveNext()
        Loop
        cb.DisplayMember = "Key"
        cb.ValueMember = "Value"

        rs.Close()
        
    End Function

    Public Function getFood(menu_id As String, tableName As String, lvt As Windows.Forms.ListView)
        rs.Open("select * from " & tableName & "", connection(), 2, 2)
        lvt.Items.Clear()

        Do Until rs.EOF
            Dim lvItem As New ListViewItem
            lvItem.SubItems.Add("" & rs("" & tableName.Substring(0, tableName.Length - 1) & "_name").Value())
            lvt.Items.Add(lvItem)
            rs.MoveNext()
        Loop
        rs.Close()

    End Function


End Module
