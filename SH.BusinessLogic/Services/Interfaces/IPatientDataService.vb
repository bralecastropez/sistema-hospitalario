Imports System.Collections.ObjectModel
Imports SH.BusinessObjects.Models
Namespace SH.BusinessLogic.Services
    Public Interface IPatientDataService
        Sub AddPatient(ByVal idPaciente As String, ByVal NoIGSS As String, ByVal Nombre As String, ByVal Apellido As String, ByVal FechaNacimiento As Date)
        Sub DeletePatient(ByVal NoIGSS As Integer)
        Sub UpdatePatient(ByVal idPaciente As String, ByVal NoIGSS As String, ByVal Nombre As String, ByVal Apellido As String, ByVal FechaNacimiento As Date)
    End Interface
End Namespace
