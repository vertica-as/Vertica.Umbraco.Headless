using Umbraco.Cms.Core;

namespace Vertica.Umbraco.Headless.Core.Rendering.PropertyRenderers
{
	public class TagsTextstringPropertyRenderer : StringArrayPropertyRenderer
	{
		public override string PropertyEditorAlias => Constants.PropertyEditors.Aliases.Tags;
	}
}