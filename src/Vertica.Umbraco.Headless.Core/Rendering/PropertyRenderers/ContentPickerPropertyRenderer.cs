using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using Vertica.Umbraco.Headless.Core.Rendering.Providers;

namespace Vertica.Umbraco.Headless.Core.Rendering.PropertyRenderers
{
    public class ContentPickerPropertyRenderer : NameAndUrlPropertyRenderer
    {
	    public ContentPickerPropertyRenderer(IUrlProvider urlProvider) : base(urlProvider)
	    {
	    }

	    public override string PropertyEditorAlias => Constants.PropertyEditors.Aliases.ContentPicker;

	    public override bool IsMultiSelect(IPublishedPropertyType propertyType) => false;
    }
}