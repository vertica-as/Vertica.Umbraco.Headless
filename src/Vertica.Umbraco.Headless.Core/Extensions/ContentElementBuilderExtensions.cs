using Umbraco.Cms.Core.Models.PublishedContent;
using Vertica.Umbraco.Headless.Core.Models;
using Vertica.Umbraco.Headless.Core.Rendering;

namespace Vertica.Umbraco.Headless.Core.Extensions
{
	public static class ContentElementBuilderExtensions
	{
		public static T RenderedValueFor<T>(this IContentElementBuilder contentElementBuilder, IPublishedElement content, string propertyAlias)
		{
			var property = content.GetProperty(propertyAlias);
			if (property == null)
			{
				return default;
			}

			return contentElementBuilder.PropertyValueFor(content, property) is T value
				? value
				: default;
		}

		public static IContentElement ContentElementFor(this IContentElementBuilder contentElementBuilder, IPublishedElement content)
			=> contentElementBuilder.ContentElementFor<ContentElement>(content);

		public static ContentElementWithSettings ContentElementWithSettingsFor(this IContentElementBuilder contentElementBuilder, IPublishedElement content, IPublishedElement settings)
			=> contentElementBuilder.ContentElementWithSettingsFor(content, settings);
	}
}
