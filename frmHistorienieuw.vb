Imports Datalaag.Global
Public Class frmHistorienieuw
    Public Loting As Datalaag.Loting2
    Private Sub btnSluiten_Click(sender As Object, e As EventArgs) Handles btnSluiten.Click
        Dispose()
    End Sub

    Private Sub btnOpslaan_Click(sender As Object, e As EventArgs) Handles btnOpslaan.Click

        If String.IsNullOrEmpty(txtPlaats.Text) Then
            Return
        End If

        Dim naam As Datalaag.Namen = cboNamen.SelectedItem
        Loting.Naamid = naam.NaamID
        Loting.Plaats = Long.Parse(txtPlaats.Text)
        Lotingrepo.Save(Loting)
        Dispose()

    End Sub

    Private Sub frmHistorienieuw_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Vulcombo()

    End Sub

    Private Sub Vulcombo()

        Dim Namen As New List(Of Datalaag.Namen)

        Select Case Loting.Serieid
            Case 1, 2, 3
                Namen = Namenrepo.Getbytype(Vistype.Senioren)
            Case 5
                Namen = Namenrepo.Getbytype(Vistype.Senioren)
            Case 6
                Namen = Namenrepo.Getbytype(Vistype.Vijftigplus)
            Case 9, 10, 11
                Namen = Namenrepo.Getbytype(Vistype.Winter)
            Case 12, 13
                Namen = Namenrepo.Getbytype(Vistype.Jeugd)
            Case 15, 17
                Namen = Namenrepo.Getbytype(Vistype.Nachtvissen)
        End Select

        'If Alles Then
        '    'Alle overige namen toevoegen aan selectie

        'Else
        '    Dim naam As New Datalaag.Namen
        '    naam.NaamID = 0
        '    naam.Naam = "Alle namen selecteren"
        '    Namen.Insert(0, naam)
        'End If
        cboNamen.DataSource = Namen
        cboNamen.ValueMember = "Naamid"
        cboNamen.DisplayMember = "Naam"

    End Sub
End Class