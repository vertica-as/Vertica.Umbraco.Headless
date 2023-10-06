/**
 * Copyright (c) 2023 Vertica
 * Copyright (c) 2023 I-ology
 */

using Iology.HeadlessUmbraco.Core.Models;
using Iology.HeadlessUmbraco.Core.Rendering.Providers;
using System.Dynamic;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Iology.HeadlessUmbraco.Core.Rendering;

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

    public virtual async Task<T> ContentElementForAsync<T>(IPublishedElement content, CancellationToken cancellationToken)
        where T : class, IContentElement, new()
        => content != null
            ? new T
            {
                Alias = content.ContentType.Alias,
                Content = await MapElementAsync(content, cancellationToken).ConfigureAwait(false)
            }
            : null;

    public virtual async Task<ContentElementWithSettings> ContentElementWithSettingsForAsync(IPublishedElement content, IPublishedElement settings, CancellationToken cancellationToken)
    {
        var contentElementWithSettings = await ContentElementForAsync<ContentElementWithSettings>(content, cancellationToken).ConfigureAwait(false);
        contentElementWithSettings.Settings = await ContentElementForAsync<ContentElement>(settings, cancellationToken).ConfigureAwait(false);
        return contentElementWithSettings;
    }

    public virtual async Task<object> PropertyValueForAsync(IPublishedElement content, IPublishedProperty property, CancellationToken cancellationToken)
    {
        var propertyRenderer = _renderingService.PropertyRendererFor(content.ContentType.GetPropertyType(property.Alias));

        var umbracoValue = UmbracoPropertyValueFor(content, property);

        return await propertyRenderer.ValueForAsync(umbracoValue, property, this, cancellationToken).ConfigureAwait(false);
    }

    protected virtual object UmbracoPropertyValueFor(IPublishedElement content, IPublishedProperty property) 
        => property?.Value(_publishedValueFallback, fallback: FallbackFor(content, property));

    protected virtual Fallback FallbackFor(IPublishedElement content, IPublishedProperty property) 
        => _fallbackProvider.FallbackFor(content, property);

    protected virtual bool ShouldIgnoreProperty(IPublishedElement content, IPublishedProperty property) 
        => false;

    private async Task<object> MapElementAsync(IPublishedElement content, CancellationToken cancellationToken)
    {
        if (content == null)
        {
            return null;
        }

        var contentModelBuilder = _renderingService.ContentModelBuilderFor(content.ContentType);
        object contentModel = null;
        if (contentModelBuilder != null)
        {
            contentModel = await contentModelBuilder.BuildContentModelAsync(content, this, cancellationToken).ConfigureAwait(false);
        }
        return contentModel ?? await MapElementDynamicallyAsync(content, cancellationToken).ConfigureAwait(false);
    }

    private async Task<object> MapElementDynamicallyAsync(IPublishedElement content, CancellationToken cancellationToken)
    {
        var contentModel = new ExpandoObject();
        IDictionary<string, object> contentmodelDictionary = contentModel;

        foreach (var property in content.Properties)
        {
            if (ShouldIgnoreProperty(content, property))
            {
                continue;
            }
            contentmodelDictionary[property.Alias.ToFirstUpper()] = await PropertyValueForAsync(content, property, cancellationToken).ConfigureAwait(false);
        }

        return contentModel;
    }
}
