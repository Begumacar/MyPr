Public Class olusanBarkod
    Private Sub kayitlarKapat_Click(sender As Object, e As EventArgs) Handles kayitlarKapat.Click
        Dim bbarkod = New barkod
        bbarkod.Show()
        Me.Hide()
    End Sub

    Private Sub olusanBarkod_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class