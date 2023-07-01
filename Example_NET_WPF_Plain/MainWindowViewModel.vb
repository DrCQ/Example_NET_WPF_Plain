Imports CommunityToolkit.Mvvm.ComponentModel
Imports CommunityToolkit.Mvvm.Input

Namespace ViewModel

    Public Class MainWindowViewModel
        Inherits ObservableObject

        ReadOnly Property CloseCommand As New RelayCommand(Of Window)(
            Sub(wnd As Window)
                wnd.Close()
            End Sub)

    End Class

End Namespace

