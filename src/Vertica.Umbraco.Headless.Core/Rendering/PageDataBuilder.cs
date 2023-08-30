using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Vertica.Umbraco.Headless.Core.Models;

namespace Vertica.Umbraco.Headless.Core.Rendering
{
	public class PageDataBuilder : IPageDataBuilder
	{
		public PageDataBuilder(IContentElementBuilder contentElementBuilder, IMetadataBuilder metadataBuilder, INavigationBuilder navigationBuilder)
		{
			ContentElementBuilder = contentElementBuilder;
			MetadataBuilder = metadataBuilder;
			NavigationBuilder = navigationBuilder;
		}

		public virtual async Task<IPageData> BuildPageDataAsync(IPublishedContent content)
		{
			var pageData = await ContentElementBuilder.ContentElementForAsync<PageData>(content).ConfigureAwait(false);
			pageData.Metadata = await MetadataForAsync(content).ConfigureAwait(false);
			pageData.Navigation = await NavigationFor(content).ConfigureAwait(false);
			return pageData;
		}

		protected IContentElementBuilder ContentElementBuilder { get; }

		protected IMetadataBuilder MetadataBuilder { get; }

		protected INavigationBuilder NavigationBuilder { get; }

		protected virtual async Task<IMetadata> MetadataForAsync(IPublishedContent content) => await MetadataBuilder.BuildMetadataAsync(content).ConfigureAwait(false);

		protected virtual async Task<INavigation> NavigationFor(IPublishedContent content) => await NavigationBuilder.BuildNavigationAsync(content).ConfigureAwait(false);
	}
}
