using System;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Vertica.Umbraco.Headless.Core.Rendering
{
    public interface IPropertyRenderer
    {
        string PropertyEditorAlias { get; }

        Type TypeFor(IPublishedPropertyType propertyType);

        object ValueFor(object umbracoValue, IPublishedProperty property, IContentElementBuilder contentElementBuilder);
    }
}
