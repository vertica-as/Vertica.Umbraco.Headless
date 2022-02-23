# Fallback handling

You can use Umbraco fallback with VUHF in two ways:

- A default fallback applied to all content rendering
- A customized fallback per property per content type

If you are unfamiliar with the concept of fallback, you can read the official Umbraco docs on the subject  [here](https://our.umbraco.com/documentation/fundamentals/Design/Rendering-Content/#using-fall-back-methods).

## Default fallback

The default fallback is configured as a parameter to the `AddHeadless()` method in to the `IUmbracoBuilder` setup:

```csharp
public void ConfigureServices(IServiceCollection services)
{
  services.AddUmbraco(_env, _config)
    .AddBackOffice()
    .AddWebsite()
    .AddComposers()
    .AddHeadless(defaultFallback: Fallback.ToLanguage) // adds Vertica Umbraco Headless Framework to Umbraco 
    .Build();
}
```

## Customized fallback

You can create a very granular fallback setup (per property per content type) by replacing the default VUHF [`IFallbackProvider`](../src/Vertica.Umbraco.Headless.Core/Rendering/Providers/IFallbackProvider.cs) with your own implementation.

A sample implementation could look like this:

```csharp
public Fallback FallbackFor(IPublishedElement content, IPublishedProperty property)
{
  // create your own fallback implementation specifici content type properties here
  if (content.ContentType.Alias == "home")
  {
    return Fallback.To(Fallback.None);
  }

  // default fallback
  return Fallback.ToLanguage;
}
```

With your implementation in place, you need to replace the default implementation. You do that by registering your own implementation as a singleton in the `ConfigureServices(...)` method of `Startup`:

```csharp
public void ConfigureServices(IServiceCollection services)
{
  services.AddUmbraco(_env, _config)
    // ...
    .AddHeadless()
    .Build();
  
  services.AddSingleton<IFallbackProvider, MyFallbackProvider>(); // replace the default fallback provider
}
```
