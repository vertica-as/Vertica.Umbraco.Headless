using System;
using System.Threading;
using System.Threading.Tasks;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Strings;

namespace Vertica.Umbraco.Headless.Core.Rendering.PropertyRenderers
{
	public class MarkdownEditorPropertyRenderer : IPropertyRenderer
	{
		public string PropertyEditorAlias => Constants.PropertyEditors.Aliases.MarkdownEditor;

		public Type TypeFor(IPublishedPropertyType propertyType) => typeof(string);

		public Task<object> ValueForAsync(object umbracoValue, IPublishedProperty property,
            IContentElementBuilder contentElementBuilder, CancellationToken cancellationToken)
			=> Task.FromResult<object>((umbracoValue as HtmlEncodedString)?.ToString());
	}
}
