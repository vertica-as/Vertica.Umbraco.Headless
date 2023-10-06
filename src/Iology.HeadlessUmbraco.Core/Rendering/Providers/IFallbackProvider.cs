/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

using Umbraco.Cms.Core.Models.PublishedContent;

namespace Iology.HeadlessUmbraco.Core.Rendering.Providers;

public interface IFallbackProvider
{
    Fallback FallbackFor(IPublishedElement content, IPublishedProperty property);
}
