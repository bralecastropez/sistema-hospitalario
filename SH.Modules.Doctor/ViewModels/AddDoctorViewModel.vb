Imports System.ComponentModel
Imports System.Collections.ObjectModel
Imports System.Windows
Imports System.Windows.Input
Imports System.Threading
Imports SH.BusinessObjects.Models
Imports SH.Infrastructure
Imports SH.Infrastructure.Helpers
Imports SH.BusinessLogic.Services

Namespace SH.Modules.Doctor.ViewModels
    Public Class AddDoctorViewModel
        Inherits ViewModelBase
#Region "Declarations"
        Private _strCodigoMedico As String
        Private _strNombre As String
        Private _strApellido As String
        Private _strNuevoNombre As String
        Private _strNuevoApellido As String
        Private _vblUpdate As Visibility = Visibility.Hidden
        Private _doctorAccess As IDoctorDataService
        Private _mainAccess As IMainDataService
        Private _medico As Medico
        Private _dgMedicos As List(Of Medico)
#End Region
        
#Region "Properties"
        Public Property Medico As Medico
            Get
                Return _medico
            End Get
            Set(value As Medico)
                _medico = value
                OnPropertyChanged("Medico")
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
                Return _strApellido
            End Get
            Set(value As String)
                _strApellido = value
                OnPropertyChanged("NuevoApellido")
            End Set
        End Property
        Public Property AgregarMedico As ICommand
        Public Property EditarMedico As ICommand
        Public Property ActualizarMedico As ICommand
#End Region
        

        Public Sub New()
            ServiceLocator.RegisterService(Of IDoctorDataService)(New DoctorDataService)
            _doctorAccess = GetService(Of IDoctorDataService)()
            AgregarMedico = New RelayCommand(AddressOf AgregarNuevoMedico)
            EditarMedico = New RelayCommand(AddressOf EditarNuevoMedico)
            ActualizarMedico = New RelayCommand(AddressOf SetMedico)
            ServiceLocator.RegisterService(Of IMainDataService)(New MainDataService)
            _mainAccess = GetService(Of IMainDataService)()
            Medicos = _mainAccess.GetDoctors
        End Sub

#Region "Methods"
        Public Sub AgregarNuevoMedico()
            _doctorAccess.AddDoctor(CodigoMedico, Nombre, Apellido)
            Medicos = _mainAccess.GetDoctors
        End Sub

        Public Sub EditarNuevoMedico()
            If Not Medico Is Nothing Then
                NuevoApellido = Medico.apellido
                NuevoNombre = Medico.nombre
                Update = Visibility.Visible
            Else
                MsgBox("Debe Seleccionar Una Fila")
            End If
        End Sub
        Public Sub SetMedico()
            Medicos = _mainAccess.GetDoctors
            _doctorAccess.UpdateDoctor(Medico.codigoMedico, NuevoNombre, NuevoApellido)
            Medicos = _mainAccess.GetDoctors
            Update = Visibility.Hidden
        End Sub
#End Region
       
    End Class
End Namespace