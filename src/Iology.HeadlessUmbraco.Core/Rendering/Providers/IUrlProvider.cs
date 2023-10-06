/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Iology.HeadlessUmbraco.Core.Rendering.Providers;

public interface IUrlProvider
{
    string UrlFor(IPublishedContent content, UrlMode mode = UrlMode.Auto);

    string UrlFor(Link link);
}
