/**
 * Copyright (c) 2023 Vertica
 * Copyright (c) 2023 I-ology
 */

using Iology.HeadlessUmbraco.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Iology.HeadlessUmbraco.Core.Rendering;

public interface IContentElementBuilder
{
    Task<T> ContentElementForAsync<T>(IPublishedElement content, CancellationToken cancellationToken)
        where T : class, IContentElement, new();

    Task<ContentElementWithSettings> ContentElementWithSettingsForAsync(IPublishedElement content, IPublishedElement settings, CancellationToken cancellationToken);

    Task<object> PropertyValueForAsync(IPublishedElement content, IPublishedProperty property, CancellationToken cancellationToken);
}
