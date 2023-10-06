/**
 * Copyright (c) 2023 Vertica
 * Copyright (c) 2023 I-ology
 */

using Iology.HeadlessUmbraco.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Iology.HeadlessUmbraco.Core.Rendering;

public interface IMetadataBuilder
{
    Task<IMetadata> BuildMetadataAsync(IPublishedContent content, CancellationToken cancellationToken);
}
