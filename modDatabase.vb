Imports System.Data.OleDb
Imports System.Data.SqlClient

Module ModDatabase

    Public CnVissen As SqlConnection = New SqlConnection("Server=h2865773.stratoserver.net;Database=Visseizoen;User Id=sa;Password=!!fn8565fn##;")
    Public Cnagenda As SqlConnection = New SqlConnection("Server=h2865773.stratoserver.net;Database=DeRuisvoorn;User Id=sa;Password=!!fn8565fn##;")
    Public CmdSql As SqlCommand
    Public Sub Verwijder(sql As String)

        Uitvoeren(sql)

    End Sub

    Public function Uitvoeren(sql As String) As Boolean

        OpenDB()

        CmdSql = New SqlCommand(sql, CnVissen)

        Try
            CmdSql.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        CloseDB()

        Return True
    End function

    Public Sub Delete(sql As String)

        Uitvoeren(sql)

    End Sub

    Public Sub Opslaan(sql As String)
        
        Uitvoeren(sql)

    End Sub

    Public Function Selecteeraantal(sql As String) As Long

        Dim dt = Selecteer(sql)
        If dt.Rows.Count = 1 Then
            Dim tmp = Long.Parse(dt.Rows(0)("Aantal").ToString())
            Return tmp
        Else
            Return 0
        End If

    End Function

    Public Function Selecteeragenda(sql As String) As Data.DataTable

        OpenDb()

        CmdSql = New SqlCommand(sql, Cnagenda)

        Dim dt As New Data.DataTable

        Dim da As New SqlDataAdapter(CmdSql)


        Try
            da.Fill(dt)
            Return dt
        Catch ex As Exception
            Return dt
        Finally
            CloseDb()
        End Try

    End Function


    Public Function Selecteer(sql As String) As Data.DataTable
        
        OpenDB()

        CmdSql = New SqlCommand(sql, CnVissen)

        Dim dt As New Data.DataTable

        Dim da As New SqlDataAdapter(CmdSql)


        Try
            da.Fill(dt)
            Return dt
        Catch ex As Exception
            Return dt
        Finally
            CloseDb()
        End Try

    End Function

    Public Sub OpenDb()

        If CnVissen.State = ConnectionState.Open Then
            CloseDB()
        End If
        Try
            CnVissen.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Sub CloseDb()

        CnVissen.Close()

    End Sub

End Module
