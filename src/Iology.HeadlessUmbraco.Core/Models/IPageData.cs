/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

namespace Iology.HeadlessUmbraco.Core.Models;

public interface IPageData : IContentElement
{
    IMetadata Metadata { get; set; }

    INavigation Navigation { get; set; }
}
