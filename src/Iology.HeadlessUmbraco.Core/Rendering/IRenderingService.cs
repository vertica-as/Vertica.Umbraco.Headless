/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

using Umbraco.Cms.Core.Models.PublishedContent;

namespace Iology.HeadlessUmbraco.Core.Rendering;

public interface IRenderingService
{
    IPropertyRenderer PropertyRendererFor(IPublishedPropertyType propertyType);

    IContentModelBuilder ContentModelBuilderFor(IPublishedContentType contentType);
}
