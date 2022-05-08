<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmHistorie
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnBewerken = New System.Windows.Forms.Button()
        Me.btnLoting = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.cboSeizoen = New System.Windows.Forms.ComboBox()
        Me.dgvLoting = New System.Windows.Forms.DataGridView()
        Me.cboSerie = New System.Windows.Forms.ComboBox()
        Me.btnSluiten = New System.Windows.Forms.Button()
        Me.pnlWachtem = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.dgvLoting, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlWachtem.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnBewerken
        '
        Me.btnBewerken.Location = New System.Drawing.Point(934, 73)
        Me.btnBewerken.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.btnBewerken.Name = "btnBewerken"
        Me.btnBewerken.Size = New System.Drawing.Size(143, 42)
        Me.btnBewerken.TabIndex = 306
        Me.btnBewerken.Text = "Bewerken"
        Me.btnBewerken.UseVisualStyleBackColor = True
        '
        'btnLoting
        '
        Me.btnLoting.Enabled = False
        Me.btnLoting.Location = New System.Drawing.Point(934, 370)
        Me.btnLoting.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.btnLoting.Name = "btnLoting"
        Me.btnLoting.Size = New System.Drawing.Size(143, 42)
        Me.btnLoting.TabIndex = 305
        Me.btnLoting.Text = "Nieuw"
        Me.btnLoting.UseVisualStyleBackColor = True
        Me.btnLoting.Visible = False
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(934, 316)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(143, 42)
        Me.btnPrint.TabIndex = 304
        Me.btnPrint.Text = "Printen"
        Me.btnPrint.UseVisualStyleBackColor = True
        Me.btnPrint.Visible = False
        '
        'cboSeizoen
        '
        Me.cboSeizoen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSeizoen.FormattingEnabled = True
        Me.cboSeizoen.Location = New System.Drawing.Point(272, 19)
        Me.cboSeizoen.Margin = New System.Windows.Forms.Padding(6)
        Me.cboSeizoen.Name = "cboSeizoen"
        Me.cboSeizoen.Size = New System.Drawing.Size(151, 32)
        Me.cboSeizoen.TabIndex = 303
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
        Me.dgvLoting.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvLoting.Location = New System.Drawing.Point(20, 68)
        Me.dgvLoting.Margin = New System.Windows.Forms.Padding(11)
        Me.dgvLoting.MultiSelect = False
        Me.dgvLoting.Name = "dgvLoting"
        Me.dgvLoting.RowHeadersVisible = False
        Me.dgvLoting.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader
        Me.dgvLoting.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvLoting.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLoting.Size = New System.Drawing.Size(904, 455)
        Me.dgvLoting.TabIndex = 302
        Me.dgvLoting.VirtualMode = True
        '
        'cboSerie
        '
        Me.cboSerie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSerie.FormattingEnabled = True
        Me.cboSerie.Location = New System.Drawing.Point(20, 19)
        Me.cboSerie.Margin = New System.Windows.Forms.Padding(6)
        Me.cboSerie.Name = "cboSerie"
        Me.cboSerie.Size = New System.Drawing.Size(240, 32)
        Me.cboSerie.Sorted = True
        Me.cboSerie.TabIndex = 301
        '
        'btnSluiten
        '
        Me.btnSluiten.Location = New System.Drawing.Point(934, 19)
        Me.btnSluiten.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.btnSluiten.Name = "btnSluiten"
        Me.btnSluiten.Size = New System.Drawing.Size(143, 42)
        Me.btnSluiten.TabIndex = 300
        Me.btnSluiten.Text = "Sluiten"
        Me.btnSluiten.UseVisualStyleBackColor = True
        '
        'pnlWachtem
        '
        Me.pnlWachtem.Controls.Add(Me.Label1)
        Me.pnlWachtem.Location = New System.Drawing.Point(696, 466)
        Me.pnlWachtem.Name = "pnlWachtem"
        Me.pnlWachtem.Size = New System.Drawing.Size(214, 43)
        Me.pnlWachtem.TabIndex = 307
        Me.pnlWachtem.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(201, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Een moment geduld..."
        '
        'frmHistorie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1087, 539)
        Me.Controls.Add(Me.pnlWachtem)
        Me.Controls.Add(Me.btnBewerken)
        Me.Controls.Add(Me.btnLoting)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.cboSeizoen)
        Me.Controls.Add(Me.dgvLoting)
        Me.Controls.Add(Me.cboSerie)
        Me.Controls.Add(Me.btnSluiten)
        Me.Font = New System.Drawing.Font("Trebuchet MS", 14.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmHistorie"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmHistorie"
        CType(Me.dgvLoting, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlWachtem.ResumeLayout(False)
        Me.pnlWachtem.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnBewerken As Button
    Friend WithEvents btnLoting As Button
    Friend WithEvents btnPrint As Button
    Friend WithEvents cboSeizoen As ComboBox
    Friend WithEvents dgvLoting As DataGridView
    Friend WithEvents cboSerie As ComboBox
    Friend WithEvents btnSluiten As Button
    Friend WithEvents pnlWachtem As Panel
    Friend WithEvents Label1 As Label
End Class
