using System;
using System.Threading.Tasks;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Vertica.Umbraco.Headless.Core.Rendering.PropertyRenderers
{
	public class DateTimePropertyRenderer : IPropertyRenderer
	{
		public string PropertyEditorAlias => Constants.PropertyEditors.Aliases.DateTime;

		public Type TypeFor(IPublishedPropertyType propertyType) => typeof(DateTime?);

		public async Task<object> ValueFor(object umbracoValue, IPublishedProperty property,
            IContentElementBuilder contentElementBuilder)
			=> umbracoValue is DateTime dateTime && dateTime.Year > 1
				? dateTime
				: (DateTime?) null;
	}
}
