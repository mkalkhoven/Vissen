Imports Datalaag
Imports Datalaag.Global
Public Class FrmVisser

    public Serie As New NaamSerie 
    public Seizoen As New Seizoen
    Private Sub frmVisser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
        Icon = FrmMain.Icon

        lblseizoen.Text = Seizoen.Jaar

        Select Case Serie.Id
            Case 1, 2, 3
                lblSerie.Text = "Koningsvisser"
                btnVisser.Text = "Maak Koningsvisser"
                Text = "Koningsvisser"
            Case 9, 10, 11
                lblSerie.Text = "Wintervisser"
                btnVisser.Text = "Maak Wintervisser"
                Text = "Wintervisser"
            Case 12, 13
                lblSerie.Text = "Jeugdvisser"
                Text = "Jeugdvisser"
                btnVisser.Text = "Maak Jeugdvisser"
        End Select

        Fillgrid()

    End Sub

    Private Sub btnSluiten_Click(sender As Object, e As EventArgs) Handles btnSluiten.Click

        Dispose()

    End Sub
    Private Function Maaktabelnaam()As String

        Select Case Serie.Id
            Case 1, 2, 3'Koningsvisser
                Return $"Koningsvisser_{Seizoen.ID}"
            Case 9, 10, 11'Wintervisser
                Return $"Wintervisser_{Seizoen.ID}"
            Case 12, 13'Jeugdvisser
                Return $"Jeugdvisser_{Seizoen.ID}"
        End Select
        Return "Foutje bedankt"

    End Function

    Private sub Fillgrid()

        Dim tabelnaam = Maaktabelnaam()
        
        Dim sql = $"SELECT '' AS [Pl], n.Naam, k.* FROM Namen n JOIN {tabelnaam} k ON n.NaamID = k.Deelnemerid ORDER BY k.Totaalgewicht DESC"
        Dim dt = Selecteer(sql)

        dgvVisser.DataSource = dt
        dgvVisser.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvVisser.Columns(0).Width = 50
        dgvVisser.Columns(1).Width = 250
        dgvVisser.Columns(2).Visible = false
        dgvVisser.Columns(3).DefaultCellStyle.Format = "N0"
        dgvVisser.Columns(3).HeaderText = "Gewicht"
        dgvVisser.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvVisser.Columns(4).Width = 75
        dgvVisser.Columns(4).HeaderText = "Aantal"
        dgvVisser.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvVisser.Columns(5).DefaultCellStyle.Format = "N0"
        dgvVisser.Columns(5).Width = 35
        dgvVisser.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        
        For Each col As DataGridViewColumn In dgvVisser.Columns
            If col.HeaderText.Contains("_") Then
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                col.DefaultCellStyle.Format = "N0"
                'col.HeaderText = col.HeaderText.Replace("_", " ")
                'col.DefaultCellStyle.WrapMode = DataGridViewTriState.True
                col.Width = 75
            End If
        Next
        
        Dim teller = 1
        For Each row As DataGridViewRow In dgvVisser.Rows
            row.Cells(0).Value = $"{teller}e."
            teller += 1
        Next
        
        dgvVisser.Height = (dgvVisser.Rows.Count * 22) + 60
        Height = dgvVisser.Height + dgvVisser.Top + 36

        btnVisser.Left = width - 24 - btnVisser.Width
        btnSluiten.Left = btnVisser.Left

    End sub

    Private Sub btnVisser_Click(sender As Object, e As EventArgs) Handles btnVisser.Click

        Enabled = false

        Dim tabelnaam = $"{Maaktabelnaam()}"
        Dim kolommen = ""
        
        Dim sql = $"DROP TABLE {tabelnaam}"
        Uitvoeren(sql)
        
        Dim totaalvis = ""
        If Serie.Naam.ToLower().Contains("jeugd") Then
            totaalvis = "[Totaalvis] [int] NULL,"
        end if
        sql = $"CREATE TABLE [dbo].[{tabelnaam}](
	        [Deelnemerid] [int] NOT NULL,
	        [Totaalgewicht] [int] NULL,{totaalvis}
	        [X] [int] NULL,"

        Dim aantal = 0

        Select Case Serie.Id
            Case 1, 2, 3'Koningsvisser
                aantal = Uitslagenrepo.Getaantal(1, Seizoen)
                If aantal > 0 Then
                    kolommen = kolommen & Maakkolommen("A", aantal)
                End If
                aantal = Uitslagenrepo.Getaantal(2, Seizoen)
                If aantal > 0 Then
                    kolommen = kolommen & Maakkolommen("B", aantal)
                End If
                aantal = Uitslagenrepo.Getaantal(3, Seizoen)
                If aantal > 0 Then
                    kolommen = kolommen & Maakkolommen("C", aantal)
                End If
            Case 9, 10, 11'Wintervisser
                aantal = Uitslagenrepo.Getaantal(9, Seizoen)
                If aantal > 0 Then
                    kolommen = kolommen & Maakkolommen("A_", aantal)
                End If
                aantal = Uitslagenrepo.Getaantal(10, Seizoen)
                If aantal > 0 Then
                    kolommen = kolommen & Maakkolommen("B_", aantal)
                End If
                aantal = Uitslagenrepo.Getaantal(11, Seizoen)
                If aantal > 0 Then
                    kolommen = kolommen & Maakkolommen("C_", aantal)
                End If
            Case 12, 13'Jeugdvisser
                aantal = Uitslagenrepo.Getaantal(12, Seizoen)
                If aantal > 0 Then
                    kolommen = kolommen & Maakkolommen("J1", aantal)
                End If
                aantal = Uitslagenrepo.Getaantal(13, Seizoen)
                If aantal > 0 Then
                    kolommen = kolommen & Maakkolommen("J2", aantal)
                End If
        End Select

        sql = $"{sql}{kolommen}
            PRIMARY KEY CLUSTERED 
            ([Deelnemerid] ASC
            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
            ) ON [PRIMARY]"
        Uitvoeren(sql)

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

        sql= $"SELECT DISTINCT n.Naamid, n.naam FROM Namen n JOIN Uitslagen u ON n.NaamID = u.IDdeelnemer WHERE n.{serienaam} = 1 AND u.IDseizoen = {Seizoen.ID}"
        Dim dt = Selecteer(sql)

        For Each row As DataRow In dt.Rows
            sql = $"INSERT INTO {tabelnaam} (Deelnemerid)VALUES({row("Naamid")})"
            Uitvoeren(sql)
            Dim aantalX = 0
            Dim totaalgewicht = 0
            Dim totaalaantalvis = 0
            Select Case serie.Id
                Case 1, 2, 3'Senioren
                    aantal = Uitslagenrepo.Getaantal(1, Seizoen)
                    For i = 1 To aantal
                        sql = $"SELECT Kilo FROM Uitslagen WHERE IDseizoen = {Seizoen.ID} AND SerieNaamNr = 1 AND SerieNummerNr = {i} AND IDdeelnemer = {row("Naamid")}"
                        Dim uitslag = Selecteer(sql)
                        If uitslag.Rows.Count = 1 Then
                            Dim kilo = uitslag.Rows(0)
                            sql = $"UPDATE {tabelnaam} SET A_{i}e = {kilo("Kilo")} WHERE Deelnemerid = {row("Naamid")}"
                            Uitvoeren(sql)
                            totaalgewicht += kilo("Kilo")
                            aantalX += 1
                        End If
                    Next
                    aantal = Uitslagenrepo.Getaantal(2, Seizoen)
                    For i = 1 To aantal
                        sql = $"SELECT Kilo FROM Uitslagen WHERE IDseizoen = {Seizoen.ID} AND SerieNaamNr = 2 AND SerieNummerNr = {i} AND IDdeelnemer = {row("Naamid")}"
                        Dim uitslag = Selecteer(sql)
                        If uitslag.Rows.Count = 1 Then
                            Dim kilo = uitslag.Rows(0)
                            sql = $"UPDATE {tabelnaam} SET B_{i}e = {kilo("Kilo")} WHERE Deelnemerid = {row("Naamid")}"
                            Uitvoeren(sql)
                            totaalgewicht += kilo("Kilo")
                            aantalX += 1
                        End If
                    Next
                    aantal = Uitslagenrepo.Getaantal(3, Seizoen)
                    For i = 1 To aantal
                        sql = $"SELECT Kilo FROM Uitslagen WHERE IDseizoen = {Seizoen.ID} AND SerieNaamNr = 3 AND SerieNummerNr = {i} AND IDdeelnemer = {row("Naamid")}"
                        Dim uitslag = Selecteer(sql)
                        If uitslag.Rows.Count = 1 Then
                            Dim kilo = uitslag.Rows(0)
                            sql = $"UPDATE {tabelnaam} SET C_{i}e = {kilo("Kilo")} WHERE Deelnemerid = {row("Naamid")}"
                            Uitvoeren(sql)
                            totaalgewicht += kilo("Kilo")
                            aantalX += 1
                        End If
                    Next
                    sql = $"UPDATE {tabelnaam} SET Totaalgewicht = {totaalgewicht}, X = {aantalX} WHERE Deelnemerid = {row("Naamid")}"
                    Uitvoeren(sql)
                Case 9, 10, 11 'Winter

                Case 12, 13'Jeugd
                    aantal = Uitslagenrepo.Getaantal(12, Seizoen)
                    For i = 1 To aantal
                        sql = $"SELECT Kilo, Pnt FROM Uitslagen WHERE IDseizoen = {Seizoen.ID} AND SerieNaamNr = 12 AND SerieNummerNr = {i} AND IDdeelnemer = {row("Naamid")}"
                        Dim uitslag = Selecteer(sql)
                        If uitslag.Rows.Count = 1 Then
                            Dim kilo = uitslag.Rows(0)
                            sql = $"UPDATE {tabelnaam} SET J1_{i}e = {kilo("Kilo")} WHERE Deelnemerid = {row("Naamid")}"
                            Uitvoeren(sql)
                            totaalgewicht += kilo("Kilo")
                            totaalaantalvis += kilo("Pnt")
                            aantalX += 1
                        End If
                    Next
                    aantal = Uitslagenrepo.Getaantal(13, Seizoen)
                    For i = 1 To aantal
                        sql = $"SELECT Kilo, Pnt FROM Uitslagen WHERE IDseizoen = {Seizoen.ID} AND SerieNaamNr = 13 AND SerieNummerNr = {i} AND IDdeelnemer = {row("Naamid")}"
                        Dim uitslag = Selecteer(sql)
                        If uitslag.Rows.Count = 1 Then
                            Dim kilo = uitslag.Rows(0)
                            sql = $"UPDATE {tabelnaam} SET J2_{i}e = {kilo("Kilo")} WHERE Deelnemerid = {row("Naamid")}"
                            Uitvoeren(sql)
                            totaalgewicht += kilo("Kilo")
                            totaalaantalvis += kilo("Pnt")
                            aantalX += 1
                        End If
                    Next
                    sql = $"UPDATE {tabelnaam} SET Totaalgewicht = {totaalgewicht}, Totaalvis = {totaalaantalvis}, X = {aantalX} WHERE Deelnemerid = {row("Naamid")}"
                    Uitvoeren(sql)
            End Select  
        Next

        Select Case serie.Id
            Case 1, 2, 3'Senioren
                aantal = Uitslagenrepo.Getaantal(1, Seizoen)
            Case 9, 10, 11 'Winter

            Case 12, 13'Jeugd

        End Select

        Fillgrid()

        Enabled = True

    End Sub
    Private Function Maakkolommen(serienaam As String, aantal As long)As String

        Dim kolommen = ""
        For i = 1 To aantal
            kolommen = $"{kolommen} [{serienaam}_{i}e] [float] NULL,"
        Next

        Return kolommen

    End Function
End Class