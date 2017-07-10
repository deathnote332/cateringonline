Public Class menu_page

    Dim isRemove As Boolean = False
    Dim listCount As Integer = 0

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


        loadData()

        ComboBox2.Enabled = False
        Button1.Enabled = False
        Button3.Enabled = False
        ListView1.Enabled = False

        Button4.Visible = False
        Button5.Visible = False

    End Sub


    Public Function loadData()
        dataGridField.Add("colName", {"ID", "Menu Name", "Event Name", "Package Name"})
        dataGridField.Add("dataFieldName", {"id", "menu_name", "event_id", "package_id"})
        dataGrid(DataGridView1, dataGridField, "menus")
        DataGridView1.Columns(0).Visible = False

        getCombo("events", ComboBox1)

        TextBox2.Visible = False
        LinkLabel1.Visible = False
        Return Nothing
    End Function

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        getCombo("packages", ComboBox2, "where event_id=" & ComboBox1.SelectedItem.Value & "")
        ComboBox2.Enabled = True
        Button3.Enabled = True
        getFood("foods", ListView1)

        listCount = ListView1.Items.Count
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged



        ListView1.Enabled = True
        Button1.Enabled = True
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        field.Add("menu_name", TextBox1.Text)
        field.Add("event_id", ComboBox1.SelectedItem.Value)
        field.Add("package_id", ComboBox2.SelectedItem.Value)
        Add(field, "menus")

        Dim getLastID As Integer = 0
        rs.Open("select * from menus order by id desc", connection(), 2, 2)
        getLastID = rs("id").Value
        rs.Close()


        For i As Integer = 0 To ListView1.SelectedItems.Count - 1
            field.Add("food_id", ListView1.SelectedItems(i).SubItems(3).Text)
            field.Add("menu_id", getLastID)
            Add(field, "food_menu")
        Next

        MsgBox("Menu Successfully added", vbInformation, "Success")
        loadData()
        backtoAdd()

    End Sub

    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        TextBox2.Text = DataGridView1.SelectedRows.Item(0).Cells(0).Value
        TextBox1.Text = DataGridView1.SelectedRows.Item(0).Cells(1).Value
        ComboBox1.Text = DataGridView1.SelectedRows.Item(0).Cells(2).Value
        ComboBox2.Text = DataGridView1.SelectedRows.Item(0).Cells(3).Value

        getFood("foods", ListView1, 1, TextBox2.Text)

        Button1.Visible = False
        Button4.Visible = True
        Button5.Visible = True
        LinkLabel1.Visible = True

        isRemove = True

    End Sub


    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        If (isRemove) Then
            ListView1.SelectedItems(0).Remove()
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        field.Add("menu_name", TextBox1.Text)
        field.Add("event_id", ComboBox1.SelectedItem.Value)
        field.Add("package_id", ComboBox2.SelectedItem.Value)
        Updates(field, "menus", "where id=" & TextBox2.Text & "")
        MsgBox(TextBox2.Text)
        If Not (listCount = ListView1.Items.Count) Then
            delete("food_menu", "where menu_id=" & TextBox2.Text & "")
            For i As Integer = 0 To ListView1.Items.Count - 1
                field.Add("food_id", ListView1.Items(i).SubItems(3).Text)
                field.Add("menu_id", TextBox2.Text)
                Add(field, "food_menu")
            Next
        End If
        MsgBox("Menu Successfully updated", vbInformation, "Success")
        loadData()
        backtoAdd()
    End Sub

    Public Function backtoAdd()
        TextBox1.Clear()
        TextBox2.Clear()
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ListView1.Items.Clear()

        Button4.Visible = False
        Button5.Visible = False
        Button1.Visible = True
        LinkLabel1.Visible = False

    End Function

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        delete("menus", "where id=" & TextBox2.Text & "")
        MsgBox("Menu Successfully deleted", vbInformation, "Success")
        loadData()
        backtoAdd()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        backtoAdd()
    End Sub
End Class
