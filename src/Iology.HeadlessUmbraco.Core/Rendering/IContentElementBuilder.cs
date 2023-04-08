/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

using Umbraco.Cms.Core.Models.PublishedContent;
using Iology.HeadlessUmbraco.Core.Models;

namespace Iology.HeadlessUmbraco.Core.Rendering;

public interface IContentElementBuilder
{
	T ContentElementFor<T>(IPublishedElement content) where T : class, IContentElement, new();

	ContentElementWithSettings ContentElementWithSettingsFor(IPublishedElement content, IPublishedElement settings);

    object PropertyValueFor(IPublishedElement content, IPublishedProperty property);
}