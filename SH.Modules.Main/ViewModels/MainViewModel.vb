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
        Private _PatientView As Windows.Visibility = Windows.Visibility.Hidden
        Private _PlantView As Windows.Visibility = Windows.Visibility.Hidden
        
    End Class
End Namespace
