﻿Public Class EntityDetailBiaya
    Private biaya As String
    Private pengeluaran As String
    Private disc As Double
    Private jumlah As Integer

    Public Property idBiaya() As String
        Get
            Return biaya
        End Get
        Set(value As String)
            biaya = value
        End Set
    End Property

    Public Property idPengeluaran() As String
        Get
            Return pengeluaran
        End Get
        Set(value As String)
            pengeluaran = value
        End Set
    End Property

    Public Property discBiaya() As Double
        Get
            Return disc
        End Get
        Set(value As Double)
            disc = value
        End Set
    End Property

    Public Property jumlahBiaya() As Integer
        Get
            Return jumlah
        End Get
        Set(value As Integer)
            jumlah = value
        End Set
    End Property
End Class
