﻿Imports Datalaag
Imports Datalaag.Classes
Imports Datalaag.Global
Public Class FrmMain
    private _toonalles As Boolean = false
    Private _deelnemer1 As New Namen
    Private _deelnemer2 As New Namen
    Private _uitslag as New Uitslagen
    Private _datum as New DatumWeerEtc
    Private _seizoen as New Seizoen
    Private ReadOnly _regelhoogte = 27
    Private _isstarted as Boolean = false
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load 

        Legen()

        Dim seizoenen = Seizoenrepo.Getsorted()
        cboSeizoen.DataSource = seizoenen
        cboSeizoen.ValueMember = "ID"
        cboSeizoen.DisplayMember = "Jaar"

        Dim series = Naamserierepo.Getsorted()
        cboNaamserie.DataSource = series
        cboNaamserie.ValueMember = "Id"
        cboNaamserie.DisplayMember = "Naam"

        lblDatum.Text = ""
        Toonvelden()

    End Sub

    Private sub Fillcombo

        Try
            CboSerieVolgnummer.DataSource = nothing
            Dim seizoen = Seizoenrepo.Get(cboSeizoen.SelectedValue)
            Dim serie = Naamserierepo.Get(cboNaamserie.SelectedValue)

            If IsNothing(serie) Or IsNothing(seizoen) Then
                return
            End If
            
            Dim aantal = Datumweeretcrepo.Getaantal(seizoen.ID, serie.Id)
            Dim lijst As New Dictionary(Of Integer, String)
            For i = 1 To aantal + 1
                lijst.Add(i, $"{i}e.")
            Next

            CboSerieVolgnummer.DataSource = new BindingSource(lijst, nothing)
            CboSerieVolgnummer.DisplayMember = "Value"
            CboSerieVolgnummer.ValueMember = "Key"
        Catch ex As Exception
        End Try

    End sub
    Private function Selecteervistype As Vistype
        
        Dim vistype As Vistype
        Try
            Select Case cboNaamserie.SelectedValue
                Case 1, 2, 3
                    vistype = vistype.Senioren
                Case 5
                    vistype = Vistype.Vrijewedstrijden
                Case 6
                    vistype = Vistype.Vijftigplus
                Case 15
                    vistype = Vistype.Koppel
                Case 9, 10, 11
                    vistype = Vistype.Winter
                Case 12, 13
                    vistype = Vistype.Jeugd
            End Select
            Return vistype
        Catch ex As Exception
            Return Nothing
        End Try

    End function
    Private sub Vulgrid(Optional zoeken As String = "")

        Dim vistype As Vistype

        If _toonalles = true Then
            vistype = Vistype.Toonalles
        Else
            vistype = Selecteervistype
        End If

        Dim namen = Namenrepo.Getsorted(vistype, zoeken)
        dgvnamen.DataSource = namen
        dgvnamen.Columns(1).Visible = false

        dim numbers = dgvUitslagen.Rows.Cast (Of DataGridViewRow)().Aggregate("", Function(current, row) $"{current}#{row.Cells("NaamID").Value}#")

        Dim cm As CurrencyManager = BindingContext(dgvnamen.DataSource)
        cm.SuspendBinding()
        
        If dgvUitslagen.Rows.Count > 0 Then
            For Each row As DataGridViewRow In dgvnamen.Rows
                Dim id = Selecteerid(row, "Naamid")
                Console.WriteLine($"{row.Cells(1).Value} {row.Cells(2).Value}")
                If numbers.Contains($"#{id}#") Then
                    row.Visible = False
                End If
            Next
        End If   
        cm.ResumeBinding()
        Verbergid(dgvnamen)
        Uitvullen(dgvnamen)

        For Each row As DataGridViewRow In dgvnamen.Rows
            row.Height = _regelhoogte
       
        Next

    End sub

    Private Sub dgvnamen_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvnamen.DataBindingComplete 

        dgvnamen.ClearSelection()

    End Sub

    Private Sub btnToonalles_Click(sender As Object, e As EventArgs) Handles btnToonalles.Click 

        If _toonalles = true Then
            _toonalles = false
            btnToonalles.Text = "Toon alles"
            txtZoeken.Text = ""
        Else 
            _toonalles = True
            btnToonalles.Text = "Verberg"
        End If
        Vulgrid()
    End Sub

    Private Sub cboNaamserie_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboNaamserie.SelectedIndexChanged 
        'Piet
        txtNaam1.text = ""

        _toonalles = false
        btnToonalles.Text = "Toon alles"
        Vulgrid()

        Fillcombo()
        txtAantal.Visible = false
        lblAantal.Visible = false

        Toonvelden
        
    End Sub

    Private Sub txtZoeken_KeyUp(sender As Object, e As KeyEventArgs) Handles txtZoeken.KeyUp 

        Vulgrid(txtZoeken.Text)

    End Sub

    Private Sub dgvnamen_MouseUp(sender As Object, e As MouseEventArgs) Handles dgvnamen.MouseUp 

        If e.Button = MouseButtons.Right And _deelnemer1.Id > 0 Then
            cmsMouse.Show(dgvnamen, e.Location)
        End If

    End Sub
    Private Sub dgvnamen_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvnamen.CellClick

        txtGewicht1.Enabled = True
        txtAantal.Enabled = True
        txtGewicht1.Text = ""
        txtGewicht2.Text = ""
        txtAantal.Text = ""
        btnOpslaan.Enabled = False
        dgvUitslagen.ClearSelection()
        _deelnemer1 = Namenrepo.Get(Selecteerid(dgvnamen, "Id"))
        txtNaam1.Text = _deelnemer1.Naam
        txtGewicht1.Focus()

    End Sub

    Private Sub cmsBewerken_Click(sender As Object, e As EventArgs) Handles cmsBewerken.Click 

        If _deelnemer1.Id > 0 Then
            Dim f As New frmNaambewerken With {
                .Naam = _deelnemer1,
                .Owner = Me
            }
            f.ShowDialog()
            _deelnemer1 = f.Naam
            f.Dispose()
            Vulgrid()
            Selecteerregel(_deelnemer1.Id, dgvnamen)

        End If

    End Sub

    Private Sub cmsNieuw_Click(sender As Object, e As EventArgs) Handles cmsNieuw.Click 
        Dim f As New frmNaambewerken With {
            .Owner = Me
        }
        f.ShowDialog()
        _deelnemer1 = f.Naam
        f.Dispose()
        Vulgrid()
        Selecteerregel(_deelnemer1.Id, dgvnamen)

    End Sub
    Private Sub cboSeizoen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSeizoen.SelectedIndexChanged 

        Fillcombo

    End Sub
    Private Sub CboSerieVolgnummer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboSerieVolgnummer.SelectedIndexChanged 
        

        If IsNothing(cboSeizoen.SelectedValue) Or IsNothing(cboNaamserie.SelectedValue) Or IsNothing(CboSerieVolgnummer.SelectedValue) Then
            Return
        End If

        lblDatumid.Text = ""

        Try
            If IsNumeric(cboSeizoen.SelectedValue) Then
                _seizoen = Seizoenrepo.Get(cboSeizoen.SelectedValue)
            Else 
                _seizoen = cboSeizoen.SelectedValue
            End If
            
            Dim serie = Naamserierepo.Get(cboNaamserie.SelectedValue)
            Dim nummer = 0
            Try
                If IsNumeric(CboSerieVolgnummer.SelectedValue) Then
                    nummer = CboSerieVolgnummer.SelectedValue
                ElseIf IsNothing(CboSerieVolgnummer.SelectedValue) Then
                    nummer = 0
                Else 
                    Dim zoek = ","
                    Dim eind = CboSerieVolgnummer.SelectedValue.ToString().LastIndexOf(zoek, StringComparison.Ordinal)-1
                    nummer = long.Parse(CboSerieVolgnummer.SelectedValue.ToString().Substring(1, eind))
                End If
            Catch ex As Exception
                If Not IsNothing(CboSerieVolgnummer.SelectedValue) Then
                    nummer = long.Parse(CboSerieVolgnummer.SelectedValue.ToString())
                end if
            End Try
            If IsNothing(_seizoen) Or IsNothing(serie) Or IsNothing(nummer = 0) Then
                Return
            End If

            _datum = Datumweeretcrepo.Get(_seizoen.ID, serie.Id, nummer)
            If Not IsNothing(_datum) Then
                Vuluitslaggrid(_datum)
            Else
                If IsStarted = false Then
                    Return
                End If
                _datum = New DatumWeerEtc With {
                    .IDseizoen = _seizoen.ID,
                    .IDserieNummer = serie.Id,
                    .SerieNaamNr = nummer
                }
                Dim f As New frmNieuwewedstrijd With {
                    .Datum = _datum,
                    .Serie = serie,
                    .Nummer = nummer,
                    .Seizoen = _seizoen
                }
                f.ShowDialog()
                _datum = Datumweeretcrepo.Get(f.Datum.ID)
                f.Dispose()
                Legen()
                Vuluitslaggrid(_datum)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private sub Vuluitslaggrid(datum As DatumWeerEtc)
        
        'Piet centreren + e

        Vuldetails(datum)
        Dim uitslagen = Uitslagenrepo.Get(datum)
        dgvUitslagen.DataSource = nothing
        dgvUitslagen.DataSource = uitslagen
        dgvUitslagen.Columns(0).Visible = false
        dgvUitslagen.Columns(1).HeaderText = "Pl."
        dgvUitslagen.Columns(1).Width = 50
        dgvUitslagen.Columns(2).Width = 200
        dgvUitslagen.Columns(3).Width = 85
        dgvUitslagen.Columns(4).Width = 80
        dgvUitslagen.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.Middlecenter
        'dgvKlassement.Columns(3).Width = 100 piet2
        
        dgvUitslagen.Columns(2).Width = 250
        dgvUitslagen.Columns(3).DefaultCellStyle.Format = "N0"
        dgvUitslagen.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.Middlecenter
        dgvUitslagen.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        dgvUitslagen.Columns(5).Visible = false

        dgvUitslagen.Columns(4).DefaultCellStyle.Format = "N1"
        dgvUitslagen.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        if cboNaamserie.Text.ToLower.Contains("jeugd") Then
            dgvUitslagen.Columns(4).DefaultCellStyle.Format = "N0"
            dgvUitslagen.Columns(4).HeaderText = "Aantal"
        ElseIf cboNaamserie.Text.ToLower.Contains("koppelvissen")
            dgvUitslagen.Columns(2).Width = dgvUitslagen.Width = dgvUitslagen.Columns(1).Width = dgvUitslagen.Width + dgvUitslagen.Columns(3).Width
            dgvUitslagen.Columns(4).Visible = False
        ElseIf cboNaamserie.Text.ToLower.Contains("nachtvissen")

        End If
        dgvUitslagen.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        
        dim teller = 1
        For Each row As DataGridViewRow In dgvUitslagen.Rows
            row.Height = _regelhoogte
            If row.Index < dgvUitslagen.Rows.Count -1 Then
                row.Cells(1).Value = $"{teller}."
                teller +=1
            End If
        Next

        Vulgrid()
        btnKlassement.Enabled = dgvUitslagen.Rows.Count > 0

        Select Case cboNaamserie.SelectedValue
            Case 1, 2, 3'Koningsvisser
                btnVisser.Text = "Koningsvisser"
                btnVisser.Visible = True
            Case 9, 10, 11'Wintervisser
                btnVisser.Text = "Wintervisser"
                btnVisser.Visible = True
            Case 12, 13'Jeugdvisser
                btnVisser.Text = "Jeugdvisser"
                btnVisser.Visible = True
            Case Else
                btnVisser.Visible = false
        End Select

    End sub
    Private sub Toonvelden()

        'Hier afvangen waar wat ingevuld kan worden
        Dim serie As NaamSerie
        If IsNumeric(cboNaamserie.SelectedValue) Then
            serie = Naamserierepo.Get(cboNaamserie.SelectedValue)
        Else 
            serie = cboNaamserie.SelectedValue
        End If
        
        'Select Case cboNaamserie.SelectedValue
        Select Case serie.Id

            Case 1, 2, 3, 5, 6, 9, 10, 11 'Senioren, 50Plus, Vrijewedstrijden, winter.
                Legen()
                gbNaamGewichtEtc.Visible=True
                LblNaam1.Visible = true		 'Naam iedereen
                lblAantal.Visible = False	 'Aantal tekst Jeugd
                lblGewicht.Visible = true	 'gewicht tekst iedereen
                txtNaam1.Visible = true	     'Naam iedereen
                txtGewicht1.Visible = true	 'Gewicht iedereen
                txtAantal.Visible = False	 'Aantal vis Jeugd
                txtNaam2.Visible = false		 'Naam2 koppels
                txtGewicht2.Visible = False		 'Gewicht2 koppels
                lblGewichtTotaal.Visible = false 'Gewicht 1+2 koppels tekst
                txtGewichtTotaal.Visible = False 'Gewicht koppels
                btnOpslaan.Visible = true
                btnOpslaan.Enabled = False
                btnOpslaan.Location = New Point(421, 41)

            Case 15 'Koppelwedstrijden.
                Legen()
                gbNaamGewichtEtc.Visible=True
                LblNaam1.Visible = true		 'Naam iedereen
                lblAantal.Visible = False	 'Aantal tekst Jeugd
                lblGewicht.Visible = true	 'gewicht tekst iedereen
                txtNaam1.Visible = true	     'Naam iedereen
                txtNaam2.Visible = true		 'Naam2 koppels
                txtGewicht1.Visible = true	 'Gewicht iedereen
                txtGewicht2.Visible = true	 'Gewicht2 koppels
                txtAantal.Visible = False	 'Aantal vis Jeugd
                lblGewichtTotaal.Visible = true 'Gewicht 1+2 koppels tekst
                txtGewichtTotaal.Visible = true 'Gewicht koppels
                btnOpslaan.Visible = true		 'Opslaan iedereen uitslag
                btnOpslaan.Enabled = False
                btnOpslaan.Location = New Point(421, 41)

            Case 12, 13'Jeugd diversen
                Legen()
                gbNaamGewichtEtc.Visible=True
                LblNaam1.Visible = true		 'Naam iedereen
                lblAantal.Visible = true	 'Aantal tekst Jeugd
                txtAantal.Enabled = false
                lblGewicht.Visible = true	 'gewicht tekst iedereen
                txtNaam1.Visible = true	     'Naam iedereen
                txtGewicht1.Visible = true	 'Gewicht iedereen
                txtAantal.Visible = true	 'Aantal vis Jeugd
                txtNaam2.Visible = false		 'Naam 2 koppels
                txtGewicht2.Visible = false		 'Gewicht 2 koppels
                lblGewichtTotaal.Visible = false 'Gewicht 1+2 koppels tekst
                txtGewichtTotaal.Visible = false 'Gewicht koppels
                btnOpslaan.Visible = true		 'Opslaan iedereen uitslag
                btnOpslaan.Enabled = False
                btnOpslaan.Location = New Point(502, 41)

        End Select
        
    End sub
    Private sub Vuldetails(datum As DatumWeerEtc)
        
        If datum.ID > 0 Then
            dgvnamen.Enabled = true
            lblDatumtitel.Visible = true
            txtGewicht1.Enabled = false
            txtGewicht2.Enabled = false
            txtAantal.Enabled = false
            lblDatumid.Text = datum.ID
            lblDatum.Text = datum.Datum.Value.ToString("d-MM-yyyy")
            lblVerhaal.Text = datum.Verhaal
            lblLocatieVissen.Text = datum.Plaats
            lblLuchtdrukMB.Text = datum.MB
            lblWeeralgemeen.Text = datum.Weer
            lblWind.Text = datum.Wind
            lblWindsnelheid.Text = datum.WindSnelheid
            lblTemperatuur.Text = $"{datum.Temp} graden"
            
            if lblDatum.Text <> "" Then
                gpVerhaalEtc.Visible=True
                lblVerhaal.Visible=True
                lblNieuwVerhaal.Visible=True
                btnWijzigverhaal.Visible=True
                gbNaamGewichtEtc.Visible=True
            Else 
                gpVerhaalEtc.Visible=False
                lblVerhaal.Visible=False
                lblNieuwVerhaal.Visible=False
                btnWijzigverhaal.Visible=False
                gbNaamGewichtEtc.Visible=false
            End If
            'Piet
        Else 
            Leegdetails
            btnWijzigverhaal.Visible = false
        end if

    End sub
    Private sub Leegdetails

        lblDatumid.Text = ""
        lblDatum.Text = ""
        lblVerhaal.Text = ""
        lblLocatieVissen.Text = ""
        lblLuchtdrukMB.Text = ""
        lblWeeralgemeen.Text = ""
        lblWind.Text = ""
        lblWindsnelheid.Text = ""
        lblTemperatuur.Text = ""

    End sub
    Private Sub dgvUitslagen_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvUitslagen.DataBindingComplete 

        dgvUitslagen.ClearSelection()

    End Sub

    Private Sub dgvUitslagen_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUitslagen.CellClick 

        legen
        btnOpslaan.Enabled = False
        txtGewicht1.Enabled = True
        txtAantal.Enabled = True

        dgvnamen.ClearSelection()
        Dim _uitslag = Uitslagenrepo.Get(Selecteerid(dgvUitslagen, "Uitslagid"))
        If Not _uitslag  Is nothing Then
            txtGewicht1.Text = _uitslag.Kilo
            lblUitslagid1.Text = _uitslag.Uitslagid

            If _uitslag.SerieNaamNr = 12 Or _uitslag.SerieNaamNr = 13 Then
                txtAantal.Visible = True
                txtAantal.Text = _uitslag.Pnt
            Else 
                txtAantal.Text = ""
                txtAantal.Visible = False
            End If
            
            _deelnemer1 = Namenrepo.Getbyoldid(_uitslag.IDdeelnemer)
            txtNaam1.Text = _deelnemer1.Naam

            txtGewicht1.Focus()
        End If
    End Sub
    Private sub Legen
        'Piet
        lblUitslagid1.Text = ""
        lblUitslagid2.Text = ""
        txtGewicht1.Text = ""
        txtAantal.Text = ""
        txtGewicht2.Text = ""
        txtGewichtTotaal.Text = ""
        txtNaam1.Text = ""
        txtNaam2.Text = ""
        lblLocatieVissen.Text = ""
        lblMelding.Text = ""
        'If lblVerhaal.Text = "" Then
        '    dgvnamen.Enabled = False
        '    Else 
        '        dgvnamen.Enabled = True
        'End If
    End sub
    Private sub Opslaan()
        
        Select Case cboNaamserie.SelectedValue
            Case 1, 2, 3, 5, 6, 9, 10, 11
                'naam en gewicht
                If String.IsNullOrEmpty(txtNaam1.Text) Or String.IsNullOrEmpty(txtGewicht1.Text) Then
                    Toonmelding("Zowel de naam als het gewicht moeten worden ingevuld")
                    Exit Sub
                End If
            Case 15'Koppel
                'beide namen en beide gewichten
                If String.IsNullOrEmpty(txtNaam1.Text) Or String.IsNullOrEmpty(txtGewicht1.Text) Or String.IsNullOrEmpty(txtNaam2.Text) Or String.IsNullOrEmpty(txtGewicht2.Text) Then
                    Toonmelding("Zowel de beide namen, als beide gewichten moeten worden ingevuld")
                    Exit Sub
                End If
            Case 12, 13'Jeugd
                'naam, gewicht en aantal
                If String.IsNullOrEmpty(txtNaam1.Text) Or String.IsNullOrEmpty(txtGewicht1.Text) Or String.IsNullOrEmpty(txtAantal.Text) Then
                    Toonmelding("Zowel de naam, het gewicht en het aantal moeten worden ingevuld")
                    Exit Sub
                End If
        End Select

        _datum = Datumweeretcrepo.Get(Long.Parse(lblDatumid.Text))

        If Not String.IsNullOrEmpty(lblUitslagid1.Text) Then
            _uitslag = Uitslagenrepo.Get(Long.Parse(lblUitslagid1.Text))
        Else 
            _uitslag = New Uitslagen()
            _uitslag.IDdeelnemer = _deelnemer1.NaamID
            _uitslag.SerieNaamNr = Integer.Parse(cboNaamserie.SelectedValue)
            _uitslag.IDdatum = _datum.ID
            _uitslag.IDseizoen = _seizoen.ID
            _uitslag.SerieNummerNr = Integer.Parse(CboSerieVolgnummer.SelectedValue)
        End If
        If Not String.IsNullOrEmpty(txtGewicht1.Text) Then
            _uitslag.Kilo = Double.Parse(txtGewicht1.Text)
        Else
            _uitslag.Kilo = 0
        end if
        If _uitslag.SerieNaamNr = 12 Or _uitslag.SerieNaamNr = 13 Then
            If Not String.IsNullOrEmpty(txtAantal.Text) Then
                _uitslag.Pnt = double.Parse(txtAantal.Text)
            End If
        Else 
            _uitslag.Pnt = 0
        End If
        Uitslagenrepo.Save(_uitslag)

        If _uitslag.IDdatum = 0 Then
            _uitslag.IDdatum = _uitslag.Uitslagid
            Uitslagenrepo.Save(_uitslag)
        End If

        Berekenpunten
        txtNaam1.Text = ""
        txtNaam2.Text = ""
        txtGewicht1.text = ""
        txtGewicht1.Enabled = false
        txtGewicht2.Text = ""
        txtGewicht2.Enabled = false
        txtAantal.Text = ""
        txtAantal.Enabled = false
        btnOpslaan.Enabled = false

        Vuluitslaggrid(_datum)
        'Vulgrid()

    End sub

    Private sub Berekenpunten()
        
        Dim naamserie = Naamserierepo.Get(_datum.SerieNaamNr)

        If naamserie.Maxaantal > 0 Then
            Dim punten = 0
            Dim overslaan = ""
            Dim uitslagen = Uitslagenrepo.Get(_datum)
            For Each uitslag As Uitslag In uitslagen
                If uitslag.Uitslagid > 0 then
                    If punten < naamserie.Maxaantal then
                        punten += 1
                    end if
                    Dim aantal = Uitslagenrepo.Getaantal(_datum, uitslag.Gewicht)
                    If aantal = 1 Then 'Tenzij deze als is geupdate met gemiddelde
                        uitslag.Punten = punten
                        Uitslagenrepo.Save(uitslag)
                    ElseIf uitslag.Gewicht = 0 Then
                        uitslag.Punten = punten
                        Uitslagenrepo.Save(uitslag)
                    Else
                        If overslaan.Contains(uitslag.Gewicht) Then
                            'Niets
                        Else 
                            Dim gedeeldepunten As Double = 0
                            For i = 1 To aantal
                                gedeeldepunten += punten
                                If punten < naamserie.Maxaantal then
                                    punten += 1
                                end if
                            Next
                            punten -= aantal
                            dim gemiddelde = gedeeldepunten / aantal
                            Uitslagenrepo.Save(_datum, gemiddelde, uitslag.Gewicht)
                            overslaan = $"{overslaan}#{uitslag.Gewicht}#"
                        End If
                    End If
                end if
            Next
        End If

    End sub
    Private Sub btnOpslaan_Click(sender As Object, e As EventArgs) Handles btnOpslaan.Click  
        
        Opslaan

    End Sub
    Private Sub btnWijzigverhaal_Click(sender As Object, e As EventArgs) Handles btnWijzigverhaal.Click
        Dim f As New FrmNieuwewedstrijd With {
            .Datum = _datum
        }
        f.ShowDialog()
        _datum = f.Datum
        Vuldetails(_datum)

    End Sub

    Private Function Enableopslaan()

        Dim enable As Boolean

        Select Case cboNaamserie.SelectedValue
            Case 1, 2, 3, 5, 6, 9, 10, 11
                'naam en gewicht
                If not String.IsNullOrEmpty(txtNaam1.Text) and Not String.IsNullOrEmpty(txtGewicht1.Text) Then
                    enable = True
                End If
            Case 15'Koppel
                'beide namen en beide gewichten
                If String.IsNullOrEmpty(txtNaam1.Text) Or String.IsNullOrEmpty(txtGewicht1.Text) Or String.IsNullOrEmpty(txtNaam2.Text) Or String.IsNullOrEmpty(txtGewicht2.Text) Then
                    Toonmelding("Zowel de beide namen, als beide gewichten moeten worden ingevuld")
                    'Exit Sub
                End If
            Case 12, 13'Jeugd
                'naam, gewicht en aantal
                If String.IsNullOrEmpty(txtNaam1.Text) Or String.IsNullOrEmpty(txtGewicht1.Text) Or String.IsNullOrEmpty(txtAantal.Text) Then
                    'Toonmelding("Zowel de naam, het gewicht en het aantal moeten worden ingevuld")
                    'Exit Sub
                    enable = false
                Else 
                    enable = true
                End If
        End Select
        
        Return enable

    End Function

    Private Sub txtGewicht2_KeyUp(sender As Object, e As KeyEventArgs) Handles txtGewicht2.KeyUp

    End Sub

    Private Sub dgvUitslagen_MouseUp(sender As Object, e As MouseEventArgs) Handles dgvUitslagen.MouseUp

        select Case e.Button
            Case MouseButtons.Left
            Case MouseButtons.Right
            If e.Button = MouseButtons.Right And _deelnemer1.Id > 0 Then
                cmsUitslag.Show(dgvUitslagen, e.Location)
            End If
        End Select

    End Sub

    Private Sub VerwijderenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerwijderenToolStripMenuItem.Click

        If MessageBox.Show("Wilt u de geselecteerde naam verwijderen", "Verwijderen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim id = Selecteerid(dgvUitslagen, "Uitslagid")
            Uitslagenrepo.Delete(id)

            Berekenpunten

            Vuluitslaggrid(_datum)

            _deelnemer1 = Nothing
            lblUitslagid1.Text = ""
            txtNaam1.Text = ""
            txtGewicht1.Text = ""
        End If

    End Sub

    Private Sub txtAantal_KeyUp(sender As Object, e As KeyEventArgs) Handles txtAantal.KeyUp

        If Not IsNumeric(txtAantal.Text) Then
            txtAantal.Text = ""
            lblMelding.Text = "Het aantal moet een numeriek, heel getal zijn"
            txtAantal.Focus()
            Return
        End If
        lblMelding.Text = ""
        btnOpslaan.Enabled = Enableopslaan
        If e.KeyCode = Keys.Enter and Enableopslaan Then
            Opslaan
        end if

    End Sub

    Private Sub txtGewicht1_KeyUp(sender As Object, e As KeyEventArgs) Handles txtGewicht1.KeyUp

        If Not IsNumeric(txtGewicht1.Text) Then
            txtGewicht1.Text = ""
            lblMelding.Text = "Het gewicht moet een numeriek, heel getal zijn"
            txtGewicht1.Focus()
            Return
        End If
        lblMelding.Text = ""
        btnOpslaan.Enabled = Enableopslaan
        if e.KeyCode = keys.Enter Then
            If cboNaamserie.SelectedValue = 12 Or cboNaamserie.SelectedValue = 13 Then
                txtAantal.Focus()
            Else 
                Opslaan()
            End If
        End If

    End Sub

    Private Sub btnKlassement_Click(sender As Object, e As EventArgs) Handles btnKlassement.Click
        Dim f As New frmklassement With {
            .Seizoen = Seizoenrepo.Get(cboSeizoen.SelectedValue),
            .Serie = Naamserierepo.Get(cboNaamserie.SelectedValue)
        }
        f.ShowDialog()

    End Sub

    Private Sub btnVisser_Click(sender As Object, e As EventArgs) Handles btnVisser.Click
        
        Dim f As New frmVisser With {
                .Seizoen = Seizoenrepo.Get(cboSeizoen.SelectedValue),
                .Serie = Naamserierepo.Get(cboNaamserie.SelectedValue)
                }
        f.ShowDialog()

    End Sub

    Private Sub FrmMain_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        if CboSerieVolgnummer.Items.Count = 0 Then
            Fillcombo
        End If
        IsStarted = true

    End Sub
End Class