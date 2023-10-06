/**
 * Copyright (c) 2023 I-ology
 */

using Iology.HeadlessUmbraco.Core.Extensions;
using Iology.HeadlessUmbraco.Core.Models;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Iology.HeadlessUmbraco.Core.Rendering.PropertyRenderers;

public class BlockGridPropertyRenderer : IPropertyRenderer
{
    public string PropertyEditorAlias => Constants.PropertyEditors.Aliases.BlockGrid;

    public Type TypeFor(IPublishedPropertyType propertyType) => typeof(BlockGrid);

    public virtual async Task<object?> ValueForAsync(object? umbracoValue, IPublishedProperty property, IContentElementBuilder contentElementBuilder, CancellationToken cancellationToken)
    {
        return umbracoValue is BlockGridModel grid ?
            new BlockGrid
            {
                GridColumns = grid.GridColumns,
                Blocks = await grid.Select(i => BlockGridElementForAsync(contentElementBuilder, i, cancellationToken)).ToArrayAsync().ConfigureAwait(false)
            } : null;
    }

    private async Task<BlockGridElement> BlockGridElementForAsync(IContentElementBuilder builder, BlockGridItem item, CancellationToken cancellationToken)
    {
        var contentElementWithSettings = await builder.ContentElementForAsync<BlockGridElement>(item.Content, cancellationToken).ConfigureAwait(false);
        contentElementWithSettings.Settings = await builder.ContentElementForAsync<ContentElement>(item.Settings, cancellationToken).ConfigureAwait(false);

        contentElementWithSettings.RowSpan = item.RowSpan;
        contentElementWithSettings.ColumnSpan = item.ColumnSpan;
        contentElementWithSettings.AreaGridColumns = item.AreaGridColumns;
        contentElementWithSettings.Areas = item.Areas?.Any() == true
            ? await item.Areas.Select(area => BlockGridAreaElementForAsync(builder, area, cancellationToken)).ToArrayAsync().ConfigureAwait(false)
            : null;

        return contentElementWithSettings;
    }

    private async Task<BlockGridAreaElement> BlockGridAreaElementForAsync(IContentElementBuilder builder, BlockGridArea area, CancellationToken cancellationToken)
    {
        return new BlockGridAreaElement
        {
            Alias = area.Alias,
            ColumnSpan = area.ColumnSpan,
            RowSpan = area.RowSpan,
            Blocks = await area.Select(block => BlockGridElementForAsync(builder, block, cancellationToken)).ToArrayAsync().ConfigureAwait(false)
        };
    }
}
