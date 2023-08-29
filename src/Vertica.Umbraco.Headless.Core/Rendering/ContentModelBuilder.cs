using System;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Vertica.Umbraco.Headless.Core.Rendering
{
	public abstract class ContentModelBuilder<T> : IContentModelBuilder where T : class
	{
		public Type ModelType() => typeof(T);

		public abstract string ContentTypeAlias();

		public async Task<object> BuildContentModel(IPublishedElement content, IContentElementBuilder contentElementBuilder) => await BuildModel(content, contentElementBuilder);

        protected abstract Task<T> BuildModel(IPublishedElement content, IContentElementBuilder contentElementBuilder);
	}
}
