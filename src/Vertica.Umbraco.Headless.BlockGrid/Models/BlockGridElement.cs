using Vertica.Umbraco.Headless.Core.Models;

namespace Vertica.Umbraco.Headless.BlockGrid.Models
{
    public class BlockGridElement : ContentElementWithSettings
    {
        public int RowSpan { get; set; }
        public int ColumnSpan { get; set; }
        public bool ForceLeft { get; set; }
        public bool ForceRight { get; set; }
        public int? AreaGridColumns { get; set; }
        public IEnumerable<BlockGridAreaElement>? Areas { get; set; }
    }
}