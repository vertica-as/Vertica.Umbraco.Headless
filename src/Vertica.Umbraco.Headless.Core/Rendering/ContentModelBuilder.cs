using System;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Vertica.Umbraco.Headless.Core.Rendering
{
	public abstract class ContentModelBuilder<T> : IContentModelBuilder where T : class
	{
		public Type ModelType() => typeof(T);

		public abstract string ContentTypeAlias();

		public object BuildContentModel(IPublishedElement content, IContentElementBuilder contentElementBuilder) => BuildModel(content, contentElementBuilder);

		protected abstract T BuildModel(IPublishedElement content, IContentElementBuilder contentElementBuilder);
	}
}
