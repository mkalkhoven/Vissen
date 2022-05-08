<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLotingnieuw
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
        Me.btnopslaan = New System.Windows.Forms.Button()
        Me.btnSluiten = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboSeizoen = New System.Windows.Forms.ComboBox()
        Me.dtpDatum = New System.Windows.Forms.DateTimePicker()
        Me.cboserie = New System.Windows.Forms.ComboBox()
        Me.txtSerienaamnummer = New System.Windows.Forms.TextBox()
        Me.lblDatumid = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnopslaan
        '
        Me.btnopslaan.Location = New System.Drawing.Point(496, 15)
        Me.btnopslaan.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.btnopslaan.Name = "btnopslaan"
        Me.btnopslaan.Size = New System.Drawing.Size(143, 42)
        Me.btnopslaan.TabIndex = 309
        Me.btnopslaan.Text = "Opslaan"
        Me.btnopslaan.UseVisualStyleBackColor = True
        '
        'btnSluiten
        '
        Me.btnSluiten.Location = New System.Drawing.Point(496, 69)
        Me.btnSluiten.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.btnSluiten.Name = "btnSluiten"
        Me.btnSluiten.Size = New System.Drawing.Size(143, 42)
        Me.btnSluiten.TabIndex = 308
        Me.btnSluiten.Text = "Sluiten"
        Me.btnSluiten.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 24)
        Me.Label1.TabIndex = 310
        Me.Label1.Text = "Datum"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 24)
        Me.Label2.TabIndex = 311
        Me.Label2.Text = "Seizoen"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 24)
        Me.Label3.TabIndex = 312
        Me.Label3.Text = "Serie"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 122)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(121, 24)
        Me.Label4.TabIndex = 313
        Me.Label4.Text = "Serienummer"
        '
        'cboSeizoen
        '
        Me.cboSeizoen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSeizoen.FormattingEnabled = True
        Me.cboSeizoen.Location = New System.Drawing.Point(140, 6)
        Me.cboSeizoen.Name = "cboSeizoen"
        Me.cboSeizoen.Size = New System.Drawing.Size(139, 32)
        Me.cboSeizoen.TabIndex = 314
        '
        'dtpDatum
        '
        Me.dtpDatum.Location = New System.Drawing.Point(140, 45)
        Me.dtpDatum.Name = "dtpDatum"
        Me.dtpDatum.Size = New System.Drawing.Size(331, 30)
        Me.dtpDatum.TabIndex = 315
        '
        'cboserie
        '
        Me.cboserie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboserie.FormattingEnabled = True
        Me.cboserie.Location = New System.Drawing.Point(140, 81)
        Me.cboserie.Name = "cboserie"
        Me.cboserie.Size = New System.Drawing.Size(331, 32)
        Me.cboserie.TabIndex = 316
        '
        'txtSerienaamnummer
        '
        Me.txtSerienaamnummer.Location = New System.Drawing.Point(139, 119)
        Me.txtSerienaamnummer.Name = "txtSerienaamnummer"
        Me.txtSerienaamnummer.Size = New System.Drawing.Size(62, 30)
        Me.txtSerienaamnummer.TabIndex = 317
        '
        'lblDatumid
        '
        Me.lblDatumid.AutoSize = True
        Me.lblDatumid.Location = New System.Drawing.Point(212, 122)
        Me.lblDatumid.Name = "lblDatumid"
        Me.lblDatumid.Size = New System.Drawing.Size(0, 24)
        Me.lblDatumid.TabIndex = 318
        '
        'frmLotingnieuw
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(652, 159)
        Me.Controls.Add(Me.lblDatumid)
        Me.Controls.Add(Me.txtSerienaamnummer)
        Me.Controls.Add(Me.cboserie)
        Me.Controls.Add(Me.dtpDatum)
        Me.Controls.Add(Me.cboSeizoen)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnopslaan)
        Me.Controls.Add(Me.btnSluiten)
        Me.Font = New System.Drawing.Font("Trebuchet MS", 14.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLotingnieuw"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmLotingnieuw"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnopslaan As Button
    Friend WithEvents btnSluiten As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cboSeizoen As ComboBox
    Friend WithEvents dtpDatum As DateTimePicker
    Friend WithEvents cboserie As ComboBox
    Friend WithEvents txtSerienaamnummer As TextBox
    Friend WithEvents lblDatumid As Label
End Class
