Public Class ListBiaya
    Private Sub BtnCari_Click(sender As Object, e As EventArgs) Handles BtnCari.Click
        DTGrid = KontrolBiaya.CariData(TxtCari.Text).ToTable
        LVBiaya.Items.Clear()
        Dim strItem(1) As String
        If DTGrid.Rows.Count > 0 Then
            For i = 0 To DTGrid.Rows.Count - 1
                strItem(0) = DTGrid.Rows(i).Item(0).ToString
                strItem(1) = DTGrid.Rows(i).Item(1).ToString
            Next
            LVBiaya.Items.Add(New ListViewItem(strItem))
        Else
            MsgBox("Data Tidak Di Temukan")
        End If
    End Sub



    Private Sub LVBiaya_DoubleClick(ByVal sendr As Object, e As EventArgs) Handles LVBiaya.DoubleClick
        With TambahBiayaAdmin
            .txtId.Text = LVBiaya.SelectedItems(0).SubItems(0).Text
            .txtNama.Text = LVBiaya.SelectedItems(0).SubItems(1).Text
            Me.Close()
            .txtDisc.Focus()
        End With
    End Sub
End Class