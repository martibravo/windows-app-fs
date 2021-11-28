## F# template for the Windows App SDK

This template makes the [Windows App SDK](https://github.com/microsoft/WindowsAppSDK) (formerly known as Project Reunion) available to F# developers.
Since F# is a fully functional member of the .NET language family, it's already compatible with the SDK's nuget package. 
XAML is not supported, yet, nor creating an UIElement other than a `Button`.


WinUI3 does not support writing UIs without a XAML compiler yet, and that is only available to C++ and C#. Everything else from the SDK 1.0 Stable version should work,

As [WinUI](https://microsoft.github.io/microsoft-ui-xaml/) is a large part of the Windows App SDK, one goal is to also support the latest WinUI app development.

