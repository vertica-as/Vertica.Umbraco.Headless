/**
 * Copyright (c) 2023 I-ology
 */

namespace Iology.HeadlessUmbraco.Core.Models;

public class BlockGridElement : ContentElementWithSettings
{
    public int RowSpan { get; set; }
    public int ColumnSpan { get; set; }
    public int? AreaGridColumns { get; set; }
    public IEnumerable<BlockGridAreaElement>? Areas { get; set; }
}
