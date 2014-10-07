Imports System.Linq
Imports System.Security.Principal
Imports System.Text.RegularExpressions
Imports System.Data.Entity
Imports SH.BusinessObjects.Models
Imports SH.Infrastructure.Helpers

Namespace SH.BusinessLogic.Services
    Public Class PlantDataService
        Implements IPlantDataService

        Public Sub AddPlant(nombrePlanta As String, numeroCamas As String) Implements IPlantDataService.AddPlant
            Try
                Dim db As New dbHospitalEntities
                Dim planta As New Planta
                planta.nombre = nombrePlanta
                planta.noCamas = CInt(numeroCamas)
                db.AddToPlanta(planta)
                db.SaveChanges()
            Catch ex As Exception
                MsgBox(ex.Message)
                MsgBox(ex.InnerException.ToString)
            End Try
        End Sub
    End Class
End Namespace