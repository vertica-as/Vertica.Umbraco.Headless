/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

using System;
using System.Collections.Generic;
using Umbraco.Cms.Core.Composing;
using Iology.HeadlessUmbraco.Core.Rendering;

namespace Iology.HeadlessUmbraco.Core.Composing;

public class ContentModelBuilderTypeCollection : BuilderCollectionBase<IContentModelBuilder>
{
	public ContentModelBuilderTypeCollection(Func<IEnumerable<IContentModelBuilder>> items) : base(items)
	{
	}
}