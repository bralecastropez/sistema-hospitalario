Imports System.Collections.ObjectModel
Imports SH.BusinessObjects.Models
Namespace SH.BusinessLogic.Services
    Public Interface IBedDataService
        Sub AddBed(ByVal numeroPlanta As String)
        Sub UpdateBed(ByVal idCama As String, ByVal numeroPlanta As String)
    End Interface
End Namespace