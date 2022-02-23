using System;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Vertica.Umbraco.Headless.Core.Rendering.PropertyRenderers
{
	public abstract class UnsupportedPropertyRenderer : IPropertyRenderer
	{
		public abstract string PropertyEditorAlias { get; }

		public Type TypeFor(IPublishedPropertyType propertyType) => typeof(object);

		public object ValueFor(object umbracoValue, IPublishedProperty property, IContentElementBuilder contentElementBuilder) => null;
	}
}
