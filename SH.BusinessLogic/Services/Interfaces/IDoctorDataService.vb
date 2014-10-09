Imports System.Collections.ObjectModel
Imports SH.BusinessObjects.Models
Namespace SH.BusinessLogic.Services
    Public Interface IDoctorDataService
        Sub AddDoctor(ByVal codigoMedico As String, ByVal Nombre As String, ByVal Apellido As String)
        Sub UpdateDoctor(ByVal codigoMedico As String, ByVal nombre As String, ByVal Apellido As String)
    End Interface
End Namespace
