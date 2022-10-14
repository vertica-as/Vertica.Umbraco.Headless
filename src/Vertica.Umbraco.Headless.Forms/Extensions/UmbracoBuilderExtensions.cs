using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.DependencyInjection;
using Vertica.Umbraco.Headless.Forms.Services;

namespace Vertica.Umbraco.Headless.Forms.Extensions;
public static class UmbracoBuilderExtensions
{
    public static IUmbracoBuilder AddHeadlessForms(this IUmbracoBuilder builder)
    {
        builder.Services.AddSingleton<IHeadlessFormService, HeadlessFormService>();
        return builder;
    }
}
