Imports Datalaag
Imports Datalaag.Global
Imports Datalaag.Database
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

        'Eerst controleren of datum icm serie bestaat in DeRuisvoorn.Agenda
        If Controleervisdatum(DateTimePickerNieuw.Value.Date, Serie.Id) = False Then
            Toonmelding("Geen geldige datum gevonden in De Ruisvoorn Agenda")
            Exit Sub
        End If

        If txtNieuwLocatievissen.Text = "" Then txtNieuwLocatievissen.Text = "?" : txtNieuwLocatievissen.Focus() : Return
        If Not IsNumeric(txtNieuwLuchtdruk.text) Then txtNieuwLuchtdruk.text = "0": txtNieuwLuchtdruk.Focus(): Return
        if txtNieuwWeerAlgemeen.text = "" Then txtNieuwWeerAlgemeen.text = "?": txtNieuwWeerAlgemeen.Focus(): Return
        If txtNieuwWindsnelheid.text = "" Then txtNieuwWindsnelheid.text = "?": txtNieuwWindsnelheid.Focus():  Return	
        if txtNieuwTemperatuur.text	= "" Then txtNieuwTemperatuur.text	= "?": txtNieuwTemperatuur.Focus(): Return
        If txtNieuwVerhaal.text = "" then txtNieuwVerhaal.text = "?": txtNieuwVerhaal.Focus(): Return

        If Datum.ID = 0 Then
            Datum = New DatumWeerEtc With {
                .IDseizoen = Seizoen.ID,
                .IDserieNummer = Nummer,
                .SerieNaamNr = Serie.Id,
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
        Else 
            Datum.Plaats = txtNieuwLocatievissen.text
            Datum.MB = txtNieuwLuchtdruk.text
            Datum.Wind = CboNieuwWindrichting.text
            Datum.WindSnelheid = txtNieuwWindsnelheid.text
            Datum.Temp = txtNieuwTemperatuur.text
            Datum.Datum = DateTimePickerNieuw.text
            Datum.Weer = txtNieuwWeerAlgemeen.text
            Datum.Verhaal = txtNieuwVerhaal.text
        end If

        Try
            Datumweeretcrepo.Save(Datum)
        Catch ex As Exception
            MessageBox.Show(ex.InnerException.ToString)
        End Try
        Close()
        
    End Sub

    Private Sub DateTimePickerNieuw_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerNieuw.ValueChanged
        
    End Sub

End Class