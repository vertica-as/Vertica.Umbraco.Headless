using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PropertyEditors;
using Umbraco.Cms.Core.PropertyEditors.ValueConverters;
using Umbraco.Extensions;
using Vertica.Umbraco.Headless.Core.Extensions;
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

		public virtual async Task<object> ValueForAsync(object umbracoValue, IPublishedProperty property,
            IContentElementBuilder contentElementBuilder, CancellationToken cancellationToken)
		{
			async Task<Media> CreateMediaAsync(IPublishedContent media)
			{
				var imageCropperValue = media.Value<ImageCropperValue>(Constants.Conventions.Media.File);
				return await MediaPicker3PropertyRenderer.ToMediaAsync(media, imageCropperValue, contentElementBuilder, _urlProvider, UrlMode.Auto, cancellationToken).ConfigureAwait(false);
			}

			return umbracoValue switch
			{
				IPublishedContent item => await CreateMediaAsync(item).ConfigureAwait(false),
				IEnumerable<IPublishedContent> items => await items.ToArrayAsync(CreateMediaAsync).ConfigureAwait(false),
				_ => null
			};
		}
	}
}
