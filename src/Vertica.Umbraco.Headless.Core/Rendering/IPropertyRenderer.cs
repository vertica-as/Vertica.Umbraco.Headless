using System;
using System.Threading;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Vertica.Umbraco.Headless.Core.Rendering
{
    public interface IPropertyRenderer : IDiscoverable
    {
        string PropertyEditorAlias { get; }

        Type TypeFor(IPublishedPropertyType propertyType);

        Task<object> ValueForAsync(object umbracoValue, IPublishedProperty property,
            IContentElementBuilder contentElementBuilder, CancellationToken cancellationToken);
    }
}
