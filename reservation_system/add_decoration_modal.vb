Public Class add_decoration_modal

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        field.Add("name", TextBox2.Text)
        field.Add("description", RichTextBox1.Text)
        field.Add("image", System.Text.Encoding.Unicode.GetString(imageToByte(PictureBox1)))
        Add(field, "decorations")


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.Filter = "Image Files|*.gif;*.jpg;*.png;*.bmp"
        OpenFileDialog1.ShowDialog()
        PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
    End Sub
End Class