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

        Dim sql = $"SELECT DISTINCT d.ID AS Datumid, l.Datum, l.Serienummer, a.Locatie FROM VisSeizoen.dbo.Loting2 l JOIN DeRuisvoorn.dbo.Agenda a ON l.Datum = a.Datum JOIN VisSeizoen.dbo.DatumWeerEtc d ON a.Datum = d.Datum WHERE (l.Serieid = {serie.Id} AND l.Seizoenid = {seizoen.ID}) ORDER BY l.Datum"

        Dim dt = Selecteeragenda(sql)

        dgvloting.DataSource = dt

        dgvloting.Columns(0).Visible = False
        dgvloting.Columns(1).DefaultCellStyle.Format = "d MMMM yyyy"
        dgvloting.Columns(1).Width = 175
        dgvloting.Columns(2).Width = 125
        dgvloting.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

    End Sub

    Private Sub dgvloting_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvloting.DataBindingComplete

        dgvloting.ClearSelection()

        'Serienaamnummer op basis van darum ophalen

        'For Each row As DataGridViewRow In dgvloting.Rows
        '    Dim datum = row.Cells("Datum")


        'Next

        'Select Case serie.Id
        '    Case 1, 2, 3 'Senioren
        '        Sql = $"SELECT Id, Datum, CAST(IDserieNummer as VARCHAR(2)) + 'e.' as Serie, Plaats FROM DatumWeerEtc WHERE (SerieNaamNr = 1 AND IDseizoen = {seizoen.ID}) OR (SerieNaamNr = 2 AND IDseizoen = {seizoen.ID}) OR (SerieNaamNr = 3 AND IDseizoen = {seizoen.ID})"
        '    Case 9, 10, 11 'Winter
        '        Sql = $"SELECT Id, Datum, CAST(IDserieNummer as VARCHAR(2)) + 'e.' as Serie, Plaats FROM DatumWeerEtc WHERE (SerieNaamNr = 9 AND IDseizoen = {seizoen.ID}) OR (SerieNaamNr = 10 AND IDseizoen = {seizoen.ID}) OR (SerieNaamNr = 11 AND IDseizoen = {seizoen.ID})"
        '    Case 12, 13 'Jeugd
        '        Sql = $"SELECT Id, Datum, CAST(IDserieNummer as VARCHAR(2)) + 'e.' as Serie, Plaats FROM DatumWeerEtc WHERE (SerieNaamNr = 12 AND IDseizoen = {seizoen.ID}) OR (SerieNaamNr = 13 AND IDseizoen = {seizoen.ID})"

    End Sub

    Private Sub btnBewerken_Click(sender As Object, e As EventArgs) Handles btnBewerken.Click

        If dgvloting.SelectedRows.Count = 0 Then
            Return
        End If

        Dim Datumid = Selecteerid(dgvloting, "Datumid")
        Dim datum = Datumweeretcrepo.Get(Datumid)

        Dim f As New frmHistorieseriebewerken With {
            .datum = datum,
            .serie = serie,
            .seizoen = seizoen,
            .Agendaid = Datumid
        }
        f.ShowDialog()
        Vulgrid()

    End Sub

    Private Sub btnLegen_Click(sender As Object, e As EventArgs)

        If dgvloting.SelectedRows.Count = 0 Then
            Return
        End If

        Dim Datumid = Selecteerid(dgvloting, "Datumid")
        Dim datum = Datumweeretcrepo.Get(Datumid)

    End Sub

    Private Sub btnVerwijdeen_Click(sender As Object, e As EventArgs) Handles btnVerwijdeen.Click

        If dgvloting.SelectedRows.Count = 0 Then
            Return
        End If

        Dim Datumid = Selecteerid(dgvloting, "Datumid")
        Dim datum = Datumweeretcrepo.Get(Datumid)

    End Sub

    Private Sub btnNieuw_Click(sender As Object, e As EventArgs) Handles btnNieuw.Click

        frmLotingnieuw.ShowDialog()

        Lotingrepo.Deleteemptyrow()

        Vulgrid()

    End Sub
End Class