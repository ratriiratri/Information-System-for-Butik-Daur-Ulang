﻿Public Class DataProdukAdmin

    Dim modeProses As Integer
    Dim baris As Integer

    Private Sub Bersih() 'clear isi 
        txtId.Text = ""
        txtNama.Text = ""
        txtHarga.Text = ""
        txtStock.Text = ""
    End Sub

    Private Sub RefreshGrid() 'tampil isi tabel pada DGProduk
        DTGrid = KontrolProduk.TampilData.ToTable
        DGProduk.DataSource = DTGrid

        If DTGrid.Rows.Count > 0 Then
            DGProduk.Rows(DTGrid.Rows.Count - 1).Selected = True
            DGProduk.CurrentCell = DGProduk.Item(1, DTGrid.Rows.Count - 1)
            Call IsiBox(DTGrid.Rows.Count - 1)
            Call Bersih()
        End If
    End Sub

    Private Sub IsiBox(br As Integer)
        If br < DTGrid.Rows.Count Then
            With DGProduk.Rows(br)
                txtId.Text = .Cells(0).Value.ToString
                txtNama.Text = .Cells(1).Value.ToString
                txtHarga.Text = .Cells(2).Value.ToString
                txtStock.Text = .Cells(3).Value.ToString
            End With
        End If
    End Sub

    Private Sub AturTxtBox(st As Boolean)
        btnSave.Enabled = st

        txtNama.Enabled = st
        txtHarga.Enabled = st
        txtStock.Enabled = st
    End Sub

    Private Sub DataProdukAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = AdminUtama

        Call RefreshGrid()
        Call Bersih()
        AturTxtBox(False)

        If DTGrid.Rows.Count = 0 Then
            btnEdit.Enabled = False
            btnDelete.Enabled = False
        End If
    End Sub

    Private Sub DGProduk_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGProduk.CellContentClick, DGProduk.CellClick
        DTGrid = KontrolProduk.TampilData.ToTable
        baris = e.RowIndex
        DGProduk.Rows(baris).Selected = True
        IsiBox(baris)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        With EntitasProduk
            .idProduk = txtId.Text
            .namaProduk = txtNama.Text
            .hargaProduk = txtHarga.Text
            .stockProduk = txtStock.Text
        End With

        If modeProses = 1 Then
            KontrolProduk.InsertData(EntitasProduk)
        ElseIf modeProses = 2 Then
            KontrolProduk.UpdateData(EntitasProduk)
        End If

        MsgBox("Data telah tersimpan!", MsgBoxStyle.Information, "Info")

        Call RefreshGrid()
        Call Bersih()
        AturTxtBox(False)

        btnNew.Enabled = True
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Call AturTxtBox(True)
        Call Bersih()
        modeProses = 1

        btnNew.Enabled = False
        btnEdit.Enabled = True
        btnDelete.Enabled = True

        txtId.Text = KontrolProduk.FCKdProduk
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        AturTxtBox(True)

        btnNew.Enabled = False

        txtNama.Focus()
        modeProses = 2
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim statusReferensi As Boolean

        statusReferensi = KontrolProduk.CekDataDipakai(txtId.Text)

        If statusReferensi Then
            MsgBox("Data masih digunakan, tidak dapat dihapus!", MsgBoxStyle.Exclamation, "Peringatan")
            Exit Sub
        End If

        If MsgBox("Apakah anda yakin menghapus data ini?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Konfirmasi") = MsgBoxResult.Yes Then
            KontrolProduk.DeleteData(txtId.Text)
        End If

        RefreshGrid()
    End Sub
End Class