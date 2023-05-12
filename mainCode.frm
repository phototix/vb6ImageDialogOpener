VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Open Image Dialog"
   ClientHeight    =   3015
   ClientLeft      =   120
   ClientTop       =   465
   ClientWidth     =   4560
   LinkTopic       =   "Form1"
   ScaleHeight     =   3015
   ScaleWidth      =   4560
   StartUpPosition =   3  'Windows Default
   Begin VB.PictureBox Picture1 
      Height          =   1935
      Left            =   240
      ScaleHeight     =   1875
      ScaleWidth      =   3915
      TabIndex        =   1
      Top             =   120
      Width           =   3975
   End
   Begin VB.CommandButton Command1 
      Caption         =   "OpenImage"
      Height          =   735
      Left            =   1200
      TabIndex        =   0
      Top             =   2280
      Width           =   2175
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Command1_Click()
    Dim img As StdPicture
    Dim dlg As FileDialog
    Set dlg = New FileDialog
    dlg.Filter = "Image Files (*.bmp;*.jpg;*.gif)|*.bmp;*.jpg;*.gif"
    If dlg.ShowOpen Then
        Set img = LoadPicture(dlg.FileName)
        If Not img Is Nothing Then
            Set Picture1.Picture = img
        Else
            MsgBox "Failed to load image file."
        End If
    End If
    Set dlg = Nothing
End Sub

Private Sub Picture1_Click()

End Sub
