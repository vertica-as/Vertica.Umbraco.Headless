/**
 * Copyright (c) 2023 Vertica
 * Copyright (c) 2023 I-ology
 */

using Iology.HeadlessUmbraco.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Iology.HeadlessUmbraco.Core.Rendering;

public interface IPageDataBuilder
{
    Task<IPageData> BuildPageDataAsync(IPublishedContent content, CancellationToken cancellationToken);
}
