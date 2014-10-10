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
                If tarjetas < 4 Then
                    tarjetaVisita.DPI = CDbl(DPI)
                    tarjetaVisita.horaComienzo = horaComienzo
                    tarjetaVisita.horaFin = horaFin
                    db.TarjetaVisita.AddObject(tarjetaVisita)
                    DataContext.DBEntities.SaveChanges()
                    db.SaveChanges()
                    MsgBox("Tarjeta de Visita Agregada Satisfactoriamente")
                Else
                    MsgBox("El Paciente ha llegado al Maximo de Tarjetas de Visita")
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub

        Public Sub UpdateCard(noVisita As Integer, horaComienzo As Date, horaFin As Date) Implements ICardDataService.UpdateCard
            Try
                Dim db As New dbHospitalEntities
                Dim tarjetaVisita = (From tarj In DataContext.DBEntities.TarjetaVisita Where tarj.noVisita = noVisita Select tarj).SingleOrDefault
                tarjetaVisita.horaComienzo = horaComienzo
                tarjetaVisita.horaFin = horaFin
                DataContext.DBEntities.SaveChanges()
                db.SaveChanges()
                MsgBox("Tarjeta de Visita Modificada Satisfactoriamente")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub
    End Class
End Namespace