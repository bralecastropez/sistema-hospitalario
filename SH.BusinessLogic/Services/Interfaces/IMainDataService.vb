Imports System.Collections.ObjectModel
Imports SH.BusinessObjects.Models
Namespace SH.BusinessLogic.Services
    Public Interface IMainDataService
        Function GetPatients() As List(Of Paciente)
        Function GetDoctors() As List(Of Medico)
        Function GetCards() As List(Of TarjetaVisita)
        Function GetBeds() As List(Of Cama)
        Function GetPlants() As List(Of Planta)
        Function GetDoctorPatients() As List(Of Medico_Paciente)
        Function GetBedPatients() As List(Of Cama_Paciente)
        Function GetDiagnostics() As List(Of Diagnostico)
        Function GetDiagnosticPatients() As List(Of Diagnostico_Paciente)
        'Function GetDiagnosticDoctors() As List(Of Diagnostico_Medico)
    End Interface
End Namespace
