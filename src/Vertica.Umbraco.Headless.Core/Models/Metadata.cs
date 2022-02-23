using System.Collections.Generic;

namespace Vertica.Umbraco.Headless.Core.Models
{
    public class Metadata : IMetadata
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string Id { get; set; }

        public IEnumerable<ILanguageAndUrl> Languages { get; set; }
    }
}
