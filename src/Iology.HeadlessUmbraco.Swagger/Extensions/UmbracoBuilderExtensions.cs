/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

using System;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;
using Umbraco.Cms.Core.DependencyInjection;
using Iology.HeadlessUmbraco.Swagger.Filters;
using Iology.HeadlessUmbraco.Swagger.TypeMapping;

namespace Iology.HeadlessUmbraco.Swagger.Extensions;

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
