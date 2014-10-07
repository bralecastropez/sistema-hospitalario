Imports SH.Modules.Main.ViewModels
Namespace SH.WPF.Shell
    Class MainWindow
        Public _mainViewModel As MainViewModel

        Public Property MainViewModel As MainViewModel
            Get
                Return _mainViewModel
            End Get
            Set(value As MainViewModel)
                _mainViewModel = value
            End Set
        End Property
        Sub New()

            ' Llamada necesaria para el diseñador.
            InitializeComponent()

            ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
            MainViewModel = New MainViewModel
            Me.DataContext = MainViewModel
        End Sub
    End Class
End Namespace