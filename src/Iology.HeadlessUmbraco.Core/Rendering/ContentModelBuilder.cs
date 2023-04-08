﻿/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

using System;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Iology.HeadlessUmbraco.Core.Rendering;

public abstract class ContentModelBuilder<T> : IContentModelBuilder where T : class
{
	public Type ModelType() => typeof(T);

	public abstract string ContentTypeAlias();

	public object BuildContentModel(IPublishedElement content, IContentElementBuilder contentElementBuilder) => BuildModel(content, contentElementBuilder);

	protected abstract T BuildModel(IPublishedElement content, IContentElementBuilder contentElementBuilder);
}
