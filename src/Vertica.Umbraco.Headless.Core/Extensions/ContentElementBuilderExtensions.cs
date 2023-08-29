using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Vertica.Umbraco.Headless.Core.Models;
using Vertica.Umbraco.Headless.Core.Rendering;

namespace Vertica.Umbraco.Headless.Core.Extensions
{
	public static class ContentElementBuilderExtensions
	{
		public static async Task<T> RenderedValueFor<T>(this IContentElementBuilder contentElementBuilder, IPublishedElement content, string propertyAlias)
		{
			var property = content.GetProperty(propertyAlias);
			if (property == null)
			{
				return default;
			}

			return (await contentElementBuilder.PropertyValueFor(content, property)) is T value
				? value
				: default;
		}

		public static async Task<IContentElement> ContentElementFor(this IContentElementBuilder contentElementBuilder, IPublishedElement content)
			=> await contentElementBuilder.ContentElementFor<ContentElement>(content);

		public static async Task<ContentElementWithSettings> ContentElementWithSettingsFor(this IContentElementBuilder contentElementBuilder, IPublishedElement content, IPublishedElement settings)
			=> await contentElementBuilder.ContentElementWithSettingsFor(content, settings);
	}
}
