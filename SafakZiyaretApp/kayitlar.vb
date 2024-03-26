Public Class kayitlar
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub kayitlarKapat_Click(sender As Object, e As EventArgs) Handles kayitlarKapat.Click
        Dim kmenu = New menu
        kmenu.Show()
        Me.Hide()
    End Sub

    Private Sub kayitlar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class