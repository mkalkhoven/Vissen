<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNieuwewedstrijd
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnNieuwSluiten = New System.Windows.Forms.Button()
        Me.btnNieuwOpslaan = New System.Windows.Forms.Button()
        Me.txtNieuwVerhaal = New System.Windows.Forms.TextBox()
        Me.txtNieuwWeerAlgemeen = New System.Windows.Forms.TextBox()
        Me.txtNieuwLuchtdruk = New System.Windows.Forms.TextBox()
        Me.txtNieuwLocatievissen = New System.Windows.Forms.TextBox()
        Me.DateTimePickerNieuw = New System.Windows.Forms.DateTimePicker()
        Me.lblNieuwLocatievissen = New System.Windows.Forms.Label()
        Me.lblNieuwLuchtdrukMB = New System.Windows.Forms.Label()
        Me.lblNieuwWeer = New System.Windows.Forms.Label()
        Me.lblNieuwWind = New System.Windows.Forms.Label()
        Me.CboNieuwWindrichting = New System.Windows.Forms.ComboBox()
        Me.lblNieuwVerhaal = New System.Windows.Forms.Label()
        Me.lblNieuwWindsnelheid = New System.Windows.Forms.Label()
        Me.txtNieuwWindsnelheid = New System.Windows.Forms.TextBox()
        Me.lblNieuwTemperatuur = New System.Windows.Forms.Label()
        Me.txtNieuwTemperatuur = New System.Windows.Forms.TextBox()
        Me.lblNieuwGraden = New System.Windows.Forms.Label()
        Me.lblNieuwDatum = New System.Windows.Forms.Label()
        Me.SuspendLayout
        '
        'btnNieuwSluiten
        '
        Me.btnNieuwSluiten.Location = New System.Drawing.Point(552, 55)
        Me.btnNieuwSluiten.Name = "btnNieuwSluiten"
        Me.btnNieuwSluiten.Size = New System.Drawing.Size(119, 40)
        Me.btnNieuwSluiten.TabIndex = 4
        Me.btnNieuwSluiten.Text = "Sluiten"
        Me.btnNieuwSluiten.UseVisualStyleBackColor = true
        '
        'btnNieuwOpslaan
        '
        Me.btnNieuwOpslaan.Location = New System.Drawing.Point(552, 9)
        Me.btnNieuwOpslaan.Name = "btnNieuwOpslaan"
        Me.btnNieuwOpslaan.Size = New System.Drawing.Size(119, 40)
        Me.btnNieuwOpslaan.TabIndex = 3
        Me.btnNieuwOpslaan.Text = "Opslaan"
        Me.btnNieuwOpslaan.UseVisualStyleBackColor = true
        '
        'txtNieuwVerhaal
        '
        Me.txtNieuwVerhaal.Location = New System.Drawing.Point(323, 203)
        Me.txtNieuwVerhaal.Multiline = true
        Me.txtNieuwVerhaal.Name = "txtNieuwVerhaal"
        Me.txtNieuwVerhaal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNieuwVerhaal.Size = New System.Drawing.Size(348, 377)
        Me.txtNieuwVerhaal.TabIndex = 5
        '
        'txtNieuwWeerAlgemeen
        '
        Me.txtNieuwWeerAlgemeen.Location = New System.Drawing.Point(171, 135)
        Me.txtNieuwWeerAlgemeen.Name = "txtNieuwWeerAlgemeen"
        Me.txtNieuwWeerAlgemeen.Size = New System.Drawing.Size(500, 30)
        Me.txtNieuwWeerAlgemeen.TabIndex = 11
        '
        'txtNieuwLuchtdruk
        '
        Me.txtNieuwLuchtdruk.Location = New System.Drawing.Point(171, 99)
        Me.txtNieuwLuchtdruk.Name = "txtNieuwLuchtdruk"
        Me.txtNieuwLuchtdruk.Size = New System.Drawing.Size(59, 30)
        Me.txtNieuwLuchtdruk.TabIndex = 12
        '
        'txtNieuwLocatievissen
        '
        Me.txtNieuwLocatievissen.Location = New System.Drawing.Point(171, 63)
        Me.txtNieuwLocatievissen.Name = "txtNieuwLocatievissen"
        Me.txtNieuwLocatievissen.Size = New System.Drawing.Size(375, 30)
        Me.txtNieuwLocatievissen.TabIndex = 13
        '
        'DateTimePickerNieuw
        '
        Me.DateTimePickerNieuw.Location = New System.Drawing.Point(171, 25)
        Me.DateTimePickerNieuw.Name = "DateTimePickerNieuw"
        Me.DateTimePickerNieuw.Size = New System.Drawing.Size(302, 30)
        Me.DateTimePickerNieuw.TabIndex = 144
        '
        'lblNieuwLocatievissen
        '
        Me.lblNieuwLocatievissen.AutoSize = true
        Me.lblNieuwLocatievissen.Location = New System.Drawing.Point(12, 66)
        Me.lblNieuwLocatievissen.Name = "lblNieuwLocatievissen"
        Me.lblNieuwLocatievissen.Size = New System.Drawing.Size(135, 24)
        Me.lblNieuwLocatievissen.TabIndex = 145
        Me.lblNieuwLocatievissen.Text = "Locatie vissen:"
        '
        'lblNieuwLuchtdrukMB
        '
        Me.lblNieuwLuchtdrukMB.AutoSize = true
        Me.lblNieuwLuchtdrukMB.Location = New System.Drawing.Point(12, 102)
        Me.lblNieuwLuchtdrukMB.Name = "lblNieuwLuchtdrukMB"
        Me.lblNieuwLuchtdrukMB.Size = New System.Drawing.Size(154, 24)
        Me.lblNieuwLuchtdrukMB.TabIndex = 146
        Me.lblNieuwLuchtdrukMB.Text = "Luchtdruk in MB:"
        '
        'lblNieuwWeer
        '
        Me.lblNieuwWeer.AutoSize = true
        Me.lblNieuwWeer.Location = New System.Drawing.Point(12, 138)
        Me.lblNieuwWeer.Name = "lblNieuwWeer"
        Me.lblNieuwWeer.Size = New System.Drawing.Size(147, 24)
        Me.lblNieuwWeer.TabIndex = 147
        Me.lblNieuwWeer.Text = "Weer algemeen:"
        '
        'lblNieuwWind
        '
        Me.lblNieuwWind.AutoSize = true
        Me.lblNieuwWind.Location = New System.Drawing.Point(12, 170)
        Me.lblNieuwWind.Name = "lblNieuwWind"
        Me.lblNieuwWind.Size = New System.Drawing.Size(59, 24)
        Me.lblNieuwWind.TabIndex = 148
        Me.lblNieuwWind.Text = "Wind:"
        '
        'CboNieuwWindrichting
        '
        Me.CboNieuwWindrichting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboNieuwWindrichting.FormattingEnabled = true
        Me.CboNieuwWindrichting.Location = New System.Drawing.Point(171, 169)
        Me.CboNieuwWindrichting.Name = "CboNieuwWindrichting"
        Me.CboNieuwWindrichting.Size = New System.Drawing.Size(53, 32)
        Me.CboNieuwWindrichting.TabIndex = 149
        '
        'lblNieuwVerhaal
        '
        Me.lblNieuwVerhaal.AutoSize = true
        Me.lblNieuwVerhaal.Location = New System.Drawing.Point(323, 173)
        Me.lblNieuwVerhaal.Name = "lblNieuwVerhaal"
        Me.lblNieuwVerhaal.Size = New System.Drawing.Size(80, 24)
        Me.lblNieuwVerhaal.TabIndex = 150
        Me.lblNieuwVerhaal.Text = "Verhaal:"
        '
        'lblNieuwWindsnelheid
        '
        Me.lblNieuwWindsnelheid.AutoSize = true
        Me.lblNieuwWindsnelheid.Location = New System.Drawing.Point(12, 206)
        Me.lblNieuwWindsnelheid.Name = "lblNieuwWindsnelheid"
        Me.lblNieuwWindsnelheid.Size = New System.Drawing.Size(135, 24)
        Me.lblNieuwWindsnelheid.TabIndex = 151
        Me.lblNieuwWindsnelheid.Text = "Wind snelheid:"
        '
        'txtNieuwWindsnelheid
        '
        Me.txtNieuwWindsnelheid.Location = New System.Drawing.Point(171, 207)
        Me.txtNieuwWindsnelheid.Name = "txtNieuwWindsnelheid"
        Me.txtNieuwWindsnelheid.Size = New System.Drawing.Size(59, 30)
        Me.txtNieuwWindsnelheid.TabIndex = 152
        '
        'lblNieuwTemperatuur
        '
        Me.lblNieuwTemperatuur.AutoSize = true
        Me.lblNieuwTemperatuur.Location = New System.Drawing.Point(12, 248)
        Me.lblNieuwTemperatuur.Name = "lblNieuwTemperatuur"
        Me.lblNieuwTemperatuur.Size = New System.Drawing.Size(125, 24)
        Me.lblNieuwTemperatuur.TabIndex = 153
        Me.lblNieuwTemperatuur.Text = "Temperatuur:"
        '
        'txtNieuwTemperatuur
        '
        Me.txtNieuwTemperatuur.Location = New System.Drawing.Point(171, 246)
        Me.txtNieuwTemperatuur.Name = "txtNieuwTemperatuur"
        Me.txtNieuwTemperatuur.Size = New System.Drawing.Size(59, 30)
        Me.txtNieuwTemperatuur.TabIndex = 154
        '
        'lblNieuwGraden
        '
        Me.lblNieuwGraden.AutoSize = true
        Me.lblNieuwGraden.Location = New System.Drawing.Point(233, 248)
        Me.lblNieuwGraden.Name = "lblNieuwGraden"
        Me.lblNieuwGraden.Size = New System.Drawing.Size(71, 24)
        Me.lblNieuwGraden.TabIndex = 155
        Me.lblNieuwGraden.Text = "Graden"
        '
        'lblNieuwDatum
        '
        Me.lblNieuwDatum.AutoSize = true
        Me.lblNieuwDatum.Location = New System.Drawing.Point(12, 30)
        Me.lblNieuwDatum.Name = "lblNieuwDatum"
        Me.lblNieuwDatum.Size = New System.Drawing.Size(73, 24)
        Me.lblNieuwDatum.TabIndex = 156
        Me.lblNieuwDatum.Text = "Datum:"
        '
        'FrmNieuwewedstrijd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10!, 24!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(719, 592)
        Me.Controls.Add(Me.lblNieuwDatum)
        Me.Controls.Add(Me.lblNieuwGraden)
        Me.Controls.Add(Me.txtNieuwTemperatuur)
        Me.Controls.Add(Me.lblNieuwTemperatuur)
        Me.Controls.Add(Me.txtNieuwWindsnelheid)
        Me.Controls.Add(Me.lblNieuwWindsnelheid)
        Me.Controls.Add(Me.lblNieuwVerhaal)
        Me.Controls.Add(Me.CboNieuwWindrichting)
        Me.Controls.Add(Me.lblNieuwWind)
        Me.Controls.Add(Me.lblNieuwWeer)
        Me.Controls.Add(Me.lblNieuwLuchtdrukMB)
        Me.Controls.Add(Me.lblNieuwLocatievissen)
        Me.Controls.Add(Me.DateTimePickerNieuw)
        Me.Controls.Add(Me.txtNieuwLocatievissen)
        Me.Controls.Add(Me.txtNieuwLuchtdruk)
        Me.Controls.Add(Me.txtNieuwWeerAlgemeen)
        Me.Controls.Add(Me.txtNieuwVerhaal)
        Me.Controls.Add(Me.btnNieuwSluiten)
        Me.Controls.Add(Me.btnNieuwOpslaan)
        Me.Font = New System.Drawing.Font("Trebuchet MS", 14.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "FrmNieuwewedstrijd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmNieuwewedstrijd"
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents btnNieuwSluiten As Button
    Friend WithEvents btnNieuwOpslaan As Button
    Friend WithEvents txtNieuwVerhaal As TextBox
    Friend WithEvents txtNieuwWeerAlgemeen As TextBox
    Friend WithEvents txtNieuwLuchtdruk As TextBox
    Friend WithEvents txtNieuwLocatievissen As TextBox
    Friend WithEvents DateTimePickerNieuw As DateTimePicker
    Friend WithEvents lblNieuwLocatievissen As Label
    Friend WithEvents lblNieuwLuchtdrukMB As Label
    Friend WithEvents lblNieuwWeer As Label
    Friend WithEvents lblNieuwWind As Label
    Friend WithEvents CboNieuwWindrichting As ComboBox
    Friend WithEvents lblNieuwVerhaal As Label
    Friend WithEvents lblNieuwWindsnelheid As Label
    Friend WithEvents txtNieuwWindsnelheid As TextBox
    Friend WithEvents lblNieuwTemperatuur As Label
    Friend WithEvents txtNieuwTemperatuur As TextBox
    Friend WithEvents lblNieuwGraden As Label
    Friend WithEvents lblNieuwDatum As Label
End Class
