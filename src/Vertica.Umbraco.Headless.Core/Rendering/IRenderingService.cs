using Umbraco.Cms.Core.Models.PublishedContent;

namespace Vertica.Umbraco.Headless.Core.Rendering
{
	public interface IRenderingService
	{
		IPropertyRenderer PropertyRendererFor(IPublishedPropertyType propertyType);

		IContentModelBuilder ContentModelBuilderFor(IPublishedContentType contentType);
	}
}