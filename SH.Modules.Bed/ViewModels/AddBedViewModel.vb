Imports System.ComponentModel
Imports System.Collections.ObjectModel
Imports System.Windows.Input
Imports System.Threading
Imports SH.BusinessObjects.Models
Imports SH.Infrastructure
Imports SH.Infrastructure.Helpers
Imports SH.BusinessLogic.Services

Namespace SH.Modules.Bed.ViewModels
    Public Class AddBedViewModel
        Inherits ViewModelBase
        Private _strNombrePlanta As String
        Private _strNumeroCamas As String
        Private _strNumeroPlanta As String
        Private _bedAccess As IBedDataService
        Private _plantAccess As IPlantDataService

        Public Property NombrePlanta As String
            Get
                Return _strNombrePlanta
            End Get
            Set(value As String)
                _strNombrePlanta = value
                OnPropertyChanged("NombrePlanta")
            End Set
        End Property
        Public Property NumeroCamas As String
            Get
                Return _strNumeroCamas
            End Get
            Set(value As String)
                _strNumeroCamas = value
                OnPropertyChanged("NumeroCamas")
            End Set
        End Property
        Public Property NumeroPlanta As String
            Get
                Return _strNumeroPlanta
            End Get
            Set(value As String)
                _strNumeroPlanta = value
                OnPropertyChanged("Numero Planta")
            End Set
        End Property
        Public Property AgregarPlanta As ICommand
        Public Property AgregarCama As ICommand

        Public Sub New()
            ServiceLocator.RegisterService(Of IBedDataService)(New BedDataService)
            ServiceLocator.RegisterService(Of IPlantDataService)(New PlantDataService)
            _bedAccess = GetService(Of IBedDataService)()
            _plantAccess = GetService(Of IPlantDataService)()
            AgregarCama = New RelayCommand(AddressOf AddBed)
            AgregarPlanta = New RelayCommand(AddressOf AddPlant)
        End Sub
        Public Sub AddBed()
            _bedAccess.AddBed(NumeroPlanta)
            MsgBox("Cama Agregada Satisfactoriamente")
        End Sub
        Public Sub AddPlant()
            _plantAccess.AddPlant(NombrePlanta, NumeroCamas)
            MsgBox("Planta Agregada Satisfactoriamente")
        End Sub
    End Class
End Namespace