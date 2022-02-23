using Umbraco.Cms.Core;

namespace Vertica.Umbraco.Headless.Core.Rendering.PropertyRenderers
{
	public class UploadFieldPropertyRenderer : GenericPropertyRenderer<string>
	{
		public override string PropertyEditorAlias => Constants.PropertyEditors.Aliases.UploadField;
	}
}