/**
 * Copyright (c) 2023 Vertica
 * Copyright (c) 2023 I-ology
 */

using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Iology.HeadlessUmbraco.Core.Rendering;

public interface IContentModelBuilder : IDiscoverable
{
    string ContentTypeAlias();

    Type ModelType();

    public Task<object> BuildContentModelAsync(IPublishedElement content, IContentElementBuilder contentElementBuilder, CancellationToken cancellationToken);
}
