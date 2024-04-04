using System.Collections.Generic;
using System.Linq;

namespace Vertica.Umbraco.Headless.Forms.Models;
public class FormFieldsetColumn
{
    public string? Caption { get; set; } = string.Empty;
    public int Width { get; set; }
    public IEnumerable<FormField> Fields { get; set; } = Enumerable.Empty<FormField>();
}