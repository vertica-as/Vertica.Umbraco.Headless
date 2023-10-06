/**
 * Copyright (c) 2023 I-ology
 */

namespace Iology.HeadlessUmbraco.Core.Models;

public class BlockGridAreaElement
{
    public string Alias { get; set; } = string.Empty;
    public int RowSpan { get; set; }
    public int ColumnSpan { get; set; }
    public BlockGridElement[] Blocks { get; set; } = Array.Empty<BlockGridElement>();
}
