/**
 * Copyright (c) 2023 Vertica
 * Copyright (c) 2023 I-ology
 */

using Iology.HeadlessUmbraco.Core.Models;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PropertyEditors.ValueConverters;

namespace Iology.HeadlessUmbraco.Core.Rendering.PropertyRenderers;

public class ImageCropperPropertyRenderer : IPropertyRenderer
{
    public string PropertyEditorAlias => Constants.PropertyEditors.Aliases.ImageCropper;

    public Type TypeFor(IPublishedPropertyType propertyType) => typeof(ImageCrop);

    public virtual Task<object?> ValueForAsync(object? umbracoValue, IPublishedProperty property, IContentElementBuilder contentElementBuilder, CancellationToken cancellationToken)
    {
        return Task.FromResult<object?>(umbracoValue is ImageCropperValue imageCropperValue
            ? new ImageCrop(imageCropperValue.Src, imageCropperValue)
            : null);
    }
}
