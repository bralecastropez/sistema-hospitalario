Imports System.ComponentModel
Imports System.Collections.ObjectModel
Imports System.Windows.Input
Imports System.Threading
Imports System.Windows
Imports SH.BusinessObjects.Models
Imports SH.Modules.Bed.Views
Imports SH.Modules.Card.Views
Imports SH.Modules.Patient.Views
Imports SH.Modules.Doctor.Views
Imports SH.Modules.Diagnostic.Views
Imports SH.Modules.Plant.Views
Imports SH.Infrastructure
Imports SH.Infrastructure.Helpers
Imports SH.BusinessLogic.Services

Namespace SH.Modules.Main.ViewModels
    Public Class MainViewModel
        Inherits ViewModelBase
#Region "Properties"
        Public Property Cama As ICommand
        Public Property Visita As ICommand
        Public Property Diagnostico As ICommand
        Public Property Medico As ICommand
        Public Property Paciente As ICommand
        Public Property Planta As ICommand
#End Region
        Sub New()
            Cama = New RelayCommand(AddressOf CamaControl)
            Visita = New RelayCommand(AddressOf VisitaControl)
            Paciente = New RelayCommand(AddressOf PacienteControl)
            Diagnostico = New RelayCommand(AddressOf DiagnosticoControl)
            Planta = New RelayCommand(AddressOf PlantaControl)
            Medico = New RelayCommand(AddressOf MedicoControl)
        End Sub

        Public Sub CamaControl()
            Dim BedWindow As New Window
            Dim bedView As New AddBedView
            BedWindow.ResizeMode = ResizeMode.NoResize
            BedWindow.SizeToContent = SizeToContent.WidthAndHeight
            BedWindow.Content() = bedView
            BedWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen
            BedWindow.Show()
        End Sub
        Public Sub VisitaControl()
            Dim CardWindow As New Window
            Dim cardView As New AddCardView
            CardWindow.ResizeMode = ResizeMode.NoResize
            CardWindow.SizeToContent = SizeToContent.WidthAndHeight
            CardWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen
            CardWindow.Content() = cardView
            CardWindow.Show()
        End Sub
        Public Sub PacienteControl()
            Dim PatientWindow As New Window
            Dim patientView As New AddPatientView
            PatientWindow.ResizeMode = ResizeMode.NoResize
            PatientWindow.SizeToContent = SizeToContent.WidthAndHeight
            PatientWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen
            PatientWindow.Content() = patientView
            PatientWindow.Show()
        End Sub
        Public Sub DiagnosticoControl()
            Dim DiagnosticWindow As New Window
            Dim diagnosticView As New AddDiagnosticView
            DiagnosticWindow.ResizeMode = ResizeMode.NoResize
            DiagnosticWindow.SizeToContent = SizeToContent.WidthAndHeight
            DiagnosticWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen
            DiagnosticWindow.Content() = diagnosticView
            DiagnosticWindow.Show()
        End Sub
        Public Sub PlantaControl()
            Dim PlantWindow As New Window
            Dim plantView As New AddPlantView
            PlantWindow.ResizeMode = ResizeMode.NoResize
            PlantWindow.SizeToContent = SizeToContent.WidthAndHeight
            PlantWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen
            PlantWindow.Content() = plantView
            PlantWindow.Show()
        End Sub
        Public Sub MedicoControl()
            Dim DoctorWindow As New Window
            Dim doctorView As New AddDoctorView
            DoctorWindow.ResizeMode = ResizeMode.NoResize
            DoctorWindow.SizeToContent = SizeToContent.WidthAndHeight
            DoctorWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen
            DoctorWindow.Content() = doctorView
            DoctorWindow.Show()
        End Sub
    End Class
End Namespace
