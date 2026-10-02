using Avae.ViewModels;
using System.Diagnostics.CodeAnalysis;

namespace Avae.Razor;

/// <summary>
/// Typed Blazor modal descriptor that binds a Razor component <typeparamref name="TView"/>
/// to a closeable view-model <typeparamref name="TViewModel"/> producing a result of type
/// <typeparamref name="TResult"/>.
/// </summary>
/// <typeparam name="TView">
/// The Razor component type rendered inside the modal.
/// </typeparam>
/// <typeparam name="TViewModel">
/// The view-model type. Must implement <see cref="ICloseableViewModel{TResult}"/>
/// so the modal can return a result when closed.
/// </typeparam>
/// <typeparam name="TResult">
/// The type of the value returned when the modal is dismissed.
/// </typeparam>
/// <remarks>
/// Implements both <see cref="IViewFor"/> (for the navigation host) and
/// <see cref="IModalFor{TViewModel, TResult}"/> (for the modal service).
/// Calling <see cref="ShowModalAsync"/> displays the modal via <see cref="ModalService"/>
/// and returns the result supplied by the view-model when it closes.
/// </remarks>
public class ModalFor<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TView,
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TViewModel, 
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TResult> :
    ViewFor<TView, TViewModel>, IViewFor, IModalFor<TViewModel, TResult>
    where TViewModel : class, ICloseableViewModel<TResult>
{
    ModalService _modalService;

    /// <summary>
    /// Creates an empty modal descriptor. The view-model must be assigned later
    /// via <see cref="ViewFor{TView, TViewModel}.Context"/> or by supplying parameters manually.
    /// </summary>
    public ModalFor(ModalService modalService)
    {
        _modalService = modalService;
    }

    /// <summary>
    /// Creates a modal descriptor that resolves <typeparamref name="TViewModel"/> from the
    /// given service provider and seeds the component parameters with it.
    /// </summary>
    /// <param name="sp">Service provider used to create / resolve the view-model.</param>
    /// <param name="context">
    /// Optional navigation context (factory / view-model / view parameters)
    /// forwarded to <c>GetViewModel</c>.
    /// </param>
    /// <param name="parameters">
    /// Optional additional component parameters merged with the view-model entry.
    /// </param>
    public ModalFor(ModalService modalService,Dictionary<string, object>? parameters = null)
    {
        _modalService = modalService;
        additionalParameters = parameters;
    }

    /// <summary>
    /// Displays the modal and returns a task that completes with the result
    /// produced when the view-model closes.
    /// </summary>
    /// <returns>
    /// A task that resolves to the <typeparamref name="TResult"/> value supplied
    /// by the view-model, or <see langword="null"/> if the modal was dismissed
    /// without a result.
    /// </returns>
    /// <remarks>
    /// Requires <see cref="ViewFor{TView, TViewModel}.Context"/> to already hold a
    /// non-null <typeparamref name="TViewModel"/> instance.
    /// </remarks>
    public Task<TResult?> ShowModalAsync()
    {
        return _modalService.ShowModalAsync<TViewModel, TResult>(this, (TViewModel)Context!, null);
    }
}