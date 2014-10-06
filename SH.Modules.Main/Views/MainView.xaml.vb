Imports SH.Modules.Main.ViewModels

Namespace SH.Modules.Main.Views
    Public Class MainView
        Sub New()

            ' Llamada necesaria para el diseñador.
            InitializeComponent()

            ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
            Me.DataContext = New MainViewModel()
        End Sub
    End Class
End Namespace
