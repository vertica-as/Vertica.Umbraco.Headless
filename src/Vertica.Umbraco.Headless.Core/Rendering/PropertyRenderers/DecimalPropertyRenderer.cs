using Umbraco.Cms.Core;

namespace Vertica.Umbraco.Headless.Core.Rendering.PropertyRenderers
{
	public class DecimalPropertyRenderer : GenericPropertyRenderer<decimal>
	{
		public override string PropertyEditorAlias => Constants.PropertyEditors.Aliases.Decimal;
	}
}