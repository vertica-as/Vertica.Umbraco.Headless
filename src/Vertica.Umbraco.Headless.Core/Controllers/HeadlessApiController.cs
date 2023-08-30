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

		protected async Task<IActionResult> ContentForAsync(int id)
			=> await ContentResultForAsync(UmbracoHelper.Content(id)).ConfigureAwait(false);

		protected async Task<IActionResult> ContentForAsync(Guid id)
			=> await ContentResultForAsync(UmbracoHelper.Content(id)).ConfigureAwait(false);

		protected async Task<IActionResult> ContentResultForAsync(IPublishedContent content) 
			=> content != null
				? OutputRenderer.ActionResult(await ContentElementForAsync(content).ConfigureAwait(false))
				: NotFound();

		protected async Task<IContentElement> ContentElementForAsync(IPublishedContent content) 
			=> await ContentElementBuilder.ContentElementForAsync(content).ConfigureAwait(false);
	}
}
