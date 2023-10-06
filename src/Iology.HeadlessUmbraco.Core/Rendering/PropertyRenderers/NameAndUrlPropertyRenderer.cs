/**
 * Copyright (c) 2023 Vertica
 * Copyright (c) 2023 I-ology
 */

using Iology.HeadlessUmbraco.Core.Models;
using Iology.HeadlessUmbraco.Core.Rendering.Providers;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Iology.HeadlessUmbraco.Core.Rendering.PropertyRenderers;

public abstract class NameAndUrlPropertyRenderer : IPropertyRenderer
{
    private readonly IUrlProvider _urlProvider;

    protected NameAndUrlPropertyRenderer(IUrlProvider urlProvider)
    {
        _urlProvider = urlProvider;
    }

    public abstract string PropertyEditorAlias { get; }

    public abstract bool IsMultiSelect(IPublishedPropertyType propertyType);

    public Type TypeFor(IPublishedPropertyType propertyType)
        => IsMultiSelect(propertyType)
            ? typeof(NameAndUrl[])
            : typeof(NameAndUrl);

    public virtual Task<object?> ValueForAsync(object? umbracoValue, IPublishedProperty property, IContentElementBuilder contentElementBuilder, CancellationToken cancellationToken)
    {
        NameAndUrl ToNameAndUrl(IPublishedContent content) => new NameAndUrl(content.Name, _urlProvider.UrlFor(content));

        return Task.FromResult<object?>(umbracoValue switch
        {
            IPublishedContent item => ToNameAndUrl(item),
            IEnumerable<IPublishedContent> items => items.Select(ToNameAndUrl).ToArray(),
            _ => null
        });
    }
}
