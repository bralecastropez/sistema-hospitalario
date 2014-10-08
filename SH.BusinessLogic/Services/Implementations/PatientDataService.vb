Imports System.Linq
Imports System.Security.Principal
Imports System.Text.RegularExpressions
Imports System.Data.Entity
Imports SH.BusinessObjects.Models
Imports SH.Infrastructure.Helpers

Namespace SH.BusinessLogic.Services
    Public Class PatientDataService
        Implements IPatientDataService


        Public Sub AddPatient(idPaciente As String, NoIGSS As String, Nombre As String, Apellido As String, FechaNacimiento As Date) Implements IPatientDataService.AddPatient
            Try
                Dim db As New dbHospitalEntities
                Dim paciente As New Paciente
                paciente.DPI = CDbl(idPaciente)
                paciente.noIGSS = CDbl(NoIGSS)
                paciente.nombre = Nombre
                paciente.apellido = Apellido
                paciente.fechaNacimiento = FechaNacimiento
                'db.AddToPaciente(paciente)
                db.Paciente.Add(paciente)
                db.SaveChanges()
                MsgBox("Paciente Agregado Satisfactoriamente")
            Catch ex As Exception
                MsgBox(ex.Message)
                MsgBox(ex.InnerException.ToString)
            End Try
        End Sub
        Public Sub DeletePatient(Paciente As Paciente) Implements IPatientDataService.DeletePatient
            Try
                Dim db As New dbHospitalEntities
                db.Paciente.Remove(Paciente)
                db.SaveChanges()
                MsgBox("Paciente Eliminado Satisfactoriamente")
            Catch ex As Exception
                MsgBox(ex.Message)
                MsgBox(ex.InnerException.ToString)
            End Try
        End Sub
    End Class
End Namespace