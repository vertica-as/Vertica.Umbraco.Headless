/**
 * Copyright (c) 2023 Vertica
 * Copyright (c) 2023 I-ology
 */

using Iology.HeadlessUmbraco.Core.Models;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PropertyEditors;
using Umbraco.Cms.Core.PropertyEditors.ValueConverters;

namespace Iology.HeadlessUmbraco.Core.Rendering.PropertyRenderers;

public class ColorPickerPropertyRenderer : IPropertyRenderer
{
    public string PropertyEditorAlias => Constants.PropertyEditors.Aliases.ColorPicker;

    public Type TypeFor(IPublishedPropertyType propertyType)
        => propertyType.DataType.ConfigurationAs<ColorPickerConfiguration>()!.UseLabel
            ? typeof(ColorAndLabel)
            : typeof(string);

    public Task<object?> ValueForAsync(object? umbracoValue, IPublishedProperty property, IContentElementBuilder contentElementBuilder, CancellationToken cancellationToken)
        => Task.FromResult(umbracoValue is ColorPickerValueConverter.PickedColor pickedColor
            ? new ColorAndLabel(pickedColor.Color, pickedColor.Label)
            : umbracoValue is string
                ? umbracoValue
                : null);
}
