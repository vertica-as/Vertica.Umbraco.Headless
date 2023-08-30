using System;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Vertica.Umbraco.Headless.Core.Rendering
{
	public interface IContentModelBuilder : IDiscoverable
	{
		string ContentTypeAlias();

		Type ModelType();

		public Task<object> BuildContentModelAsync(IPublishedElement content, IContentElementBuilder contentElementBuilder);
	}
}