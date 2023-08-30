# Property rendering

When VUHF creates JSON output for Umbraco content, it applies a *property renderer* to each content property. A property renderer is tasked with turning the value of a single Umbraco content property into a meaningful headless JSON output. As such, each type of Umbraco property editor (ie. Textbox, Content Picker etc.) should be matched by a corresponding property renderer, in order to achieve the best possible JSON output.

## Built-in property renderers

VUHF has built-in property renderers for almost all standard Umbraco property editors. In the following table you'll find the standard Umbraco property editors and the corresponding C# models created by the built-in property renderers.

| Umbraco property editor | VUHF model |
| --- | --- |
| Block List | `ContentElementWithSettings[]` ([source](../src/Vertica.Umbraco.Headless.Core/Models/ContentElementWithSettings.cs)) |
| Checkbox List | `string[]` |
| Color Picker | `ColorAndLabel` ([source](../src/Vertica.Umbraco.Headless.Core/Models/ColorAndLabel.cs)) if the Umbraco datatype is configured to include labels - `string` otherwise |
| Content Picker | `NameAndUrl` ([source](../src/Vertica.Umbraco.Headless.Core/Models/NameAndUrl.cs)) |
| Date/Time | `DateTime?` |
| Decimal | `decimal` |
| Dropdown | `string[]` if the Umbraco datatype is configured as multiselect - `string` otherwise |
| Email Address | `string` |
| Eye Dropper Color Picker | `string` |
| File Upload | `string` |
| Grid Layout | Unsupported (explicitly ignored) |
| Image Cropper | `ImageCrop` ([source](../src/Vertica.Umbraco.Headless.Core/Models/ImageCrop.cs)) |
| Markdown Editor | `string` |
| Media Picker | `Media[]` ([source](../src/Vertica.Umbraco.Headless.Core/Models/Media.cs)) if the Umbraco datatype is configured as multiselect - `Media` otherwise |
| Media Picker (legacy) | `Media[]` ([source](../src/Vertica.Umbraco.Headless.Core/Models/Media.cs)) if the Umbraco datatype is configured as multiselect - `Media` otherwise |
| Member Group Picker | Unsupported (explicitly ignored) |
| Member Picker | Unsupported (explicitly ignored) |
| Multi URL Picker | `Link[]` ([source](../src/Vertica.Umbraco.Headless.Core/Models/Link.cs)) if the Umbraco datatype is configured for multiple items - `Link` otherwise |
| Multinode Treepicker | `NameAndUrl[]` ([source](../src/Vertica.Umbraco.Headless.Core/Models/NameAndUrl.cs)) if the Umbraco datatype is configured for multiple items - `NameAndUrl` otherwise |
| Nested Content | `IContentElement[]` ([source](../src/Vertica.Umbraco.Headless.Core/Models/IContentElement.cs)) if the Umbraco datatype is configured for multiple items - `IContentElement` otherwise |
| Numeric | `int` |
| Radio Button List | `string` |
| Repeatable Textstrings | `string[]` |
| Rich Text Editor | `string` |
| Slider | `DecimalRange` ([source](../src/Vertica.Umbraco.Headless.Core/Models/DecimalRange.cs)) ifthe Umbraco datatype is  configured for range input - `decimal` otherwise |
| Tags | `string[]` |
| Textarea | `string` |
| Textbox | `string` |
| Toggle | `bool` |
| User Picker | Unsupported (explicitly ignored) |

### Points of interest

As the table above shows, property renderers can return different models based on the configuration of the Umbraco datatypes created for the property editors. This mirrors the behavior of ModelsBuilder.

The output from Block List and Nested Content properties is created in the same manner as output at root level for an Umbraco page (see [Exploring the JSON format](exploring-the-json-format.md)). This is because page content and Block List/Nested Content items are all modelled from the same source: `IPublishedElement`. In other words: Any given Umbraco property is rendered in the same way, whether it exists in context of a page or a Block List/Nested Content item.

## Custom property editors

When VUHF encounters an Umbraco property editor, that does not have a corresponding property renderer (i.e. editors from 3rd party add-ons), it returns the raw value from the editor's property value converter in the JSON output. This might very well be perfectly fine or it might not be, depending on both your use case and the editor implementation. 

If the raw value is not useful, you can create a custom property renderer for the property editor by implementing the [`IPropertyRenderer`](../src/Vertica.Umbraco.Headless.Core/Rendering/IPropertyRenderer.cs) interface - see the sample in the next section, or browse all [built-in property renderers](../src/Vertica.Umbraco.Headless.Core/Rendering/PropertyRenderers) for inspiration.

You can use dependency injection with your custom property renderers, and you don't need to register them anywhere; VUHF automatically picks up all property renderers and registers them correctly.

## Replacing the built-in property renderers

If for some reason a built-in property renderer does not work for you, you can replace it by implementing your own property renderer in its place. Custom property renderers always take precedence over the built-in ones, in case multiple property renderers are found for the same Umbraco property editor.

Here's a sample of a custom property renderer that replaces the built-in one for Textbox properties:

```csharp
public class MyTextBoxPropertyRenderer : IPropertyRenderer
{
  private readonly IUmbracoContextAccessor _umbracoContextAccessor;

  public MyTextBoxPropertyRenderer(IUmbracoContextAccessor umbracoContextAccessor)
  {
    _umbracoContextAccessor = umbracoContextAccessor;
  }

  // this property renderer handles textbox properties  
  public string PropertyEditorAlias => Constants.PropertyEditors.Aliases.TextBox;

  // this property renderer always returns a string value
  public Type TypeFor(IPublishedPropertyType propertyType) => typeof(string);

  // extract the property value
  public Task<object> ValueForAsync(object umbracoValue, IPublishedProperty property, IContentElementBuilder contentElementBuilder, CancellationToken cancellationToken)
  {
    // expecting a string value for Textbox properties
    if (!(umbracoValue is string value))
    {
      return Task.FromResult<object>(null);
    }

    // append " (preview mode)" to the property value if the current context is a preview
    var isPreview = _umbracoContextAccessor.GetRequiredUmbracoContext().InPreviewMode;
    return Task.FromResult<object>($"{value} {(isPreview ? " (preview mode)" : "")}");
  }
}
```