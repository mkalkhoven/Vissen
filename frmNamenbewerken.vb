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
    Private Sub frmNamenbewerken_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Fillgrid

    End Sub
    Private sub FillgridKlaverjassen

        Cursor.Current = Cursors.WaitCursor
        
        dgvKlaverjassen.Left = 12
        dgvKlaverjassen.Top = 56
        dgvKlaverjassen.Height = 757
        dgvKlaverjassen.Width = 1060
        
        dgvJokeren.Visible = False
        dgvnamen.Visible = False
        dgvKlaverjassen.Visible = True
        
        Dim namen = klaverjasrepo.Getdeelnemers
        dgvKlaverjassen.DataSource = namen

        Cursor.Current = Cursors.Arrow
    End sub

    Private sub FillgridJokeren

        Cursor.Current = Cursors.WaitCursor
        
        dgvJokeren.Left = 12
        dgvJokeren.Top = 56
        dgvJokeren.Height = 757
        dgvJokeren.Width = 1060
        
        dgvJokeren.Visible = False
        dgvJokeren.Visible = False
        dgvJokeren.Visible = True
        
        Dim namen = Jokerenrepo.Getdeelnemers
        dgvJokeren.DataSource = namen

        Cursor.Current = Cursors.Arrow

    End sub

    private sub Fillgrid

        Cursor.Current = Cursors.WaitCursor
        dgvnamen.DataSource = Nothing
        dgvnamen.Rows.Clear()
        dgvnamen.Columns.Clear()
        Dim b = 87 'Breedte van kolommen

        Dim namen = Namenrepo.Get(chkVerwijderdtonen.Checked)
        dgvnamen.DataSource = namen
        dgvnamen.Columns(0).Visible = False 'NaamID
        dgvnamen.Columns(1).Width = 302 'Naam
        dgvnamen.Columns(2).Visible=False 'KoppelID
        dgvnamen.Columns(3).Visible=False '50Plus
        dgvnamen.Columns(4).Width = 302 'Afbeelding
        'dgvnamen.Columns(7).Width = 10 '50Plus
        dgvnamen.Columns(8).Visible = False 'Verwijderd
        dgvnamen.Columns(10).Visible = False 'Voornaam
        dgvnamen.Columns(11).Visible = False 'Tussenvoegsel
        dgvnamen.Columns(12).Visible = False 'Achternaam
        dgvnamen.Columns(13).Visible = False 'Achternaam
        dgvnamen.Columns(14).Visible = False 'Achternaam
        dgvnamen.Columns(15).Visible = False 'Achternaam

        Dim col50plus As New DataGridViewTextBoxColumn With {
            .HeaderText = "50-Plus"
        }
        dgvnamen.Columns.Insert(5, col50plus)
        dgvnamen.Columns(6).Visible = False
        dgvnamen.Columns(5).Width = b '50Plus

        Dim colsenioren As New DataGridViewTextBoxColumn With {
            .HeaderText = "Senioren"
        }
        dgvnamen.Columns.Insert(7, colsenioren)
        dgvnamen.Columns(8).Visible = False
        dgvnamen.Columns(7).Width = b 'Senioren
        


        Dim colJeugd As New DataGridViewTextBoxColumn With {
            .HeaderText = "Jeugd"
         }
        dgvnamen.Columns.Insert(10, coljeugd)
        dgvnamen.Columns(9).Visible = False
        dgvnamen.Columns(10).Width = b   'Jeugd
        


        Dim colkoppelvissen As New DataGridViewTextBoxColumn With {
            .HeaderText = "Koppel"
         }
        dgvnamen.Columns.Insert(13, colkoppelvissen)
        dgvnamen.Columns(12).Visible = False
        dgvnamen.Columns(13).Width = b 'Koppelvissen
        
        Dim colWinter As New DataGridViewTextBoxColumn With {
            .HeaderText = "Winter"
         }
        dgvnamen.Columns.Insert(16, colWinter)
        dgvnamen.Columns(15).Visible = False
        dgvnamen.Columns(16).Width = b 'Wintervissen

        For Each row As DataGridViewRow In dgvnamen.Rows

            Dim id = Long.Parse(row.Cells(0).Value.ToString())
            Dim naam = Namenrepo.GetbyNaamid(id)

            If chkVerwijderdtonen.Checked = False Then
                If naam.Verwijderd = True
                    row.Visible = False
                End If
            End If

            If naam.Vijftigplus.HasValue Then
                If naam.Vijftigplus = True Then
                    row.Cells(5).Value = "Ja"
                End If
            End if
            If naam.Senioren.HasValue Then
                If naam.Senioren = True Then
                    row.Cells(7).Value = "Ja"
                End If
            End If

            If naam.Jeugd.HasValue Then
                If naam.Jeugd = True Then
                    row.Cells(10).Value = "Ja"
                End If
            End If

            If naam.Koppelvissen.HasValue Then
                If naam.Koppelvissen = True Then
                    row.Cells(13).Value = "Ja"
                End If
            End If

            If naam.Winter.HasValue Then
                If naam.Winter = True Then
                    row.Cells(16).Value = "Ja"
                End If
            End If
        Next

        If Columncount = 0 Then
            For Each column  As DataGridViewColumn In dgvnamen.Columns
                Columncount += 1
            Next
            Columncount -= 2
        End If

        Cursor.Current = Cursors.Arrow

    End sub

    Private Sub btnSluiten_Click(sender As Object, e As EventArgs) Handles btnSluiten.Click

        Dispose

    End Sub
    Private sub Leegallevelden()

        For Each ctl In Controls
            If TypeOf ctl Is TextBox Then
                ctl.Text = ""
                ctl.Enabled = True
            End If
            If TypeOf ctl Is CheckBox Then
                dim ctrl as CheckBox = ctl
                ctrl.Checked = False
            End If
        Next ctl

        picFotoDeelnemer.Image = Nothing
        Afbeelding = ""

        naam = New Namen
        deelnemerj = New DeelnemerJ
        deelnemerk = New DeelnemerK

    End sub

    Private Sub dgvnamen_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvnamen.CellClick

        Leegallevelden()

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
        'Afbeelding ophalen
        If not String.IsNullOrEmpty(naam.Afbeelding) Then
            picFotoDeelnemer.ImageLocation = $"http://deruisvoornacquoy.nl/Afbeeldingen/{naam.Afbeelding}"
        else
            picFotoDeelnemer.ImageLocation = "http://deruisvoornacquoy.nl/Afbeeldingen/Geen_Foto_vissen.jpg"
        End If        

    End Sub

    Private Sub btnopslaan_Click(sender As Object, e As EventArgs) Handles btnopslaan.Click

        Select Case database
            Case Databasetype.Vissen
                If Not naam.NaamID.HasValue Then
                    'Naamid ophalen
                    naam.NaamID = Namenrepo.Verkrijgid
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
                Fillgrid
        Selecteerregel(naam.NaamID, dgvnamen)
            Case Databasetype.Klaverjassen
                'deelnemerk.VolledigeNaam = txt
                klaverjasrepo.Save(deelnemerk)
                'Piet -> object vullen
            Case Databasetype.Jokeren
                'Piet -> object vullen
                'Piet -> object opslaan
        End Select

    End Sub

    Private Sub txtVoornaam_TextChanged(sender As Object, e As EventArgs) Handles txtVoornaam.TextChanged

        Maaknaam()

    End Sub
    Private Sub Maaknaam()

        If Not string.IsNullOrEmpty(txtVoornaam.Text) And Not String.IsNullOrEmpty(TxtAchternaam.Text) Then
            If String.IsNullOrEmpty(txtTussenvoegsel.Text) Then
                txtVolledigeNaam.Text = $"{txtVoornaam.Text} {TxtAchternaam.Text}"
            Else
                txtVolledigeNaam.Text = $"{txtVoornaam.Text} {txtTussenvoegsel.Text} {TxtAchternaam.Text}"
            End If
        End If

    End Sub

    Private Sub txtTussenvoegsel_TextChanged(sender As Object, e As EventArgs) Handles txtTussenvoegsel.TextChanged
        
        Maaknaam()

    End Sub

    Private Sub TxtAchternaam_TextChanged(sender As Object, e As EventArgs) Handles TxtAchternaam.TextChanged
        
        Maaknaam()

    End Sub

    Private Sub dgvnamen_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvnamen.DataBindingComplete

        dgvnamen.ClearSelection

        For Each row As DataGridViewRow In dgvnamen.Rows
            row.Height = 28
        Next

    End Sub

    Private Sub btnWijzigfoto_Click(sender As Object, e As EventArgs) Handles btnWijzigfoto.Click

        Dim voornaam As String = ""
        Dim achternaam As String = ""
        Dim extensie As String = ""

        ofd.InitialDirectory = "D:\Documenten\De Ruisvoorn\Afbeeldingen"
        ofd.Filter = "Afbeeldingen (*.png *.jpg) |*.png; *.jpg;"
        ofd.Title = "Selecteer een afbeelding"
        If (ofd.ShowDialog() = DialogResult.OK) Then
            'lblTempafbeelding.Text = ofd.FileName
            picFotoDeelnemer.ImageLocation = ofd.FileName
            picFotoDeelnemer.Image = Image.FromFile(ofd.FileName)
            Afbeelding = ofd.FileName
        End If

    End Sub

    Private Sub picFoto_Click(sender As Object, e As EventArgs) Handles picFotoDeelnemer.Click
        picFotoDeelnemer.Image = Nothing
          End Sub

'Private Sub btnVissen_Click(sender As Object, e As EventArgs) Handles btnVissen.Click
'    txtVolledigeNaam.Enabled=False
'    txtVoornaam.Enabled=Enabled
'    txtTussenvoegsel.Enabled=Enabled
'    TxtAchternaam.Enabled=Enabled
'    chkVijftigplus.Enabled=True
'    chkJeugd.Enabled=True
'    chkKoppelvissen.Enabled=True
'    chkSenioren.Enabled=True
'    chkVerwijderd.Enabled=True
'    chkVijftigplus.Enabled=True
'    chkWinter.Enabled=True
'    lblVissen.Text="Vissen"

'End Sub

'Private Sub btnKlaverjassen_Click(sender As Object, e As EventArgs) Handles btnKlaverjassen.Click
'    KlaverjassenJokeren
'    lblVissen.Text = "Klaverjassen"
'End Sub
'Private Sub btnJokeren_Click(sender As Object, e As EventArgs) Handles btnJokeren.Click
'    KlaverjassenJokeren
'    lblVissen.Text = "Jokeren"
'End Sub
'Sub KlaverjassenJokeren
'    txtVolledigeNaam.Enabled=True
'    txtVolledigeNaam.Text=""
'    txtVoornaam.Enabled=False
'    txtVoornaam.text=""
'    txtTussenvoegsel.Enabled=False
'    txtTussenvoegsel.Text=""
'    TxtAchternaam.Enabled=False
'    TxtAchternaam.Text=""
'    txtNaamAfbeelding.Text=""
'    chkVijftigplus.Enabled=False
'    chkJeugd.Enabled=False
'    chkKoppelvissen.Enabled=False
'    chkSenioren.Enabled=False
'    chkVerwijderd.Enabled=False
'    chkVijftigplus.Enabled=False
'    chkWinter.Enabled=False
'    'picFotoDeelnemer.Image = Image.FromFile("D:\Documenten\De Ruisvoorn\Afbeeldingen\Geen_Foto2.jpg")
'End Sub

    Private Sub btnNieuw_Click(sender As Object, e As EventArgs) Handles btnNieuw.Click

        Leegallevelden()

    End Sub

    Private Sub chkVerwijderdtonen_CheckedChanged(sender As Object, e As EventArgs) Handles chkVerwijderdtonen.CheckedChanged

        Fillgrid

        If naam.NaamID.HasValue Then
            Selecteerregel(naam.NaamID, dgvnamen)
        End if

    End Sub

    Private Sub btnKlaverjassen_Click(sender As Object, e As EventArgs) Handles btnKlaverjassen.Click

        database = Databasetype.Klaverjassen
        FillgridKlaverjassen

    End Sub

    Private Sub btnJokeren_Click(sender As Object, e As EventArgs) Handles btnJokeren.Click

        database = Databasetype.Jokeren
        FillgridJokeren

    End Sub

    Private Sub dgvJokeren_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvJokeren.CellClick
        
        Leegallevelden()

        Dim id = Selecteerid(dgvJokeren, 0)
        deelnemerj = Jokerenrepo.Get(id)
        'Piet -> textboxen vullen
    End Sub

    Private Sub dgvKlaverjassen_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvKlaverjassen.CellClick
        
        Leegallevelden()

        Dim id = Selecteerid(dgvKlaverjassen, 0)
        deelnemerk = klaverjasrepo.Get(id)
        'Piet -> textboxen vullen
    End Sub

    Private Sub btnVissen_Click(sender As Object, e As EventArgs) Handles btnVissen.Click

        database = Databasetype.Vissen
        Fillgrid

    End Sub
End Class