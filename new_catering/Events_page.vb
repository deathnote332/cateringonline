﻿Imports System.IO
Imports System.Drawing.Imaging

Public Class Events_page

    Private Sub side_dash_Click(sender As Object, e As EventArgs) Handles side_dash.Click
        Dashboard.Show()
        Me.Hide()
    End Sub

    Private Sub side_reserv_Click(sender As Object, e As EventArgs) Handles side_reserv.Click
        Reservation.Show()
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        field.Add("event_name", TextBox2.Text)
        field.Add("event_description", RichTextBox1.Text)
        field.Add("image", "")
        field.Add("file_name", TextBox3.Text)

        Add(field, "events", ImgToByteArray(PictureBox9.Image, ImageFormat.Jpeg))

        backtoAdd()
        MsgBox("Event Successfully Added", vbInformation, "Success")

        loadData()
    End Sub

    Private Sub Events_page_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadData()
        LinkLabel1.Visible = False
        Button4.Visible = False
        Button5.Visible = False
        TextBox1.Visible = False
    End Sub

    
    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        LinkLabel1.Visible = True
        Button4.Visible = True
        Button5.Visible = True
        Button1.Visible = False
        'MsgBox(DataGridView1.SelectedRows.Item(0).Cells(0).Value)
        'Dim data As Byte() = DirectCa

        TextBox1.Text = DataGridView1.SelectedRows.Item(0).Cells(0).Value
        TextBox2.Text = DataGridView1.SelectedRows.Item(0).Cells(1).Value
        RichTextBox1.Text = DataGridView1.SelectedRows.Item(0).Cells(2).Value

        rs.Open("select * from events where id=" & DataGridView1.SelectedRows.Item(0).Cells(0).Value & "")
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


        End If

        rs.Close()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        field.Add("event_name", TextBox2.Text)
        field.Add("event_description", RichTextBox1.Text)

        Updates(field, "events", "where id=" & TextBox1.Text & "")

        MsgBox("Event Successfully updated", vbInformation, "Success")


        loadData()

        backtoAdd()
    End Sub
    Public Function loadData()
        dataGridField.Add("colName", {"ID", "Event Name", "Event Description", "File Name"})
        dataGridField.Add("dataFieldName", {"id", "event_name", "event_description", "file_name"})
        dataGrid(DataGridView1, dataGridField, "events")
        DataGridView1.Columns(0).Visible = False
        
        Return Nothing
    End Function

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        backtoAdd()
    End Sub

    Public Function backtoAdd()

        LinkLabel1.Visible = False
        Button4.Visible = False
        Button5.Visible = False
        Button1.Visible = True
        TextBox1.Clear()
        TextBox2.Clear()
        RichTextBox1.Clear()
        PictureBox9.Image = Nothing
    End Function

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        delete("events", TextBox1.Text)
        MsgBox("Event Successfully deleted", vbInformation, "Success")

        loadData()
        backtoAdd()
    End Sub

    ' this is easily used from a class or converted to an extension
    Public Function ImgToByteArray(img As Image, imgFormat As ImageFormat) As Byte()
        Dim tmpData As Byte()
        Using ms As New MemoryStream()
            img.Save(ms, imgFormat)

            tmpData = ms.ToArray
        End Using              ' dispose of memstream
        Return tmpData
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        OpenFileDialog1.Filter = "(Image Files)|*.jpg;*.png;*.bmp;*.gif;*.ico|Jpg, | *.jpg|Png, | *.png|Bmp, | *.bmp|Gif, | *.gif|Ico | *.ico"
        If (OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK) Then

            PictureBox9.Image = Image.FromFile(OpenFileDialog1.FileName)
            TextBox3.Text = OpenFileDialog1.FileName

        End If


    End Sub

End Class
