﻿Imports System.Collections.ObjectModel
Imports SH.BusinessObjects.Models
Namespace SH.BusinessLogic.Services
    Public Interface IPatientDataService
        Sub AddPatient(ByVal idPaciente As String, ByVal NoIGSS As String, ByVal Nombre As String, ByVal Apellido As String, ByVal FechaNacimiento As Date)
        Sub DeletePatient(ByVal Paciente As Paciente)
    End Interface
End Namespace
