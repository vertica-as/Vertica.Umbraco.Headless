/**
 * Copyright (c) 2023 Vertica
 * Copyright (c) 2023 I-ology
 */

using Iology.HeadlessUmbraco.Core.Models;
using Iology.HeadlessUmbraco.Core.Rendering;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Iology.HeadlessUmbraco.Core.Extensions;

public static class ContentElementBuilderExtensions
{
    public static async Task<T> RenderedValueForAsync<T>(this IContentElementBuilder contentElementBuilder, IPublishedElement content, string propertyAlias, CancellationToken cancellationToken)
    {
        var property = content.GetProperty(propertyAlias);
        if (property == null)
        {
            return default;
        }

        return await contentElementBuilder.PropertyValueForAsync(content, property, cancellationToken).ConfigureAwait(false) is T value
            ? value
            : default;
    }

    public static async Task<IContentElement> ContentElementForAsync(
            this IContentElementBuilder contentElementBuilder,
            IPublishedElement content,
            CancellationToken cancellationToken)
            => await contentElementBuilder.ContentElementForAsync<ContentElement>(content, cancellationToken).ConfigureAwait(false);

    public static async Task<ContentElementWithSettings> ContentElementWithSettingsForAsync(
        this IContentElementBuilder contentElementBuilder,
        IPublishedElement content,
        IPublishedElement settings,
        CancellationToken cancellationToken)
        => await contentElementBuilder.ContentElementWithSettingsForAsync(content, settings, cancellationToken).ConfigureAwait(false);
}
