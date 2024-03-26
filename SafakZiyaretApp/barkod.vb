Imports System.Data.SqlClient
Public Class barkod
    Dim Con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\BEGUM_ACAR\Documents\safakZiyaret.mdf;Integrated Security=True;Connect Timeout=30")

    Private Sub FetchZiyaretci()
        If txtTcno.Text = "" Then
            MsgBox("Ziyaretçinin T.C kimlik numarasını giriniz.")
        Else
            Con.Open()
            Dim Query = "select * from MOBIL_ZIYARET where ztcno= " & txtTcno.Text & ""
            Dim cmd As SqlCommand
            cmd = New SqlCommand(Query, Con)
            Dim dt As DataTable
            dt = New DataTable
            Dim sda As SqlDataAdapter
            sda = New SqlDataAdapter(cmd)
            sda.Fill(dt)
            For Each dr As DataRow In dt.Rows
                'ZAdSoyad.Text = dr(1).ToString()
                'Zemail
                'Zdurum
                'Ztip
                'ZcariKod
                'ZcariAd
            Next
            Con.Close()
        End If
    End Sub
    Private Sub barkod_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ara_Click(sender As Object, e As EventArgs) Handles ara.Click
        FetchZiyaretci()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Dim obarkod = New olusanBarkod
        obarkod.Show()
    End Sub

    Private Sub barkodKapat_Click(sender As Object, e As EventArgs) Handles barkodKapat.Click
        Me.Hide()
        Dim bmenu = New menu
        bmenu.Show()
    End Sub
End Class