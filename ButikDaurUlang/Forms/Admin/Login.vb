﻿Public Class Login
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        DTGrid = KontrolUser.loginAdmin(txtUsername.Text).ToTable
        If DTGrid.Rows.Count > 0 Then
            With EntitasUser
                .idUser = DTGrid.Rows(0)(0).ToString
                .namaUser = DTGrid.Rows(0)(1).ToString
                .hpUser = DTGrid.Rows(0)(2).ToString
                .usernameUser = DTGrid.Rows(0)(3).ToString
                .passwordUser = DTGrid.Rows(0)(4).ToString
                .statusUser = DTGrid.Rows(0)(5).ToString

                KODELOG = EntitasUser.idUser
                NAMAADMIN = EntitasUser.namaUser
            End With
            If txtUsername.Text = EntitasUser.usernameUser And txtPassword.Text = EntitasUser.passwordUser Then
                MsgBox("Login Berhasil")
                AdminUtama.Show()
                Me.Hide()
            Else
                MsgBox("password salah")
                txtPassword.Focus()
            End If
        Else
            MsgBox("Data User Tidak Ditemukan")
            txtPassword.Text = ""
            txtPassword.Focus()
        End If
    End Sub
End Class