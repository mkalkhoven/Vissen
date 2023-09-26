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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtVolledigeNaam = New System.Windows.Forms.TextBox()
        Me.picFotoDeelnemer = New System.Windows.Forms.PictureBox()
        Me.btnWijzigfoto = New System.Windows.Forms.Button()
        Me.ofd = New System.Windows.Forms.OpenFileDialog()
        Me.txtNaamAfbeelding = New System.Windows.Forms.TextBox()
        Me.btnJokeren = New System.Windows.Forms.Button()
        Me.btnKlaverjassen = New System.Windows.Forms.Button()
        Me.btnVissen = New System.Windows.Forms.Button()
        Me.lblVissen = New System.Windows.Forms.Label()
        Me.chkVerwijderdtonen = New System.Windows.Forms.CheckBox()
        Me.dgvKlaverjassen = New System.Windows.Forms.DataGridView()
        Me.dgvJokeren = New System.Windows.Forms.DataGridView()
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
        Me.dgvnamen.Size = New System.Drawing.Size(1060, 757)
        Me.dgvnamen.TabIndex = 3
        '
        'btnopslaan
        '
        Me.btnopslaan.Location = New System.Drawing.Point(1220, 409)
        Me.btnopslaan.Name = "btnopslaan"
        Me.btnopslaan.Size = New System.Drawing.Size(160, 35)
        Me.btnopslaan.TabIndex = 4
        Me.btnopslaan.Text = "Opslaan"
        Me.btnopslaan.UseVisualStyleBackColor = true
        '
        'btnNieuw
        '
        Me.btnNieuw.Location = New System.Drawing.Point(1220, 450)
        Me.btnNieuw.Name = "btnNieuw"
        Me.btnNieuw.Size = New System.Drawing.Size(160, 35)
        Me.btnNieuw.TabIndex = 5
        Me.btnNieuw.Text = "Nieuw"
        Me.btnNieuw.UseVisualStyleBackColor = true
        '
        'btnSluiten
        '
        Me.btnSluiten.Location = New System.Drawing.Point(1220, 491)
        Me.btnSluiten.Name = "btnSluiten"
        Me.btnSluiten.Size = New System.Drawing.Size(160, 35)
        Me.btnSluiten.TabIndex = 6
        Me.btnSluiten.Text = "Sluiten"
        Me.btnSluiten.UseVisualStyleBackColor = true
        '
        'txtVoornaam
        '
        Me.txtVoornaam.Location = New System.Drawing.Point(1220, 54)
        Me.txtVoornaam.Name = "txtVoornaam"
        Me.txtVoornaam.Size = New System.Drawing.Size(179, 30)
        Me.txtVoornaam.TabIndex = 7
        '
        'lblVoornaam
        '
        Me.lblVoornaam.AutoSize = true
        Me.lblVoornaam.Location = New System.Drawing.Point(1078, 57)
        Me.lblVoornaam.Name = "lblVoornaam"
        Me.lblVoornaam.Size = New System.Drawing.Size(93, 24)
        Me.lblVoornaam.TabIndex = 8
        Me.lblVoornaam.Text = "Voornaam"
        '
        'chkVijftigplus
        '
        Me.chkVijftigplus.AutoSize = true
        Me.chkVijftigplus.Location = New System.Drawing.Point(1220, 198)
        Me.chkVijftigplus.Name = "chkVijftigplus"
        Me.chkVijftigplus.Size = New System.Drawing.Size(90, 28)
        Me.chkVijftigplus.TabIndex = 9
        Me.chkVijftigplus.Text = "50 Plus"
        Me.chkVijftigplus.UseVisualStyleBackColor = true
        '
        'txtTussenvoegsel
        '
        Me.txtTussenvoegsel.Location = New System.Drawing.Point(1220, 90)
        Me.txtTussenvoegsel.Name = "txtTussenvoegsel"
        Me.txtTussenvoegsel.Size = New System.Drawing.Size(179, 30)
        Me.txtTussenvoegsel.TabIndex = 10
        '
        'TxtAchternaam
        '
        Me.TxtAchternaam.Location = New System.Drawing.Point(1220, 126)
        Me.TxtAchternaam.Name = "TxtAchternaam"
        Me.TxtAchternaam.Size = New System.Drawing.Size(179, 30)
        Me.TxtAchternaam.TabIndex = 11
        '
        'lblAchternaam
        '
        Me.lblAchternaam.AutoSize = true
        Me.lblAchternaam.Location = New System.Drawing.Point(1078, 129)
        Me.lblAchternaam.Name = "lblAchternaam"
        Me.lblAchternaam.Size = New System.Drawing.Size(111, 24)
        Me.lblAchternaam.TabIndex = 12
        Me.lblAchternaam.Text = "Achternaam"
        '
        'lblTussenvoegsel
        '
        Me.lblTussenvoegsel.AutoSize = true
        Me.lblTussenvoegsel.Location = New System.Drawing.Point(1078, 93)
        Me.lblTussenvoegsel.Name = "lblTussenvoegsel"
        Me.lblTussenvoegsel.Size = New System.Drawing.Size(128, 24)
        Me.lblTussenvoegsel.TabIndex = 13
        Me.lblTussenvoegsel.Text = "Tussenvoegsel"
        '
        'chkSenioren
        '
        Me.chkSenioren.AutoSize = true
        Me.chkSenioren.Location = New System.Drawing.Point(1220, 234)
        Me.chkSenioren.Name = "chkSenioren"
        Me.chkSenioren.Size = New System.Drawing.Size(101, 28)
        Me.chkSenioren.TabIndex = 14
        Me.chkSenioren.Text = "Senioren"
        Me.chkSenioren.UseVisualStyleBackColor = true
        '
        'chkJeugd
        '
        Me.chkJeugd.AutoSize = true
        Me.chkJeugd.Location = New System.Drawing.Point(1220, 270)
        Me.chkJeugd.Name = "chkJeugd"
        Me.chkJeugd.Size = New System.Drawing.Size(79, 28)
        Me.chkJeugd.TabIndex = 15
        Me.chkJeugd.Text = "Jeugd"
        Me.chkJeugd.UseVisualStyleBackColor = true
        '
        'chkWinter
        '
        Me.chkWinter.AutoSize = true
        Me.chkWinter.Location = New System.Drawing.Point(1220, 306)
        Me.chkWinter.Name = "chkWinter"
        Me.chkWinter.Size = New System.Drawing.Size(135, 28)
        Me.chkWinter.TabIndex = 16
        Me.chkWinter.Text = "Wintervissen"
        Me.chkWinter.UseVisualStyleBackColor = true
        '
        'chkKoppelvissen
        '
        Me.chkKoppelvissen.AutoSize = true
        Me.chkKoppelvissen.Location = New System.Drawing.Point(1220, 341)
        Me.chkKoppelvissen.Name = "chkKoppelvissen"
        Me.chkKoppelvissen.Size = New System.Drawing.Size(137, 28)
        Me.chkKoppelvissen.TabIndex = 17
        Me.chkKoppelvissen.Text = "Koppelvissen"
        Me.chkKoppelvissen.UseVisualStyleBackColor = true
        '
        'chkVerwijderd
        '
        Me.chkVerwijderd.AutoSize = true
        Me.chkVerwijderd.Location = New System.Drawing.Point(1220, 377)
        Me.chkVerwijderd.Name = "chkVerwijderd"
        Me.chkVerwijderd.Size = New System.Drawing.Size(122, 28)
        Me.chkVerwijderd.TabIndex = 18
        Me.chkVerwijderd.Text = "Verwijderd"
        Me.chkVerwijderd.UseVisualStyleBackColor = true
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(1078, 165)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 24)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Volledige naam"
        '
        'txtVolledigeNaam
        '
        Me.txtVolledigeNaam.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtVolledigeNaam.Enabled = false
        Me.txtVolledigeNaam.Location = New System.Drawing.Point(1220, 162)
        Me.txtVolledigeNaam.Name = "txtVolledigeNaam"
        Me.txtVolledigeNaam.ReadOnly = true
        Me.txtVolledigeNaam.Size = New System.Drawing.Size(179, 30)
        Me.txtVolledigeNaam.TabIndex = 19
        '
        'picFotoDeelnemer
        '
        Me.picFotoDeelnemer.BackColor = System.Drawing.SystemColors.ControlLight
        Me.picFotoDeelnemer.Location = New System.Drawing.Point(1224, 606)
        Me.picFotoDeelnemer.Name = "picFotoDeelnemer"
        Me.picFotoDeelnemer.Size = New System.Drawing.Size(156, 171)
        Me.picFotoDeelnemer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picFotoDeelnemer.TabIndex = 211
        Me.picFotoDeelnemer.TabStop = false
        '
        'btnWijzigfoto
        '
        Me.btnWijzigfoto.Location = New System.Drawing.Point(1221, 566)
        Me.btnWijzigfoto.Name = "btnWijzigfoto"
        Me.btnWijzigfoto.Size = New System.Drawing.Size(160, 35)
        Me.btnWijzigfoto.TabIndex = 212
        Me.btnWijzigfoto.Text = "Wijzig foto"
        Me.btnWijzigfoto.UseVisualStyleBackColor = true
        '
        'txtNaamAfbeelding
        '
        Me.txtNaamAfbeelding.Location = New System.Drawing.Point(1082, 783)
        Me.txtNaamAfbeelding.Name = "txtNaamAfbeelding"
        Me.txtNaamAfbeelding.ReadOnly = true
        Me.txtNaamAfbeelding.Size = New System.Drawing.Size(298, 30)
        Me.txtNaamAfbeelding.TabIndex = 213
        '
        'btnJokeren
        '
        Me.btnJokeren.Location = New System.Drawing.Point(344, 12)
        Me.btnJokeren.Name = "btnJokeren"
        Me.btnJokeren.Size = New System.Drawing.Size(160, 35)
        Me.btnJokeren.TabIndex = 214
        Me.btnJokeren.Text = "Jokeren"
        Me.btnJokeren.UseVisualStyleBackColor = true
        '
        'btnKlaverjassen
        '
        Me.btnKlaverjassen.Location = New System.Drawing.Point(178, 12)
        Me.btnKlaverjassen.Name = "btnKlaverjassen"
        Me.btnKlaverjassen.Size = New System.Drawing.Size(160, 35)
        Me.btnKlaverjassen.TabIndex = 215
        Me.btnKlaverjassen.Text = "Klaverjassen"
        Me.btnKlaverjassen.UseVisualStyleBackColor = true
        '
        'btnVissen
        '
        Me.btnVissen.Location = New System.Drawing.Point(12, 12)
        Me.btnVissen.Name = "btnVissen"
        Me.btnVissen.Size = New System.Drawing.Size(160, 35)
        Me.btnVissen.TabIndex = 216
        Me.btnVissen.Text = "Vissen"
        Me.btnVissen.UseVisualStyleBackColor = true
        '
        'lblVissen
        '
        Me.lblVissen.AutoSize = true
        Me.lblVissen.Location = New System.Drawing.Point(1216, 17)
        Me.lblVissen.Name = "lblVissen"
        Me.lblVissen.Size = New System.Drawing.Size(62, 24)
        Me.lblVissen.TabIndex = 217
        Me.lblVissen.Text = "Vissen"
        '
        'chkVerwijderdtonen
        '
        Me.chkVerwijderdtonen.AutoSize = true
        Me.chkVerwijderdtonen.Location = New System.Drawing.Point(510, 16)
        Me.chkVerwijderdtonen.Name = "chkVerwijderdtonen"
        Me.chkVerwijderdtonen.Size = New System.Drawing.Size(176, 28)
        Me.chkVerwijderdtonen.TabIndex = 218
        Me.chkVerwijderdtonen.Text = "Verwijderd tonen"
        Me.chkVerwijderdtonen.UseVisualStyleBackColor = true
        Me.chkVerwijderdtonen.Visible = false
        '
        'dgvKlaverjassen
        '
        Me.dgvKlaverjassen.AllowUserToAddRows = false
        Me.dgvKlaverjassen.AllowUserToDeleteRows = false
        Me.dgvKlaverjassen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvKlaverjassen.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvKlaverjassen.Location = New System.Drawing.Point(865, 436)
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
        Me.dgvJokeren.Location = New System.Drawing.Point(865, 43)
        Me.dgvJokeren.MultiSelect = false
        Me.dgvJokeren.Name = "dgvJokeren"
        Me.dgvJokeren.RowHeadersVisible = false
        Me.dgvJokeren.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvJokeren.Size = New System.Drawing.Size(324, 387)
        Me.dgvJokeren.TabIndex = 220
        Me.dgvJokeren.Visible = false
        '
        'frmNamenbewerken
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10!, 24!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1442, 835)
        Me.Controls.Add(Me.dgvJokeren)
        Me.Controls.Add(Me.dgvKlaverjassen)
        Me.Controls.Add(Me.chkVerwijderdtonen)
        Me.Controls.Add(Me.lblVissen)
        Me.Controls.Add(Me.btnVissen)
        Me.Controls.Add(Me.btnKlaverjassen)
        Me.Controls.Add(Me.btnJokeren)
        Me.Controls.Add(Me.txtNaamAfbeelding)
        Me.Controls.Add(Me.btnWijzigfoto)
        Me.Controls.Add(Me.picFotoDeelnemer)
        Me.Controls.Add(Me.Label1)
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
        Me.Text = "frmNamenbewerken"
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
    Friend WithEvents Label1 As Label
    Friend WithEvents txtVolledigeNaam As TextBox
    Friend WithEvents picFotoDeelnemer As PictureBox
    Friend WithEvents btnWijzigfoto As Button
    Friend WithEvents ofd As OpenFileDialog
    Friend WithEvents txtNaamAfbeelding As TextBox
    Friend WithEvents btnJokeren As Button
    Friend WithEvents btnKlaverjassen As Button
    Friend WithEvents btnVissen As Button
    Friend WithEvents lblVissen As Label
    Friend WithEvents chkVerwijderdtonen As CheckBox
    Friend WithEvents dgvKlaverjassen As DataGridView
    Friend WithEvents dgvJokeren As DataGridView
End Class
