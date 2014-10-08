Imports System.Linq
Imports System.Security.Principal
Imports System.Text.RegularExpressions
Imports System.Data.Entity
Imports SH.BusinessObjects.Models
Imports SH.Infrastructure.Helpers

Namespace SH.BusinessLogic.Services
    Public Class CardDataService
        Implements ICardDataService

        Public Sub AddCard(DPI As String, horaComienzo As Date, horaFin As Date) Implements ICardDataService.AddCard
            Try
                Dim db As New dbHospitalEntities
                Dim tarjetaVisita As New TarjetaVisita
                Dim tarjetas = (From visita In DataContext.DBEntities.TarjetaVisita Where visita.DPI = DPI).Count
                MsgBox(tarjetas.ToString)
                If tarjetas = 1 Or tarjetas = 2 Or tarjetas = 3 Or tarjetas = 4 Then
                    tarjetaVisita.DPI = CDbl(DPI)
                    tarjetaVisita.horaComienzo = horaComienzo
                    tarjetaVisita.horaFin = horaFin
                    'db.AddToTarjetaVisita(tarjetaVisita)
                    db.TarjetaVisita.Add(tarjetaVisita)
                    db.SaveChanges()
                    MsgBox("Tarjeta de Visita Agregada Satisfactoriamente")
                Else
                    MsgBox("El Paciente ha llegado al Maximo de Tarjetas de Visita")
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
                MsgBox(ex.InnerException.ToString)
            End Try
        End Sub
    End Class
End Namespace