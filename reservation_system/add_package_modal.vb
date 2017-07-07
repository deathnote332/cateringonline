Public Class add_package_modal

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim key As String = DirectCast(ComboBox1.SelectedItem, KeyValuePair(Of String, String)).Key



        field.Add("package_name", TextBox3.Text)
        field.Add("event_id", key)
        field.Add("total_guest", ComboBox2.Text)
        field.Add("price", TextBox2.Text)
        Add(field, "packages")

    End Sub

    Private Sub add_package_modal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getList("events", ComboBox1)
    End Sub
End Class