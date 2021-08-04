Imports Datalaag
Imports Datalaag.Global
Public Class frmHistorieseriebewerken

    Public datum As DatumWeerEtc
    Public Agendaid As Long 'Komt uit agenda in deruisvoorn database
    Public serie As NaamSerie
    Public seizoen As Seizoen
    Private Sub frmHistorieseriebewerken_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblSerie.Text = serie.Naam
        lblSeizoen.Text = seizoen.Jaar
        lblDatum.Text = datum.Datum.Value.ToString("d MMMM yyyy")
        Icon = FrmMain.Icon


        Fillgrid()




        'Dim sql = "SELECT DISTINCT ID, Jaar FROM Seizoen ORDER BY Jaar DESC"
        'Dim dt = Selecteer(sql)

        'cboSeizoen.DataSource = dt
        'cboSeizoen.DisplayMember = "Jaar"
        'cboSeizoen.ValueMember = "ID"

        'If loting.Lotingid > 0 Then
        '    btnLotingopslaan.Visible = False
        '    btnOpslaan.Visible = True
        '    btnOpslaan.Enabled = True
        '    Fillgrid()
        'Else
        '    btnLotingopslaan.Location = New Point(437, 6)
        '    Fillgrid()
        'End If


    End Sub
    Private Sub Fillgrid()

        Dim sql = $"SELECT l.Lotingid, n.Naam, l.Plaats, n.Naamid FROM Loting2 l JOIN Namen n ON l.Naamid = n.NaamID WHERE Datum = {GetISODate(datum.Datum)} AND Serieid = {serie.Id}"
        Dim dt = Selecteer(sql)

        dgvLoting.DataSource = dt
        dgvLoting.Columns(0).Visible = False
        dgvLoting.Columns(1).Width = 340
        dgvLoting.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgvLoting.Columns(3).Visible = False

    End Sub
    Private Sub btnSluiten_Click(sender As Object, e As EventArgs) Handles btnSluiten.Click

        Dispose()

    End Sub

    Private Sub btnOpslaan_Click(sender As Object, e As EventArgs) Handles btnOpslaan.Click

        For Each row As DataGridViewRow In dgvLoting.Rows
            Dim lotingid = Getid(row)
            Dim Plaats = Long.Parse(row.Cells(2).Value.ToString)
            Dim Naamid = Long.Parse(row.Cells(3).Value.ToString)
            Dim Sql As String
            If lotingid = 0 Then
                'Eerst alle gegevens ophalen
                Dim loting = Lotingrepo.Getbydatumid(Agendaid)
                'Insert
                Sql = $"INSERT INTO Loting2(Naamid, Seizoenid, Serieid, Datum, Nummer, Plaats, Datumid, Serienummer)VALUES({Naamid}, {loting.Seizoenid}, {loting.Serieid}, {GetISODate(loting.Datum)}, 0, {Plaats}, {loting.Datumid}, {loting.Serienummer})"
            Else
                'Update
                Sql = $"UPDATE Loting2 SET Plaats = {Plaats} WHERE Lotingid = {lotingid}"
            End If
            Opslaan(Sql)
        Next

    End Sub

    Private Sub btnNieuw_Click(sender As Object, e As EventArgs) Handles btnNieuw.Click

        Dim Loting = Lotingrepo.Get(Getid(dgvLoting.Rows(0)))
        Dim Newloting As New Loting2 With {
            .Datum = Loting.Datum,
            .Datumid = Loting.Datumid,
            .Seizoenid = Loting.Seizoenid,
            .Serieid = Loting.Serieid,
            .Serienummer = Loting.Serienummer
        }
        Dim f As New frmHistorienieuw With {
            .Loting = Newloting
        }
        f.ShowDialog()
        Fillgrid()

    End Sub

    Private Sub btnVerwijderen_Click(sender As Object, e As EventArgs) Handles btnVerwijderen.Click

        If dgvLoting.SelectedRows.Count = 0 Then
            Return
        End If
        If Toonvraag("Wilt u de geselecteerde plaat verwijderen?") = DialogResult.Yes Then
            Dim id = Getid(dgvLoting)
            Lotingrepo.Delete(id)
            Fillgrid()
        End If

    End Sub
End Class