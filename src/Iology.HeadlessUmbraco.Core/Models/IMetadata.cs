/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

namespace Iology.HeadlessUmbraco.Core.Models;

public interface IMetadata
{
    string Name { get; set; }

    string Url { get; set; }

    string Id { get; set; }

    IEnumerable<ILanguageAndUrl> Languages { get; set; }
}
