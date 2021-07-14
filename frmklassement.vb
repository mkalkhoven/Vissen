Imports Datalaag
Imports Datalaag.Global
Public Class Frmklassement

    public Serie As New NaamSerie 
    public Seizoen As New Seizoen
    Private Function Selecteercorrectie As KlassementCorrectie
        
        Dim correctie  = Correctierepo.Get(Seizoen, Serie)
        return correctie

    End Function

    Private Sub frmklassement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
        Icon = FrmMain.Icon

        lblseizoen.Text = Seizoen.Jaar
        lblSerie.Text = Serie.Naam

        Dim correctie = Selecteercorrectie()
        If correctie Is Nothing Then
            Cbocorrectie.Text = "0"
        Else 
            Cbocorrectie.Text = correctie.Correctie
        End If

        Fillgrid()

    End Sub
    Private Function Maaktabelnaam()As String

        Dim naamserie As string

        Select Case Serie.id
            Case 1, 2, 3, 6, 9, 10, 11
                naamserie = Serie.Naam.Replace(" ", "")
            Case 12
                naamserie = "Jeugdeersteserie"
            Case 13
                naamserie = "Jeugdtweedeserie"
        End Select

        Return $"Klassement{naamserie}_{Seizoen.ID}"

    End Function
    Private sub Fillgrid()

        Dim tabelnaam = Maaktabelnaam()
        Dim kolommen = ""

        Dim aantal = Uitslagenrepo.Getaantal(Serie, Seizoen)

        For i = 1 To aantal
            kolommen = $"{kolommen} ,Punten{i} AS [Pnt{i}], Gewicht{i} AS [Gew{i}]"
        Next

        Dim sql As String

        if Serie.Naam.ToLower().Contains("jeugd") Then
            sql = $"SELECT '' AS [Pl], n.Naam, k.Totaalpunten AS [Punten], k.Totaalgewicht AS [Gewicht], k.X {Kolommen} FROM {tabelnaam} k JOIN Namen n ON k.Deelnemerid = n.NaamID ORDER BY k.Totaalgewicht DESC"
        else
            sql = $"SELECT '' AS [Pl], n.Naam, k.Totaalpunten AS [Punten], k.Totaalgewicht AS [Gewicht], k.X {Kolommen} FROM {tabelnaam} k JOIN Namen n ON k.Deelnemerid = n.NaamID ORDER BY k.Totaalpunten ASC"
        End If
        Dim dt = Selecteer(sql)

        If dt.Rows.Count > 0 Then


            dgvKlassement.DataSource = dt
        dgvKlassement.Columns(1).DefaultCellStyle.Format = "N0"
        dgvKlassement.Columns(3).DefaultCellStyle.Format = "N1"
        dgvKlassement.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvKlassement.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvKlassement.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvKlassement.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        
        if Serie.Naam.ToLower().Contains("jeugd") Then
            dgvKlassement.Columns(2).HeaderText = "Aantal"
            dgvKlassement.Columns(2).DefaultCellStyle.Format = "N0"
        Else 
            dgvKlassement.Columns(2).DefaultCellStyle.Format = "N1"
        End If
        
        For Each col As DataGridViewColumn In dgvKlassement.Columns
            If col.HeaderText.Contains("Pnt") Then
                If Serie.Naam.ToLower().Contains("jeugd")
                    col.DefaultCellStyle.Format = "N0"    
                    col.HeaderText = col.HeaderText.Replace("Pnt", "Aant")
                Else 
                    col.DefaultCellStyle.Format = "N1"
                End If
            End If
            If col.HeaderText.Contains("Gew") Then
                col.DefaultCellStyle.Format = "N0"
            End If
            col.Width = 75
        Next
        dgvKlassement.Columns(0).Width = 50
        dgvKlassement.Columns(1).Width = 250
        dgvKlassement.Columns(3).Width = 100

        dgvKlassement.Width = dgvKlassement.Columns(0).Width + dgvKlassement.Columns(1).Width + dgvKlassement.Columns(2).Width + dgvKlassement.Columns(3).Width + dgvKlassement.Columns(4).Width
        Width = dgvKlassement.Width + 36

        Dim teller = 1
        For Each row As DataGridViewRow In dgvKlassement.Rows
            row.Cells(0).Value = $"{teller}."
            teller += 1
        Next

        End If


        dgvKlassement.Height = (dgvKlassement.Rows.Count * 22) + 60
        Height = dgvKlassement.Height + dgvKlassement.Top + 36

        btnMaakklassement.Left = width - 24 - btnMaakklassement.Width
        btnSluiten.Left = btnMaakklassement.Left



    End sub

    Private Sub btnMaakklassement_Click(sender As Object, e As EventArgs) Handles btnMaakklassement.Click
        
        Enabled = False

        Dim correctie = Selecteercorrectie()
        If correctie Is nothing then
            correctie = new KlassementCorrectie With {
                .Seizoenid = Seizoen.ID,
                .Serieid = serie.Id
            }
        End If
        correctie.Correctie = Integer.Parse(Cbocorrectie.Text)
        Correctierepo.Save(correctie)
        'Weggooien en maken van de tabel
        Dim tabelnaam = Maaktabelnaam()
        Dim sql = $"DROP TABLE {tabelnaam}"
        Uitvoeren(sql)

        sql = $"CREATE TABLE [dbo].[{tabelnaam}](
	        [Deelnemerid] [int] NOT NULL,
	        [Totaalpunten] [float] NULL,
	        [Totaalgewicht] [int] NULL,
	        [X] [int] NULL,"
        Dim aantal = Uitslagenrepo.Getaantal(Serie, Seizoen)
        Dim kolommen = ""
        For i = 1 To aantal
            kolommen = $"{kolommen} [Punten{i}] [float] NULL,"
            kolommen = $"{kolommen} [Gewicht{i}] [float] NULL,"
        Next
        sql = $"{sql}{kolommen}
            PRIMARY KEY CLUSTERED 
            ([Deelnemerid] ASC
            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
            ) ON [PRIMARY]"
        Uitvoeren(sql)

        'Vullen van de tabel
        'Alle deelnemers van serie en seizoen selecteren

        Dim serienaam = ""
        Select Case Serie.id
            Case 6
                serienaam= "Vijftigplus"
            Case 1, 2, 3
                serienaam = "Senioren"
            Case 9, 10, 11
                serienaam = "Winter"
            Case 12, 13
                serienaam = "Jeugd"
        End Select

        sql = $"SELECT ID FROM DatumWeerEtc WHERE IDseizoen = {Seizoen.ID} AND SerieNaamNr = {Serie.Id}"
        Dim dtWedstrijden = selecteer(sql)

        sql= $"SELECT DISTINCT n.Naamid, n.naam FROM Namen n JOIN Uitslagen u ON n.NaamID = u.IDdeelnemer WHERE n.{serienaam} = 1 AND u.SerieNaamNr = {Serie.Id} AND u.IDseizoen = {Seizoen.ID}"
        Dim dt = Selecteer(sql)
        For Each row As datarow In dt.Rows
            Dim tmpUitslagen As new List(Of Tmpuitslag)
            Dim aantalX = 0
            sql = $"INSERT INTO {tabelnaam}(Deelnemerid)VALUES({row("Naamid")})"
            Uitvoeren(sql)
            Dim teller = 1
            For Each wedstrijd As datarow In dtWedstrijden.Rows
                Dim tmpUitslag As new Tmpuitslag
                sql = $"SELECT * FROM Uitslagen WHERE IDdatum = {wedstrijd("ID")} AND  IDdeelnemer = {row("Naamid")}"
                Dim uitslag = Selecteer(sql)
                If uitslag.Rows.Count = 0 Then
                    tmpUitslag.Punten = Serie.Maxaantal
                    tmpUitslag.Gewicht = 0
                    sql = $"UPDATE {tabelnaam} SET Punten{teller} = {Serie.Punten} WHERE Deelnemerid = {row("Naamid")}"
                    Uitvoeren(sql)
                ElseIf uitslag.Rows.Count = 1 Then
                    aantalX += 1
                    Dim regel = uitslag(0)
                    tmpUitslag.Punten = regel("Pnt")
                    tmpUitslag.Gewicht = regel("Kilo")
                    sql = $"UPDATE {tabelnaam} SET Punten{teller} = {regel("Pnt").ToString().Replace(",", ".")}, Gewicht{teller} = {regel("Kilo")} WHERE Deelnemerid = {row("Naamid")}"
                    Uitvoeren(sql)
                End If
                teller += 1
                tmpUitslagen.Add(tmpUitslag)
            Next

            Dim tmp = tmpUitslagen.OrderBy(Function(obj) obj.Punten).ThenByDescending(Function(obj) obj.Gewicht) 
            
            Dim totaalgewicht = 0
            Dim totaalpunten = 0
            dim corr As Integer = Integer.Parse(Cbocorrectie.Text)
            corr = aantal - corr

            'If Serie.Naam.ToLower().Contains("jeugd") Then
            '    For i = 0 To tmpUitslagen.Count-1
            '        Dim x = tmp(i)
            '        totaalpunten += x.Punten
            '        totaalgewicht += x.Gewicht
            '    Next
            'Else 
                For i = 0 To corr-1
                    Dim x = tmp(i)
                    totaalpunten += x.Punten
                    totaalgewicht += x.Gewicht
                Next
            'End If

            sql = $"UPDATE {tabelnaam} SET X = {aantalX}, Totaalpunten = {totaalpunten}, Totaalgewicht = {totaalgewicht} WHERE Deelnemerid = {row("Naamid")}"
            Uitvoeren(sql)
        Next

        Fillgrid()
        Enabled = true

    End Sub

    Private Sub btnSluiten_Click(sender As Object, e As EventArgs) Handles btnSluiten.Click

        Dispose()

    End Sub
End Class