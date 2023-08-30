using System;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Vertica.Umbraco.Headless.Core.Rendering
{
	public abstract class ContentModelBuilder<T> : IContentModelBuilder where T : class
	{
		public Type ModelType() => typeof(T);

		public abstract string ContentTypeAlias();

		public async Task<object> BuildContentModelAsync(IPublishedElement content, IContentElementBuilder contentElementBuilder) => await BuildModelAsync(content, contentElementBuilder);

        protected abstract Task<T> BuildModelAsync(IPublishedElement content, IContentElementBuilder contentElementBuilder);
	}
}
