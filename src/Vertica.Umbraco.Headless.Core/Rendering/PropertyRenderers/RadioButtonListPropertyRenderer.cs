using Umbraco.Cms.Core;

namespace Vertica.Umbraco.Headless.Core.Rendering.PropertyRenderers
{
	public class RadioButtonListPropertyRenderer : GenericPropertyRenderer<string>
	{
		public override string PropertyEditorAlias => Constants.PropertyEditors.Aliases.RadioButtonList;
	}
}