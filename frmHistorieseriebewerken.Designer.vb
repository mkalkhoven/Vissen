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
        Me.btnSluiten = New System.Windows.Forms.Button()
        Me.lblSeizoen = New System.Windows.Forms.Label()
        Me.lblSerie = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblDatum = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgvloting = New System.Windows.Forms.DataGridView()
        CType(Me.dgvloting, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSluiten
        '
        Me.btnSluiten.Location = New System.Drawing.Point(631, 15)
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
        Me.lblSerie.Location = New System.Drawing.Point(282, 15)
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
        Me.Label1.Location = New System.Drawing.Point(195, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 24)
        Me.Label1.TabIndex = 306
        Me.Label1.Text = "Serie:"
        '
        'lblDatum
        '
        Me.lblDatum.AutoSize = True
        Me.lblDatum.Location = New System.Drawing.Point(465, 15)
        Me.lblDatum.Name = "lblDatum"
        Me.lblDatum.Size = New System.Drawing.Size(66, 24)
        Me.lblDatum.TabIndex = 312
        Me.lblDatum.Text = "Datum"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(378, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 24)
        Me.Label6.TabIndex = 310
        Me.Label6.Text = "Datum:"
        '
        'dgvloting
        '
        Me.dgvloting.AllowUserToAddRows = False
        Me.dgvloting.AllowUserToDeleteRows = False
        Me.dgvloting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvloting.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvloting.Location = New System.Drawing.Point(16, 42)
        Me.dgvloting.MultiSelect = False
        Me.dgvloting.Name = "dgvloting"
        Me.dgvloting.RowHeadersVisible = False
        Me.dgvloting.RowTemplate.Height = 27
        Me.dgvloting.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvloting.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvloting.Size = New System.Drawing.Size(562, 639)
        Me.dgvloting.TabIndex = 313
        '
        'frmHistorieseriebewerken
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(788, 693)
        Me.Controls.Add(Me.dgvloting)
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
        Me.Name = "frmHistorieseriebewerken"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmHistorieseriebewerken"
        CType(Me.dgvloting, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents dgvloting As DataGridView
End Class
