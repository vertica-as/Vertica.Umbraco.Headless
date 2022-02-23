using System;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;
using Umbraco.Cms.Core.DependencyInjection;
using Vertica.Umbraco.Headless.Swagger.Filters;
using Vertica.Umbraco.Headless.Swagger.TypeMapping;

namespace Vertica.Umbraco.Headless.Swagger.Extensions
{
	public static class UmbracoBuilderExtensions
	{
		public static IUmbracoBuilder AddHeadlessSwaggerGen(
			this IUmbracoBuilder builder,
			Action<SwaggerGenOptions> customSwaggerGenSetup = null,
			Action<ReplaceType> typeReplacement = null,
			Type[] additionalTypes = null)
		{
			typeReplacement ??= _ => { };
			additionalTypes ??= Array.Empty<Type>();

			builder.Services.AddSwaggerGen(options =>
			{
				options.DocumentFilter<ContentTypesDocumentFilter>(typeReplacement, additionalTypes);
				options.DescribeAllParametersInCamelCase();

				customSwaggerGenSetup?.Invoke(options);
			});

			return builder;
		}
	}
}
