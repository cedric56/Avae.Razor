using Avae.Services;
using Avae.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MudBlazor.Services;
using System.Diagnostics.CodeAnalysis;

namespace Avae.Razor;

public static class Extensions
{
    public static void RegisterModalFor<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TComponent,
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TViewModel,
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TResult>(
    this IServiceCollection services,
    object? viewKey = null,
    object? viewModelKey = null,
    ServiceLifetime viewModelLifetime = ServiceLifetime.Scoped,
    ServiceLifetime viewLifetime = ServiceLifetime.Scoped)
    where TComponent : class where TViewModel : class, ICloseableViewModel<TResult>
    => services.RegisterWithLifetime<ModalFor<TComponent, TViewModel, TResult>, TViewModel>(
        (sp) => new ModalFor<TComponent, TViewModel, TResult>(sp.GetRequiredService<ModalService>()), viewModelLifetime, viewLifetime, viewKey, viewModelKey);


    public static void RegisterViewFor<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TComponent,
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TViewModel>(
    this IServiceCollection services,    
    object? viewKey = null,
    object? viewModelKey = null,
    ServiceLifetime viewModelLifetime = ServiceLifetime.Scoped,
    ServiceLifetime viewLifetime = ServiceLifetime.Scoped,
    bool centered = false)
    where TComponent : class where TViewModel : class
    => services.RegisterWithLifetime<ViewFor<TComponent, TViewModel>, TViewModel>(
        (sp) => new ViewFor<TComponent, TViewModel>() { Class = centered ? "center" : string.Empty }, viewModelLifetime, viewLifetime, viewKey, viewModelKey);

    public static void RegisterViewFor<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TComponent,
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TViewModel>(
    this IServiceCollection services,
    Func<IServiceProvider, ViewFor<TComponent, TViewModel>> func,
    object? viewKey = null,
    object? viewModelKey = null,
    ServiceLifetime viewModelLifetime = ServiceLifetime.Scoped,
    ServiceLifetime viewLifetime = ServiceLifetime.Scoped)
    where TComponent : class where TViewModel : class
    => services.RegisterWithLifetime<ViewFor<TComponent, TViewModel>, TViewModel>(
        func, viewModelLifetime, viewLifetime, viewKey, viewModelKey);

    public static void RegisterViewFor<
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TComponent,
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TViewModel,
        TArg1>(
        this IServiceCollection services,
        Func<IServiceProvider, TArg1, ViewFor<TComponent, TViewModel>> func,
        object? viewKey = null,
        object? viewModelKey = null,
        ServiceLifetime viewModelLifetime = ServiceLifetime.Scoped,
        ServiceLifetime viewLifetime = ServiceLifetime.Scoped)
        where TComponent : class where TViewModel : class
        => services.RegisterWithLifetime<ViewFor<TComponent, TViewModel>, TViewModel, TArg1>(
            func, viewModelLifetime, viewLifetime, viewKey, viewModelKey);

    public static void RegisterViewFor<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TComponent,
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TViewModel,
    TArg1, TArg2>(
    this IServiceCollection services,
    Func<IServiceProvider, TArg1, TArg2, ViewFor<TComponent, TViewModel>> func,
    object? viewKey = null,
    object? viewModelKey = null,
    ServiceLifetime viewModelLifetime = ServiceLifetime.Scoped,
    ServiceLifetime viewLifetime = ServiceLifetime.Scoped)
    where TComponent : class where TViewModel : class
    => services.RegisterWithLifetime<ViewFor<TComponent, TViewModel>, TViewModel, TArg1, TArg2>(
        func, viewModelLifetime, viewLifetime, viewKey, viewModelKey);

    public static void RegisterViewFor<
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TComponent,
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TViewModel,
        TArg1, TArg2, TArg3>(
        this IServiceCollection services,
        Func<IServiceProvider, TArg1, TArg2, TArg3, ViewFor<TComponent, TViewModel>> func,
        object? viewKey = null,
        object? viewModelKey = null,
        ServiceLifetime viewModelLifetime = ServiceLifetime.Scoped,
        ServiceLifetime viewLifetime = ServiceLifetime.Scoped)
        where TComponent : class where TViewModel : class
        => services.RegisterWithLifetime<ViewFor<TComponent, TViewModel>, TViewModel, TArg1, TArg2, TArg3>(
            func, viewModelLifetime, viewLifetime, viewKey, viewModelKey);

    public static void RegisterViewFor<
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TComponent,
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TViewModel,
        TArg1, TArg2, TArg3, TArg4>(
        this IServiceCollection services,
        Func<IServiceProvider, TArg1, TArg2, TArg3, TArg4, ViewFor<TComponent, TViewModel>> func,
        object? viewKey = null,
        object? viewModelKey = null,
        ServiceLifetime viewModelLifetime = ServiceLifetime.Scoped,
        ServiceLifetime viewLifetime = ServiceLifetime.Scoped)
        where TComponent : class where TViewModel : class
        => services.RegisterWithLifetime<ViewFor<TComponent, TViewModel>, TViewModel, TArg1, TArg2, TArg3, TArg4>(
            func, viewModelLifetime, viewLifetime, viewKey, viewModelKey);

    public static void RegisterViewFor<
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TComponent,
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TViewModel,
        TArg1, TArg2, TArg3, TArg4, TArg5>(
        this IServiceCollection services,
        Func<IServiceProvider, TArg1, TArg2, TArg3, TArg4, TArg5, ViewFor<TComponent, TViewModel>> func,
        object? viewKey = null,
        object? viewModelKey = null,
        ServiceLifetime viewModelLifetime = ServiceLifetime.Scoped,
        ServiceLifetime viewLifetime = ServiceLifetime.Scoped)
        where TComponent : class where TViewModel : class
        => services.RegisterWithLifetime<ViewFor<TComponent, TViewModel>, TViewModel, TArg1, TArg2, TArg3, TArg4, TArg5>(
            func, viewModelLifetime, viewLifetime, viewKey, viewModelKey);

    public static void RegisterViewFor<
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TComponent,
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TViewModel,
        TArg1>(
        this IServiceCollection services,
        object? viewKey = null,
        object? viewModelKey = null,
        ServiceLifetime viewModelLifetime = ServiceLifetime.Scoped,
        ServiceLifetime viewLifetime = ServiceLifetime.Scoped,
        bool centered = false,
        Func<TArg1, Dictionary<string, object>>? viewParameters = null)
        where TComponent : class where TViewModel : class
        => services.RegisterWithLifetime<ViewFor<TComponent, TViewModel>, TViewModel, TArg1>(
             (sp, arg) => new ViewFor<TComponent, TViewModel>(
                 viewParameters is not null ? viewParameters?.Invoke(arg) : [])
             {
                 Class = centered ? "center" : string.Empty

             }, viewModelLifetime, viewLifetime, viewKey, viewModelKey);

    public static void RegisterViewFor<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TComponent,
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TViewModel,
    TArg1, TArg2>(
    this IServiceCollection services,
    object? viewKey = null,
    object? viewModelKey = null,
    ServiceLifetime viewModelLifetime = ServiceLifetime.Scoped,
    ServiceLifetime viewLifetime = ServiceLifetime.Scoped,
    bool centered = false,
    Func<TArg1, TArg2, Dictionary<string, object>>? viewParameters = null)
    where TComponent : class where TViewModel : class
    => services.RegisterWithLifetime<ViewFor<TComponent, TViewModel>, TViewModel, TArg1, TArg2>(
         (sp, arg1, arg2) => new ViewFor<TComponent, TViewModel>(
             viewParameters is not null ? viewParameters?.Invoke(arg1, arg2) : [])
         {
             Class = centered ? "center" : string.Empty
         }, viewModelLifetime, viewLifetime, viewKey, viewModelKey);

    public static void RegisterViewFor<
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TComponent,
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TViewModel,
        TArg1, TArg2, TArg3>(
        this IServiceCollection services,
        object? viewKey = null,
        object? viewModelKey = null,
        ServiceLifetime viewModelLifetime = ServiceLifetime.Scoped,
        ServiceLifetime viewLifetime = ServiceLifetime.Scoped,
        bool centered = false,
        Func<TArg1, TArg2, TArg3, Dictionary<string, object>>? viewParameters = null)
        where TComponent : class where TViewModel : class
        => services.RegisterWithLifetime<ViewFor<TComponent, TViewModel>, TViewModel, TArg1, TArg2, TArg3>(
             (sp, arg1, arg2, arg3) => new ViewFor<TComponent, TViewModel>(
                 viewParameters is not null ? viewParameters?.Invoke(arg1, arg2, arg3) : [])
             {
                 Class = centered ? "center" : string.Empty
             }, viewModelLifetime, viewLifetime, viewKey, viewModelKey);

    public static void RegisterViewFor<
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TComponent,
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TViewModel,
        TArg1, TArg2, TArg3, TArg4>(
        this IServiceCollection services,
        object? viewKey = null,
        object? viewModelKey = null,
        ServiceLifetime viewModelLifetime = ServiceLifetime.Scoped,
        ServiceLifetime viewLifetime = ServiceLifetime.Scoped,
        bool centered = false,
        Func<TArg1, TArg2, TArg3, TArg4, Dictionary<string, object>>? viewParameters = null)
        where TComponent : class where TViewModel : class
        => services.RegisterWithLifetime<ViewFor<TComponent, TViewModel>, TViewModel, TArg1, TArg2, TArg3, TArg4>(
             (sp, arg1, arg2, arg3, arg4) => new ViewFor<TComponent, TViewModel>(
                 viewParameters is not null ? viewParameters?.Invoke(arg1, arg2, arg3, arg4) : [])
             {
                 Class = centered ? "center" : string.Empty
             }, viewModelLifetime, viewLifetime, viewKey, viewModelKey);

    public static void RegisterViewFor<
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TComponent,
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TViewModel,
        TArg1, TArg2, TArg3, TArg4, TArg5>(
        this IServiceCollection services,
        object? viewKey = null,
        object? viewModelKey = null,
        ServiceLifetime viewModelLifetime = ServiceLifetime.Scoped,
        ServiceLifetime viewLifetime = ServiceLifetime.Scoped,
        bool centered = false,
        Func<TArg1, TArg2, TArg3, TArg4, TArg5, Dictionary<string, object>>? viewParameters = null)
        where TComponent : class where TViewModel : class
        => services.RegisterWithLifetime<ViewFor<TComponent, TViewModel>, TViewModel, TArg1, TArg2, TArg3, TArg4, TArg5>(
             (sp, arg1, arg2, arg3, arg4, arg5) => new ViewFor<TComponent, TViewModel>(
                 viewParameters is not null ? viewParameters?.Invoke(arg1, arg2, arg3, arg4, arg5) : [])
             {
                 Class = centered ? "center" : string.Empty
             }, viewModelLifetime, viewLifetime, viewKey, viewModelKey);

    public static void UseAvae(this IServiceCollection services,
        Runtime runtime,
        Func<IServiceProvider, Task>? onCircuitProviderChanged = null,
        NotificationPosition position = NotificationPosition.BottomLeft,
        int maxDispayments = 5)
    {    
        services.AddMudServices(config =>
        {
            config.SnackbarConfiguration = new SnackbarConfiguration()
            {
                PreventDuplicates = false,
                PositionClass = position switch
                {
                    NotificationPosition.TopLeft => Defaults.Classes.Position.TopLeft,
                    NotificationPosition.TopCenter => Defaults.Classes.Position.TopCenter,
                    NotificationPosition.TopRight => Defaults.Classes.Position.TopRight,
                    NotificationPosition.BottomLeft => Defaults.Classes.Position.BottomLeft,
                    NotificationPosition.BottomCenter => Defaults.Classes.Position.BottomCenter,
                    NotificationPosition.BottomRight => Defaults.Classes.Position.BottomRight,
                    _ => Defaults.Classes.Position.TopRight
                },
                MaxDisplayedSnackbars = maxDispayments
            };
        });
        services.AddSingleton<Func<IServiceProvider, Task>>(onCircuitProviderChanged ?? (_ => Task.CompletedTask));
        services.RegisterNavigation();
        services.RegisterEnvironments(runtime);
        services.AddScoped<IRequestedThemeService, RequestThemeService>();
        services.AddScoped<Avae.Services.IDialogService, DialogService>();
        services.AddScoped<IContentDialogService, ContentDialogService>();
        services.AddScoped<ITaskDialogService, TaskDialogService>();
        services.AddScoped<INotificationService, NotificationService>();
        services.AddScoped<ModalService>();
    }
}
