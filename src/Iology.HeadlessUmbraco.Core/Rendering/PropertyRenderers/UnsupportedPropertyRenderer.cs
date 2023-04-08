/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

using System;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Iology.HeadlessUmbraco.Core.Rendering.PropertyRenderers;

public abstract class UnsupportedPropertyRenderer : IPropertyRenderer
{
	public abstract string PropertyEditorAlias { get; }

	public Type TypeFor(IPublishedPropertyType propertyType) => typeof(object);

	public object ValueFor(object umbracoValue, IPublishedProperty property, IContentElementBuilder contentElementBuilder) => null;
}
