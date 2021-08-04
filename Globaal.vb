Module Globaal
    Public IsStarted = False
    Public Function Getid(dgv As DataGridView) As Long

        'Return Getid(dgv.SelectedRows)

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
    Public sub Showmessage(message As string)

        MessageBox.Show(message, "Vissen", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End sub
    Public Sub Verbergid(dgv As DataGridView)

            dgv.Columns(0).Visible = false

    End Sub
    Public Sub Toonmelding(melding As String)

        MessageBox.Show(melding, "Vissen", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
    Public Function Toonvraag(vraag As String) As DialogResult

        Return MessageBox.Show(vraag, "Vissen", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

    End Function
    Public sub Kleurregel(regel As DataGridViewRow)

            regel.DefaultCellStyle.BackColor  = Color.Yellow

    End sub
    public sub Uitvullen(dgv As DataGridView)

        Dim kolom = dgv.Columns(dgv.Columns.Count - 1)
        kolom.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

    End sub
    public Function Selecteerid(dgv As DataGridView, kolom As string) As long

        Try
            Dim index = dgv.Columns(kolom).Index
            Dim id As Long = long.Parse(dgv.Item(index, dgv.CurrentRow.Index).Value.ToString())
            Return id
        Catch ex As Exception
            Return 0
        End Try
        
    End Function
    public Function Selecteerid(row As DataGridViewrow, kolom As string) As long

        Dim id = long.Parse(row.Cells(kolom).Value.ToString())
        Return id

    End Function
    public Function Selecteerid(dgv As DataGridView) As long

        Dim id As Long = long.Parse(dgv.Item(0, dgv.CurrentRow.Index).Value.ToString())
        Return id

    End Function
    public Function Selecteerid(row As DataGridViewRow) As long

        Dim id As Long = long.Parse(row.Cells(0).Value)
        Return id

    End Function

    Public Sub Selecteerregel(id As Long, dgv As datagridview)

        For Each row As DataGridViewRow In dgv.rows
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
