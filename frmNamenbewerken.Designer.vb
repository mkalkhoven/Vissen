<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNamenbewerken
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
        Me.dgvnamen = New System.Windows.Forms.DataGridView()
        Me.btnopslaan = New System.Windows.Forms.Button()
        Me.btnNieuw = New System.Windows.Forms.Button()
        Me.btnSluiten = New System.Windows.Forms.Button()
        Me.txtVoornaam = New System.Windows.Forms.TextBox()
        Me.lblVoornaam = New System.Windows.Forms.Label()
        Me.chkVijftigplus = New System.Windows.Forms.CheckBox()
        Me.txtTussenvoegsel = New System.Windows.Forms.TextBox()
        Me.TxtAchternaam = New System.Windows.Forms.TextBox()
        Me.lblAchternaam = New System.Windows.Forms.Label()
        Me.lblTussenvoegsel = New System.Windows.Forms.Label()
        Me.chkSenioren = New System.Windows.Forms.CheckBox()
        Me.chkJeugd = New System.Windows.Forms.CheckBox()
        Me.chkWinter = New System.Windows.Forms.CheckBox()
        Me.chkKoppelvissen = New System.Windows.Forms.CheckBox()
        Me.chkVerwijderd = New System.Windows.Forms.CheckBox()
        Me.lblVolledigeNaam = New System.Windows.Forms.Label()
        Me.txtVolledigeNaam = New System.Windows.Forms.TextBox()
        Me.picFotoDeelnemer = New System.Windows.Forms.PictureBox()
        Me.btnWijzigfoto = New System.Windows.Forms.Button()
        Me.ofd = New System.Windows.Forms.OpenFileDialog()
        Me.txtNaamAfbeelding = New System.Windows.Forms.TextBox()
        Me.btnJokeren = New System.Windows.Forms.Button()
        Me.btnKlaverjassen = New System.Windows.Forms.Button()
        Me.btnVissen = New System.Windows.Forms.Button()
        Me.lblVissen = New System.Windows.Forms.Label()
        Me.dgvKlaverjassen = New System.Windows.Forms.DataGridView()
        Me.dgvJokeren = New System.Windows.Forms.DataGridView()
        Me.txtZoeken = New System.Windows.Forms.TextBox()
        Me.chkVerwijderdeleden = New System.Windows.Forms.CheckBox()
        Me.cboSerie = New System.Windows.Forms.ComboBox()
        Me.lblTotaal = New System.Windows.Forms.Label()
        Me.txtTotaal = New System.Windows.Forms.TextBox()
        Me.btnVerwijderdHeleNaam = New System.Windows.Forms.Button()
        CType(Me.dgvnamen,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.picFotoDeelnemer,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.dgvKlaverjassen,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.dgvJokeren,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'dgvnamen
        '
        Me.dgvnamen.AllowUserToAddRows = false
        Me.dgvnamen.AllowUserToDeleteRows = false
        Me.dgvnamen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvnamen.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvnamen.Location = New System.Drawing.Point(12, 56)
        Me.dgvnamen.MultiSelect = false
        Me.dgvnamen.Name = "dgvnamen"
        Me.dgvnamen.RowHeadersVisible = false
        Me.dgvnamen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvnamen.Size = New System.Drawing.Size(630, 757)
        Me.dgvnamen.TabIndex = 3
        '
        'btnopslaan
        '
        Me.btnopslaan.Location = New System.Drawing.Point(824, 430)
        Me.btnopslaan.Name = "btnopslaan"
        Me.btnopslaan.Size = New System.Drawing.Size(160, 35)
        Me.btnopslaan.TabIndex = 4
        Me.btnopslaan.Text = "Opslaan"
        Me.btnopslaan.UseVisualStyleBackColor = true
        '
        'btnNieuw
        '
        Me.btnNieuw.Location = New System.Drawing.Point(824, 470)
        Me.btnNieuw.Name = "btnNieuw"
        Me.btnNieuw.Size = New System.Drawing.Size(160, 35)
        Me.btnNieuw.TabIndex = 5
        Me.btnNieuw.Text = "Nieuw"
        Me.btnNieuw.UseVisualStyleBackColor = true
        '
        'btnSluiten
        '
        Me.btnSluiten.Location = New System.Drawing.Point(824, 510)
        Me.btnSluiten.Name = "btnSluiten"
        Me.btnSluiten.Size = New System.Drawing.Size(160, 35)
        Me.btnSluiten.TabIndex = 6
        Me.btnSluiten.Text = "Sluiten"
        Me.btnSluiten.UseVisualStyleBackColor = true
        '
        'txtVoornaam
        '
        Me.txtVoornaam.Location = New System.Drawing.Point(824, 95)
        Me.txtVoornaam.Name = "txtVoornaam"
        Me.txtVoornaam.Size = New System.Drawing.Size(179, 30)
        Me.txtVoornaam.TabIndex = 7
        '
        'lblVoornaam
        '
        Me.lblVoornaam.AutoSize = true
        Me.lblVoornaam.Location = New System.Drawing.Point(682, 95)
        Me.lblVoornaam.Name = "lblVoornaam"
        Me.lblVoornaam.Size = New System.Drawing.Size(93, 24)
        Me.lblVoornaam.TabIndex = 8
        Me.lblVoornaam.Text = "Voornaam"
        '
        'chkVijftigplus
        '
        Me.chkVijftigplus.AutoSize = true
        Me.chkVijftigplus.Location = New System.Drawing.Point(824, 245)
        Me.chkVijftigplus.Name = "chkVijftigplus"
        Me.chkVijftigplus.Size = New System.Drawing.Size(90, 28)
        Me.chkVijftigplus.TabIndex = 9
        Me.chkVijftigplus.Text = "50 Plus"
        Me.chkVijftigplus.UseVisualStyleBackColor = true
        '
        'txtTussenvoegsel
        '
        Me.txtTussenvoegsel.Location = New System.Drawing.Point(824, 130)
        Me.txtTussenvoegsel.Name = "txtTussenvoegsel"
        Me.txtTussenvoegsel.Size = New System.Drawing.Size(179, 30)
        Me.txtTussenvoegsel.TabIndex = 10
        '
        'TxtAchternaam
        '
        Me.TxtAchternaam.Location = New System.Drawing.Point(824, 165)
        Me.TxtAchternaam.Name = "TxtAchternaam"
        Me.TxtAchternaam.Size = New System.Drawing.Size(179, 30)
        Me.TxtAchternaam.TabIndex = 11
        '
        'lblAchternaam
        '
        Me.lblAchternaam.AutoSize = true
        Me.lblAchternaam.Location = New System.Drawing.Point(682, 165)
        Me.lblAchternaam.Name = "lblAchternaam"
        Me.lblAchternaam.Size = New System.Drawing.Size(111, 24)
        Me.lblAchternaam.TabIndex = 12
        Me.lblAchternaam.Text = "Achternaam"
        '
        'lblTussenvoegsel
        '
        Me.lblTussenvoegsel.AutoSize = true
        Me.lblTussenvoegsel.Location = New System.Drawing.Point(682, 130)
        Me.lblTussenvoegsel.Name = "lblTussenvoegsel"
        Me.lblTussenvoegsel.Size = New System.Drawing.Size(128, 24)
        Me.lblTussenvoegsel.TabIndex = 13
        Me.lblTussenvoegsel.Text = "Tussenvoegsel"
        '
        'chkSenioren
        '
        Me.chkSenioren.AutoSize = true
        Me.chkSenioren.Location = New System.Drawing.Point(824, 275)
        Me.chkSenioren.Name = "chkSenioren"
        Me.chkSenioren.Size = New System.Drawing.Size(101, 28)
        Me.chkSenioren.TabIndex = 14
        Me.chkSenioren.Text = "Senioren"
        Me.chkSenioren.UseVisualStyleBackColor = true
        '
        'chkJeugd
        '
        Me.chkJeugd.AutoSize = true
        Me.chkJeugd.Location = New System.Drawing.Point(824, 305)
        Me.chkJeugd.Name = "chkJeugd"
        Me.chkJeugd.Size = New System.Drawing.Size(79, 28)
        Me.chkJeugd.TabIndex = 15
        Me.chkJeugd.Text = "Jeugd"
        Me.chkJeugd.UseVisualStyleBackColor = true
        '
        'chkWinter
        '
        Me.chkWinter.AutoSize = true
        Me.chkWinter.Location = New System.Drawing.Point(824, 335)
        Me.chkWinter.Name = "chkWinter"
        Me.chkWinter.Size = New System.Drawing.Size(135, 28)
        Me.chkWinter.TabIndex = 16
        Me.chkWinter.Text = "Wintervissen"
        Me.chkWinter.UseVisualStyleBackColor = true
        '
        'chkKoppelvissen
        '
        Me.chkKoppelvissen.AutoSize = true
        Me.chkKoppelvissen.Location = New System.Drawing.Point(824, 365)
        Me.chkKoppelvissen.Name = "chkKoppelvissen"
        Me.chkKoppelvissen.Size = New System.Drawing.Size(137, 28)
        Me.chkKoppelvissen.TabIndex = 17
        Me.chkKoppelvissen.Text = "Koppelvissen"
        Me.chkKoppelvissen.UseVisualStyleBackColor = true
        '
        'chkVerwijderd
        '
        Me.chkVerwijderd.AutoSize = true
        Me.chkVerwijderd.Location = New System.Drawing.Point(824, 395)
        Me.chkVerwijderd.Name = "chkVerwijderd"
        Me.chkVerwijderd.Size = New System.Drawing.Size(111, 28)
        Me.chkVerwijderd.TabIndex = 18
        Me.chkVerwijderd.Text = "Verwijder"
        Me.chkVerwijderd.UseVisualStyleBackColor = true
        '
        'lblVolledigeNaam
        '
        Me.lblVolledigeNaam.AutoSize = true
        Me.lblVolledigeNaam.Location = New System.Drawing.Point(682, 200)
        Me.lblVolledigeNaam.Name = "lblVolledigeNaam"
        Me.lblVolledigeNaam.Size = New System.Drawing.Size(140, 24)
        Me.lblVolledigeNaam.TabIndex = 20
        Me.lblVolledigeNaam.Text = "Volledige naam"
        '
        'txtVolledigeNaam
        '
        Me.txtVolledigeNaam.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtVolledigeNaam.Location = New System.Drawing.Point(824, 200)
        Me.txtVolledigeNaam.Name = "txtVolledigeNaam"
        Me.txtVolledigeNaam.ReadOnly = true
        Me.txtVolledigeNaam.Size = New System.Drawing.Size(276, 30)
        Me.txtVolledigeNaam.TabIndex = 19
        '
        'picFotoDeelnemer
        '
        Me.picFotoDeelnemer.BackColor = System.Drawing.SystemColors.ControlLight
        Me.picFotoDeelnemer.Enabled = false
        Me.picFotoDeelnemer.Location = New System.Drawing.Point(824, 594)
        Me.picFotoDeelnemer.Name = "picFotoDeelnemer"
        Me.picFotoDeelnemer.Size = New System.Drawing.Size(159, 172)
        Me.picFotoDeelnemer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picFotoDeelnemer.TabIndex = 211
        Me.picFotoDeelnemer.TabStop = false
        '
        'btnWijzigfoto
        '
        Me.btnWijzigfoto.Location = New System.Drawing.Point(824, 550)
        Me.btnWijzigfoto.Name = "btnWijzigfoto"
        Me.btnWijzigfoto.Size = New System.Drawing.Size(160, 35)
        Me.btnWijzigfoto.TabIndex = 212
        Me.btnWijzigfoto.Text = "Wijzig foto"
        Me.btnWijzigfoto.UseVisualStyleBackColor = true
        '
        'txtNaamAfbeelding
        '
        Me.txtNaamAfbeelding.Enabled = false
        Me.txtNaamAfbeelding.Location = New System.Drawing.Point(824, 774)
        Me.txtNaamAfbeelding.Name = "txtNaamAfbeelding"
        Me.txtNaamAfbeelding.ReadOnly = true
        Me.txtNaamAfbeelding.Size = New System.Drawing.Size(393, 30)
        Me.txtNaamAfbeelding.TabIndex = 213
        '
        'btnJokeren
        '
        Me.btnJokeren.Location = New System.Drawing.Point(261, 12)
        Me.btnJokeren.Name = "btnJokeren"
        Me.btnJokeren.Size = New System.Drawing.Size(110, 35)
        Me.btnJokeren.TabIndex = 214
        Me.btnJokeren.Text = "Jokeren"
        Me.btnJokeren.UseVisualStyleBackColor = true
        '
        'btnKlaverjassen
        '
        Me.btnKlaverjassen.Location = New System.Drawing.Point(129, 12)
        Me.btnKlaverjassen.Name = "btnKlaverjassen"
        Me.btnKlaverjassen.Size = New System.Drawing.Size(126, 35)
        Me.btnKlaverjassen.TabIndex = 215
        Me.btnKlaverjassen.Text = "Klaverjassen"
        Me.btnKlaverjassen.UseVisualStyleBackColor = true
        '
        'btnVissen
        '
        Me.btnVissen.Font = New System.Drawing.Font("Trebuchet MS", 14.25!)
        Me.btnVissen.ForeColor = System.Drawing.Color.Black
        Me.btnVissen.Location = New System.Drawing.Point(12, 12)
        Me.btnVissen.Name = "btnVissen"
        Me.btnVissen.Size = New System.Drawing.Size(111, 35)
        Me.btnVissen.TabIndex = 216
        Me.btnVissen.Text = "Vissen"
        Me.btnVissen.UseVisualStyleBackColor = true
        '
        'lblVissen
        '
        Me.lblVissen.AutoSize = true
        Me.lblVissen.Font = New System.Drawing.Font("Trebuchet MS", 36!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblVissen.ForeColor = System.Drawing.Color.DarkRed
        Me.lblVissen.Location = New System.Drawing.Point(813, -4)
        Me.lblVissen.Name = "lblVissen"
        Me.lblVissen.Size = New System.Drawing.Size(158, 61)
        Me.lblVissen.TabIndex = 217
        Me.lblVissen.Text = "Vissen"
        '
        'dgvKlaverjassen
        '
        Me.dgvKlaverjassen.AllowUserToAddRows = false
        Me.dgvKlaverjassen.AllowUserToDeleteRows = false
        Me.dgvKlaverjassen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvKlaverjassen.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvKlaverjassen.Location = New System.Drawing.Point(129, 235)
        Me.dgvKlaverjassen.MultiSelect = false
        Me.dgvKlaverjassen.Name = "dgvKlaverjassen"
        Me.dgvKlaverjassen.RowHeadersVisible = false
        Me.dgvKlaverjassen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvKlaverjassen.Size = New System.Drawing.Size(324, 387)
        Me.dgvKlaverjassen.TabIndex = 219
        Me.dgvKlaverjassen.Visible = false
        '
        'dgvJokeren
        '
        Me.dgvJokeren.AllowUserToAddRows = false
        Me.dgvJokeren.AllowUserToDeleteRows = false
        Me.dgvJokeren.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvJokeren.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvJokeren.Location = New System.Drawing.Point(185, 275)
        Me.dgvJokeren.MultiSelect = false
        Me.dgvJokeren.Name = "dgvJokeren"
        Me.dgvJokeren.RowHeadersVisible = false
        Me.dgvJokeren.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvJokeren.Size = New System.Drawing.Size(324, 387)
        Me.dgvJokeren.TabIndex = 220
        Me.dgvJokeren.Visible = false
        '
        'txtZoeken
        '
        Me.txtZoeken.Location = New System.Drawing.Point(377, 15)
        Me.txtZoeken.Name = "txtZoeken"
        Me.txtZoeken.Size = New System.Drawing.Size(96, 30)
        Me.txtZoeken.TabIndex = 222
        '
        'chkVerwijderdeleden
        '
        Me.chkVerwijderdeleden.AutoSize = true
        Me.chkVerwijderdeleden.Location = New System.Drawing.Point(620, 19)
        Me.chkVerwijderdeleden.Name = "chkVerwijderdeleden"
        Me.chkVerwijderdeleden.Size = New System.Drawing.Size(132, 28)
        Me.chkVerwijderdeleden.TabIndex = 224
        Me.chkVerwijderdeleden.Text = "Verwijderde"
        Me.chkVerwijderdeleden.UseVisualStyleBackColor = true
        '
        'cboSerie
        '
        Me.cboSerie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSerie.FormattingEnabled = true
        Me.cboSerie.Location = New System.Drawing.Point(479, 14)
        Me.cboSerie.Name = "cboSerie"
        Me.cboSerie.Size = New System.Drawing.Size(135, 32)
        Me.cboSerie.TabIndex = 225
        Me.cboSerie.Visible = false
        '
        'lblTotaal
        '
        Me.lblTotaal.AutoSize = true
        Me.lblTotaal.Location = New System.Drawing.Point(682, 60)
        Me.lblTotaal.Name = "lblTotaal"
        Me.lblTotaal.Size = New System.Drawing.Size(63, 24)
        Me.lblTotaal.TabIndex = 227
        Me.lblTotaal.Text = "Totaal"
        '
        'txtTotaal
        '
        Me.txtTotaal.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtTotaal.Location = New System.Drawing.Point(824, 60)
        Me.txtTotaal.Name = "txtTotaal"
        Me.txtTotaal.ReadOnly = true
        Me.txtTotaal.Size = New System.Drawing.Size(59, 30)
        Me.txtTotaal.TabIndex = 228
        '
        'btnVerwijderdHeleNaam
        '
        Me.btnVerwijderdHeleNaam.Location = New System.Drawing.Point(989, 731)
        Me.btnVerwijderdHeleNaam.Name = "btnVerwijderdHeleNaam"
        Me.btnVerwijderdHeleNaam.Size = New System.Drawing.Size(228, 35)
        Me.btnVerwijderdHeleNaam.TabIndex = 229
        Me.btnVerwijderdHeleNaam.Text = "Verwijder hele naam"
        Me.btnVerwijderdHeleNaam.UseVisualStyleBackColor = true
        '
        'frmNamenbewerken
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10!, 24!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1222, 835)
        Me.Controls.Add(Me.btnVerwijderdHeleNaam)
        Me.Controls.Add(Me.txtTotaal)
        Me.Controls.Add(Me.lblTotaal)
        Me.Controls.Add(Me.cboSerie)
        Me.Controls.Add(Me.chkVerwijderdeleden)
        Me.Controls.Add(Me.txtZoeken)
        Me.Controls.Add(Me.dgvJokeren)
        Me.Controls.Add(Me.dgvKlaverjassen)
        Me.Controls.Add(Me.lblVissen)
        Me.Controls.Add(Me.btnVissen)
        Me.Controls.Add(Me.btnKlaverjassen)
        Me.Controls.Add(Me.btnJokeren)
        Me.Controls.Add(Me.txtNaamAfbeelding)
        Me.Controls.Add(Me.btnWijzigfoto)
        Me.Controls.Add(Me.picFotoDeelnemer)
        Me.Controls.Add(Me.lblVolledigeNaam)
        Me.Controls.Add(Me.txtVolledigeNaam)
        Me.Controls.Add(Me.chkVerwijderd)
        Me.Controls.Add(Me.chkKoppelvissen)
        Me.Controls.Add(Me.chkWinter)
        Me.Controls.Add(Me.chkJeugd)
        Me.Controls.Add(Me.chkSenioren)
        Me.Controls.Add(Me.lblTussenvoegsel)
        Me.Controls.Add(Me.lblAchternaam)
        Me.Controls.Add(Me.TxtAchternaam)
        Me.Controls.Add(Me.txtTussenvoegsel)
        Me.Controls.Add(Me.chkVijftigplus)
        Me.Controls.Add(Me.lblVoornaam)
        Me.Controls.Add(Me.txtVoornaam)
        Me.Controls.Add(Me.btnSluiten)
        Me.Controls.Add(Me.btnNieuw)
        Me.Controls.Add(Me.btnopslaan)
        Me.Controls.Add(Me.dgvnamen)
        Me.Font = New System.Drawing.Font("Trebuchet MS", 14.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmNamenbewerken"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "  "
        CType(Me.dgvnamen,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.picFotoDeelnemer,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.dgvKlaverjassen,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.dgvJokeren,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents dgvnamen As DataGridView
    Friend WithEvents btnopslaan As Button
    Friend WithEvents btnNieuw As Button
    Friend WithEvents btnSluiten As Button
    Friend WithEvents txtVoornaam As TextBox
    Friend WithEvents lblVoornaam As Label
    Friend WithEvents chkVijftigplus As CheckBox
    Friend WithEvents txtTussenvoegsel As TextBox
    Friend WithEvents TxtAchternaam As TextBox
    Friend WithEvents lblAchternaam As Label
    Friend WithEvents lblTussenvoegsel As Label
    Friend WithEvents chkSenioren As CheckBox
    Friend WithEvents chkJeugd As CheckBox
    Friend WithEvents chkWinter As CheckBox
    Friend WithEvents chkKoppelvissen As CheckBox
    Friend WithEvents chkVerwijderd As CheckBox
    Friend WithEvents lblVolledigeNaam As Label
    Friend WithEvents txtVolledigeNaam As TextBox
    Friend WithEvents picFotoDeelnemer As PictureBox
    Friend WithEvents btnWijzigfoto As Button
    Friend WithEvents ofd As OpenFileDialog
    Friend WithEvents txtNaamAfbeelding As TextBox
    Friend WithEvents btnJokeren As Button
    Friend WithEvents btnKlaverjassen As Button
    Friend WithEvents btnVissen As Button
    Friend WithEvents lblVissen As Label
    Friend WithEvents dgvKlaverjassen As DataGridView
    Friend WithEvents dgvJokeren As DataGridView
    Friend WithEvents txtZoeken As TextBox
    Friend WithEvents chkVerwijderdeleden As CheckBox
    Friend WithEvents cboSerie As ComboBox
    Friend WithEvents lblTotaal As Label
    Friend WithEvents txtTotaal As TextBox
    Friend WithEvents btnVerwijderdHeleNaam As Button
End Class
