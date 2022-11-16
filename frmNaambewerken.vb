Imports Datalaag
Imports Datalaag.Global
Public Class FrmNaambewerken
    Public Naam As Namen
    Private Function Selecteerpartnerid(Naam As Namen, serieid As Long) As Long

        For Each partner As Partner In Naam.Partner
            If partner.Serieid = serieid Then
                Return partner.Partnernaamid
            End If
        Next
        Return 0

    End Function
    Private Sub frmNaambewerken_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Icon = FrmMain.Icon

        Dim vistype = New Vistype()

        Dim vijftigplus = Namenrepo.Get(vistype.Vijftigplus)
        cboPartnervijftigplus.DataSource = vijftigplus
        vijftigplus.Insert(0, New Namen())
        cboPartnervijftigplus.DisplayMember = "Naam"
        cboPartnervijftigplus.ValueMember = "NaamId"

        Dim senioren = Namenrepo.Get(Vistype.Senioren)
        senioren.Insert(0, New Namen())
        cboPartnersenioren.DataSource = senioren
        cboPartnersenioren.DisplayMember = "Naam"
        cboPartnersenioren.ValueMember = "NaamId"

        Dim winter = Namenrepo.Get(Vistype.Winter)
        winter.Insert(0, New Namen())
        cboPartnerwinter.DataSource = winter
        cboPartnerwinter.DisplayMember = "Naam"
        cboPartnerwinter.ValueMember = "NaamId"

        Dim jeugd = Namenrepo.Get(Vistype.Jeugd)
        jeugd.Insert(0, New Namen())
        cboPartnerjeugd.DataSource = jeugd
        cboPartnerjeugd.DisplayMember = "Naam"
        cboPartnerjeugd.ValueMember = "NaamId"

        Dim koppelvissen = Namenrepo.Get(Vistype.Koppel)
        koppelvissen.Insert(0, New Namen())
        cboPartnerkoppelvissen.DataSource = koppelvissen
        cboPartnerkoppelvissen.DisplayMember = "Naam"
        cboPartnerkoppelvissen.ValueMember = "NaamId"

        If Not IsNothing(Naam) Then
            txtAchternaam.Text = Naam.Achternaam
            txtVoornaam.Text = Naam.Voornaam
            txtTussenvoegsel.Text = Naam.Tussenvoegsel

            chkVijftigplus.Checked = Naam.Vijftigplus
            chkSenioren.Checked = Naam.Senioren
            chkWintervissen.Checked = Naam.Winter
            chkjeugd.Checked = Naam.Jeugd
            chkkoppelvissen.Checked = Naam.Koppelvissen
            chkVerwijderd.Checked = Naam.Verwijderd

            If Naam.Vijftigplus = True Then
                cboPartnervijftigplus.Enabled = True
                cboPartnervijftigplus.SelectedValue = Selecteerpartnerid(Naam, 6)
            End If
            If Naam.Senioren = True Then
                cboPartnersenioren.Enabled = True
                cboPartnersenioren.SelectedValue = Selecteerpartnerid(Naam, 1)
            End If
            If Naam.Winter = True Then
                cboPartnerwinter.Enabled = True
                cboPartnerwinter.SelectedValue = Selecteerpartnerid(Naam, 9)
            End If
            If Naam.Jeugd = True Then
                cboPartnerjeugd.Enabled = True
                cboPartnerjeugd.SelectedValue = Selecteerpartnerid(Naam, 12)
            End If
            If Naam.Koppelvissen = True Then
                cboPartnerkoppelvissen.Enabled = True
                cboPartnerkoppelvissen.SelectedValue = Selecteerpartnerid(Naam, 15)
            End If

        Else
            Naam = New Namen()
        End If

    End Sub

    Private Sub btnSluiten_Click(sender As Object, e As EventArgs) Handles btnSluiten.Click

        Close()

    End Sub

    Private Sub btnOpslaan_Click(sender As Object, e As EventArgs) Handles btnOpslaan.Click

        If txtVoornaam.Text = "" Or txtAchternaam.Text = "" Then
            MessageBox.Show("Zowel voor- als achternaam moeten zijn gevuld zijn", "FOUT!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Naam.Achternaam = txtAchternaam.Text
        Naam.Voornaam = txtVoornaam.Text
        Naam.Tussenvoegsel = txtTussenvoegsel.Text
        If String.IsNullOrEmpty(txtTussenvoegsel.Text) Then
            Naam.Naam = $"{txtVoornaam.Text} {txtAchternaam.Text}"
        Else
            Naam.Naam = $"{txtVoornaam.Text} {txtTussenvoegsel.Text} {txtAchternaam.Text}"
        End If
        Naam.Vijftigplus = chkVijftigplus.Checked
        Naam.Senioren = chkSenioren.Checked
        Naam.Winter = chkWintervissen.Checked
        Naam.Jeugd = chkjeugd.Checked
        Naam.Koppelvissen = chkkoppelvissen.Checked
        Naam.Verwijderd = chkVerwijderd.Checked

        Namenrepo.Save(Naam)
        If Not Naam.NaamID.HasValue Then
            Naam.NaamID = Namenrepo.Getid()
            Namenrepo.Save(Naam)
        End If

        Close()

    End Sub

    Private Sub cboPartnervijftigplus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPartnervijftigplus.SelectedIndexChanged

        Try
            Dim partner = Partnerrepo.Get(Naam.NaamID, 6)
            If IsNothing(partner) Then
                partner = New Partner()
            End If
            If partner.Partnerid <> cboPartnervijftigplus.SelectedValue Then
                If cboPartnervijftigplus.SelectedValue = 0 Then
                    'Verwijderen
                Else
                    Dim newpartner As New Partner()
                    newpartner.Partnernaamid = cboPartnervijftigplus.SelectedValue
                    newpartner.Naamid = Naam.NaamID
                    newpartner.Id = Naam.Id
                    newpartner.Serieid = 6
                    Partnerrepo.Save(newpartner)
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub
End Class