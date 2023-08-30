using System;
using System.Dynamic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Vertica.Umbraco.Headless.Core.Rendering.PropertyRenderers
{
    public class DefaultPropertyRenderer : IPropertyRenderer
    {
        public virtual string PropertyEditorAlias => "*";

        public Type TypeFor(IPublishedPropertyType propertyType) => typeof(object);

        public virtual Task<object> ValueForAsync(object umbracoValue, IPublishedProperty property,
            IContentElementBuilder contentElementBuilder)
        {
	        if (umbracoValue is JObject jObject)
	        {
		        return Task.FromResult<object>(jObject.ToObject<ExpandoObject>());
	        }

	        return Task.FromResult(umbracoValue);
        }
    }
}
