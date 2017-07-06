Public Class Form1

    Private Sub Reserve_list_Click(sender As Object, e As EventArgs) Handles Reserve_list.Click
        Reserve_panel.Show()
        Food_panel.Hide()
        Service_panel.Hide()
        Decoration_panel.Hide()
        Menu_panel.Hide()
        Venue_panel.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        add_product_modal.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        add_service_modal.Show()
    End Sub

    Private Sub Food_list_Click(sender As Object, e As EventArgs) Handles Food_list.Click
        Food_panel.Show()
        Service_panel.Hide()
        Reserve_panel.Hide()
        Decoration_panel.Hide()
        Menu_panel.Hide()
        Venue_panel.Hide()
    End Sub


    Private Sub Service_list_Click(sender As Object, e As EventArgs) Handles Service_list.Click
        Service_panel.Show()
        Reserve_panel.Hide()
        Food_panel.Hide()
        Decoration_panel.Hide()
        Menu_panel.Hide()
        Venue_panel.Hide()
    End Sub

    Private Sub Decoration_list_Click(sender As Object, e As EventArgs) Handles Decoration_list.Click
        Decoration_panel.Show()
        Food_panel.Hide()
        Reserve_panel.Hide()
        Service_panel.Hide()
        Menu_panel.Hide()
        Venue_panel.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        add_decoration_modal.Show()
    End Sub

    Private Sub Menu_list_Click(sender As Object, e As EventArgs) Handles Menu_list.Click
        Menu_panel.Show()
        Food_panel.Hide()
        Reserve_panel.Hide()
        Service_panel.Hide()
        Decoration_panel.Hide()
        Venue_panel.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        add_menu_modal.Show()
    End Sub


    Private Sub Venue_list_Click(sender As Object, e As EventArgs) Handles Venue_list.Click
        Venue_panel.Show()
        Menu_panel.Hide()
        Food_panel.Hide()
        Reserve_panel.Hide()
        Service_panel.Hide()
        Decoration_panel.Hide()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        add_venue_modal.Show()
    End Sub
End Class
