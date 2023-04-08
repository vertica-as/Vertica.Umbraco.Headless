/**
 * Copyright (c) 2023 I-ology
 */

using Iology.HeadlessUmbraco.Core.Models;
using System;
using System.Linq;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Iology.HeadlessUmbraco.Core.Rendering.PropertyRenderers;

public class BlockGridPropertyRenderer : IPropertyRenderer
{
    public string PropertyEditorAlias => Constants.PropertyEditors.Aliases.BlockGrid;

    public Type TypeFor(IPublishedPropertyType propertyType) => typeof(BlockGrid);

    public virtual object ValueFor(object umbracoValue, IPublishedProperty property, IContentElementBuilder contentElementBuilder)
    {
        return umbracoValue is BlockGridModel grid ?
            new BlockGrid
            {
                GridColumns = grid.GridColumns,
                Blocks = grid.Select(i => BlockGridElementFor(contentElementBuilder, i)).ToArray()
            } : null;
    }

    private BlockGridElement BlockGridElementFor(IContentElementBuilder builder, BlockGridItem item)
    {
        var contentElementWithSettings = builder.ContentElementFor<BlockGridElement>(item.Content);
        contentElementWithSettings.Settings = builder.ContentElementFor<ContentElement>(item.Settings);

        contentElementWithSettings.RowSpan = item.RowSpan;
        contentElementWithSettings.ColumnSpan = item.ColumnSpan;
        contentElementWithSettings.AreaGridColumns = item.AreaGridColumns;
        contentElementWithSettings.Areas = item.Areas?.Any() == true ?
            item.Areas.Select(area => BlockGridAreaElementFor(builder, area)) :
            null;

        return contentElementWithSettings;
    }

    private BlockGridAreaElement BlockGridAreaElementFor(IContentElementBuilder builder, BlockGridArea area)
    {
        return new BlockGridAreaElement
        {
            Alias = area.Alias,
            ColumnSpan = area.ColumnSpan,
            RowSpan = area.RowSpan,
            Blocks = area.Select(block => BlockGridElementFor(builder, block))
        };
    }
}
