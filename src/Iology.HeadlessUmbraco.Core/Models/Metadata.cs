/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

namespace Iology.HeadlessUmbraco.Core.Models;

public class Metadata : IMetadata
{
    public string Name { get; set; }

    public string Url { get; set; }

    public string Id { get; set; }

    public IEnumerable<ILanguageAndUrl> Languages { get; set; }
}
