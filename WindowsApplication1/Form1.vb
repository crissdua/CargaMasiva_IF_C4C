Imports OASP_C.ExBodegaService
Imports System.Linq
Imports System.Net
Imports System.Text
Imports System.Windows.Forms
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.IO
Imports System.Xml.Linq
Imports System.Xml
Imports System.Collections
Imports System
Imports System.Net.Security
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Security.Cryptography.X509Certificates

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim objetoEscribir2 As New C4C_SaldoClientesB.CreateResponse
        Dim leerrequest2 As New C4C_SaldoClientesB.CreateRequest

        Dim objetoEscribir As New C4C_SaldoClientesV.CreateResponse
        Dim leerrequest As New C4C_SaldoClientesV.CreateRequest

        Dim request As IF_SaldoClientesV.SaldoClientesVType = New IF_SaldoClientesV.SaldoClientesVType
        Dim response As IF_SaldoClientesV.SaldoClientesVResponseType = New IF_SaldoClientesV.SaldoClientesVResponseType
        Dim cliente As New IF_SaldoClientesV.ipostep_vP0010000101in_WCSX_comsapb1ivplatformruntime_INB_WS_CALL_SYNC_XPT_INB_WS_CALL_SYNC_XPTipo_procClient
        cliente.ClientCredentials.UserName.UserName = "B1iruntime"
        cliente.ClientCredentials.UserName.Password = "12345678"
        response = cliente.ZSaldoClientesV(request)

        leerrequest2.Saldo_ClienteBSaldo_ClienteBCreateRequest_sync = New C4C_SaldoClientesB.Saldo_ClienteBSaldo_ClienteBCreateRequestMessage_sync
        leerrequest2.Saldo_ClienteBSaldo_ClienteBCreateRequest_sync.Saldo_ClienteB = New C4C_SaldoClientesB.Saldo_ClienteBSaldo_ClienteBCreateRequest
        objetoEscribir2.Saldo_ClienteBSaldo_ClienteBCreateConfirmation_sync = New C4C_SaldoClientesB.Saldo_ClienteBSaldo_ClienteBCreateConfirmationMessage_sync
        leerrequest2.Saldo_ClienteBSaldo_ClienteBCreateRequest_sync.Saldo_ClienteB.Nombre = New C4C_SaldoClientesB.Text
        leerrequest2.Saldo_ClienteBSaldo_ClienteBCreateRequest_sync.Saldo_ClienteB.Saldo = New C4C_SaldoClientesB.Text

        leerrequest.Saldo_ClienteVSaldo_ClienteVCreateRequest_sync = New C4C_SaldoClientesV.Saldo_ClienteVSaldo_ClienteVCreateRequestMessage_sync
        leerrequest.Saldo_ClienteVSaldo_ClienteVCreateRequest_sync.Saldo_ClienteV = New C4C_SaldoClientesV.Saldo_ClienteVSaldo_ClienteVCreateRequest
        objetoEscribir.Saldo_ClienteVSaldo_ClienteVCreateConfirmation_sync = New C4C_SaldoClientesV.Saldo_ClienteVSaldo_ClienteVCreateConfirmationMessage_sync
        leerrequest.Saldo_ClienteVSaldo_ClienteVCreateRequest_sync.Saldo_ClienteV.Nombre = New C4C_SaldoClientesV.Text
        leerrequest.Saldo_ClienteVSaldo_ClienteVCreateRequest_sync.Saldo_ClienteV.Saldo = New C4C_SaldoClientesV.Quantity


        Dim cliente2 As New C4C_SaldoClientesV.YGGG2714Y_SaldoClienteVClient
        cliente2.ClientCredentials.UserName.UserName = "_BODEGACS_1"
        cliente2.ClientCredentials.UserName.Password = "Welcome08"

        Dim cliente3 As New C4C_SaldoClientesB.Y3YVY3FOY_Saldo_ClienteBClient
        cliente3.ClientCredentials.UserName.UserName = "_BODEGACS_1"
        cliente3.ClientCredentials.UserName.Password = "Welcome08"
        Try

            For Each a As IF_SaldoClientesV.SaldoClientesVResponseTypeRow In response.SaldoClientesVResult
                    leerrequest.Saldo_ClienteVSaldo_ClienteVCreateRequest_sync.Saldo_ClienteV.Entry = a.CardCode
                    leerrequest.Saldo_ClienteVSaldo_ClienteVCreateRequest_sync.Saldo_ClienteV.Nombre.Value = a.CardName
                    leerrequest.Saldo_ClienteVSaldo_ClienteVCreateRequest_sync.Saldo_ClienteV.Saldo.Value = a.Balance
                'objetoEscribir.Saldo_ClienteVSaldo_ClienteVCreateConfirmation_sync = cliente2.Create(leerrequest.Saldo_ClienteVSaldo_ClienteVCreateRequest_sync)
                If a.Balance > 0 Then
                    leerrequest2.Saldo_ClienteBSaldo_ClienteBCreateRequest_sync.Saldo_ClienteB.Entry = a.CardCode
                    leerrequest2.Saldo_ClienteBSaldo_ClienteBCreateRequest_sync.Saldo_ClienteB.Nombre.Value = a.CardName
                    leerrequest2.Saldo_ClienteBSaldo_ClienteBCreateRequest_sync.Saldo_ClienteB.Saldo.Value = "TRUE"
                Else
                    leerrequest2.Saldo_ClienteBSaldo_ClienteBCreateRequest_sync.Saldo_ClienteB.Entry = a.CardCode
                    leerrequest2.Saldo_ClienteBSaldo_ClienteBCreateRequest_sync.Saldo_ClienteB.Nombre.Value = a.CardName
                    leerrequest2.Saldo_ClienteBSaldo_ClienteBCreateRequest_sync.Saldo_ClienteB.Saldo.Value = "FALSE"
                End If
                'objetoEscribir2.Saldo_ClienteBSaldo_ClienteBCreateConfirmation_sync = cliente3.Create(leerrequest2.Saldo_ClienteBSaldo_ClienteBCreateRequest_sync)
            Next
            Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
