Imports SH.Modules.Plant.ViewModels

Namespace SH.Modules.Plant.Views
    Public Class AddPlantView
        Sub New()

            ' Llamada necesaria para el diseñador.
            InitializeComponent()

            ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
            Me.DataContext = New AddPlantViewModel()
        End Sub
    End Class
End Namespace