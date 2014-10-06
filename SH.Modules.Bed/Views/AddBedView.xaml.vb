Imports SH.Modules.Bed.ViewModels

Namespace SH.Modules.Bed.Views
    Public Class AddBedView
        Sub New()

            ' Llamada necesaria para el diseñador.
            InitializeComponent()

            ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
            Me.DataContext = New AddBedViewModel()
        End Sub
    End Class
End Namespace
