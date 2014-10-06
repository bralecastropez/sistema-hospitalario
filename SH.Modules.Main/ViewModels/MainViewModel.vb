Imports System.ComponentModel
Imports System.Collections.ObjectModel
Imports System.Windows.Input
Imports System.Threading
Imports SH.BusinessObjects.Models
Imports SH.Infrastructure
Imports SH.Infrastructure.Helpers
Imports SH.BusinessLogic.Services

Namespace SH.Modules.Main.ViewModels
    Public Class MainViewModel
        Inherits ViewModelBase
        Private _BedView As Windows.Visibility = Windows.Visibility.Hidden
        Private _CardView As Windows.Visibility = Windows.Visibility.Hidden
        Private _DiagnosticView As Windows.Visibility = Windows.Visibility.Hidden
        Private _DoctorView As Windows.Visibility = Windows.Visibility.Hidden
        Private _PatientView As Windows.Visibility = Windows.Visibility.Hidden
        Private _MainView As Windows.Visibility = Windows.Visibility.Hidden
        Private _PlantView As Windows.Visibility = Windows.Visibility.Hidden

        Public Property BedView As Windows.Visibility
            Get
                Return _BedView
            End Get
            Set(value As Windows.Visibility)
                _BedView = value
            End Set
        End Property
        Public Property CardView As Windows.Visibility
            Get
                Return _CardView
            End Get
            Set(value As Windows.Visibility)
                _CardView = value
            End Set
        End Property
        Public Property DiagnosticView As Windows.Visibility
            Get
                Return _DiagnosticView
            End Get
            Set(value As Windows.Visibility)
                _DiagnosticView = value
            End Set
        End Property
        Public Property DoctorView As Windows.Visibility
            Get
                Return _DoctorView
            End Get
            Set(value As Windows.Visibility)
                _DoctorView = value
            End Set
        End Property
        Public Property PatientView As Windows.Visibility
            Get
                Return _PatientView
            End Get
            Set(value As Windows.Visibility)
                _PatientView = value
            End Set
        End Property
        Public Property MainView As Windows.Visibility
            Get
                Return _MainView
            End Get
            Set(value As Windows.Visibility)
                _MainView = value
            End Set
        End Property
        Public Property PlantView As Windows.Visibility
            Get
                Return _PlantView
            End Get
            Set(value As Windows.Visibility)
                _PlantView = value
            End Set
        End Property

    End Class
End Namespace
