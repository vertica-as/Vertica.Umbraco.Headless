/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

using Iology.HeadlessUmbraco.Core.Composing;
using Iology.HeadlessUmbraco.Core.Controllers;
using Iology.HeadlessUmbraco.Core.Rendering;
using Iology.HeadlessUmbraco.Core.Rendering.Output;
using Iology.HeadlessUmbraco.Core.Rendering.Providers;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Website.Controllers;

namespace Iology.HeadlessUmbraco.Core.Extensions;

public static class UmbracoBuilderExtensions
{
    public static IUmbracoBuilder AddHeadless(this IUmbracoBuilder builder, Fallback defaultFallback = default)
        => builder.AddHeadless<HeadlessRenderController>(defaultFallback);

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
