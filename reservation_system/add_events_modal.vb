Public Class add_events_modal

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        field.Add("event_name", TextBox2.Text)
        field.Add("event_description", RichTextBox1.Text)

        Add(field, "events")

    End Sub
End Class