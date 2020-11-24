Imports Datalaag
Imports Datalaag.Global
Public Class FrmNieuwewedstrijd
    public Dim Datum As New DatumWeerEtc
    Private Sub frmNieuwewedstrijd_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim wind = Windrepo.Get()
        CboNieuwWindrichting.DataSource = wind
        'CboNieuwWindrichting.ValueMember = "ID"
        CboNieuwWindrichting.DisplayMember = "Wind1"


        If Datum.ID > 0 Then
            txtNieuwLocatievissen.text = Datum.Plaats
            txtNieuwLuchtdruk.text = Datum.MB
            CboNieuwWindrichting.text = Datum.Wind
            txtNieuwWindsnelheid.text = Datum.WindSnelheid
            txtNieuwTemperatuur.text = Datum.Temp
            DateTimePickerNieuw.text = Datum.Datum
            txtNieuwWeerAlgemeen.text = Datum.Weer
            txtNieuwVerhaal.text = Datum.Verhaal
        End If

    End Sub

    Private Sub btnSluiten_Click(sender As Object, e As EventArgs) Handles btnNieuwSluiten.Click
        Close()
    End Sub

    Private Sub btnOpslaan_Click(sender As Object, e As EventArgs) Handles btnNieuwOpslaan.Click

        Datum.Plaats = txtNieuwLocatievissen.text
        Datum.MB = txtNieuwLuchtdruk.text
        Datum.Wind = CboNieuwWindrichting.text	
        Datum.WindSnelheid = txtNieuwWindsnelheid.text	
        Datum.Temp = txtNieuwTemperatuur.text	
        Datum.Datum	= DateTimePickerNieuw.text
        Datum.Weer= txtNieuwWeerAlgemeen.text
        Datum.Verhaal = txtNieuwVerhaal.text

        Datumweeretcrepo.Save(Datum)

        Close()
        
    End Sub

    Private Sub DateTimePickerNieuw_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerNieuw.ValueChanged
        
    End Sub

End Class