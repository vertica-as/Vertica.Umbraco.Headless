/**
 * Copyright (c) 2023 Vertica
 * Copyright (c) 2023 I-ology
 */

using Iology.HeadlessUmbraco.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Iology.HeadlessUmbraco.Core.Rendering;

public class PageDataBuilder : IPageDataBuilder
{
    public PageDataBuilder(IContentElementBuilder contentElementBuilder, IMetadataBuilder metadataBuilder, INavigationBuilder navigationBuilder)
    {
        ContentElementBuilder = contentElementBuilder;
        MetadataBuilder = metadataBuilder;
        NavigationBuilder = navigationBuilder;
    }

    public virtual async Task<IPageData> BuildPageDataAsync(IPublishedContent content, CancellationToken cancellationToken)
    {
        var pageData = await ContentElementBuilder.ContentElementForAsync<PageData>(content, cancellationToken).ConfigureAwait(false);
        pageData.Metadata = await MetadataForAsync(content, cancellationToken).ConfigureAwait(false);
        pageData.Navigation = await NavigationForAsync(content, cancellationToken).ConfigureAwait(false);
        return pageData;
    }

    protected IContentElementBuilder ContentElementBuilder { get; }

    protected IMetadataBuilder MetadataBuilder { get; }

    protected INavigationBuilder NavigationBuilder { get; }

    protected virtual async Task<IMetadata> MetadataForAsync(IPublishedContent content, CancellationToken cancellationToken)
        => await MetadataBuilder.BuildMetadataAsync(content, cancellationToken).ConfigureAwait(false);

    protected virtual async Task<INavigation> NavigationForAsync(IPublishedContent content, CancellationToken cancellationToken)
        => await NavigationBuilder.BuildNavigationAsync(content, cancellationToken).ConfigureAwait(false);
}
