Imports SH.Modules.Diagnostic.ViewModels

Namespace SH.Modules.Diagnostic.Views
    Public Class AddDiagnosticView
        Sub New()

            ' Llamada necesaria para el diseñador.
            InitializeComponent()

            ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
            Me.DataContext = New AddDiagnosticViewModel()
        End Sub
    End Class
End Namespace