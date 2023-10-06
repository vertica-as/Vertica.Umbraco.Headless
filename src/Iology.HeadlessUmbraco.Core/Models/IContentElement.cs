/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

namespace Iology.HeadlessUmbraco.Core.Models;

public interface IContentElement
{
    string Alias { get; set; }

    object? Content { get; set; }
}
