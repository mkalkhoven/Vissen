Imports Datalaag.Global
Imports Datalaag
Public Class frmLotingnieuw
    Dim Isloaded As Boolean = False
    Private Sub frmLotingnieuw_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Icon = FrmMain.Icon
        Text = "Nieuwe loting"

        Dim seizoenen = Seizoenrepo.Getsorted
        cboSeizoen.DataSource = seizoenen
        cboSeizoen.ValueMember = "Id"
        cboSeizoen.DisplayMember = "Jaar"

        Dim series = Naamserierepo.Getsorted
        cboserie.DataSource = series
        cboserie.ValueMember = "Id"
        cboserie.DisplayMember = "Naam"

        Isloaded = True

        Zoekwedstrijd()

    End Sub

    Private Sub Zoekwedstrijd()

        'MessageBox.Show(dtpDatum.Value.ToString)


        Dim serieid = cboserie.SelectedValue
        Dim visdatum As Date = dtpDatum.Value

        Dim Datum = Selecteeragenda(visdatum, serieid)
        If Datum.Agendaid > 0 Then
            txtSerienaamnummer.Text = Datum.Serienaamnummer
            lblDatumid.Text = Datum.Agendaid
        End If

    End Sub

    Private Sub btnSluiten_Click(sender As Object, e As EventArgs) Handles btnSluiten.Click

        Hide()

    End Sub

    Private Sub btnopslaan_Click(sender As Object, e As EventArgs) Handles btnopslaan.Click

        Dim datum = New DateTime(dtpDatum.Value.Year, dtpDatum.Value.Month, dtpDatum.Value.Day, 0, 0, 0)

        Dim loting As New Loting2 With {
            .Naamid = 0,
            .Seizoenid = Long.Parse(cboSeizoen.SelectedValue.ToString),
            .Serieid = Long.Parse(cboserie.SelectedValue.ToString),
            .Datum = datum,
            .Nummer = 0,
            .Plaats = 0,
            .Datumid = Long.Parse(lblDatumid.Text),
            .Serienummer = txtSerienaamnummer.Text
        }
        Lotingrepo.Save(loting)

        Hide()

        Dim datumweeretc As DatumWeerEtc = Datumweeretcrepo.Get(datum, Long.Parse(cboserie.SelectedValue.ToString))

        If IsNothing(datumweeretc) Then
            Toonmelding("De datum is niet terug te vinden in de tabel DatumWeerEtc")
            Exit Sub
        End If

        Dim seizoen = Seizoenrepo.Get(Long.Parse(cboSeizoen.SelectedValue.ToString))
        Dim serie = Naamserierepo.Get(Long.Parse(cboserie.SelectedValue.ToString))

        Dim f As New frmHistorieseriebewerken With {
            .datum = datumweeretc,
            .serie = serie,
            .seizoen = seizoen,
            .Agendaid = Long.Parse(lblDatumid.Text)
        }
        f.ShowDialog()

        Dispose()

    End Sub

    Private Sub dtpDatum_ValueChanged(sender As Object, e As EventArgs) Handles dtpDatum.ValueChanged

        If Isloaded Then
            Zoekwedstrijd
        End If

    End Sub

    Private Sub cboserie_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboserie.SelectedIndexChanged

        If Isloaded Then
            Zoekwedstrijd
        End If

    End Sub
End Class