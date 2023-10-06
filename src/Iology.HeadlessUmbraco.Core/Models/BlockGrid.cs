/**
 * Copyright (c) 2023 I-ology
 */

namespace Iology.HeadlessUmbraco.Core.Models;

public class BlockGrid
{
    public int? GridColumns { get; set; }
    public IEnumerable<BlockGridElement> Blocks { get; set; } = Array.Empty<BlockGridElement>();
}
