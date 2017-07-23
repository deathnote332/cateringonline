Imports System.Drawing.Imaging
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports System.Net
Imports Newtonsoft.Json.Linq

Module functions

    Public colNames As Array
    Public dataFieldName As Array

    'connection
    Public conType As String = "mysql"
    Dim host As String = "localhost"
    Dim hostName As String = "root"
    Dim hostpassword As String = ""
    Dim dbName As String = "catering"
    Public rs As New ADODB.Recordset
    Public field As New Dictionary(Of String, String)

    Public dataGridField As New Dictionary(Of String, Array)
    Private url As String = "http://192.168.43.113/webRequest.php?function="


    Public Function httpPost(fields As Dictionary(Of String, String), requestUrl As String)
        Dim request As WebRequest = WebRequest.Create(url & requestUrl)
        request.Method = "POST"
        Dim postData As String = ""

        For Each dic As KeyValuePair(Of String, String) In fields
            postData += "&" & dic.Key & "=" + dic.Value
        Next
        field.Clear()

        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
        request.ContentType = "application/x-www-form-urlencoded"
        request.ContentLength = byteArray.Length
        Dim dataStream As Stream = request.GetRequestStream()
        dataStream.Write(byteArray, 0, byteArray.Length)
        dataStream.Close()
        Dim response As WebResponse = request.GetResponse()
        Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
        dataStream = response.GetResponseStream()
        Dim reader As New StreamReader(dataStream)
        Dim responseFromServer As String = reader.ReadToEnd()
        reader.Close()
        dataStream.Close()
        response.Close()
        MsgBox(responseFromServer)
        Return responseFromServer

    End Function

    Public Function deletes(fields As Dictionary(Of String, String))
        Dim request As WebRequest = WebRequest.Create(url & "deleteData")
        request.Method = "POST"
        Dim postData As String = ""

        For Each dic As KeyValuePair(Of String, String) In fields
            postData += "&" & dic.Key & "=" + dic.Value
        Next
        field.Clear()

        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
        request.ContentType = "application/x-www-form-urlencoded"
        request.ContentLength = byteArray.Length
        Dim dataStream As Stream = request.GetRequestStream()
        dataStream.Write(byteArray, 0, byteArray.Length)
        dataStream.Close()
        Dim response As WebResponse = request.GetResponse()
        Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
        dataStream = response.GetResponseStream()
        Dim reader As New StreamReader(dataStream)
        Dim responseFromServer As String = reader.ReadToEnd()
        reader.Close()
        dataStream.Close()
        response.Close()
        MsgBox(responseFromServer)
        Return responseFromServer

    End Function



    Public Function GETURLREQUEST(URL As String)
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse
        Dim reader As StreamReader

        request = DirectCast(WebRequest.Create(URL), HttpWebRequest)

        response = DirectCast(request.GetResponse(), HttpWebResponse)
        reader = New StreamReader(response.GetResponseStream())

        Dim data As String
        data = reader.ReadToEnd

        Return data

    End Function

    Public Function dataGrid(dg As DataGridView, options As Dictionary(Of String, Array))

        dg.Columns.Clear()
        For Each colName In options("colName")
            Dim col As New DataGridViewTextBoxColumn
            col.Name = colName
            dg.Columns.Add(col)
        Next

        options.Clear()

        dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dg.AllowUserToAddRows = False
        dg.AllowUserToDeleteRows = False
        dg.AllowUserToOrderColumns = False
        dg.AllowUserToResizeColumns = False
        dg.AllowUserToResizeRows = False

        Return Nothing
    End Function

    'GET Reservation
    Public Function getReservation(dg As DataGridView, options As Dictionary(Of String, Array))
        Dim data = GETURLREQUEST(url & "getReservation")

        dataGrid(dg, options)

        dg.Rows.Clear()

        Dim datas As JArray = JArray.Parse(data)
        For Each jtoken As JToken In datas
            dg.Rows.Add(jtoken("id"), jtoken("first_name"), jtoken("last_name"), jtoken("contact"), jtoken("reservation_date"), jtoken("event_date"), jtoken("venue"), jtoken("event_name"), jtoken("package_name"), jtoken("total_guest"), jtoken("add_ons"))

        Next


        Return Nothing
    End Function


    'GET EVENTS
    Public Function getEvent(dg As DataGridView, options As Dictionary(Of String, Array))
        Dim data = GETURLREQUEST(url & "getEvent")

        dataGrid(dg, options)

        dg.Rows.Clear()

        Dim datas As JArray = JArray.Parse(data)
        For Each jtoken As JToken In datas
            dg.Rows.Add(jtoken("id"), jtoken("event_name"), jtoken("file_name"), jtoken("event_description"), jtoken("image"))

        Next


        Return Nothing
    End Function

    'GET PACKAGES
    Public Function getPackage(dg As DataGridView, options As Dictionary(Of String, Array))
        Dim data = GETURLREQUEST(url & "getPackage")

        dataGrid(dg, options)

        dg.Rows.Clear()

        
        Dim datas As JArray = JArray.Parse(data)
        For Each jtoken As JToken In datas
            dg.Rows.Add(jtoken("id"), jtoken("event_name"), jtoken("package_name"), jtoken("price_head"))

        Next


        Return Nothing
    End Function

    
    'GET FOODs
    Public Function getFood(dg As DataGridView, options As Dictionary(Of String, Array))
        Dim data = GETURLREQUEST(url & "getFood")

        dataGrid(dg, options)

        dg.Rows.Clear()

        Dim datas As JArray = JArray.Parse(data)
        For Each jtoken As JToken In datas
            dg.Rows.Add(jtoken("id"), jtoken("food_type"), jtoken("food_name"), jtoken("food_description"), jtoken("file_name"), jtoken("image"))

        Next
        Return Nothing
    End Function

    'GET MENUS
    Public Function getMenu(dg As DataGridView, options As Dictionary(Of String, Array))
        Dim data = GETURLREQUEST(url & "getMenu")

        dataGrid(dg, options)

        dg.Rows.Clear()

        Dim datas As JArray = JArray.Parse(data)
        For Each jtoken As JToken In datas
            dg.Rows.Add(jtoken("id"), jtoken("menu_name"), jtoken("event_name"), jtoken("package_name"))

        Next

        Return Nothing
    End Function

    Public Function getComboEventName(cb As ComboBox)
        Dim combodic As New Dictionary(Of String, String)

        Dim data = GETURLREQUEST(url & "getEvent")

        cb.Items.Clear()


        Dim datas As JArray = JArray.Parse(data)
        For Each jtoken As JToken In datas
            cb.Items.Add(New DictionaryEntry(jtoken("event_name"), jtoken("id")))

        Next


        cb.DisplayMember = "Key"
        cb.ValueMember = "Value"

        Return Nothing
    End Function

    Public Function getComboPackageName(cb As ComboBox)
        Dim combodic As New Dictionary(Of String, String)

        Dim data = GETURLREQUEST(url & "getPackage")

        cb.Items.Clear()


        Dim datas As JArray = JArray.Parse(data)
        For Each jtoken As JToken In datas
            cb.Items.Add(New DictionaryEntry(jtoken("package_name"), jtoken("id")))

        Next


        cb.DisplayMember = "Key"
        cb.ValueMember = "Value"

        Return Nothing
    End Function


    Public Function getComboFoodType(cb As ComboBox)
        Dim combodic As New Dictionary(Of String, String)

        Dim data = GETURLREQUEST(url & "getFoodType")

        cb.Items.Clear()


        Dim datas As JArray = JArray.Parse(data)
        For Each jtoken As JToken In datas
            cb.Items.Add(New DictionaryEntry(jtoken("food_type"), jtoken("id")))

        Next


        cb.DisplayMember = "Key"
        cb.ValueMember = "Value"
        Return Nothing

    End Function

    Public Function getFoodList(lvt As ListView)
        lvt.Items.Clear()


        Dim data = GETURLREQUEST(url & "getFood")



        Dim datas As JArray = JArray.Parse(data)
        For Each jtoken As JToken In datas
            Dim lvItem As New ListViewItem
            lvItem.SubItems.Add(jtoken("food_name"))
            lvItem.SubItems.Add(jtoken("food_type"))
            lvItem.SubItems.Add(jtoken("id"))
            lvt.Items.Add(lvItem)

        Next

        Return Nothing

    End Function



    Public Function getEventimage(event_id As String)


        Dim request As WebRequest = WebRequest.Create(url & "getEventimage")
        request.Method = "POST"
        Dim postData As String = ""
        postData = "event_id=" + event_id
        

        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
        request.ContentType = "application/x-www-form-urlencoded"
        request.ContentLength = byteArray.Length
        Dim dataStream As Stream = request.GetRequestStream()
        dataStream.Write(byteArray, 0, byteArray.Length)
        dataStream.Close()
        Dim response As WebResponse = request.GetResponse()
        Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
        dataStream = response.GetResponseStream()
        Dim reader As New StreamReader(dataStream)
        Dim responseFromServer As String = reader.ReadToEnd()
        reader.Close()
        dataStream.Close()
        response.Close()
        
        
        Dim image_event As String
        Dim datas As JArray = JArray.Parse(responseFromServer)
        For Each jtoken As JToken In datas
            image_event = jtoken("image")
        Next

        Return image_event

    End Function

End Module

