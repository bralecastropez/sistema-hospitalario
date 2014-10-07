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
        Public _strCodigoMedico As String
        Public _strNombre As String
        Public _strApellido As String
        Public _doctorAccess As IDoctorDataService

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
        End Sub

        Public Sub AgregarNuevoMedico()
            _doctorAccess.AddDoctor(CodigoMedico, Nombre, Apellido)
            MsgBox("Medico Agregado Satisfactoriamente")
        End Sub
    End Class
End Namespace