<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListBiaya
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
        Me.LVBiaya = New System.Windows.Forms.ListView()
        Me.HKode = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.HNama = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.HHarga = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BtnCari = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtCari = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'LVBiaya
        '
        Me.LVBiaya.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.HKode, Me.HNama, Me.HHarga})
        Me.LVBiaya.FullRowSelect = True
        Me.LVBiaya.GridLines = True
        Me.LVBiaya.HideSelection = False
        Me.LVBiaya.Location = New System.Drawing.Point(12, 50)
        Me.LVBiaya.MultiSelect = False
        Me.LVBiaya.Name = "LVBiaya"
        Me.LVBiaya.Size = New System.Drawing.Size(534, 318)
        Me.LVBiaya.TabIndex = 30
        Me.LVBiaya.UseCompatibleStateImageBehavior = False
        Me.LVBiaya.View = System.Windows.Forms.View.Details
        '
        'HKode
        '
        Me.HKode.Text = "Kode"
        Me.HKode.Width = 80
        '
        'HNama
        '
        Me.HNama.Text = "Nama Barang"
        Me.HNama.Width = 350
        '
        'HHarga
        '
        Me.HHarga.Text = "Harga"
        Me.HHarga.Width = 100
        '
        'BtnCari
        '
        Me.BtnCari.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCari.Location = New System.Drawing.Point(499, 4)
        Me.BtnCari.Name = "BtnCari"
        Me.BtnCari.Size = New System.Drawing.Size(47, 25)
        Me.BtnCari.TabIndex = 29
        Me.BtnCari.Text = "Cari"
        Me.BtnCari.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnCari.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(15, 12)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 13)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "Kata Kunci :"
        '
        'TxtCari
        '
        Me.TxtCari.Location = New System.Drawing.Point(98, 9)
        Me.TxtCari.Name = "TxtCari"
        Me.TxtCari.Size = New System.Drawing.Size(394, 20)
        Me.TxtCari.TabIndex = 27
        '
        'ListBiaya
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(555, 378)
        Me.Controls.Add(Me.LVBiaya)
        Me.Controls.Add(Me.BtnCari)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TxtCari)
        Me.Name = "ListBiaya"
        Me.Text = "ListBiaya"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LVBiaya As ListView
    Friend WithEvents HKode As ColumnHeader
    Friend WithEvents HNama As ColumnHeader
    Friend WithEvents HHarga As ColumnHeader
    Friend WithEvents BtnCari As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents TxtCari As TextBox
End Class
