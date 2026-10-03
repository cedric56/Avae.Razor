using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Avae.Razor;

/// <summary>
/// Typed Blazor view descriptor that maps a concrete component type <typeparamref name="TView"/>
/// to the Avae navigation layer.
/// </summary>
/// <typeparam name="TView">
/// The Razor component type that will be rendered for this view entry.
/// </typeparam>
/// <remarks>
/// Used by the host to resolve which component to display when the router navigates
/// to a matching view-model. Parameters (including optional child content) are
/// forwarded to the component via <see cref="ViewFor.Parameters"/>.
/// </remarks>
public class ViewFor<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TView> : ViewFor
{
    private object? _content;
    /// <summary>
    /// Creates an empty descriptor for <typeparamref name="TView"/> with no parameters.
    /// </summary>
    public ViewFor()
    {
    }

    /// <summary>
    /// Creates a descriptor that supplies the given object as the component's
    /// <c>ChildContent</c> render fragment.
    /// </summary>
    /// <param name="content">
    /// Content to wrap in a <see cref="RenderFragment"/> and pass as the
    /// "ChildContent" parameter (typical for layout / host components).
    /// </param>
    public ViewFor(object content)
    {
        _content = content;
    }

    /// <summary>
    /// The concrete Razor component type that should be instantiated for this view.
    /// </summary>
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)]
    public override Type Type => typeof(TView);

    public override RenderFragment Content => builder =>
    {
        builder.OpenComponent(0, Type);

        if (_content is not null)
        {
            builder.AddAttribute(
                1,
                "ChildContent",
                (RenderFragment)(childBuilder =>
                    childBuilder.AddContent(0, _content)));
        }

        if (Parameters is not null)
        {
            foreach (var parameter in Parameters)
            {
                builder.AddAttribute(
                    2,
                    parameter.Key,
                    parameter.Value);
            }
        }

        builder.CloseComponent();
    };
}