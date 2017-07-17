Imports System.Drawing.Imaging
Imports System.IO

Public Class Dashboard

    Dim isRemove As Boolean = False
    Dim listCount As Integer = 0
    Dim isSelectedFile As Integer = 0
    Dim filename As String = ""
    'FUNCTIONS FOR RESERVATION

    Private Sub side_reserv_Click(sender As Object, e As EventArgs) Handles side_reserv.Click
        reservations_panel.Location = New Point(196, 69)
        reservations_panel.Visible = True
        event_panel.Visible = False
        packages_panel.Visible = False
        menus_panel.Visible = False
        foods_panel.Visible = False

        loadDataReservations()


    End Sub

    Public Function loadDataReservations()
        dataGridField.Add("colName", {"ID", "Client Lastname", "Client Firstname", "Contact #", "Reservation Date", "Date of Event", "Venue", "Event", "Package", "Total Guest", "add_ons"})
        reservations_dg.Columns(0).Visible = False
        reservations_dg.Columns(10).Visible = False

        clearReservation()
        Return Nothing
    End Function

    

    Private Sub reservations_dg_DoubleClick(sender As Object, e As EventArgs) Handles reservations_dg.DoubleClick

        If Not reservations_dg.Rows.Count = 0 Then
            reservations_initials.Text = reservations_dg.SelectedRows.Item(0).Cells(2).Value(0) & reservations_dg.SelectedRows.Item(0).Cells(1).Value(0)
            reservations_id.Text = reservations_dg.SelectedRows.Item(0).Cells(0).Value
            reservations_name.Text = reservations_dg.SelectedRows.Item(0).Cells(2).Value & " " & reservations_dg.SelectedRows.Item(0).Cells(1).Value
            reservations_venue.Text = reservations_dg.SelectedRows.Item(0).Cells(6).Value
            reservations_reserve_date.Text = reservations_dg.SelectedRows.Item(0).Cells(4).Value
            reservations_date_events.Text = reservations_dg.SelectedRows.Item(0).Cells(5).Value
            reservations_contact.Text = reservations_dg.SelectedRows.Item(0).Cells(3).Value
            reservations_event.Text = reservations_dg.SelectedRows.Item(0).Cells(7).Value
            reservations_package.Text = reservations_dg.SelectedRows.Item(0).Cells(8).Value
            reservations_total_guest.Text = reservations_dg.SelectedRows.Item(0).Cells(9).Value
            reservations_addons.Text = reservations_dg.SelectedRows.Item(0).Cells(10).Value
        End If

       
    End Sub

    Private Sub reservations_cancel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles reservations_cancel.LinkClicked

        If Not (reservations_id.Text = "") Then
            If (MsgBox("Are you sure you want to cancel this reservation?", vbQuestion + vbYesNo, "CANCEL RESERVATION") = vbYes) Then

                MsgBox("Successfully cancel a reservation", vbInformation, "Success")

                loadDataReservations()
                clearReservation()

            End If

        End If

    End Sub


    Public Function clearReservation()
        reservations_initials.Text = ""
        reservations_id.Text = ""
        reservations_name.Text = ""
        reservations_venue.Text = ""
        reservations_reserve_date.Text = ""
        reservations_date_events.Text = ""
        reservations_contact.Text = ""
        reservations_event.Text = ""
        reservations_package.Text = ""
        reservations_total_guest.Text = ""
        reservations_addons.Text = ""
        Return Nothing
    End Function


    'END FUNCTIONS FOR RESERVATION

    '-----------------------------------------------------------------------------------------------------------------------

    'FUNCTIONS FOR EVENTS
    Private Sub side_event_Click(sender As Object, e As EventArgs) Handles side_event.Click
        event_panel.Location = New Point(196, 69)
        event_panel.Visible = True
        packages_panel.Visible = False
        reservations_panel.Visible = False
        menus_panel.Visible = False
        foods_panel.Visible = False
        loadDataEvents()

    End Sub

    Public Function loadDataEvents()
        dataGridField.Add("colName", {"ID", "Event Name", "File Name", "Inclusions", "image"})
        dataGrid1(events_dg, dataGridField)
        events_dg.Columns(0).Visible = False
        events_dg.Columns(3).Visible = False
        events_dg.Columns(4).Visible = False

        events_update_btn.Visible = False
        events_back.Visible = False
        events_id.Visible = False

        Return Nothing
    End Function

    Public Function backtoAddEvents()

        events_back.Visible = False

        events_update_btn.Visible = False
        events_add_btn.Visible = True
        events_filename.Clear()
        events_name.Clear()
        events_id.Clear()
        events_inclusions.Clear()
        events_picture.Image = My.Resources.no_image
        Return Nothing
    End Function

    Private Sub events_add_btn_Click(sender As Object, e As EventArgs) Handles events_add_btn.Click

        If (events_name.Text = "") Then
            MsgBox("Please input event name", vbCritical, "Error")
            events_name.Focus()
        Else

            If (MsgBox("Are you sure you want to add this event?", vbQuestion + vbYesNo, "ADD EVENT") = vbYes) Then

                field.Add("event_name", events_name.Text)
                field.Add("event_description", events_inclusions.Text)
                field.Add("file_name", events_filename.Text)


                'MOVE FILE IF SELECTED
                If (isSelectedFile >= 1) Then
                    If Not (File.Exists(Directory.GetCurrentDirectory() & "/images/" & Path.GetFileName(filename))) Then

                        FileCopy(filename, Directory.GetCurrentDirectory() & "/images/" & Path.GetFileName(filename))
                        isSelectedFile = 0
                    End If
                    field.Add("image", Directory.GetCurrentDirectory() & "/images/" & Path.GetFileName(filename))

                Else
                    field.Add("image", "")
                End If


                httpPost(field, "saveEvent")
                backtoAddEvents()
                MsgBox("Event Successfully Added", vbInformation, "Success")

                loadDataEvents()

            End If

        End If


        
        
    End Sub

    Private Sub events_back_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles events_back.LinkClicked
        backtoAddEvents()
    End Sub

    Private Sub events_dg_DoubleClick(sender As Object, e As EventArgs) Handles events_dg.DoubleClick

        If Not events_dg.Rows.Count = 0 Then
            events_back.Visible = True

            events_update_btn.Visible = True
            events_add_btn.Visible = False

            events_id.Text = events_dg.SelectedRows.Item(0).Cells(0).Value
            events_name.Text = events_dg.SelectedRows.Item(0).Cells(1).Value
            events_filename.Text = events_dg.SelectedRows.Item(0).Cells(2).Value
            events_inclusions.Text = events_dg.SelectedRows.Item(0).Cells(3).Value

            If (events_dg.SelectedRows.Item(0).Cells(4).Value).ToString.Equals("") Then
                events_picture.Image = My.Resources.no_image

            Else
                events_picture.Image = Image.FromFile(events_dg.SelectedRows.Item(0).Cells(4).Value)

            End If
            
        End If


    End Sub


    Private Sub events_update_btn_Click(sender As Object, e As EventArgs) Handles events_update_btn.Click

        If (events_name.Text = "") Then
            MsgBox("Please input event name", vbCritical, "Error")
            events_name.Focus()
        Else

            If (MsgBox("Are you sure you want to update this event?", vbQuestion + vbYesNo, "UPDATE EVENT") = vbYes) Then

                field.Add("event_name", events_name.Text)
                field.Add("event_description", events_inclusions.Text)
                field.Add("image", "")
                field.Add("file_name", events_filename.Text)

                '       Updates(field, "events", "where id=" & events_id.Text & "", ImgToByteArray(events_picture.Image, ImageFormat.Jpeg))
                backtoAddEvents()
                MsgBox("Event Successfully updated", vbInformation, "Success")

                loadDataEvents()
            End If
        End If


    End Sub

    Private Sub events_delete_btn_Click(sender As Object, e As EventArgs)
        If (MsgBox("Are you sure you want to delete this event?", vbQuestion + vbYesNo, "UPDATE EVENT") = vbYes) Then

            ' delete("events", "where id=" & events_id.Text & "")
            MsgBox("Event Successfully deleted", vbInformation, "Success")

            loadDataEvents()
            backtoAddEvents()
        End If
    End Sub

    Private Sub events_browse_btn_Click(sender As Object, e As EventArgs) Handles events_browse_btn.Click
        filename = ""
        OpenFileDialog1.Filter = "(Image Files)|*.jpg;*.png;*.bmp;*.gif;*.ico|Jpg, | *.jpg|Png, | *.png|Bmp, | *.bmp|Gif, | *.gif|Ico | *.ico"
        If (OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK) Then
            isSelectedFile = isSelectedFile + 1
            filename = OpenFileDialog1.FileName
            events_picture.Image = Image.FromFile(OpenFileDialog1.FileName)
            events_filename.Text = Path.GetFileName(OpenFileDialog1.FileName)
        End If

    End Sub

    'END OF EVENTS FUNCTIONS
    '-----------------------------------------------------------------------------------------------------------------------

    'FUNCTIONS FOR PACKAGE

    Private Sub side_pack_Click(sender As Object, e As EventArgs) Handles side_pack.Click
        packages_panel.Location = New Point(196, 69)
        event_panel.Visible = False
        packages_panel.Visible = True
        reservations_panel.Visible = False
        menus_panel.Visible = False
        foods_panel.Visible = False

        loadDataPackages()
    End Sub

    Public Function loadDataPackages()

        backToAddPackages()

        dataGridField.Add("colName", {"Id", "Event Name", "Package Name", "Price per head"})
        packages_dg.Columns(0).Visible = False
        Return Nothing
    End Function

    Private Sub packages_add_btn_Click(sender As Object, e As EventArgs) Handles packages_add_btn.Click

        If (packages_perhead.Text = "" Or packages_name.Text = "") Then

            MsgBox("Please input required fields", vbCritical, "Error")
        Else

            If (MsgBox("Are you sure you want to add this package?", vbQuestion + vbYesNo, "ADD EVENT") = vbYes) Then
                field.Add("event_id", packages_cb1.SelectedItem.Value)
                field.Add("package_name", packages_name.Text)
                field.Add("price_head", packages_perhead.Text)
                MsgBox("Package Successfully added", vbInformation, "Success")
                loadDataPackages()

                backToAddPackages()

            End If

        End If

    End Sub

    Public Function backToAddPackages()



        packages_update_btn.Visible = False
        backtoPackages.Visible = False
        packages_add_btn.Visible = True
        packages_id.Visible = False

        packages_id.Clear()
        packages_perhead.Clear()
        packages_name.Clear()
        packages_cb1.Text = ""
        Return Nothing
    End Function


    Private Sub packages_dg_DoubleClick(sender As Object, e As EventArgs) Handles packages_dg.DoubleClick
        If Not packages_dg.Rows.Count = 0 Then

            packages_update_btn.Visible = True
            backtoPackages.Visible = True
            packages_add_btn.Visible = False


            packages_id.Text = packages_dg.SelectedRows.Item(0).Cells(0).Value
            packages_cb1.Text = packages_dg.SelectedRows.Item(0).Cells(1).Value
            packages_name.Text = packages_dg.SelectedRows.Item(0).Cells(2).Value
            packages_perhead.Text = packages_dg.SelectedRows.Item(0).Cells(3).Value
        End If
    End Sub

    Private Sub packages_update_btn_Click(sender As Object, e As EventArgs) Handles packages_update_btn.Click
        If (packages_perhead.Text = "" Or packages_name.Text = "") Then

            MsgBox("Please input required fields", vbCritical, "Error")
        Else

            If (MsgBox("Are you sure you want to add this package?", vbQuestion + vbYesNo, "ADD EVENT") = vbYes) Then
                field.Add("event_id", packages_cb1.SelectedItem.Value)
                field.Add("package_name", packages_name.Text)
                field.Add("price_head", packages_perhead.Text)
                MsgBox("Package Successfully updated", vbInformation, "Success")
                loadDataPackages()

                backToAddPackages()

            End If

        End If
    End Sub

    Private Sub packages_delete_btn_Click(sender As Object, e As EventArgs)
        If (MsgBox("Are you sure you want to delete this event?", vbQuestion + vbYesNo, "UPDATE EVENT") = vbYes) Then

            MsgBox("Package Successfully deleted", vbInformation, "Success")

            loadDataPackages()
            backToAddPackages()
        End If
    End Sub

    Private Sub packages_perhead_KeyPress(sender As Object, e As KeyPressEventArgs) Handles packages_perhead.KeyPress
        If Not IsNumeric(e.KeyChar) And Not Asc(e.KeyChar) = 8 Then
            e.Handled = True
        End If

    End Sub

    Private Sub packages_cb1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles packages_cb1.KeyPress
        e.Handled = True
    End Sub




    'END OF RESERVATION FUNCTIONS
    '-----------------------------------------------------------------------------------------------------------------------


    'FUNCTIONS FOR MENUS

    Private Sub side_menus_Click(sender As Object, e As EventArgs) Handles side_menus.Click
        menus_panel.Location = New Point(196, 69)
        menus_panel.Visible = True
        event_panel.Visible = False
        packages_panel.Visible = False
        reservations_panel.Visible = False
        foods_panel.Visible = False

        loadDataMenus()
    End Sub

    Public Function loadDataMenus()
        dataGridField.Add("colName", {"ID", "Menu Name", "Event Name", "Package Name"})
        dataGridField.Add("dataFieldName", {"id", "menu_name", "event_id", "package_id"})
        menus_dg.Columns(0).Visible = False

        
        backToAddMenus()
        Return Nothing
    End Function

    Public Function backToAddMenus()


        backtomenus.Visible = False
        menus_update_btn.Visible = False

        menus_add_btn.Visible = True
        menus_id.Visible = False

        menus_id.Clear()
        menus_name.Clear()
        menus_cb1.Text = ""
        menus_cb2.Text = ""
        menus_list.Items.Clear()


        Return Nothing
    End Function


    Private Sub menus_cb1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles menus_cb1.SelectedIndexChanged
        listCount = menus_list.Items.Count
    End Sub

    Private Sub menus_add_btn_Click(sender As Object, e As EventArgs) Handles menus_add_btn.Click

        If (menus_name.Text = "" Or menus_cb1.Text = "" Or menus_cb1.Text = "" Or menus_list.Items.Count = 0) Then
            MsgBox("Please input required fields", vbCritical, "Error")
        Else
            If (MsgBox("Are you sure you want to add this menu?", vbQuestion + vbYesNo, "ADD MENU") = vbYes) Then

                field.Add("menu_name", menus_name.Text)
                field.Add("event_id", menus_cb1.SelectedItem.Value)
                field.Add("package_id", menus_cb2.SelectedItem.Value)
                'Add(field, "menus")

                Dim getLastID As Integer = 0
                'rs.Open("select * from menus order by id desc", connection(), 2, 2)
                getLastID = rs("id").Value
                rs.Close()


                For i As Integer = 0 To menus_list.SelectedItems.Count - 1
                    field.Add("food_id", menus_list.SelectedItems(i).SubItems(3).Text)
                    field.Add("menu_id", getLastID)
                    '        Add(field, "food_menu")
                Next

                MsgBox("Menu Successfully added", vbInformation, "Success")

                loadDataMenus()

            End If



        End If


    End Sub


    Private Sub menus_dg_DoubleClick(sender As Object, e As EventArgs) Handles menus_dg.DoubleClick
        If Not menus_dg.Rows.Count = 0 Then
            menus_id.Text = menus_dg.SelectedRows.Item(0).Cells(0).Value
            menus_name.Text = menus_dg.SelectedRows.Item(0).Cells(1).Value
            menus_cb1.Text = menus_dg.SelectedRows.Item(0).Cells(2).Value
            menus_cb2.Text = menus_dg.SelectedRows.Item(0).Cells(3).Value

            ' getFood("foods", menus_list, 1, menus_id.Text)

            menus_add_btn.Visible = False

            menus_update_btn.Visible = True
            backtomenus.Visible = False

            isRemove = True
        End If


    End Sub

    Private Sub menus_update_btn_Click(sender As Object, e As EventArgs) Handles menus_update_btn.Click
        If (menus_name.Text = "" Or menus_cb1.Text = "" Or menus_cb1.Text = "" Or menus_list.Items.Count = 0) Then
            MsgBox("Please input required fields", vbCritical, "Error")
        Else
            If (MsgBox("Are you sure you want to update this menu?", vbQuestion + vbYesNo, "UPDATE MENU") = vbYes) Then

                field.Add("menu_name", menus_name.Text)
                field.Add("event_id", menus_cb1.SelectedItem.Value)
                field.Add("package_id", menus_cb2.SelectedItem.Value)
                '        Updates(field, "menus", "where id=" & menus_id.Text & "")

                If Not (listCount = menus_list.Items.Count) Then
                    '    delete("food_menu", "where menu_id=" & menus_id.Text & "")
                    For i As Integer = 0 To menus_list.Items.Count - 1
                        field.Add("food_id", menus_list.Items(i).SubItems(3).Text)
                        field.Add("menu_id", menus_id.Text)
                        '       Add(field, "food_menu")
                    Next
                End If
                MsgBox("Menu Successfully updated", vbInformation, "Success")

                loadDataMenus()

            End If



        End If
    End Sub

    Private Sub menus_delete_btn_Click(sender As Object, e As EventArgs)
        If (MsgBox("Are you sure you want to update this menu?", vbQuestion + vbYesNo, "DELETE MENU") = vbYes) Then
            '    delete("menus", "where id=" & menus_id.Text & "")
            MsgBox("Menu Successfully deleted", vbInformation, "Success")
            loadDataMenus()
        End If

    End Sub

    Private Sub menus_cb1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles menus_cb1.KeyPress
        e.Handled = True
    End Sub

    Private Sub menus_cb2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles menus_cb2.KeyPress
        e.Handled = True
    End Sub


    'END OF FUNCTION FOR MENUS

    Private Sub side_foods_Click(sender As Object, e As EventArgs) Handles side_foods.Click
        foods_panel.Location = New Point(196, 69)
        menus_panel.Visible = False
        event_panel.Visible = False
        packages_panel.Visible = False
        reservations_panel.Visible = False
        foods_panel.Visible = True

        loadDataFoods()
    End Sub


    Public Function loadDataFoods()
        dataGridField.Add("colName", {"ID", "Food Type", "Food Name", "Food Description", "FILE"})
        dataGridField.Add("dataFieldName", {"id", "food_type_id", "food_name", "food_description", "file_name"})
        '  DataGrid(foods_dg, dataGridField, "foods")
        foods_dg.Columns(0).Visible = False
        foods_dg.Columns(4).Visible = False


        '  getCombo("food_type", foods_cb1)
        backtoAddFoods()
        Return Nothing
    End Function


    Public Function backtoAddFoods()
        foods_picture.Image = My.Resources.no_image
        foods_filename.Clear()
        foods_name.Clear()
        foods_description.Clear()

        foods_cb1.Text = ""

        foods_add_btn.Visible = True
        foods_update_btn.Visible = False
        foods_delete_btn.Visible = False
        foods_id.Visible = False
        foods_id.Clear()
        backtoFoods.Visible = False

        Return Nothing
    End Function


    Private Sub foods_browse_Click(sender As Object, e As EventArgs) Handles foods_browse.Click
        OpenFileDialog1.Filter = "(Image Files)|*.jpg;*.png;*.bmp;*.gif;*.ico|Jpg, | *.jpg|Png, | *.png|Bmp, | *.bmp|Gif, | *.gif|Ico | *.ico"
        If (OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK) Then

            foods_picture.Image = Image.FromFile(OpenFileDialog1.FileName)
            foods_filename.Text = Path.GetFileName(OpenFileDialog1.FileName)

        End If
    End Sub

    Private Sub foods_add_btn_Click(sender As Object, e As EventArgs) Handles foods_add_btn.Click
        If (foods_cb1.Text = "" Or foods_name.Text = "" Or foods_description.Text = "") Then

            MsgBox("Please input required fields", vbCritical, "Error")
        Else
            If (MsgBox("Are you sure you want to add this food?", vbQuestion + vbYesNo, "ADD FOOD") = vbYes) Then


                field.Add("food_name", foods_name.Text)
                field.Add("food_type_id", foods_cb1.SelectedItem.Value)
                field.Add("food_description", foods_description.Text)
                field.Add("image", "")
                field.Add("file_name", foods_filename.Text)
                '     Add(field, "foods", ImgToByteArray(foods_picture.Image, ImageFormat.Jpeg))


                MsgBox("Food Successfully added", vbInformation, "Success")
                loadDataFoods()

            End If
        End If

    End Sub

    Private Sub backtoFoods_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles backtoFoods.LinkClicked
        backtoAddFoods()
    End Sub

    Private Sub foods_update_btn_Click(sender As Object, e As EventArgs) Handles foods_update_btn.Click

        If (foods_cb1.Text = "" Or foods_name.Text = "" Or foods_description.Text = "") Then

            MsgBox("Please input required fields", vbCritical, "Error")
        Else
            If (MsgBox("Are you sure you want to update this food?", vbQuestion + vbYesNo, "ADD FOOD") = vbYes) Then


                field.Add("food_name", foods_name.Text)
                field.Add("food_type_id", foods_cb1.SelectedItem.Value)
                field.Add("food_description", foods_description.Text)
                field.Add("image", "")
                field.Add("file_name", foods_filename.Text)
                '        Updates(field, "foods", "where id=" & foods_id.Text & "", ImgToByteArray(foods_picture.Image, ImageFormat.Jpeg))
                MsgBox("Food Successfully updated", vbInformation, "Success")

                loadDataFoods()

            End If
        End If
    End Sub

    Private Sub foods_delete_btn_Click(sender As Object, e As EventArgs) Handles foods_delete_btn.Click
        If (MsgBox("Are you sure you want to delete this food?", vbQuestion + vbYesNo, "DELETE FOOD") = vbYes) Then

            '    delete("foods", "where id=" & foods_id.Text & "")
            MsgBox("Food Successfully deleted", vbInformation, "Success")
            loadDataFoods()
        End If

    End Sub

    Private Sub foods_cb1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles foods_cb1.KeyPress
        e.Handled = True
    End Sub


    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        foods_panel.Location = New Point(196, 69)
        menus_panel.Visible = False
        event_panel.Visible = False
        packages_panel.Visible = False
        reservations_panel.Visible = True
        foods_panel.Visible = False

        loadDataReservations()

    End Sub

    Private Sub foods_dg_DoubleClick(sender As Object, e As EventArgs) Handles foods_dg.DoubleClick
        If Not foods_dg.Rows.Count = 0 Then

            foods_id.Text = foods_dg.SelectedRows.Item(0).Cells(0).Value
            foods_cb1.Text = foods_dg.SelectedRows.Item(0).Cells(1).Value
            foods_name.Text = foods_dg.SelectedRows.Item(0).Cells(2).Value
            foods_description.Text = foods_dg.SelectedRows.Item(0).Cells(3).Value
            foods_filename.Text = foods_dg.SelectedRows.Item(0).Cells(4).Value


            rs.Open("select * from foods where id=" & foods_id.Text & "")
            Dim boolType As Boolean

            If (conType.Equals("access")) Then
                boolType = IsDBNull(rs("image").Value)
            Else
                Dim pictureData As Byte()
                pictureData = DirectCast(rs("image").Value, Byte())
                boolType = pictureData.Length = 0
            End If


            If Not (boolType) Then
                Dim pictureData As Byte()
                pictureData = DirectCast(rs("image").Value, Byte())
                Dim ms As New MemoryStream(pictureData)
                foods_picture.Image = Image.FromStream(ms)

            Else
                foods_picture.Image = My.Resources.no_image
            End If

            rs.Close()

            foods_delete_btn.Visible = True
            foods_update_btn.Visible = True
            foods_add_btn.Visible = False
            backtoFoods.Visible = True

        End If
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        Me.Hide()
        LoginPage.Show()
        LoginPage.TextBox1.Clear()
        LoginPage.TextBox2.Clear()

    End Sub

    Private Sub events_dg_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles events_dg.CellContentClick

    End Sub

    Private Sub side_event_Paint(sender As Object, e As PaintEventArgs) Handles side_event.Paint

    End Sub
End Class


