using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core;
using Umbraco.Forms.Core.Models;
using Umbraco.Forms.Core.Services;
using Vertica.Umbraco.Headless.Forms.Models;

namespace Vertica.Umbraco.Headless.Forms.Services
{
    public class HeadlessFormService : IHeadlessFormService
    {
        private readonly IFormService _formService;
        private readonly IFieldTypeStorage _fieldTypeStorage;
        private readonly IPublishedContentQueryAccessor _publishedContentQueryAccessor;
        public HeadlessFormService(IFormService formService, IFieldTypeStorage fieldTypeStorage, IPublishedContentQueryAccessor publishedContentQueryAccessor)
        {
            _formService = formService;
            _fieldTypeStorage = fieldTypeStorage;
            _publishedContentQueryAccessor = publishedContentQueryAccessor;
        }

        public FormViewModel? Get(Guid id) => Convert(_formService.Get(id));
        public FormViewModel? Get(string name) => Convert(_formService.Get(name));
        public IEnumerable<FormViewModel?> Get(Guid[] ids) => _formService.Get(ids).Select(Convert);
        public IEnumerable<FormViewModel?> Get() => _formService.Get().Select(Convert);

        public FormViewModel? Convert(Form? form)
        {
            if (form == null) return null;
            if (!(_publishedContentQueryAccessor.TryGetValue(out IPublishedContentQuery? publishedContentQuery))) throw new Exception($"Missing {nameof(publishedContentQuery)}");

            return new FormViewModel()
            {
                Id = form.Id,
                Indicator = form.Indicator,
                CssClass = form.CssClass,
                NextLabel = form.NextLabel,
                DisableDefaultStylesheet = form.DisableDefaultStylesheet,
                FieldIndicationType = form.FieldIndicationType,
                GotoPageOnSubmit = publishedContentQuery.Content(form.GoToPageOnSubmit)?.Key,
                HideFieldValidation = form.HideFieldValidation,
                MessageOnSubmit = form.MessageOnSubmit,
                Name = form.Name,
                Pages = form.Pages.Select(FromPage),
                PreviousLabel = form.PrevLabel,
                ShowValidationSummary = form.ShowValidationSummary,
                SubmitLabel = form.SubmitLabel,
            };
        }
        private FormPage FromPage(Page page)
        {
            return new FormPage()
            {
                Caption = page.Caption,
                Fieldsets = page.FieldSets.Select(FromFieldset)
            };
        }
        private FormCondition? FromFieldCondition(FieldCondition? fieldCondition)
        {
            if (fieldCondition == null) return null;

            return new FormCondition()
            {
                ActionType = fieldCondition.ActionType,
                LogicType = fieldCondition.LogicType,
                Rules = fieldCondition.Rules.Select(FromFieldConditionRule)
            };
        }
        private FormConditionRule FromFieldConditionRule(FieldConditionRule fieldConditionRule)
        {
            return new FormConditionRule()
            {
                Field = fieldConditionRule.Field.ToString(),
                Operator = fieldConditionRule.Operator,
                Value = fieldConditionRule.Value
            };
        }
        private FormFieldset FromFieldset(FieldSet fieldset)
        {
            return new FormFieldset()
            {
                Caption = fieldset.Caption,
                Condition = FromFieldCondition(fieldset.Condition),
                Columns = fieldset.Containers.Select(FromFieldsetContainer),
            };
        }
        private FormFieldsetColumn FromFieldsetContainer(FieldsetContainer container)
        {
            return new FormFieldsetColumn()
            {
                Caption = container.Caption,
                Width = container.Width,
                Fields = container.Fields.Select(fromField),
            };
        }
        private FormField fromField(Field field)
        {
            return new FormField()
            {
                Caption = field.Caption,
                Alias = field.Alias,
                Condition = FromFieldCondition(field.Condition),
                CssClass = field.CssClass,
                HelpText = field.ToolTip,
                Placeholder = field.Placeholder,
                PreValues = field.PreValues,
                Required = field.Mandatory,
                RequiredErrorMessage = field.RequiredErrorMessage,
                Settings = field.Settings,
                Type = GetFieldTypeName(field)
        };
        }

        private string GetFieldTypeName(Field field) 
            => _fieldTypeStorage
                .GetFieldTypeByField(field)
                .GetType()
                .Name
                .ToLower();
    }
}