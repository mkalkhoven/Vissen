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

        Select Case serie.Id
            Case 1, 2, 3 'Senioren
                lblSerie.Text = "Senioren"
            Case 6
                lblSerie.Text = serie.Naam
            Case 9, 10, 11 'Winter
                lblSerie.Text = "Winter"
            Case 12, 13 'Jeugd
                lblSerie.Text = "Jeugd"
            Case Else 'Alle enkele series
                Toonmelding("De serie kan niet opgehaald worden")
                Return
        End Select

        Vulgrid()

    End Sub
    Private Sub Vulgrid()

        Dim sql As String

        Select Case serie.Id
            Case 1, 2, 3 'Senioren
                'sql = $"SELECT Id, Datum, CAST(IDserieNummer as VARCHAR(2)) + 'e.' as Serie, Plaats FROM DatumWeerEtc WHERE (SerieNaamNr = 1 AND IDseizoen = {seizoen.ID}) OR (SerieNaamNr = 2 AND IDseizoen = {seizoen.ID}) OR (SerieNaamNr = 3 AND IDseizoen = {seizoen.ID})"
                sql = $"SELECT DISTINCT d.ID AS Datumid, l.Datum, l.Serienummer, a.Locatie FROM VisSeizoen.dbo.Loting2 l JOIN DeRuisvoorn.dbo.Agenda a ON l.Datum = a.Datum JOIN VisSeizoen.dbo.DatumWeerEtc d ON a.Datum = d.Datum WHERE (l.Serieid = 1 AND l.Seizoenid = {seizoen.ID}) OR (l.Serieid = 2 AND l.Seizoenid = {seizoen.ID}) OR (l.Serieid = 3 AND l.Seizoenid = {seizoen.ID}) ORDER BY l.Datum"
            Case 9, 10, 11 'Winter
                'sql = $"SELECT Id, Datum, CAST(IDserieNummer as VARCHAR(2)) + 'e.' as Serie, Plaats FROM DatumWeerEtc WHERE (SerieNaamNr = 9 AND IDseizoen = {seizoen.ID}) OR (SerieNaamNr = 10 AND IDseizoen = {seizoen.ID}) OR (SerieNaamNr = 11 AND IDseizoen = {seizoen.ID})"
                sql = $"SELECT DISTINCT d.ID AS Datumid, l.Datum, l.Serienummer, a.Locatie FROM VisSeizoen.dbo.Loting2 l JOIN DeRuisvoorn.dbo.Agenda a ON l.Datum = a.Datum JOIN VisSeizoen.dbo.DatumWeerEtc d ON a.Datum = d.Datum WHERE (l.Serieid = 9 AND l.Seizoenid = {seizoen.ID}) OR (l.Serieid = 10 AND l.Seizoenid = {seizoen.ID}) OR (l.Serieid = 11 AND l.Seizoenid = {seizoen.ID}) ORDER BY l.Datum"
            Case 12, 13 'Jeugd
                'sql = $"SELECT Id, Datum, CAST(IDserieNummer as VARCHAR(2)) + 'e.' as Serie, Plaats FROM DatumWeerEtc WHERE (SerieNaamNr = 12 AND IDseizoen = {seizoen.ID}) OR (SerieNaamNr = 13 AND IDseizoen = {seizoen.ID})"
                sql = $"SELECT DISTINCT d.ID AS Datumid, l.Datum, l.Serienummer, a.Locatie FROM VisSeizoen.dbo.Loting2 l JOIN DeRuisvoorn.dbo.Agenda a ON l.Datum = a.Datum JOIN VisSeizoen.dbo.DatumWeerEtc d ON a.Datum = d.Datum WHERE (l.Serieid = 12 AND l.Seizoenid = {seizoen.ID}) OR (l.Serieid = 13 AND l.Seizoenid = {seizoen.ID}) ORDER BY l.Datum"
            Case Else 'Alle enkele series
                'sql = $"SELECT Id, Datum, CAST(IDserieNummer as VARCHAR(2)) as Serie, Plaats FROM DatumWeerEtc WHERE (SerieNaamNr = {serie.Id} AND IDseizoen = {seizoen.ID})"
                sql = $"SELECT DISTINCT d.ID AS Datumid, l.Datum, l.Serienummer, a.Locatie FROM VisSeizoen.dbo.Loting2 l JOIN DeRuisvoorn.dbo.Agenda a ON l.Datum = a.Datum JOIN VisSeizoen.dbo.DatumWeerEtc d ON a.Datum = d.Datum WHERE (l.Serieid = {serie.Id} AND l.Seizoenid = {seizoen.ID}) ORDER BY l.Datum"
        End Select

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
End Class