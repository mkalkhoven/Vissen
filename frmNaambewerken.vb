﻿Imports Datalaag
Imports Datalaag.Global
Public Class FrmNaambewerken
    public Naam As Namen
    Private Sub frmNaambewerken_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
        Icon = FrmMain.Icon

        Dim Namen = Namenrepo.Get(Naam.Vijftigplus, Naam.Senioren, Naam.Winter, Naam.Jeugd, Naam.Koppelvissen)
        cboPatner.DataSource = Namen
        cboPatner.DisplayMember = "Naam"
        cboPatner.ValueMember = "NaamId"

        If Not IsNothing(Naam) Then
            txtAchternaam.Text = Naam.Achternaam
            txtVoornaam.Text = Naam.Voornaam
            txtTussenvoegsel.Text=  Naam.Tussenvoegsel

            chkVijftigplus.Checked = Naam.Vijftigplus
            chkSenioren.Checked = Naam.Senioren
            chkWintervissen.Checked = Naam.Winter
            chkjeugd.Checked = Naam.Jeugd
            chkkoppelvissen.Checked = Naam.Koppelvissen
            chkVerwijderd.Checked = Naam.Verwijderd

            If Not IsNothing(Naam.Partnerid) Then
                cboPatner.SelectedValue = Naam.Partnerid
            End If

        Else 
            Naam = New Namen()
        End If

    End Sub

    Private Sub btnSluiten_Click(sender As Object, e As EventArgs) Handles btnSluiten.Click

        Close()

    End Sub

     Private Sub btnOpslaan_Click(sender As Object, e As EventArgs) Handles btnOpslaan.Click

        Naam.Achternaam = txtAchternaam.Text
        Naam.Voornaam = txtVoornaam.Text
        Naam.Tussenvoegsel = txtTussenvoegsel.Text
        If String.IsNullOrEmpty(txtTussenvoegsel.Text) Then
            Naam.Naam = $"{txtVoornaam.Text} {txtAchternaam.Text}"
        else
            Naam.Naam = $"{txtVoornaam.Text} {txtTussenvoegsel.Text} {txtAchternaam.Text}"
        End If
        Naam.Vijftigplus = chkVijftigplus.Checked
        Naam.Senioren = chkSenioren.Checked
        Naam.Winter = chkWintervissen.Checked
        Naam.Jeugd = chkjeugd.Checked
        Naam.Koppelvissen = chkkoppelvissen.Checked
        Naam.Verwijderd = chkVerwijderd.Checked

        If cboPatner.SelectedIndex > 0 Then
            Naam.Partnerid = Long.Parse(cboPatner.SelectedValue.ToString())
        End If

        Namenrepo.Save(Naam)
        If Not Naam.NaamID.HasValue
            Naam.NaamID = Naam.Id + 1000
            Namenrepo.Save(Naam)
        End If

        Close()

    End Sub

End Class