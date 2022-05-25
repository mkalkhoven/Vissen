Imports Datalaag
Imports Datalaag.Global
Public Class frmHistorieseriebewerken

    Public datum As DateTime
    Public Agendaid As Long 'Komt uit agenda in deruisvoorn database
    Public serie As NaamSerie
    Public seizoen As Seizoen
    Private Legeloting As Boolean
    Private Sub frmHistorieseriebewerken_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblSerie.Text = serie.Naam
        lblSeizoen.Text = seizoen.Jaar

        lblDatum.Text = datum.ToString("d MMMM yyyy")
        Icon = FrmMain.Icon

        Legeloting = False

        Fillgrid()

        If dgvLoting.Rows.Count = 0 Then 'Lege loting
            Legeloting = True

            Dim Sql As String

            Select Case serie.Id
                Case 1, 2, 3, 17 'Senioren
                    Sql = "Select Naamid, Naam, null AS Plaats from namen WHERE Senioren = 1 ORDER BY Achternaam"
                Case 6
                    Sql = "Select Naamid, Naam, null AS Plaats from namen WHERE Vijftigplus = 1 ORDER BY Achternaam"
                Case 9, 10, 11 'Winter
                    Sql = "Select Naamid, Naam, null AS Plaats from namen WHERE Winter = 1 ORDER BY Achternaam"
                Case 12, 13 'Jeugd
                    Sql = "Select Naamid, Naam, null AS Plaats from namen WHERE Jeugd = 1 ORDER BY Achternaam"
                Case Else 'Alle enkele series
                    Toonmelding("De serie is niet gedefinieerd in de functie frmHistorieseriebewerken_Load")
                    Return
            End Select
            Dim dt = ModDatabase.Selecteer(Sql)
            dgvLoting.DataSource = dt
            dgvLoting.Columns(0).Visible = False
            dgvLoting.Columns(1).Width = 300
            dgvLoting.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End If

    End Sub
    Private Sub Fillgrid()

        Dim sql = $"SELECT l.Lotingid, n.Naam, l.Plaats, l.Naamid FROM Loting2 l JOIN Namen n ON l.Naamid = n.NaamID WHERE l.Datum = {GetISODate(datum)}  AND l.Serieid = {serie.Id} AND l.Plaats > 0 ORDER BY l.Plaats"
        Dim dt = ModDatabase.Selecteer(sql)

        dgvLoting.DataSource = dt
        dgvLoting.Columns(0).Visible = False
        dgvLoting.Columns(1).Width = 300
        dgvLoting.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgvLoting.Columns(3).Visible = False

    End Sub
    Private Sub btnSluiten_Click(sender As Object, e As EventArgs) Handles btnSluiten.Click

        Dispose()

    End Sub

    Private Sub btnOpslaan_Click(sender As Object, e As EventArgs) Handles btnOpslaan.Click

        Dim loting As Loting2

        If Legeloting = False Then
            For Each row As DataGridViewRow In dgvLoting.Rows

                Dim Plaats = 0
                Dim lotingid = Getid(row)
                Long.TryParse(row.Cells(2).Value.ToString, Plaats)

                loting = Lotingrepo.Get(lotingid)
                loting.Plaats = Plaats
                Lotingrepo.Save(loting)
            Next
        Else
            'Nieuwe loting aanmaken op basis van nul loting
            Dim nulloting = Lotingrepo.getnulloting(serie.Id)

            If IsNothing(nulloting) Then
                Exit Sub
            End If

            For Each row As DataGridViewRow In dgvLoting.Rows
                Try
                    'Dim datum2 As Date = datum.Datum
                    'Dim agenda = Selecteeragenda(datum2)
                    Dim Naamid = Long.Parse(row.Cells(0).Value.ToString)
                    Dim Plaats = Long.Parse(row.Cells(2).Value.ToString)

                    loting = New Loting2 With {
                        .Naamid = Naamid,
                        .Seizoenid = seizoen.ID,
                        .Serieid = serie.Id,
                        .Datum = nulloting.Datum,
                        .Nummer = 0,
                        .Plaats = Plaats,
                        .Datumid = nulloting.Datumid,
                        .Serienummer = nulloting.Serienummer
                    }
                    Lotingrepo.Save(loting)
                Catch ex As Exception
                    'Geen plaats, niet opslaan
                End Try
            Next
            Lotingrepo.Delete(nulloting)
        End If
        Fillgrid()

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
        If Toonvraag("Wilt u de geselecteerde plaats verwijderen?") = DialogResult.Yes Then
            Dim id = Getid(dgvLoting)
            Lotingrepo.Delete(id)
            Fillgrid()
        End If

    End Sub
End Class