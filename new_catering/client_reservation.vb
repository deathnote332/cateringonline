Public Class client_reservation

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        LoginPage.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        field.Add("reservation_date", DateTimePicker2.Value)
        field.Add("event_date", DateTimePicker1.Value)
        field.Add("name", TextBox1.Text)
        field.Add("contact", TextBox4.Text)
        field.Add("event_type_id", ComboBox4.Text)
        field.Add("package_id", ComboBox1.Text)
        field.Add("total_guest", ComboBox3.Text)
        Add(field, "reservations")


        MsgBox("Successfully Added new reservation", vbInformation, "Success")


    End Sub

    Private Sub client_reservation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getCombo("events", ComboBox4)
        ListView1.Visible = False
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        getCombo("packages", ComboBox1, "where event_id=" & ComboBox4.SelectedItem.Value & "")
        ListView1.Visible = False
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim getMenuId As Integer = 0
        rs.Open("select * from menus where package_id=" & ComboBox1.SelectedItem.Value & "", connection(), 2, 2)
        getMenuId = rs("id").Value
        rs.Close()

        getFood("foods", ListView1, 1, getMenuId)
        ListView1.Visible = True
    End Sub
End Class