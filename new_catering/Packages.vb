Public Class Packages

    Private Sub side_dash_Click(sender As Object, e As EventArgs) Handles side_dash.Click
        Me.Hide()
        Dashboard.Show()
    End Sub

    Private Sub side_reserv_Click(sender As Object, e As EventArgs) Handles side_reserv.Click
        Me.Hide()
        Reservation.Show()
    End Sub

    Private Sub side_event_Click(sender As Object, e As EventArgs) Handles side_event.Click
        Me.Hide()
        Events_page.Show()
    End Sub

    Private Sub side_menus_Click(sender As Object, e As EventArgs) Handles side_menus.Click
        menu_page.Show()
        Me.Hide()
    End Sub

    Private Sub Packages_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadData()
        Button4.Visible = False
        Button5.Visible = False
        LinkLabel1.Visible = False
        TextBox1.Visible = False


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        field.Add("event_id", ComboBox1.SelectedItem.Value)
        field.Add("package_name", TextBox3.Text)
        field.Add("price", TextBox2.Text)
        field.Add("total_guest", ComboBox2.Text)

        Add(field, "packages")

        TextBox2.Clear()
        TextBox3.Clear()

        MsgBox("Package Successfully Added", vbInformation, "Success")

        loadData()

    End Sub

    Public Function loadData()

        dataGridField.Add("colName", {"Id", "Event Name", "Package Name", "Total Guest", "Price"})
        dataGridField.Add("dataFieldName", {"id", "event_id", "package_name", "total_guest", "price"})
        dataGrid(DataGridView1, dataGridField, "packages")
        getCombo("events", ComboBox1)
        DataGridView1.Columns(0).Visible = False
        Return Nothing
    End Function


    Public Function backtoAdd()

        LinkLabel1.Visible = False
        Button4.Visible = False
        Button5.Visible = False
        Button1.Visible = True

        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()

        ComboBox1.Text = ""
        ComboBox2.Text = ""

    End Function


    
    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        LinkLabel1.Visible = True
        Button4.Visible = True
        Button5.Visible = True
        Button1.Visible = False

        ComboBox1.Text = DataGridView1.SelectedRows.Item(0).Cells(1).Value
        TextBox3.Text = DataGridView1.SelectedRows.Item(0).Cells(2).Value
        ComboBox2.Text = DataGridView1.SelectedRows.Item(0).Cells(3).Value
        TextBox2.Text = DataGridView1.SelectedRows.Item(0).Cells(4).Value
        TextBox1.Text = DataGridView1.SelectedRows.Item(0).Cells(0).Value

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        backtoAdd()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        field.Add("event_id", ComboBox1.SelectedItem.Value)
        field.Add("package_name", TextBox3.Text)
        field.Add("price", TextBox2.Text)
        field.Add("total_guest", ComboBox2.Text)

        Updates(field, "packages", "where id=" & TextBox1.Text & "")
        MsgBox("Package Successfully updated", vbInformation, "Success")
        loadData()
        backtoAdd()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        delete("packages", TextBox1.Text)
        MsgBox("Package Successfully deleted", vbInformation, "Success")
        loadData()
        backtoAdd()
    End Sub
End Class
