Public Class Form1

    Private Sub LoadImage()
        Try
            ' Create a new OpenFileDialog object.
            Dim openFileDialog1 As New OpenFileDialog()

            ' Set the filter options and filter index.
            openFileDialog1.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG"
            openFileDialog1.FilterIndex = 1

            ' Display the OpenFileDialog.
            If openFileDialog1.ShowDialog() = DialogResult.OK Then
                ' Load the selected image into the PictureBox.
                PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
                PictureBox1.Image = Image.FromFile(openFileDialog1.FileName)
            End If

            ' Set the anchor property to Top And Left
            PictureBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Left

            ' Set the location of the PictureBox to the top-left corner of the window.
            PictureBox1.Location = New Point(0, 0)

        Catch ex As Exception
            ' Display an error message if an exception occurs.
            MessageBox.Show("An error occurred while loading the image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadImage()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        LoadImage()
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Try
            ' Resize the PictureBox to fit the form.
            PictureBox1.Width = ClientSize.Width
            PictureBox1.Height = ClientSize.Height

            ' Center and anchor the "Select Image" button at the bottom of the form.
            Button1.Left = (ClientSize.Width - Button1.Width) / 2
            Button1.Top = ClientSize.Height - Button1.Height
            Button1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right

            ' Set the anchor property to Top And Left
            PictureBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Left

            ' Set the location of the PictureBox to the top-left corner of the window.
            PictureBox1.Location = New Point(0, 0)

        Catch ex As Exception
            ' Display an error message to the user.
            MessageBox.Show("An error occurred while resizing the form: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set the TopMost property of the form to True.
        Me.TopMost = True

        Try
            ' Load the default image into the PictureBox.
            PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
            PictureBox1.Image = Image.FromFile("default.jpg")

            ' Set the default aspect ratio to 4:3.
            Dim aspectRatio As Double = 4.0 / 3.0
            Dim newHeight As Integer = CInt(PictureBox1.Width / aspectRatio)
            PictureBox1.Height = newHeight

        Catch ex As Exception
            ' Display an error message to the user.
            MessageBox.Show("Welcome! Please select an image to start!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

End Class