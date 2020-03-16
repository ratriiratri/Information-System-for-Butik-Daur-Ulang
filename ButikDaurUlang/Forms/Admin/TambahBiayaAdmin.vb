Public Class TambahBiayaAdmin

    Private Sub Bersih() 'clear isi 
        txtId.Text = ""
        txtNama.Text = ""
        txtDisc.Text = ""
        txtJumlah.Text = ""
    End Sub

    Sub HitungTotal()
        Dim total As Integer

        total = 0

        For i = 0 To LVDetailBiaya.Items.Count - 1
            total = total + (LVDetailBiaya.Items(i).SubItems(4).Text)
        Next

        lblNominal.Text = total
    End Sub

    Private Sub TambahBiayaAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = AdminUtama
    End Sub

    Private Sub lblLihat_Click(sender As Object, e As EventArgs) Handles lblLihat.Click
        LihatBiayaAdmin.Show()
        Me.Close()
        DataBiayaAdmin.Close()
    End Sub

    Private Sub lblData_Click(sender As Object, e As EventArgs) Handles lblData.Click
        LihatBiayaAdmin.Close()
        Me.Close()
        DataBiayaAdmin.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim namaHari As String()

        namaHari = New String() {"Minggu", "Senin", "Selasa", "Rabu", "Kmais", "Jumat", "Sabtu"}

        lblTanggal.Text = Format(Now, namaHari(Now.DayOfWeek()) & "yyyy/MM/dd")
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'deklarasi array string
        Dim strItem(4) As String

        strItem(0) = txtId.Text
        strItem(1) = txtNama.Text
        strItem(2) = txtJumlah.Text
        strItem(3) = txtDisc.Text
        strItem(4) = txtJumlah.Text - (txtJumlah.Text * txtDisc.Text)

        'tambahkan item add (ListViewDetailBiaya) dengan isi array
        LVDetailBiaya.Items.Add(New ListViewItem(strItem))

        Call HitungTotal()
        Call Bersih()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        LVDetailBiaya.SelectedItems(0).Remove()
        Dim total As Integer

        total = 0
        For i = 0 To LVDetailBiaya.Items.Count - 1
            total = (LVDetailBiaya.Items(i).SubItems(4).Text) - total
        Next

        lblNominal.Text = total
    End Sub

    Private Sub btnCariBarang_Click(sender As Object, e As EventArgs) Handles btnCariBarang.Click
        LihatBiayaAdmin.Show()

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim listDetail As New List(Of EntityDetailBiaya)()

        If LVDetailBiaya.Items.Count = 0 Then
            MsgBox("Masukan Biaya terlebih dulu")
            Exit Sub
        End If

        With EntitasPengeluaran
            .idPengeluaran = lblPengeluaran.Text
            .jmlPengeluaran = lblNominal.Text
            .ketPengeluaran = ""
            .tglPengeluaran = Format(Now, "yyyy/MM/dd")
            .idUser = lblUser.Text
        End With

        For i = 0 To LVDetailBiaya.Items.Count - 1
            With LVDetailBiaya.Items(i)
                EntitasDetailBiaya.idBiaya = .SubItems(0).Text
                EntitasDetailBiaya.idPengeluaran = lblPengeluaran.Text
                EntitasDetailBiaya.jumlahBiaya = .SubItems(2).Text
            End With
            listDetail.Add(EntitasDetailBiaya)
        Next
        KontrolPengeluaran.SIMPAN_DATA(EntitasPengeluaran, listDetail)
        MsgBox("Data Berhasil DiSimpan")
    End Sub

    Private Sub lblPengeluaran_TextChanged(sender As Object, e As EventArgs) Handles lblPengeluaran.TextChanged

    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint
        lblPengeluaran.Text = KontrolPengeluaran.FCKdPengeluaran
        lblUser.Text = KODELOG
        lblTanggal.Text = Format(Now, "yyyy/MM/dd")
    End Sub


End Class