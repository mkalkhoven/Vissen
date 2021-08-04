<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHistorienieuw
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
        Me.btnOpslaan = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboNamen = New System.Windows.Forms.ComboBox()
        Me.txtPlaats = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnSluiten
        '
        Me.btnSluiten.Location = New System.Drawing.Point(382, 9)
        Me.btnSluiten.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.btnSluiten.Name = "btnSluiten"
        Me.btnSluiten.Size = New System.Drawing.Size(143, 42)
        Me.btnSluiten.TabIndex = 302
        Me.btnSluiten.Text = "Sluiten"
        Me.btnSluiten.UseVisualStyleBackColor = True
        '
        'btnOpslaan
        '
        Me.btnOpslaan.Location = New System.Drawing.Point(382, 63)
        Me.btnOpslaan.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.btnOpslaan.Name = "btnOpslaan"
        Me.btnOpslaan.Size = New System.Drawing.Size(143, 42)
        Me.btnOpslaan.TabIndex = 303
        Me.btnOpslaan.Text = "Opslaan"
        Me.btnOpslaan.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 24)
        Me.Label1.TabIndex = 304
        Me.Label1.Text = "Naam"
        '
        'cboNamen
        '
        Me.cboNamen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNamen.FormattingEnabled = True
        Me.cboNamen.Location = New System.Drawing.Point(76, 9)
        Me.cboNamen.Name = "cboNamen"
        Me.cboNamen.Size = New System.Drawing.Size(298, 32)
        Me.cboNamen.Sorted = True
        Me.cboNamen.TabIndex = 305
        '
        'txtPlaats
        '
        Me.txtPlaats.Location = New System.Drawing.Point(76, 47)
        Me.txtPlaats.Name = "txtPlaats"
        Me.txtPlaats.Size = New System.Drawing.Size(77, 30)
        Me.txtPlaats.TabIndex = 306
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 24)
        Me.Label2.TabIndex = 307
        Me.Label2.Text = "Plaats"
        '
        'frmHistorienieuw
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(543, 114)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPlaats)
        Me.Controls.Add(Me.cboNamen)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnOpslaan)
        Me.Controls.Add(Me.btnSluiten)
        Me.Font = New System.Drawing.Font("Trebuchet MS", 14.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Name = "frmHistorienieuw"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmHistorienieuw"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSluiten As Button
    Friend WithEvents btnOpslaan As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents cboNamen As ComboBox
    Friend WithEvents txtPlaats As TextBox
    Friend WithEvents Label2 As Label
End Class
