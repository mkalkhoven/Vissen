Module Globaal
    Public IsStarted = false
    public Function Getid(row As DataGridViewRow) As Long
        Return row.Cells(0).Value
    End Function
    public sub Showmessage(message As string)

        MessageBox.Show(message, "Vissen", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End sub
    Public Sub Verbergid(dgv As DataGridView)

            dgv.Columns(0).Visible = false

    End Sub
    public sub Toonmelding(melding as string)

        MessageBox.Show(melding, "Vissen", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End sub
    public sub Kleurregel(regel As DataGridViewRow)

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

    public sub Selecteerregel(id As Long, dgv As datagridview)

        For Each row As DataGridViewRow In dgv.rows
            If row.Cells(0).Value.ToString = id.ToString() Then
                row.Selected = true
                Return
            End If
        Next

    End sub

End Module
