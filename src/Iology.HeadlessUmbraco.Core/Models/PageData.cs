/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

namespace Iology.HeadlessUmbraco.Core.Models;

public class PageData : IPageData
{
    public string Alias { get; set; }

    public object Content { get; set; }

    public IMetadata Metadata { get; set; }

    public INavigation Navigation { get; set; }
}
