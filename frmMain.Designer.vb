<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.cboSeizoen = New System.Windows.Forms.ComboBox()
        Me.cboNaamserie = New System.Windows.Forms.ComboBox()
        Me.dgvnamen = New System.Windows.Forms.DataGridView()
        Me.txtZoeken = New System.Windows.Forms.TextBox()
        Me.btnToonalles = New System.Windows.Forms.Button()
        Me.cmsMouse = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsBewerken = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsNieuw = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsVerwijderen = New System.Windows.Forms.ToolStripMenuItem()
        Me.CboSerieVolgnummer = New System.Windows.Forms.ComboBox()
        Me.dgvUitslagen = New System.Windows.Forms.DataGridView()
        Me.lblVerhaal = New System.Windows.Forms.Label()
        Me.lblNieuwVerhaal = New System.Windows.Forms.Label()
        Me.lblUitslagid1 = New System.Windows.Forms.Label()
        Me.lblUitslagid2 = New System.Windows.Forms.Label()
        Me.lblDatumid = New System.Windows.Forms.Label()
        Me.gpVerhaalEtc = New System.Windows.Forms.GroupBox()
        Me.lblDatumtitel = New System.Windows.Forms.Label()
        Me.lblTemperatuur = New System.Windows.Forms.Label()
        Me.lblWindsnelheid = New System.Windows.Forms.Label()
        Me.lblWind = New System.Windows.Forms.Label()
        Me.lblWeeralgemeen = New System.Windows.Forms.Label()
        Me.lblLuchtdrukMB = New System.Windows.Forms.Label()
        Me.lblLocatieVissen = New System.Windows.Forms.Label()
        Me.lblNieuwTemperatuur = New System.Windows.Forms.Label()
        Me.lblNieuwWindsnelheid = New System.Windows.Forms.Label()
        Me.lblNieuwWind = New System.Windows.Forms.Label()
        Me.lblNieuwWeer = New System.Windows.Forms.Label()
        Me.lblNieuwLuchtdrukMB = New System.Windows.Forms.Label()
        Me.lblNieuwLocatievissen = New System.Windows.Forms.Label()
        Me.btnWijzigverhaal = New System.Windows.Forms.Button()
        Me.lblDatum = New System.Windows.Forms.Label()
        Me.gbNaamGewichtEtc = New System.Windows.Forms.GroupBox()
        Me.btnOpslaan = New System.Windows.Forms.Button()
        Me.txtNaam1 = New System.Windows.Forms.TextBox()
        Me.txtGewichtTotaal = New System.Windows.Forms.TextBox()
        Me.txtGewicht1 = New System.Windows.Forms.TextBox()
        Me.lblGewichtTotaal = New System.Windows.Forms.Label()
        Me.LblNaam1 = New System.Windows.Forms.Label()
        Me.txtGewicht2 = New System.Windows.Forms.TextBox()
        Me.lblGewicht = New System.Windows.Forms.Label()
        Me.txtNaam2 = New System.Windows.Forms.TextBox()
        Me.txtAantal = New System.Windows.Forms.TextBox()
        Me.lblAantal = New System.Windows.Forms.Label()
        Me.cmsUitslag = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.VerwijderenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblMelding = New System.Windows.Forms.Label()
        Me.btnKlassement = New System.Windows.Forms.Button()
        Me.btnVisser = New System.Windows.Forms.Button()
        Me.btnLoting = New System.Windows.Forms.Button()
        CType(Me.dgvnamen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsMouse.SuspendLayout()
        CType(Me.dgvUitslagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpVerhaalEtc.SuspendLayout()
        Me.gbNaamGewichtEtc.SuspendLayout()
        Me.cmsUitslag.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboSeizoen
        '
        Me.cboSeizoen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSeizoen.FormattingEnabled = True
        Me.cboSeizoen.Location = New System.Drawing.Point(15, 13)
        Me.cboSeizoen.Name = "cboSeizoen"
        Me.cboSeizoen.Size = New System.Drawing.Size(331, 32)
        Me.cboSeizoen.TabIndex = 0
        '
        'cboNaamserie
        '
        Me.cboNaamserie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNaamserie.FormattingEnabled = True
        Me.cboNaamserie.Location = New System.Drawing.Point(15, 51)
        Me.cboNaamserie.Name = "cboNaamserie"
        Me.cboNaamserie.Size = New System.Drawing.Size(258, 32)
        Me.cboNaamserie.TabIndex = 1
        '
        'dgvnamen
        '
        Me.dgvnamen.AllowUserToAddRows = False
        Me.dgvnamen.AllowUserToDeleteRows = False
        Me.dgvnamen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvnamen.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvnamen.Location = New System.Drawing.Point(13, 128)
        Me.dgvnamen.MultiSelect = False
        Me.dgvnamen.Name = "dgvnamen"
        Me.dgvnamen.RowHeadersVisible = False
        Me.dgvnamen.Size = New System.Drawing.Size(331, 496)
        Me.dgvnamen.TabIndex = 2
        '
        'txtZoeken
        '
        Me.txtZoeken.Location = New System.Drawing.Point(15, 92)
        Me.txtZoeken.Name = "txtZoeken"
        Me.txtZoeken.Size = New System.Drawing.Size(215, 30)
        Me.txtZoeken.TabIndex = 4
        '
        'btnToonalles
        '
        Me.btnToonalles.Location = New System.Drawing.Point(236, 92)
        Me.btnToonalles.Name = "btnToonalles"
        Me.btnToonalles.Size = New System.Drawing.Size(110, 30)
        Me.btnToonalles.TabIndex = 5
        Me.btnToonalles.Text = "Toon alles"
        Me.btnToonalles.UseVisualStyleBackColor = True
        '
        'cmsMouse
        '
        Me.cmsMouse.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsBewerken, Me.cmsNieuw, Me.cmsVerwijderen})
        Me.cmsMouse.Name = "cmsMouse"
        Me.cmsMouse.Size = New System.Drawing.Size(136, 70)
        '
        'cmsBewerken
        '
        Me.cmsBewerken.Name = "cmsBewerken"
        Me.cmsBewerken.Size = New System.Drawing.Size(135, 22)
        Me.cmsBewerken.Text = "Bewerken"
        '
        'cmsNieuw
        '
        Me.cmsNieuw.Name = "cmsNieuw"
        Me.cmsNieuw.Size = New System.Drawing.Size(135, 22)
        Me.cmsNieuw.Text = "Nieuw"
        '
        'cmsVerwijderen
        '
        Me.cmsVerwijderen.Name = "cmsVerwijderen"
        Me.cmsVerwijderen.Size = New System.Drawing.Size(135, 22)
        Me.cmsVerwijderen.Text = "Verwijderen"
        '
        'CboSerieVolgnummer
        '
        Me.CboSerieVolgnummer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboSerieVolgnummer.FormattingEnabled = True
        Me.CboSerieVolgnummer.Location = New System.Drawing.Point(279, 51)
        Me.CboSerieVolgnummer.Name = "CboSerieVolgnummer"
        Me.CboSerieVolgnummer.Size = New System.Drawing.Size(67, 32)
        Me.CboSerieVolgnummer.TabIndex = 6
        '
        'dgvUitslagen
        '
        Me.dgvUitslagen.AllowUserToAddRows = False
        Me.dgvUitslagen.AllowUserToDeleteRows = False
        Me.dgvUitslagen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUitslagen.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvUitslagen.Location = New System.Drawing.Point(350, 211)
        Me.dgvUitslagen.MultiSelect = False
        Me.dgvUitslagen.Name = "dgvUitslagen"
        Me.dgvUitslagen.RowHeadersVisible = False
        Me.dgvUitslagen.RowTemplate.Height = 27
        Me.dgvUitslagen.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvUitslagen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvUitslagen.Size = New System.Drawing.Size(480, 413)
        Me.dgvUitslagen.TabIndex = 17
        '
        'lblVerhaal
        '
        Me.lblVerhaal.Location = New System.Drawing.Point(836, 239)
        Me.lblVerhaal.Name = "lblVerhaal"
        Me.lblVerhaal.Size = New System.Drawing.Size(453, 496)
        Me.lblVerhaal.TabIndex = 20
        Me.lblVerhaal.Text = "Verhaal:"
        Me.lblVerhaal.Visible = False
        '
        'lblNieuwVerhaal
        '
        Me.lblNieuwVerhaal.AutoSize = True
        Me.lblNieuwVerhaal.Location = New System.Drawing.Point(836, 211)
        Me.lblNieuwVerhaal.Name = "lblNieuwVerhaal"
        Me.lblNieuwVerhaal.Size = New System.Drawing.Size(80, 24)
        Me.lblNieuwVerhaal.TabIndex = 157
        Me.lblNieuwVerhaal.Text = "Verhaal:"
        Me.lblNieuwVerhaal.Visible = False
        '
        'lblUitslagid1
        '
        Me.lblUitslagid1.AutoSize = True
        Me.lblUitslagid1.Location = New System.Drawing.Point(523, 85)
        Me.lblUitslagid1.Name = "lblUitslagid1"
        Me.lblUitslagid1.Size = New System.Drawing.Size(95, 24)
        Me.lblUitslagid1.TabIndex = 167
        Me.lblUitslagid1.Text = "Uitslagid1"
        Me.lblUitslagid1.Visible = False
        '
        'lblUitslagid2
        '
        Me.lblUitslagid2.AutoSize = True
        Me.lblUitslagid2.Location = New System.Drawing.Point(523, 117)
        Me.lblUitslagid2.Name = "lblUitslagid2"
        Me.lblUitslagid2.Size = New System.Drawing.Size(95, 24)
        Me.lblUitslagid2.TabIndex = 168
        Me.lblUitslagid2.Text = "Uitslagid2"
        Me.lblUitslagid2.Visible = False
        '
        'lblDatumid
        '
        Me.lblDatumid.AutoSize = True
        Me.lblDatumid.Location = New System.Drawing.Point(421, 85)
        Me.lblDatumid.Name = "lblDatumid"
        Me.lblDatumid.Size = New System.Drawing.Size(82, 24)
        Me.lblDatumid.TabIndex = 169
        Me.lblDatumid.Text = "Datumid"
        Me.lblDatumid.Visible = False
        '
        'gpVerhaalEtc
        '
        Me.gpVerhaalEtc.Controls.Add(Me.lblDatumtitel)
        Me.gpVerhaalEtc.Controls.Add(Me.lblTemperatuur)
        Me.gpVerhaalEtc.Controls.Add(Me.lblWindsnelheid)
        Me.gpVerhaalEtc.Controls.Add(Me.lblWind)
        Me.gpVerhaalEtc.Controls.Add(Me.lblWeeralgemeen)
        Me.gpVerhaalEtc.Controls.Add(Me.lblLuchtdrukMB)
        Me.gpVerhaalEtc.Controls.Add(Me.lblLocatieVissen)
        Me.gpVerhaalEtc.Controls.Add(Me.lblNieuwTemperatuur)
        Me.gpVerhaalEtc.Controls.Add(Me.lblNieuwWindsnelheid)
        Me.gpVerhaalEtc.Controls.Add(Me.lblNieuwWind)
        Me.gpVerhaalEtc.Controls.Add(Me.lblNieuwWeer)
        Me.gpVerhaalEtc.Controls.Add(Me.lblNieuwLuchtdrukMB)
        Me.gpVerhaalEtc.Controls.Add(Me.lblNieuwLocatievissen)
        Me.gpVerhaalEtc.Controls.Add(Me.btnWijzigverhaal)
        Me.gpVerhaalEtc.Controls.Add(Me.lblDatum)
        Me.gpVerhaalEtc.Location = New System.Drawing.Point(350, 1)
        Me.gpVerhaalEtc.Name = "gpVerhaalEtc"
        Me.gpVerhaalEtc.Size = New System.Drawing.Size(799, 207)
        Me.gpVerhaalEtc.TabIndex = 170
        Me.gpVerhaalEtc.TabStop = False
        Me.gpVerhaalEtc.Visible = False
        '
        'lblDatumtitel
        '
        Me.lblDatumtitel.AutoSize = True
        Me.lblDatumtitel.Location = New System.Drawing.Point(5, 12)
        Me.lblDatumtitel.Name = "lblDatumtitel"
        Me.lblDatumtitel.Size = New System.Drawing.Size(79, 24)
        Me.lblDatumtitel.TabIndex = 181
        Me.lblDatumtitel.Text = "Datum: "
        Me.lblDatumtitel.Visible = False
        '
        'lblTemperatuur
        '
        Me.lblTemperatuur.AutoSize = True
        Me.lblTemperatuur.Location = New System.Drawing.Point(187, 173)
        Me.lblTemperatuur.Name = "lblTemperatuur"
        Me.lblTemperatuur.Size = New System.Drawing.Size(30, 24)
        Me.lblTemperatuur.TabIndex = 180
        Me.lblTemperatuur.Text = "30"
        '
        'lblWindsnelheid
        '
        Me.lblWindsnelheid.AutoSize = True
        Me.lblWindsnelheid.Location = New System.Drawing.Point(187, 146)
        Me.lblWindsnelheid.Name = "lblWindsnelheid"
        Me.lblWindsnelheid.Size = New System.Drawing.Size(135, 24)
        Me.lblWindsnelheid.TabIndex = 179
        Me.lblWindsnelheid.Text = "Wind snelheid:"
        '
        'lblWind
        '
        Me.lblWind.AutoSize = True
        Me.lblWind.Location = New System.Drawing.Point(187, 120)
        Me.lblWind.Name = "lblWind"
        Me.lblWind.Size = New System.Drawing.Size(59, 24)
        Me.lblWind.TabIndex = 178
        Me.lblWind.Text = "Wind:"
        '
        'lblWeeralgemeen
        '
        Me.lblWeeralgemeen.AutoSize = True
        Me.lblWeeralgemeen.Location = New System.Drawing.Point(187, 93)
        Me.lblWeeralgemeen.Name = "lblWeeralgemeen"
        Me.lblWeeralgemeen.Size = New System.Drawing.Size(147, 24)
        Me.lblWeeralgemeen.TabIndex = 177
        Me.lblWeeralgemeen.Text = "Weer algemeen:"
        '
        'lblLuchtdrukMB
        '
        Me.lblLuchtdrukMB.AutoSize = True
        Me.lblLuchtdrukMB.Location = New System.Drawing.Point(187, 66)
        Me.lblLuchtdrukMB.Name = "lblLuchtdrukMB"
        Me.lblLuchtdrukMB.Size = New System.Drawing.Size(154, 24)
        Me.lblLuchtdrukMB.TabIndex = 176
        Me.lblLuchtdrukMB.Text = "Luchtdruk in MB:"
        '
        'lblLocatieVissen
        '
        Me.lblLocatieVissen.AutoSize = True
        Me.lblLocatieVissen.Location = New System.Drawing.Point(187, 39)
        Me.lblLocatieVissen.Name = "lblLocatieVissen"
        Me.lblLocatieVissen.Size = New System.Drawing.Size(135, 24)
        Me.lblLocatieVissen.TabIndex = 175
        Me.lblLocatieVissen.Text = "Locatie vissen:"
        '
        'lblNieuwTemperatuur
        '
        Me.lblNieuwTemperatuur.AutoSize = True
        Me.lblNieuwTemperatuur.Location = New System.Drawing.Point(5, 173)
        Me.lblNieuwTemperatuur.Name = "lblNieuwTemperatuur"
        Me.lblNieuwTemperatuur.Size = New System.Drawing.Size(125, 24)
        Me.lblNieuwTemperatuur.TabIndex = 173
        Me.lblNieuwTemperatuur.Text = "Temperatuur:"
        '
        'lblNieuwWindsnelheid
        '
        Me.lblNieuwWindsnelheid.AutoSize = True
        Me.lblNieuwWindsnelheid.Location = New System.Drawing.Point(5, 146)
        Me.lblNieuwWindsnelheid.Name = "lblNieuwWindsnelheid"
        Me.lblNieuwWindsnelheid.Size = New System.Drawing.Size(135, 24)
        Me.lblNieuwWindsnelheid.TabIndex = 172
        Me.lblNieuwWindsnelheid.Text = "Wind snelheid:"
        '
        'lblNieuwWind
        '
        Me.lblNieuwWind.AutoSize = True
        Me.lblNieuwWind.Location = New System.Drawing.Point(5, 120)
        Me.lblNieuwWind.Name = "lblNieuwWind"
        Me.lblNieuwWind.Size = New System.Drawing.Size(59, 24)
        Me.lblNieuwWind.TabIndex = 171
        Me.lblNieuwWind.Text = "Wind:"
        '
        'lblNieuwWeer
        '
        Me.lblNieuwWeer.AutoSize = True
        Me.lblNieuwWeer.Location = New System.Drawing.Point(5, 93)
        Me.lblNieuwWeer.Name = "lblNieuwWeer"
        Me.lblNieuwWeer.Size = New System.Drawing.Size(147, 24)
        Me.lblNieuwWeer.TabIndex = 170
        Me.lblNieuwWeer.Text = "Weer algemeen:"
        '
        'lblNieuwLuchtdrukMB
        '
        Me.lblNieuwLuchtdrukMB.AutoSize = True
        Me.lblNieuwLuchtdrukMB.Location = New System.Drawing.Point(5, 66)
        Me.lblNieuwLuchtdrukMB.Name = "lblNieuwLuchtdrukMB"
        Me.lblNieuwLuchtdrukMB.Size = New System.Drawing.Size(154, 24)
        Me.lblNieuwLuchtdrukMB.TabIndex = 169
        Me.lblNieuwLuchtdrukMB.Text = "Luchtdruk in MB:"
        '
        'lblNieuwLocatievissen
        '
        Me.lblNieuwLocatievissen.AutoSize = True
        Me.lblNieuwLocatievissen.Location = New System.Drawing.Point(5, 39)
        Me.lblNieuwLocatievissen.Name = "lblNieuwLocatievissen"
        Me.lblNieuwLocatievissen.Size = New System.Drawing.Size(135, 24)
        Me.lblNieuwLocatievissen.TabIndex = 168
        Me.lblNieuwLocatievissen.Text = "Locatie vissen:"
        '
        'btnWijzigverhaal
        '
        Me.btnWijzigverhaal.Location = New System.Drawing.Point(651, 29)
        Me.btnWijzigverhaal.Name = "btnWijzigverhaal"
        Me.btnWijzigverhaal.Size = New System.Drawing.Size(142, 33)
        Me.btnWijzigverhaal.TabIndex = 167
        Me.btnWijzigverhaal.Text = "Wijzig verhaal"
        Me.btnWijzigverhaal.UseVisualStyleBackColor = True
        '
        'lblDatum
        '
        Me.lblDatum.AutoSize = True
        Me.lblDatum.Location = New System.Drawing.Point(187, 12)
        Me.lblDatum.Name = "lblDatum"
        Me.lblDatum.Size = New System.Drawing.Size(79, 24)
        Me.lblDatum.TabIndex = 166
        Me.lblDatum.Text = "Datum: "
        Me.lblDatum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gbNaamGewichtEtc
        '
        Me.gbNaamGewichtEtc.Controls.Add(Me.btnOpslaan)
        Me.gbNaamGewichtEtc.Controls.Add(Me.txtNaam1)
        Me.gbNaamGewichtEtc.Controls.Add(Me.txtGewichtTotaal)
        Me.gbNaamGewichtEtc.Controls.Add(Me.lblUitslagid1)
        Me.gbNaamGewichtEtc.Controls.Add(Me.lblUitslagid2)
        Me.gbNaamGewichtEtc.Controls.Add(Me.lblDatumid)
        Me.gbNaamGewichtEtc.Controls.Add(Me.txtGewicht1)
        Me.gbNaamGewichtEtc.Controls.Add(Me.lblGewichtTotaal)
        Me.gbNaamGewichtEtc.Controls.Add(Me.LblNaam1)
        Me.gbNaamGewichtEtc.Controls.Add(Me.txtGewicht2)
        Me.gbNaamGewichtEtc.Controls.Add(Me.lblGewicht)
        Me.gbNaamGewichtEtc.Controls.Add(Me.txtNaam2)
        Me.gbNaamGewichtEtc.Controls.Add(Me.txtAantal)
        Me.gbNaamGewichtEtc.Controls.Add(Me.lblAantal)
        Me.gbNaamGewichtEtc.Location = New System.Drawing.Point(8, 629)
        Me.gbNaamGewichtEtc.Name = "gbNaamGewichtEtc"
        Me.gbNaamGewichtEtc.Size = New System.Drawing.Size(628, 150)
        Me.gbNaamGewichtEtc.TabIndex = 171
        Me.gbNaamGewichtEtc.TabStop = False
        Me.gbNaamGewichtEtc.Visible = False
        '
        'btnOpslaan
        '
        Me.btnOpslaan.Enabled = False
        Me.btnOpslaan.Location = New System.Drawing.Point(502, 41)
        Me.btnOpslaan.Name = "btnOpslaan"
        Me.btnOpslaan.Size = New System.Drawing.Size(105, 33)
        Me.btnOpslaan.TabIndex = 182
        Me.btnOpslaan.Text = "Opslaan"
        Me.btnOpslaan.UseVisualStyleBackColor = True
        '
        'txtNaam1
        '
        Me.txtNaam1.BackColor = System.Drawing.Color.White
        Me.txtNaam1.Location = New System.Drawing.Point(6, 43)
        Me.txtNaam1.Name = "txtNaam1"
        Me.txtNaam1.ReadOnly = True
        Me.txtNaam1.Size = New System.Drawing.Size(330, 30)
        Me.txtNaam1.TabIndex = 173
        '
        'txtGewichtTotaal
        '
        Me.txtGewichtTotaal.BackColor = System.Drawing.Color.White
        Me.txtGewichtTotaal.Enabled = False
        Me.txtGewichtTotaal.Location = New System.Drawing.Point(339, 114)
        Me.txtGewichtTotaal.Name = "txtGewichtTotaal"
        Me.txtGewichtTotaal.ReadOnly = True
        Me.txtGewichtTotaal.Size = New System.Drawing.Size(79, 30)
        Me.txtGewichtTotaal.TabIndex = 181
        '
        'txtGewicht1
        '
        Me.txtGewicht1.BackColor = System.Drawing.Color.White
        Me.txtGewicht1.Location = New System.Drawing.Point(339, 43)
        Me.txtGewicht1.Name = "txtGewicht1"
        Me.txtGewicht1.Size = New System.Drawing.Size(79, 30)
        Me.txtGewicht1.TabIndex = 172
        '
        'lblGewichtTotaal
        '
        Me.lblGewichtTotaal.AutoSize = True
        Me.lblGewichtTotaal.Location = New System.Drawing.Point(200, 117)
        Me.lblGewichtTotaal.Name = "lblGewichtTotaal"
        Me.lblGewichtTotaal.Size = New System.Drawing.Size(138, 24)
        Me.lblGewichtTotaal.TabIndex = 180
        Me.lblGewichtTotaal.Text = "Gewicht totaal"
        '
        'LblNaam1
        '
        Me.LblNaam1.AutoSize = True
        Me.LblNaam1.Location = New System.Drawing.Point(2, 15)
        Me.LblNaam1.Name = "LblNaam1"
        Me.LblNaam1.Size = New System.Drawing.Size(58, 24)
        Me.LblNaam1.TabIndex = 174
        Me.LblNaam1.Text = "Naam"
        '
        'txtGewicht2
        '
        Me.txtGewicht2.BackColor = System.Drawing.Color.White
        Me.txtGewicht2.Location = New System.Drawing.Point(339, 79)
        Me.txtGewicht2.Name = "txtGewicht2"
        Me.txtGewicht2.Size = New System.Drawing.Size(79, 30)
        Me.txtGewicht2.TabIndex = 179
        '
        'lblGewicht
        '
        Me.lblGewicht.AutoSize = True
        Me.lblGewicht.Location = New System.Drawing.Point(339, 15)
        Me.lblGewicht.Name = "lblGewicht"
        Me.lblGewicht.Size = New System.Drawing.Size(80, 24)
        Me.lblGewicht.TabIndex = 175
        Me.lblGewicht.Text = "Gewicht"
        '
        'txtNaam2
        '
        Me.txtNaam2.BackColor = System.Drawing.Color.White
        Me.txtNaam2.Location = New System.Drawing.Point(6, 79)
        Me.txtNaam2.Name = "txtNaam2"
        Me.txtNaam2.ReadOnly = True
        Me.txtNaam2.Size = New System.Drawing.Size(330, 30)
        Me.txtNaam2.TabIndex = 178
        '
        'txtAantal
        '
        Me.txtAantal.BackColor = System.Drawing.Color.White
        Me.txtAantal.Location = New System.Drawing.Point(421, 43)
        Me.txtAantal.Name = "txtAantal"
        Me.txtAantal.Size = New System.Drawing.Size(79, 30)
        Me.txtAantal.TabIndex = 176
        Me.txtAantal.Visible = False
        '
        'lblAantal
        '
        Me.lblAantal.AutoSize = True
        Me.lblAantal.Location = New System.Drawing.Point(427, 15)
        Me.lblAantal.Name = "lblAantal"
        Me.lblAantal.Size = New System.Drawing.Size(65, 24)
        Me.lblAantal.TabIndex = 177
        Me.lblAantal.Text = "Aantal"
        Me.lblAantal.Visible = False
        '
        'cmsUitslag
        '
        Me.cmsUitslag.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VerwijderenToolStripMenuItem})
        Me.cmsUitslag.Name = "cmsUitslag"
        Me.cmsUitslag.Size = New System.Drawing.Size(181, 48)
        '
        'VerwijderenToolStripMenuItem
        '
        Me.VerwijderenToolStripMenuItem.Name = "VerwijderenToolStripMenuItem"
        Me.VerwijderenToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.VerwijderenToolStripMenuItem.Text = "Verwijderen"
        '
        'lblMelding
        '
        Me.lblMelding.AutoSize = True
        Me.lblMelding.Location = New System.Drawing.Point(12, 782)
        Me.lblMelding.Name = "lblMelding"
        Me.lblMelding.Size = New System.Drawing.Size(89, 24)
        Me.lblMelding.TabIndex = 172
        Me.lblMelding.Text = "Melding: "
        '
        'btnKlassement
        '
        Me.btnKlassement.Enabled = False
        Me.btnKlassement.Location = New System.Drawing.Point(699, 635)
        Me.btnKlassement.Name = "btnKlassement"
        Me.btnKlassement.Size = New System.Drawing.Size(131, 33)
        Me.btnKlassement.TabIndex = 183
        Me.btnKlassement.Text = "Klassement"
        Me.btnKlassement.UseVisualStyleBackColor = True
        '
        'btnVisser
        '
        Me.btnVisser.Location = New System.Drawing.Point(699, 674)
        Me.btnVisser.Name = "btnVisser"
        Me.btnVisser.Size = New System.Drawing.Size(131, 33)
        Me.btnVisser.TabIndex = 184
        Me.btnVisser.Text = "Visser"
        Me.btnVisser.UseVisualStyleBackColor = True
        Me.btnVisser.Visible = False
        '
        'btnLoting
        '
        Me.btnLoting.Location = New System.Drawing.Point(699, 714)
        Me.btnLoting.Name = "btnLoting"
        Me.btnLoting.Size = New System.Drawing.Size(131, 33)
        Me.btnLoting.TabIndex = 186
        Me.btnLoting.Text = "Loting"
        Me.btnLoting.UseVisualStyleBackColor = True
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1343, 831)
        Me.Controls.Add(Me.btnLoting)
        Me.Controls.Add(Me.btnVisser)
        Me.Controls.Add(Me.btnKlassement)
        Me.Controls.Add(Me.lblMelding)
        Me.Controls.Add(Me.gbNaamGewichtEtc)
        Me.Controls.Add(Me.gpVerhaalEtc)
        Me.Controls.Add(Me.lblNieuwVerhaal)
        Me.Controls.Add(Me.lblVerhaal)
        Me.Controls.Add(Me.dgvUitslagen)
        Me.Controls.Add(Me.CboSerieVolgnummer)
        Me.Controls.Add(Me.btnToonalles)
        Me.Controls.Add(Me.txtZoeken)
        Me.Controls.Add(Me.dgvnamen)
        Me.Controls.Add(Me.cboNaamserie)
        Me.Controls.Add(Me.cboSeizoen)
        Me.Font = New System.Drawing.Font("Trebuchet MS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Name = "FrmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmMain"
        CType(Me.dgvnamen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsMouse.ResumeLayout(False)
        CType(Me.dgvUitslagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpVerhaalEtc.ResumeLayout(False)
        Me.gpVerhaalEtc.PerformLayout()
        Me.gbNaamGewichtEtc.ResumeLayout(False)
        Me.gbNaamGewichtEtc.PerformLayout()
        Me.cmsUitslag.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboSeizoen As ComboBox
    Friend WithEvents cboNaamserie As ComboBox
    Friend WithEvents dgvnamen As DataGridView
    Friend WithEvents txtZoeken As TextBox
    Friend WithEvents btnToonalles As Button
    Friend WithEvents cmsMouse As ContextMenuStrip
    Friend WithEvents cmsBewerken As ToolStripMenuItem
    Friend WithEvents cmsNieuw As ToolStripMenuItem
    Friend WithEvents cmsVerwijderen As ToolStripMenuItem
    Friend WithEvents CboSerieVolgnummer As ComboBox
    Friend WithEvents dgvUitslagen As DataGridView
    Friend WithEvents lblVerhaal As Label
    Friend WithEvents lblNieuwVerhaal As Label
    Friend WithEvents lblUitslagid1 As Label
    Friend WithEvents lblUitslagid2 As Label
    Friend WithEvents lblDatumid As Label
    Friend WithEvents gpVerhaalEtc As GroupBox
    Friend WithEvents lblDatumtitel As Label
    Friend WithEvents lblTemperatuur As Label
    Friend WithEvents lblWindsnelheid As Label
    Friend WithEvents lblWind As Label
    Friend WithEvents lblWeeralgemeen As Label
    Friend WithEvents lblLuchtdrukMB As Label
    Friend WithEvents lblLocatieVissen As Label
    Friend WithEvents lblNieuwTemperatuur As Label
    Friend WithEvents lblNieuwWindsnelheid As Label
    Friend WithEvents lblNieuwWind As Label
    Friend WithEvents lblNieuwWeer As Label
    Friend WithEvents lblNieuwLuchtdrukMB As Label
    Friend WithEvents lblNieuwLocatievissen As Label
    Friend WithEvents btnWijzigverhaal As Button
    Friend WithEvents lblDatum As Label
    Friend WithEvents gbNaamGewichtEtc As GroupBox
    Friend WithEvents btnOpslaan As Button
    Friend WithEvents txtNaam1 As TextBox
    Friend WithEvents txtGewichtTotaal As TextBox
    Friend WithEvents txtGewicht1 As TextBox
    Friend WithEvents lblGewichtTotaal As Label
    Friend WithEvents LblNaam1 As Label
    Friend WithEvents txtGewicht2 As TextBox
    Friend WithEvents lblGewicht As Label
    Friend WithEvents txtNaam2 As TextBox
    Friend WithEvents txtAantal As TextBox
    Friend WithEvents lblAantal As Label
    Friend WithEvents cmsUitslag As ContextMenuStrip
    Friend WithEvents VerwijderenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblMelding As Label
    Friend WithEvents btnKlassement As Button
    Friend WithEvents btnVisser As Button
    Friend WithEvents btnLoting As Button
End Class
