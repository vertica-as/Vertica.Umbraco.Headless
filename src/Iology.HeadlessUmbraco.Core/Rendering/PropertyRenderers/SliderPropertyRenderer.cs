/**
 * Copyright (c) 2023 Vertica
 * Copyright (c) 2023 I-ology
 */

using Iology.HeadlessUmbraco.Core.Models;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PropertyEditors;

namespace Iology.HeadlessUmbraco.Core.Rendering.PropertyRenderers;

public class SliderPropertyRenderer : IPropertyRenderer
{
    public string PropertyEditorAlias => Constants.PropertyEditors.Aliases.Slider;

    public Type TypeFor(IPublishedPropertyType propertyType)
        => propertyType.DataType.ConfigurationAs<SliderConfiguration>()!.EnableRange
            ? typeof(DecimalRange) 
            : typeof(decimal);

    public Task<object?> ValueForAsync(object? umbracoValue, IPublishedProperty property, IContentElementBuilder contentElementBuilder, CancellationToken cancellationToken)
    {
        return Task.FromResult<object?>(umbracoValue switch
        {
            Range<decimal> range => new DecimalRange(range.Minimum, range.Maximum),
            decimal value => value,
            _ => 0m
        });
    }
}
