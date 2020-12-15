Imports Datalaag
Imports Datalaag.Global
Public Class FrmNieuwewedstrijd
    public Datum As New DatumWeerEtc
    public Serie As New NaamSerie
    public Seizoen As New Seizoen
    public Nummer As Long
    Private Sub frmNieuwewedstrijd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
        Icon = FrmMain.Icon

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
            Else 
                FrmMain.dgvnamen.Enabled=false
        End If

    End Sub

    Private Sub btnSluiten_Click(sender As Object, e As EventArgs) Handles btnNieuwSluiten.Click
        Close()
    End Sub

    Private Sub btnOpslaan_Click(sender As Object, e As EventArgs) Handles btnNieuwOpslaan.Click

        If txtNieuwLocatievissen.text ="" Then txtNieuwLocatievissen.text = "?":txtNieuwLocatievissen.Focus(): Return 
        If txtNieuwLuchtdruk.text = "" Then txtNieuwLuchtdruk.text = "?": txtNieuwLuchtdruk.Focus(): Return
        if txtNieuwWeerAlgemeen.text = "" Then txtNieuwWeerAlgemeen.text = "?": txtNieuwWeerAlgemeen.Focus(): Return
        If txtNieuwWindsnelheid.text = "" Then txtNieuwWindsnelheid.text = "?": txtNieuwWindsnelheid.Focus():  Return	
        if txtNieuwTemperatuur.text	= "" Then txtNieuwTemperatuur.text	= "?": txtNieuwTemperatuur.Focus(): Return
        If txtNieuwVerhaal.text = "" then txtNieuwVerhaal.text = "?": txtNieuwVerhaal.Focus(): Return

        Datum = New DatumWeerEtc With {
            .IDseizoen = Seizoen.ID,
            .IDserieNummer = Serie.Id,
            .SerieNaamNr = nummer,
            .Plaats = txtNieuwLocatievissen.text,
            .MB = txtNieuwLuchtdruk.text,
            .Wind = CboNieuwWindrichting.text,
            .WindSnelheid = txtNieuwWindsnelheid.text,
            .Temp = txtNieuwTemperatuur.text,
            .Datum = DateTimePickerNieuw.text,
            .Weer = txtNieuwWeerAlgemeen.text,
            .Verhaal = txtNieuwVerhaal.text
        }
        Datum.ID = Datumweeretcrepo.Getid()
        Datumweeretcrepo.Save(Datum)
        Close()
        
    End Sub

    Private Sub DateTimePickerNieuw_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerNieuw.ValueChanged
        
    End Sub

End Class