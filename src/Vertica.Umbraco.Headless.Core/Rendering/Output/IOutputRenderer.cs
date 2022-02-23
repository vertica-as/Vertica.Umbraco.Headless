using Microsoft.AspNetCore.Mvc;

namespace Vertica.Umbraco.Headless.Core.Rendering.Output
{
	public interface IOutputRenderer
	{
		string Serialize(object value);

		IActionResult ActionResult(object value);
	}
}