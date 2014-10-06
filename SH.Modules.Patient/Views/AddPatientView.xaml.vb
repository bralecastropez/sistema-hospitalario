Imports SH.Modules.Patient.ViewModels

Namespace SH.Modules.Patient.Views
    Public Class AddPatientView
        Sub New()

            ' Llamada necesaria para el diseñador.
            InitializeComponent()

            ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
            Me.DataContext = New AddPatientViewModel()
        End Sub
    End Class
End Namespace