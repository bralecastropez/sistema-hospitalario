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
                planta.noCamas = CDbl(numeroCamas)
                db.Planta.AddObject(planta)
                DataContext.DBEntities.SaveChanges()
                MsgBox("Planta Agregada Satisfactoriamente")
                db.SaveChanges()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub

        Public Sub UpdatePlant(idPlanta As String, nombre As String, numeroCamas As String) Implements IPlantDataService.UpdatePlant
            Try
                Dim db As New dbHospitalEntities
                Dim plant = (From u In DataContext.DBEntities.Planta Where u.idPlanta = idPlanta Select u).FirstOrDefault
                plant.nombre = nombre
                plant.noCamas = numeroCamas
                DataContext.DBEntities.SaveChanges()
                db.SaveChanges()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub
    End Class
End Namespace