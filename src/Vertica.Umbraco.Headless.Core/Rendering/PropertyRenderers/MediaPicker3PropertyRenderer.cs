using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PropertyEditors;
using Umbraco.Cms.Core.PropertyEditors.ValueConverters;
using Umbraco.Extensions;
using Vertica.Umbraco.Headless.Core.Rendering.Providers;
using Media = Vertica.Umbraco.Headless.Core.Models.Media;

namespace Vertica.Umbraco.Headless.Core.Rendering.PropertyRenderers
{
	public class MediaPicker3PropertyRenderer : IPropertyRenderer
	{
		private readonly IUrlProvider _urlProvider;

		public MediaPicker3PropertyRenderer(IUrlProvider urlProvider)
		{
			_urlProvider = urlProvider;
		}

		public string PropertyEditorAlias => Constants.PropertyEditors.Aliases.MediaPicker3;

		public Type TypeFor(IPublishedPropertyType propertyType)
			=> propertyType.DataType.ConfigurationAs<MediaPicker3Configuration>().Multiple
				? typeof(Media[])
				: typeof(Media);

		public object ValueFor(object umbracoValue, IPublishedProperty property, IContentElementBuilder contentElementBuilder)
		{
			Media CreateMedia(MediaWithCrops media) => ToMedia(media.Content, media.LocalCrops, contentElementBuilder, _urlProvider, UrlMode.Auto);

			return umbracoValue switch
			{
				MediaWithCrops item => CreateMedia(item),
				IEnumerable<MediaWithCrops> items => items.Select(CreateMedia).ToArray(),
				_ => null
			};
		}

		internal static Media ToMedia(IPublishedContent media, ImageCropperValue imageCropperValue, IContentElementBuilder contentElementBuilder, IUrlProvider urlProvider, UrlMode urlMode)
		{
			var additionalProperties = media
				.Properties
				.Where(property => property.Alias.StartsWith("umbraco") == false)
				.ToDictionary(
					property => property.Alias,
					property => contentElementBuilder.PropertyValueFor(media, property)
				);

			return new Media(
				media.Name,
				urlProvider.UrlFor(media, urlMode),
				media.Value<int>(Constants.Conventions.Media.Width),
				media.Value<int>(Constants.Conventions.Media.Height),
				media.Value<string>(Constants.Conventions.Media.Extension),
				imageCropperValue,
				additionalProperties
			);
		}
	}
}
