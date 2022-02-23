using Umbraco.Cms.Core;

namespace Vertica.Umbraco.Headless.Core.Rendering.PropertyRenderers
{
	public class BooleanPropertyRenderer : GenericPropertyRenderer<bool>
	{
		public override string PropertyEditorAlias => Constants.PropertyEditors.Aliases.Boolean;
	}
}