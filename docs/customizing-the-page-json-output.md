# Customizing the page JSON output

The following covers the most common extension points for the page JSON output. If you haven't already, read [Exploring the JSON format](exploring-the-json-format.md) before diving into this.

## Additional data in `metadata` and/or `navigation`

To tweak the `metadata` and/or `navigation` output, you have to create your own implementations the interfaces [`IMetadataBuilder`](../src/Iology.HeadlessUmbraco.Core/Rendering/IMetadataBuilder.cs) and/or [`INavigationBuilder`](../src/Iology.HeadlessUmbraco.Core/Rendering/INavigationBuilder.cs) respectively. To keep your implementations simple you can opt to expand upon the core implementations rather than building your own from scratch.

Once you have your implementations in place, you must replace the default implementations. You do that by registering your own implementations as singletons in the `ConfigureServices(...)` method of `Startup`.

In the following sample we'll:

- Add a secondary navigation to `navigation`
- Add the content last modified date to `metadata`

```csharp
// Our custom navigation model - based on the default Navigation (which implements INavigation)
public class MyNavigation : Navigation
{
  public IEnumerable<NameAndUrl> Secondary { get; set; }
}

// Custom navigation builder that includes a secondary navigation in the default navigation output
public class MyNavigationBuilder : NavigationBuilder
{
  public override Task<INavigation> BuildNavigationAsync(IPublishedContent content, CancellationToken cancellationToken)
  {
    // Add the default navigation data to our custom navigation class
    var myNavigation = base.BuildNavigation<MyNavigation>(content);

    // Add our secondary navigation (root level children) - NameAndUrl is a core class, we'll reuse it here
    myNavigation.Secondary = content.AncestorOrSelf(2).Children.Select(c => new NameAndUrl(c.Name, c.Url())).ToArray();

    return Task.FromResult<INavigation>(myNavigation);
  }
}

// Our custom metadata model - based on the default Metadata (which implements IMetadata)
public class MyMetadata : Metadata
{
  public DateTime LastModified { get; set; }
}

// Our custom metadata builder that adds last modified to the default metadata output
public class MyMetadataBuilder : MetadataBuilder
{
  public override Task<IMetadata> BuildMetadataAsync(IPublishedContent content, CancellationToken cancellationToken)
  {
    // Add the default metadata to our custom metadata class
    var myMetadata = base.BuildMetadata<MyMetadata>(content);

    // Add last modified date
    myMetadata.LastModified = content.UpdateDate;

    return Task.FromResult<IMetadata>(myMetadata);
  }
}
```

And to swap the default implementations with our custom implementations:

```csharp
public void ConfigureServices(IServiceCollection services)
{
  services.AddUmbraco(_env, _config)
    // ...
    .AddHeadless()
    .Build();

  // Replace the default navigation and metadata builders
  services.AddSingleton<INavigationBuilder, MyNavigationBuilder>();
  services.AddSingleton<IMetadataBuilder, MyMetadataBuilder>();
}
```

## Custom content models

When I-ology HeadlessUmbraco builds the `content` and `settings` parts of the `contentElement` output, it generates content models dynamically based on the content type of the requested content. This is likely a great fit for most usage, but sometimes you may find yourself wanting to control and enrich the content output for a given content type.

To this end you can create your own content models per content type. In other words, you can construct your own output for certain content types, while still leveraging the dynamic content model generation for the rest of the content types.

Custom content model is created by implementing the factory interface [`IContentModelBuilder`](../src/Iology.HeadlessUmbraco.Core/Rendering/IContentModelBuilder.cs) for all relevant content types. Each factory implementation is then responsible for creating a new instance of the custom content model for the given content type.

The content model can be its own factory, if you prefer - or you can create a factory implementation seperately from the content model, if you want a little more seperation of concerns.

You can use dependency injection with your factory implementations, and you don't need to register them anywhere; I-ology HeadlessUmbraco automatically picks up all implementations and registers them correctly.

In the following sample we'll create a custom content model for the content type with alias "home". The factory implementation uses dependency injection to acquire and enrich the custom content model with external service data:

```csharp
// This is the content model factory
public class HomeContentModelBuilder : IContentModelBuilder
{
  private readonly IUmbracoContextAccessor _umbracoContextAccessor;

  public HomeContentModelBuilder(IUmbracoContextAccessor umbracoContextAccessor)
  {
    _umbracoContextAccessor = umbracoContextAccessor;
  }

  public string ContentTypeAlias() => "home";

  public Type ModelType() => typeof(HomeContentModel);

  public Task<object> BuildContentModelAsync(IPublishedElement content, IContentElementBuilder contentElementBuilder, CancellationToken cancellationToken)
    => Task.FromResult<object>(new HomeContentModel
    {
        TheTitle = content.Value<string>("title"),
        TheIntro = content.Value<string>("intro"),
        IsPreview = _umbracoContextAccessor.GetRequiredUmbracoContext().InPreviewMode
    });
}

// This is the custom content model
public class HomeContentModel
{
  public string TheTitle { get; set; }

  public string TheIntro { get; set; }

  public bool IsPreview { get; set; }
}
```

_Note: This sample implementation is based solely on `IPublishedContent`. If you're using ModelsBuilder to generate C# classes, you can simplify it and get rid of the magic property name strings._

### What is that `IContentElementBuilder` parameter?

In short: `IContentElementBuilder` is responsible for stitching everything together when I-ology HeadlessUmbraco creates JSON output for Umbraco content. This means that `IContentElementBuilder` is responsible for extracting Umbraco property values when creating dynamically generated content models.

As long as your factory method only has to extract simple Umbraco properties for your custom content model (like the sample above), you probably don't need to worry about `IContentElementBuilder`.

If you find yourself wanting to use the [built-in property rendering](property-renderering.md) for complex Umbraco properties (i.e. Media or Block List rendering), you can use `IContentElementBuilder` to extract Umbraco property values in your factory implementation - like this: `await contentElementBuilder.RenderedValueForAsync<Media>(content, "image", cancellationToken)`.

## Creating your own `RenderController`

All I-ology HeadlessUmbraco outut builds on top of the default Umbraco request pipeline. Thus all requests are handled by implementations of `RenderController`. Upon installation, I-ology HeadlessUmbraco adds a default `RenderController` to handle all requests that are not specifically handled by other `RenderController` implementations.

You may eventually find it handy to create your own `RenderController` to manage request state. In that case you either want to:

- Replace the default `RenderController` to handle requests for all page types, or
- Create `RenderController` implementations to handle requests for specific page types, or
- All of the above

A custom I-ology HeadlessUmbraco `RenderController` is created as an implementation of [`HeadlessRenderController`](../src/Iology.HeadlessUmbraco.Core/Controllers/HeadlessRenderController.cs).

When creating `RenderController` implementations for specific page types, and if you're using ModelsBuilder to generate C# classes, you can choose to implement `HeadlessRenderController<T>` instead (where `T` is your page type). This will give you strongly typed access to the page content in your implementation.

```csharp
using Iology.HeadlessUmbraco.Core.Controllers;

// ...

public class MyDefaultRenderController : HeadlessRenderController {
  // ...
}

public class MyConcretePageRenderController : HeadlessRenderController<MyConcretePage> {
  // ...
}
```

To replace the default I-ology HeadlessUmbraco `RenderController`, change your `Startup` class to use the `AddHeadless<T>(...)` overload that accepts a type argument for the default controller:

```csharp
public void ConfigureServices(IServiceCollection services)
{
  services.AddUmbraco(_env, _config)
    .AddBackOffice()
    .AddWebsite()
    .AddComposers()
    .AddHeadless<MyDefaultRenderController>() // Adds I-ology HeadlessUmbraco to Umbraco
    .Build();
}
```

If you're looking to use I-ology HeadlessUmbraco only for select areas of your content (e.g. content type specific `RenderController` implementations), or as part of a [custom API implementation](building-a-custom-api.md), you probably don't want a I-ology HeadlessUmbraco `HeadlessRenderController` as the default controller. Fortunately the `AddHeadless<T>(...)` overload accepts any `RenderController` implementation - it doesn't have to be a I-ology HeadlessUmbraco controller. You can even use `RenderController` itself in the overload, which will revert the content rendering to the Umbraco default.

## Custom page output

You can customize the entire page output (the container for `alias`, `content`, `metadata` and `navigation`) in the same manner as is shown above for `metadata` and `navigation` - by creating your own implementation of the interface [`IPageDataBuilder`](../src/Iology.HeadlessUmbraco.Core/Rendering/IPageDataBuilder.cs) and swapping the default implementation with your own in `Startup`.

This extension point is mostly mentioned here for the sake of completion. If you're considering a customized page output, you should probably first consider if a custom content model is a better fit for your needs.
