/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PropertyEditors;
using Umbraco.Cms.Core.PropertyEditors.ValueConverters;
using Umbraco.Extensions;
using Iology.HeadlessUmbraco.Core.Models;
using Iology.HeadlessUmbraco.Core.Rendering.Providers;

namespace Iology.HeadlessUmbraco.Core.Rendering.PropertyRenderers;

public class MediaPickerPropertyRenderer : IPropertyRenderer
{
	private readonly IUrlProvider _urlProvider;

	public MediaPickerPropertyRenderer(IUrlProvider urlProvider)
	{
		_urlProvider = urlProvider;
	}

	public string PropertyEditorAlias => Constants.PropertyEditors.Aliases.MediaPicker;

	public Type TypeFor(IPublishedPropertyType propertyType)
		=> propertyType.DataType.ConfigurationAs<MediaPickerConfiguration>().Multiple
			? typeof(Media[])
			: typeof(Media);

	public virtual object ValueFor(object umbracoValue, IPublishedProperty property, IContentElementBuilder contentElementBuilder)
	{
		Media CreateMedia(IPublishedContent media)
		{
			var imageCropperValue = media.Value<ImageCropperValue>(Constants.Conventions.Media.File);
			return MediaPicker3PropertyRenderer.ToMedia(media, imageCropperValue, contentElementBuilder, _urlProvider, UrlMode.Auto);
		}

		return umbracoValue switch
		{
			IPublishedContent item => CreateMedia(item),
			IEnumerable<IPublishedContent> items => items.Select(CreateMedia).ToArray(),
			_ => null
		};
	}
}
