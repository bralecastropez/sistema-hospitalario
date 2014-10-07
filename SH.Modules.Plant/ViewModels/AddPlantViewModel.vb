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
            AgregarCamaAPaciente = New RelayCommand(AddressOf AddBedToPatient)
            AgregarMedicoAPaciente = New RelayCommand(AddressOf AddDoctorToPatient)
        End Sub

        Public Sub AddBedToPatient()
            MsgBox("Agregado Satisfactoriamente")
        End Sub
        Public Sub AddDoctorToPatient()
            MsgBox("Agregado Satisfactoriamente")
        End Sub
    End Class
End Namespace