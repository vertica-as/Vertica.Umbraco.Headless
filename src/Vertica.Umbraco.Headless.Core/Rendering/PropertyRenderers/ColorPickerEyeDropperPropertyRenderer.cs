using Umbraco.Cms.Core;

namespace Vertica.Umbraco.Headless.Core.Rendering.PropertyRenderers
{
	public class ColorPickerEyeDropperPropertyRenderer : GenericPropertyRenderer<string>
	{
		public override string PropertyEditorAlias => Constants.PropertyEditors.Aliases.ColorPickerEyeDropper;
	}
}