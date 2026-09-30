using System.Diagnostics.CodeAnalysis;

namespace Avae.Razor;

/// <summary>
/// Abstract descriptor that represents a Blazor view to be resolved and rendered
/// by the Avae navigation host.
/// </summary>
/// <remarks>
/// Concrete subclasses supply the component <see cref="Type"/> and optional
/// <see cref="Parameters"/> that are passed to the component when it is created.
/// The host uses these descriptors instead of navigating by view type directly,
/// keeping the shared ViewModel layer UI-agnostic.
/// </remarks>
public abstract class ViewFor
{
    /// <summary>
    /// Optional CSS class name(s) applied to the rendered component's root element.
    /// </summary>
    public string Class { get; set; } = string.Empty;

    /// <summary>
    /// The concrete Razor component type that should be instantiated for this view.
    /// </summary>
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)]
    public abstract Type Type { get; }

    /// <summary>
    /// Optional parameter dictionary forwarded to the component instance
    /// (e.g. <c>ViewModel</c>, <c>ChildContent</c>, or arbitrary component parameters).
    /// </summary>
    public IDictionary<string, object>? Parameters { get; set; }
}