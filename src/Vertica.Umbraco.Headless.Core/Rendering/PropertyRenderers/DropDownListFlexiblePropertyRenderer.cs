using System;
using System.Collections.Generic;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PropertyEditors;

namespace Vertica.Umbraco.Headless.Core.Rendering.PropertyRenderers
{
	public class DropDownListFlexiblePropertyRenderer : IPropertyRenderer
	{
		public string PropertyEditorAlias => Constants.PropertyEditors.Aliases.DropDownListFlexible;

		public Type TypeFor(IPublishedPropertyType propertyType)
			=> propertyType.DataType.ConfigurationAs<DropDownFlexibleConfiguration>().Multiple
				? typeof(string[])
				: typeof(string);

		public object ValueFor(object umbracoValue, IPublishedProperty property, IContentElementBuilder contentElementBuilder)
		{
			return umbracoValue switch
			{
				IEnumerable<string> values => values,
				string value => value,
				_ => null
			};
		}
	}
}
