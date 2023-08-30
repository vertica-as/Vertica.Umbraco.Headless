﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Vertica.Umbraco.Headless.Core.Rendering.PropertyRenderers
{
	public abstract class StringArrayPropertyRenderer : IPropertyRenderer
	{
		public abstract string PropertyEditorAlias { get; }

		public Type TypeFor(IPublishedPropertyType propertyType) => typeof(string[]);

		public Task<object> ValueFor(object umbracoValue, IPublishedProperty property,
            IContentElementBuilder contentElementBuilder)
			=> Task.FromResult<object>(umbracoValue is IEnumerable<string> value ? value.ToArray() : null);
	}
}
