/**
 * Copyright (c) 2023 Vertica
 * Copyright (c) 2023 I-ology
 */

using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Iology.HeadlessUmbraco.Core.Rendering.PropertyRenderers;

public class TinyMcePropertyRenderer : IPropertyRenderer
{
    public string PropertyEditorAlias => Constants.PropertyEditors.Aliases.TinyMce;

    public Type TypeFor(IPublishedPropertyType propertyType) => typeof(string);

    public virtual Task<object?> ValueForAsync(object? umbracoValue, IPublishedProperty property, IContentElementBuilder contentElementBuilder, CancellationToken cancellationToken)
        => Task.FromResult<object?>(umbracoValue is IEnumerable<string> value ? value.ToArray() : null);
}
