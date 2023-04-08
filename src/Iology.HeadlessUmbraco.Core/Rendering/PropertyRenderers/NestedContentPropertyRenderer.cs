/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PropertyEditors;
using Iology.HeadlessUmbraco.Core.Extensions;
using Iology.HeadlessUmbraco.Core.Models;

namespace Iology.HeadlessUmbraco.Core.Rendering.PropertyRenderers;

public class NestedContentPropertyRenderer : IPropertyRenderer
{
    public string PropertyEditorAlias => Constants.PropertyEditors.Aliases.NestedContent;

    public Type TypeFor(IPublishedPropertyType propertyType)
    {
	    var config = propertyType.DataType.ConfigurationAs<NestedContentConfiguration>();
	    return config.MinItems == 1 && config.MaxItems == 1
		    ? typeof(IContentElement)
		    : typeof(IContentElement[]);
    }

    public virtual object ValueFor(object umbracoValue, IPublishedProperty property, IContentElementBuilder contentElementBuilder)
    {
        if (umbracoValue is IEnumerable<IPublishedElement> items)
        {
            return items.Select(contentElementBuilder.ContentElementFor).ToArray();
        }

        if (umbracoValue is IPublishedElement item)
        {
            return contentElementBuilder.ContentElementFor(item);
        }

        return null;
    }
}
