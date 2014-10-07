Imports System.Collections.ObjectModel
Imports SH.BusinessObjects.Models
Namespace SH.BusinessLogic.Services
    Public Interface ICardDataService
        Sub AddCard(ByVal DPI As String, ByVal horaComienzo As Date, ByVal horaFin As Date)
    End Interface
End Namespace
