using System;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Vertica.Umbraco.Headless.Core.Rendering
{
	public interface IContentModelBuilder
	{
		string ContentTypeAlias();

		Type ModelType();

		public object BuildContentModel(IPublishedElement content, IContentElementBuilder contentElementBuilder);
	}
}