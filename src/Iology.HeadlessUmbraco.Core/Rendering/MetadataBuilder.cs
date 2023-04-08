/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

using System.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;
using Iology.HeadlessUmbraco.Core.Extensions;
using Iology.HeadlessUmbraco.Core.Models;

namespace Iology.HeadlessUmbraco.Core.Rendering;

public class MetadataBuilder : IMetadataBuilder
{
	public virtual IMetadata BuildMetadata(IPublishedContent content) => BuildMetadata<Metadata>(content);

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
