Imports System.ComponentModel
Imports System.Collections.ObjectModel
Imports System.Windows.Input
Imports System.Threading
Imports SH.BusinessObjects.Models
Imports SH.Infrastructure
Imports SH.Infrastructure.Helpers
Imports SH.BusinessLogic.Services
Imports System.Windows

Namespace SH.Modules.Patient.ViewModels
    Public Class AddPatientViewModel
        Inherits ViewModelBase
        Private _patientAccess As IPatientDataService
        Private _strNombre As String
        Private _strApellido As String
        Private _intDPI As String
        Private _intNoIGSS As String
        Private _datFecha As Date
        Private _vblUpdate As Visibility = Visibility.Hidden
        Private _strNuevoNombre As String
        Private _strNuevoApellido As String
        Private _intNuevoDPI As String
        Private _intNuevoNoIGSS As String
        Private _datNuevoFecha As Date

        Private _paciente As Paciente
        Private _mainAccess As IMainDataService
        Private _dgPacientes As List(Of Paciente)

        Public Property Patient As Paciente
            Get
                Return _paciente
            End Get
            Set(value As Paciente)
                _paciente = value
                OnPropertyChanged("Patient")
            End Set
        End Property

        Public Property Pacientes As List(Of Paciente)
            Get
                Return _dgPacientes
            End Get
            Set(value As List(Of Paciente))
                _dgPacientes = value
                OnPropertyChanged("Pacientes")
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

        Public Property Nombre As String
            Get
                Return _strNombre
            End Get
            Set(value As String)
                _strNombre = value
                OnPropertyChanged("Nombre")
            End Set
        End Property
        Public Property Apellido As String
            Get
                Return _strApellido
            End Get
            Set(value As String)
                _strApellido = value
                OnPropertyChanged("Apellido")
            End Set
        End Property
        Public Property FechaNacimiento As Date
            Get
                Return _datFecha
            End Get
            Set(value As Date)
                _datFecha = value
                OnPropertyChanged("FechaNacimiento")
            End Set
        End Property
        Public Property NoIGSS As String
            Get
                Return _intNoIGSS
            End Get
            Set(value As String)
                _intNoIGSS = value
                OnPropertyChanged("NoIGSS")
            End Set
        End Property
        Public Property idPaciente As String
            Get
                Return _intDPI
            End Get
            Set(value As String)
                _intDPI = value
                OnPropertyChanged("idPaciente")
            End Set
        End Property

        Public Property NuevoNombre As String
            Get
                Return _strNuevoNombre
            End Get
            Set(value As String)
                _strNuevoNombre = value
                OnPropertyChanged("NuevoNombre")
            End Set
        End Property
        Public Property NuevoApellido As String
            Get
                Return _strNuevoApellido
            End Get
            Set(value As String)
                _strNuevoApellido = value
                OnPropertyChanged("NuevoApellido")
            End Set
        End Property
        Public Property NuevoFechaNacimiento As Date
            Get
                Return _datNuevoFecha
            End Get
            Set(value As Date)
                _datNuevoFecha = value
                OnPropertyChanged("NuevoFechaNacimiento")
            End Set
        End Property
        Public Property NuevoNoIGSS As String
            Get
                Return _intNuevoNoIGSS
            End Get
            Set(value As String)
                _intNuevoNoIGSS = value
                OnPropertyChanged("NuevoNoIGSS")
            End Set
        End Property

        Public Property AgregarPaciente As ICommand
        Public Property EditarPaciente As ICommand
        Public Property ActualizarPaciente As ICommand

        Public Sub New()
            ServiceLocator.RegisterService(Of IPatientDataService)(New PatientDataService)
            _patientAccess = GetService(Of IPatientDataService)()
            ServiceLocator.RegisterService(Of IMainDataService)(New MainDataService)
            _mainAccess = GetService(Of IMainDataService)()
            Pacientes = _mainAccess.GetPatients
            AgregarPaciente = New RelayCommand(AddressOf AgregarNuevoPaciente)
            EditarPaciente = New RelayCommand(AddressOf EditarNuevoPaciente)
            ActualizarPaciente = New RelayCommand(AddressOf ActualizarNuevoPaciente)
        End Sub
        Public Sub AgregarNuevoPaciente()
            _patientAccess.AddPatient(idPaciente, NoIGSS, Nombre, Apellido, FechaNacimiento)
            Pacientes = _mainAccess.GetPatients
        End Sub

        Public Sub ActualizarNuevoPaciente()
            _patientAccess.UpdatePatient(Patient.DPI, NuevoNoIGSS, NuevoNombre, NuevoApellido, NuevoFechaNacimiento)
            Pacientes = _mainAccess.GetPatients
            Update = Visibility.Hidden
        End Sub
        Public Sub EditarNuevoPaciente()
            NuevoNombre = Patient.nombre
            NuevoApellido = Patient.apellido
            NuevoNoIGSS = Patient.noIGSS
            NuevoFechaNacimiento = Patient.fechaNacimiento
            Update = Visibility.Visible
        End Sub
    End Class
End Namespace