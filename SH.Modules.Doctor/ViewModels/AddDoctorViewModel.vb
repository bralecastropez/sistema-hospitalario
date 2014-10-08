Imports System.ComponentModel
Imports System.Collections.ObjectModel
Imports System.Windows.Input
Imports System.Threading
Imports SH.BusinessObjects.Models
Imports SH.Infrastructure
Imports SH.Infrastructure.Helpers
Imports SH.BusinessLogic.Services

Namespace SH.Modules.Doctor.ViewModels
    Public Class AddDoctorViewModel
        Inherits ViewModelBase
        Private _strCodigoMedico As String
        Private _strNombre As String
        Private _strApellido As String
        Private _doctorAccess As IDoctorDataService
        Private _mainAccess As IMainDataService
        Private _dgMedicos As List(Of Medico)


        Public Property Medicos As List(Of Medico)
            Get
                Return _dgMedicos
            End Get
            Set(value As List(Of Medico))
                _dgMedicos = value
                OnPropertyChanged("Medicos")
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
        Public Property AgregarMedico As ICommand

        Public Sub New()
            ServiceLocator.RegisterService(Of IDoctorDataService)(New DoctorDataService)
            _doctorAccess = GetService(Of IDoctorDataService)()
            AgregarMedico = New RelayCommand(AddressOf AgregarNuevoMedico)
            ServiceLocator.RegisterService(Of IMainDataService)(New MainDataService)
            _mainAccess = GetService(Of IMainDataService)()
            Medicos = _mainAccess.GetDoctors
        End Sub

        Public Sub AgregarNuevoMedico()
            _doctorAccess.AddDoctor(CodigoMedico, Nombre, Apellido)
            Medicos = _mainAccess.GetDoctors
            MsgBox("Medico Agregado Satisfactoriamente")
        End Sub
    End Class
End Namespace