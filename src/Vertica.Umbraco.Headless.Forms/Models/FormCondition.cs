using System.Collections.Generic;
using System.Linq;
using Umbraco.Forms.Core.Enums;

namespace Vertica.Umbraco.Headless.Forms.Models;
public class FormCondition
{
    public FieldConditionActionType ActionType { get; set; }
    public FieldConditionLogicType LogicType { get; set; }
    public IEnumerable<FormConditionRule> Rules { get; set; } = Enumerable.Empty<FormConditionRule>();
}