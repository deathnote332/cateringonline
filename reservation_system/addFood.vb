Public Class addFood
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        field.Add("food_name", TextBox1.Text)

        Add(field, "foods")
        getFood(1, "foods", ListView.ListView1)
        Me.Hide()

    End Sub
End Class