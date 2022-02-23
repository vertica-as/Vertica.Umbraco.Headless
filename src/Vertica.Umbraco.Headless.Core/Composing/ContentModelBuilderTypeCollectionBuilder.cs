using Umbraco.Cms.Core.Composing;
using Vertica.Umbraco.Headless.Core.Rendering;

namespace Vertica.Umbraco.Headless.Core.Composing
{
	public class ContentModelBuilderTypeCollectionBuilder : LazyCollectionBuilderBase<ContentModelBuilderTypeCollectionBuilder, ContentModelBuilderTypeCollection, IContentModelBuilder>
	{
		protected override ContentModelBuilderTypeCollectionBuilder This => this;
	}
}
