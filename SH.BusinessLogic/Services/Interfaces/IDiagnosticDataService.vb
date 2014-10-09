Imports System.Collections.ObjectModel
Imports SH.BusinessObjects.Models
Namespace SH.BusinessLogic.Services
    Public Interface IDiagnosticDataService
        Sub AddDiagnostic(ByVal descripcion As String)
        Sub AddPatientToDoctor(ByVal CodigoMedico As String, ByVal DPI As String)
        Sub AddBedToPatient(ByRef DPI As String, ByVal idCama As String)
        Sub AddDiagnosticToDoctor(ByVal CodigoMedico As String, ByVal CodigoDiagnostico As String)
        Sub AddDiagnosticToPatient(ByVal DPI As String, ByVal CodigoDiagnostico As String)
        Sub UpdateDiagnostic(ByVal idDiagnostico As String, ByVal nuevaDescripcion As String)
    End Interface
End Namespace
