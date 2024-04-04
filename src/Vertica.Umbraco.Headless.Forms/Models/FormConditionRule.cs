using Umbraco.Forms.Core.Enums;

namespace Vertica.Umbraco.Headless.Forms.Models;
public class FormConditionRule
{
    public string Field { get; set; } = string.Empty;
    public FieldConditionRuleOperator Operator { get; set; }
    public string Value { get; set; } = string.Empty;
}