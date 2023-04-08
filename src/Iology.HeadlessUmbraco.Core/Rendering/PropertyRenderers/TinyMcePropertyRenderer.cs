/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

using System;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Strings;

namespace Iology.HeadlessUmbraco.Core.Rendering.PropertyRenderers;

public class TinyMcePropertyRenderer : IPropertyRenderer
{
    public string PropertyEditorAlias => Constants.PropertyEditors.Aliases.TinyMce;

    public Type TypeFor(IPublishedPropertyType propertyType) => typeof(string);

    public virtual object ValueFor(object umbracoValue, IPublishedProperty property, IContentElementBuilder contentElementBuilder)
		=> (umbracoValue as HtmlEncodedString)?.ToString();
}
