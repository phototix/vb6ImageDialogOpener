Private Sub Command1_Click()
    Dim dlgOpen As CommonDialog
    Set dlgOpen = New CommonDialog
    dlgOpen.Filter = "Image Files|*.bmp;*.jpg;*.gif;*.png|All Files|*.*"
    dlgOpen.ShowOpen
    If dlgOpen.FileName <> "" Then
        Load frmImage
        frmImage.Show
        frmImage.Image1.Picture = LoadPicture(dlgOpen.FileName)
    End If
End Sub
