Imports System.Linq
Imports System.Security.Principal
Imports System.Text.RegularExpressions
Imports System.Data.Entity
Imports SH.BusinessObjects.Models
Imports SH.Infrastructure.Helpers

Namespace SH.BusinessLogic.Services
    Public Class MainDataService
        Implements IMainDataService


        Public Function GetBedPatients() As List(Of Cama_Paciente) Implements IMainDataService.GetBedPatients
            Try
                Dim bedpatients As List(Of Cama_Paciente) = (DataContext.DBEntities.Cama_Paciente).ToList
                Return bedpatients
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Function GetBeds() As List(Of Cama) Implements IMainDataService.GetBeds
            Try
                Dim beds As List(Of Cama) = (DataContext.DBEntities.Cama).ToList
                Return beds
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Function GetCards() As List(Of TarjetaVisita) Implements IMainDataService.GetCards
            Try
                Dim cards As List(Of TarjetaVisita) = (DataContext.DBEntities.TarjetaVisita).ToList
                Return cards
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Function GetDiagnosticPatients() As List(Of Diagnostico_Paciente) Implements IMainDataService.GetDiagnosticPatients
            Try
                Dim diagnosticPatients As List(Of Diagnostico_Paciente) = (DataContext.DBEntities.Diagnostico_Paciente).ToList
                Return diagnosticPatients
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Function GetDiagnostics() As List(Of Diagnostico) Implements IMainDataService.GetDiagnostics
            Try
                Dim diagnostics As List(Of Diagnostico) = (DataContext.DBEntities.Diagnostico).ToList
                Return diagnostics
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Function GetDoctorPatients() As List(Of Medico_Paciente) Implements IMainDataService.GetDoctorPatients
            Try
                Dim doctorPatients As List(Of Medico_Paciente) = (DataContext.DBEntities.Medico_Paciente).ToList
                Return doctorPatients
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Function GetDoctors() As List(Of Medico) Implements IMainDataService.GetDoctors
            Try
                Dim doctors As List(Of Medico) = (DataContext.DBEntities.Medico).ToList
                Return doctors
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Function GetPatients() As List(Of Paciente) Implements IMainDataService.GetPatients
            Try
                Dim patients As List(Of Paciente) = (DataContext.DBEntities.Paciente).ToList
                Return patients
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Function GetPlants() As List(Of Planta) Implements IMainDataService.GetPlants
            Try
                Dim plants As List(Of Planta) = (DataContext.DBEntities.Planta).ToList
                Return plants
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        'Public Function GetDiagnosticDoctors() As List(Of Diagnostico_Medico) Implements IMainDataService.GetDiagnosticPatients
        '   Try
        'Dim diagnosticDoctors As List(Of Diagnostico_Medico) = (DataContext.DBEntities.Diagnostico_Medico).ToList
        '       Return diagnosticDoctors
        '  Catch ex As Exception
        '     Throw New Exception(ex.Message, ex.InnerException)
        'End Try
        'End Function

    End Class
End Namespace