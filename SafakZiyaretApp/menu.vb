Public Class menu
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Hide()
        Dim bkayitlar = New kayitlar
        bkayitlar.Show()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.Hide()
        Dim bkayitlar = New kayitlar
        bkayitlar.Show()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Hide()
        Dim bbarkod = New barkod
        bbarkod.Show()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Me.Hide()
        Dim bbarkod = New barkod
        bbarkod.Show()
    End Sub

    Private Sub menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub loginKapat_Click(sender As Object, e As EventArgs) Handles loginKapat.Click
        Dim log = New Login
        log.Show()
        Me.Hide()
    End Sub
End Class