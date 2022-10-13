using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Forms.Core.Enums;

namespace Vertica.Umbraco.Headless.Forms.Models;
public class FormViewModel
{
    [JsonProperty("_id")]
    public Guid Id { get; set; }
    public string Indicator { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? CssClass { get; set; } = string.Empty;
    public string? NextLabel { get; set; } = string.Empty;
    public string? PreviousLabel { get; set; } = string.Empty;
    public string? SubmitLabel { get; set; } = string.Empty;
    public bool DisableDefaultStylesheet { get; set; }
    public FormFieldIndication FieldIndicationType { get; set; }
    public bool HideFieldValidation { get; set; }
    public string? MessageOnSubmit { get; set; } = string.Empty;
    public bool ShowValidationSummary { get; set; }
    public Guid? GotoPageOnSubmit { get; set; }
    public IEnumerable<FormPage> Pages { get; set; } = Enumerable.Empty<FormPage>();
}