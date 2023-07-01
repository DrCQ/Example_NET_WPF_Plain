# NET WPF Application (XAML Designer Error)
This is an simple NET7 - WPF application to show the XAML Designer error while using the CefSharp browser. Following Nuget packages are used:
- CommunityToolkit.Mvvm (V8.2.0)
- Microsoft.Extensions.DependencyInjection (V7.0.0)
- CefSharp.Wpf.NETCore (V114.2.100)
## Architecture
The XAML MainWindow is hosting three Border elements in the Grid for: Title, Chromium WebBrowser and 'Close' Button.
The 'Close' Button is bounded to the _CloseCommand_ defined in the _MainWindowViewModel_ class and using the _MainWindow_ refernce as CommandParameter.

The _MainWindowViewModel_ class is using the CommunityToolkit.Mvvm to create the 'Close' command as _RelayCommand(Of Window)_.

The _ViewModelLocator_ class is using the IServiveProvider interface to allow the View classes (like _MainWindow_) to access the related ViewModel classes (like _MainWindowViewModel_).
## Error Description
This small application runs as expected without any runtime errors (in Debug and Release mode), but the XAML Designer is raising an exception:

_Parameter "parameter" (object) cannot be of type Microsoft.VisualStudio.XSurface.Wpf.Window, as the command type requires an argument of type System.Windows.Window. (Parameter 'parameter')_

StackTrace:

 at CommunityToolkit.Mvvm.Input.RelayCommand`1.ThrowArgumentExceptionForInvalidCommandArgument(Object parameter)
   at CommunityToolkit.Mvvm.Input.RelayCommand`1.CanExecute(Object parameter)
   at System.Windows.Controls.Primitives.ButtonBase.UpdateCanExecute()
   at System.Windows.DependencyObject.OnPropertyChanged(DependencyPropertyChangedEventArgs e)
   at System.Windows.FrameworkElement.OnPropertyChanged(DependencyPropertyChangedEventArgs e)
   at System.Windows.DependencyObject.NotifyPropertyChange(DependencyPropertyChangedEventArgs args)
   at System.Windows.DependencyObject.UpdateEffectiveValue(EntryIndex entryIndex, DependencyProperty dp, PropertyMetadata metadata, EffectiveValueEntry oldEntry, EffectiveValueEntry& newEntry, Boolean coerceWithDeferredReference, Boolean coerceWithCurrentValue, OperationType operationType)
   at System.Windows.DependencyObject.InvalidateProperty(DependencyProperty dp, Boolean preserveCurrentValue)
   at System.Windows.Data.BindingExpression.TransferValue(Object newValue, Boolean isASubPropertyChange)
   at System.Windows.Data.BindingExpression.Activate(Object item)
   at System.Windows.Data.BindingExpression.AttachToContext(AttachAttempt attempt)
   at System.Windows.Data.BindingExpression.MS.Internal.Data.IDataBindEngineClient.AttachToContext(Boolean lastChance)
   at MS.Internal.Data.DataBindEngine.Task.Run(Boolean lastChance)
   at MS.Internal.Data.DataBindEngine.Run(Object arg)
   at MS.Internal.Data.DataBindEngine.OnLayoutUpdated(Object sender, EventArgs e)
   at System.Windows.ContextLayoutManager.fireLayoutUpdateEvent()
   at System.Windows.ContextLayoutManager.UpdateLayout()
   at Microsoft.VisualStudio.DesignTools.WpfTap.WpfVisualTreeService.VisualTree.DispatcherVisualTreeContext.UpdateLayout()
   at Microsoft.VisualStudio.XSurface.Wpf.DesignerTapInstanceManager.AfterProcessActions(TapInstanceBuilderContext context)

   The VS Tooltip over the ChromiumWebBrowser shows: _Cannot load a reference assembly for execution_

   ## Unexpected Behavior
   Commenting the _CommandParameter_ of the 'Close' button is not raising the XAML Designer exception, but of cource the execution is not working (app is not closing).
   
 CommandParameter="{Binding Mode=OneWay, RelativeSource={RelativeSource AncestorType={x:Type local:MainWindow}}}"
    
   
