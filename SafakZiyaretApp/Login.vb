Public Class Login
    Private Sub pbKapat_Click(sender As Object, e As EventArgs) Handles pbKapat.Click
        Application.Exit()
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub giris_Click(sender As Object, e As EventArgs) Handles giris.Click
        girisyap()
    End Sub

    Private Sub txtSifre_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSifre.KeyDown
        If e.KeyCode = Keys.Enter Then
            girisyap()
        End If
    End Sub

    Private Sub girisyap()
        If txtSifre.Text = "" Then
            MsgBox("Şifre giriniz.")
        ElseIf txtSifre.Text = "1955**" Then
            Dim bmenu = New menu
            bmenu.Show()
            Me.Hide()
        Else
            MsgBox("Şifre yanlış.")
        End If
    End Sub

    Private Sub visibleSifre_Click(sender As Object, e As EventArgs) Handles visibleSifre.Click
        If txtSifre.PasswordChar = "*"c Then
            txtSifre.PasswordChar = ControlChars.NullChar
        Else
            txtSifre.PasswordChar = "*"c
        End If
    End Sub
End Class
