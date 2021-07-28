Imports Datalaag
Imports Datalaag.Global
Public Class frmHistorieseriebewerken

    Public datum As DatumWeerEtc
    Public serie As NaamSerie
    Public seizoen As Seizoen
    Private Sub frmHistorieseriebewerken_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblSerie.Text = serie.Naam
        lblSeizoen.Text = seizoen.Jaar
        lblDatum.Text = datum.Datum.Value.ToString("d MMMM yyyy")
        Icon = FrmMain.Icon

    End Sub

    Private Sub btnSluiten_Click(sender As Object, e As EventArgs) Handles btnSluiten.Click

        Dispose()

    End Sub
End Class