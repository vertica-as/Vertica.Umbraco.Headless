using System;
using System.Dynamic;
using Newtonsoft.Json.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Vertica.Umbraco.Headless.Core.Rendering.PropertyRenderers
{
    public class DefaultPropertyRenderer : IPropertyRenderer
    {
        public virtual string PropertyEditorAlias => "*";

        public Type TypeFor(IPublishedPropertyType propertyType) => typeof(object);

        public virtual object ValueFor(object umbracoValue, IPublishedProperty property, IContentElementBuilder contentElementBuilder)
        {
	        if (umbracoValue is JObject jObject)
	        {
		        return jObject.ToObject<ExpandoObject>();
	        }

	        return umbracoValue;
        }
    }
}
