/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

using System;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Iology.HeadlessUmbraco.Core.Rendering;

public interface IPropertyRenderer : IDiscoverable
{
    string PropertyEditorAlias { get; }

    Type TypeFor(IPublishedPropertyType propertyType);

    object ValueFor(object umbracoValue, IPublishedProperty property, IContentElementBuilder contentElementBuilder);
}
