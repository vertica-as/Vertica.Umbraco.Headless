/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

using Umbraco.Cms.Core.Models.PublishedContent;
using Iology.HeadlessUmbraco.Core.Models;
using Iology.HeadlessUmbraco.Core.Rendering;

namespace Iology.HeadlessUmbraco.Core.Extensions;

public static class ContentElementBuilderExtensions
{
	public static T RenderedValueFor<T>(this IContentElementBuilder contentElementBuilder, IPublishedElement content, string propertyAlias)
	{
		var property = content.GetProperty(propertyAlias);
		if (property == null)
		{
			return default;
		}

		return contentElementBuilder.PropertyValueFor(content, property) is T value
			? value
			: default;
	}

	public static IContentElement ContentElementFor(this IContentElementBuilder contentElementBuilder, IPublishedElement content)
		=> contentElementBuilder.ContentElementFor<ContentElement>(content);

	public static ContentElementWithSettings ContentElementWithSettingsFor(this IContentElementBuilder contentElementBuilder, IPublishedElement content, IPublishedElement settings)
		=> contentElementBuilder.ContentElementWithSettingsFor(content, settings);
}
