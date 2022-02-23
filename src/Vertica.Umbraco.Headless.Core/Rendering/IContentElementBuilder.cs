using Umbraco.Cms.Core.Models.PublishedContent;
using Vertica.Umbraco.Headless.Core.Models;

namespace Vertica.Umbraco.Headless.Core.Rendering
{
    public interface IContentElementBuilder
    {
	    T ContentElementFor<T>(IPublishedElement content) where T : class, IContentElement, new();

	    ContentElementWithSettings ContentElementWithSettingsFor(IPublishedElement content, IPublishedElement settings);

        object PropertyValueFor(IPublishedElement content, IPublishedProperty property);
    }
}