/**
 * Copyright (c) 2023 Vertica
 * Copyright (c) 2023 I-ology
 */

using Iology.HeadlessUmbraco.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Iology.HeadlessUmbraco.Core.Rendering;

public class NavigationBuilder : INavigationBuilder
{
    public virtual Task<INavigation> BuildNavigationAsync(IPublishedContent content, CancellationToken cancellationToken)
        => Task.FromResult<INavigation>(BuildNavigation<Navigation>(content));

    protected TNavigation BuildNavigation<TNavigation>(IPublishedContent content) where TNavigation : class, INavigation, new()
        => new TNavigation
        {
            Breadcrumb = content
                .Ancestors()
                .Reverse()
                .Select(c => new BreadcrumbItem(c.Name, c.Url()))
                .ToArray()
        };
}
