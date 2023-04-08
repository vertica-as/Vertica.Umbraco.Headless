/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

using System;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PropertyEditors.ValueConverters;
using Iology.HeadlessUmbraco.Core.Models;

namespace Iology.HeadlessUmbraco.Core.Rendering.PropertyRenderers;

public class ImageCropperPropertyRenderer : IPropertyRenderer
{
	public string PropertyEditorAlias => Constants.PropertyEditors.Aliases.ImageCropper;

	public Type TypeFor(IPublishedPropertyType propertyType) => typeof(ImageCrop);

	public virtual object ValueFor(object umbracoValue, IPublishedProperty property, IContentElementBuilder contentElementBuilder)
	{
		return umbracoValue is ImageCropperValue imageCropperValue
			? new ImageCrop(imageCropperValue.Src, imageCropperValue)
			: null;
	}
}
