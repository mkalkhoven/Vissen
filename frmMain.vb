Imports Datalaag
Imports Datalaag.Classes
Imports Datalaag.Global
Imports Vissen.Globaal
Public Class FrmMain
    private _toonalles As Boolean = false
    Private _deelnemer1 As New Namen
    Private _deelnemer2 As New Namen
    Private _uitslag as New Uitslagen
    dim _koppelvissen = new Nachtvissen
    private nachtvis as Nachtvissen' = New Nachtvissen

    dim _datum as New DatumWeerEtc
    Private _seizoen as New Seizoen
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

        _isstarted = True

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
                Case 9, 10, 11
                    vistype = Vistype.Winter
                Case 12, 13
                    vistype = Vistype.Jeugd
                Case 17, 15
                    vistype = Vistype.Koppel
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

        Dim cm As CurrencyManager = BindingContext(dgvnamen.DataSource)
        cm.SuspendBinding()
        dim numbers = ""
        Dim value As Long
        Try
            value = cboNaamserie.SelectedValue
        Catch ex As Exception
            Dim serie As NaamSerie = cboNaamserie.SelectedValue
            value = serie.Id
        End Try

        If value = 15 Or value = 17 Then
            For Each row As DataGridViewRow In dgvUitslagen.Rows

                'Dim tmp As String = row.Cells(0).Value.ToString()

                'Dim id As Long = Long.Parse(row.Cells(1).Value.ToString())
                'Dim nv = Nachtvissenrepo.Get(id)
                'numbers = $"{numbers}#{nv.Deelnemerid1}##{nv.Deelnemerid1}"
                'id = Long.Parse(row.Cells("Deelnemerid2").Value.ToString())
                'nv = Nachtvissenrepo.Get(id)
                'numbers = $"{numbers}#{nv.Deelnemerid1}##{nv.Deelnemerid2}"
            Next
        Else
            numbers = dgvUitslagen.Rows.Cast(Of DataGridViewRow)().Aggregate("", Function(current, row) $"{current}#{row.Cells("NaamID").Value}#")
        End If

        If dgvUitslagen.Rows.Count > 0 Then
            For Each row As DataGridViewRow In dgvnamen.Rows
                Dim id = Selecteerid(row, "Naamid")
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
        txtNaam1.text = ""

        _toonalles = False
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

        Dim id As long = Selecteerid(dgvnamen, "NaamId")
        If (cboNaamserie.SelectedValue = 15 Or cboNaamserie.SelectedValue = 17) And not String.IsNullOrEmpty(txtNaam1.Text) Then
            txtGewicht2.Enabled = True
            txtGewicht2.Text = ""
            dgvUitslagen.ClearSelection()
            If id > 0 Then
                _deelnemer2 = Namenrepo.Getbyoldid(Selecteerid(dgvnamen, "NaamId"))
                If _deelnemer1.Id = _deelnemer2.Id Then
                    Showmessage("U kunt niet dezelfde deelnemer selecteren. Bent u een aap, ofzo..?")
                    Return
                End If
                txtNaam2.Text = _deelnemer2.Naam
                txtGewicht2.Focus()
            End If
        else
            txtGewicht1.Enabled = True
            txtAantal.Enabled = True
            txtGewicht1.Text = ""
            txtGewicht2.Text = ""
            txtAantal.Text = ""
            btnOpslaan.Enabled = False
            dgvUitslagen.ClearSelection()
            If id > 0 Then
                _deelnemer1 = Namenrepo.Getbyoldid(Selecteerid(dgvnamen, "NaamId"))
                txtNaam1.Text = _deelnemer1.Naam
                txtGewicht1.Focus()
            End If
        End If
        
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

        Fillcombo()

    End Sub
    Private Sub CboSerieVolgnummer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboSerieVolgnummer.SelectedIndexChanged 
        Legen()
        If _isstarted = False Then
            Return
        End If

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
                Try
                    _datum = Datumweeretcrepo.Get(f.Datum.ID)
                    Legen()
                    Vuluitslaggrid(_datum)
                Catch ex As Exception
                    _datum = nothing
                End Try
                f.Dispose()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private sub Vuluitslaggrid(datum As DatumWeerEtc)
        
        Vuldetails(datum)
        dgvUitslagen.DataSource = nothing
        If cboNaamserie.SelectedValue = 15 Or cboNaamserie.SelectedValue = 17 Then
            Dim sql = $"SELECT * FROM Nachtvissen WHERE ID = {datum.ID} ORDER BY Gewicht DESC"
            Dim dt = Selecteer(sql)
            Dim koppeluitslag = New List(Of uitslag)
            Dim totaal As long = 0
            Dim plaats = 1
            For Each row As datarow In dt.Rows
                Dim uitslag = New Uitslag With {
                    .Uitslagid = Long.Parse(row("Nachtvisid").ToString()),
                    .Naam = row("Namen"),
                    .Gewicht = long.Parse(row("Gewicht").ToString())
                }
                koppeluitslag.Add(uitslag)
                totaal += Long.Parse(row("Gewicht").ToString())
                plaats += 1
            Next

            Dim totaaluitslag = New Uitslag With {
                .Naam = "      Totaal Gewicht",
                .Gewicht = totaal
            }
            koppeluitslag.Add(totaaluitslag)

            
            dgvUitslagen.DataSource = Maakplaats(koppeluitslag)
            
            dgvUitslagen.Columns(0).Visible = false
            dgvUitslagen.Columns(1).HeaderText = "Pl."
            dgvUitslagen.Columns(1).Width = 50
            dgvUitslagen.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.Middlecenter
            dgvUitslagen.Columns(2).Width = 325
            
            dgvUitslagen.Columns(3).DefaultCellStyle.Format = "N0"
            dgvUitslagen.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            dgvUitslagen.Columns(4).Visible = false
            dgvUitslagen.Columns(5).Visible = false

            Return
        Else 
            Dim uitslagen = Uitslagenrepo.Get(datum)
            dgvUitslagen.DataSource = Maakplaats(uitslagen)
        End If
        dgvUitslagen.Columns(0).Visible = false
        dgvUitslagen.Columns(1).HeaderText = "Pl."
        dgvUitslagen.Columns(1).Width = 50
        dgvUitslagen.Columns(2).Width = 200
        dgvUitslagen.Columns(3).Width = 85
        dgvUitslagen.Columns(4).Width = 80
        dgvUitslagen.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.Middlecenter
        
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
        
        'dim teller = 1
        'For Each row As DataGridViewRow In dgvUitslagen.Rows
        '    If row.Index < dgvUitslagen.Rows.Count -1 Then
        '        row.Cells(1).Value = $"{teller}."
        '        teller +=1
        '    End If
        'Next

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

            Case 15, 17 'Koppelwedstrijden nachtvissen
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

            lblDatumtitel.Text = $"Datum: (id = {datum.ID})"

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


        Dim cm As CurrencyManager = BindingContext(dgvnamen.DataSource)

        Dim numbers = ""
        Dim value As Long
        Try
            value = cboNaamserie.SelectedValue
        Catch ex As Exception
            Dim serie As NaamSerie = cboNaamserie.SelectedValue
            value = serie.Id
        End Try

        If value = 15 Or value = 17 Then
            If dgvUitslagen.Rows.Count <= 1 Then
                Return
            End If
            For Each row As DataGridViewRow In dgvUitslagen.Rows
                Dim id As Long = 0
                Long.TryParse(row.Cells("Uitslagid").Value.ToString(), id)
                If id > 0 Then
                    Dim nv = Nachtvissenrepo.Get(id)
                    If Not IsNothing(nv) Then
                        numbers = $"{numbers}#{nv.Deelnemerid1}##{nv.Deelnemerid2}#"
                    End If
                End If
            Next
        Else
            numbers = dgvUitslagen.Rows.Cast(Of DataGridViewRow)().Aggregate("", Function(current, row) $"{current}#{row.Cells("NaamID").Value}#")
        End If

        If dgvUitslagen.Rows.Count > 0 Then

            For Each row As DataGridViewRow In dgvnamen.Rows
                Dim id = 0
                Try
                    id = Selecteerid(row, "Naamid")
                Catch ex As Exception
                    'Niets
                End Try
                cm.SuspendBinding()
                row.Visible = Not numbers.Contains($"#{id}#")
                cm.ResumeBinding()
            Next
        End If


    End Sub

    Private Sub dgvUitslagen_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUitslagen.CellClick 
        
        If cboNaamserie.SelectedValue = 15 Or cboNaamserie.SelectedValue = 17 Then
            nachtvis = Nachtvissenrepo.Get(Selecteerid(dgvUitslagen, "Uitslagid"))
            _deelnemer1 = Namenrepo.Getbyoldid(nachtvis.Deelnemerid1)
            _deelnemer2 = Namenrepo.Getbyoldid(nachtvis.Deelnemerid2)
            txtNaam1.Text = _deelnemer1.Naam
            txtGewicht1.Text = nachtvis.Gewicht1
            txtGewicht1.Enabled = True
            txtNaam2.Text = _deelnemer2.Naam
            txtGewicht2.Text = nachtvis.Gewicht2
            txtGewicht2.Enabled = True
            Optellen()
            Return
        End If
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
    End sub
    Private sub Opslaan()
        
        _datum = Datumweeretcrepo.Get(Long.Parse(lblDatumid.Text))

        Select Case cboNaamserie.SelectedValue
            Case 1, 2, 3, 5, 6, 9, 10, 11
                'naam en gewicht
                If String.IsNullOrEmpty(txtNaam1.Text) Or String.IsNullOrEmpty(txtGewicht1.Text) Then
                    Toonmelding("Zowel de naam als het gewicht moeten worden ingevuld")
                    Exit Sub
                End If
            Case 15, 17 'Koppel nachtvissen
                'beide namen en beide gewichten

                If String.IsNullOrEmpty(txtNaam1.Text) Or String.IsNullOrEmpty(txtGewicht1.Text) Or String.IsNullOrEmpty(txtNaam2.Text) Or String.IsNullOrEmpty(txtGewicht2.Text) Then
                    Exit Sub
                End If
                If Not String.IsNullOrEmpty(txtNaam1.Text) And Not String.IsNullOrEmpty(txtNaam2.Text) Then
                    If String.IsNullOrEmpty(txtGewicht1.Text) Or String.IsNullOrEmpty(txtGewicht2.Text) Then
                        Toonmelding("Zowel de beide namen, als beide gewichten moeten worden ingevuld")
                    End If
                End If

                'Opslaan in aparte tabel: nachtvissen
                If IsNothing(nachtvis) Then
                    nachtvis = New Nachtvissen With {
                        .Nachtvisid = Nachtvissenrepo.Getid(),
                        .ID = _datum.ID
                    }
                End If
                nachtvis.Deelnemerid1 = _deelnemer1.NaamID
                nachtvis.Gewicht1 = Long.Parse(txtGewicht1.Text)
                nachtvis.Deelnemerid2 = _deelnemer2.NaamID
                nachtvis.Gewicht2 = Long.Parse(txtGewicht2.Text)
                nachtvis.Gewicht = long.Parse(txtGewichtTotaal.Text.replace(".", ""))
                nachtvis.Namen = $"{_deelnemer1.Naam} en {_deelnemer2.Naam}"
                Nachtvissenrepo.Save(Nachtvis)
                Optellen()
                nachtvis = Nothing
            Case 12, 13'Jeugd
                'naam, gewicht en aantal
                If String.IsNullOrEmpty(txtNaam1.Text) Or String.IsNullOrEmpty(txtGewicht1.Text) Or String.IsNullOrEmpty(txtAantal.Text) Then
                    Toonmelding("Zowel de naam, het gewicht en het aantal moeten worden ingevuld")
                    Exit Sub
                End If
        End Select

        If Not String.IsNullOrEmpty(lblUitslagid1.Text) Then
            _uitslag = Uitslagenrepo.Get(Long.Parse(lblUitslagid1.Text))
        Else
            _uitslag = New Uitslagen With {
                .IDdeelnemer = _deelnemer1.NaamID,
                .SerieNaamNr = Integer.Parse(cboNaamserie.SelectedValue),
                .IDdatum = _datum.ID,
                .IDseizoen = _seizoen.ID,
                .SerieNummerNr = Integer.Parse(CboSerieVolgnummer.SelectedValue)
            }
        End If
        If Not String.IsNullOrEmpty(txtGewicht1.Text) Then
            _uitslag.Kilo = Double.Parse(txtGewicht1.Text)
        Else
            _uitslag.Kilo = 0
        end If
        If _uitslag.SerieNaamNr = 12 Or _uitslag.SerieNaamNr = 13 Then
            If Not String.IsNullOrEmpty(txtAantal.Text) Then
                _uitslag.Pnt = Double.Parse(txtAantal.Text)
            End If
        Else
            _uitslag.Pnt = 0
        End If

        Legen()

        Uitslagenrepo.Save(_uitslag)

        If _uitslag.IDdatum = 0 Then
            _uitslag.IDdatum = _uitslag.Uitslagid
            Uitslagenrepo.Save(_uitslag)
        End If

        'txtNaam1.Text = ""
        'txtNaam2.Text = ""
        'txtGewicht1.text = ""
        'txtGewicht1.Enabled = false
        'txtGewicht2.Text = ""
        'txtGewicht2.Enabled = false
        'txtAantal.Text = ""
        'txtAantal.Enabled = false
        btnOpslaan.Enabled = False

        Vuluitslaggrid(_datum)
        Berekenpunten()

    End sub
    Private sub Berekenpunten()
        Dim gedeeldepunten As Double = 0
        Dim bevateennul = false
        Dim gedaan = 0
        Dim punten As double = 1
        dim plaats As Long = 0
        Dim naamserie = Naamserierepo.Get(_datum.SerieNaamNr)
        Dim uitslagen = Uitslagenrepo.Get(_datum)
        Dim klaar = 0
        Dim teller = 0

        While teller < uitslagen.Count - 1
            plaats += 1
            dim uitslag = uitslagen(teller)
            Dim aantal = Uitslagenrepo.Getaantal(_datum, uitslag.Gewicht)
            If aantal = 1 Then
                uitslag.Punten = punten
                Uitslagenrepo.Save(uitslag)
                teller += 1
                If punten <= naamserie.Maxaantal Then
                    punten += 1
                end if
            Else
                gedeeldepunten = 0
                For i = 1 To aantal
                    gedeeldepunten += punten
                    If punten <= naamserie.Maxaantal Then
                        punten += 1
                    end if
                Next
                For i = 1 To aantal
                    uitslag = uitslagen(teller)
                    uitslag.Punten = gedeeldepunten/aantal
                    Uitslagenrepo.Save(uitslag)
                    teller +=1
                Next
            End If
        End While
        
        dgvUitslagen.DataSource = Maakplaats(uitslagen)
        
    End sub

    Private Function Maakplaats(uitslagen As List(Of Uitslag))As List(Of Uitslag)
        
        Dim plaats = 1
        Dim voriggewicht = 0

        For Each uitslag As Uitslag In uitslagen
            If(uitslag.Gewicht <> voriggewicht) Then
                if uitslag.Naam.TrimEnd().ToLower().Contains("totaal") Then
                    Continue For
                End If
                uitslag.Plaats = $"{plaats}."
                voriggewicht = uitslag.Gewicht
            End If
            plaats += 1
        Next

        Return uitslagen

    End Function
    Private Sub btnOpslaan_Click(sender As Object, e As EventArgs) Handles btnOpslaan.Click

        Opslaanvoorbereiden()

    End Sub

    Private Sub Opslaanvoorbereiden()

        Dim nummer = 0
        Dim serie = 0

        gbNaamGewichtEtc.Enabled = False

        Opslaan()
        Legen()

        Try
            If IsNumeric(CboSerieVolgnummer.SelectedValue) Then
                nummer = CboSerieVolgnummer.SelectedValue
            ElseIf IsNothing(CboSerieVolgnummer.SelectedValue) Then
                nummer = 0
            Else
                Dim zoek = ","
                Dim eind = CboSerieVolgnummer.SelectedValue.ToString().LastIndexOf(zoek, StringComparison.Ordinal) - 1
                nummer = Long.Parse(CboSerieVolgnummer.SelectedValue.ToString().Substring(1, eind))
            End If
        Catch ex As Exception
            If Not IsNothing(CboSerieVolgnummer.SelectedValue) Then
                nummer = Long.Parse(CboSerieVolgnummer.SelectedValue.ToString())
            End If
        End Try
        If IsNothing(_seizoen) Or IsNothing(serie) Or IsNothing(nummer = 0) Then
            Return
        End If
        serie = cboNaamserie.SelectedValue

        _datum = Datumweeretcrepo.Get(_seizoen.ID, serie, nummer)
        If Not IsNothing(_datum) Then
            Vuluitslaggrid(_datum)
        End If

        gbNaamGewichtEtc.Enabled = True

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
            Case 15, 17'Koppel, nachtvissen
                'beide namen en beide gewichten
                If String.IsNullOrEmpty(txtNaam1.Text) Or String.IsNullOrEmpty(txtGewicht1.Text) Or String.IsNullOrEmpty(txtNaam2.Text) Or String.IsNullOrEmpty(txtGewicht2.Text) Then
                    'Toonmelding("Zowel de beide namen, als beide gewichten moeten worden ingevuld")
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

        Optellen()
        If e.KeyCode = Keys.Enter Then
            Opslaanvoorbereiden()
        End If

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

            If cboNaamserie.SelectedValue = 15 Or cboNaamserie.SelectedValue = 17 Then
                Nachtvissenrepo.Delete(id)
                Vuluitslaggrid(_datum)
                Return
            End If

            Uitslagenrepo.Delete(id)

            Vuluitslaggrid(_datum)

            Berekenpunten

            _deelnemer1 = Nothing
            lblUitslagid1.Text = ""
            txtNaam1.Text = ""
            txtGewicht1.Text = ""
        End If

        Legen()

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
            'lblMelding.Text = "Het gewicht moet een numeriek, heel getal zijn"
            optellen
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

        If cboNaamserie.SelectedValue = 15 Or cboNaamserie.SelectedValue = 17 Then
            Optellen
        End If

    End Sub
    Private sub Optellen

        Dim totaal As Long

        If IsNumeric(txtGewicht1.Text) Then
            totaal = long.Parse(txtGewicht1.Text)
        end if
        If IsNumeric(txtGewicht2.Text)Then
            totaal += Long.Parse(txtGewicht2.Text)
        End If

        if String.IsNullOrEmpty(txtGewicht1.Text) And String.IsNullOrEmpty(txtGewicht2.Text) Then
            txtGewichtTotaal.Text = ""
        Else 
            txtGewichtTotaal.Text = totaal.ToString("N0")
        End If

        If Not String.IsNullOrEmpty(txtGewicht1.Text) And Not String.IsNullOrEmpty(txtGewicht2.Text) Then
            btnOpslaan.Enabled = True
        else
            btnOpslaan.Enabled = False
        End If

    End sub
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

    Private Sub txtNaam1_Enter(sender As Object, e As EventArgs) Handles txtNaam1.Enter

        txtNaam1.Text = ""
        txtGewicht1.Text = ""
        _deelnemer1 = Nothing
        optellen

    End Sub

    Private Sub txtNaam2_Enter(sender As Object, e As EventArgs) Handles txtNaam2.Enter

        txtNaam2.Text=""
        txtGewicht2.Text=""
        _deelnemer2 = Nothing
        optellen

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim sql = "SELECT DISTINCT Datum FROM Loting2"
        Dim dt = Selecteer(sql)

        For Each row As DataRow In dt.Rows
            Dim datum = row("Datum")
            sql = $"SELECT * FROM Agenda WHERE Datum = {GetISODate(datum)}"
            Dim dtagenda = Selecteeragenda(sql)
            If dtagenda.Rows.Count = 1 Then
                Dim serienummer As String = dtagenda.Rows(0)("Serie").ToString()
                If Not serienummer.Contains(".") Then
                    serienummer = $"{serienummer}."
                End If
                sql = $"UPDATE Loting2 SET Serienummer = '{serienummer}' WHERE Datum = {GetISODate(datum)}"
                Uitvoeren(sql)

            End If
        Next

    End Sub

    Private Sub btnLoting_Click(sender As Object, e As EventArgs) Handles btnLoting.Click

        frmHistorie.ShowDialog()

    End Sub
End Class