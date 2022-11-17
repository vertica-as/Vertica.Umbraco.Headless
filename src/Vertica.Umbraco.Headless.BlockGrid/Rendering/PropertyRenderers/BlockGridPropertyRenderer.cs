using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Vertica.Umbraco.Headless.Core.Models;
using Vertica.Umbraco.Headless.Core.Rendering;
using Vertica.Umbraco.Headless.BlockGrid.Models;

namespace Vertica.Umbraco.Headless.BlockGrid.Rendering.PropertyRenderers;
public class BlockGridPropertyRenderer : IPropertyRenderer
{
    public string PropertyEditorAlias => Constants.PropertyEditors.Aliases.BlockGrid;

    public Type TypeFor(IPublishedPropertyType propertyType) => typeof(Models.BlockGrid);

    public virtual object? ValueFor(object umbracoValue, IPublishedProperty property, IContentElementBuilder contentElementBuilder)
        => umbracoValue is BlockGridModel grid
            ? new Models.BlockGrid
            {
                GridColumns = grid.GridColumns,
                Blocks = grid.Select(i => BlockGridElementFor(contentElementBuilder, i)).ToArray(),
            }
            : null;

    private static BlockGridElement BlockGridElementFor(IContentElementBuilder builder, BlockGridItem item)
    {
        var contentElementWithSettings = builder.ContentElementFor<BlockGridElement>(item.Content);
        contentElementWithSettings.Settings = builder.ContentElementFor<ContentElement>(item.Settings);
        contentElementWithSettings.RowSpan = item.RowSpan;
        contentElementWithSettings.ColumnSpan = item.ColumnSpan;
        contentElementWithSettings.AreaGridColumns = item.AreaGridColumns;
        contentElementWithSettings.Areas = item.Areas?.Any() == true
            ? item.Areas?.Select(area => BlockGridAreaElementFor(builder, area))
            : null;
        return contentElementWithSettings;
    }

    private static BlockGridAreaElement BlockGridAreaElementFor(IContentElementBuilder builder, BlockGridArea area)
    {
        return new BlockGridAreaElement
        {
            Alias = area.Alias,
            ColumnSpan = area.ColumnSpan,
            RowSpan = area.RowSpan,
            Blocks = area.Select(block => BlockGridElementFor(builder, block)),
        };
    }
}