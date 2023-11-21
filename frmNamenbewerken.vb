imports Datalaag.Global
Imports Datalaag
Imports System.IO

Public Class frmNamenbewerken
    public naam As Namen = New Namen
    Private deelnemerk As DeelnemerK = New DeelnemerK
    Private deelnemerj As DeelnemerJ = New DeelnemerJ
    Private Columncount As Integer
    Private Afbeelding As String
    Private database As Databasetype
    Private red As Color
    Private Sub CboSeriesub
        btnWijzigfoto.Enabled=false
        database = Databasetype.Vissen
        btnOpslaan.Enabled=false
        Dim serie As New List(Of String)({"Alles", "50 Plus", "Jeugd", "Senioren", "Wintervissen"})
        cboSerie.DataSource = serie
    End Sub
    Private Sub frmNamenbewerken_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
        CboSeriesub
        dgvnamen.ClearSelection
        
    End Sub
     private sub Fillgrid()
        dgvnamen.ClearSelection
        Cursor.Current = Cursors.WaitCursor
        cboSerie.Visible = True
        dgvnamen.DataSource = Nothing
        dgvnamen.Rows.Clear()
        dgvnamen.Columns.Clear()
        dgvnamen.RowTemplate.Height = 30
        Dim b = 87 'Breedte van kolommen

        Dim x As New List(Of Namen)
        'Afhankelijk van cboserie
        Dim serie As New Serienaam
        Select Case cboSerie.SelectedIndex
            Case 0'Alles
                serie = Serienaam.Alles
                lblVissen.Text="Vissen alles"
            Case 1'50 Plus
                serie = Serienaam.Vijftigplus
                lblVissen.Text="Vissen 50 Plus"
            Case 2'Jeugd
                serie = Serienaam.Jeugd
                lblVissen.Text="Vissen Jeugd"
            Case 3'Senioren
                serie = Serienaam.Senioren
                lblVissen.Text="Vissen Senioren"
            Case 4'Wintervissen
                serie = Serienaam.Wintervissen
                lblVissen.Text="Vissen Winter"
        End Select
        Dim namen = Namenrepo.Get(serie, chkVerwijderdeleden.Checked)
        dgvnamen.DataSource = namen
        dgvnamen.Columns(0).Visible = False 'NaamID
        dgvnamen.Columns(1).Width = 315 'Naam
        dgvnamen.Columns(2).Visible=False 'KoppelID
        dgvnamen.Columns(3).Visible=False '50Plus
        dgvnamen.Columns(4).Width = 315 'Afbeelding
        dgvnamen.Width = 650
        dgvnamen.Columns(8).Visible = False 'Verwijderd
        dgvnamen.Columns(10).Visible = False 'Voornaam
        dgvnamen.Columns(11).Visible = False 'Tussenvoegsel
        dgvnamen.Columns(12).Visible = False 'Achternaam
        dgvnamen.Columns(13).Visible = False 'Achternaam
        dgvnamen.Columns(14).Visible = False 'Achternaam
        dgvnamen.Columns(15).Visible = False 'Achternaam
        dgvnamen.Columns(1).Width = 320 'Naam
        dgvnamen.Columns(4).Width = 330
        dgvnamen.ClearSelection
        '2
       
      
        'Wordt niet meer gebruikt
        'Dim col50plus As New DataGridViewTextBoxColumn With {
        '    .HeaderText = "50-Plus"
        '}
        'dgvnamen.Columns.Insert(5, col50plus)
        'dgvnamen.Columns(6).Visible = False
        'dgvnamen.Columns(5).Width = b '50Plus

        'Dim colsenioren As New DataGridViewTextBoxColumn With {
        '    .HeaderText = "Senioren"
        '}
        'dgvnamen.Columns.Insert(7, colsenioren)
        'dgvnamen.Columns(8).Visible = False
        'dgvnamen.Columns(7).Width = b 'Senioren
        'Dim colJeugd As New DataGridViewTextBoxColumn With {
        '    .HeaderText = "Jeugd"
        ' }
        'dgvnamen.Columns.Insert(10, coljeugd)
        'dgvnamen.Columns(9).Visible = False
        'dgvnamen.Columns(10).Width = b   'Jeugd
        'Dim colkoppelvissen As New DataGridViewTextBoxColumn With {
        '    .HeaderText = "Koppel"
        ' }
        'dgvnamen.Columns.Insert(13, colkoppelvissen)
        'dgvnamen.Columns(12).Visible = False
        'dgvnamen.Columns(13).Width = b 'Koppelvissen

        'Dim colWinter As New DataGridViewTextBoxColumn With {
        '    .HeaderText = "Winter"
        ' }
        'dgvnamen.Columns.Insert(16, colWinter)
        'dgvnamen.Columns(15).Visible = False
        'dgvnamen.Columns(16).Width = b 'Wintervissen
        'For Each row As DataGridViewRow In dgvnamen.Rows
        '    Dim id = Long.Parse(row.Cells(0).Value.ToString())
        '    Dim naam = Namenrepo.GetbyNaamid(id)

        '    If chkVerwijderdtonen.Checked = False Then
        '        If naam.Verwijderd = True
        '            row.Visible = False
        '        End If
        '    End If
        '    If naam.Vijftigplus.HasValue Then
        '        If naam.Vijftigplus = True Then
        '            row.Cells(5).Value = "Ja"
        '        End If
        '    End if
        '    If naam.Senioren.HasValue Then
        '        If naam.Senioren = True Then
        '            row.Cells(7).Value = "Ja"
        '        End If
        '    End If
        '    If naam.Jeugd.HasValue Then
        '        If naam.Jeugd = True Then
        '            row.Cells(10).Value = "Ja"
        '        End If
        '    End If
        '    If naam.Koppelvissen.HasValue Then
        '        If naam.Koppelvissen = True Then
        '            row.Cells(13).Value = "Ja"
        '        End If
        '    End If
        '    If naam.Winter.HasValue Then
        '        If naam.Winter = True Then
        '            row.Cells(16).Value = "Ja"
        '        End If
        '    End If
        'Next

        If Columncount = 0 Then
            For Each column  As DataGridViewColumn In dgvnamen.Columns
                Columncount += 1
            Next
            Columncount -= 2
        End If
        Cursor.Current = Cursors.Arrow
    End sub
    Private sub FillgridKlaverjassen
        Dim namen = klaverjasrepo.Getdeelnemers(chkVerwijderdeleden.Checked)
        Cursor.Current = Cursors.WaitCursor
        dgvKlaverjassen.RowTemplate.Height = 30
        dgvKlaverjassen.DataSource = Nothing
        dgvKlaverjassen.Rows.Clear()
        dgvKlaverjassen.Columns.Clear()
        dgvKlaverjassen.Left = 12
        dgvKlaverjassen.Top = 56
        dgvKlaverjassen.Height = 757
        dgvKlaverjassen.Width = 650
        dgvJokeren.Visible = False
        dgvnamen.Visible = False
        dgvKlaverjassen.Visible = True
        dgvKlaverjassen.DataSource = namen
        dgvKlaverjassen.Columns(1).Width = 299 'Naam
        dgvKlaverjassen.Columns(2).Visible = true 'Naam afbeelding 
        dgvKlaverjassen.Columns(2).Width = 299 
        dgvKlaverjassen.Columns(0).Width = 50 'Nummer
        Cursor.Current = Cursors.Arrow
    End sub
       Private sub FillgridJokeren
        Dim namen = Jokerenrepo.Getdeelnemers(chkVerwijderdeleden.Checked)
        Cursor.Current = Cursors.WaitCursor
        dgvJokeren.DataSource = Nothing
        dgvJokeren.Rows.Clear()
        dgvJokeren.Columns.Clear()
        dgvJokeren .RowTemplate.Height = 30
        dgvJokeren.Left = 12
        dgvJokeren.Top = 56
        dgvJokeren.Height = 757
        dgvJokeren.Width = 650
        dgvJokeren.Visible = True
        dgvnamen.Visible = False
        dgvKlaverjassen.Visible = False
        dgvJokeren.DataSource = namen
        dgvJokeren.Columns(1).Width = 299 'Naam
        dgvJokeren.Columns(2).Visible = true 'Naam afbeelding 
        dgvJokeren.Columns(2).Width = 299
        dgvJokeren.Columns(0).Width = 50 'Nummer
        Cursor.Current = Cursors.Arrow
       End sub
    Private Sub wisNamen
        chkVijftigplus.Checked=False
        chkSenioren.Checked=False
        chkJeugd.Checked=false
        chkWinter.Checked=false
        chkKoppelvissen.Checked=False
        chkWinter.Checked=False
        btnVerwijderdHeleNaam.Enabled=False
        'chkVerwijderd.Enabled = false
        dgvnamen.ClearSelection
        btnopslaan.Enabled = False
        chkVerwijderdeleden.Checked = False
        txtNaamAfbeelding.Text=""
        txtTussenvoegsel.Text=""
        txtVoornaam.Text=""
        txtTussenvoegsel.Text=""
        TxtAchternaam.Text=""
        txtVolledigeNaam.Text=""
        TxtAchternaam.Text=""
        picFotoDeelnemer.Image = Image.FromFile("C:\Documenten\De Ruisvoorn\Afbeeldingen\Geen_Foto2.jpg")
    End Sub
    Private Sub Verplaatstknoppen()
        chkJeugd.Enabled = False
        chkKoppelvissen.Enabled = False
        chkSenioren.Enabled = False
        chkVijftigplus.Enabled = False
        chkWinter.Enabled = False
        chkVerwijderd.Enabled = True
        picFotoDeelnemer.Image = Image.FromFile("C:\Documenten\De Ruisvoorn\Afbeeldingen\Geen_Foto2.jpg")
    End Sub
    Private Sub VerplaatstknoppenVissen()
        chkJeugd.Enabled = True
        chkKoppelvissen.Enabled = True
        chkSenioren.Enabled = True
        chkVerwijderd.Enabled = True
        chkVijftigplus.Enabled = True
        chkWinter.Enabled = True
        chkVerwijderd.Enabled = True
        picFotoDeelnemer.Image = Image.FromFile("C:\Documenten\De Ruisvoorn\Afbeeldingen\Geen_Foto2.jpg")
    End Sub
    Private Sub btnSluiten_Click(sender As Object, e As EventArgs) Handles btnSluiten.Click
        wisNamen()
        Dispose()
    End Sub
    Private Sub Leegallevelden()
        '4

        For Each ctl In Controls
            If TypeOf ctl Is TextBox Then
                ctl.Text = ""
                ctl.Enabled = True
            End If
            If TypeOf ctl Is CheckBox Then
                Dim ctrl As CheckBox = ctl
                If ctrl.Name <> "chkVerwijderdeleden" Then
                    ctrl.Checked = False
                End If
            End If
        Next ctl
        picFotoDeelnemer.Image = Nothing
        btnopslaan.Enabled = True
        Afbeelding = ""
        naam = New Namen
        deelnemerj = New DeelnemerJ
        deelnemerk = New DeelnemerK
        txtVoornaam.Focus()
    End Sub

    Private Sub dgvnamen_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvnamen.CellClick
        Leegallevelden()
        btnVerwijderdHeleNaam.Enabled = True
        btnWijzigfoto.Enabled = True
        Dim id = Selecteerid(dgvnamen, Columncount)
        naam = Namenrepo.Get(id)
        txtVoornaam.Text = naam.Voornaam
        txtTussenvoegsel.Text = naam.Tussenvoegsel
        TxtAchternaam.Text = naam.Achternaam
        txtVolledigeNaam.Text = naam.Naam
        txtNaamAfbeelding.Text = naam.Afbeelding
        chkVijftigplus.Checked = naam.Vijftigplus
        chkJeugd.Checked = naam.Jeugd
        chkKoppelvissen.Checked = naam.Koppelvissen
        chkSenioren.Checked = naam.Senioren
        chkWinter.Checked = naam.Winter
        chkVerwijderd.Checked = naam.Verwijderd
        btnopslaan.Enabled = True
        If Not String.IsNullOrEmpty(naam.Afbeelding) Then
            picFotoDeelnemer.ImageLocation = $"http://deruisvoornacquoy.nl/Afbeeldingen/{naam.Afbeelding}"
        Else
            picFotoDeelnemer.ImageLocation = "http://deruisvoornacquoy.nl/Afbeeldingen/Geen_Foto_vissen.jpg"
        End If
    End Sub

    Private Sub Maaknaam()

        If Not String.IsNullOrEmpty(txtVoornaam.Text) And Not String.IsNullOrEmpty(TxtAchternaam.Text) Then
            If String.IsNullOrEmpty(txtTussenvoegsel.Text) Then
                txtVolledigeNaam.Text = $"{txtVoornaam.Text} {TxtAchternaam.Text}"
            Else
            End If
        End If

        txtVolledigeNaam.Text = $"{txtVoornaam.Text} {txtTussenvoegsel.Text} {TxtAchternaam.Text}"
    End Sub
    Private Sub txtVoornaam_TextChanged(sender As Object, e As EventArgs) Handles txtVoornaam.TextChanged
        Maaknaam()
    End Sub
    Private Sub txtTussenvoegsel_TextChanged(sender As Object, e As EventArgs) Handles txtTussenvoegsel.TextChanged
        Maaknaam()
    End Sub
    Private Sub TxtAchternaam_TextChanged(sender As Object, e As EventArgs) Handles TxtAchternaam.TextChanged
        Maaknaam()
    End Sub

    Private Sub dgvnamen_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvnamen.DataBindingComplete
        '1
        'Dim totaal = 0
        'For Each row As DataGridViewRow In dgvnamen.Rows
        '    row.Height = 28
        '    totaal = totaal + 1
        'Next
        'txtTotaal.Text = totaal
        dgvnamen.ClearSelection()
    End Sub

    Private Sub btnWijzigfoto_Click(sender As Object, e As EventArgs) Handles btnWijzigfoto.Click
        Dim voornaam As String = ""
        Dim achternaam As String = ""
        Dim extensie As String = ""
        ofd.InitialDirectory = "C:\Documenten\De Ruisvoorn\Afbeeldingen"
        ofd.Filter = "Afbeeldingen (*.png *.jpg) |*.png; *.jpg;"
        ofd.Title = "Selecteer een afbeelding"
        If (ofd.ShowDialog() = DialogResult.OK) Then
            picFotoDeelnemer.ImageLocation = ofd.FileName
            picFotoDeelnemer.Image = Image.FromFile(ofd.FileName)
            Afbeelding = ofd.FileName
            Dim fi As New FileInfo(Afbeelding)
            naam.Afbeelding = fi.Name
            txtNaamAfbeelding.Text = naam.Afbeelding
        End If

    End Sub

    Private Sub picFoto_Click(sender As Object, e As EventArgs) Handles picFotoDeelnemer.Click
        picFotoDeelnemer.Image = Nothing
          End Sub

    Private Sub btnNieuw_Click(sender As Object, e As EventArgs) Handles btnNieuw.Click
        If lblVissen.Text="Klaverjassen" Then return
        if lblVissen.Text="Jokeren" Then Return
        Leegallevelden()
        picFotoDeelnemer.ImageLocation = "http://deruisvoornacquoy.nl/Afbeeldingen/Geen_Foto_vissen.jpg"
    End Sub
    Private Sub btnKlaverjassen_Click(sender As Object, e As EventArgs) Handles btnKlaverjassen.Click
        wisNamen
        database = Databasetype.Klaverjassen
        btnWijzigfoto.Enabled=false
        cboSerie.Visible = false
        btnNieuw.Enabled=False
        dgvnamen.ClearSelection
        lblVissen.Text="Klaverjassen"
        dgvJokeren.Visible = False
        dgvKlaverjassen.Visible = True
        dgvnamen.Visible = False
        Verplaatstknoppen
        FillgridKlaverjassen
        btnVerwijderdHeleNaam.Enabled=False
    End Sub
    Private Sub btnJokeren_Click(sender As Object, e As EventArgs) Handles btnJokeren.Click
        wisNamen
        database = Databasetype.Jokeren
        btnWijzigfoto.Enabled=false
        btnNieuw.Enabled=false
        cboSerie.Visible = false
        dgvnamen.ClearSelection
        
        lblVissen.Text="Jokeren"
        dgvJokeren.Visible = true
        dgvnamen.Visible = False
        dgvKlaverjassen.Visible = False
        Verplaatstknoppen
        FillgridJokeren
        btnVerwijderdHeleNaam.Enabled=False
    End Sub
    Private Sub dgvJokeren_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvJokeren.CellClick
        Leegallevelden()
        btnopslaan.Enabled=True
        btnWijzigfoto.Enabled=true
        Dim id = Selecteerid(dgvJokeren, 0)
        deelnemerj = Jokerenrepo.Get(id)
        txtNaamAfbeelding.Text = deelnemerj.Afbeelding
        txtVoornaam.Text = deelnemerj.Voornaam
        txtTussenvoegsel.Text = deelnemerj.Tussenvoegsel
        TxtAchternaam.Text = deelnemerj.Achternaam
        txtVolledigeNaam.Text = deelnemerj.VolledigeNaamJ
        chkVerwijderd.Checked = deelnemerj.Verwijderd
        If not String.IsNullOrEmpty(deelnemerj.Afbeelding) Then
            picFotoDeelnemer.ImageLocation = $"http://deruisvoornacquoy.nl/Afbeeldingen/{deelnemerj.Afbeelding}"
        else
            picFotoDeelnemer.ImageLocation = "http://deruisvoornacquoy.nl/Afbeeldingen/Geen_Foto_vissen.jpg"
        End If    
    End Sub

    Private Sub dgvKlaverjassen_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvKlaverjassen.CellClick
        Leegallevelden()
        btnopslaan.Enabled=True
        btnWijzigfoto.Enabled=True
        Dim id = Selecteerid(dgvKlaverjassen, 0)
        deelnemerk = klaverjasrepo.Get(id)
        txtNaamAfbeelding.Text = deelnemerk.Afbeelding
        txtVoornaam.Text = deelnemerk.Voornaam
        txtTussenvoegsel.Text = deelnemerk.Tussenvoegsel
        TxtAchternaam.Text = deelnemerk.Achternaam
        txtVolledigeNaam.Text = deelnemerk.VolledigeNaam
        chkVerwijderd.Checked = deelnemerk.Verwijderd
        If not String.IsNullOrEmpty(deelnemerk.Afbeelding) Then
            picFotoDeelnemer.ImageLocation = $"http://deruisvoornacquoy.nl/Afbeeldingen/{deelnemerk.Afbeelding}"
        else
            picFotoDeelnemer.ImageLocation = "http://deruisvoornacquoy.nl/Afbeeldingen/Geen_Foto_vissen.jpg"
        End If    
    End Sub
    Private Sub btnVissen_Click(sender As Object, e As EventArgs) Handles btnVissen.Click
        wisNamen
        CboSeriesub
        btnWijzigfoto.Enabled=False
        Database = Databasetype.Vissen
        Leegallevelden
        dgvKlaverjassen.Visible=False
        dgvJokeren.Visible=False
        dgvKlaverjassen.ClearSelection
        lblVissen.Text="Vissen"
        btnNieuw.Enabled=True
        'btnopslaan.Visible=True
        dgvnamen.Visible = true
        dgvJokeren.Visible = False
        dgvKlaverjassen.Visible = False
        txtVolledigeNaam.Enabled = False
        txtVolledigeNaam.Visible = True
        lblVolledigeNaam.Visible = True
        VerplaatstknoppenVissen
        btnopslaan.Enabled=false
        chkVerwijderdeleden.Checked = False
        Fillgrid
    End Sub
    Private Sub txtZoeken_KeyUp(sender As Object, e As KeyEventArgs) Handles txtZoeken.KeyUp
         Cursor.Current = Cursors.WaitCursor
        Select Case database
            Case Databasetype.Jokeren
                dgvJokeren.DataSource = Nothing
                dgvJokeren.Rows.Clear()
                dgvJokeren.Columns.Clear()
                Dim namen = Jokerenrepo.Getdeelnemers(txtZoeken.Text)
                dgvJokeren.DataSource = namen
                dgvJokeren.Left = 12
                dgvJokeren.Top = 56
                dgvJokeren.Height = 757
                dgvJokeren.Width = 650
                dgvJokeren.Visible = True
                dgvnamen.Visible = False
                dgvKlaverjassen.Visible = False
                dgvJokeren.DataSource = namen
                dgvJokeren.Columns(1).Width = 298 'Naam
                dgvJokeren.Columns(2).Visible = true 'Naam afbeelding 
                dgvJokeren.Columns(2).Width = 298
                dgvJokeren.Columns(0).Width = 50 'Nummer
            Case Databasetype.Klaverjassen
                dgvKlaverjassen.DataSource = Nothing
                dgvKlaverjassen.Rows.Clear()
                dgvKlaverjassen.Columns.Clear()
                Dim namen = klaverjasrepo.Getdeelnemers(txtZoeken.Text)
                dgvKlaverjassen.DataSource = namen
                dgvKlaverjassen.DataSource = Nothing
                dgvKlaverjassen.Rows.Clear()
                dgvKlaverjassen.Columns.Clear()
                dgvKlaverjassen.Left = 12
                dgvKlaverjassen.Top = 56
                dgvKlaverjassen.Height = 757
                dgvKlaverjassen.Width = 650
                dgvJokeren.Visible = False
                dgvnamen.Visible = False
                dgvKlaverjassen.Visible = True
                dgvKlaverjassen.DataSource = namen
                dgvKlaverjassen.Columns(1).Width = 300 'Naam
                dgvKlaverjassen.Columns(2).Visible = true 'Naam afbeelding 
                dgvKlaverjassen.Columns(2).Width = 300 
                dgvKlaverjassen.Columns(0).Width = 50 'Nummer
            Case Databasetype.Vissen                
                dgvnamen.DataSource = Nothing
                dgvnamen.Rows.Clear()
                Dim namen = Namenrepo.Get(txtZoeken.Text)
                dgvnamen.DataSource = namen
                dgvnamen.Columns(0).Visible = False 'NaamID
                dgvnamen.Columns(1).Width = 325 'Naam
                dgvnamen.Columns(2).Visible=False 'KoppelID
                dgvnamen.Columns(3).Visible=False '50Plus
                dgvnamen.Columns(4).Width = 325 'Afbeelding
                dgvnamen.Width = 650
                dgvnamen.Columns(8).Visible = False 'Verwijderd
                dgvnamen.Columns(10).Visible = False 'Voornaam
                dgvnamen.Columns(11).Visible = False 'Tussenvoegsel
                dgvnamen.Columns(12).Visible = False 'Achternaam
                dgvnamen.Columns(13).Visible = False 'Achternaam
                dgvnamen.Columns(14).Visible = False 'Achternaam
                dgvnamen.Columns(15).Visible = False 'Achternaam
        End Select
        Cursor.Current = Cursors.Arrow
    End Sub
    Private Sub btnopslaan_Click_1(sender As Object, e As EventArgs) Handles btnopslaan.Click
        'Goed 
        btnopslaan.Enabled=False
        If txtVolledigeNaam.Text = "" Then  return
        Select Case database
            Case Databasetype.Vissen
                If Not naam.NaamID.HasValue Then
                    'Naamid ophalen
                    naam.NaamID = Namenrepo.Verkrijgid
                End If
                If txtVoornaam.Text="" Then txtVoornaam.focus: Return
                If TxtAchternaam.Text="" Then
                    TxtAchternaam.Text="VUL ACHTERNAAM IN"
                    TxtAchternaam.focus
                    btnopslaan.Enabled=True
                    Return
                End If
                naam.Voornaam = txtVoornaam.Text
                naam.Tussenvoegsel = txtTussenvoegsel.Text
                naam.Achternaam= TxtAchternaam.Text
                naam.Naam = txtVolledigeNaam.Text
                naam.Vijftigplus = chkVijftigplus.Checked
                naam.Senioren = chkSenioren.Checked
                naam.Jeugd = chkJeugd.Checked
                naam.Winter = chkWinter.Checked
                naam.Koppelvissen = chkKoppelvissen.Checked
                naam.Verwijderd = chkVerwijderd.Checked
                If Not String.IsNullOrEmpty(Afbeelding) Then
                    'Bestandsnaam
                    Dim fi As New FileInfo(Afbeelding)
                    naam.Afbeelding = fi.Name
                    txtNaamAfbeelding.Text = fi.Name
                    'Uploaden naar internet
                    uploaden(Afbeelding, $"ftp://ftp.deruisvoornacquoy.nl/Afbeeldingen/{fi.Name}")
                    Afbeelding = ""
                End If
                Namenrepo.Save(naam)
                'Leegallevelden
                wisNamen
                Fillgrid
                Selecteerregel(naam.NaamID, dgvnamen)
            Case Databasetype.Klaverjassen
                If Not String.IsNullOrEmpty(Afbeelding) Then
                    Dim fi As New FileInfo(Afbeelding)
                    deelnemerk.Afbeelding = fi.Name
                    txtNaamAfbeelding.Text = fi.Name
                    'Uploaden naar internet
                    uploaden(Afbeelding, $"ftp://ftp.deruisvoornacquoy.nl/Afbeeldingen/{fi.Name}")
                    'Afbeelding = ""
                Else
                    deelnemerk.Voornaam = txtVoornaam.text
                    deelnemerk.Tussenvoegsel = txtTussenvoegsel.text
                    deelnemerk.Achternaam = TxtAchternaam.text
                    deelnemerk.VolledigeNaam = txtVolledigeNaam.text
                    deelnemerk.Verwijderd = chkVerwijderd.Checked
                End If
                klaverjasrepo.Save(deelnemerk)
                wisNamen
                FillgridKlaverjassen
            Case Databasetype.Jokeren
                 If Not String.IsNullOrEmpty(Afbeelding) Then
                    Dim fi As New FileInfo(Afbeelding)
                    deelnemerj.Afbeelding = fi.Name
                    txtNaamAfbeelding.Text = fi.Name
                    'Uploaden naar internet
                    uploaden(Afbeelding, $"ftp://ftp.deruisvoornacquoy.nl/Afbeeldingen/{fi.Name}")
                Else
                    deelnemerj.Voornaam = txtVoornaam.text
                    deelnemerj.Tussenvoegsel = txtTussenvoegsel.text
                    deelnemerj.Achternaam = TxtAchternaam.text
                    deelnemerj.VolledigeNaamj = txtVolledigeNaam.text
                    deelnemerj.Verwijderd = chkVerwijderd.Checked
                End If
                Jokerenrepo.Save(deelnemerj)
                wisNamen
                FillgridJokeren
        End Select
    End Sub

    Private Sub cboSerie_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSerie.SelectedIndexChanged
        Fillgrid
        dgvnamen.ClearSelection
        '3
    End Sub
    Private Sub chkVerwijderdeleden_CheckedChanged(sender As Object, e As EventArgs) Handles chkVerwijderdeleden.CheckedChanged
        Select Case database
            Case Databasetype.Jokeren
                FillgridJokeren
            Case Databasetype.Klaverjassen
                FillgridKlaverjassen
            Case Databasetype.Vissen
                Fillgrid
        End Select
    End Sub
    Private Sub dgvKlaverjassen_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvKlaverjassen.DataBindingComplete
        Dim totaal=0
        dgvKlaverjassen.ClearSelection
        For Each row As DataGridViewRow In dgvKlaverjassen.Rows
            row.Height = 28
            Totaal = Totaal+1
        Next
        txttotaal.text=totaal
    End Sub
    Private Sub dgvJokeren_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvJokeren.DataBindingComplete
        Dim totaal=0
        dgvJokeren.ClearSelection
                For Each row As DataGridViewRow In dgvJokeren.Rows
            row.Height = 28
            Totaal = Totaal+1
        Next
        txttotaal.text=totaal
    End Sub
    Private Sub txtVoornaam_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtVoornaam.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txtTussenvoegsel.Focus()
        End If
    End Sub
     Private Sub txtTussenvoegsel_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTussenvoegsel.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            TxtAchternaam.Focus()
        End If
    End Sub

    Private Sub TxtAchternaam_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtAchternaam.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txtVoornaam.Focus()
        End If
    End Sub

    Private Sub VerwijderdHeleNaam_Click(sender As Object, e As EventArgs) Handles btnVerwijderdHeleNaam.Click
      If MessageBox.Show( " Weet u het zeker dat u dit lid wilt verwijderen ?? ",txtVolledigeNaam.Text, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                Return
        Else
                'Stop 'hier moet het lid worden verwijderd
            database = Databasetype.Vissen
        dim sql = $"DELETE FROM namen WHERE Lidid = {naam.NaamID}"
            Namenrepo.Delete(naam)
            
            Fillgrid
        End If
    End Sub

    Private Sub cboSerie_Click(sender As Object, e As EventArgs) Handles cboSerie.Click
        btnVerwijderdHeleNaam.Enabled=False
        VerplaatstknoppenVissen
        chkVerwijderd.Enabled=True
        wisNamen
    End Sub

    Private Sub dgvJokeren_Click(sender As Object, e As EventArgs) Handles dgvJokeren.Click
        btnWijzigfoto.Enabled=True
    End Sub

    Private Sub frmNamenbewerken_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint

        dgvnamen.ClearSelection()

    End Sub

End Class