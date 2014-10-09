Imports System.Linq
Imports System.Security.Principal
Imports System.Text.RegularExpressions
Imports System.Data.Entity
Imports SH.BusinessObjects.Models
Imports SH.Infrastructure.Helpers

Namespace SH.BusinessLogic.Services
    Public Class DoctorDataService
        Implements IDoctorDataService


        Public Sub AddDoctor(codigoMedico As String, Nombre As String, Apellido As String) Implements IDoctorDataService.AddDoctor
            Try
                Dim db As New dbHospitalEntities
                Dim doctor As New Medico
                doctor.codigoMedico = CDbl(codigoMedico)
                doctor.nombre = Nombre
                doctor.apellido = Apellido
                'db.AddToMedico(doctor)
                db.Medico.Add(doctor)
                DataContext.DBEntities.SaveChanges()
                MsgBox("Doctor Agregado Satisfactoriamente")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub

        Public Sub UpdateDoctor(codigoMedico As String, nombre As String, Apellido As String) Implements IDoctorDataService.UpdateDoctor
            Try
                Dim doctor = (From u In DataContext.DBEntities.Medico Where u.codigoMedico = codigoMedico Select u).FirstOrDefault
                doctor.nombre = nombre
                doctor.apellido = Apellido
                DataContext.DBEntities.SaveChanges()
                MsgBox("Doctor Actualizado Satisfactoriamente")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub
    End Class
End Namespace