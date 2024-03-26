Imports System.Data.SqlClient
Public Class Connection
    Private SqlConn As New SqlConnection
    Private ConnString As String
    Public Sub New()
        ConnString = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        SqlConn.ConnectionString = ConnString
    End Sub
    Public Function Open() As SqlConnection
        Try
            If SqlConn.State = ConnectionState.Closed Then
                SqlConn.Open()
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return SqlConn
    End Function
    Public Function Close()
        If SqlConn.State <> ConnectionState.Closed Then
            SqlConn.Close()
        End If
    End Function
End Class
