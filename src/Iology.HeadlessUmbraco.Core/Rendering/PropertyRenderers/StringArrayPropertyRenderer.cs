/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Iology.HeadlessUmbraco.Core.Rendering.PropertyRenderers;

public abstract class StringArrayPropertyRenderer : IPropertyRenderer
{
	public abstract string PropertyEditorAlias { get; }

	public Type TypeFor(IPublishedPropertyType propertyType) => typeof(string[]);

	public object ValueFor(object umbracoValue, IPublishedProperty property, IContentElementBuilder contentElementBuilder)
		=> umbracoValue is IEnumerable<string> value ? value.ToArray() : null;
}
