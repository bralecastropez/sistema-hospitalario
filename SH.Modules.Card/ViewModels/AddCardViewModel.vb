Imports System.ComponentModel
Imports System.Collections.ObjectModel
Imports System.Windows.Input
Imports System.Threading
Imports SH.BusinessObjects.Models
Imports SH.Infrastructure
Imports SH.Infrastructure.Helpers
Imports SH.BusinessLogic.Services
Imports SH.Modules.Card.Views
Imports System.Windows

Namespace SH.Modules.Card.ViewModels
    Public Class AddCardViewModel
        Inherits ViewModelBase
        Private _strDPI As String
        Private _datHoraInicio As Date
        Private _datNuevaHoraInicio As Date
        Private _datNuevaHoraFin As Date
        Private _datHoraFin As Date
        Private _vblUpdate As Visibility = Visibility.Hidden
        Private _card As TarjetaVisita
        Private _cardAccess As ICardDataService
        Private _mainAccess As IMainDataService
        Private _dgPacientes As List(Of Paciente)
        Private _dgVisitas As List(Of TarjetaVisita)
        Dim idVista As Integer
#Region "Properties"
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
        Public Property Card As TarjetaVisita
            Get
                Return _card
            End Get
            Set(value As TarjetaVisita)
                _card = value
                OnPropertyChanged("Card")
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
        Public Property NuevaHoraComienzo As Date
            Get
                Return _datNuevaHoraInicio
            End Get
            Set(value As Date)
                _datNuevaHoraInicio = value
                OnPropertyChanged("NuevaHoraComienzo")
            End Set
        End Property
        Public Property NuevaHoraFin As Date
            Get
                Return _datNuevaHoraFin
            End Get
            Set(value As Date)
                _datNuevaHoraFin = value
                OnPropertyChanged("NuevaHoraFin")
            End Set
        End Property

        Public Property Update As Visibility
            Get
                Return _vblUpdate
            End Get
            Set(value As Visibility)
                _vblUpdate = value
                OnPropertyChanged("Update")
            End Set
        End Property
        Public Property AgregarTarjeta As ICommand
        Public Property EditarTarjeta As ICommand
        Public Property EliminarTarjeta As ICommand
        Public Property Actualizar As ICommand
#End Region

        Public Sub New()
            ServiceLocator.RegisterService(Of ICardDataService)(New CardDataService)
            ServiceLocator.RegisterService(Of IMainDataService)(New MainDataService)
            _mainAccess = GetService(Of IMainDataService)()
            _cardAccess = GetService(Of ICardDataService)()
            AgregarTarjeta = New RelayCommand(AddressOf AgregarNuevaTarjeta)
            EditarTarjeta = New RelayCommand(AddressOf ModificarTarjeta)
            EliminarTarjeta = New RelayCommand(AddressOf EliminarTarjetaSeleccionada)
            Actualizar = New RelayCommand(AddressOf ActualizarTarjeta)
            Pacientes = _mainAccess.GetPatients
            Visitas = _mainAccess.GetCards
        End Sub

        Public Sub AgregarNuevaTarjeta()
            _cardAccess.AddCard(DPI, HoraComienzo, HoraFin)
            Pacientes = _mainAccess.GetPatients
            Visitas = _mainAccess.GetCards
        End Sub
        Public Sub ModificarTarjeta()
            Update = Visibility.Visible
        End Sub
        Public Sub EliminarTarjetaSeleccionada()
            _cardAccess.DeleteCard(Card.noVisita)
            _cardAccess.UpdateCard(idVista, NuevaHoraComienzo, NuevaHoraFin)
            Pacientes = _mainAccess.GetPatients
            Visitas = _mainAccess.GetCards
        End Sub
        Public Sub ActualizarTarjeta()
            idVista = Card.noVisita
            _cardAccess.UpdateCard(idVista, NuevaHoraComienzo, NuevaHoraFin)
            Pacientes = _mainAccess.GetPatients
            Visitas = _mainAccess.GetCards
        End Sub
    End Class
End Namespace