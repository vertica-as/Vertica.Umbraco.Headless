using System.Collections.Generic;

namespace Vertica.Umbraco.Headless.Forms.Models;
public class FormField
{
    public string Caption { get; set; } = string.Empty;
    public string? HelpText { get; set; } = string.Empty;
    public string? Placeholder { get; set; } = string.Empty;
    public string? CssClass { get; set; } = string.Empty;
    public string Alias { get; set; } = string.Empty;
    public bool Required { get; set; }
    public string? RequiredErrorMessage { get; set; } = string.Empty;
    public FormCondition? Condition { get; set; }
    public IDictionary<string, string> Settings { get; set; } = new Dictionary<string, string>();
    public object? PreValues { get; set; }
    public string Type { get; set; } = string.Empty;

}