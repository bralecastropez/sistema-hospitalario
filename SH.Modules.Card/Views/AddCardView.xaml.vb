Imports SH.Modules.Card.ViewModels

Namespace SH.Modules.Card.Views
    Public Class AddCardView
        Sub New()

            ' Llamada necesaria para el diseñador.
            InitializeComponent()

            ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
            Me.DataContext = New AddCardViewModel()
        End Sub
    End Class
End Namespace
