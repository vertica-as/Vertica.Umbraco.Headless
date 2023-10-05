# Building a custom API

Whlie I-ology HeadlessUmbraco is very much aimed at rendering headless content on the actual routes of the published Umbraco content, you can also use the same rendering in your own custom APIs.

I-ology HeadlessUmbraco ships with an API controller base class you can use as a starting point: [`HeadlessApiController`](../src/Iology.HeadlessUmbraco.Core/Controllers/HeadlessApiController.cs). An implementation of this base class could look like this:

```csharp
public class HeadlessContentApiController : HeadlessApiController
{
  public HeadlessContentApiController(...)
    : base(...)
  {
  }

  // Get headless content by Umbraco content ID
  public async Task<IActionResult> Content(int id, CancellationToken cancellationToken) =>
    await ContentForAsync(id, cancellationToken);
}
```

## Exploring the API a little more in depth

When implementing a custom API based on I-ology HeadlessUmbraco, there are two key services in play:

- `IContentElementBuilder` - responsible for turning published Umbraco content into corresponding `IContentElement` instances while adhering to the defined property renderers and the general configuration
- `IOutputRenderer` - responsible for rendering serialized output from controllers

You can use dependency injection to obtain both services, along with any other services needed by your API.

The flow of your API methods will likely look like this:

1. Query Umbraco to obtain whatever content your API method should serve as output.
2. Use `IContentElementBuilder.ContentElementForAsync(...)` to create `IContentElement` instances for the obtained content.
3. Use `IOutputRenderer.ActionResult(...)` to serialize the API output in a manner consistent with any other I-ology HeadlessUmbraco output in your project.
