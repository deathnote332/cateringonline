Public Class Form1
    Dim option1 As New Dictionary(Of String, Array)
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        

        Dim option2 As Array = {"id", "first_name", "last_name"}
        option1.Add("fieldName", option2)

        dataGrid("users", DataGridView1, option1)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub
End Class
