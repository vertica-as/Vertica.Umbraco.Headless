using System;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Strings;

namespace Vertica.Umbraco.Headless.Core.Rendering.PropertyRenderers
{
	public class MarkdownEditorPropertyRenderer : IPropertyRenderer
	{
		public string PropertyEditorAlias => Constants.PropertyEditors.Aliases.MarkdownEditor;

		public Type TypeFor(IPublishedPropertyType propertyType) => typeof(string);

		public object ValueFor(object umbracoValue, IPublishedProperty property, IContentElementBuilder contentElementBuilder)
			=> (umbracoValue as HtmlEncodedString)?.ToString();
	}
}
