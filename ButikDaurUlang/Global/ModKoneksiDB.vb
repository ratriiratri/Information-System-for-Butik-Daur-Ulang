﻿Imports System.Data.OleDb

Module ModKoneksiDB
    Public DTR As OleDbDataReader
    Public CMD As New OleDbCommand
    Public DTA As New OleDbDataAdapter
    Public DTS As New DataSet
    Public DTT As New DataTable
    Public DTGrid As New DataTable
    Public strKon = "Provider=SQLNCLI11;Data Source=DESKTOP-1MQNARG\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=ButikDaurUlang"
    Public Connection As New OleDbConnection(strKon)

    Public Function OpenConnection() As OleDbConnection
        Try
            If Connection.State = ConnectionState.Closed Then Connection.Open()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return Connection
    End Function

    Public Function CloseConnection() As OleDbConnection
        Connection.Close()
        Return Connection
    End Function
End Module
