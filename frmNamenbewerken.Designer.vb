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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkVijftigplus = New System.Windows.Forms.CheckBox()
        CType(Me.dgvnamen,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'dgvnamen
        '
        Me.dgvnamen.AllowUserToAddRows = false
        Me.dgvnamen.AllowUserToDeleteRows = false
        Me.dgvnamen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvnamen.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvnamen.Location = New System.Drawing.Point(12, 12)
        Me.dgvnamen.MultiSelect = false
        Me.dgvnamen.Name = "dgvnamen"
        Me.dgvnamen.RowHeadersVisible = false
        Me.dgvnamen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvnamen.Size = New System.Drawing.Size(507, 741)
        Me.dgvnamen.TabIndex = 3
        '
        'btnopslaan
        '
        Me.btnopslaan.Location = New System.Drawing.Point(1173, 189)
        Me.btnopslaan.Name = "btnopslaan"
        Me.btnopslaan.Size = New System.Drawing.Size(160, 63)
        Me.btnopslaan.TabIndex = 4
        Me.btnopslaan.Text = "Opslaan"
        Me.btnopslaan.UseVisualStyleBackColor = true
        '
        'btnNieuw
        '
        Me.btnNieuw.Location = New System.Drawing.Point(1173, 258)
        Me.btnNieuw.Name = "btnNieuw"
        Me.btnNieuw.Size = New System.Drawing.Size(160, 63)
        Me.btnNieuw.TabIndex = 5
        Me.btnNieuw.Text = "Nieuw"
        Me.btnNieuw.UseVisualStyleBackColor = true
        '
        'btnSluiten
        '
        Me.btnSluiten.Location = New System.Drawing.Point(641, 381)
        Me.btnSluiten.Name = "btnSluiten"
        Me.btnSluiten.Size = New System.Drawing.Size(160, 63)
        Me.btnSluiten.TabIndex = 6
        Me.btnSluiten.Text = "Sluiten"
        Me.btnSluiten.UseVisualStyleBackColor = true
        '
        'txtVoornaam
        '
        Me.txtVoornaam.Location = New System.Drawing.Point(747, 148)
        Me.txtVoornaam.Name = "txtVoornaam"
        Me.txtVoornaam.Size = New System.Drawing.Size(179, 30)
        Me.txtVoornaam.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(621, 154)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 24)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Voornaam"
        '
        'chkVijftigplus
        '
        Me.chkVijftigplus.AutoSize = true
        Me.chkVijftigplus.Location = New System.Drawing.Point(705, 247)
        Me.chkVijftigplus.Name = "chkVijftigplus"
        Me.chkVijftigplus.Size = New System.Drawing.Size(90, 28)
        Me.chkVijftigplus.TabIndex = 9
        Me.chkVijftigplus.Text = "50 Plus"
        Me.chkVijftigplus.UseVisualStyleBackColor = true
        '
        'frmNamenbewerken
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10!, 24!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1442, 824)
        Me.Controls.Add(Me.chkVijftigplus)
        Me.Controls.Add(Me.Label1)
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
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents dgvnamen As DataGridView
    Friend WithEvents btnopslaan As Button
    Friend WithEvents btnNieuw As Button
    Friend WithEvents btnSluiten As Button
    Friend WithEvents txtVoornaam As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents chkVijftigplus As CheckBox
End Class
