Imports SH.Modules.Doctor.ViewModels

Namespace SH.Modules.Doctor.Views
    Public Class AddDoctorView
        Sub New()

            ' Llamada necesaria para el diseñador.
            InitializeComponent()

            ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
            Me.DataContext = New AddDoctorViewModel()
        End Sub
    End Class
End Namespace