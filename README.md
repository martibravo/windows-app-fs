## F# template for the Windows App SDK

This template makes the [Windows App SDK](https://github.com/microsoft/WindowsAppSDK) (formerly known as Project Reunion) available to F# developers.
Since F# is a fully functional member of the .NET language family, it's already compatible with the SDK's nuget package. 
XAML is not supported, yet, nor creating an UIElement other than a `Button`.

Using controls, or XAML, is not supported, but the Windowing APIs and other members of the WindowsAppSDK work as expected.

The WindowsAppSDK is currently in beta, and it's use in unpackaged apps like this one is not currently supported. This support should arrive in the next WindowsAppSDK previews as the 1.0 Release nears (expected in Q4)

As [WinUI](https://microsoft.github.io/microsoft-ui-xaml/) is a large part of the Windows App SDK, one goal is to also support the latest WinUI app development.

