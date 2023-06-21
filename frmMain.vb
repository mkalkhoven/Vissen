Imports System.IO
Imports System.Net
Imports Datalaag
Imports Datalaag.Classes
Imports Datalaag.Global
Public Class frmMain
    Private klaarmetladen As Boolean = False
    Private _toonalles As Boolean = False
    Private _deelnemer1 As New Namen
    Private _deelnemer2 As New Namen
    Private _uitslag As New Uitslagen
    Dim _koppelvissen = New Nachtvissen
    Dim _serie As New Serie
    Private nachtvis As Nachtvissen ' = New Nachtvissen

    Dim _datum As New DatumWeerEtc
    Private _seizoen As New Seizoen
    Private _isstarted As Boolean = False

    Private Sub Vulseizoencombo()

        Dim seizoenen = Seizoenrepo.Getsorted()
        Dim seizoennaam = seizoenen.First
        Dim seizoen = New Seizoen With {
            .Jaar = "Nieuw seizoen",
            .ID = 0
        }
        seizoenen.Insert(0, seizoen)
        cboSeizoen.DataSource = seizoenen
        cboSeizoen.ValueMember = "ID"
        cboSeizoen.DisplayMember = "Jaar"
        cboSeizoen.Text = seizoennaam.Jaar

        Dim series = Naamserierepo.Getsorted()
        cboNaamserie.DataSource = series
        cboNaamserie.ValueMember = "Id"
        cboNaamserie.DisplayMember = "Naam"

    End Sub
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Legen()

        Vulseizoencombo()

        lblDatum.Text = ""
        Toonvelden()

        klaarmetladen = True

    End Sub

    Private Sub Fillcombo()

        If klaarmetladen = False Then
            Return
        End If
        If cboSeizoen.Text = "Nieuw seizoen" Then
            klaarmetladen = False
            Nieuwseizoenform.ShowDialog()
            Vulseizoencombo()
            klaarmetladen = True
            Return
        End If


        Try
            CboSerieVolgnummer.DataSource = Nothing
            Dim seizoen = Seizoenrepo.Get(cboSeizoen.SelectedValue)
            Dim serie = Naamserierepo.Get(cboNaamserie.SelectedValue)

            If IsNothing(serie) Or IsNothing(seizoen) Then
                Return
            End If

            Dim aantal = Datumweeretcrepo.Getaantal(seizoen.ID, serie.Id)
            Dim lijst As New Dictionary(Of Integer, String)
            For i = 1 To aantal + 1
                lijst.Add(i, $"{i}e.")
            Next

            CboSerieVolgnummer.DataSource = New BindingSource(lijst, Nothing)
            CboSerieVolgnummer.DisplayMember = "Value"
            CboSerieVolgnummer.ValueMember = "Key"
        Catch ex As Exception
        End Try

        _isstarted = True

    End Sub
    Private Function Selecteervistype() As Vistype

        Dim vistype As Vistype
        Try
            Select Case cboNaamserie.SelectedValue
                Case 1, 2, 3
                    vistype = Vistype.Senioren
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

    End Function
    Private Sub Vulgrid(Optional zoeken As String = "")

        Dim vistype As Vistype

        If _toonalles = True Then
            vistype = Vistype.Toonalles
        Else
            vistype = Selecteervistype()
        End If

        Dim namen = Namenrepo.Getsorted(vistype, zoeken)
        dgvnamen.DataSource = namen
        dgvnamen.Columns(1).Visible = False

        Dim cm As CurrencyManager = BindingContext(dgvnamen.DataSource)
        cm.SuspendBinding()
        Dim numbers = ""
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

    End Sub

    Private Sub dgvnamen_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvnamen.DataBindingComplete

        dgvnamen.ClearSelection()

    End Sub

    Private Sub btnToonalles_Click(sender As Object, e As EventArgs) Handles btnToonalles.Click

        If _toonalles = True Then
            _toonalles = False
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
        txtNaam1.Text = ""

        _toonalles = False
        btnToonalles.Text = "Toon alles"



        Vulgrid()

        Fillcombo()
        txtAantal.Visible = False
        lblAantal.Visible = False

        Toonvelden()

    End Sub

    Private Sub txtZoeken_KeyUp(sender As Object, e As KeyEventArgs) Handles txtZoeken.KeyUp

        Vulgrid(txtZoeken.Text)

    End Sub

    Private Sub dgvnamen_MouseUp(sender As Object, e As MouseEventArgs) Handles dgvnamen.MouseUp
        Try
            If e.Button = MouseButtons.Right And _deelnemer1.Id > 0 Then
                cmsMouse.Show(dgvnamen, e.Location)
            End If
        Catch ex As Exception

        End Try


    End Sub
    Private Sub dgvnamen_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvnamen.CellClick

        Dim id As Long = Selecteerid(dgvnamen, "NaamId")

        If id = 0 Then
            Return
        End If

        If (cboNaamserie.SelectedValue = 15 Or cboNaamserie.SelectedValue = 17) And Not String.IsNullOrEmpty(txtNaam1.Text) Then
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
        Else
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
            Dim f As New FrmNaambewerken With {
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
        Dim f As New FrmNaambewerken With {
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

            _datum = Datumweeretcrepo.Get(_seizoen.ID, serie.Id, nummer)
            If Not IsNothing(_datum) Then
                Vuluitslaggrid(_datum)
            Else
                If IsStarted = False Then
                    Return
                End If
                _datum = New DatumWeerEtc With {
                    .IDseizoen = _seizoen.ID,
                    .IDserieNummer = serie.Id,
                    .SerieNaamNr = nummer
                }
                Dim f As New FrmNieuwewedstrijd With {
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
                    _datum = Nothing
                End Try
                f.Dispose()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Vuluitslaggrid(datum As DatumWeerEtc)

        Vuldetails(datum)
        dgvUitslagen.DataSource = Nothing
        If cboNaamserie.SelectedValue = 15 Or cboNaamserie.SelectedValue = 17 Then
            Dim sql = $"SELECT * FROM Nachtvissen WHERE ID = {datum.ID} ORDER BY Gewicht DESC, Hoogstegewicht DESC"
            Dim dt = ModDatabase.Selecteer(sql)
            Dim koppeluitslag = New List(Of Uitslag)
            Dim totaal As Long = 0
            Dim plaats = 1
            For Each row As DataRow In dt.Rows
                Dim uitslag = New Uitslag With {
                    .Uitslagid = Long.Parse(row("Nachtvisid").ToString()),
                    .Naam = row("Namen"),
                    .Gewicht = Long.Parse(row("Gewicht").ToString())
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

            dgvUitslagen.Columns(0).Visible = False
            dgvUitslagen.Columns(1).HeaderText = "Pl."
            dgvUitslagen.Columns(1).Width = 50
            dgvUitslagen.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvUitslagen.Columns(2).Width = 325

            dgvUitslagen.Columns(3).DefaultCellStyle.Format = "N0"
            dgvUitslagen.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            dgvUitslagen.Columns(4).Visible = False
            dgvUitslagen.Columns(5).Visible = False

            Return
        Else
            Dim uitslagen = Uitslagenrepo.Get(datum)
            dgvUitslagen.DataSource = Maakplaats(uitslagen)
        End If
        dgvUitslagen.Columns(0).Visible = False
        dgvUitslagen.Columns(1).HeaderText = "Pl."
        dgvUitslagen.Columns(1).Width = 50
        dgvUitslagen.Columns(2).Width = 200
        dgvUitslagen.Columns(3).Width = 85
        dgvUitslagen.Columns(4).Width = 80
        dgvUitslagen.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        dgvUitslagen.Columns(2).Width = 250
        dgvUitslagen.Columns(3).DefaultCellStyle.Format = "N0"
        dgvUitslagen.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvUitslagen.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        dgvUitslagen.Columns(5).Visible = False

        dgvUitslagen.Columns(4).DefaultCellStyle.Format = "N1"
        dgvUitslagen.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        If cboNaamserie.Text.ToLower.Contains("jeugd") Then
            dgvUitslagen.Columns(4).DefaultCellStyle.Format = "N0"
            dgvUitslagen.Columns(4).HeaderText = "Aantal"
        ElseIf cboNaamserie.Text.ToLower.Contains("koppelvissen") Then
            dgvUitslagen.Columns(2).Width = dgvUitslagen.Width = dgvUitslagen.Columns(1).Width = dgvUitslagen.Width + dgvUitslagen.Columns(3).Width
            dgvUitslagen.Columns(4).Visible = False
        ElseIf cboNaamserie.Text.ToLower.Contains("nachtvissen") Then

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
            Case 1, 2, 3 'Koningsvisser
                btnVisser.Text = "Koningsvisser"
                btnVisser.Visible = True
            Case 9, 10, 11 'Wintervisser
                btnVisser.Text = "Wintervisser"
                btnVisser.Visible = True
            Case 12, 13 'Jeugdvisser
                btnVisser.Text = "Jeugdvisser"
                btnVisser.Visible = True
            Case Else
                btnVisser.Visible = False
        End Select

    End Sub
    Private Sub Toonvelden()

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
                gbNaamGewichtEtc.Visible = True
                LblNaam1.Visible = True      'Naam iedereen
                lblAantal.Visible = False    'Aantal tekst Jeugd
                lblGewicht.Visible = True    'gewicht tekst iedereen
                txtNaam1.Visible = True      'Naam iedereen
                txtGewicht1.Visible = True   'Gewicht iedereen
                txtAantal.Visible = False    'Aantal vis Jeugd
                txtNaam2.Visible = False         'Naam2 koppels
                txtGewicht2.Visible = False      'Gewicht2 koppels
                lblGewichtTotaal.Visible = False 'Gewicht 1+2 koppels tekst
                txtGewichtTotaal.Visible = False 'Gewicht koppels
                btnOpslaan.Visible = True
                btnOpslaan.Enabled = False
                btnOpslaan.Location = New Point(421, 41)

            Case 15, 17 'Koppelwedstrijden nachtvissen
                Legen()
                gbNaamGewichtEtc.Visible = True
                LblNaam1.Visible = True      'Naam iedereen
                lblAantal.Visible = False    'Aantal tekst Jeugd
                lblGewicht.Visible = True    'gewicht tekst iedereen
                txtNaam1.Visible = True      'Naam iedereen
                txtNaam2.Visible = True      'Naam2 koppels
                txtGewicht1.Visible = True   'Gewicht iedereen
                txtGewicht2.Visible = True   'Gewicht2 koppels
                txtAantal.Visible = False    'Aantal vis Jeugd
                lblGewichtTotaal.Visible = True 'Gewicht 1+2 koppels tekst
                txtGewichtTotaal.Visible = True 'Gewicht koppels
                btnOpslaan.Visible = True        'Opslaan iedereen uitslag
                btnOpslaan.Enabled = False
                btnOpslaan.Location = New Point(421, 41)

            Case 12, 13 'Jeugd diversen
                Legen()
                gbNaamGewichtEtc.Visible = True
                LblNaam1.Visible = True      'Naam iedereen
                lblAantal.Visible = True     'Aantal tekst Jeugd
                txtAantal.Enabled = False
                lblGewicht.Visible = True    'gewicht tekst iedereen
                txtNaam1.Visible = True      'Naam iedereen
                txtGewicht1.Visible = True   'Gewicht iedereen
                txtAantal.Visible = True     'Aantal vis Jeugd
                txtNaam2.Visible = False         'Naam 2 koppels
                txtGewicht2.Visible = False      'Gewicht 2 koppels
                lblGewichtTotaal.Visible = False 'Gewicht 1+2 koppels tekst
                txtGewichtTotaal.Visible = False 'Gewicht koppels
                btnOpslaan.Visible = True        'Opslaan iedereen uitslag
                btnOpslaan.Enabled = False
                btnOpslaan.Location = New Point(502, 41)

        End Select

    End Sub
    Private Sub Vuldetails(datum As DatumWeerEtc)

        If datum.ID > 0 Then
            panfoto.Visible = True
            lblSleep.Visible = True
            dgvnamen.Enabled = True
            lblDatumtitel.Visible = True
            txtGewicht1.Enabled = False
            txtGewicht2.Enabled = False
            txtAantal.Enabled = True
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

            If lblDatum.Text <> "" Then
                gpVerhaalEtc.Visible = True
                lblVerhaal.Visible = True
                lblNieuwVerhaal.Visible = True
                btnWijzigverhaal.Visible = True
                btnVerwijderwedstrijd.Visible = True
                gbNaamGewichtEtc.Visible = True
            Else
                gpVerhaalEtc.Visible = False
                lblVerhaal.Visible = False
                lblNieuwVerhaal.Visible = False
                btnWijzigverhaal.Visible = False
                btnVerwijderwedstrijd.Visible = False
                gbNaamGewichtEtc.Visible = False
            End If
            If Not IsNothing(datum.Afbeelding) then
                picfoto.ImageLocation = $"https://www.deruisvoornacquoy.nl/Afbeeldingen/{datum.Afbeelding}"
                btnfotowissen.Visible = True
            Else
                btnfotowissen.Visible = False
            End If
        Else
            Leegdetails()
            btnWijzigverhaal.Visible = False
            btnVerwijderwedstrijd.Visible = False
            btnfotowissen.Visible = False
        End If
        panfoto.Visible = true

    End Sub
    Private Sub Leegdetails()

        lblDatumid.Text = ""
        lblDatumtitel.Text = "Datum:"
        lblDatum.Text = ""
        lblVerhaal.Text = ""
        lblLocatieVissen.Text = ""
        lblLuchtdrukMB.Text = ""
        lblWeeralgemeen.Text = ""
        lblWind.Text = ""
        lblWindsnelheid.Text = ""
        lblTemperatuur.Text = ""
        picfoto.Image = Nothing
        btnfotoopslaan.Visible = False
        btnfotowissen.Visible = False
        btnWijzigverhaal.Visible = False
        btnVerwijderwedstrijd.Visible = False
        dgvUitslagen.DataSource = Nothing

    End Sub
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
    Private Sub Legen()
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
        picfoto.Image = Nothing
        btnfotoopslaan.Visible = False

    End Sub
    Private Sub Opslaan()

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

                If nachtvis.Gewicht1 >= nachtvis.Gewicht2 Then
                    nachtvis.Hoogstegewicht = nachtvis.Gewicht1
                Else
                    nachtvis.Hoogstegewicht = nachtvis.Gewicht2
                End If

                nachtvis.Gewicht = Long.Parse(txtGewichtTotaal.Text.Replace(".", ""))

                'If _deelnemer1.Naam.ToLower().Contains("geen partner") Or _deelnemer2.Naam.ToLower().Contains("geen partner") Then
                '    If _deelnemer1.Naam.ToLower().Contains("geen partner") Then
                '        nachtvis.Namen = $"{_deelnemer2.Naam} (geen partner)"
                '    Else
                '        nachtvis.Namen = $"{_deelnemer1.Naam} (geen partner)"
                '    End If
                'Else
                '    nachtvis.Namen = $"{_deelnemer1.Naam} en {_deelnemer2.Naam}"
                'End If
                nachtvis.Namen = $"{_deelnemer1.Naam} en {_deelnemer2.Naam}"

                Nachtvissenrepo.Save(nachtvis)
                Vuluitslaggrid(_datum)
                Optellen()
                nachtvis = Nothing
                Return
            Case 12, 13 'Jeugd
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
        End If
        If _uitslag.SerieNaamNr = 12 Or _uitslag.SerieNaamNr = 13 Then
            If Not String.IsNullOrEmpty(txtAantal.Text) Then
                _uitslag.Pnt = Double.Parse(txtAantal.Text)
            End If
        Else
            _uitslag.Pnt = 0
        End If

        Legen()

        'Uitslagenrepo.Save(_uitslag)

        If _uitslag.IDdatum = 0 Then
            _uitslag.IDdatum = _uitslag.Uitslagid
        End If
        Uitslagenrepo.Save(_uitslag)

        btnOpslaan.Enabled = False

        Vuluitslaggrid(_datum)
        Berekenpunten()

    End Sub
    Private Sub Berekenpunten()


        Dim punten As Double = 1
        Dim plaats As Long = 0
        Dim naamserie = Naamserierepo.Get(_datum.SerieNaamNr)
        Dim uitslagen = Uitslagenrepo.Get(_datum)
        Dim teller = 0

        If _datum.SerieNaamNr = 12 Or _datum.SerieNaamNr = 13 Then
            Return
        End If

        While teller < uitslagen.Count - 1
            plaats += 1
            Dim uitslag = uitslagen(teller)
            Dim aantal = Uitslagenrepo.Getaantal(_datum, uitslag.Gewicht)
            If aantal = 1 Then
                uitslag.Punten = punten
                Uitslagenrepo.Save(uitslag)
                teller += 1
                If punten < naamserie.Maxaantal Then
                    punten += 1
                Else
                    punten = naamserie.Maxaantal
                End If
            Else
                Dim gedeeldepunten As Double = 0
                For i = 1 To aantal
                    gedeeldepunten += punten
                    If punten < naamserie.Maxaantal Then
                        punten += 1
                    Else
                        punten = naamserie.Maxaantal
                    End If
                Next
                For i = 1 To aantal
                    uitslag = uitslagen(teller)
                    uitslag.Punten = gedeeldepunten / aantal
                    Uitslagenrepo.Save(uitslag)
                    teller += 1
                Next
            End If
        End While

        dgvUitslagen.DataSource = Maakplaats(uitslagen)

    End Sub

    Private Function Maakplaats(uitslagen As List(Of Uitslag)) As List(Of Uitslag)

        Dim plaats = 1
        Dim voriggewicht = 0

        For Each uitslag As Uitslag In uitslagen
            If (uitslag.Gewicht <> voriggewicht) Then
                If uitslag.Naam.TrimEnd().ToLower().Contains("totaal") Then
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
            .Datum = _datum,
            .Seizoen = _seizoen,
            .Serie = Naamserierepo.Get(_datum.SerieNaamNr)
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
                If Not String.IsNullOrEmpty(txtNaam1.Text) And Not String.IsNullOrEmpty(txtGewicht1.Text) Then
                    enable = True
                End If
            Case 15, 17 'Koppel, nachtvissen
                'beide namen en beide gewichten
                If String.IsNullOrEmpty(txtNaam1.Text) Or String.IsNullOrEmpty(txtGewicht1.Text) Or String.IsNullOrEmpty(txtNaam2.Text) Or String.IsNullOrEmpty(txtGewicht2.Text) Then
                    'Toonmelding("Zowel de beide namen, als beide gewichten moeten worden ingevuld")
                    'Exit Sub
                End If
            Case 12, 13 'Jeugd
                'naam, gewicht en aantal
                If String.IsNullOrEmpty(txtNaam1.Text) Or String.IsNullOrEmpty(txtGewicht1.Text) Or String.IsNullOrEmpty(txtAantal.Text) Then
                    'Toonmelding("Zowel de naam, het gewicht en het aantal moeten worden ingevuld")
                    'Exit Sub
                    enable = False
                Else
                    enable = True
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

        Select Case e.Button
            Case MouseButtons.Left
            Case MouseButtons.Right
                If e.Button = MouseButtons.Right And _deelnemer1.Id > 0 Then
                    cmsUitslag.Show(dgvUitslagen, e.Location)
                End If
        End Select

    End Sub

    Private Sub VerwijderenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerwijderenToolStripMenuItem.Click

        Dim id = Selecteerid(dgvUitslagen, "Uitslagid")

        If id = 0 Then
            Return
        End If

        If MessageBox.Show("Wilt u de geselecteerde naam verwijderen", "Verwijderen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If cboNaamserie.SelectedValue = 15 Or cboNaamserie.SelectedValue = 17 Then
                Nachtvissenrepo.Delete(id)
            Else
                Uitslagenrepo.Delete(id)
            End If
            _deelnemer1 = Nothing
            _deelnemer2 = Nothing
            Vuluitslaggrid(_datum)
            Berekenpunten()
            lblUitslagid1.Text = ""
            txtNaam1.Text = ""
            txtGewicht1.Text = ""
            txtNaam2.Text = ""
            txtGewicht2.Text = ""

            Vuluitslaggrid(_datum)

            dgvUitslagen.ClearSelection()
            dgvnamen.ClearSelection()
            Legen()        
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
        btnOpslaan.Enabled = Enableopslaan()

        If e.KeyCode = Keys.Enter And Enableopslaan() Then
            Opslaan()
        End If

    End Sub

    Private Sub txtGewicht1_KeyUp(sender As Object, e As KeyEventArgs) Handles txtGewicht1.KeyUp

        If Not IsNumeric(txtGewicht1.Text) Then
            txtGewicht1.Text = ""
            'lblMelding.Text = "Het gewicht moet een numeriek, heel getal zijn"
            Optellen()
            txtGewicht1.Focus()
            Return
        End If
        lblMelding.Text = ""
        btnOpslaan.Enabled = Enableopslaan()

        If e.KeyCode = Keys.Enter Then
            If cboNaamserie.SelectedValue = 12 Or cboNaamserie.SelectedValue = 13 Then
                txtAantal.Focus()
            Else
                Opslaan()
            End If
        End If

        If cboNaamserie.SelectedValue = 15 Or cboNaamserie.SelectedValue = 17 Then
            Optellen()
        End If

        If e.KeyCode = Keys.Enter Then
            txtNaam2.Select()
            dgvnamen.ClearSelection()
        End If

    End Sub
    Private Sub Optellen()

        Dim totaal As Long

        If IsNumeric(txtGewicht1.Text) Then
            totaal = Long.Parse(txtGewicht1.Text)
        End If
        If IsNumeric(txtGewicht2.Text) Then
            totaal += Long.Parse(txtGewicht2.Text)
        End If

        If String.IsNullOrEmpty(txtGewicht1.Text) And String.IsNullOrEmpty(txtGewicht2.Text) Then
            txtGewichtTotaal.Text = ""
        Else
            txtGewichtTotaal.Text = totaal.ToString("N0")
        End If

        If Not String.IsNullOrEmpty(txtGewicht1.Text) And Not String.IsNullOrEmpty(txtGewicht2.Text) Then
            btnOpslaan.Enabled = True
        Else
            btnOpslaan.Enabled = False
        End If

    End Sub
    Private Sub btnKlassement_Click(sender As Object, e As EventArgs) Handles btnKlassement.Click
        Dim f As New Frmklassement With {
            .Seizoen = Seizoenrepo.Get(cboSeizoen.SelectedValue),
            .Serie = Naamserierepo.Get(cboNaamserie.SelectedValue)
        }
        f.ShowDialog()

    End Sub

    Private Sub btnVisser_Click(sender As Object, e As EventArgs) Handles btnVisser.Click

        Dim f As New FrmVisser With {
                .Seizoen = Seizoenrepo.Get(cboSeizoen.SelectedValue),
                .Serie = Naamserierepo.Get(cboNaamserie.SelectedValue)
                }
        f.ShowDialog()

    End Sub

    Private Sub FrmMain_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        If CboSerieVolgnummer.Items.Count = 0 Then
            Fillcombo()
        End If
        IsStarted = True

    End Sub

    Private Sub txtNaam1_Enter(sender As Object, e As EventArgs) Handles txtNaam1.Enter

        txtNaam1.Text = ""
        txtGewicht1.Text = ""
        _deelnemer1 = Nothing
        Optellen()

    End Sub

    Private Sub txtNaam2_Enter(sender As Object, e As EventArgs) Handles txtNaam2.Enter

        txtNaam2.Text = ""
        txtGewicht2.Text = ""
        _deelnemer2 = Nothing
        Optellen()

    End Sub
    Private Sub btnLoting_Click(sender As Object, e As EventArgs) Handles btnLoting.Click

        frmHistorie.ShowDialog()

    End Sub

    Private Sub dgvUitslagen_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUitslagen.CellClick

        Dim id = Selecteerid(dgvUitslagen, "Uitslagid")

        Legen()
        If (cboNaamserie.SelectedValue = 15 Or cboNaamserie.SelectedValue = 17) Then
            If id > 0 Then
                nachtvis = Nachtvissenrepo.Get(id)
                If IsNothing(nachtvis) Then
                    Return
                End If
                _deelnemer1 = Namenrepo.Getbyoldid(Long.Parse(nachtvis.Deelnemerid1.ToString))
                _deelnemer2 = Namenrepo.Getbyoldid(Long.Parse(nachtvis.Deelnemerid2.ToString))

                'lblDatumid.Text = nachtvis.ID.ToString()
                lblUitslagid1.Text = nachtvis.Nachtvisid
                txtNaam1.Text = _deelnemer1.Naam
                txtNaam2.Text = _deelnemer2.Naam

                If String.IsNullOrEmpty(nachtvis.Gewicht1) Or String.IsNullOrEmpty(nachtvis.Gewicht2) Then
                    txtGewicht1.Text = nachtvis.Gewicht / 2
                    txtGewicht2.Text = nachtvis.Gewicht / 2
                Else
                    txtGewicht1.Text = nachtvis.Gewicht1
                    txtGewicht2.Text = nachtvis.Gewicht2
                End If
            End If
        Else
            If id > 0 Then
                Dim uitslag = Uitslagenrepo.Get(id)
                Dim naam = Namenrepo.Getbyoldid(uitslag.IDdeelnemer)
                If uitslag.SerieNaamNr = 12 Or uitslag.SerieNaamNr = 13 Then
                    txtAantal.Text = uitslag.Pnt.ToString()
                End If
                _deelnemer1 = naam
                txtNaam1.Text = naam.Naam
                lblDatumid.Text = uitslag.IDdatum
                lblUitslagid1.Text = uitslag.Uitslagid
                txtGewicht1.Text = uitslag.Kilo
            End If
        End If
        txtGewicht1.Enabled = True
        txtGewicht2.Enabled = True
        'dgvUitslagen.ClearSelection()

    End Sub

    Private Sub picfoto_DragEnter(sender As Object, e As DragEventArgs) Handles picfoto.DragEnter

        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If

    End Sub

    Private Sub picfoto_DragDrop(sender As Object, e As DragEventArgs) Handles picfoto.DragDrop

    End Sub

    Private Sub frmMain_DragEnter(sender As Object, e As DragEventArgs) Handles MyBase.DragEnter

        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If

    End Sub

    Private Sub frmMain_DragDrop(sender As Object, e As DragEventArgs) Handles MyBase.DragDrop

    End Sub

    Private Sub panfoto_DragDrop(sender As Object, e As DragEventArgs) Handles panfoto.DragDrop

        Dim data = e.Data.GetData(DataFormats.FileDrop)
        If data IsNot Nothing Then
            Dim bestandsnamen As String() = data
            If IsImage(bestandsnamen(0)) then
                txtfoto.Text = bestandsnamen(0)
                picfoto.Image = Image.FromFile(bestandsnamen(0))
                btnfotoopslaan.Visible = True
            End If
        End If

    End Sub

    Private Sub panfoto_DragEnter(sender As Object, e As DragEventArgs) Handles panfoto.DragEnter

        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If

    End Sub

    Private Sub btnfoto_Click(sender As Object, e As EventArgs) Handles btnfotoopslaan.Click

        If Not String.IsNullOrEmpty(txtfoto.Text) Then
            Dim folder As String = Path.GetDirectoryName(txtfoto.Text)
            Schrijfregister("visfotomap", folder)
            Dim extension As String = Path.GetExtension(txtfoto.Text)
            _datum.Afbeelding = $"{_datum.ID}{extension}"
            Dim uploadbestand = $"ftp://ftp.deruisvoornacquoy.nl/Afbeeldingen/{_datum.Afbeelding}"
            Dim client = New WebClient With {.Credentials = New NetworkCredential("pietline", "fn8565fn")}
            Try
                client.UploadFile(uploadbestand, txtfoto.Text)
                Datumweeretcrepo.Save(_datum)
                picfoto.ImageLocation = $"https://www.deruisvoornacquoy.nl/Afbeeldingen/{_datum.Afbeelding}"
                btnfotowissen.Visible = True
            Catch ex As Exception
                MessageBox.Show("Er is iets fout gegaan met het uploaden.")
            End Try

        End If

    End Sub

    Private Sub btnfotowissen_Click(sender As Object, e As EventArgs) Handles btnfotowissen.Click

        Verwijderfoto

    End Sub

    Private sub VerwijderFoto
        
        If Not String.IsNullOrEmpty(_datum.Afbeelding) Then
            Try
                Dim request As FtpWebRequest = WebRequest.Create($"ftp://ftp.deruisvoornacquoy.nl/Afbeeldingen/{_datum.Afbeelding}")
                request.Credentials = New NetworkCredential("pietline", "fn8565fn")
                request.Method = WebRequestMethods.Ftp.DeleteFile
                Dim response = request.GetResponse()
                picfoto.Image = Nothing
                _datum.Afbeelding = nothing
                Datumweeretcrepo.Save(_datum)
                btnfotowissen.Visible = False
                btnfotoopslaan.Visible = False
            Catch ex As Exception
                MessageBox.Show("Er is iets fout gegaan met het VERWIJDEREN VAN DE AFBEELDING.")
            End Try
        End If

    End sub

    Private Sub picfoto_Click(sender As Object, e As EventArgs) Handles picfoto.Click

        Dim map = Leesregister("visfotomap")
        If String.IsNullOrEmpty(map) Then
            map = "D:\Documenten\De Ruisvoorn"
        End If

        dim ofd = New OpenFileDialog With {
            .InitialDirectory = map,
            .Filter = "Afbeeldingen (*.png *.jpg *.jpeg) |*.png; *.jpg; *.jpeg|Alle bestanden(*.*) |*.*",
            .FilterIndex = 1
        }
        If ofd.ShowDialog <> DialogResult.Cancel Then
             If IsImage(ofd.FileName) then
                txtfoto.Text = ofd.FileName
                picfoto.Image = Image.FromFile(ofd.FileName)
                Dim folder As String = Path.GetDirectoryName(ofd.FileName)
                Schrijfregister("visfotomap", folder)
                btnfotoopslaan.Visible = True
            End If
        End If
    End Sub

    Private Sub btnVerwijderwedstrijd_Click(sender As Object, e As EventArgs) Handles btnVerwijderwedstrijd.Click

        If MessageBox.Show("Wilt u de geselecteerde wedstrijd verwijderen", "Verwijderen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Return
        End If
        'Is er een foto? -> Verwijderen
        VerwijderFoto
        'Is er een uitslag? -> Uitslagen verwijderen rekening houdend met serie
        If _datum.SerieNaamNr = 15 Or _datum.SerieNaamNr = 17 Then
            Nachtvissenrepo.Delete(_datum)
        Else
            Dim uitslagen = Uitslagenrepo.Get(_datum)
            If uitslagen.Count > 0 Then
                For Each regel As Uitslag In uitslagen
                    If regel.Uitslagid > 0 Then
                        Uitslagenrepo.Delete(regel.Uitslagid)
                    End If
                Next
            End If
        End If

        Dim loten = Lotingrepo.Get(_datum)
        If loten.Count > 0 Then
            For Each regel As Loting2 In loten
                Lotingrepo.Delete(regel)
            Next
        End If
       
        Datumweeretcrepo.Delete(_datum)
        Leegdetails

    End Sub

    Private Sub DeelnemerVerwijderen_Click(sender As Object, e As EventArgs) 



    End Sub
End Class