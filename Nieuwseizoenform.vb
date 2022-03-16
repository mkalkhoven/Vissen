Imports Datalaag
Imports Datalaag.Global

Public Class Nieuwseizoenform
    Private Sub btnSluiten_Click(sender As Object, e As EventArgs) Handles btnSluiten.Click
        Dispose()
    End Sub

    Private Sub btnOpslaan_Click(sender As Object, e As EventArgs) Handles btnOpslaan.Click

        If String.IsNullOrEmpty(txtseizoen.Text) Then
            Return
        End If

        Dim seizoenen = Seizoenrepo.Getsorted
        Dim id = seizoenen.First().ID + 1

        Dim seizoen = New Seizoen With {
            .Jaar = txtseizoen.Text,
            .ID = id
        }
        Seizoenrepo.Save(seizoen)
        Dispose

    End Sub
End Class