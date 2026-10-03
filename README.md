# Avae.Razor

A small Razor/Blazor UI adapter for the Avae services and view-model layers.

The package provides reusable Blazor components, MudBlazor-backed dialog and notification services, view descriptors, MVVM navigation integration, and theme support.

## Features

- MVVM-friendly Razor components through `AvaeComponentBase<TViewModel>`
- `ViewFor<TView>` and `ViewFor<TView, TViewModel>` descriptors for dynamic component rendering
- Modal views backed by closeable view-models
- Content dialogs and task dialogs
- Snackbar notifications
- Theme requests and dark/light theme integration
- Navigation integration with `Avae.ViewModels`
- Reusable form, validation, and layout components

## Requirements

The project currently targets:

- .NET 11
- MudBlazor 9.9.0
- Avae.Services 1.0.0-preview.1
- Avae.ViewModels 1.0.0-preview.1

## Installation

From NuGet:

```bash
dotnet add package Avae.Razor
```

For development from source:

```bash
git clone https://github.com/cedric56/Avae.Razor.git
cd Avae.Razor
dotnet restore Avae.Razor.slnx
dotnet build Avae.Razor.slnx
```

## Registering Avae services

Register the Avae integration from your application's service collection:

```csharp
services.UseAvae(
    runtime,
    onCircuitProviderChanged: async provider =>
    {
        // Optional application initialization.
        await Task.CompletedTask;
    });
```

`UseAvae` registers MudBlazor services, Avae navigation/environment services, and the Avae UI service adapters.

## View-model components

Components can inherit from `AvaeComponentBase<TViewModel>`:

```razor
@inherits AvaeComponentBase<MyViewModel>

<MudText Typo="Typo.h5">@ViewModel.Title</MudText>
```

Register the view/view-model pair with:

```csharp
services.RegisterViewFor<MyComponent, MyViewModel>();
```

The view descriptor passes the view-model through the component's `ViewModel` parameter.

## Dialogs and notifications

The Avae service interfaces are implemented using MudBlazor:

- `IContentDialogService`
- `ITaskDialogService`
- `IDialogService`
- `INotificationService`
- `IRequestedThemeService`

This keeps view-model code independent from the underlying MudBlazor API.

## Components

The package includes:

- `AvaeForm`
- `ContentDialog`
- `TaskDialog`
- `MainLayout`
- `ValidationError`

Static assets are under `wwwroot`.

## Project layout

```text
Avae.Razor/
├── Components/       # Razor UI components
├── Services/         # Avae service adapters
├── Views/            # View descriptors and modal support
├── wwwroot/          # CSS/static assets
├── AvaeComponentBase.cs
├── Extensions.cs
└── Avae.Razor.csproj
```

## Development

Build the solution with:

```bash
dotnet restore Avae.Razor.slnx
dotnet build Avae.Razor.slnx
```

There is currently no test project in this repository. The dialog lifecycle, Blazor Server service lifetime, and component initialization paths are therefore worth covering with automated tests.

## License

See [LICENSE](LICENSE).
