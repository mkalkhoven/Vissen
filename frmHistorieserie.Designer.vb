<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHistorieserie
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblSeizoen = New System.Windows.Forms.Label()
        Me.lblSerie = New System.Windows.Forms.Label()
        Me.dgvloting = New System.Windows.Forms.DataGridView()
        Me.btnBewerken = New System.Windows.Forms.Button()
        Me.btnVerwijdeen = New System.Windows.Forms.Button()
        Me.btnNieuw = New System.Windows.Forms.Button()
        CType(Me.dgvloting, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSluiten
        '
        Me.btnSluiten.Location = New System.Drawing.Point(650, 53)
        Me.btnSluiten.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.btnSluiten.Name = "btnSluiten"
        Me.btnSluiten.Size = New System.Drawing.Size(143, 42)
        Me.btnSluiten.TabIndex = 301
        Me.btnSluiten.Text = "Sluiten"
        Me.btnSluiten.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(199, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 24)
        Me.Label1.TabIndex = 302
        Me.Label1.Text = "Serie:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 24)
        Me.Label2.TabIndex = 303
        Me.Label2.Text = "Seizoen:"
        '
        'lblSeizoen
        '
        Me.lblSeizoen.AutoSize = True
        Me.lblSeizoen.Location = New System.Drawing.Point(103, 15)
        Me.lblSeizoen.Name = "lblSeizoen"
        Me.lblSeizoen.Size = New System.Drawing.Size(74, 24)
        Me.lblSeizoen.TabIndex = 305
        Me.lblSeizoen.Text = "Seizoen"
        '
        'lblSerie
        '
        Me.lblSerie.AutoSize = True
        Me.lblSerie.Location = New System.Drawing.Point(286, 15)
        Me.lblSerie.Name = "lblSerie"
        Me.lblSerie.Size = New System.Drawing.Size(52, 24)
        Me.lblSerie.TabIndex = 304
        Me.lblSerie.Text = "Serie"
        '
        'dgvloting
        '
        Me.dgvloting.AllowUserToAddRows = False
        Me.dgvloting.AllowUserToDeleteRows = False
        Me.dgvloting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvloting.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvloting.Location = New System.Drawing.Point(20, 53)
        Me.dgvloting.MultiSelect = False
        Me.dgvloting.Name = "dgvloting"
        Me.dgvloting.RowHeadersVisible = False
        Me.dgvloting.RowTemplate.Height = 27
        Me.dgvloting.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvloting.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvloting.Size = New System.Drawing.Size(622, 586)
        Me.dgvloting.TabIndex = 306
        '
        'btnBewerken
        '
        Me.btnBewerken.Location = New System.Drawing.Point(650, 107)
        Me.btnBewerken.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.btnBewerken.Name = "btnBewerken"
        Me.btnBewerken.Size = New System.Drawing.Size(143, 42)
        Me.btnBewerken.TabIndex = 307
        Me.btnBewerken.Text = "Bewerken"
        Me.btnBewerken.UseVisualStyleBackColor = True
        '
        'btnVerwijdeen
        '
        Me.btnVerwijdeen.Location = New System.Drawing.Point(650, 161)
        Me.btnVerwijdeen.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.btnVerwijdeen.Name = "btnVerwijdeen"
        Me.btnVerwijdeen.Size = New System.Drawing.Size(143, 42)
        Me.btnVerwijdeen.TabIndex = 310
        Me.btnVerwijdeen.Text = "Verwijderen"
        Me.btnVerwijdeen.UseVisualStyleBackColor = True
        '
        'btnNieuw
        '
        Me.btnNieuw.Location = New System.Drawing.Point(650, 215)
        Me.btnNieuw.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.btnNieuw.Name = "btnNieuw"
        Me.btnNieuw.Size = New System.Drawing.Size(143, 42)
        Me.btnNieuw.TabIndex = 311
        Me.btnNieuw.Text = "Nieuw"
        Me.btnNieuw.UseVisualStyleBackColor = True
        '
        'frmHistorieserie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(802, 651)
        Me.Controls.Add(Me.btnNieuw)
        Me.Controls.Add(Me.btnVerwijdeen)
        Me.Controls.Add(Me.btnBewerken)
        Me.Controls.Add(Me.dgvloting)
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
        Me.Name = "frmHistorieserie"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmHistorieserie"
        CType(Me.dgvloting, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSluiten As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblSeizoen As Label
    Friend WithEvents lblSerie As Label
    Friend WithEvents dgvloting As DataGridView
    Friend WithEvents btnBewerken As Button
    Friend WithEvents btnVerwijdeen As Button
    Friend WithEvents btnNieuw As Button
End Class
