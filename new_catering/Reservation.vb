Public Class Reservation

    Private Sub side_dash_Click(sender As Object, e As EventArgs) Handles side_dash.Click
        Me.Hide()
        Dashboard.Show()
    End Sub

    Private Sub side_event_Click(sender As Object, e As EventArgs) Handles side_event.Click
        Me.Hide()
        Events_page.Show()
    End Sub

    Private Sub side_pack_Click(sender As Object, e As EventArgs) Handles side_pack.Click
        Me.Hide()
        Packages.Show()
    End Sub

    Private Sub side_menus_Click(sender As Object, e As EventArgs) Handles side_menus.Click
        Me.Hide()
        menu_page.Show()
    End Sub

End Class
