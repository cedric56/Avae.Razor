using Microsoft.AspNetCore.Components;

namespace Avae.Razor;

/// <summary>
/// Base class for Avae Razor components that are bound to a view-model of type
/// <typeparamref name="TViewModel"/>.
/// </summary>
/// <typeparam name="TViewModel">
/// The view-model type associated with the component. Must be a reference type.
/// </typeparam>
/// <remarks>
/// Provides the required DI-injected services (MudBlazor snackbar / dialog service
/// and the ambient <see cref="IServiceProvider"/>) and wires them into the static
/// Avae dialog / notification services on first initialization so that
/// view-models can invoke modals, task dialogs, content dialogs, and toasts
/// without taking a direct dependency on MudBlazor.
/// <para>
/// Concrete pages and modal components should inherit from this type and receive
/// their view-model via the required <see cref="ViewModel"/> parameter.
/// </para>
/// </remarks>
public partial class AvaeComponentBase<TViewModel> : ComponentBase
    where TViewModel : class
{
    /// <summary>
    /// MudBlazor snackbar service used by <see cref="NotificationService"/>
    /// to display transient toasts.
    /// </summary>
    [Inject]
    public required MudBlazor.ISnackbar Snackbar { get; set; }

    /// <summary>
    /// MudBlazor dialog service used by the Avae dialog / modal services
    /// (<see cref="TaskDialogService"/>, <see cref="ContentDialogService"/>,
    /// <see cref="DialogService"/>, <see cref="ModalService"/>).
    /// </summary>
    [Inject]
    public required MudBlazor.IDialogService MudDialogService { get; set; }

    /// <summary>
    /// Ambient service provider, available for resolving additional services
    /// from within the component or its view-model helpers.
    /// </summary>
    [Inject]
    public required IServiceProvider Provider { get; set; }

    /// <summary>
    /// The view-model instance bound to this component.
    /// </summary>
    /// <remarks>
    /// Marked <see cref="EditorRequiredAttribute"/> so the host must supply it
    /// (typically via the parameters dictionary built by <c>ViewFor&lt;TView, TViewModel&gt;</c>).
    /// </remarks>
    [Parameter, EditorRequired]
    public required TViewModel ViewModel { get; set; }

    /// <summary>
    /// Called once when the component is first initialized.
    /// Registers the injected MudBlazor services with the static Avae service
    /// facades so that subsequent dialog / notification calls work correctly.
    /// </summary>
    protected override void OnInitialized()
    {
        base.OnInitialized();

        // Bridge MudBlazor services into the static Avae facades used by view-models.
        TaskDialogService.MudDialogService = MudDialogService;
        ContentDialogService.MudDialogService = MudDialogService;
        NotificationService.SnackbarService = Snackbar;
        DialogService.MudDialogService = MudDialogService;
        ModalService.MudDialogService = MudDialogService;
    }
}