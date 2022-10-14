using System.Collections.Generic;
using System.Linq;

namespace Vertica.Umbraco.Headless.Forms.Models;
public class FormFieldset
{
    public string? Caption { get; set; } = string.Empty;
    public FormCondition? Condition { get; set; }
    public IEnumerable<FormFieldsetColumn> Columns { get; set; } = Enumerable.Empty<FormFieldsetColumn>();

}