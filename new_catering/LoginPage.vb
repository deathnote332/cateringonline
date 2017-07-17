Imports System.IO

Public Class LoginPage

    Private Sub LoginPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

        client_reservation.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'login(TextBox1.Text, TextBox2.Text)
        'Dashboard.Show()

        MsgBox(Directory.GetCurrentDirectory())

        'field.Add("username", TextBox1.Text)
        'field.Add("password", TextBox2.Text)
        'Add(field, "users")
        'MsgBox("Successfully Added new reservation", vbInformation, "Success")


    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class