using System.Linq;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;
using Vertica.Umbraco.Headless.Core.Extensions;
using Vertica.Umbraco.Headless.Core.Models;

namespace Vertica.Umbraco.Headless.Core.Rendering
{
	public class MetadataBuilder : IMetadataBuilder
	{
		public virtual Task<IMetadata> BuildMetadataAsync(IPublishedContent content) => Task.FromResult<IMetadata>(BuildMetadata<Metadata>(content));

		protected TMetadata BuildMetadata<TMetadata>(IPublishedContent content) where TMetadata : class, IMetadata, new()
			=> new TMetadata
			{
				Id = content.Key.ToString(),
				Name = content.Name,
				Url = content.Url(mode: UrlMode.Absolute),
				Languages = content.Root().Cultures.Values
					.Where(pci => pci.Culture.IsNotEmpty() && content.IsPublished(pci.Culture))
					.Select(pci => new LanguageAndUrl
					{
						Language = pci.Culture,
						Url = content.Url(pci.Culture, UrlMode.Absolute)
					})
					.ToArray()
			};
	}
}
