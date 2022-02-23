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

		public virtual IPageData BuildPageData(IPublishedContent content)
		{
			var pageData = ContentElementBuilder.ContentElementFor<PageData>(content);
			pageData.Metadata = MetadataFor(content);
			pageData.Navigation = NavigationFor(content);
			return pageData;
		}

		protected IContentElementBuilder ContentElementBuilder { get; }

		protected IMetadataBuilder MetadataBuilder { get; }

		protected INavigationBuilder NavigationBuilder { get; }

		protected virtual IMetadata MetadataFor(IPublishedContent content) => MetadataBuilder.BuildMetadata(content);

		protected virtual INavigation NavigationFor(IPublishedContent content) => NavigationBuilder.BuildNavigation(content);
	}
}
