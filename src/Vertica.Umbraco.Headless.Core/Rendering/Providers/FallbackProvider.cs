using Umbraco.Cms.Core.Models.PublishedContent;

namespace Vertica.Umbraco.Headless.Core.Rendering.Providers
{
	public class FallbackProvider : IFallbackProvider
	{
		private readonly Fallback _fallback;

		public FallbackProvider(Fallback fallback)
		{
			_fallback = fallback;
		}

		public Fallback FallbackFor(IPublishedElement content, IPublishedProperty property) => _fallback;
	}
}
