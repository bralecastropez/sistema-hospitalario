﻿Imports System.Linq
Imports System.Security.Principal
Imports System.Text.RegularExpressions
Imports System.Data.Entity
Imports SH.BusinessObjects.Models
Imports SH.Infrastructure.Helpers

Namespace SH.BusinessLogic.Services
    Public Class DiagnosticDataService
        Implements IDiagnosticDataService
        Public Sub AddDiagnostic(descripcion As String) Implements IDiagnosticDataService.AddDiagnostic
            Try
                Dim db As New dbHospitalEntities
                Dim diagnostico As New Diagnostico
                diagnostico.descripcion = descripcion
                'db.AddToDiagnostico(diagnostico)
                db.Diagnostico.Add(diagnostico)
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                MsgBox(ex.Message)
                MsgBox(ex.InnerException.ToString)
            End Try
        End Sub

        Public Sub AddPatientToDoctor(CodigoMedico As String, DPI As String) Implements IDiagnosticDataService.AddPatientToDoctor
            Try
                Dim db As New dbHospitalEntities
                Dim medicoPaciente As New Medico_Paciente
                medicoPaciente.codigoMedico = CDbl(CodigoMedico)
                medicoPaciente.DPI = CDbl(DPI)
                medicoPaciente.fecha = DateAndTime.Now
                db.Medico_Paciente.Add(medicoPaciente)
                'db.AddToMedico_Paciente(medicoPaciente)
                DataContext.DBEntities.SaveChanges()
                MsgBox("Paciente Agregado Satisfactoriamente")
            Catch ex As Exception
                MsgBox(ex.Message)
                MsgBox(ex.InnerException.ToString)
            End Try
        End Sub

        Public Sub AddBedToPatient(ByRef DPI As String, idCama As String) Implements IDiagnosticDataService.AddBedToPatient
            Try
                Dim db As New dbHospitalEntities
                Dim bedPatient As New Cama_Paciente
                Dim bed = (From u In DataContext.DBEntities.Cama Where u.idCama = idCama).FirstOrDefault
                If bed.estado = True Then
                    MsgBox("La Cama Está Ocupada")
                Else
                    bedPatient.idCama = CDbl(idCama)
                    bedPatient.DPI = CDbl(DPI)
                    bedPatient.fecha = DateAndTime.Now
                    bed.estado = True
                    'db.AddToCama_Paciente(bedPatient)
                    db.Cama_Paciente.Add(bedPatient)
                    DataContext.DBEntities.SaveChanges()
                    MsgBox("Agregado Satisfactoriamente")
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
                MsgBox(ex.InnerException.ToString)
            End Try
        End Sub

        Public Sub AddDiagnosticToDoctor(CodigoMedico As String, CodigoDiagnostico As String) Implements IDiagnosticDataService.AddDiagnosticToDoctor
            Try
                Dim db As New dbHospitalEntities
                ' Dim diagnosticDoctor As New Diagnostico_Medico
                'diagnosticDoctor.codigoMedico = CInt(CodigoMedico)
                'diagnosticDoctor.codigoDiagnostico = CInt(CodigoDiagnostico)
                'db.AddToDiagnostico_Medico(diagnosticDoctor)
                'db.SaveChanges()
                MsgBox("Diagnostico Agregado Satisfactoriamente")
            Catch ex As Exception
                MsgBox(ex.Message)
                MsgBox(ex.InnerException.ToString)
            End Try
        End Sub

        Public Sub AddDiagnosticToPatient(DPI As String, CodigoDiagnostico As String) Implements IDiagnosticDataService.AddDiagnosticToPatient
            Try
                Dim db As New dbHospitalEntities
                Dim diagnosticPatient As New Diagnostico_Paciente
                diagnosticPatient.DPI = CDbl(DPI)
                diagnosticPatient.codigoDiagnostico = CDbl(CodigoDiagnostico)
                diagnosticPatient.fecha = DateAndTime.Now
                'db.AddToDiagnostico_Paciente(diagnosticPatient)
                db.Diagnostico_Paciente.Add(diagnosticPatient)
                DataContext.DBEntities.SaveChanges()
                MsgBox("Diagnostico Agregado Satisfactoriamente")
            Catch ex As Exception
                MsgBox(ex.Message)
                MsgBox(ex.InnerException.ToString)
            End Try
        End Sub
    End Class
End Namespace