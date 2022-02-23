using Umbraco.Cms.Core;

namespace Vertica.Umbraco.Headless.Core.Rendering.PropertyRenderers
{
	public class UserPickerPropertyRenderer : UnsupportedPropertyRenderer
	{
		public override string PropertyEditorAlias => Constants.PropertyEditors.Aliases.UserPicker;
	}
}