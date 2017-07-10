Imports System.Drawing.Imaging
Imports System.IO

Public Class Food_page
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        field.Add("food_name", TextBox2.Text)
        field.Add("food_type_id", ComboBox2.SelectedItem.Value)
        field.Add("food_description", RichTextBox1.Text)
        field.Add("image", "")
        field.Add("file_name", TextBox3.Text)
        Add(field, "foods", ImgToByteArray(PictureBox9.Image, ImageFormat.Jpeg))


        MsgBox("Food Successfully added", vbInformation, "Success")
        loadData()
        backtoAdd()
    End Sub


    Private Sub Food_page_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        loadData()
        Button4.Visible = False
        Button5.Visible = False
        LinkLabel1.Visible = False
        TextBox1.Visible = False
    End Sub

    Public Function loadData()
        dataGridField.Add("colName", {"ID", "Food Type", "Food Name", "Food Description"})
        dataGridField.Add("dataFieldName", {"id", "food_type_id", "food_name", "food_description"})
        dataGrid(DataGridView1, dataGridField, "foods")
        DataGridView1.Columns(0).Visible = False


        getCombo("food_type", ComboBox2)
        getCombo("food_type", ComboBox1, "", "All")
        Return Nothing
    End Function

    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick

        TextBox1.Text = DataGridView1.SelectedRows.Item(0).Cells(0).Value
        ComboBox2.Text = DataGridView1.SelectedRows.Item(0).Cells(1).Value
        TextBox2.Text = DataGridView1.SelectedRows.Item(0).Cells(2).Value
        RichTextBox1.Text = DataGridView1.SelectedRows.Item(0).Cells(3).Value


        rs.Open("select * from foods where id=" & TextBox1.Text & "")
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
            PictureBox9.Image = Image.FromStream(ms)

        Else
            PictureBox9.Image = My.Resources.no_image
        End If

        rs.Close()

        Button1.Visible = False
        Button4.Visible = True
        Button5.Visible = True
        LinkLabel1.Visible = True

    End Sub

    Public Function backtoAdd()

        Button1.Visible = True
        Button4.Visible = False
        Button5.Visible = False
        LinkLabel1.Visible = False

        ComboBox2.Text = ""
        TextBox1.Clear()
        TextBox2.Clear()
        RichTextBox1.Clear()

    End Function

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        backtoAdd()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        field.Add("food_name", TextBox2.Text)
        field.Add("food_type_id", ComboBox2.SelectedItem.Value)
        field.Add("food_description", RichTextBox1.Text)
        field.Add("image", "")
        field.Add("file_name", TextBox3.Text)
        Updates(field, "foods", "where id=" & TextBox1.Text & "", ImgToByteArray(PictureBox9.Image, ImageFormat.Jpeg))
        MsgBox("Food Successfully updated", vbInformation, "Success")

        loadData()
        backtoAdd()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        delete("foods", "where id=" & TextBox1.Text & "")
        MsgBox("Food Successfully deleted", vbInformation, "Success")

        loadData()
        backtoAdd()

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        dataGridField.Add("colName", {"ID", "Food Type", "Food Name", "Food Description"})
        dataGridField.Add("dataFieldName", {"id", "food_type_id", "food_name", "food_description"})
        If (ComboBox1.SelectedItem.Value.Equals(0)) Then
            dataGrid(DataGridView1, dataGridField, "foods")
        Else

            dataGrid(DataGridView1, dataGridField, "foods", "where food_type_id='" & ComboBox1.SelectedItem.Value & "'")

        End If



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        OpenFileDialog1.Filter = "(Image Files)|*.jpg;*.png;*.bmp;*.gif;*.ico|Jpg, | *.jpg|Png, | *.png|Bmp, | *.bmp|Gif, | *.gif|Ico | *.ico"
        If (OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK) Then

            PictureBox9.Image = Image.FromFile(OpenFileDialog1.FileName)
            TextBox3.Text = Path.GetFileName(OpenFileDialog1.FileName)

        End If
    End Sub
End Class