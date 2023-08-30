using System;
using System.Threading;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Vertica.Umbraco.Headless.Core.Rendering.PropertyRenderers
{
	public abstract class GenericPropertyRenderer<T> : IPropertyRenderer
	{
		public abstract string PropertyEditorAlias { get; }

		public Type TypeFor(IPublishedPropertyType propertyType) => typeof(T);

		public Task<object> ValueForAsync(object umbracoValue, IPublishedProperty property,
            IContentElementBuilder contentElementBuilder, CancellationToken cancellationToken)
			=> Task.FromResult<object>(umbracoValue is T value ? value : default);
	}
}
