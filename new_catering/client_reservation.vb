Public Class client_reservation

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        LoginPage.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        If (fname.Text = "" Or contact.Text = "" Or package.Text = "" Or ComboBox3.Text = "" Or event_type.Text = "") Then
            MsgBox("Please input required fields", vbCritical, "Error")

        Else

            rs.Open("select * from  reservations where event_date='" & doe.Value.ToShortDateString & "'", connection(), 2, 2)
            If Not (rs.EOF) Then
                rs.Close()

                MsgBox("Date has already reserve", vbCritical, "Error")
                doe.Focus()
            Else
                rs.Close()
                field.Add("reservation_date", Date.Now())
                field.Add("event_date", doe.Value.ToShortDateString)
                field.Add("first_name", fname.Text)
                field.Add("last_name", lname.Text)
                field.Add("venue", venue.Text)
                field.Add("contact", fname.Text)
                field.Add("event_id", event_type.SelectedItem.Value)
                field.Add("package_id", package.SelectedItem.Value)
                field.Add("total_guest", ComboBox3.Text)
                field.Add("add_ons", addons.Text)
                Add(field, "reservations")
                MsgBox("Successfully Added new reservation", vbInformation, "Success")
                resetForm()


            End If

        End If


    End Sub

    Private Sub client_reservation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getCombo("events", event_type)
        resetForm()
    End Sub



    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles event_type.SelectedIndexChanged
        getCombo("packages", package, "where event_id=" & event_type.SelectedItem.Value & "")
        ListView1.Visible = False

    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles package.SelectedIndexChanged
        Dim getMenuId As Integer = 0
        rs.Open("select * from menus where package_id=" & package.SelectedItem.Value & "", connection(), 2, 2)
        getMenuId = rs("id").Value
        rs.Close()
        Label4.Visible = True
        Label4.Text = "Menu of " & package.Text
        getFood("foods", ListView1, 1, getMenuId)
        PictureBox2.Height = 264

        ListView1.Visible = True
    End Sub

    Private Sub ComboBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles event_type.KeyPress
        e.Handled = True
    End Sub

    Private Sub ComboBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles package.KeyPress
        e.Handled = True
    End Sub

    Private Sub ComboBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox3.KeyPress
        e.Handled = True
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles contact.KeyPress
        If Not IsNumeric(e.KeyChar) And Not Asc(e.KeyChar) = 8 And Not Asc(e.KeyChar) = 45 Then
            e.Handled = True
        End If

    End Sub
    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles fname.KeyPress
        If IsNumeric(e.KeyChar) Then
            e.Handled = True
        Else
            e.Handled = False
        End If

    End Sub

    Public Function resetForm()
        ListView1.Visible = False
        Label4.Visible = False
        Dim currentYear = Date.Now().Year
        Dim currentMonthadvance2months = Date.Now().AddMonths(2).Month
        doe.MinDate = New Date(currentYear, currentMonthadvance2months, 1)

        contact.Clear()
        fname.Clear()
        addons.Clear()
        package.Text = ""
        ComboBox3.Text = ""
        event_type.Text = ""
        venue.Text = ""
        lname.Text = ""

        PictureBox2.Height = 515

        Return Nothing
    End Function

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles contact.TextChanged

    End Sub
End Class