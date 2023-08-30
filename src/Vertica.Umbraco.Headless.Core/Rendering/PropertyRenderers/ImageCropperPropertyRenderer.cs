using System;
using System.Threading.Tasks;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PropertyEditors.ValueConverters;
using Vertica.Umbraco.Headless.Core.Models;

namespace Vertica.Umbraco.Headless.Core.Rendering.PropertyRenderers
{
	public class ImageCropperPropertyRenderer : IPropertyRenderer
	{
		public string PropertyEditorAlias => Constants.PropertyEditors.Aliases.ImageCropper;

		public Type TypeFor(IPublishedPropertyType propertyType) => typeof(ImageCrop);

		public virtual Task<object> ValueForAsync(object umbracoValue, IPublishedProperty property,
            IContentElementBuilder contentElementBuilder)
		{
			return Task.FromResult<object>(umbracoValue is ImageCropperValue imageCropperValue
                ? new ImageCrop(imageCropperValue.Src, imageCropperValue)
                : null);
		}
	}
}
