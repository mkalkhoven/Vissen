<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVisser
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
        Me.dgvVisser = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblSerie = New System.Windows.Forms.Label()
        Me.lblseizoen = New System.Windows.Forms.Label()
        Me.btnSluiten = New System.Windows.Forms.Button()
        Me.btnVisser = New System.Windows.Forms.Button()
        CType(Me.dgvVisser,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'dgvVisser
        '
        Me.dgvVisser.AllowUserToAddRows = false
        Me.dgvVisser.AllowUserToDeleteRows = false
        Me.dgvVisser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVisser.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvVisser.Location = New System.Drawing.Point(12, 120)
        Me.dgvVisser.MultiSelect = false
        Me.dgvVisser.Name = "dgvVisser"
        Me.dgvVisser.RowHeadersVisible = false
        Me.dgvVisser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvVisser.Size = New System.Drawing.Size(673, 613)
        Me.dgvVisser.TabIndex = 25
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Location = New System.Drawing.Point(12, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 24)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Seizoen:"
        '
        'lblSerie
        '
        Me.lblSerie.AutoSize = true
        Me.lblSerie.Location = New System.Drawing.Point(12, 47)
        Me.lblSerie.Name = "lblSerie"
        Me.lblSerie.Size = New System.Drawing.Size(59, 24)
        Me.lblSerie.TabIndex = 22
        Me.lblSerie.Text = "Visser"
        '
        'lblseizoen
        '
        Me.lblseizoen.AutoSize = true
        Me.lblseizoen.Location = New System.Drawing.Point(101, 9)
        Me.lblseizoen.Name = "lblseizoen"
        Me.lblseizoen.Size = New System.Drawing.Size(74, 24)
        Me.lblseizoen.TabIndex = 21
        Me.lblseizoen.Text = "Seizoen"
        '
        'btnSluiten
        '
        Me.btnSluiten.Location = New System.Drawing.Point(235, 58)
        Me.btnSluiten.Name = "btnSluiten"
        Me.btnSluiten.Size = New System.Drawing.Size(179, 40)
        Me.btnSluiten.TabIndex = 20
        Me.btnSluiten.Text = "Sluiten"
        Me.btnSluiten.UseVisualStyleBackColor = true
        '
        'btnVisser
        '
        Me.btnVisser.Location = New System.Drawing.Point(235, 12)
        Me.btnVisser.Name = "btnVisser"
        Me.btnVisser.Size = New System.Drawing.Size(179, 40)
        Me.btnVisser.TabIndex = 19
        Me.btnVisser.Text = "Maak Visser"
        Me.btnVisser.UseVisualStyleBackColor = true
        '
        'FrmVisser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10!, 24!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(772, 461)
        Me.Controls.Add(Me.dgvVisser)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblSerie)
        Me.Controls.Add(Me.lblseizoen)
        Me.Controls.Add(Me.btnSluiten)
        Me.Controls.Add(Me.btnVisser)
        Me.Font = New System.Drawing.Font("Trebuchet MS", 14.25!)
        Me.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "FrmVisser"
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmVisser"
        CType(Me.dgvVisser,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents dgvVisser As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents lblSerie As Label
    Friend WithEvents lblseizoen As Label
    Friend WithEvents btnSluiten As Button
    Friend WithEvents btnVisser As Button
End Class
