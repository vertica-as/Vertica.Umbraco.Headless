/**
 * Copyright (c) 2023 Vertica
 * Copyright (c) 2023 I-ology
 */

using System;
using System.Threading;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Iology.HeadlessUmbraco.Core.Rendering;

public abstract class ContentModelBuilder<T> : IContentModelBuilder where T : class
{
	public Type ModelType() => typeof(T);

	public abstract string ContentTypeAlias();

	public async Task<object> BuildContentModelAsync(IPublishedElement content, IContentElementBuilder contentElementBuilder, CancellationToken cancellationToken)
        => await BuildModelAsync(content, contentElementBuilder, cancellationToken).ConfigureAwait(false);

	protected abstract Task<T> BuildModelAsync(IPublishedElement content, IContentElementBuilder contentElementBuilder, CancellationToken cancellationToken);
}
