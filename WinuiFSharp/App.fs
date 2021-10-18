open System
open System.IO
open System.Linq
open System.Runtime.InteropServices
open System.Runtime.InteropServices.WindowsRuntime
open System.Collections.Generic
open System.Xml
open Windows.UI.Xaml

open Windows.Foundation
open Windows.Foundation.Collections
open WinRT
open WinRT.Interop
open System.Windows

open Microsoft.UI.Xaml
open Microsoft.UI
open Microsoft.UI.Windowing
open Microsoft.UI.Xaml.Controls
open Microsoft.UI.Xaml.Core.Direct
open Microsoft.UI.Dispatching
open Microsoft.UI.Windowing
open Microsoft.UI.Xaml.XamlTypeInfo
open Microsoft.Windows.ApplicationModel.DynamicDependency
open Microsoft.Windows.ApplicationModel.WindowsAppRuntime


type App() as this =
    inherit Application()

    let mutable _window:Window = Unchecked.defaultof<Window>
    let mutable _appWindow:AppWindow = Unchecked.defaultof<AppWindow>

    override this.OnLaunched(e:LaunchActivatedEventArgs) =
        _window <- new Window()
        this.RequestedTheme <- ApplicationTheme.Dark
        _appWindow <- AppWindow.GetFromWindowId(Win32Interop.GetWindowIdFromWindow(WindowNative.GetWindowHandle(_window)))

        let titleBar = _appWindow.TitleBar
        _appWindow.SetPresenter(AppWindowPresenterKind.Overlapped)

        
        titleBar.BackgroundColor <- Colors.Black
        titleBar.ForegroundColor <- Colors.White
        titleBar.ButtonBackgroundColor <- Colors.Black
        titleBar.ButtonForegroundColor <- Colors.White

        let MainPage = new Page()
        let button = new Button()
        button.HorizontalAlignment <- HorizontalAlignment.Center
        button.Content <- "Click me!"
        button.CornerRadius <- new CornerRadius(4.0)
        MainPage.Content <- button

        _window.Title <- "WinUI 3 from F#"
        _window.Content <- MainPage
        _window.Activate()

    

 [<DllImport("Microsoft.ui.xaml.dll")>]
 extern void XamlCheckProcessRequirements()




    
[<EntryPoint>]
let main argv =
    let version_tag = "preview2"
    let mdd_version = (uint32)0x00010000
    let mutable f = 0

    let boot:bool = Bootstrap.TryInitialize(mdd_version, version_tag, &f)

    if(boot) then
        XamlCheckProcessRequirements()
        WinRT.ComWrappersSupport.InitializeComWrappers()
        App.Start(ApplicationInitializationCallback(fun a -> (
            let context = new DispatcherQueueSynchronizationContext(DispatcherQueue.GetForCurrentThread());
            System.Threading.SynchronizationContext.SetSynchronizationContext(context);
            ignore(App())
        )))
    0