using System;
using System.Threading.Tasks;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PropertyEditors;
using Umbraco.Cms.Core.PropertyEditors.ValueConverters;
using Vertica.Umbraco.Headless.Core.Models;

namespace Vertica.Umbraco.Headless.Core.Rendering.PropertyRenderers
{
	public class ColorPickerPropertyRenderer : IPropertyRenderer
	{
		public string PropertyEditorAlias => Constants.PropertyEditors.Aliases.ColorPicker;

		public Type TypeFor(IPublishedPropertyType propertyType)
			=> propertyType.DataType.ConfigurationAs<ColorPickerConfiguration>().UseLabel
				? typeof(ColorAndLabel)
				: typeof(string);

		public async Task<object> ValueFor(object umbracoValue, IPublishedProperty property,
            IContentElementBuilder contentElementBuilder)
			=> umbracoValue is ColorPickerValueConverter.PickedColor pickedColor
				? new ColorAndLabel(pickedColor.Color, pickedColor.Label)
				: umbracoValue is string
					? umbracoValue
					: null;
	}
}