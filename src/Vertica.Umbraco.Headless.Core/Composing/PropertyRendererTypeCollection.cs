using System;
using System.Collections.Generic;
using Umbraco.Cms.Core.Composing;
using Vertica.Umbraco.Headless.Core.Rendering;

namespace Vertica.Umbraco.Headless.Core.Composing
{
	public class PropertyRendererTypeCollection : BuilderCollectionBase<IPropertyRenderer>
	{
		public PropertyRendererTypeCollection(Func<IEnumerable<IPropertyRenderer>> items) : base(items)
		{
		}
	}
}
