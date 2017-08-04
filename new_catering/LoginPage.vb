Imports System.IO
Imports Newtonsoft.Json.Linq

Public Class LoginPage

    Private Sub LoginPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

        client_reservation.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim message As String


        field.Add("username", TextBox1.Text)
        field.Add("password", TextBox2.Text)
        message = httpPost(field, "login")

        If Not (message.Equals("Invalid credentials")) Then
            MsgBox("Login successfully")
            userType = 0
            userType = message
            Dim fname As String = ""
            Dim lname As String = ""

            Dim datas As JArray = JArray.Parse(message)
            For Each jtoken As JToken In datas
                userType = jtoken("user_type")
                fname = jtoken("first_name")
                lname = jtoken("last_name")

            Next
            Dashboard.Label1.Text = fname & " " & lname
            Dashboard.Label28.Text = "Administrator"
            Me.Hide()
            Dashboard.Show()
        Else
            MsgBox(message)

            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox1.Focus()
        End If


    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        End
    End Sub
End Class