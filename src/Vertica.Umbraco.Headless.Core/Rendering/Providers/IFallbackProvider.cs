using Umbraco.Cms.Core.Models.PublishedContent;

namespace Vertica.Umbraco.Headless.Core.Rendering.Providers
{
	public interface IFallbackProvider
	{
		Fallback FallbackFor(IPublishedElement content, IPublishedProperty property);
	}
}