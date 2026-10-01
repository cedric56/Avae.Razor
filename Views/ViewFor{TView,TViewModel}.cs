using Avae.ViewModels;
using System.Diagnostics.CodeAnalysis;

namespace Avae.Razor;

/// <summary>
/// Typed Blazor view descriptor that binds a Razor component <typeparamref name="TView"/>
/// to its corresponding view-model <typeparamref name="TViewModel"/>.
/// </summary>
/// <typeparam name="TView">
/// The Razor component type that will be rendered for this view entry.
/// </typeparam>
/// <typeparam name="TViewModel">
/// The view-model type associated with the component. Must be a reference type.
/// </typeparam>
/// <remarks>
/// Implements <see cref="IViewFor"/> so the Avae <c>Router</c> can treat this
/// descriptor as a navigable view. The view-model is resolved via DI and passed
/// to the component as the <c>ViewModel</c> parameter (see <see cref="AvaeComponentBase{TViewModel}"/>).
/// </remarks>
public class ViewFor<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)]TView,
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TViewModel> : ViewFor, IViewFor
    where TViewModel : class
{
    private object? _context;

    /// <summary>
    /// The current view-model instance associated with this view.
    /// </summary>
    /// <remarks>
    /// Setting the property triggers <see cref="OnContextChanged"/> so that
    /// <see cref="ViewFor.Parameters"/> is populated with the view-model when
    /// it has not already been supplied via the constructor.
    /// </remarks>
    public object? Context
    {
        get => _context;
        set
        {
            _context = value;
            OnContextChanged(_context);
        }
    }

    /// <summary>
    /// Creates an empty descriptor. The view-model must be assigned later
    /// via <see cref="Context"/> or by supplying parameters manually.
    /// </summary>
    public ViewFor()
    {
    }

    /// <summary>
    /// Creates a descriptor that resolves <typeparamref name="TViewModel"/> from the
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
    public ViewFor(Dictionary<string, object>? parameters = null)
    {
        additionalParameters = parameters;
    }

    /// <summary>
    /// The concrete Razor component type that should be instantiated for this view.
    /// </summary>
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)]
    public override Type Type => typeof(TView);

    /// <summary>
    /// Called when <see cref="Context"/> is set. If no parameters have been
    /// supplied yet, builds a parameter dictionary containing the view-model.
    /// </summary>
    /// <param name="context">The newly assigned view-model instance (may be null).</param>
    protected void OnContextChanged(object? context)
    {
        if (context is null)
            return;

        Parameters = new Dictionary<string, object>(additionalParameters ?? [])
        {
            { nameof(AvaeComponentBase<TViewModel>.ViewModel), (TViewModel)context! }
        };
    }
}