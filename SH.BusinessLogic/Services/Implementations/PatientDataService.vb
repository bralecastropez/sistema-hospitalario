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
                DataContext.DBEntities.SaveChanges()
                db.SaveChanges()
                MsgBox("Paciente Agregado Satisfactoriamente")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub
        Public Sub DeletePatient(NoIGSS As Integer) Implements IPatientDataService.DeletePatient
            Try
                Dim db As New dbHospitalEntities
                Dim patient = {From u In DataContext.DBEntities.Paciente Where u.noIGSS = NoIGSS Select u}.FirstOrDefault
                db.Paciente.Remove(patient)
                DataContext.DBEntities.SaveChanges()
                db.SaveChanges()
                MsgBox("Paciente Eliminado Satisfactoriamente")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub

        Public Sub UpdatePatient(idPaciente As String, NoIGSS As String, Nombre As String, Apellido As String, FechaNacimiento As Date) Implements IPatientDataService.UpdatePatient
            Try
                Dim db As New dbHospitalEntities
                Dim patient = (From u In DataContext.DBEntities.Paciente Where u.DPI = idPaciente Select u).FirstOrDefault
                patient.noIGSS = CDbl(NoIGSS)
                patient.nombre = Nombre
                patient.apellido = Apellido
                patient.fechaNacimiento = FechaNacimiento
                DataContext.DBEntities.SaveChanges()
                db.SaveChanges()
                MsgBox("Paciente Modificado Satisfactoriamente")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub
    End Class
End Namespace