using Umbraco.Cms.Core;

namespace Vertica.Umbraco.Headless.Core.Rendering.PropertyRenderers
{
	public class IntegerPropertyRenderer : GenericPropertyRenderer<int>
	{
		public override string PropertyEditorAlias => Constants.PropertyEditors.Aliases.Integer;
	}
}