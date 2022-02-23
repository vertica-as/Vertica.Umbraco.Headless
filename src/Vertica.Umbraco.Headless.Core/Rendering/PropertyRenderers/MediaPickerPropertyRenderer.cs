using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PropertyEditors;
using Umbraco.Cms.Core.PropertyEditors.ValueConverters;
using Umbraco.Extensions;
using Vertica.Umbraco.Headless.Core.Models;
using Vertica.Umbraco.Headless.Core.Rendering.Providers;

namespace Vertica.Umbraco.Headless.Core.Rendering.PropertyRenderers
{
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
}
