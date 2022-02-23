using Umbraco.Cms.Core;

namespace Vertica.Umbraco.Headless.Core.Rendering.PropertyRenderers
{
	public class MultipleTextstringPropertyRenderer : StringArrayPropertyRenderer
	{
		public override string PropertyEditorAlias => Constants.PropertyEditors.Aliases.MultipleTextstring;
	}
}