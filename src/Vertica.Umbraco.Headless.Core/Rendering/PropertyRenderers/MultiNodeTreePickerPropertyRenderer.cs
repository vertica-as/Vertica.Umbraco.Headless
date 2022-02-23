using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PropertyEditors;
using Vertica.Umbraco.Headless.Core.Rendering.Providers;

namespace Vertica.Umbraco.Headless.Core.Rendering.PropertyRenderers
{
    public class MultiNodeTreePickerPropertyRenderer : NameAndUrlPropertyRenderer
    {
	    public MultiNodeTreePickerPropertyRenderer(IUrlProvider urlProvider) : base(urlProvider)
	    {
	    }

	    public override string PropertyEditorAlias => Constants.PropertyEditors.Aliases.MultiNodeTreePicker;

        public override bool IsMultiSelect(IPublishedPropertyType propertyType)
	        => propertyType.DataType.ConfigurationAs<MultiNodePickerConfiguration>().MaxNumber != 1;
    }
}