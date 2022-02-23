# Vertica Umbraco Headless Framework

This is an extension for [Umbraco](https://github.com/umbraco/umbraco-cms) (version 9+) that lets you use your Umbraco content in a headless fashion. It is highly customizable, and you can tweak or replace every aspect of the generated output.

Vertica Umbraco Headless Framework (VUHF) is *not* to be confused with the [Umbraco Heartcore](https://umbraco.com/products/umbraco-heartcore/), commercial headless SaaS offering from Umbraco. This is purely a rendering framework, designed to replace (or complement) the rendering mechanism within Umbraco.

The framework is build to be:

- **Friendly** - plug & play headless CMS capability for Umbraco
- **Flexible** - 100% extensible and customizable 
- **Open** - integrates seamlessly with the Umbraco ecosystem, thus imposing no limitations towards other Umbraco packages and add-ons

## Installation

First install the VUHF [NuGet package](https://www.nuget.org/packages/Vertica.Umbraco.Headless.Core/) in your Umbraco project:

```
dotnet add MyProject package Vertica.Umbraco.Headless.Core
```

Now open the `Startup` class of your Umbraco project and include the VUHF core extensions by adding: 

```csharp
using Vertica.Umbraco.Headless.Core.Extensions;
```

Lastly add `AddHeadless()` to the `IUmbracoBuilder` setup in the `ConfigureServices(...)` method of the same class:

```csharp
public void ConfigureServices(IServiceCollection services)
{
  services.AddUmbraco(_env, _config)
    .AddBackOffice()
    .AddWebsite()
    .AddComposers()
    .AddHeadless() // adds Vertica Umbraco Headless Framework to Umbraco
    .Build();
}
```

Provided your site has any published content, it will now be returned as JSON when requested. 

By default VUHF takes over the entire output rendering, meaning any existing Umbraco templates will no longer be invoked. However, this (and much more) can be changed and tailored to your specific needs. Have a read through the documentation below.

## Documentation - table of contents

- [Exploring the JSON format](docs/exploring-the-json-format.md) - an introduction to the generated JSON output
- [Customizing the page JSON output](docs/customizing-the-page-json-output.md) - a walkthrough of the most commonly used extension points
- [Property rendering](docs/property-rendering.md) - property level rendering and extension explained
- [Fallback handling](docs/fallback-handling.md) - how to use the Umbraco fallback mechanism with VUHF
- [Building a custom API](building-a-custom-api.md) - get started with custom APIs leveraging headless content output
- [Headless or hybrid CMS](docs/headless-or-hybrid-cms.md) - serve content both as head and in a headless manner
- [OpenAPI support](openapi-support.md) - generate OpenAPI contracts for your content models 
