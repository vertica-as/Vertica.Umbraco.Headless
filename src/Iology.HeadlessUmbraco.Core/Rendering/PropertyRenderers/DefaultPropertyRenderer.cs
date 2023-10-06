/**
 * Copyright (c) 2023 Vertica
 * Copyright (c) 2023 I-ology
 */

using System.Dynamic;
using Newtonsoft.Json.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Iology.HeadlessUmbraco.Core.Rendering.PropertyRenderers;

public class DefaultPropertyRenderer : IPropertyRenderer
{
    public virtual string PropertyEditorAlias => "*";

    public Type TypeFor(IPublishedPropertyType propertyType) => typeof(object);

    public virtual Task<object?> ValueForAsync(object? umbracoValue, IPublishedProperty property, IContentElementBuilder contentElementBuilder, CancellationToken cancellationToken)
    {
        if (umbracoValue is JObject jObject)
        {
            return Task.FromResult<object?>(jObject.ToObject<ExpandoObject>());
        }

        return Task.FromResult(umbracoValue);
    }
}
