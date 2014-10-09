Imports System.ComponentModel
Imports System.Collections.ObjectModel
Imports System.Windows.Input
Imports System.Threading
Imports SH.BusinessObjects.Models
Imports SH.Infrastructure
Imports SH.Infrastructure.Helpers
Imports SH.BusinessLogic.Services

Namespace SH.Modules.Patient.ViewModels
    Public Class AddPatientViewModel
        Inherits ViewModelBase
        Private _patientAccess As IPatientDataService
        Private _strNombre As String
        Private _strApellido As String
        Private _intDPI As String
        Private _intNoIGSS As String
        Private _datFecha As Date
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
        Public Property AgregarPaciente As ICommand
        Public Property EliminarPaciente As ICommand
        Public Sub New()
            ServiceLocator.RegisterService(Of IPatientDataService)(New PatientDataService)
            _patientAccess = GetService(Of IPatientDataService)()
            ServiceLocator.RegisterService(Of IMainDataService)(New MainDataService)
            _mainAccess = GetService(Of IMainDataService)()
            Pacientes = _mainAccess.GetPatients
            AgregarPaciente = New RelayCommand(AddressOf AgregarNuevoPaciente)
            EliminarPaciente = New RelayCommand(AddressOf EliminarNuevoPaciente)
        End Sub
        Public Sub AgregarNuevoPaciente()
            _patientAccess.AddPatient(idPaciente, NoIGSS, Nombre, Apellido, FechaNacimiento)
            Pacientes = _mainAccess.GetPatients
        End Sub

        Public Sub EliminarNuevoPaciente()
            MsgBox("No Se Puede Eliminar Un Paciente Porque Esta Enlazado A Otros Datos")
        End Sub
    End Class
End Namespace