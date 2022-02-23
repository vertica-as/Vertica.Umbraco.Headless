using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Vertica.Umbraco.Headless.Core.Rendering.Output
{
	public class JsonOutputRenderer : IOutputRenderer
	{
		public string Serialize(object value) => JsonConvert.SerializeObject(value, JsonSerializerSettings());

		public IActionResult ActionResult(object value) => new ContentResult
		{
			Content = Serialize(value),
			ContentType = "application/json"
		};

		protected virtual JsonSerializerSettings JsonSerializerSettings()
			=> new JsonSerializerSettings
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver(),
				Converters = {new StringEnumConverter()},
				ReferenceLoopHandling = ReferenceLoopHandling.Ignore
			};
	}
}
