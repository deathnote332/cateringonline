Public Class Dashboard

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

    Private Sub side_menus_Click(sender As Object, e As EventArgs) Handles side_menus.Click
        menu_page.Show()

        Me.Hide()
    End Sub


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click

    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click

    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click

    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click

    End Sub

    Private Sub side_dash_Paint(sender As Object, e As PaintEventArgs) Handles side_dash.Paint

    End Sub

    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
