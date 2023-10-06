/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

using Umbraco.Cms.Core.Models.PublishedContent;

namespace Iology.HeadlessUmbraco.Core.Rendering.Providers;

    public class FallbackProvider : IFallbackProvider
{
    private readonly Fallback _fallback;

    public FallbackProvider(Fallback fallback)
    {
        _fallback = fallback;
    }

    public Fallback FallbackFor(IPublishedElement content, IPublishedProperty property) => _fallback;
}
