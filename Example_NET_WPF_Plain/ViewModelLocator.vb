Imports Microsoft.Extensions.DependencyInjection

Namespace ViewModel

    Public NotInheritable Class ViewModelLocator

#Region "Private variables"

        Private _mainVM As MainWindowViewModel = Nothing

#End Region

#Region "Properties: MainWindowVM"

        ''' <summary>
        ''' returns the <see cref="MainWindowViewModel"/> instance
        ''' </summary>
        ReadOnly Property MainWindowVM As MainWindowViewModel
            Get
                If Me._mainVM Is Nothing Then _mainVM = VMServices.GetService(Of MainWindowViewModel)
                Return _mainVM
            End Get
        End Property

#End Region

#Region "Private properties: VMServices"

        Private Shared Property VMServices As IServiceProvider = Nothing

#End Region

        Sub New()

            If VMServices Is Nothing Then

                'Create a new instance of ServiceCollection for 
                Dim services As New ServiceCollection

                'register all ViewModel classes
                services.AddTransient(Of MainWindowViewModel)

                'Assign the resulting service provide to the private VMServices Property
                VMServices = services.BuildServiceProvider

            End If

        End Sub

    End Class

End Namespace

