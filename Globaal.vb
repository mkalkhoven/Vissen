
Imports System.Data.SqlClient
Module Globaal
    Public IsStarted = False
    Private ReadOnly CnKaarten = New SqlConnection("Server=h2865773.stratoserver.net;Database=seizoen;User Id=sa;Password=!!fn8565fn##;")
    Private ReadOnly CnVissen = New SqlConnection("Server=h2865773.stratoserver.net;Database=visseizoen;User Id=sa;Password=!!fn8565fn##;")
    Private ReadOnly CnRuisvoorn = New SqlConnection("Server=h2865773.stratoserver.net;Database=DeRuisvoorn;User Id=sa;Password=!!fn8565fn##;")
    Private command As SqlCommand = New SqlCommand()
    Public Enum Databasetype
        Kaarten
        Vissen
        Ruisvoorn
    End Enum
    Public Function Selecteer(sql As String, type As Databasetype) As DataTable

        Try
            Select Case type
                Case Databasetype.Kaarten
                    command.Connection = CnKaarten
                Case Databasetype.Vissen
                    command.Connection = CnVissen
                Case Databasetype.Ruisvoorn
                    command.Connection = CnRuisvoorn
            End Select
            If command.Connection.State = ConnectionState.Closed Then
                command.Connection.Open()
            End If

            Try
                command.CommandText = sql
                Dim dr = command.ExecuteReader
                Dim dt As New DataTable
                dt.Load(dr)
                Return dt
            Catch ex As Exception
                Return Nothing
            Finally
                command.Connection.Close()
                command.Parameters.Clear()
            End Try
        Catch ex As Exception
            Return New DataTable
        End Try

    End Function
    Public Function Getid(dgv As DataGridView) As Long

        For Each row As DataGridViewRow In dgv.SelectedRows
            Return Getid(row)
        Next
        Return 0
    End Function
    Public Function Getid(row As DataGridViewRow) As Long
        Return row.Cells(0).Value
    End Function
    Public Function Getid(cbo As ComboBox) As Long

        Try
            Dim id = Long.Parse(cbo.SelectedValue.ToString())
            Return id
        Catch ex As Exception
            Return 0
        End Try

    End Function
    Public Sub Showmessage(message As String)

        MessageBox.Show(message, "Vissen", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
    Public Sub Verbergid(dgv As DataGridView)

        dgv.Columns(0).Visible = False

    End Sub
    Public Sub Toonmelding(melding As String)

        MessageBox.Show(melding, "Vissen", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
    Public Function Toonvraag(vraag As String) As DialogResult

        Return MessageBox.Show(vraag, "Vissen", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

    End Function
    Public Sub Kleurregel(regel As DataGridViewRow)

        regel.DefaultCellStyle.BackColor = Color.Yellow

    End Sub
    Public Sub Uitvullen(dgv As DataGridView)

        Dim kolom = dgv.Columns(dgv.Columns.Count - 1)
        kolom.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

    End Sub
    Public Function Selecteerid(dgv As DataGridView, kolom As String) As Long

        Try
            Dim index = dgv.Columns(kolom).Index
            Dim id As Long = Long.Parse(dgv.Item(index, dgv.CurrentRow.Index).Value.ToString())
            Return id
        Catch ex As Exception
            Return 0
        End Try

    End Function
    Public Function Selecteerid(row As DataGridViewRow, kolom As String) As Long

        Dim id = Long.Parse(row.Cells(kolom).Value.ToString())
        Return id

    End Function
    Public Function Selecteerid(dgv As DataGridView) As Long

        Dim id As Long = Long.Parse(dgv.Item(0, dgv.CurrentRow.Index).Value.ToString())
        Return id

    End Function
    Public Function Selecteerid(row As DataGridViewRow) As Long

        Dim id As Long = Long.Parse(row.Cells(0).Value)
        Return id

    End Function

    Public Sub Selecteerregel(id As Long, dgv As DataGridView)

        For Each row As DataGridViewRow In dgv.Rows
            If row.Cells(0).Value.ToString = id.ToString() Then
                row.Selected = True
                Return
            End If
        Next

    End Sub

    Public Function GetISODate(datum As String) As String

        Dim tmp As DateTime
        DateTime.TryParse(datum, tmp)

        Return $"'{tmp.ToString("yyyy-MM-dd")}'"

    End Function

    Public Function GetISODate() As String

        Return $"'{DateTime.Now.ToString("yyyy-MM-dd")}'"

    End Function

    Public Function GetISODateTime() As String

        Return $"'{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}'"

    End Function

    Public Function GetISODateTime(datumtijd As DateTime) As String

        Return $"'{datumtijd.ToString("yyyy-MM-dd HH:mm:ss")}'"

    End Function

End Module
