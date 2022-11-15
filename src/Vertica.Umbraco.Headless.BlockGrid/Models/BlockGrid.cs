namespace Vertica.Umbraco.Headless.BlockGrid.Models;
public class BlockGrid
{
    public int? GridColumns { get; set; }
    public IEnumerable<BlockGridElement> Blocks { get; set; } = Array.Empty<BlockGridElement>();
}