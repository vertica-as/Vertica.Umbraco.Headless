using Umbraco.Cms.Core.Composing;
using Vertica.Umbraco.Headless.Core.Rendering;

namespace Vertica.Umbraco.Headless.Core.Composing
{
	public class PropertyRendererTypeCollectionBuilder : LazyCollectionBuilderBase<PropertyRendererTypeCollectionBuilder, PropertyRendererTypeCollection, IPropertyRenderer>
	{
		protected override PropertyRendererTypeCollectionBuilder This => this;
	}
}
