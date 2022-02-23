using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Vertica.Umbraco.Headless.Core.Rendering.Providers
{
    public class UrlProvider : IUrlProvider
    {
	    public virtual string UrlFor(IPublishedContent content, UrlMode mode = UrlMode.Auto) 
		    => content.ItemType == PublishedItemType.Content || content.ItemType == PublishedItemType.Media 
				? content.Url(mode: mode)
				: null;

		public virtual string UrlFor(Link link) => link.Url;
    }
}
