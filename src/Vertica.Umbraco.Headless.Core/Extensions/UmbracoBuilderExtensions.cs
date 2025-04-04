using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Website.Controllers;
using Vertica.Umbraco.Headless.Core.Composing;
using Vertica.Umbraco.Headless.Core.Controllers;
using Vertica.Umbraco.Headless.Core.Rendering;
using Vertica.Umbraco.Headless.Core.Rendering.Output;
using Vertica.Umbraco.Headless.Core.Rendering.Providers;

namespace Vertica.Umbraco.Headless.Core.Extensions
{
	public static class UmbracoBuilderExtensions
	{
		public static IUmbracoBuilder AddHeadless(this IUmbracoBuilder builder, Fallback defaultFallback = default)
		{
			builder.AddNotificationHandler<UmbracoApplicationStartingNotification, DisableTemplatesNotificationHandler>();
			return builder.AddHeadless<HeadlessRenderController>(defaultFallback);
		}

		public static IUmbracoBuilder AddHeadless<TDefaultController>(this IUmbracoBuilder builder, Fallback defaultFallback = default)
			where TDefaultController : IRenderController
		{
			// required dependencies for the headless setup 
			builder.Services.AddSingleton<IContentElementBuilder, ContentElementBuilder>();
			builder.Services.AddSingleton<IFallbackProvider>(_ => new FallbackProvider(defaultFallback));
			builder.Services.AddSingleton<IUrlProvider, UrlProvider>();
			builder.Services.AddSingleton<IOutputRenderer, JsonOutputRenderer>();
			builder.Services.AddSingleton<IRenderingService, RenderingService>();
			builder.Services.AddSingleton<IPageDataBuilder, PageDataBuilder>();
			builder.Services.AddSingleton<IMetadataBuilder, MetadataBuilder>();
			builder.Services.AddSingleton<INavigationBuilder, NavigationBuilder>();

			// change the default render controller to the headless controller
			builder.Services.Configure<UmbracoRenderingDefaultsOptions>(c =>
			{
				c.DefaultControllerType = typeof(TDefaultController);
			});

			builder.WithCollectionBuilder<PropertyRendererTypeCollectionBuilder>()
				.Add(() => builder.TypeLoader.GetTypes<IPropertyRenderer>());

			builder.WithCollectionBuilder<ContentModelBuilderTypeCollectionBuilder>()
				.Add(() => builder.TypeLoader.GetTypes<IContentModelBuilder>());

			return builder;
		}
	}
}
