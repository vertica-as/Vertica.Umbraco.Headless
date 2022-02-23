using System;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common;
using Umbraco.Cms.Web.Common.Controllers;
using Vertica.Umbraco.Headless.Core.Extensions;
using Vertica.Umbraco.Headless.Core.Models;
using Vertica.Umbraco.Headless.Core.Rendering;
using Vertica.Umbraco.Headless.Core.Rendering.Output;

namespace Vertica.Umbraco.Headless.Core.Controllers
{
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
}
