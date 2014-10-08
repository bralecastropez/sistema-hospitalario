Imports System.ComponentModel
Imports System.Collections.ObjectModel
Imports System.Windows.Input
Imports System.Threading
Imports SH.BusinessObjects.Models
Imports SH.Infrastructure
Imports SH.Infrastructure.Helpers
Imports SH.BusinessLogic.Services

Namespace SH.Modules.Plant.ViewModels
    Public Class AddPlantViewModel
        Inherits ViewModelBase
        Private _strDPIMedico As String
        Private _strDPICama As String
        Private _strNumeroCama As String
        Private _strCodigoMedico As String
        Private _DiagnosticAccess As IDiagnosticDataService
        Private _mainAccess As IMainDataService
        Private _dgMedicos As List(Of Medico)
        Private _dgCamas As List(Of Cama)
        Private _dgPacientes As List(Of Paciente)

        Public Property Medicos As List(Of Medico)
            Get
                Return _dgMedicos
            End Get
            Set(value As List(Of Medico))
                _dgMedicos = value
                OnPropertyChanged("Medicos")
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
        Public Property Pacientes As List(Of Paciente)
            Get
                Return _dgPacientes
            End Get
            Set(value As List(Of Paciente))
                _dgPacientes = value
                OnPropertyChanged("Pacientes")
            End Set
        End Property

        Public Property DPIMedico As String
            Get
                Return _strDPIMedico
            End Get
            Set(value As String)
                _strDPIMedico = value
                OnPropertyChanged("DPIMedico")
            End Set
        End Property
        Public Property DPICama As String
            Get
                Return _strDPICama
            End Get
            Set(value As String)
                _strDPICama = value
                OnPropertyChanged("DPI")
            End Set
        End Property
        Public Property CodigoMedico As String
            Get
                Return _strCodigoMedico
            End Get
            Set(value As String)
                _strCodigoMedico = value
                OnPropertyChanged("CodigoMedico")
            End Set
        End Property
        Public Property NumeroCama As String
            Get
                Return _strNumeroCama
            End Get
            Set(value As String)
                _strNumeroCama = value
                OnPropertyChanged("NumeroCama")
            End Set
        End Property
        Public Property AgregarCamaAPaciente As ICommand
        Public Property AgregarMedicoAPaciente As ICommand

        Sub New()
            ServiceLocator.RegisterService(Of IDiagnosticDataService)(New DiagnosticDataService)
            _DiagnosticAccess = GetService(Of IDiagnosticDataService)()
            AgregarCamaAPaciente = New RelayCommand(AddressOf AddBedToPatient)
            AgregarMedicoAPaciente = New RelayCommand(AddressOf AddDoctorToPatient)
            ServiceLocator.RegisterService(Of IMainDataService)(New MainDataService)
            _mainAccess = GetService(Of IMainDataService)()
            Pacientes = _mainAccess.GetPatients
            Medicos = _mainAccess.GetDoctors
            Camas = _mainAccess.GetBeds
        End Sub

        Public Sub AddBedToPatient()
            _DiagnosticAccess.AddBedToPatient(DPICama, NumeroCama)
            Pacientes = _mainAccess.GetPatients
            Medicos = _mainAccess.GetDoctors
            Camas = _mainAccess.GetBeds
        End Sub
        Public Sub AddDoctorToPatient()
            _DiagnosticAccess.AddPatientToDoctor(CodigoMedico, DPIMedico)
            Pacientes = _mainAccess.GetPatients
            Medicos = _mainAccess.GetDoctors
            Camas = _mainAccess.GetBeds
        End Sub
    End Class
End Namespace