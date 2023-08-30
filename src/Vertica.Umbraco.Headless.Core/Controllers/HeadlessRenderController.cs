using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Vertica.Umbraco.Headless.Core.Models;
using Vertica.Umbraco.Headless.Core.Rendering;
using Vertica.Umbraco.Headless.Core.Rendering.Output;

namespace Vertica.Umbraco.Headless.Core.Controllers
{
	public class HeadlessRenderController : HeadlessRenderController<IPublishedContent>
	{
		public HeadlessRenderController(
			IContentElementBuilder contentElementBuilder,
			IOutputRenderer outputRenderer,
			IPageDataBuilder pageDataBuilder,
			ILogger<RenderController> logger,
			ICompositeViewEngine compositeViewEngine,
			IUmbracoContextAccessor umbracoContextAccessor
		) : base(contentElementBuilder, outputRenderer, pageDataBuilder, logger, compositeViewEngine, umbracoContextAccessor)
		{
		}
	}

	public abstract class HeadlessRenderController<T> : RenderController where T : IPublishedContent
	{
		protected HeadlessRenderController(
			IContentElementBuilder contentElementBuilder,
			IOutputRenderer outputRenderer,
			IPageDataBuilder pageDataBuilder,
			ILogger<RenderController> logger,
			ICompositeViewEngine compositeViewEngine,
			IUmbracoContextAccessor umbracoContextAccessor
		)
			: base(logger, compositeViewEngine, umbracoContextAccessor)
		{
			ContentElementBuilder = contentElementBuilder;
			OutputRenderer = outputRenderer;
			PageDataBuilder = pageDataBuilder;
		}

		protected IContentElementBuilder ContentElementBuilder { get; }

		protected IOutputRenderer OutputRenderer { get; }
		
		protected IPageDataBuilder PageDataBuilder { get; }

        [NonAction]
        public override IActionResult Index()
        {
            throw new NotSupportedException("Sync rendering is not supported");
        }

		public async Task<IActionResult> Index(CancellationToken cancellationToken)
		{
			if (!(CurrentPage is T content))
			{
				throw new ArgumentException("Wrong type of content", nameof(CurrentPage));
			}

			var pageData = await PageDataForAsync(content);
			return IndexFor(pageData, content);
		}

		protected virtual IActionResult IndexFor(IPageData pageData, T content)
			=> OutputRenderer.ActionResult(pageData);

		protected virtual async Task<IPageData> PageDataForAsync(T content) 
			=> await PageDataBuilder.BuildPageDataAsync(content);
	}
}
