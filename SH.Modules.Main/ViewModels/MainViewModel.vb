Imports System.ComponentModel
Imports System.Collections.ObjectModel
Imports System.Windows.Input
Imports System.Threading
Imports System.Windows
Imports SH.BusinessObjects.Models
Imports SH.Infrastructure
Imports SH.Infrastructure.Helpers
Imports SH.BusinessLogic.Services

Namespace SH.Modules.Main.ViewModels
    Public Class MainViewModel
        Inherits ViewModelBase
        Private _mainViewModel As MainViewModel
        Private _BedView As Visibility = Visibility.Hidden
        Private _CardView As Visibility = Visibility.Hidden
        Private _DiagnosticView As Visibility = Visibility.Hidden
        Private _DoctorView As Visibility = Visibility.Hidden
        Private _PatientView As Visibility = Visibility.Hidden
        Private _PlantView As Visibility = Visibility.Hidden
#Region "Properties"
        Public Property MainViewModel As MainViewModel
            Get
                Return _mainViewModel
            End Get
            Set(value As MainViewModel)
                _mainViewModel = value
            End Set
        End Property

        Public Property BedView As Windows.Visibility
            Get
                Return _BedView
            End Get
            Set(value As Windows.Visibility)
                _BedView = value
                OnPropertyChanged("Cama")
            End Set
        End Property
        Public Property CardView As Windows.Visibility
            Get
                Return _CardView
            End Get
            Set(value As Windows.Visibility)
                _CardView = value
                OnPropertyChanged("Visita")
            End Set
        End Property
        Public Property DiagnosticView As Windows.Visibility
            Get
                Return _DiagnosticView
            End Get
            Set(value As Windows.Visibility)
                _DiagnosticView = value
                OnPropertyChanged("Diagnostico")
            End Set
        End Property
        Public Property DoctorView As Windows.Visibility
            Get
                Return _DoctorView
            End Get
            Set(value As Windows.Visibility)
                _DoctorView = value
                OnPropertyChanged("Medico")
            End Set
        End Property
        Public Property PatientView As Windows.Visibility
            Get
                Return _PatientView
            End Get
            Set(value As Windows.Visibility)
                _PatientView = value
                OnPropertyChanged("Paciente")
            End Set
        End Property
        Public Property PlantView As Windows.Visibility
            Get
                Return _PlantView
            End Get
            Set(value As Windows.Visibility)
                _PlantView = value
                OnPropertyChanged("Planta")
            End Set
        End Property

        Public Property Cama As ICommand
        Public Property Visita As ICommand
        Public Property Diagnostico As ICommand
        Public Property Medico As ICommand
        Public Property Paciente As ICommand
        Public Property Planta As ICommand
#End Region
        Sub New()
            Me.MainViewModel = Me
            Cama = New RelayCommand(AddressOf CamaControl)
            Visita = New RelayCommand(AddressOf VisitaControl)
            Paciente = New RelayCommand(AddressOf PacienteControl)
            Diagnostico = New RelayCommand(AddressOf DiagnosticoControl)
            Planta = New RelayCommand(AddressOf PlantaControl)
            Medico = New RelayCommand(AddressOf MedicoControl)
        End Sub

        Public Sub CamaControl()
            CardView = Visibility.Hidden
            BedView = Visibility.Visible
            DiagnosticView = Visibility.Hidden
            DoctorView = Visibility.Hidden
            PatientView = Visibility.Hidden
            PlantView = Visibility.Hidden
            MsgBox(BedView.ToString)
        End Sub
        Public Sub VisitaControl()
            CardView = Visibility.Visible
            BedView = Visibility.Hidden
            DiagnosticView = Visibility.Hidden
            DoctorView = Visibility.Hidden
            PatientView = Visibility.Hidden
            PlantView = Visibility.Hidden
            MsgBox(CardView.ToString)
        End Sub
        Public Sub PacienteControl()
            CardView = Visibility.Hidden
            BedView = Visibility.Hidden
            DiagnosticView = Visibility.Hidden
            DoctorView = Visibility.Hidden
            PatientView = Visibility.Visible
            PlantView = Visibility.Hidden
            MsgBox(PatientView.ToString)
        End Sub
        Public Sub DiagnosticoControl()
            CardView = Visibility.Hidden
            BedView = Visibility.Hidden
            DiagnosticView = Visibility.Visible
            DoctorView = Visibility.Hidden
            PatientView = Visibility.Hidden
            PlantView = Visibility.Hidden
            MsgBox(DiagnosticView.ToString)
        End Sub
        Public Sub PlantaControl()
            CardView = Visibility.Hidden
            BedView = Visibility.Hidden
            DiagnosticView = Visibility.Hidden
            DoctorView = Visibility.Hidden
            PatientView = Visibility.Hidden
            PlantView = Visibility.Visible
            MsgBox(PlantView.ToString)
        End Sub
        Public Sub MedicoControl()
            CardView = Visibility.Hidden
            BedView = Visibility.Hidden
            DiagnosticView = Visibility.Hidden
            DoctorView = Visibility.Visible
            PatientView = Visibility.Hidden
            PlantView = Visibility.Hidden
            MsgBox(DoctorView.ToString)
        End Sub
    End Class
End Namespace
