<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Nieuwseizoenform
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
        Me.btnOpslaan = New System.Windows.Forms.Button()
        Me.btnSluiten = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtseizoen = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnOpslaan
        '
        Me.btnOpslaan.Location = New System.Drawing.Point(361, 12)
        Me.btnOpslaan.Name = "btnOpslaan"
        Me.btnOpslaan.Size = New System.Drawing.Size(113, 33)
        Me.btnOpslaan.TabIndex = 168
        Me.btnOpslaan.Text = "Opslaan"
        Me.btnOpslaan.UseVisualStyleBackColor = True
        '
        'btnSluiten
        '
        Me.btnSluiten.Location = New System.Drawing.Point(361, 51)
        Me.btnSluiten.Name = "btnSluiten"
        Me.btnSluiten.Size = New System.Drawing.Size(113, 33)
        Me.btnSluiten.TabIndex = 169
        Me.btnSluiten.Text = "Sluiten"
        Me.btnSluiten.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 24)
        Me.Label1.TabIndex = 170
        Me.Label1.Text = "Nieuw seizoen"
        '
        'txtseizoen
        '
        Me.txtseizoen.Location = New System.Drawing.Point(150, 13)
        Me.txtseizoen.Name = "txtseizoen"
        Me.txtseizoen.Size = New System.Drawing.Size(205, 30)
        Me.txtseizoen.TabIndex = 171
        '
        'Nieuwseizoenform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(483, 93)
        Me.Controls.Add(Me.txtseizoen)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSluiten)
        Me.Controls.Add(Me.btnOpslaan)
        Me.Font = New System.Drawing.Font("Trebuchet MS", 14.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Nieuwseizoenform"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nieuwseizoenform"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnOpslaan As Button
    Friend WithEvents btnSluiten As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtseizoen As TextBox
End Class
