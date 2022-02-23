using System;
using System.Collections.Generic;
using Umbraco.Cms.Core.Composing;
using Vertica.Umbraco.Headless.Core.Rendering;

namespace Vertica.Umbraco.Headless.Core.Composing
{
	public class ContentModelBuilderTypeCollection : BuilderCollectionBase<IContentModelBuilder>
	{
		public ContentModelBuilderTypeCollection(Func<IEnumerable<IContentModelBuilder>> items) : base(items)
		{
		}
	}
}