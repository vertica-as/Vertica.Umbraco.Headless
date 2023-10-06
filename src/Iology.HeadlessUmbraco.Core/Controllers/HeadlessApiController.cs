/**
 * Copyright (c) 2023 Vertica
 * Copyright (c) 2023 I-ology
 */

using Iology.HeadlessUmbraco.Core.Extensions;
using Iology.HeadlessUmbraco.Core.Models;
using Iology.HeadlessUmbraco.Core.Rendering;
using Iology.HeadlessUmbraco.Core.Rendering.Output;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common;
using Umbraco.Cms.Web.Common.Controllers;

namespace Iology.HeadlessUmbraco.Core.Controllers;

public abstract class HeadlessApiController : UmbracoApiController
{
    protected HeadlessApiController(IContentElementBuilder contentElementBuilder, IOutputRenderer outputRenderer, UmbracoHelper umbracoHelper)
    {
        ContentElementBuilder = contentElementBuilder;
        OutputRenderer = outputRenderer;
        UmbracoHelper = umbracoHelper;
    }

    protected IContentElementBuilder ContentElementBuilder { get; }

    protected IOutputRenderer OutputRenderer { get; }
        
    protected UmbracoHelper UmbracoHelper { get; }

    protected async Task<IActionResult> ContentForAsync(int id, CancellationToken cancellationToken)
        => await ContentResultForAsync(UmbracoHelper.Content(id), cancellationToken).ConfigureAwait(false);

    protected async Task<IActionResult> ContentForAsync(Guid id, CancellationToken cancellationToken)
        => await ContentResultForAsync(UmbracoHelper.Content(id), cancellationToken).ConfigureAwait(false);

    protected async Task<IActionResult> ContentResultForAsync(IPublishedContent content, CancellationToken cancellationToken) 
        => content != null
            ? OutputRenderer.ActionResult(await ContentElementForAsync(content, cancellationToken).ConfigureAwait(false))
            : NotFound();

    protected async Task<IContentElement> ContentElementForAsync(IPublishedContent content, CancellationToken cancellationToken) 
        => await ContentElementBuilder.ContentElementForAsync(content, cancellationToken).ConfigureAwait(false);
}
