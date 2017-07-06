Public Class add_venue_modal

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        field.Add("name", TextBox2.Text)
        field.Add("description", RichTextBox1.Text)

        Add(field, "venues")

    End Sub
End Class