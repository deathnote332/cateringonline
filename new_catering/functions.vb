Imports System.Drawing.Imaging
Imports System.IO

Module functions

    Public colNames As Array
    Public dataFieldName As Array

    'connection
    Public conType As String = "access"
    Dim host As String = "localhost"
    Dim hostName As String = "root"
    Dim hostpassword As String = ""
    Dim dbName As String = "catering"
    Public rs As New ADODB.Recordset

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
            con = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\xampp\htdocs\cateringonline\sample.mdb"
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

    Public Function dataGrid(dg As DataGridView, options As Dictionary(Of String, Array), tableName As String, Optional ByVal query As String = "")
        dg.Columns.Clear()
        For Each colName In options("colName")
            Dim col As New DataGridViewTextBoxColumn
            col.Name = colName
            dg.Columns.Add(col)
        Next


        rs.Open("select * from " & tableName & " " & query & "", connection(), 2, 2)
        dg.Rows.Clear()
        Do Until rs.EOF
            Dim dataList As New ArrayList
            For Each fieldName In options("dataFieldName")
                If (fieldName.Equals("event_id")) Then
                    Dim rs1 As New ADODB.Recordset
                    rs1.Open("select * from events where id=" & rs(fieldName).Value & "", connection(), 2, 2)
                    dataList.Add(rs1("event_name").Value)
                    rs1.Close()
                ElseIf (fieldName.Equals("food_type_id")) Then
                    Dim rs1 As New ADODB.Recordset
                    rs1.Open("select * from food_type where id=" & rs(fieldName).Value & "", connection(), 2, 2)
                    dataList.Add(rs1("food_type").Value)
                    rs1.Close()
                ElseIf (fieldName.Equals("event_id")) Then
                    Dim rs1 As New ADODB.Recordset
                    rs1.Open("select * from events where id=" & rs(fieldName).Value & "", connection(), 2, 2)
                    dataList.Add(rs1("event_name").Value)
                    rs1.Close()
                ElseIf (fieldName.Equals("package_id")) Then
                    Dim rs1 As New ADODB.Recordset
                    rs1.Open("select * from packages where id=" & rs(fieldName).Value & "", connection(), 2, 2)
                    dataList.Add(rs1("package_name").Value)
                    rs1.Close()
                ElseIf (fieldName.Equals("image")) Then

                    dataList.Add(rs(fieldName).Value)
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


    Public Function delete(tableName As String, Optional ByVal query As String = "")
        rs.Open("select * from " & tableName & " " & query & "", connection(), 2, 2)
        Do Until rs.EOF
            rs.Delete()
            rs.Update()
            rs.MoveNext()
        Loop
        rs.Close()
    End Function

    Public Function Add(fields As Dictionary(Of String, String), tableName As String, Optional ByVal image As Byte() = Nothing)
        rs.Open("select * from " & tableName & "", connection(), 2, 2)
        rs.AddNew()
        For Each dic As KeyValuePair(Of String, String) In fields
            If (dic.Key.Equals("image")) Then
                rs(dic.Key).Value = image
            Else
                rs(dic.Key).Value = dic.Value
            End If
        Next
        rs.Update()
        rs.Close()
        fields.Clear()
    End Function

    Public Function Updates(fields As Dictionary(Of String, String), tableName As String, Optional ByVal query As String = "", Optional ByVal image As Byte() = Nothing)
        rs.Open("select * from " & tableName & " " & query & "", connection(), 2, 2)
        For Each dic As KeyValuePair(Of String, String) In fields
            If (dic.Key.Equals("image")) Then
                rs(dic.Key).Value = image
            Else
                rs(dic.Key).Value = dic.Value
            End If
        Next
        rs.Update()
        rs.Close()
        fields.Clear()
    End Function


    Public Function getCombo(tableName As String, cb As ComboBox, Optional ByVal query As String = "", Optional ByVal customItem As String = "")
        Dim combodic As New Dictionary(Of String, String)

        rs.Open("select * from " & tableName & " " & query & "", connection(), 2, 2)
        cb.Items.Clear()


        If Not (customItem.Equals("")) Then
            cb.Items.Add(New DictionaryEntry(customItem, 0))
        End If

        Do Until rs.EOF
            If (tableName.Equals("food_type")) Then
                cb.Items.Add(New DictionaryEntry(rs("food_type").Value(), rs("id").Value()))
            Else
                cb.Items.Add(New DictionaryEntry(rs("" & tableName.Substring(0, tableName.Length - 1) & "_name").Value(), rs("id").Value()))
            End If
            rs.MoveNext()
        Loop
        cb.DisplayMember = "Key"
        cb.ValueMember = "Value"



        rs.Close()

    End Function

    Public Function getFood(tableName As String, lvt As Windows.Forms.ListView, Optional ByVal join As Integer = 0, Optional ByVal menu_id As String = "")

        If (join = 0) Then
            rs.Open("select * from " & tableName & "", connection(), 2, 2)
            lvt.Items.Clear()

            Do Until rs.EOF
                Dim lvItem As New ListViewItem
                lvItem.SubItems.Add("" & rs("" & tableName.Substring(0, tableName.Length - 1) & "_name").Value())
                Dim rs1 As New ADODB.Recordset
                rs1.Open("select * from food_type where id=" & rs("food_type_id").Value & "", connection(), 2, 2)
                lvItem.SubItems.Add("" & rs1("food_type").Value())

                rs1.Close()
                lvItem.SubItems.Add("" & rs("id").Value())

                lvt.Items.Add(lvItem)
                rs.MoveNext()
            Loop
            rs.Close()
        Else
            Dim rs2 As New ADODB.Recordset
            rs2.Open("select * from food_menu where menu_id=" & menu_id & "", connection(), 2, 2)
            lvt.Items.Clear()
            Do Until rs2.EOF
                rs.Open("select * from " & tableName & " where id=" & rs2("food_id").Value & "", connection(), 2, 2)


                Do Until rs.EOF
                    Dim lvItem As New ListViewItem
                    lvItem.SubItems.Add("" & rs("" & tableName.Substring(0, tableName.Length - 1) & "_name").Value())
                    Dim rs1 As New ADODB.Recordset
                    rs1.Open("select * from food_type where id=" & rs("food_type_id").Value & "", connection(), 2, 2)
                    lvItem.SubItems.Add("" & rs1("food_type").Value())

                    rs1.Close()
                    lvItem.SubItems.Add("" & rs("id").Value())

                    lvt.Items.Add(lvItem)
                    rs.MoveNext()
                Loop
                rs.Close()

                rs2.MoveNext()
            Loop
            rs2.Close()
        End If

    End Function


    ' this is easily used from a class or converted to an extension
    Public Function ImgToByteArray(img As Image, imgFormat As ImageFormat) As Byte()
        Dim tmpData As Byte()
        Using ms As New MemoryStream()
            img.Save(ms, imgFormat)

            tmpData = ms.ToArray
        End Using              ' dispose of memstream
        Return tmpData
    End Function

End Module
