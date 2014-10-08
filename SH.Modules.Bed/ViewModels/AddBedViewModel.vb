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
        Private _mainAccess As IMainDataService
        Private _dgPlantas As List(Of Planta)
        Private _dgCamas As List(Of Cama)

        Public Property Camas As List(Of Cama)
            Get
                Return _dgCamas
            End Get
            Set(value As List(Of Cama))
                _dgCamas = value
                OnPropertyChanged("Camas")
            End Set
        End Property
        Public Property Plantas As List(Of Planta)
            Get
                Return _dgPlantas
            End Get
            Set(value As List(Of Planta))
                _dgPlantas = value
                OnPropertyChanged("Plantas")
            End Set
        End Property

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
            ServiceLocator.RegisterService(Of IMainDataService)(New MainDataService)
            _bedAccess = GetService(Of IBedDataService)()
            _plantAccess = GetService(Of IPlantDataService)()
            _mainAccess = GetService(Of IMainDataService)()
            AgregarCama = New RelayCommand(AddressOf AddBed)
            AgregarPlanta = New RelayCommand(AddressOf AddPlant)
            Plantas = _mainAccess.GetPlants
            Camas = _mainAccess.GetBeds
        End Sub
        Public Sub AddBed()
            _bedAccess.AddBed(NumeroPlanta)
            Plantas = _mainAccess.GetPlants
            Camas = _mainAccess.GetBeds
            MsgBox("Cama Agregada Satisfactoriamente")
        End Sub
        Public Sub AddPlant()
            _plantAccess.AddPlant(NombrePlanta, NumeroCamas)
            Plantas = _mainAccess.GetPlants
            Camas = _mainAccess.GetBeds
            MsgBox("Planta Agregada Satisfactoriamente")
        End Sub
    End Class
End Namespace