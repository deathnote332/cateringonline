<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Food_page
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.panel_event_add = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.panel_events = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.panel_event_add.SuspendLayout()
        Me.panel_events.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panel_event_add
        '
        Me.panel_event_add.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_event_add.Controls.Add(Me.Button2)
        Me.panel_event_add.Controls.Add(Me.TextBox3)
        Me.panel_event_add.Controls.Add(Me.PictureBox9)
        Me.panel_event_add.Controls.Add(Me.TextBox1)
        Me.panel_event_add.Controls.Add(Me.Label1)
        Me.panel_event_add.Controls.Add(Me.ComboBox2)
        Me.panel_event_add.Controls.Add(Me.Button5)
        Me.panel_event_add.Controls.Add(Me.Button4)
        Me.panel_event_add.Controls.Add(Me.LinkLabel1)
        Me.panel_event_add.Controls.Add(Me.RichTextBox1)
        Me.panel_event_add.Controls.Add(Me.Label9)
        Me.panel_event_add.Controls.Add(Me.TextBox2)
        Me.panel_event_add.Controls.Add(Me.Label8)
        Me.panel_event_add.Controls.Add(Me.Button1)
        Me.panel_event_add.Controls.Add(Me.Label30)
        Me.panel_event_add.Location = New System.Drawing.Point(655, 42)
        Me.panel_event_add.Name = "panel_event_add"
        Me.panel_event_add.Size = New System.Drawing.Size(262, 475)
        Me.panel_event_add.TabIndex = 27
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(13, 178)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 17)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "Food Type"
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"Foods", "Desserts", "Drinks"})
        Me.ComboBox2.Location = New System.Drawing.Point(16, 218)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(146, 21)
        Me.ComboBox2.TabIndex = 55
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(86, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.SystemColors.Control
        Me.Button5.Location = New System.Drawing.Point(138, 423)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(106, 37)
        Me.Button5.TabIndex = 52
        Me.Button5.Text = "DELETE"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(86, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.SystemColors.Control
        Me.Button4.Location = New System.Drawing.Point(16, 425)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(109, 37)
        Me.Button4.TabIndex = 51
        Me.Button4.Text = "UPDATE"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(86, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(188, 18)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(55, 12)
        Me.LinkLabel1.TabIndex = 27
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Back to Add"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RichTextBox1.Location = New System.Drawing.Point(16, 321)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(230, 69)
        Me.RichTextBox1.TabIndex = 34
        Me.RichTextBox1.Text = ""
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(15, 303)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 17)
        Me.Label9.TabIndex = 32
        Me.Label9.Text = "Description"
        '
        'TextBox2
        '
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(16, 262)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(230, 29)
        Me.TextBox2.TabIndex = 31
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(13, 242)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 17)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "Name"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(86, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.Control
        Me.Button1.Location = New System.Drawing.Point(15, 425)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(230, 37)
        Me.Button1.TabIndex = 27
        Me.Button1.Text = "SAVE"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(86, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label30.Location = New System.Drawing.Point(9, 12)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(99, 21)
        Me.Label30.TabIndex = 26
        Me.Label30.Text = "ADD FOODS"
        '
        'panel_events
        '
        Me.panel_events.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_events.Controls.Add(Me.Label2)
        Me.panel_events.Controls.Add(Me.ComboBox1)
        Me.panel_events.Controls.Add(Me.LinkLabel2)
        Me.panel_events.Controls.Add(Me.DataGridView1)
        Me.panel_events.Controls.Add(Me.Label29)
        Me.panel_events.Location = New System.Drawing.Point(1, 42)
        Me.panel_events.Name = "panel_events"
        Me.panel_events.Size = New System.Drawing.Size(642, 474)
        Me.panel_events.TabIndex = 26
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(12, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 17)
        Me.Label2.TabIndex = 57
        Me.Label2.Text = "Food Type"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Foods", "Desserts", "Drinks"})
        Me.ComboBox1.Location = New System.Drawing.Point(87, 59)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(146, 21)
        Me.ComboBox1.TabIndex = 54
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(86, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.LinkLabel2.LinkColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(86, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.LinkLabel2.Location = New System.Drawing.Point(459, 24)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(165, 12)
        Me.LinkLabel2.TabIndex = 53
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "DOUBLE CLICK TO UPDATE/DELETE"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(15, 88)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(609, 362)
        Me.DataGridView1.TabIndex = 11
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(86, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Label29.Location = New System.Drawing.Point(11, 15)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(62, 21)
        Me.Label29.TabIndex = 10
        Me.Label29.Text = "FOODS"
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(206, 218)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(39, 29)
        Me.TextBox1.TabIndex = 57
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(86, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.Control
        Me.Button2.Location = New System.Drawing.Point(13, 173)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(90, 22)
        Me.Button2.TabIndex = 60
        Me.Button2.Text = "Browser"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'TextBox3
        '
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(109, 173)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(134, 22)
        Me.TextBox3.TabIndex = 59
        '
        'PictureBox9
        '
        Me.PictureBox9.Image = Global.new_catering.My.Resources.Resources.no_image
        Me.PictureBox9.InitialImage = Nothing
        Me.PictureBox9.Location = New System.Drawing.Point(13, 36)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(230, 131)
        Me.PictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox9.TabIndex = 58
        Me.PictureBox9.TabStop = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Food_page
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(937, 552)
        Me.Controls.Add(Me.panel_event_add)
        Me.Controls.Add(Me.panel_events)
        Me.Name = "Food_page"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Food_page"
        Me.panel_event_add.ResumeLayout(False)
        Me.panel_event_add.PerformLayout()
        Me.panel_events.ResumeLayout(False)
        Me.panel_events.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panel_event_add As Panel
    Friend WithEvents Button5 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label30 As Label
    Friend WithEvents panel_events As Panel
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label29 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents PictureBox9 As PictureBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
End Class
