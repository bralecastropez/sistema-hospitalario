﻿Imports System.Collections.ObjectModel
Imports SH.BusinessObjects.Models
Namespace SH.BusinessLogic.Services
    Public Interface IPlantDataService
        Sub AddPlant(ByVal nombrePlanta As String, ByVal numeroCamas As String)
    End Interface
End Namespace