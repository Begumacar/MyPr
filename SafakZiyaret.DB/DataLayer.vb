Imports System.Data.SqlClient
Imports System.Web
Imports Industry40.EntityLayer

Public Class DataLayer

#Region "Public Funcitons"
    Public Function EXSP_Teklifler(ByVal myevrakseri As String, ByVal myevraksira As String,
                                   ByVal mycarikod As String) As DataSet
        Dim ds As New DataSet
        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim da As New SqlDataAdapter(SqlComm)

        Try
            With SqlComm
                '.CommandType = CommandType.Text
                .CommandType = CommandType.StoredProcedure
                .CommandText = "EXSP_Teklifler"
                .Parameters.Add("@myseri", SqlDbType.NVarChar).Value = myevrakseri
                .Parameters.Add("@mysira", SqlDbType.NVarChar).Value = myevraksira
                .Parameters.Add("@mycarikod", SqlDbType.NVarChar).Value = mycarikod
                .Connection = ObjConn.Open()
                da.Fill(ds)
            End With

        Catch ex As SqlClient.SqlException
            ds = New DataSet
        Finally
            ObjConn.Close()
        End Try
        Return ds
    End Function
    Public Function EXSP_TeklifVer(ByVal myguid As String, ByVal myevrakseri As String,
    ByVal myevraksira As String, myfiyat As Double, mydoviz As Integer, mymiktar As Double) As Int32
        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_TeklifVer"
            .Parameters.Add("@myguid", SqlDbType.NVarChar).Value = myguid
            .Parameters.Add("@myevrakseri", SqlDbType.NVarChar).Value = myevrakseri
            .Parameters.Add("@myevrasira", SqlDbType.NVarChar).Value = myevraksira
            .Parameters.Add("@myfiyat", SqlDbType.NVarChar).Value = myfiyat
            .Parameters.Add("@mydoviz", SqlDbType.NVarChar).Value = mydoviz
            .Parameters.Add("@mymiktar", SqlDbType.NVarChar).Value = mymiktar
            .Connection = ObjConn.Open()

            Try
                result = .ExecuteScalar()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function EXSP_TeklifDosyaInsert(ByVal myguid As String, ByVal myevrakseri As String,
             ByVal myevraksira As String, ByVal myms As Byte(), myfilename As String, ByVal myfileext As String) As Int32
        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_TeklifDosyaInsert"
            .Parameters.Add("@myguid", SqlDbType.NVarChar).Value = myguid
            .Parameters.Add("@myevrakseri", SqlDbType.NVarChar).Value = myevrakseri
            .Parameters.Add("@myevraksira", SqlDbType.NVarChar).Value = myevraksira
            .Parameters.Add("@myms", SqlDbType.VarBinary).Value = myms
            .Parameters.Add("@myfilename", SqlDbType.NVarChar).Value = myfilename
            .Parameters.Add("@myfileext", SqlDbType.NVarChar).Value = myfileext
            .Connection = ObjConn.Open()

            Try
                result = .ExecuteScalar()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function EXSP_NewTeklifInsert(ByVal myguid As String, ByVal myevrakseri As String,
             ByVal myevraksira As String, ByVal mydate As String,
             ByVal mymik As Double, ByVal myoffer As Double, ByVal myselection As Integer,
             ByVal mycarikod As String, ByVal mydoviz As String, ByVal mytestar As String) As Int32
        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_NewTeklifInsert"
            .Parameters.Add("@myguid", SqlDbType.NVarChar).Value = myguid
            .Parameters.Add("@myevrakseri", SqlDbType.NVarChar).Value = myevrakseri
            .Parameters.Add("@myevraksira", SqlDbType.NVarChar).Value = myevraksira
            .Parameters.Add("@mydate", SqlDbType.NVarChar).Value = mydate
            .Parameters.Add("@mymikdbl", SqlDbType.Float).Value = mymik
            .Parameters.Add("@myofferdbl", SqlDbType.Float).Value = myoffer
            .Parameters.Add("@myselectionint", SqlDbType.Int).Value = myselection
            .Parameters.Add("@mycarikod", SqlDbType.NVarChar).Value = mycarikod
            .Parameters.Add("@mydoviz", SqlDbType.NVarChar).Value = mydoviz
            .Parameters.Add("@mytestar", SqlDbType.NVarChar).Value = mytestar
            .Connection = ObjConn.Open()

            Try
                result = .ExecuteScalar()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function EX_GetLoginNames() As List(Of EX_LoginNames)
        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim lstLoginNames As New List(Of EX_LoginNames)
        Dim recordIndex As Integer = 1

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_GetLoginNames"
            .Connection = ObjConn.Open()

            Dim dtLoginNames As New DataTable
            Dim da As New SqlDataAdapter(SqlComm)
            Try
                da.Fill(dtLoginNames)

                If (dtLoginNames IsNot Nothing) Then
                    For Each dataRow As DataRow In dtLoginNames.Rows
                        lstLoginNames.Add(SetLoginNames(dataRow))
                        lstLoginNames(lstLoginNames.Count - 1).RecordIndex = recordIndex
                        recordIndex += 1
                    Next
                End If
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try
            da = Nothing
            dtLoginNames = Nothing
            Return lstLoginNames
        End With
    End Function
    Public Function EX_GetPassword(ByVal plaid As Int32) As Int32
        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32 = 0

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_GetPassword"
            .Parameters.Add("@plaid", SqlDbType.Int, 1000).Value = plaid
            .Connection = ObjConn.Open()

            Try
                result = Convert.ToInt32(.ExecuteScalar())
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try
            Return result
        End With
    End Function
    Public Function EX_GetUser(ByVal plaid As Int32) As List(Of EX_LoginNames)
        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim lstLoginNames As New List(Of EX_LoginNames)
        Dim recordIndex As Integer = 1

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_GetUser"
            .Parameters.Add("@plaid", SqlDbType.Int, 1000).Value = plaid
            .Connection = ObjConn.Open()

            Dim dtLoginNames As New DataTable
            Dim da As New SqlDataAdapter(SqlComm)
            Try
                da.Fill(dtLoginNames)

                If (dtLoginNames IsNot Nothing) Then
                    For Each dataRow As DataRow In dtLoginNames.Rows
                        lstLoginNames.Add(SetLoginNames(dataRow))
                        lstLoginNames(lstLoginNames.Count - 1).RecordIndex = recordIndex
                        recordIndex += 1
                    Next
                End If
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try
            da = Nothing
            dtLoginNames = Nothing
            Return lstLoginNames
        End With
    End Function
    Public Function EXSP_GetJobCenters(ByVal mypcip As String) As DataSet
        Dim ds As New DataSet
        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim da As New SqlDataAdapter(SqlComm)

        Try
            With SqlComm
                '.CommandType = CommandType.Text
                .CommandType = CommandType.StoredProcedure
                .CommandText = "EXSP_GetJobCenters"
                .Parameters.Add("@mypcip", SqlDbType.NVarChar).Value = mypcip
                .Connection = ObjConn.Open()
                da.Fill(ds)
            End With

        Catch ex As SqlClient.SqlException
            ds = New DataSet
        Finally
            ObjConn.Close()
        End Try
        Return ds
    End Function
    Public Function EXSP_GetJobCenterswithismerkno(ByVal ismerkno As String) As DataSet
        Dim ds As New DataSet
        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim da As New SqlDataAdapter(SqlComm)

        Try
            With SqlComm
                '.CommandType = CommandType.Text
                .CommandType = CommandType.StoredProcedure
                .CommandText = "EXSP_GetJobCenterswithismerkno"
                .Parameters.Add("@ismerkno", SqlDbType.NVarChar).Value = ismerkno
                .Connection = ObjConn.Open()
                da.Fill(ds)
            End With

        Catch ex As SqlClient.SqlException
            ds = New DataSet
        Finally
            ObjConn.Close()
        End Try
        Return ds
    End Function
    Public Function EXSP_GetDDConsList(ByVal myisno As String, ByVal mysafhano As Integer) As DataSet
        Dim ds As New DataSet
        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim da As New SqlDataAdapter(SqlComm)

        Try
            With SqlComm
                '.CommandType = CommandType.Text
                .CommandType = CommandType.StoredProcedure
                .CommandText = "EXSP_GetDDConsList"
                .Parameters.Add("@myisno", SqlDbType.NVarChar).Value = myisno
                .Parameters.Add("@mysafhano", SqlDbType.Int).Value = mysafhano
                .Connection = ObjConn.Open()
                da.Fill(ds)
            End With

        Catch ex As SqlClient.SqlException
            ds = New DataSet
        Finally
            ObjConn.Close()
        End Try
        Return ds
    End Function
    Public Function EXSP_GetPlanConsListRec(ByVal myisno As String, ByVal mysafhano As Integer) As DataSet
        Dim ds As New DataSet
        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim da As New SqlDataAdapter(SqlComm)

        Try
            With SqlComm
                '.CommandType = CommandType.Text
                .CommandType = CommandType.StoredProcedure
                .CommandText = "EXSP_GetPlanConsListRec"
                .Parameters.Add("@myisno", SqlDbType.NVarChar).Value = myisno
                .Parameters.Add("@mysafhano", SqlDbType.Int).Value = mysafhano
                .Connection = ObjConn.Open()
                da.Fill(ds)
            End With

        Catch ex As SqlClient.SqlException
            ds = New DataSet
        Finally
            ObjConn.Close()
        End Try
        Return ds
    End Function
    Public Function EXSP_GetPlanConsListTar(ByVal myisno As String) As DataSet
        Dim ds As New DataSet
        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim da As New SqlDataAdapter(SqlComm)

        Try
            With SqlComm
                '.CommandType = CommandType.Text
                .CommandType = CommandType.StoredProcedure
                .CommandText = "EXSP_GetPlanConsListTar"
                .Parameters.Add("@myisno", SqlDbType.NVarChar).Value = myisno

                .Connection = ObjConn.Open()
                da.Fill(ds)
            End With

        Catch ex As SqlClient.SqlException
            ds = New DataSet
        Finally
            ObjConn.Close()
        End Try
        Return ds
    End Function
    Public Function EXSP_GetFiiliConsList(ByVal myjobrn As Integer) As DataSet
        Dim ds As New DataSet
        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim da As New SqlDataAdapter(SqlComm)

        Try
            With SqlComm
                '.CommandType = CommandType.Text
                .CommandType = CommandType.StoredProcedure
                .CommandText = "EXSP_GetFiiliConsList"
                .Parameters.Add("@myjobrn", SqlDbType.Int).Value = myjobrn
                .Connection = ObjConn.Open()
                da.Fill(ds)
            End With

        Catch ex As SqlClient.SqlException
            ds = New DataSet
        Finally
            ObjConn.Close()
        End Try
        Return ds
    End Function
    Public Function EXSP_GetTartimLabelInfo(ByVal etiketno As Double, ByVal isno As String) As DataSet
        Dim ds As New DataSet
        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim da As New SqlDataAdapter(SqlComm)

        Try
            With SqlComm
                '.CommandType = CommandType.Text
                .CommandType = CommandType.StoredProcedure
                .CommandText = "EXSP_GetTartimLabelInfo"
                .Parameters.Add("@etiketno", SqlDbType.Int).Value = etiketno
                .Parameters.Add("@myisno", SqlDbType.NVarChar).Value = isno

                .Connection = ObjConn.Open()
                da.Fill(ds)
            End With

        Catch ex As SqlClient.SqlException
            ds = New DataSet
        Finally
            ObjConn.Close()
        End Try
        Return ds
    End Function
    Public Function EXSP_GetFiiliLabelInfo(ByVal etiketno As Double, ByVal isno As String) As Int32
        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32 = 0

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_GetFiiliLabelInfo"
            .Parameters.Add("@etiketno", SqlDbType.Int, 1000).Value = etiketno
            .Parameters.Add("@myisno", SqlDbType.NVarChar, 1000).Value = isno
            .Connection = ObjConn.Open()

            Try
                result = Convert.ToInt32(.ExecuteScalar())
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try
            Return result
        End With
    End Function
    Public Function EX_GetJobswithismerkno(ByVal ismerk As String) As List(Of EX_Jobs)
        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim lstJobs As New List(Of EX_Jobs)
        Dim recordIndex As Integer = 1

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_GetJobswithismerkno"
            If Not String.IsNullOrEmpty(ismerk) Then
                .Parameters.Add("@ismerk", SqlDbType.NVarChar).Value = ismerk
            End If
            .Connection = ObjConn.Open()

            Dim dtJobs As New DataTable
            Dim da As New SqlDataAdapter(SqlComm)
            Try
                da.Fill(dtJobs)

                If (dtJobs IsNot Nothing) Then
                    For Each dataRow As DataRow In dtJobs.Rows
                        lstJobs.Add(SetJobs(dataRow))
                        lstJobs(lstJobs.Count - 1).RecordIndex = recordIndex
                        recordIndex += 1
                    Next
                End If
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try
            da = Nothing
            dtJobs = Nothing
            Return lstJobs
        End With
    End Function
    Public Function EX_GetJobswithisno(ByVal isno As String) As List(Of EX_Jobs)
        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim lstJobs As New List(Of EX_Jobs)
        Dim recordIndex As Integer = 1

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_GetJobswithisno"
            If Not String.IsNullOrEmpty(isno) Then
                .Parameters.Add("@isno", SqlDbType.NVarChar).Value = isno
            End If
            .Connection = ObjConn.Open()

            Dim dtJobs As New DataTable
            Dim da As New SqlDataAdapter(SqlComm)
            Try
                da.Fill(dtJobs)

                If (dtJobs IsNot Nothing) Then
                    For Each dataRow As DataRow In dtJobs.Rows
                        lstJobs.Add(SetJobs(dataRow))
                        lstJobs(lstJobs.Count - 1).RecordIndex = recordIndex
                        recordIndex += 1
                    Next
                End If
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try
            da = Nothing
            dtJobs = Nothing
            Return lstJobs
        End With
    End Function
    Public Function EX_GetTimeLine(ByVal ismerk As String) As List(Of EX_TimeLine)
        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim lstTimeLine As New List(Of EX_TimeLine)
        Dim recordIndex As Integer = 1

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_GetTimeLine"
            If Not String.IsNullOrEmpty(ismerk) Then
                .Parameters.Add("@ismerk", SqlDbType.NVarChar).Value = ismerk
            End If
            .Connection = ObjConn.Open()

            Dim dtTimeLine As New DataTable
            Dim da As New SqlDataAdapter(SqlComm)
            Try
                da.Fill(dtTimeLine)

                If (dtTimeLine IsNot Nothing) Then
                    For Each dataRow As DataRow In dtTimeLine.Rows
                        lstTimeLine.Add(SetTimeLine(dataRow))
                        lstTimeLine(lstTimeLine.Count - 1).RecordIndex = recordIndex
                        recordIndex += 1
                    Next
                End If
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try
            da = Nothing
            dtTimeLine = Nothing
            Return lstTimeLine
        End With
    End Function

    Public Function EX_GetJobrn(ByVal jobrn As Int32) As List(Of EX_Jobrn)
        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim lstJobrn As New List(Of EX_Jobrn)
        Dim recordIndex As Integer = 1

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_GetJobrn"
            If Not String.IsNullOrEmpty(jobrn) Then
                .Parameters.Add("@jobrn", SqlDbType.Int).Value = jobrn
            End If
            .Connection = ObjConn.Open()

            Dim dtJobrn As New DataTable
            Dim da As New SqlDataAdapter(SqlComm)
            Try
                da.Fill(dtJobrn)

                If (dtJobrn IsNot Nothing) Then
                    For Each dataRow As DataRow In dtJobrn.Rows
                        lstJobrn.Add(SetJobrn(dataRow))
                        lstJobrn(lstJobrn.Count - 1).RecordIndex = recordIndex
                        recordIndex += 1
                    Next
                End If
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try
            da = Nothing
            dtJobrn = Nothing
            Return lstJobrn
        End With
    End Function
    Public Function EX_GetWorkers(ByVal jobrn As Int32) As List(Of EX_Workers)
        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim lstWorkers As New List(Of EX_Workers)
        Dim recordIndex As Integer = 1

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_GetWorkers"
            If Not String.IsNullOrEmpty(jobrn) Then
                .Parameters.Add("@jobrn", SqlDbType.Int).Value = jobrn
            End If
            .Connection = ObjConn.Open()

            Dim dtWorkers As New DataTable
            Dim da As New SqlDataAdapter(SqlComm)
            Try
                da.Fill(dtWorkers)

                If (dtWorkers IsNot Nothing) Then
                    For Each dataRow As DataRow In dtWorkers.Rows
                        lstWorkers.Add(SetWorkers(dataRow))
                        lstWorkers(lstWorkers.Count - 1).RecordIndex = recordIndex
                        recordIndex += 1
                    Next
                End If
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try
            da = Nothing
            dtWorkers = Nothing
            Return lstWorkers
        End With
    End Function
    Public Function EX_GetLabels(ByVal jobrn As Int32) As List(Of EX_Labels)
        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim lstLabels As New List(Of EX_Labels)
        Dim recordIndex As Integer = 1

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_GetLabels"
            If Not String.IsNullOrEmpty(jobrn) Then
                .Parameters.Add("@jobrn", SqlDbType.Int).Value = jobrn
            End If
            .Connection = ObjConn.Open()

            Dim dtLabels As New DataTable
            Dim da As New SqlDataAdapter(SqlComm)
            Try
                da.Fill(dtLabels)

                If (dtLabels IsNot Nothing) Then
                    For Each dataRow As DataRow In dtLabels.Rows
                        lstLabels.Add(SetLabels(dataRow))
                        lstLabels(lstLabels.Count - 1).RecordIndex = recordIndex
                        recordIndex += 1
                    Next
                End If
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try
            da = Nothing
            dtLabels = Nothing
            Return lstLabels
        End With
    End Function
    Public Function EX_GetStops(ByVal jobrn As Int32) As List(Of EX_Stops)
        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim lstStops As New List(Of EX_Stops)
        Dim recordIndex As Integer = 1

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_GetStops"
            If Not String.IsNullOrEmpty(jobrn) Then
                .Parameters.Add("@jobrn", SqlDbType.Int).Value = jobrn
            End If
            .Connection = ObjConn.Open()

            Dim dtStops As New DataTable
            Dim da As New SqlDataAdapter(SqlComm)
            Try
                da.Fill(dtStops)

                If (dtStops IsNot Nothing) Then
                    For Each dataRow As DataRow In dtStops.Rows
                        lstStops.Add(SetStops(dataRow))
                        lstStops(lstStops.Count - 1).RecordIndex = recordIndex
                        recordIndex += 1
                    Next
                End If
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try
            da = Nothing
            dtStops = Nothing
            Return lstStops
        End With
    End Function
    Public Function EX_GetScraps(ByVal jobrn As Int32) As List(Of EX_Scraps)
        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim lstScraps As New List(Of EX_Scraps)
        Dim recordIndex As Integer = 1

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_GetScraps"
            If Not String.IsNullOrEmpty(jobrn) Then
                .Parameters.Add("@jobrn", SqlDbType.Int).Value = jobrn
            End If
            .Connection = ObjConn.Open()

            Dim dtScraps As New DataTable
            Dim da As New SqlDataAdapter(SqlComm)
            Try
                da.Fill(dtScraps)

                If (dtScraps IsNot Nothing) Then
                    For Each dataRow As DataRow In dtScraps.Rows
                        lstScraps.Add(SetScraps(dataRow))
                        lstScraps(lstScraps.Count - 1).RecordIndex = recordIndex
                        recordIndex += 1
                    Next
                End If
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try
            da = Nothing
            dtScraps = Nothing
            Return lstScraps
        End With
    End Function
    Public Function EX_GetWorkerList() As List(Of EX_WorkerList)
        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim lstWorkerList As New List(Of EX_WorkerList)
        Dim recordIndex As Integer = 1

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_GetWorkerList"
            .Connection = ObjConn.Open()

            Dim dtWorkerList As New DataTable
            Dim da As New SqlDataAdapter(SqlComm)
            Try
                da.Fill(dtWorkerList)

                If (dtWorkerList IsNot Nothing) Then
                    For Each dataRow As DataRow In dtWorkerList.Rows
                        lstWorkerList.Add(SetWorkerList(dataRow))
                        lstWorkerList(lstWorkerList.Count - 1).RecordIndex = recordIndex
                        recordIndex += 1
                    Next
                End If
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try
            da = Nothing
            dtWorkerList = Nothing
            Return lstWorkerList
        End With
    End Function
    Public Function EX_GetStopList() As List(Of EX_StopList)
        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim lstStopList As New List(Of EX_StopList)
        Dim recordIndex As Integer = 1

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_GetStopList"
            .Connection = ObjConn.Open()

            Dim dtStopList As New DataTable
            Dim da As New SqlDataAdapter(SqlComm)
            Try
                da.Fill(dtStopList)

                If (dtStopList IsNot Nothing) Then
                    For Each dataRow As DataRow In dtStopList.Rows
                        lstStopList.Add(SetStopList(dataRow))
                        lstStopList(lstStopList.Count - 1).RecordIndex = recordIndex
                        recordIndex += 1
                    Next
                End If
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try
            da = Nothing
            dtStopList = Nothing
            Return lstStopList
        End With
    End Function

    Public Function EX_GetScrapList() As List(Of EX_ScrapList)
        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim lstScrapList As New List(Of EX_ScrapList)
        Dim recordIndex As Integer = 1

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_GetScrapList"
            .Connection = ObjConn.Open()

            Dim dtScrapList As New DataTable
            Dim da As New SqlDataAdapter(SqlComm)
            Try
                da.Fill(dtScrapList)

                If (dtScrapList IsNot Nothing) Then
                    For Each dataRow As DataRow In dtScrapList.Rows
                        lstScrapList.Add(SetScrapList(dataRow))
                        lstScrapList(lstScrapList.Count - 1).RecordIndex = recordIndex
                        recordIndex += 1
                    Next
                End If
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try
            da = Nothing
            dtScrapList = Nothing
            Return lstScrapList
        End With
    End Function

    Public Function EX_GetLabelinfo(ByVal labelno As Int32) As List(Of EX_Labelinfo)
        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim lstlabelinfo As New List(Of EX_Labelinfo)
        Dim recordIndex As Integer = 1

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_GetLabelinfo"
            If Not String.IsNullOrEmpty(labelno) Then
                .Parameters.Add("@labelno", SqlDbType.Int).Value = labelno
            End If
            .Connection = ObjConn.Open()

            Dim dtlabelinfo As New DataTable
            Dim da As New SqlDataAdapter(SqlComm)
            Try
                da.Fill(dtlabelinfo)

                If (dtlabelinfo IsNot Nothing) Then
                    For Each dataRow As DataRow In dtlabelinfo.Rows
                        lstlabelinfo.Add(SetLabelinfo(dataRow))
                        lstlabelinfo(lstlabelinfo.Count - 1).RecordIndex = recordIndex
                        recordIndex += 1
                    Next
                End If
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try
            da = Nothing
            dtlabelinfo = Nothing
            Return lstlabelinfo
        End With
    End Function
    Public Function EX_InsertSarf(ByVal myjobrn As String, ByVal myisno As String,
                         ByVal mysarfkod As String, ByVal mysarfmik As Double,
                                  mydepono As Integer, myetiketno As Integer, ByVal mytip As String) As Int32
        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EX_InsertSarf"
            .Parameters.Add("@myjobrn", SqlDbType.NVarChar).Value = myjobrn
            .Parameters.Add("@myisno", SqlDbType.NVarChar).Value = myisno
            .Parameters.Add("@mysarfkod", SqlDbType.NVarChar).Value = mysarfkod
            .Parameters.Add("@mysarfmik", SqlDbType.NVarChar).Value = mysarfmik
            .Parameters.Add("@mydepono", SqlDbType.NVarChar).Value = mydepono
            .Parameters.Add("@myetiketno", SqlDbType.NVarChar).Value = myetiketno
            .Parameters.Add("@mytip", SqlDbType.NVarChar).Value = mytip
            .Connection = ObjConn.Open()

            Try
                result = .ExecuteScalar()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function InsertJobCenterJobs(ByVal ismerk As String, ByVal isno As String, ByVal zaman As DateTime) As Int32

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_Insert_JobCenterJobs"
            .Parameters.Add("@ismerk", SqlDbType.NVarChar).Value = ismerk
            .Parameters.Add("@startedjob", SqlDbType.NVarChar).Value = isno
            .Parameters.Add("@starttim", SqlDbType.DateTime).Value = zaman
            .Parameters.Add("@endtim", SqlDbType.DateTime).Value = zaman
            .Connection = ObjConn.Open()

            Try
                result = .ExecuteNonQuery()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function EX_InsertJobrn(ByVal xisno As String, ByVal xismerkno As String,
                         ByVal xopno As String, ByVal xsafhano As String, ByVal xsonrakisafhano As String) As Int32
        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_InsertJobrn"
            .Parameters.Add("@isno", SqlDbType.NVarChar).Value = xisno
            .Parameters.Add("@ismerkno", SqlDbType.NVarChar).Value = xismerkno
            .Parameters.Add("@opno", SqlDbType.NVarChar).Value = xopno
            .Parameters.Add("@safhano", SqlDbType.NVarChar).Value = xsafhano
            .Parameters.Add("@sonrakisafhano", SqlDbType.NVarChar).Value = xsonrakisafhano
            .Connection = ObjConn.Open()

            Try
                result = .ExecuteScalar()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function EX_InsertBozuk(jobrn As Int32, isno As String,
        bozkod As String, bozad As String, bozmik As Double) As Int32
        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_InsertBozuk"
            .Parameters.Add("@jobrn", SqlDbType.Int).Value = jobrn
            .Parameters.Add("@isno", SqlDbType.NVarChar).Value = isno
            .Parameters.Add("@bozkod", SqlDbType.NVarChar).Value = bozkod
            .Parameters.Add("@bozad", SqlDbType.NVarChar).Value = bozad
            .Parameters.Add("@bozmik", SqlDbType.NVarChar).Value = bozmik
            .Connection = ObjConn.Open()

            Try
                .ExecuteNonQuery()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function EX_InsertPartiLot(ByVal urunkod As String, ByVal parti As String, ByVal lot As Int32) As Int32
        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_InsertPartiLot"
            .Parameters.Add("@urunkod", SqlDbType.NVarChar).Value = urunkod
            .Parameters.Add("@parti", SqlDbType.NVarChar).Value = parti
            .Parameters.Add("@lot", SqlDbType.Int).Value = lot
            .Connection = ObjConn.Open()

            Try
                .ExecuteNonQuery()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function

    Public Function EX_InsertWorker(jobrn As Int32, isno As String,
        perkod As String, perad As String) As Int32
        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_InsertWorker"
            .Parameters.Add("@jobrn", SqlDbType.Int).Value = jobrn
            .Parameters.Add("@isno", SqlDbType.NVarChar).Value = isno
            .Parameters.Add("@perkod", SqlDbType.NVarChar).Value = perkod
            .Parameters.Add("@perad", SqlDbType.NVarChar).Value = perad
            .Connection = ObjConn.Open()

            Try
                .ExecuteNonQuery()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function EX_InsertLabel(ByVal jobrn As Int32,
        ByVal partiloty As String,
        ByVal isno As String,
        ByVal ismerno As String,
        ByVal opno As String,
        ByVal etiketmik As Double,
        ByVal parti As String,
        ByVal loty As Int32,
        ByVal vardiyay As String,
        ByVal createuser As Int32,
        ByVal urunkod As String,
        ByVal safhano As Int32) As Int32

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_InsertLabel"

            .Parameters.Add("@jobrn", SqlDbType.Int).Value = jobrn
            .Parameters.Add("@partilot", SqlDbType.NVarChar).Value = partiloty
            .Parameters.Add("@isno", SqlDbType.NVarChar).Value = isno
            .Parameters.Add("@ismerno", SqlDbType.NVarChar).Value = ismerno
            .Parameters.Add("@opno", SqlDbType.NVarChar).Value = opno
            .Parameters.Add("@etiketmik", SqlDbType.Float).Value = etiketmik
            .Parameters.Add("@parti", SqlDbType.NVarChar).Value = parti
            .Parameters.Add("@lot", SqlDbType.Int).Value = loty
            .Parameters.Add("@vardiya", SqlDbType.NVarChar).Value = vardiyay
            .Parameters.Add("@createuser", SqlDbType.Int).Value = createuser
            .Parameters.Add("@urunkod", SqlDbType.NVarChar).Value = urunkod
            .Parameters.Add("@safhano", SqlDbType.Int).Value = safhano
            .Connection = ObjConn.Open()

            Try
                result = .ExecuteNonQuery()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function EX_InsertDurus(jobrn As Int32, isno As String,
        durkod As String, durad As String) As Int32
        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_InsertDurus"
            .Parameters.Add("@jobrn", SqlDbType.Int).Value = jobrn
            .Parameters.Add("@isno", SqlDbType.NVarChar).Value = isno
            .Parameters.Add("@durkod", SqlDbType.NVarChar).Value = durkod
            .Parameters.Add("@durad", SqlDbType.NVarChar).Value = durad
            .Connection = ObjConn.Open()

            Try
                .ExecuteNonQuery()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function EXSP_InsertOptamam(jobrn As Int32, isno As String, opperkod As String) As Int32
        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_optamam_0insertall"
            .Parameters.Add("@jobrn", SqlDbType.Int).Value = jobrn
            .Parameters.Add("@isno", SqlDbType.NVarChar).Value = isno
            .Parameters.Add("@opperkod", SqlDbType.NVarChar).Value = Replace(opperkod, " ", "")
            .Connection = ObjConn.Open()

            Try
                .ExecuteNonQuery()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function DeleteWorker(ByVal perrecno As Int32) As Int32

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_DeleteWorker"
            .Parameters.Add("@perrecno", SqlDbType.Int).Value = perrecno
            .Connection = ObjConn.Open()

            Try
                .ExecuteNonQuery()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function

    Public Function DeleteLabel(ByVal labelno As Int32, ByVal jobrn As Int32) As Int32

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_DeleteLabel"
            .Parameters.Add("@labelno", SqlDbType.Int).Value = labelno
            .Parameters.Add("@jobrn", SqlDbType.Int).Value = jobrn
            .Connection = ObjConn.Open()

            Try
                .ExecuteNonQuery()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function DeleteJobrn(ByVal jobrn As Int32) As Int32

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_DeleteJobrn"
            .Parameters.Add("@jobrn", SqlDbType.Int).Value = jobrn
            .Connection = ObjConn.Open()

            Try
                .ExecuteNonQuery()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function DeleteBozuk(ByVal bozrecno As Int32) As Int32

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_DeleteBozuk"
            .Parameters.Add("@bozrecno", SqlDbType.Int).Value = bozrecno
            .Connection = ObjConn.Open()

            Try
                .ExecuteNonQuery()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function DeleteFiiliSarf(ByVal sarfrecno As Int32, ByVal jobrn As Int32) As Int32

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_DeleteFiiliSarf"
            .Parameters.Add("@sarfrecno", SqlDbType.Int).Value = sarfrecno
            .Parameters.Add("@jobrn", SqlDbType.Int).Value = jobrn
            .Connection = ObjConn.Open()

            Try
                .ExecuteNonQuery()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function

    Public Function DeleteDurus(ByVal durrecno As Int32) As Int32

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_DeleteDurus"
            .Parameters.Add("@durrecno", SqlDbType.Int).Value = durrecno
            .Connection = ObjConn.Open()

            Try
                .ExecuteNonQuery()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function

    Public Function EtiketHareketGormusmu(ByVal labelno As Int32) As Int32

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_EtiketHareketGormusmu"
            .Parameters.Add("@labelno", SqlDbType.NVarChar).Value = CStr(labelno.ToString)
            .Connection = ObjConn.Open()

            Try
                result = .ExecuteScalar()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function

    Public Function EX_GetWorkerNumber(ByVal jobrn As Int32) As Int32

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_GetWorkerNumber"
            .Parameters.Add("@jobrn", SqlDbType.Int).Value = jobrn
            .Connection = ObjConn.Open()

            Try
                result = .ExecuteScalar()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function EXSP_GetSpecial1(ByVal opno As String) As String

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As String

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_GetSpecial1"
            .Parameters.Add("@opno", SqlDbType.NVarChar).Value = opno
            .Connection = ObjConn.Open()

            Try
                result = .ExecuteScalar()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function EX_GetTotalStop(ByVal jobrn As Int32) As Int32

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Double

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_GetTotalStop"
            .Parameters.Add("@jobrn", SqlDbType.Int).Value = jobrn
            .Connection = ObjConn.Open()

            Try
                result = .ExecuteScalar()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function EX_GetTotalScrap(ByVal jobrn As Int32) As Int32

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Double

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_GetTotalScrap"
            .Parameters.Add("@jobrn", SqlDbType.Int).Value = jobrn
            .Connection = ObjConn.Open()

            Try
                result = .ExecuteScalar()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function EX_GetTotalLabel(ByVal jobrn As Int32) As Int32

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Double

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_GetTotalLabel"
            .Parameters.Add("@jobrn", SqlDbType.Int).Value = jobrn
            .Connection = ObjConn.Open()

            Try
                result = .ExecuteScalar()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function EX_GetLotBul(partiy As String, urunkod As String) As Int32

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_GetLotBul"
            .Parameters.Add("@parti", SqlDbType.NVarChar).Value = partiy
            .Parameters.Add("@urunkod", SqlDbType.NVarChar).Value = urunkod
            .Connection = ObjConn.Open()

            Try
                result = .ExecuteScalar()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function

    Public Function GetJobVarmi(ByVal jobrn As Int32) As Int32

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_GetJobVarmi"
            .Parameters.Add("@jobrn", SqlDbType.Int).Value = jobrn
            .Connection = ObjConn.Open()

            Try
                result = .ExecuteScalar()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function GetCalisanVarmi(ByVal jobrn As Int32) As Int32

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_GetCalisanVarmi"
            .Parameters.Add("@jobrn", SqlDbType.Int).Value = jobrn
            .Connection = ObjConn.Open()

            Try
                result = .ExecuteScalar()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function GetEtiketVarmi(ByVal jobrn As Int32) As Int32

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_GetEtiketVarmi"
            .Parameters.Add("@jobrn", SqlDbType.Int).Value = jobrn
            .Connection = ObjConn.Open()

            Try
                result = .ExecuteScalar()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function GetDurusVarmi(ByVal jobrn As Int32) As Int32

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_GetDurusVarmi"
            .Parameters.Add("@jobrn", SqlDbType.Int).Value = jobrn
            .Connection = ObjConn.Open()

            Try
                result = .ExecuteScalar()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function GetBozukVarmi(ByVal jobrn As Int32) As Int32

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_GetBozukVarmi"
            .Parameters.Add("@jobrn", SqlDbType.Int).Value = jobrn
            .Connection = ObjConn.Open()

            Try
                result = .ExecuteScalar()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function GetSarfVarmi(ByVal jobrn As Int32) As Int32

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_GetSarfVarmi"
            .Parameters.Add("@jobrn", SqlDbType.Int).Value = jobrn
            .Connection = ObjConn.Open()

            Try
                result = .ExecuteScalar()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function GetBTRMinStop(ByVal jobrn As Int32) As String

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As String

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_GetBTRMinStop"
            .Parameters.Add("@jobrn", SqlDbType.Int).Value = jobrn
            .Connection = ObjConn.Open()

            Try
                result = .ExecuteScalar()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function GetBTRMaxStop(ByVal jobrn As Int32) As String

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As String

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_GetBTRMaxStop"
            .Parameters.Add("@jobrn", SqlDbType.Int).Value = jobrn
            .Connection = ObjConn.Open()

            Try
                result = .ExecuteScalar()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function GetBTRTotalStopCount(ByVal jobrn As Int32) As Int32

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_GetBTRTotalStopCount"
            .Parameters.Add("@jobrn", SqlDbType.Int).Value = jobrn
            .Connection = ObjConn.Open()

            Try
                result = .ExecuteScalar()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function GetBTRZeroStopCount(ByVal jobrn As Int32) As Int32

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_GetBTRZeroStopCount"
            .Parameters.Add("@jobrn", SqlDbType.Int).Value = jobrn
            .Connection = ObjConn.Open()

            Try
                result = .ExecuteScalar()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function GetBTRTotalScrapCount(ByVal jobrn As Int32) As Int32

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_GetBTRTotalScrapCount"
            .Parameters.Add("@jobrn", SqlDbType.Int).Value = jobrn
            .Connection = ObjConn.Open()

            Try
                result = .ExecuteScalar()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function GetBTRZeroScrapCount(ByVal jobrn As Int32) As Int32

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_GetBTRZeroScrapCount"
            .Parameters.Add("@jobrn", SqlDbType.Int).Value = jobrn
            .Connection = ObjConn.Open()

            Try
                result = .ExecuteScalar()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function GetFinishJob(ByVal jobrn As Int32) As Int32

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_GetFinishJob"
            .Parameters.Add("@jobrn", SqlDbType.Int).Value = jobrn
            .Connection = ObjConn.Open()

            Try
                .ExecuteNonQuery()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function UpdateJobZaman(ByVal jobrn As String,
                    sday As String, stime As String, eday As String, etime As String) As Int32

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "UpdateJobZaman"
            .Parameters.Add("@jobrn", SqlDbType.NVarChar).Value = jobrn
            .Parameters.Add("@sday", SqlDbType.NVarChar).Value = sday
            .Parameters.Add("@stime", SqlDbType.NVarChar).Value = stime
            .Parameters.Add("@eday", SqlDbType.NVarChar).Value = eday
            .Parameters.Add("@etime", SqlDbType.NVarChar).Value = etime
            .Connection = ObjConn.Open()

            Try
                .ExecuteNonQuery()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function UpdateStopZaman(ByVal jobrn As String,
                    sday As String, stime As String, eday As String, etime As String, durrecno As String) As Int32

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "UpdateStopZaman"
            .Parameters.Add("@jobrn", SqlDbType.NVarChar).Value = jobrn
            .Parameters.Add("@sday", SqlDbType.NVarChar).Value = sday
            .Parameters.Add("@stime", SqlDbType.NVarChar).Value = stime
            .Parameters.Add("@eday", SqlDbType.NVarChar).Value = eday
            .Parameters.Add("@etime", SqlDbType.NVarChar).Value = etime
            .Parameters.Add("@durrecno", SqlDbType.NVarChar).Value = durrecno
            .Connection = ObjConn.Open()

            Try
                .ExecuteNonQuery()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function UpdateWorkerZaman(ByVal jobrn As String,
                    sday As String, stime As String, eday As String, etime As String, worrecno As String) As Int32

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "UpdateWorkerZaman"
            .Parameters.Add("@jobrn", SqlDbType.NVarChar).Value = jobrn
            .Parameters.Add("@sday", SqlDbType.NVarChar).Value = sday
            .Parameters.Add("@stime", SqlDbType.NVarChar).Value = stime
            .Parameters.Add("@eday", SqlDbType.NVarChar).Value = eday
            .Parameters.Add("@etime", SqlDbType.NVarChar).Value = etime
            .Parameters.Add("@worrecno", SqlDbType.NVarChar).Value = worrecno
            .Connection = ObjConn.Open()

            Try
                .ExecuteNonQuery()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function EX_GetJobTimes(ByVal jobrn As String) As List(Of EX_Jobstartstoptimes)
        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim lstJobtimes As New List(Of EX_Jobstartstoptimes)
        Dim recordIndex As Integer = 1

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_GetJobTimes"
            If Not String.IsNullOrEmpty(jobrn) Then
                .Parameters.Add("@jobrn", SqlDbType.NVarChar).Value = jobrn
            End If
            .Connection = ObjConn.Open()

            Dim dtJobtimes As New DataTable
            Dim da As New SqlDataAdapter(SqlComm)
            Try
                da.Fill(dtJobtimes)

                If (dtJobtimes IsNot Nothing) Then
                    For Each dataRow As DataRow In dtJobtimes.Rows
                        lstJobtimes.Add(SetJobtimes(dataRow))
                        lstJobtimes(lstJobtimes.Count - 1).RecordIndex = recordIndex
                        recordIndex += 1
                    Next
                End If
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try
            da = Nothing
            dtJobtimes = Nothing
            Return lstJobtimes
        End With
    End Function
    Public Function EX_GetStopTimes(ByVal jobrn As String, ByVal durrecno As String) As List(Of EX_Durusstartstoptimes)
        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim lstStoptimes As New List(Of EX_Durusstartstoptimes)
        Dim recordIndex As Integer = 1

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_GetStopTimes"
            If Not String.IsNullOrEmpty(jobrn) Then
                .Parameters.Add("@jobrn", SqlDbType.NVarChar).Value = jobrn
                .Parameters.Add("@durrecno", SqlDbType.NVarChar).Value = durrecno
            End If
            .Connection = ObjConn.Open()

            Dim dtStoptimes As New DataTable
            Dim da As New SqlDataAdapter(SqlComm)
            Try
                da.Fill(dtStoptimes)

                If (dtStoptimes IsNot Nothing) Then
                    For Each dataRow As DataRow In dtStoptimes.Rows
                        lstStoptimes.Add(SetStoptimes(dataRow))
                        lstStoptimes(lstStoptimes.Count - 1).RecordIndex = recordIndex
                        recordIndex += 1
                    Next
                End If
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try
            da = Nothing
            dtStoptimes = Nothing
            Return lstStoptimes
        End With
    End Function
    Public Function EX_GetWorkerTimes(ByVal jobrn As String, ByVal worrecno As String) As List(Of EX_Workerstartstoptimes)
        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim lstWorkertimes As New List(Of EX_Workerstartstoptimes)
        Dim recordIndex As Integer = 1

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_GetWorkerTimes"
            If Not String.IsNullOrEmpty(jobrn) Then
                .Parameters.Add("@jobrn", SqlDbType.NVarChar).Value = jobrn
                .Parameters.Add("@worrecno", SqlDbType.NVarChar).Value = worrecno
            End If
            .Connection = ObjConn.Open()

            Dim dtWorkertimes As New DataTable
            Dim da As New SqlDataAdapter(SqlComm)
            Try
                da.Fill(dtWorkertimes)

                If (dtWorkertimes IsNot Nothing) Then
                    For Each dataRow As DataRow In dtWorkertimes.Rows
                        lstWorkertimes.Add(SetWorkertimes(dataRow))
                        lstWorkertimes(lstWorkertimes.Count - 1).RecordIndex = recordIndex
                        recordIndex += 1
                    Next
                End If
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try
            da = Nothing
            dtWorkertimes = Nothing
            Return lstWorkertimes
        End With
    End Function
    Public Function EX_AyniZamanDilimi(ByVal ismerkezi As String, ByVal jobrn As String,
        ByVal isstartgun As String, isendgun As String) As List(Of EX_Aynizamandilimi)
        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim lstaynitimes As New List(Of EX_Aynizamandilimi)
        Dim recordIndex As Integer = 1

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_GetAyniZamanDilimi"
            If Not String.IsNullOrEmpty(jobrn) Then
                .Parameters.Add("@ismerkezi", SqlDbType.NVarChar).Value = ismerkezi
                .Parameters.Add("@jobrn", SqlDbType.NVarChar).Value = jobrn
                .Parameters.Add("@isstartgun", SqlDbType.NVarChar).Value = isstartgun
                .Parameters.Add("@isendgun", SqlDbType.NVarChar).Value = isendgun
            End If
            .Connection = ObjConn.Open()

            Dim dtaynitimes As New DataTable
            Dim da As New SqlDataAdapter(SqlComm)
            Try
                da.Fill(dtaynitimes)

                If (dtaynitimes IsNot Nothing) Then
                    For Each dataRow As DataRow In dtaynitimes.Rows
                        lstaynitimes.Add(SetAynizamandilimi(dataRow))
                        lstaynitimes(lstaynitimes.Count - 1).RecordIndex = recordIndex
                        recordIndex += 1
                    Next
                End If
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try
            da = Nothing
            dtaynitimes = Nothing
            Return lstaynitimes
        End With
    End Function
    Public Function EXSP_jobrndurusuyumkontrol(ByVal jobrn As Int32, ByVal bastime As String, ByVal bittime As String) As Int32

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_jobrndurusuyumkontrol"
            .Parameters.Add("@jobrn", SqlDbType.NVarChar).Value = CStr(jobrn.ToString)
            .Parameters.Add("@bastime", SqlDbType.NVarChar).Value = CStr(bastime.ToString)
            .Parameters.Add("@bittime", SqlDbType.NVarChar).Value = CStr(bittime.ToString)
            .Connection = ObjConn.Open()

            Try
                result = .ExecuteScalar()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function EXSP_durusjobrnuyumkontrol(ByVal jobrn As Int32, ByVal bastime As String, ByVal bittime As String) As Int32

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_durusjobrnuyumkontrol"
            .Parameters.Add("@jobrn", SqlDbType.NVarChar).Value = CStr(jobrn.ToString)
            .Parameters.Add("@bastime", SqlDbType.NVarChar).Value = CStr(bastime.ToString)
            .Parameters.Add("@bittime", SqlDbType.NVarChar).Value = CStr(bittime.ToString)
            .Connection = ObjConn.Open()

            Try
                result = .ExecuteScalar()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function EXSP_workerjobrnuyumkontrol(ByVal jobrn As Int32, ByVal bastime As String, ByVal bittime As String) As Int32

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_workerjobrnuyumkontrol"
            .Parameters.Add("@jobrn", SqlDbType.NVarChar).Value = CStr(jobrn.ToString)
            .Parameters.Add("@bastime", SqlDbType.NVarChar).Value = CStr(bastime.ToString)
            .Parameters.Add("@bittime", SqlDbType.NVarChar).Value = CStr(bittime.ToString)
            .Connection = ObjConn.Open()

            Try
                result = .ExecuteScalar()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function EXSP_jcakisma_arasinda(ByVal jobrn As Int32, ByVal perkod As String, ByVal ismerkno As String,
        ByVal bastime As String, ByVal bittime As String) As Int32

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_jcakisma_arasinda"
            .Parameters.Add("@jobrn", SqlDbType.NVarChar).Value = CStr(jobrn.ToString)
            .Parameters.Add("@perkod", SqlDbType.NVarChar).Value = CStr(perkod.ToString)
            .Parameters.Add("@ismerkno", SqlDbType.NVarChar).Value = CStr(ismerkno.ToString)
            .Parameters.Add("@bastime", SqlDbType.NVarChar).Value = CStr(bastime.ToString)
            .Parameters.Add("@bittime", SqlDbType.NVarChar).Value = CStr(bittime.ToString)
            .Connection = ObjConn.Open()

            Try
                result = .ExecuteScalar()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function EXSP_jcakisma_kapsiyor(ByVal jobrn As Int32, ByVal perkod As String, ByVal ismerkno As String,
        ByVal bastime As String, ByVal bittime As String) As Int32

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_jcakisma_kapsiyor"
            .Parameters.Add("@jobrn", SqlDbType.NVarChar).Value = CStr(jobrn.ToString)
            .Parameters.Add("@perkod", SqlDbType.NVarChar).Value = CStr(perkod.ToString)
            .Parameters.Add("@ismerkno", SqlDbType.NVarChar).Value = CStr(ismerkno.ToString)
            .Parameters.Add("@bastime", SqlDbType.NVarChar).Value = CStr(bastime.ToString)
            .Parameters.Add("@bittime", SqlDbType.NVarChar).Value = CStr(bittime.ToString)
            .Connection = ObjConn.Open()

            Try
                result = .ExecuteScalar()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function EXSP_jcakisma_bastanoverlap(ByVal jobrn As Int32, ByVal perkod As String, ByVal ismerkno As String,
        ByVal bastime As String, ByVal bittime As String) As Int32

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_jcakisma_bastanoverlap"
            .Parameters.Add("@jobrn", SqlDbType.NVarChar).Value = CStr(jobrn.ToString)
            .Parameters.Add("@perkod", SqlDbType.NVarChar).Value = CStr(perkod.ToString)
            .Parameters.Add("@ismerkno", SqlDbType.NVarChar).Value = CStr(ismerkno.ToString)
            .Parameters.Add("@bastime", SqlDbType.NVarChar).Value = CStr(bastime.ToString)
            .Parameters.Add("@bittime", SqlDbType.NVarChar).Value = CStr(bittime.ToString)
            .Connection = ObjConn.Open()

            Try
                result = .ExecuteScalar()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function EXSP_jcakisma_sondanoverlap(ByVal jobrn As Int32, ByVal perkod As String, ByVal ismerkno As String,
        ByVal bastime As String, ByVal bittime As String) As Int32

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_jcakisma_sondanoverlap"
            .Parameters.Add("@jobrn", SqlDbType.NVarChar).Value = CStr(jobrn.ToString)
            .Parameters.Add("@perkod", SqlDbType.NVarChar).Value = CStr(perkod.ToString)
            .Parameters.Add("@ismerkno", SqlDbType.NVarChar).Value = CStr(ismerkno.ToString)
            .Parameters.Add("@bastime", SqlDbType.NVarChar).Value = CStr(bastime.ToString)
            .Parameters.Add("@bittime", SqlDbType.NVarChar).Value = CStr(bittime.ToString)
            .Connection = ObjConn.Open()

            Try
                result = .ExecuteScalar()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function EXSP_dcakisma_arasinda(ByVal recno As Int32, ByVal jobrn As Int32,
    ByVal bastime As String, ByVal bittime As String) As Int32

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_dcakisma_arasinda"
            .Parameters.Add("@recno", SqlDbType.NVarChar).Value = CStr(recno.ToString)
            .Parameters.Add("@jobrn", SqlDbType.NVarChar).Value = CStr(jobrn.ToString)
            .Parameters.Add("@bastime", SqlDbType.NVarChar).Value = CStr(bastime.ToString)
            .Parameters.Add("@bittime", SqlDbType.NVarChar).Value = CStr(bittime.ToString)
            .Connection = ObjConn.Open()

            Try
                result = .ExecuteScalar()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function EXSP_dcakisma_kapsiyor(ByVal recno As Int32, ByVal jobrn As Int32,
    ByVal bastime As String, ByVal bittime As String) As Int32

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_dcakisma_kapsiyor"
            .Parameters.Add("@recno", SqlDbType.NVarChar).Value = CStr(recno.ToString)
            .Parameters.Add("@jobrn", SqlDbType.NVarChar).Value = CStr(jobrn.ToString)
            .Parameters.Add("@bastime", SqlDbType.NVarChar).Value = CStr(bastime.ToString)
            .Parameters.Add("@bittime", SqlDbType.NVarChar).Value = CStr(bittime.ToString)
            .Connection = ObjConn.Open()

            Try
                result = .ExecuteScalar()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function EXSP_dcakisma_bastanoverlap(ByVal recno As Int32, ByVal jobrn As Int32,
    ByVal bastime As String, ByVal bittime As String) As Int32

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_dcakisma_bastanoverlap"
            .Parameters.Add("@recno", SqlDbType.NVarChar).Value = CStr(recno.ToString)
            .Parameters.Add("@jobrn", SqlDbType.NVarChar).Value = CStr(jobrn.ToString)
            .Parameters.Add("@bastime", SqlDbType.NVarChar).Value = CStr(bastime.ToString)
            .Parameters.Add("@bittime", SqlDbType.NVarChar).Value = CStr(bittime.ToString)
            .Connection = ObjConn.Open()

            Try
                result = .ExecuteScalar()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function EXSP_dcakisma_sondanoverlap(ByVal recno As Int32, ByVal jobrn As Int32,
    ByVal bastime As String, ByVal bittime As String) As Int32

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As Int32

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_dcakisma_sondanoverlap"
            .Parameters.Add("@recno", SqlDbType.NVarChar).Value = CStr(recno.ToString)
            .Parameters.Add("@jobrn", SqlDbType.NVarChar).Value = CStr(jobrn.ToString)
            .Parameters.Add("@bastime", SqlDbType.NVarChar).Value = CStr(bastime.ToString)
            .Parameters.Add("@bittime", SqlDbType.NVarChar).Value = CStr(bittime.ToString)
            .Connection = ObjConn.Open()

            Try
                result = .ExecuteScalar()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function EXSP_WorkerPerKod(ByVal jobrn As Int32) As String

        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim result As String

        With SqlComm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "EXSP_WorkerPerKod"
            .Parameters.Add("@jobrn", SqlDbType.NVarChar).Value = CStr(jobrn.ToString)
            .Connection = ObjConn.Open()

            Try
                result = .ExecuteScalar()
            Catch ex As Exception
                Return Nothing
            Finally
                ObjConn.Close()
            End Try

            Return result
        End With
    End Function
    Public Function EXSP_FindJobrnWithPsk(ByVal zpsk As Int32) As DataSet
        Dim ds As New DataSet
        Dim SqlComm As New SqlCommand
        Dim ObjConn As New Connection
        Dim da As New SqlDataAdapter(SqlComm)

        Try
            With SqlComm
                '.CommandType = CommandType.Text
                .CommandType = CommandType.StoredProcedure
                .CommandText = "EXSP_FindJobrnWithPsk"
                .Parameters.Add("@zpsk", SqlDbType.Int, 1000).Value = zpsk
                .Connection = ObjConn.Open()
                da.Fill(ds)
            End With

        Catch ex As SqlClient.SqlException
            ds = New DataSet
        Finally
            ObjConn.Close()
        End Try
        Return ds
    End Function
    Private Function SetLoginNames(dataRow As DataRow)
        Dim lognam As New EX_LoginNames
        lognam.plaad = Convert.ToString(dataRow("plaad"))
        lognam.plaid = Convert.ToString(dataRow("plaid"))
        lognam.plakod = Convert.ToString(dataRow("plakod"))
        lognam.evrakseri = Convert.ToString(dataRow("evrakseri"))
        lognam.sifre = Convert.ToString(dataRow("sifre"))
        Return lognam
    End Function
    Private Function SetJobCenters(dataRow As DataRow)
        Dim jobcen As New EX_JobCenters
        jobcen.Ismerkno = Convert.ToString(dataRow("ismerkno"))
        jobcen.Ismerkname = Convert.ToString(dataRow("ismerkname"))
        'jobcen.ImagePath = Convert.ToString(dataRow("imagepath"))
        jobcen.isstart_gun = Convert.ToString(dataRow("isstart_gun"))
        jobcen.isstart_saat = Convert.ToString(dataRow("isstart_saat"))
        jobcen.isend_gun = Convert.ToString(dataRow("isend_gun"))
        jobcen.isend_saat = Convert.ToString(dataRow("isend_saat"))
        jobcen.isstarttime = Convert.ToString(dataRow("isstarttime"))
        jobcen.isno = Convert.ToString(dataRow("isno"))
        jobcen.kod = Convert.ToString(dataRow("kod"))
        jobcen.ad = Convert.ToString(dataRow("ad"))
        jobcen.mik = Convert.ToString(dataRow("mik"))
        jobcen.opad = Convert.ToString(dataRow("opaciklama"))
        jobcen.durumu = Convert.ToString(dataRow("durumu"))
        jobcen.mikrosure = Convert.ToString(dataRow("mikrosure"))
        jobcen.safhano = Convert.ToString(dataRow("safhano"))
        jobcen.opkod = Convert.ToString(dataRow("opkod"))
        jobcen.jobrn = Convert.ToString(dataRow("jobrn"))
        jobcen.nesure = Convert.ToString(dataRow("nesure"))
        jobcen.statu = Convert.ToString(dataRow("statu"))
        jobcen.fiilibrsure = Convert.ToString(dataRow("fiilibrsure"))
        jobcen.carkcount = Convert.ToString(dataRow("carkcount"))
        Return jobcen
    End Function

    Private Function SetJobs(dataRow As DataRow)
        Dim job As New EX_Jobs
        job.Iskod = Convert.ToString(dataRow("iskod"))
        job.Ismerkno = Convert.ToString(dataRow("ismerkno"))
        job.Stokkod = Convert.ToString(dataRow("stokkod"))
        job.Stokname = Convert.ToString(dataRow("stokname"))
        job.safhano = Convert.ToString(dataRow("safhano"))
        job.sonrakisafhano = Convert.ToString(dataRow("sonrakisafhano"))
        job.Opkod = Convert.ToString(dataRow("opkod"))
        job.Opad = Convert.ToString(dataRow("opad"))
        job.Jobplanqty = Convert.ToString(dataRow("jobplanqty"))
        Return job
    End Function

    Private Function SetTimeLine(dataRow As DataRow)
        Dim tim As New EX_TimeLine
        tim.Ismerk = Convert.ToString(dataRow("ismerk"))
        tim.Signal1 = Convert.ToString(dataRow("signal1"))
        tim.Xstarttimee = Convert.ToString(dataRow("xstarttimee"))
        tim.Xendtimee = Convert.ToString(dataRow("xendtimee"))
        tim.Xsure = Convert.ToString(dataRow("xsure"))
        tim.Xrunno = Convert.ToString(dataRow("xrunno"))
        tim.Disccount = Convert.ToString(dataRow("disccount"))
        Return tim
    End Function
    Private Function SetJobrn(dataRow As DataRow)
        Dim jobrn As New EX_Jobrn
        jobrn.Ismerkno = Convert.ToString(dataRow("ismerkno"))
        jobrn.Ismerkname = Convert.ToString(dataRow("ismerkname"))
        'jobrn.ImagePath = Convert.ToString(dataRow("imagepath"))
        jobrn.isstart_gun = Convert.ToString(dataRow("isstart_gun"))
        jobrn.isstart_saat = Convert.ToString(dataRow("isstart_saat"))
        jobrn.isend_gun = Convert.ToString(dataRow("isend_gun"))
        jobrn.isend_saat = Convert.ToString(dataRow("isend_saat"))
        jobrn.isstarttime = Convert.ToString(dataRow("isstarttime"))
        jobrn.isno = Convert.ToString(dataRow("isno"))
        jobrn.kod = Convert.ToString(dataRow("kod"))
        jobrn.ad = Convert.ToString(dataRow("ad"))
        jobrn.Birim = Convert.ToString(dataRow("birim"))
        jobrn.Ingilizcead = Convert.ToString(dataRow("ingilizcead"))
        jobrn.Brkg = Convert.ToString(dataRow("brkg"))
        jobrn.mik = Convert.ToString(dataRow("mik"))
        jobrn.opad = Convert.ToString(dataRow("opaciklama"))
        jobrn.durumu = Convert.ToString(dataRow("durumu"))
        jobrn.mikrosure = Convert.ToString(dataRow("mikrosure"))
        jobrn.safhano = Convert.ToString(dataRow("safhano"))
        jobrn.opkod = Convert.ToString(dataRow("opkod"))
        jobrn.jobrn = Convert.ToString(dataRow("jobrn"))
        jobrn.nesure = Convert.ToString(dataRow("nesure"))
        jobrn.statu = Convert.ToString(dataRow("statu"))
        jobrn.fiilibrsure = Convert.ToString(dataRow("fiilibrsure"))
        jobrn.carkcount = Convert.ToString(dataRow("carkcount"))
        Return jobrn
    End Function
    Private Function SetWorkers(dataRow As DataRow)
        Dim workers As New EX_Workers
        workers.perkod = Convert.ToString(dataRow("perkod"))
        workers.perad = Convert.ToString(dataRow("perad"))
        workers.Isegirgun = Convert.ToString(dataRow("isegir_gun"))
        workers.Isegirsaat = Convert.ToString(dataRow("isegir_saat"))
        workers.Istencikgun = Convert.ToString(dataRow("istencik_gun"))
        workers.Istenciksaat = Convert.ToString(dataRow("istencik_saat"))
        workers.sure = Convert.ToString(dataRow("sure"))
        workers.Isno = Convert.ToString(dataRow("isno"))
        workers.Jobrn = Convert.ToString(dataRow("jobrn"))
        workers.recno = Convert.ToString(dataRow("recno"))
        Return workers
    End Function
    Private Function SetLabels(dataRow As DataRow)
        Dim labels As New EX_Labels
        labels.Krecno = Convert.ToString(dataRow("Krecno"))
        labels.Parti = Convert.ToString(dataRow("parti"))
        labels.Lot = Convert.ToString(dataRow("lot"))
        labels.Urunkod = Convert.ToString(dataRow("urunkod"))
        labels.Urunad = Convert.ToString(dataRow("urunad"))
        labels.Birim = Convert.ToString(dataRow("birim"))
        labels.Miktar = Convert.ToString(dataRow("miktar"))
        labels.Olusmatarihi = Convert.ToString(dataRow("olusmatarihi"))
        labels.Olusturan = Convert.ToString(dataRow("olusturan"))
        labels.Jobrn = Convert.ToString(dataRow("JobRN"))
        labels.tip = Convert.ToString(dataRow("tip"))
        labels.Isno = Convert.ToString(dataRow("isno"))
        Return labels
    End Function

    Private Function SetStops(dataRow As DataRow)

        Dim stops As New EX_Stops
        stops.Durkod = Convert.ToString(dataRow("durkod"))
        stops.Durad = Convert.ToString(dataRow("durad"))
        stops.Durbasgun = Convert.ToString(dataRow("durbas_gun"))
        stops.Durbassaat = Convert.ToString(dataRow("durbas_saat"))
        stops.Durbitgun = Convert.ToString(dataRow("durbit_gun"))
        stops.Durbitsaat = Convert.ToString(dataRow("durbit_saat"))
        stops.sure = Convert.ToString(dataRow("sure"))
        stops.Isno = Convert.ToString(dataRow("isno"))
        stops.Jobrn = Convert.ToString(dataRow("jobrn"))
        stops.recno = Convert.ToString(dataRow("recno"))
        stops.tip = Convert.ToString(dataRow("tip"))
        stops.dfinrunno = Convert.ToString(dataRow("dfinrunno"))
        stops.didsignalstart = Convert.ToString(dataRow("didsignalstart"))
        stops.didsignalend = Convert.ToString(dataRow("didsignalend"))
        Return stops
    End Function
    Private Function SetScraps(dataRow As DataRow)
        Dim scraps As New EX_Scraps
        scraps.Isno = Convert.ToString(dataRow("isno"))
        scraps.Bozkod = Convert.ToString(dataRow("bozkod"))
        scraps.Bozad = Convert.ToString(dataRow("bozad"))
        scraps.Mikt = Convert.ToString(dataRow("mikt"))
        scraps.Jobrn = Convert.ToString(dataRow("jobrn"))
        scraps.recno = Convert.ToString(dataRow("recno"))
        Return scraps
    End Function
    Private Function SetWorkerList(dataRow As DataRow)
        Dim workerlist As New EX_WorkerList
        workerlist.perkod = Convert.ToString(dataRow("perkod"))
        workerlist.perad = Convert.ToString(dataRow("perad"))
        Return workerlist
    End Function
    Private Function SetStopList(dataRow As DataRow)
        Dim stoplist As New EX_StopList
        stoplist.durkod = Convert.ToString(dataRow("durkod"))
        stoplist.durad = Convert.ToString(dataRow("durad"))
        Return stoplist
    End Function
    Private Function SetScrapList(dataRow As DataRow)
        Dim scraplist As New EX_ScrapList
        scraplist.bozkod = Convert.ToString(dataRow("bozkod"))
        scraplist.bozad = Convert.ToString(dataRow("bozad"))
        Return scraplist
    End Function
    Private Function SetLabelinfo(dataRow As DataRow)
        Dim labelno As New EX_Labelinfo
        labelno.isno = Convert.ToString(dataRow("isno"))
        labelno.kod = Convert.ToString(dataRow("kod"))
        labelno.ad = Convert.ToString(dataRow("ad"))
        labelno.Birim = Convert.ToString(dataRow("birim"))
        labelno.Ingilizcead = Convert.ToString(dataRow("ingilizcead"))
        labelno.Brkg = Convert.ToString(dataRow("brkg"))
        labelno.mik = Convert.ToString(dataRow("mik"))
        labelno.safhano = Convert.ToString(dataRow("safhano"))
        labelno.opkod = Convert.ToString(dataRow("opkod"))
        labelno.lot = Convert.ToString(dataRow("lot"))
        labelno.parti = Convert.ToString(dataRow("parti"))
        labelno.partilot = Convert.ToString(dataRow("partilot"))
        labelno.etiketno = Convert.ToString(dataRow("Krecno"))
        Return labelno
    End Function
    Private Function SetJobtimes(dataRow As DataRow)
        Dim jobtimes As New EX_Jobstartstoptimes
        jobtimes.isstart_gun = Convert.ToString(dataRow("isstart_gun"))
        jobtimes.isstart_saat = Convert.ToString(dataRow("isstart_saat"))
        jobtimes.isend_gun = Convert.ToString(dataRow("isend_gun"))
        jobtimes.isend_saat = Convert.ToString(dataRow("isend_saat"))
        jobtimes.jobrn = Convert.ToString(dataRow("jobrn"))
        jobtimes.mikrosure = Convert.ToString(dataRow("mikrosure"))
        jobtimes.ismerkno = Convert.ToString(dataRow("ismerkno"))
        Return jobtimes
    End Function
    Private Function SetStoptimes(dataRow As DataRow)
        Dim stoptimes As New EX_Durusstartstoptimes
        stoptimes.durstart_gun = Convert.ToString(dataRow("durbas_gun"))
        stoptimes.durstart_saat = Convert.ToString(dataRow("durbas_saat"))
        stoptimes.durend_gun = Convert.ToString(dataRow("durbit_gun"))
        stoptimes.durend_saat = Convert.ToString(dataRow("durbit_saat"))
        stoptimes.jobrn = Convert.ToString(dataRow("jobrn"))
        Return stoptimes
    End Function
    Private Function SetWorkertimes(dataRow As DataRow)
        Dim worktimes As New EX_Workerstartstoptimes
        worktimes.worstart_gun = Convert.ToString(dataRow("worbas_gun"))
        worktimes.worstart_saat = Convert.ToString(dataRow("worbas_saat"))
        worktimes.worend_gun = Convert.ToString(dataRow("worbit_gun"))
        worktimes.worend_saat = Convert.ToString(dataRow("worbit_saat"))
        worktimes.jobrn = Convert.ToString(dataRow("jobrn"))
        Return worktimes
    End Function
    Private Function SetAynizamandilimi(dataRow As DataRow)
        Dim aynitimes As New EX_Aynizamandilimi
        aynitimes.isstart_gun = Convert.ToString(dataRow("isstart_gun"))
        aynitimes.isstart_saat = Convert.ToString(dataRow("isstart_saat"))
        aynitimes.isend_gun = Convert.ToString(dataRow("isend_gun"))
        aynitimes.isend_saat = Convert.ToString(dataRow("isend_saat"))
        aynitimes.jobrn = Convert.ToString(dataRow("jobrn"))
        aynitimes.ismerkno = Convert.ToString(dataRow("ismerkno"))
        Return aynitimes
    End Function
#End Region
End Class
