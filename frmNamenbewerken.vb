imports Datalaag.Global
Public Class frmNamenbewerken
    public naam As Datalaag.Namen = New Datalaag.Namen
    Private Sub frmNamenbewerken_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Fillgrid

    End Sub

    private sub Fillgrid

        Dim namen = Namenrepo.Get(False)

        dgvnamen.DataSource = namen

    End sub

    Private Sub btnSluiten_Click(sender As Object, e As EventArgs) Handles btnSluiten.Click

        Dispose

    End Sub

    Private Sub dgvnamen_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvnamen.CellClick

        Dim id = Selecteerid(dgvnamen, 14)
        naam = Namenrepo.Get(id)

        txtVoornaam.Text = naam.Voornaam

        chkVijftigplus.Checked = naam.Vijftigplus

    End Sub

    Private Sub btnopslaan_Click(sender As Object, e As EventArgs) Handles btnopslaan.Click

        naam.Voornaam = txtVoornaam.Text
        naam.Vijftigplus = chkVijftigplus.Checked

        Namenrepo.Save(naam)

        Fillgrid

    End Sub
End Class