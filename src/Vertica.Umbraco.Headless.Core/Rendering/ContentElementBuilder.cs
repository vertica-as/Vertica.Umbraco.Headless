using System.Collections.Generic;
using System.Dynamic;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;
using Vertica.Umbraco.Headless.Core.Models;
using Vertica.Umbraco.Headless.Core.Rendering.Providers;

namespace Vertica.Umbraco.Headless.Core.Rendering
{
    public class ContentElementBuilder : IContentElementBuilder
    {
	    private readonly IRenderingService _renderingService;
	    private readonly IFallbackProvider _fallbackProvider;
        private readonly IPublishedValueFallback _publishedValueFallback;

        public ContentElementBuilder(
	        IRenderingService renderingService,
	        IFallbackProvider fallbackProvider,
	        IPublishedValueFallback publishedValueFallback)
        {
	        _publishedValueFallback = publishedValueFallback;
	        _fallbackProvider = fallbackProvider;
	        _renderingService = renderingService;
        }

        public virtual T ContentElementFor<T>(IPublishedElement content)
	        where T : class, IContentElement, new()
	        => content != null
		        ? new T
		        {
			        Alias = content.ContentType.Alias,
			        Content = MapElement(content)
		        }
		        : null;

        public virtual ContentElementWithSettings ContentElementWithSettingsFor(IPublishedElement content, IPublishedElement settings)
        {
		// Try to make CI trigger
		var test = "this is valid";
	        var contentElementWithSettings = ContentElementFor<ContentElementWithSettings>(content);
	        contentElementWithSettings.Settings = ContentElementFor<ContentElement>(settings);
	        return contentElementWithSettings;
        }

        public virtual object PropertyValueFor(IPublishedElement content, IPublishedProperty property)
        {
	        var propertyRenderer = _renderingService.PropertyRendererFor(content.ContentType.GetPropertyType(property.Alias));

	        var umbracoValue = UmbracoPropertyValueFor(content, property);

	        return propertyRenderer.ValueFor(umbracoValue, property, this);
        }

        protected virtual object UmbracoPropertyValueFor(IPublishedElement content, IPublishedProperty property) 
	        => property?.Value(_publishedValueFallback, fallback: FallbackFor(content, property));

        protected virtual Fallback FallbackFor(IPublishedElement content, IPublishedProperty property) 
	        => _fallbackProvider.FallbackFor(content, property);

        protected virtual bool ShouldIgnoreProperty(IPublishedElement content, IPublishedProperty property) 
	        => false;

        private object MapElement(IPublishedElement content)
        {
	        if (content == null)
	        {
		        return null;
	        }

	        var contentModelBuilder = _renderingService.ContentModelBuilderFor(content.ContentType);
            return contentModelBuilder?.BuildContentModel(content, this) ?? MapElementDynamically(content);
        }

        private object MapElementDynamically(IPublishedElement content)
        {
	        var contentModel = new ExpandoObject();
	        IDictionary<string, object> contentmodelDictionary = contentModel;

	        foreach (var property in content.Properties)
	        {
		        if (ShouldIgnoreProperty(content, property))
		        {
			        continue;
		        }
		        contentmodelDictionary[property.Alias.ToFirstUpper()] = PropertyValueFor(content, property);
	        }

            return contentModel;
        }
    }
}
