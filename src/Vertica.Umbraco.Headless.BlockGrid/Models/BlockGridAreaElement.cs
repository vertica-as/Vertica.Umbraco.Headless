namespace Vertica.Umbraco.Headless.BlockGrid.Models;
public class BlockGridAreaElement
{
#if NET7_0_OR_GREATER
    public required string Alias { get; set; }
#else
    public string Alias { get; set; } = string.Empty;
#endif

    public int RowSpan { get; set; }
    public int ColumnSpan { get; set; }
    public IEnumerable<BlockGridElement> Blocks { get; set; } = Array.Empty<BlockGridElement>();
}