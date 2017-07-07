Public Class Form1
    Private Sub Events_list_Click(sender As Object, e As EventArgs) Handles Events_list.Click
        Events_panel.Show()
        Reserve_panel.Hide()
        Food_panel.Hide()
        Service_panel.Hide()
        Paclages_panel.Hide()
        Menu_panel.Hide()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        add_events_modal.ShowDialog()


    End Sub

    Private Sub Packages_list_Click(sender As Object, e As EventArgs) Handles Packages_list.Click
        Events_panel.Hide()
        Reserve_panel.Hide()
        Food_panel.Hide()
        Service_panel.Hide()
        Paclages_panel.Show()
        Menu_panel.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        add_package_modal.ShowDialog()

    End Sub

    Private Sub Menus_list_Paint(sender As Object, e As PaintEventArgs) Handles Menus_list.Paint

    End Sub

    Private Sub Menus_list_Click(sender As Object, e As EventArgs) Handles Menus_list.Click
        Events_panel.Hide()
        Reserve_panel.Hide()
        Food_panel.Hide()
        Service_panel.Hide()
        Paclages_panel.Hide()
        Menu_panel.Show()
    End Sub
End Class
