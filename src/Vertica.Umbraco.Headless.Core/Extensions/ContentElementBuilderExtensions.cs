using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Vertica.Umbraco.Headless.Core.Models;
using Vertica.Umbraco.Headless.Core.Rendering;

namespace Vertica.Umbraco.Headless.Core.Extensions
{
	public static class ContentElementBuilderExtensions
	{
		public static async Task<T> RenderedValueForAsync<T>(this IContentElementBuilder contentElementBuilder, IPublishedElement content, string propertyAlias)
		{
			var property = content.GetProperty(propertyAlias);
			if (property == null)
			{
				return default;
			}

			return (await contentElementBuilder.PropertyValueForAsync(content, property)) is T value
				? value
				: default;
		}

		public static async Task<IContentElement> ContentElementForAsync(this IContentElementBuilder contentElementBuilder, IPublishedElement content)
			=> await contentElementBuilder.ContentElementForAsync<ContentElement>(content);

		public static async Task<ContentElementWithSettings> ContentElementWithSettingsForAsync(this IContentElementBuilder contentElementBuilder, IPublishedElement content, IPublishedElement settings)
			=> await contentElementBuilder.ContentElementWithSettingsForAsync(content, settings);
	}
}
