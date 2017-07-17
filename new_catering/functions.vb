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
    Private url As String = "http://192.168.254.120/webRequest.php?"


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


    'GET DATA FROM TBLWAITING-DONE
    Public Function dataGrid1(dg As DataGridView, options As Dictionary(Of String, Array))
        Dim data = GETURLREQUEST("http://192.168.254.120/webRequest.php?function=getEvent")


        dg.Columns.Clear()
        For Each colName In options("colName")
            Dim col As New DataGridViewTextBoxColumn
            col.Name = colName
            dg.Columns.Add(col)
        Next


        dg.Rows.Clear()

        Dim datas As JArray = JArray.Parse(data)
        For Each jtoken As JToken In datas
            dg.Rows.Add(jtoken("id"), jtoken("event_name"), jtoken("file_name"), jtoken("event_description"), jtoken("image"))

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


End Module
