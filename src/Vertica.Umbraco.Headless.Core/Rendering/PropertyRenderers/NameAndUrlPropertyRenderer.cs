using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Vertica.Umbraco.Headless.Core.Models;
using Vertica.Umbraco.Headless.Core.Rendering.Providers;

namespace Vertica.Umbraco.Headless.Core.Rendering.PropertyRenderers
{
    public abstract class NameAndUrlPropertyRenderer : IPropertyRenderer
    {
	    private readonly IUrlProvider _urlProvider;

	    protected NameAndUrlPropertyRenderer(IUrlProvider urlProvider)
	    {
		    _urlProvider = urlProvider;
	    }

	    public abstract string PropertyEditorAlias { get; }

        public abstract bool IsMultiSelect(IPublishedPropertyType propertyType);

        public Type TypeFor(IPublishedPropertyType propertyType)
	        => IsMultiSelect(propertyType)
		        ? typeof(NameAndUrl[])
		        : typeof(NameAndUrl);

        public virtual Task<object> ValueFor(object umbracoValue, IPublishedProperty property,
            IContentElementBuilder contentElementBuilder)
        {
	        NameAndUrl ToNameAndUrl(IPublishedContent content) => new NameAndUrl(content.Name, _urlProvider.UrlFor(content));

	        return Task.FromResult<object>(umbracoValue switch
            {
                IPublishedContent item => ToNameAndUrl(item),
                IEnumerable<IPublishedContent> items => items.Select(ToNameAndUrl).ToArray(),
                _ => null
            });
        }
    }
}
