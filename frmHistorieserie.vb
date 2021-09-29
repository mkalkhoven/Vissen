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

        Dim sql As String

        Select Case serie.Id
            Case 1, 2, 3 'Senioren
                sql = $"SELECT Id, Datum, CAST(IDserieNummer as VARCHAR(2)) + 'e.' as Serie, Plaats FROM DatumWeerEtc WHERE (SerieNaamNr = 1 AND IDseizoen = {seizoen.ID}) OR (SerieNaamNr = 2 AND IDseizoen = {seizoen.ID}) OR (SerieNaamNr = 3 AND IDseizoen = {seizoen.ID})"
            Case 9, 10, 11 'Winter
                sql = $"SELECT Id, Datum, CAST(IDserieNummer as VARCHAR(2)) + 'e.' as Serie, Plaats FROM DatumWeerEtc WHERE (SerieNaamNr = 9 AND IDseizoen = {seizoen.ID}) OR (SerieNaamNr = 10 AND IDseizoen = {seizoen.ID}) OR (SerieNaamNr = 11 AND IDseizoen = {seizoen.ID})"
            Case 12, 13 'Jeugd
                sql = $"SELECT Id, Datum, CAST(IDserieNummer as VARCHAR(2)) + 'e.' as Serie, Plaats FROM DatumWeerEtc WHERE (SerieNaamNr = 12 AND IDseizoen = {seizoen.ID}) OR (SerieNaamNr = 13 AND IDseizoen = {seizoen.ID})"
            Case Else 'Alle enkele series
                'sql = $"SELECT Id, Datum, CAST(IDserieNummer as VARCHAR(2)) + 'e.' as Serie, Plaats FROM Agenda SerieNaamNr = {serie.Id} AND IDseizoen = {seizoen.ID}"
                sql = $"SELECT Agendaid, Datum, Serie, Locatie FROM Agenda WHERE Serieid = {serie.Id} AND Seizoenid = {seizoen.ID} ORDER BY Datum"
        End Select

        Dim dt = Selecteeragenda(sql)

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