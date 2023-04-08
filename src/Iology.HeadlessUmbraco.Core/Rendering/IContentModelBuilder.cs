/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

using System;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Iology.HeadlessUmbraco.Core.Rendering;

public interface IContentModelBuilder : IDiscoverable
{
	string ContentTypeAlias();

	Type ModelType();

	public object BuildContentModel(IPublishedElement content, IContentElementBuilder contentElementBuilder);
}