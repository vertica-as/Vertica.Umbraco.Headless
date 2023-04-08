/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Iology.HeadlessUmbraco.Core.Models;

namespace Iology.HeadlessUmbraco.Core.Rendering.PropertyRenderers;

public class BlockListPropertyRenderer : IPropertyRenderer
{
	public string PropertyEditorAlias => Constants.PropertyEditors.Aliases.BlockList;

	public Type TypeFor(IPublishedPropertyType propertyType) => typeof(ContentElementWithSettings[]);

	public virtual object ValueFor(object umbracoValue, IPublishedProperty property, IContentElementBuilder contentElementBuilder)
		=> umbracoValue is IEnumerable<BlockListItem> items
			? items.Select(i => contentElementBuilder.ContentElementWithSettingsFor(i.Content, i.Settings)).ToArray()
			: null;
}
