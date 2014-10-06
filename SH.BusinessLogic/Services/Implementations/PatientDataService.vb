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
                paciente.DPI = CInt(idPaciente)
                paciente.noIGSS = CInt(NoIGSS)
                paciente.nombre = Nombre
                paciente.apellido = Apellido
                paciente.fechaNacimiento = FechaNacimiento
                db.AddToPaciente(paciente)
                db.SaveChanges()
            Catch ex As Exception
                MsgBox(ex.Message)
                MsgBox(ex.InnerException.ToString)
            End Try
        End Sub
    End Class
End Namespace