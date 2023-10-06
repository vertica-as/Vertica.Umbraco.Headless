/**
 * Copyright (c) 2023 Vertica
 * Copyright (c) 2023 I-ology
 */

using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Iology.HeadlessUmbraco.Core.Rendering;

public interface IPropertyRenderer : IDiscoverable
{
    string PropertyEditorAlias { get; }

    Type TypeFor(IPublishedPropertyType propertyType);

    Task<object?> ValueForAsync(object? umbracoValue, IPublishedProperty property, IContentElementBuilder contentElementBuilder, CancellationToken cancellationToken);
}
