using System;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Forms.Core.Models;
using Vertica.Umbraco.Headless.Core.Rendering;
using Vertica.Umbraco.Headless.Forms.Services;

namespace Vertica.Umbraco.Headless.Forms.Rendering;
public class FormsPropertyRenderer : IPropertyRenderer
{
    private readonly IHeadlessFormService _headlessFormService;
    public FormsPropertyRenderer(IHeadlessFormService headlessFormService)
    {
        _headlessFormService = headlessFormService;
    }
    public string PropertyEditorAlias => "UmbracoForms.FormPicker";
    public Type TypeFor(IPublishedPropertyType propertyType) => typeof(Form);
    public object ValueFor(object umbracoValue, IPublishedProperty property, IContentElementBuilder contentElementBuilder) => _headlessFormService.Get((Guid)umbracoValue);


}