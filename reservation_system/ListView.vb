Public Class ListView
    Friend items As Object

    Private Sub ListView_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        getFood(1, "foods", ListView1)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        addFood.ShowDialog()
    End Sub
End Class