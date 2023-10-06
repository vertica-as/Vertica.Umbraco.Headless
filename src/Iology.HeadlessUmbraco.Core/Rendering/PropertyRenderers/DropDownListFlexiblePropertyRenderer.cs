/**
 * Copyright (c) 2023 Vertica
 * Copyright (c) 2023 I-ology
 */

using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PropertyEditors;

namespace Iology.HeadlessUmbraco.Core.Rendering.PropertyRenderers;

public class DropDownListFlexiblePropertyRenderer : IPropertyRenderer
{
    public string PropertyEditorAlias => Constants.PropertyEditors.Aliases.DropDownListFlexible;

    public Type TypeFor(IPublishedPropertyType propertyType)
        => propertyType.DataType.ConfigurationAs<DropDownFlexibleConfiguration>()!.Multiple
            ? typeof(string[])
            : typeof(string);

    public Task<object?> ValueForAsync(object? umbracoValue, IPublishedProperty property, IContentElementBuilder contentElementBuilder, CancellationToken cancellationToken)
    {
        return Task.FromResult<object?>(umbracoValue switch
        {
            IEnumerable<string> values => values,
            string value => value,
            _ => null
        });
    }
}
