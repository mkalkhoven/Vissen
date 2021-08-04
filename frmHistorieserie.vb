Imports Datalaag
Imports Datalaag.Global
Public Class frmHistorieserie
    Public serie As NaamSerie
    Public seizoen As Seizoen
    Private Sub btnSluiten_Click(sender As Object, e As EventArgs) Handles btnSluiten.Click

        Dispose()

    End Sub

    Private Sub frmHistorieserie_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Icon = FrmMain.Icon

        lblSeizoen.Text = seizoen.Jaar
        lblSerie.Text = serie.Naam
        Vulgrid()

    End Sub
    Private Sub Vulgrid()

        Dim sql = $"SELECT Id, Datum, CAST(IDserieNummer as VARCHAR(2)) + 'e.' as Serie, Plaats FROM DatumWeerEtc WHERE SerieNaamNr = {serie.Id} AND IDseizoen = {seizoen.ID}"
        Dim dt = Selecteer(sql)

        dgvloting.DataSource = dt

        dgvloting.Columns(0).Visible = False
        dgvloting.Columns(1).DefaultCellStyle.Format = "d MMMM yyyy"
        dgvloting.Columns(2).Width = 60
        dgvloting.Columns(1).Width = 175
        dgvloting.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

    End Sub

    Private Sub dgvloting_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvloting.DataBindingComplete

        dgvloting.ClearSelection()

    End Sub

    Private Sub btnBewerken_Click(sender As Object, e As EventArgs) Handles btnBewerken.Click

        If dgvloting.SelectedRows.Count = 0 Then
            Return
        End If

        Dim datumid = Selecteerid(dgvloting, "Id")
        Dim datum = Datumweeretcrepo.Get(datumid)

        Dim f As New frmHistorieseriebewerken With {
            .datum = datum,
            .serie = serie,
            .seizoen = seizoen
        }
        f.ShowDialog()
        Vulgrid()

    End Sub
End Class