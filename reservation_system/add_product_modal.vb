Public Class add_product_modal

    
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        field.Add("name", TextBox2.Text)
        field.Add("description", RichTextBox1.Text)
        field.Add("category", ComboBox1.Text)
        field.Add("price", TextBox3.Text)
        field.Add("status", ComboBox2.Text)

        Add(field, "foods")

    End Sub
End Class