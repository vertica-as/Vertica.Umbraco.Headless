using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Vertica.Umbraco.Headless.Forms.Rendering;

namespace Vertica.Umbraco.Headless.Forms.Models;
[JsonConverter(typeof(StringEnumConverter), typeof(UpperSnakeCaseNamingStrategy))]
public enum FormConditionRuleOperator
{
    Is,
    IsNot,
    GreaterThen,
    LessThen,
    Contains,
    StartsWith,
    EndsWith
}