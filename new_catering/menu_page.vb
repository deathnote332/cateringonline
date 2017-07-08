Public Class menu_page

    Private Sub side_dash_Click(sender As Object, e As EventArgs) Handles side_dash.Click
        Dashboard.Show()
        Me.Hide()
    End Sub

    Private Sub side_reserv_Click(sender As Object, e As EventArgs) Handles side_reserv.Click
        Reservation.Show()
        Me.Hide()
    End Sub

    Private Sub side_event_Click(sender As Object, e As EventArgs) Handles side_event.Click
        Events_page.Show()
        Me.Hide()
    End Sub

    Private Sub side_pack_Click(sender As Object, e As EventArgs) Handles side_pack.Click
        Packages.Show()
        Me.Hide()
    End Sub

    Private Sub menu_page_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getCombo("events", ComboBox1)

        ComboBox2.Enabled = False
        Button1.Enabled = False
        Button3.Enabled = False
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        getCombo("packages", ComboBox2, "where event_id=" & ComboBox1.SelectedItem.Value & "")

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub
End Class
