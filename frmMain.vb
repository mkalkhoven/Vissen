Imports Datalaag
Imports Datalaag.Classes
Imports Datalaag.Global
Public Class FrmMain
    private _toonalles As Boolean = false
    Private _deelnemer1 As New Namen
    Private _deelnemer2 As New Namen
    Private _uitslag as New Uitslagen
    Private _datum as New DatumWeerEtc
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

        Fillcombo()

        lblDatum.Text = ""
        Legen

        IsStarted = true
        Fillcombo

        Toonvelden()

    End Sub

    Private sub Fillcombo

        If IsStarted = false Then
            Return 
        End If

        Try
            CboSerieVolgnummer.DataSource = nothing
            Dim seizoen = Seizoenrepo.Get(cboSeizoen.SelectedValue)
            Dim serie = Naamserierepo.Get(cboNaamserie.SelectedValue)
            Dim serienaamnummer = Datumweeretcrepo.Get(seizoen, serie)
            Dim lijst As New Dictionary(Of Integer, String)

            For i = 1 To serienaamnummer.Count + 1
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

        dim numbers = ""
        For i = 0 To dgvUitslagen.Rows.Count - 1
            numbers = $"{numbers}#{dgvUitslagen.Rows(i).Cells(4).Value}#"
        Next

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
        If IsStarted = false Then
            return
        End If

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
            cmsMouse.Show(me, new Point(e.X, e.Y))
        End If

    End Sub
    Private Sub dgvnamen_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvnamen.CellClick

        dgvUitslagen.ClearSelection()
        _deelnemer1 = Namenrepo.Get(Selecteerid(dgvnamen, "Id"))
        txtNaam1.Text = _deelnemer1.Naam
        txtGewicht1.Text = ""
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
        
        lblDatumid.Text = ""

        Try
            Dim seizoen = Seizoenrepo.Get(cboSeizoen.SelectedValue)
            Dim serie = Naamserierepo.Get(cboNaamserie.SelectedValue)
            
            If IsNothing(seizoen) Or IsNothing(serie) Or IsNothing(CboSerieVolgnummer.SelectedValue) Then
                Return
            End If

            _datum = Datumweeretcrepo.Get(seizoen, serie, CboSerieVolgnummer.SelectedValue)
            If Not IsNothing(_datum) Then
                Vuluitslaggrid(_datum)
            Else
                _datum = New DatumWeerEtc With {
                    .IDseizoen = seizoen.ID,
                    .IDserieNummer = serie.Id,
                    .SerieNaamNr = CboSerieVolgnummer.SelectedValue
                }
                Dim f As New frmNieuwewedstrijd With {
                    .Datum = _datum
                }
                f.ShowDialog()
                _datum = f.Datum
                f.Dispose()
                Vuluitslaggrid(_datum)
            End If
        Catch ex As Exception

        End Try
        Vulgrid()

    End Sub
    Private sub Vuluitslaggrid(datum As DatumWeerEtc)
        
        Vuldetails(datum)
        Dim uitslagen = Uitslagenrepo.Get(datum)
        dgvUitslagen.DataSource = uitslagen
        dgvUitslagen.Columns(0).Visible = false
        dgvUitslagen.Columns(1).Width = dgvUitslagen.Width - dgvUitslagen.Columns(2).Width - dgvUitslagen.Columns(3).Width
        dgvUitslagen.Columns(2).DefaultCellStyle.Format = "N0"
        dgvUitslagen.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        dgvUitslagen.Columns(4).Visible = false

        dgvUitslagen.Columns(3).DefaultCellStyle.Format = "N1"
        dgvUitslagen.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        if cboNaamserie.Text.ToLower.Contains("jeugd") Then
            dgvUitslagen.Columns(3).DefaultCellStyle.Format = "N0"
            dgvUitslagen.Columns(3).HeaderText = "Aantal"
        ElseIf cboNaamserie.Text.ToLower.Contains("koppelvissen")
            dgvUitslagen.Columns(1).Width = dgvUitslagen.Width = dgvUitslagen.Columns(1).Width = dgvUitslagen.Width + dgvUitslagen.Columns(3).Width
            dgvUitslagen.Columns(3).Visible = False
        ElseIf cboNaamserie.Text.ToLower.Contains("nachtvissen")

        End If
        dgvUitslagen.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter

    End sub
    Private sub Toonvelden()

        'Hier afvangen waar wat ingevuld kan worden
        Select Case cboNaamserie.SelectedValue
            Case 1, 2, 3, 5, 6, 9, 10, 11 'Senioren 50Plus Vrijewedstrijden winter

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
                btnOpslaan.Visible = true		 'Opslaan iedereen uitslag
            'Case 5'Vrijewedstrijden
            '    'vistype = Vistype.Vrijewedstrijden
            'Case 6
            '    'vistype = Vistype.Vijftigplus
                'Case 9, 10, 11
                'vistype = Vistype.Winter

            Case 15 'vistype = Vistype.Koppel
                gbNaamGewichtEtc.Visible=True
                LblNaam1.Visible = true		 'Naam iedereen
                lblAantal.Visible = False	 'Aantal tekst Jeugd
                lblGewicht.Visible = true	 'gewicht tekst iedereen
                txtNaam1.Visible = true	     'Naam iedereen
                txtGewicht1.Visible = true	 'Gewicht iedereen
                txtAantal.Visible = False	 'Aantal vis Jeugd
                txtNaam2.Visible = true		 'Naam2 koppels
                txtGewicht2.Visible = true		 'Gewicht2 koppels
                lblGewichtTotaal.Visible = true 'Gewicht 1+2 koppels tekst
                txtGewichtTotaal.Visible = true 'Gewicht koppels
                btnOpslaan.Visible = true		 'Opslaan iedereen uitslag
            Case 12, 13'Jeugd
                gbNaamGewichtEtc.Visible=True
                LblNaam1.Visible = true		 'Naam iedereen
                lblAantal.Visible = true	 'Aantal tekst Jeugd
                lblGewicht.Visible = true	 'gewicht tekst iedereen
                txtNaam1.Visible = true	     'Naam iedereen
                txtGewicht1.Visible = true	 'Gewicht iedereen
                txtAantal.Visible = true	 'Aantal vis Jeugd
                txtNaam2.Visible = false		 'Naam 2 koppels
                txtGewicht2.Visible = false		 'Gewicht 2 koppels
                lblGewichtTotaal.Visible = false 'Gewicht 1+2 koppels tekst
                txtGewichtTotaal.Visible = false 'Gewicht koppels
                btnOpslaan.Visible = true		 'Opslaan iedereen uitslag
        End Select
        
    End sub
    Private sub Vuldetails(datum As DatumWeerEtc)
        
        
        lblDatumtitel.Visible = true

        lblDatumid.Text = datum.ID
        lblDatum.Text = datum.Datum.Value.ToString("d-MM-yyyy")
        lblVerhaal.Text = datum.Verhaal
        lblLocatieVissen.Text = datum.Plaats
        lblLuchtdrukMB.Text = datum.MB
        lblWeeralgemeen.Text = datum.Weer
        lblWind.Text = datum.Wind
        lblWindsnelheid.Text = datum.WindSnelheid
        lblTemperatuur.Text = $"{datum.Temp} graden"
        
        if lblDatum.Text >"" Then

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


    End sub

    Private Sub dgvUitslagen_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvUitslagen.DataBindingComplete 

        dgvUitslagen.ClearSelection()

    End Sub

    Private Sub dgvUitslagen_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUitslagen.CellClick 

        legen

        dgvnamen.ClearSelection()
        Dim _uitslag = Uitslagenrepo.Get(Selecteerid(dgvUitslagen, "Uitslagid"))
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
        
    End Sub

    Private sub Legen
        'Piet
        lblUitslagid1.Text = ""
        lblUitslagid2.Text = ""
        txtGewicht1.Text = ""
        txtAantal.Text = ""
        txtGewicht2.Text = ""
        txtGewichtTotaal.Text = ""
        lblLocatieVissen.Text = ""
    End sub
    Private sub Opslaan()
        
        Dim datum = Datumweeretcrepo.Get(Long.Parse(lblDatumid.Text))

        Dim naamserie = Naamserierepo.Get(datum.SerieNaamNr)

        If Not String.IsNullOrEmpty(lblUitslagid1.Text) Then
            _uitslag = Uitslagenrepo.Get(Long.Parse(lblUitslagid1.Text))
        Else 
            _uitslag = New Uitslagen With {
                .IDdeelnemer = _deelnemer1.NaamID,
                .SerieNaamNr = cboNaamserie.SelectedValue,
                .IDdatum = datum.ID
                }
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
        End If
        Uitslagenrepo.Save(_uitslag)

        If _uitslag.IDdatum = 0 Then
            _uitslag.IDdatum = _uitslag.Uitslagid
            Uitslagenrepo.Save(_uitslag)
        End If

        If naamserie.Maxaantal > 0 Then
            Dim punten = 0
            Dim overslaan = ""
            Dim uitslagen = Uitslagenrepo.Get(datum)
            For Each uitslag As Uitslag In uitslagen
                If uitslag.Uitslagid > 0 then
                    If punten < naamserie.Maxaantal then
                        punten += 1
                    end if
                    Dim aantal = Uitslagenrepo.getaantal(datum, uitslag.Gewicht)
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
                            Uitslagenrepo.Save(datum, gemiddelde, uitslag.Gewicht)
                            overslaan = $"{overslaan}#{uitslag.Gewicht}#"
                        End If
                    End If
                end if
            Next
        End If
            Vuluitslaggrid(datum)

    End sub
    Private Sub btnOpslaan_Click(sender As Object, e As EventArgs) Handles btnOpslaan.Click  

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
                    Toonmelding("Zowel de naam, het gewicht en het aantal moeten worden ingevuld")
                    'Exit Sub
                End If
        End Select
        
        Return enable

    End Function

    Private Sub txtGewicht1_KeyUp_1(sender As Object, e As KeyEventArgs) Handles txtGewicht1.KeyUp

        btnOpslaan.Enabled = Enableopslaan

    End Sub

    Private Sub txtGewicht2_KeyUp(sender As Object, e As KeyEventArgs) Handles txtGewicht2.KeyUp

    End Sub
End Class