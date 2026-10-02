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
}