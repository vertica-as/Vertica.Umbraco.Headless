/**
 * Copyright (c) 2023 Vertica
 * Copyright (c) 2023 I-ology
 */

using Iology.HeadlessUmbraco.Core.Extensions;
using Iology.HeadlessUmbraco.Core.Models;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Iology.HeadlessUmbraco.Core.Rendering.PropertyRenderers;

public class BlockListPropertyRenderer : IPropertyRenderer
{
    public string PropertyEditorAlias => Constants.PropertyEditors.Aliases.BlockList;

    public Type TypeFor(IPublishedPropertyType propertyType) => typeof(ContentElementWithSettings[]);

    public virtual async Task<object?> ValueForAsync(object? umbracoValue, IPublishedProperty property, IContentElementBuilder contentElementBuilder, CancellationToken cancellationToken)
    {
        if (umbracoValue is IEnumerable<BlockListItem> items)
        {
            return await items
                .Select(i => contentElementBuilder.ContentElementWithSettingsForAsync(i.Content, i.Settings, cancellationToken))
                .ToArrayAsync()
                .ConfigureAwait(false);
        }

        return null;
    }
}
