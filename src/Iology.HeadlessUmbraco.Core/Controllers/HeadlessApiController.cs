/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

using System;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common;
using Umbraco.Cms.Web.Common.Controllers;
using Iology.HeadlessUmbraco.Core.Extensions;
using Iology.HeadlessUmbraco.Core.Models;
using Iology.HeadlessUmbraco.Core.Rendering;
using Iology.HeadlessUmbraco.Core.Rendering.Output;

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

	protected IActionResult ContentFor(int id)
		=> ContentResultFor(UmbracoHelper.Content(id));

	protected IActionResult ContentFor(Guid id)
		=> ContentResultFor(UmbracoHelper.Content(id));

	protected IActionResult ContentResultFor(IPublishedContent content) 
		=> content != null
			? OutputRenderer.ActionResult(ContentElementFor(content))
			: NotFound();

	protected IContentElement ContentElementFor(IPublishedContent content) 
		=> ContentElementBuilder.ContentElementFor(content);
}
