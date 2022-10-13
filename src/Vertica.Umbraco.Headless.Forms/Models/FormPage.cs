using System.Collections.Generic;
using System.Linq;

namespace Vertica.Umbraco.Headless.Forms.Models;
public class FormPage
{
    public string? Caption { get; set; } = string.Empty;
    public IEnumerable<FormFieldset> Fieldsets { get; set; } = Enumerable.Empty<FormFieldset>();
}