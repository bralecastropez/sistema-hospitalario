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
                tarjetaVisita.DPI = DPI
                tarjetaVisita.horaComienzo = horaComienzo
                tarjetaVisita.horaFin = horaFin
                db.AddToTarjetaVisita(tarjetaVisita)
                db.SaveChanges()
            Catch ex As Exception
                MsgBox(ex.Message)
                MsgBox(ex.InnerException.ToString)
            End Try
        End Sub
    End Class
End Namespace