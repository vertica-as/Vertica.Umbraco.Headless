using System.Threading;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Vertica.Umbraco.Headless.Core.Models;

namespace Vertica.Umbraco.Headless.Core.Rendering
{
    public interface IContentElementBuilder
    {
	    Task<T> ContentElementForAsync<T>(IPublishedElement content, CancellationToken cancellationToken) where T : class, IContentElement, new();

	    Task<ContentElementWithSettings> ContentElementWithSettingsForAsync(IPublishedElement content,
            IPublishedElement settings, CancellationToken cancellationToken);

        Task<object> PropertyValueForAsync(IPublishedElement content, IPublishedProperty property,
            CancellationToken cancellationToken);
    }
}