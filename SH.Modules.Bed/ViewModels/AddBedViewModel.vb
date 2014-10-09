Imports System.ComponentModel
Imports System.Collections.ObjectModel
Imports System.Windows
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
        Private _strNuevoNombrePlanta As String
        Private _strNuevoNumeroCamas As String
        Private _strNuevoNumeroPlanta As String
        Private _vblUpdatePlant As Visibility = Visibility.Hidden
        Private _vblUpdateBed As Visibility = Visibility.Hidden
        Private _bedAccess As IBedDataService
        Private _plantAccess As IPlantDataService
        Private _mainAccess As IMainDataService
        Private _dgPlantas As List(Of Planta)
        Private _dgCamas As List(Of Cama)
        Private _bed As Cama
        Private _plant As Planta
#Region "Properties"
        Public Property UpdatePlant As Visibility
            Get
                Return _vblUpdatePlant
            End Get
            Set(value As Visibility)
                _vblUpdatePlant = value
                OnPropertyChanged("UpdatePlant")
            End Set
        End Property
        Public Property UpdateBed As Visibility
            Get
                Return _vblUpdateBed
            End Get
            Set(value As Visibility)
                _vblUpdateBed = value
                OnPropertyChanged("UpdateBed")
            End Set
        End Property
        Public Property Bed As Cama
            Get
                Return _bed
            End Get
            Set(value As Cama)
                _bed = value
                OnPropertyChanged("Bed")
            End Set
        End Property
        Public Property Plant As Planta
            Get
                Return _plant
            End Get
            Set(value As Planta)
                _plant = value
                OnPropertyChanged("Plant")
            End Set
        End Property
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
                OnPropertyChanged("NumeroPlanta")
            End Set
        End Property

        Public Property NuevoNombrePlanta As String
            Get
                Return _strNuevoNombrePlanta
            End Get
            Set(value As String)
                _strNuevoNombrePlanta = value
                OnPropertyChanged("NuevoNombrePlanta")
            End Set
        End Property
        Public Property NuevoNumeroCamas As String
            Get
                Return _strNuevoNumeroCamas
            End Get
            Set(value As String)
                _strNuevoNumeroCamas = value
                OnPropertyChanged("NuevoNumeroCamas")
            End Set
        End Property
        Public Property NuevoNumeroPlanta As String
            Get
                Return _strNuevoNumeroPlanta
            End Get
            Set(value As String)
                _strNuevoNumeroPlanta = value
                OnPropertyChanged("NuevoNumeroPlanta")
            End Set
        End Property
        Public Property AgregarPlanta As ICommand
        Public Property EditarPlanta As ICommand
        Public Property AgregarCama As ICommand
        Public Property EditarCama As ICommand
        Public Property ActualizarCama As ICommand
        Public Property ActualizarPlanta As ICommand
#End Region
        

        Public Sub New()
            ServiceLocator.RegisterService(Of IBedDataService)(New BedDataService)
            ServiceLocator.RegisterService(Of IPlantDataService)(New PlantDataService)
            ServiceLocator.RegisterService(Of IMainDataService)(New MainDataService)
            _bedAccess = GetService(Of IBedDataService)()
            _plantAccess = GetService(Of IPlantDataService)()
            _mainAccess = GetService(Of IMainDataService)()
            AgregarCama = New RelayCommand(AddressOf AddBed)
            AgregarPlanta = New RelayCommand(AddressOf AddPlant)
            EditarCama = New RelayCommand(AddressOf EditBed)
            EditarPlanta = New RelayCommand(AddressOf EditPlant)
            ActualizarCama = New RelayCommand(AddressOf SetBed)
            ActualizarPlanta = New RelayCommand(AddressOf SetPlant)
            Plantas = _mainAccess.GetPlants
            Camas = _mainAccess.GetBeds
        End Sub
        Public Sub AddBed()
            _bedAccess.AddBed(NumeroPlanta)
            Plantas = _mainAccess.GetPlants
            Camas = _mainAccess.GetBeds
        End Sub
        Public Sub AddPlant()
            _plantAccess.AddPlant(NombrePlanta, NumeroCamas)
            Plantas = _mainAccess.GetPlants
            Camas = _mainAccess.GetBeds
        End Sub
        Public Sub EditBed()
            UpdateBed = Visibility.Visible
            NuevoNumeroPlanta = Bed.idPlanta
        End Sub
        Public Sub EditPlant()
            UpdatePlant = Visibility.Visible
            NuevoNombrePlanta = Plant.nombre
            NuevoNumeroCamas = Plant.noCamas
        End Sub
        Public Sub SetBed()
            _bedAccess.UpdateBed(Bed.idCama, NuevoNumeroPlanta)
            Plantas = _mainAccess.GetPlants
            Camas = _mainAccess.GetBeds
            UpdateBed = Visibility.Hidden
        End Sub
        Public Sub SetPlant()
            Plantas = _mainAccess.GetPlants
            Camas = _mainAccess.GetBeds
            _plantAccess.UpdatePlant(Plant.idPlanta, NuevoNombrePlanta, NuevoNumeroCamas)
            UpdateBed = Visibility.Hidden
        End Sub
    End Class
End Namespace