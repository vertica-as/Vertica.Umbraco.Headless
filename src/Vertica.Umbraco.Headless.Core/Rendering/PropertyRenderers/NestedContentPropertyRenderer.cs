﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PropertyEditors;
using Vertica.Umbraco.Headless.Core.Extensions;
using Vertica.Umbraco.Headless.Core.Models;

namespace Vertica.Umbraco.Headless.Core.Rendering.PropertyRenderers
{
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

        public virtual async Task<object> ValueForAsync(object umbracoValue, IPublishedProperty property,
            IContentElementBuilder contentElementBuilder, CancellationToken cancellationToken)
        {
            if (umbracoValue is IEnumerable<IPublishedElement> items)
            {
                return await items
                    .Select(i => contentElementBuilder.ContentElementForAsync(i, cancellationToken))
                    .ToArrayAsync()
                    .ConfigureAwait(false);
            }

            if (umbracoValue is IPublishedElement item)
            {
                return await contentElementBuilder.ContentElementForAsync(item, cancellationToken).ConfigureAwait(false);
            }

            return null;
        }
    }
}
