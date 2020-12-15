<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frmklassement
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
        Me.btnMaakklassement = New System.Windows.Forms.Button()
        Me.lblseizoen = New System.Windows.Forms.Label()
        Me.lblSerie = New System.Windows.Forms.Label()
        Me.Cbocorrectie = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgvKlassement = New System.Windows.Forms.DataGridView()
        CType(Me.dgvKlassement,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'btnSluiten
        '
        Me.btnSluiten.Location = New System.Drawing.Point(235, 58)
        Me.btnSluiten.Name = "btnSluiten"
        Me.btnSluiten.Size = New System.Drawing.Size(164, 40)
        Me.btnSluiten.TabIndex = 6
        Me.btnSluiten.Text = "Sluiten"
        Me.btnSluiten.UseVisualStyleBackColor = true
        '
        'btnMaakklassement
        '
        Me.btnMaakklassement.Location = New System.Drawing.Point(235, 12)
        Me.btnMaakklassement.Name = "btnMaakklassement"
        Me.btnMaakklassement.Size = New System.Drawing.Size(164, 40)
        Me.btnMaakklassement.TabIndex = 5
        Me.btnMaakklassement.Text = "Maak klassement"
        Me.btnMaakklassement.UseVisualStyleBackColor = true
        '
        'lblseizoen
        '
        Me.lblseizoen.AutoSize = true
        Me.lblseizoen.Location = New System.Drawing.Point(101, 9)
        Me.lblseizoen.Name = "lblseizoen"
        Me.lblseizoen.Size = New System.Drawing.Size(74, 24)
        Me.lblseizoen.TabIndex = 7
        Me.lblseizoen.Text = "Seizoen"
        '
        'lblSerie
        '
        Me.lblSerie.AutoSize = true
        Me.lblSerie.Location = New System.Drawing.Point(101, 47)
        Me.lblSerie.Name = "lblSerie"
        Me.lblSerie.Size = New System.Drawing.Size(52, 24)
        Me.lblSerie.TabIndex = 8
        Me.lblSerie.Text = "Serie"
        '
        'Cbocorrectie
        '
        Me.Cbocorrectie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cbocorrectie.FormattingEnabled = true
        Me.Cbocorrectie.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5"})
        Me.Cbocorrectie.Location = New System.Drawing.Point(105, 82)
        Me.Cbocorrectie.Name = "Cbocorrectie"
        Me.Cbocorrectie.Size = New System.Drawing.Size(65, 32)
        Me.Cbocorrectie.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(12, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 24)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Correctie"
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Location = New System.Drawing.Point(12, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 24)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Serie: "
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Location = New System.Drawing.Point(12, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 24)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Seizoen:"
        '
        'dgvKlassement
        '
        Me.dgvKlassement.AllowUserToAddRows = false
        Me.dgvKlassement.AllowUserToDeleteRows = false
        Me.dgvKlassement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvKlassement.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvKlassement.Location = New System.Drawing.Point(12, 120)
        Me.dgvKlassement.MultiSelect = false
        Me.dgvKlassement.Name = "dgvKlassement"
        Me.dgvKlassement.RowHeadersVisible = false
        Me.dgvKlassement.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvKlassement.Size = New System.Drawing.Size(673, 613)
        Me.dgvKlassement.TabIndex = 18
        '
        'Frmklassement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10!, 24!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(746, 786)
        Me.Controls.Add(Me.dgvKlassement)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Cbocorrectie)
        Me.Controls.Add(Me.lblSerie)
        Me.Controls.Add(Me.lblseizoen)
        Me.Controls.Add(Me.btnSluiten)
        Me.Controls.Add(Me.btnMaakklassement)
        Me.Font = New System.Drawing.Font("Trebuchet MS", 14.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "Frmklassement"
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmklassement"
        CType(Me.dgvKlassement,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents btnSluiten As Button
    Friend WithEvents btnMaakklassement As Button
    Friend WithEvents lblseizoen As Label
    Friend WithEvents lblSerie As Label
    Friend WithEvents Cbocorrectie As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dgvKlassement As DataGridView
End Class
