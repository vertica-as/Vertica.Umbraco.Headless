using System;
using System.Threading.Tasks;
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

		protected async Task<IActionResult> ContentFor(int id)
			=> await ContentResultFor(UmbracoHelper.Content(id));

		protected async Task<IActionResult> ContentFor(Guid id)
			=> await ContentResultFor(UmbracoHelper.Content(id));

		protected async Task<IActionResult> ContentResultFor(IPublishedContent content) 
			=> content != null
				? OutputRenderer.ActionResult(await ContentElementFor(content))
				: NotFound();

		protected async Task<IContentElement> ContentElementFor(IPublishedContent content) 
			=> await ContentElementBuilder.ContentElementFor(content);
	}
}
