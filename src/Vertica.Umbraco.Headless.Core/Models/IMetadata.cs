using System.Collections.Generic;

namespace Vertica.Umbraco.Headless.Core.Models
{
	public interface IMetadata
	{
		string Name { get; set; }

		string Url { get; set; }

		string Id { get; set; }

		IEnumerable<ILanguageAndUrl> Languages { get; set; }
	}
}