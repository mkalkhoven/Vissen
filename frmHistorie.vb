Imports Datalaag.Global
Public Class frmHistorie
    Private Sub frmHistorie_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Icon = FrmMain.Icon
        Text = $"{FrmMain.Text} - Loting historie"

        VulSeriecombo(cboSerie)

        Icon = FrmMain.Icon

    End Sub

    Public Sub VulSeriecombo(cbo As ComboBox)

        cbo.Items.Clear()
        Dim series As New List(Of Serie)
        Dim leeg As New Serie
        series.Add(leeg)
        Dim vijftigplus As New Serie With {
                .Serieid = 6,
                .Naam = "50 plus"
                }
        series.Add(vijftigplus)
        Dim jeugd As New Serie With {
                .Serieid = 12,
                .Naam = "Jeugd"
                }
        series.Add(jeugd)
        Dim senioren As New Serie With {
                .Serieid = 1,
                .Naam = "Senioren"
                }
        series.Add(senioren)
        Dim winter As New Serie With {
                .Serieid = 9,
                .Naam = "Winter"
                }
        series.Add(winter)

        cbo.DataSource = series
        cbo.ValueMember = "Serieid"
        cbo.DisplayMember = "Naam"

    End Sub

    Private Sub btnSluiten_Click(sender As Object, e As EventArgs) Handles btnSluiten.Click

        Dispose()

    End Sub

    Private Sub cboSerie_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSerie.SelectedIndexChanged

        Fillgrid()
        If cboSerie.SelectedIndex > 0 Then
            btnLoting.Enabled = True
            btnBewerken.Enabled = True
        End If

    End Sub

    Private Sub Fillgrid()

        Try
            Dim serieid = cboSerie.SelectedValue
            If serieid > 0 Then
                Dim seizoen = Seizoenrepo.Get(Sorting.descending)
                RemoveHandler cboSeizoen.SelectedIndexChanged, AddressOf cboSeizoen_SelectedIndexChanged
                cboSeizoen.DataSource = seizoen
                AddHandler cboSeizoen.SelectedIndexChanged, AddressOf cboSeizoen_SelectedIndexChanged
                cboSeizoen.DisplayMember = "Jaar"
                cboSeizoen.ValueMember = "ID"
            End If
        Catch ex As Exception
            dgvLoting.DataSource = Nothing
        End Try

        Vulgrid()

    End Sub

    Private Sub Vulgrid()

        Dim serieid = Getid(cboSerie)
        Dim seizoenid = Getid(cboSeizoen)

        If seizoenid = 0 Then
            Return
            seizoenid = Seizoenrepo.Getlaatste()
        End If

        Dim sql = $"SELECT DISTINCT n.NaamID, n.Naam, n.Achternaam, n.Voornaam FROM Namen n JOIN Loting2 l on l.Naamid = n.NaamID WHERE l.Serieid = {serieid} AND l.Seizoenid = {seizoenid} ORDER BY n.Achternaam, n.Voornaam"
        Dim dt = Selecteer(sql)
        dgvLoting.DataSource = dt
        dgvLoting.Columns(0).Visible = False
        dgvLoting.Columns(1).Width = 250
        dgvLoting.Columns(2).Visible = False
        dgvLoting.Columns(3).Visible = False

        sql = $"SELECT DISTINCT Datum, Serienummer from loting2 where serieid = {serieid} and seizoenid = {seizoenid} ORDER BY Datum"
        Dim dt2 = Selecteer(sql)
        For Each row As DataRow In dt2.Rows
            dt.Columns.Add(row("Serienummer"), Type.GetType("System.String"))
        Next

        Dim iRow = 0
        For Each row As DataRow In dt.Rows
            Dim iCol = 4
            Dim inaam = 0
            For Each row2 As DataRow In dt2.Rows
                'Per naam
                inaam += 1
                'Application.DoEvents()

                sql = $"SELECT * FROM Loting2 WHERE Naamid = {row("Naamid")} AND Seizoenid = {seizoenid} AND Serieid = {serieid} AND Serienummer = '{row2("Serienummer")}'"
                Dim dt3 = Selecteer(sql)
                If dt3.Rows.Count = 0 Then
                    'Streepje
                    dgvLoting.Rows(iRow).Cells(iCol).Value = "-"
                Else
                    'Plaats
                    If cboSerie.SelectedValue = 9 Then
                        'dgvLoting.Rows(iRow).Cells(iCol).Value = $"{Plaatsrow("Onderboven")}{Plaatsrow("Plaats")}"
                    Else
                        'Ernout even naar kijken -> celltype integer
                        dgvLoting.Rows(iRow).Cells(iCol).Value = dt3.Rows(0)("Plaats").ToString
                    End If
                End If
                iCol += 1
            Next
            iRow += 1
        Next

        dgvLoting.DataSource = dt

    End Sub

    Private Sub cboSeizoen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSeizoen.SelectedIndexChanged

        Vulgrid()

    End Sub

    Private Sub dgvLoting_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvLoting.DataBindingComplete

        For Each col As DataGridViewColumn In dgvLoting.Columns
            If col.HeaderText.Contains(".") Then
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                col.Width = 45
            End If
        Next

        dgvLoting.ClearSelection()

    End Sub

    Private Sub btnBewerken_Click(sender As Object, e As EventArgs) Handles btnBewerken.Click


        Dim serieid = Getid(cboSerie)
        Dim seizoenid = Getid(cboSeizoen)
        Dim serie = Naamserierepo.Get(serieid)
        Dim seizoen = Seizoenrepo.Get(seizoenid)

        Dim f As New frmHistorieserie With {
            .serie = serie,
            .seizoen = seizoen
        }
        f.ShowDialog()

        Vulgrid()

    End Sub
End Class