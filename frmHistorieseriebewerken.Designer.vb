<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHistorieseriebewerken
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnSluiten = New System.Windows.Forms.Button()
        Me.lblSeizoen = New System.Windows.Forms.Label()
        Me.lblSerie = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblDatum = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgvLoting = New System.Windows.Forms.DataGridView()
        Me.btnOpslaan = New System.Windows.Forms.Button()
        Me.btnNieuw = New System.Windows.Forms.Button()
        Me.btnVerwijderen = New System.Windows.Forms.Button()
        Me.btnLegen = New System.Windows.Forms.Button()
        CType(Me.dgvLoting, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSluiten
        '
        Me.btnSluiten.Location = New System.Drawing.Point(444, 101)
        Me.btnSluiten.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.btnSluiten.Name = "btnSluiten"
        Me.btnSluiten.Size = New System.Drawing.Size(143, 42)
        Me.btnSluiten.TabIndex = 301
        Me.btnSluiten.Text = "Sluiten"
        Me.btnSluiten.UseVisualStyleBackColor = True
        '
        'lblSeizoen
        '
        Me.lblSeizoen.AutoSize = True
        Me.lblSeizoen.Location = New System.Drawing.Point(99, 15)
        Me.lblSeizoen.Name = "lblSeizoen"
        Me.lblSeizoen.Size = New System.Drawing.Size(74, 24)
        Me.lblSeizoen.TabIndex = 309
        Me.lblSeizoen.Text = "Seizoen"
        '
        'lblSerie
        '
        Me.lblSerie.AutoSize = True
        Me.lblSerie.Location = New System.Drawing.Point(99, 66)
        Me.lblSerie.Name = "lblSerie"
        Me.lblSerie.Size = New System.Drawing.Size(52, 24)
        Me.lblSerie.TabIndex = 308
        Me.lblSerie.Text = "Serie"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 24)
        Me.Label2.TabIndex = 307
        Me.Label2.Text = "Seizoen:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 24)
        Me.Label1.TabIndex = 306
        Me.Label1.Text = "Serie:"
        '
        'lblDatum
        '
        Me.lblDatum.AutoSize = True
        Me.lblDatum.Location = New System.Drawing.Point(99, 39)
        Me.lblDatum.Name = "lblDatum"
        Me.lblDatum.Size = New System.Drawing.Size(66, 24)
        Me.lblDatum.TabIndex = 312
        Me.lblDatum.Text = "Datum"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 24)
        Me.Label6.TabIndex = 310
        Me.Label6.Text = "Datum:"
        '
        'dgvLoting
        '
        Me.dgvLoting.AllowUserToAddRows = False
        Me.dgvLoting.AllowUserToDeleteRows = False
        Me.dgvLoting.AllowUserToResizeColumns = False
        Me.dgvLoting.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvLoting.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvLoting.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvLoting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLoting.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvLoting.Location = New System.Drawing.Point(16, 101)
        Me.dgvLoting.Margin = New System.Windows.Forms.Padding(11)
        Me.dgvLoting.MultiSelect = False
        Me.dgvLoting.Name = "dgvLoting"
        Me.dgvLoting.RowHeadersVisible = False
        Me.dgvLoting.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader
        Me.dgvLoting.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvLoting.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLoting.Size = New System.Drawing.Size(415, 582)
        Me.dgvLoting.TabIndex = 313
        Me.dgvLoting.VirtualMode = True
        '
        'btnOpslaan
        '
        Me.btnOpslaan.Location = New System.Drawing.Point(444, 152)
        Me.btnOpslaan.Name = "btnOpslaan"
        Me.btnOpslaan.Size = New System.Drawing.Size(143, 42)
        Me.btnOpslaan.TabIndex = 315
        Me.btnOpslaan.Text = "Opslaan"
        Me.btnOpslaan.UseVisualStyleBackColor = True
        '
        'btnNieuw
        '
        Me.btnNieuw.Location = New System.Drawing.Point(444, 200)
        Me.btnNieuw.Name = "btnNieuw"
        Me.btnNieuw.Size = New System.Drawing.Size(143, 42)
        Me.btnNieuw.TabIndex = 316
        Me.btnNieuw.Text = "Nieuw"
        Me.btnNieuw.UseVisualStyleBackColor = True
        '
        'btnVerwijderen
        '
        Me.btnVerwijderen.Location = New System.Drawing.Point(444, 248)
        Me.btnVerwijderen.Name = "btnVerwijderen"
        Me.btnVerwijderen.Size = New System.Drawing.Size(143, 42)
        Me.btnVerwijderen.TabIndex = 317
        Me.btnVerwijderen.Text = "Verwijderen"
        Me.btnVerwijderen.UseVisualStyleBackColor = True
        '
        'btnLegen
        '
        Me.btnLegen.Location = New System.Drawing.Point(444, 299)
        Me.btnLegen.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.btnLegen.Name = "btnLegen"
        Me.btnLegen.Size = New System.Drawing.Size(143, 42)
        Me.btnLegen.TabIndex = 318
        Me.btnLegen.Text = "Legen"
        Me.btnLegen.UseVisualStyleBackColor = True
        '
        'frmHistorieseriebewerken
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(601, 693)
        Me.Controls.Add(Me.btnLegen)
        Me.Controls.Add(Me.btnVerwijderen)
        Me.Controls.Add(Me.btnNieuw)
        Me.Controls.Add(Me.btnOpslaan)
        Me.Controls.Add(Me.dgvLoting)
        Me.Controls.Add(Me.lblDatum)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblSeizoen)
        Me.Controls.Add(Me.lblSerie)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSluiten)
        Me.Font = New System.Drawing.Font("Trebuchet MS", 14.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmHistorieseriebewerken"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmHistorieseriebewerken"
        CType(Me.dgvLoting, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSluiten As Button
    Friend WithEvents lblSeizoen As Label
    Friend WithEvents lblSerie As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblDatum As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents dgvLoting As DataGridView
    Friend WithEvents btnOpslaan As Button
    Friend WithEvents btnNieuw As Button
    Friend WithEvents btnVerwijderen As Button
    Friend WithEvents btnLegen As Button
End Class
