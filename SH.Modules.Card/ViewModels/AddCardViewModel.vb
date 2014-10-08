Imports System.ComponentModel
Imports System.Collections.ObjectModel
Imports System.Windows.Input
Imports System.Threading
Imports SH.BusinessObjects.Models
Imports SH.Infrastructure
Imports SH.Infrastructure.Helpers
Imports SH.BusinessLogic.Services

Namespace SH.Modules.Card.ViewModels
    Public Class AddCardViewModel
        Inherits ViewModelBase
        Private _strDPI As String
        Private _datHoraInicio As Date
        Private _datHoraFin As Date
        Private _cardAccess As ICardDataService
        Private _mainAccess As IMainDataService
        Private _dgPacientes As List(Of Paciente)
        Private _dgVisitas As List(Of TarjetaVisita)

        Public Property Pacientes As List(Of Paciente)
            Get
                Return _dgPacientes
            End Get
            Set(value As List(Of Paciente))
                _dgPacientes = value
                OnPropertyChanged("Pacientes")
            End Set
        End Property
        Public Property Visitas As List(Of TarjetaVisita)
            Get
                Return _dgVisitas
            End Get
            Set(value As List(Of TarjetaVisita))
                _dgVisitas = value
                OnPropertyChanged("Visitas")
            End Set
        End Property

        Public Property DPI As String
            Get
                Return _strDPI
            End Get
            Set(value As String)
                _strDPI = value
                OnPropertyChanged("DPI")
            End Set
        End Property
        Public Property HoraComienzo As Date
            Get
                Return _datHoraInicio
            End Get
            Set(value As Date)
                _datHoraInicio = value
                OnPropertyChanged("HoraComienzo")
            End Set
        End Property
        Public Property HoraFin As Date
            Get
                Return _datHoraFin
            End Get
            Set(value As Date)
                _datHoraFin = value
                OnPropertyChanged("HoraFin")
            End Set
        End Property
        Public Property AgregarTarjeta As ICommand

        Public Sub New()
            ServiceLocator.RegisterService(Of ICardDataService)(New CardDataService)
            ServiceLocator.RegisterService(Of IMainDataService)(New MainDataService)
            _mainAccess = GetService(Of IMainDataService)()
            _cardAccess = GetService(Of ICardDataService)()
            AgregarTarjeta = New RelayCommand(AddressOf AgregarNuevaTarjeta)
            Pacientes = _mainAccess.GetPatients
            Visitas = _mainAccess.GetCards
        End Sub
        Public Sub AgregarNuevaTarjeta()
            _cardAccess.AddCard(DPI, HoraComienzo, HoraFin)
            Pacientes = _mainAccess.GetPatients
            Visitas = _mainAccess.GetCards
            MsgBox("Tarjeta Agregada")
        End Sub
    End Class
End Namespace