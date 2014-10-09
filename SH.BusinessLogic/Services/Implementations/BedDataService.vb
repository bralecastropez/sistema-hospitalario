Imports System.Linq
Imports System.Security.Principal
Imports System.Text.RegularExpressions
Imports System.Data.Entity
Imports SH.BusinessObjects.Models
Imports SH.Infrastructure.Helpers

Namespace SH.BusinessLogic.Services
    Public Class BedDataService
        Implements IBedDataService

        Public Sub AddBed(numeroPlanta As String) Implements IBedDataService.AddBed
            Try
                Dim db As New dbHospitalEntities
                Dim cama As New Cama
                cama.estado = False
                cama.idPlanta = CInt(numeroPlanta)
                'db.AddToCama(cama)
                db.Cama.Add(cama)
                DataContext.DBEntities.SaveChanges()
                MsgBox("Cama Agregada Satisfactoriamente")
            Catch ex As Exception
                MsgBox(ex.Message)
                MsgBox(ex.InnerException.ToString)
            End Try
        End Sub

        Public Sub UpdateBed(idCama As String, numeroPlanta As String) Implements IBedDataService.UpdateBed
            Try
                Dim db As New dbHospitalEntities
                Dim cama = (From u In DataContext.DBEntities.Cama Where u.idCama = idCama Select u).FirstOrDefault
                cama.estado = False
                cama.idPlanta = CInt(numeroPlanta)
                'db.AddToCama(cama)
                DataContext.DBEntities.SaveChanges()
                MsgBox("Cama Actualizada Satisfactoriamente")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub
    End Class
End Namespace