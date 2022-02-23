using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Vertica.Umbraco.Headless.Core.Rendering.Providers
{
    public interface IUrlProvider
    {
        string UrlFor(IPublishedContent content, UrlMode mode = UrlMode.Auto);

        string UrlFor(Link link);
    }
}