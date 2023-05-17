Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar

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

            ' Set the properties of Button1.
            Button1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
            Button1.Width = 200
            Button1.Height = 30
            Button1.Left = (Me.ClientSize.Width - Button1.Width) / 2
            Button1.Top = Me.ClientSize.Height - Button1.Height - 10

            ' Set the properties of Button2.
            Button2.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
            Button2.Width = 200
            Button2.Height = 30
            Button2.Left = (Me.ClientSize.Width - Button2.Width) / 2
            Button2.Top = Button1.Top - Button2.Height - 10

            ' Set the anchor property to Top And Left
            PictureBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Left

            ' Set the location of the PictureBox to the top-left corner of the window.
            PictureBox1.Location = New Point(0, 0)

            ' Maintain the 4:3 aspect ratio of the PictureBox.
            Dim newWidth As Integer = Me.ClientSize.Width
            Dim newHeight As Integer = newWidth * 3 \ 4

            If newHeight > Me.ClientSize.Height Then
                newHeight = Me.ClientSize.Height
                newWidth = newHeight * 4 \ 3
            End If

            ' Set the size and position of the PictureBox.
            PictureBox1.Size = New Size(newWidth, newHeight)
            PictureBox1.Location = New Point((Me.ClientSize.Width - PictureBox1.Width) \ 2, (Me.ClientSize.Height - PictureBox1.Height) \ 2)

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

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        ' Toggle the TopMost property of the form.
        TopMost = Not TopMost

        ' Update the text of the button.
        If TopMost Then
            Button2.Text = "Turn Off Always OnTop"
        Else
            Button2.Text = "Turn On Always OnTop"
        End If
    End Sub
End Class