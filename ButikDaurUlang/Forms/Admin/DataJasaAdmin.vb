﻿Public Class DataJasaAdmin

    Dim modeProses As Integer '0=tanpa mode, 1=tambah, 2=ubah
    Dim baris As Integer

    Private Sub Bersih()
        txtId.Text = ""
        txtNama.Text = ""
        txtHarga.Text = ""
    End Sub

    Private Sub RefreshGrid()
        DTGrid = KontrolJasa.TampilData.ToTable
        DGJasa.DataSource = DTGrid

        If DTGrid.Rows.Count > 0 Then
            DGJasa.Rows(DTGrid.Rows.Count - 1).Selected = True
            DGJasa.CurrentCell = DGJasa.Item(1, DTGrid.Rows.Count - 1)
            Call IsiBox(DTGrid.Rows.Count - 1)
            Call Bersih()
        End If
    End Sub

    Private Sub IsiBox(br As Integer)
        If br < DTGrid.Rows.Count Then
            With DGJasa.Rows(br)
                txtId.Text = .Cells(0).Value.ToString
                txtNama.Text = .Cells(1).Value.ToString
                txtHarga.Text = .Cells(2).Value.ToString
            End With
        End If
    End Sub

    Private Sub AturTxtBox(st As Boolean)
        btnSave.Enabled = st

        txtNama.Enabled = st
        txtHarga.Enabled = st
    End Sub

    Private Sub DataJasaAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = AdminUtama

        Call RefreshGrid()
        Call Bersih()
        AturTxtBox(False)

        If DTGrid.Rows.Count = 0 Then
            btnEdit.Enabled = False
            btnDelete.Enabled = False
        End If
    End Sub

    Private Sub lblTambah_Click(sender As Object, e As EventArgs) Handles lblTambah.Click
        Me.Close()
        TambahJasaAdmin.Show()
        LihatJasaAdmin.Close()
    End Sub

    Private Sub lblLihat_Click(sender As Object, e As EventArgs) Handles lblLihat.Click
        Me.Close()
        TambahJasaAdmin.Close()
        LihatJasaAdmin.Show()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        With EntitasJasa
            .idJasa = txtId.Text
            .namaJasa = txtNama.Text
            .hargaJasa = txtHarga.Text
        End With

        If modeProses = 1 Then
            KontrolJasa.InsertData(EntitasJasa)
        ElseIf modeProses = 2 Then
            KontrolJasa.UpdateData(EntitasJasa)
        End If

        MsgBox("Data telah tersimpan!", MsgBoxStyle.Information, "Info")

        btnNew.Enabled = True
        Call RefreshGrid()
        Call Bersih()
        AturTxtBox(False)
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Call AturTxtBox(True)
        Call Bersih()
        modeProses = 1

        btnNew.Enabled = False
        btnEdit.Enabled = True
        btnDelete.Enabled = True

        txtId.Text = KontrolJasa.FCKdJasa
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        AturTxtBox(True)

        btnNew.Enabled = False

        txtNama.Focus()
        modeProses = 2
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim statusReferensi As Boolean

        statusReferensi = KontrolJasa.CekDataDipakai(txtId.Text)
        If statusReferensi Then
            MsgBox("Data masih dipakai! Tidak bisa dihapus.", MsgBoxStyle.Exclamation, "Peringatan")
            Exit Sub
        End If

        If MsgBox("Apakah anda yakin ingin menghapus data ini?", MsgBoxStyle.Question + MsgBoxStyle.YesNo,
        "Konfirmasi") = MsgBoxResult.Yes Then
            KontrolJasa.DeleteData(txtId.Text)
        End If

        Call RefreshGrid()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Call RefreshGrid()
    End Sub

    Private Sub DGJasa_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGJasa.CellContentClick, DGJasa.CellClick
        DTGrid = KontrolJasa.TampilData.ToTable
        baris = e.RowIndex
        DGJasa.Rows(baris).Selected = True
        IsiBox(baris)
    End Sub
End Class