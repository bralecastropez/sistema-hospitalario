Imports System.ComponentModel
Imports System.Collections.ObjectModel
Imports System.Windows.Input
Imports System.Threading
Imports SH.BusinessObjects.Models
Imports SH.Infrastructure
Imports SH.Infrastructure.Helpers
Imports SH.BusinessLogic.Services

Namespace SH.Modules.Diagnostic.ViewModels
    Public Class AddDiagnosticViewModel
        Inherits ViewModelBase

        Private _strDPI As String
        Private _strDescripcion As String
        Private _strCodigoDiagnosticoPaciente As String
        Private _strCodigoDiagnosticoMedico As String
        Private _strCodigoMedico As String
        Private _diagnosticAccess As IDiagnosticDataService
        Private _mainAccess As IMainDataService
        Private _dgPacientes As List(Of Paciente)
        Private _dgDiagnosticos As List(Of Diagnostico)
        Private _dgMedicos As List(Of Medico)

        Public Property Pacientes As List(Of Paciente)
            Get
                Return _dgPacientes
            End Get
            Set(value As List(Of Paciente))
                _dgPacientes = value
                OnPropertyChanged("Pacientes")
            End Set
        End Property
        Public Property Diagnosticos As List(Of Diagnostico)
            Get
                Return _dgDiagnosticos
            End Get
            Set(value As List(Of Diagnostico))
                _dgDiagnosticos = value
                OnPropertyChanged("Diagnosticos")
            End Set
        End Property
        Public Property Medicos As List(Of Medico)
            Get
                Return _dgMedicos
            End Get
            Set(value As List(Of Medico))
                _dgMedicos = value
                OnPropertyChanged("Medicos")
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
        Public Property Descripcion As String
            Get
                Return _strDescripcion
            End Get
            Set(value As String)
                _strDescripcion = value
                OnPropertyChanged("Descripcion")
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
        Public Property CodigoDiagnosticoMedico As String
            Get
                Return _strCodigoDiagnosticoMedico
            End Get
            Set(value As String)
                _strCodigoDiagnosticoMedico = value
                OnPropertyChanged("CodigoDiagnosticoMedico")
            End Set
        End Property
        Public Property CodigoDiagnosticoPaciente As String
            Get
                Return _strCodigoDiagnosticoPaciente
            End Get
            Set(value As String)
                _strCodigoDiagnosticoPaciente = value
                OnPropertyChanged("CodigoDiagnosticoPaciente")
            End Set
        End Property
        Public Property AgregarDiagnostico As ICommand
        Public Property AgregarDiagnosticoAPaciente As ICommand
        Public Property AgregarDiagnosticoAMedico As ICommand

        Sub New()
            ServiceLocator.RegisterService(Of IDiagnosticDataService)(New DiagnosticDataService)
            _diagnosticAccess = GetService(Of IDiagnosticDataService)()
            AgregarDiagnostico = New RelayCommand(AddressOf AgregarNuevoDiagnostico)
            AgregarDiagnosticoAPaciente = New RelayCommand(AddressOf AgregarNuevoDiagnosticoAPaciente)
            AgregarDiagnosticoAMedico = New RelayCommand(AddressOf AgregarNuevoDiagnosticoMedico)
            ServiceLocator.RegisterService(Of IMainDataService)(New MainDataService)
            _mainAccess = GetService(Of IMainDataService)()
            Pacientes = _mainAccess.GetPatients
            Medicos = _mainAccess.GetDoctors
            Diagnosticos = _mainAccess.GetDiagnostics
        End Sub

        Public Sub AgregarNuevoDiagnostico()
            _diagnosticAccess.AddDiagnostic(Descripcion)
            Pacientes = _mainAccess.GetPatients
            Medicos = _mainAccess.GetDoctors
            Diagnosticos = _mainAccess.GetDiagnostics
            MsgBox("Diagnostico  Agregado Satisfactoriamente", MsgBoxStyle.MsgBoxRight)
        End Sub
        Public Sub AgregarNuevoDiagnosticoAPaciente()
            _diagnosticAccess.AddDiagnosticToPatient(DPI, CodigoDiagnosticoPaciente)
            Pacientes = _mainAccess.GetPatients
            Medicos = _mainAccess.GetDoctors
            Diagnosticos = _mainAccess.GetDiagnostics
            MsgBox("Diagnostico  Agregado Satisfactoriamente", MsgBoxStyle.MsgBoxRight)
        End Sub
        Public Sub AgregarNuevoDiagnosticoMedico()
            _diagnosticAccess.AddDiagnosticToDoctor(CodigoMedico, CodigoDiagnosticoMedico)
            Pacientes = _mainAccess.GetPatients
            Medicos = _mainAccess.GetDoctors
            Diagnosticos = _mainAccess.GetDiagnostics
            MsgBox("Diagnostico  Agregado Satisfactoriamente", MsgBoxStyle.MsgBoxRight)
        End Sub
    End Class
End Namespace