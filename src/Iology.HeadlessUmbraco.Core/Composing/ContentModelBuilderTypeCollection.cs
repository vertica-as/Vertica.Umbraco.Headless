/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

using Iology.HeadlessUmbraco.Core.Rendering;
using Umbraco.Cms.Core.Composing;

namespace Iology.HeadlessUmbraco.Core.Composing;

public class ContentModelBuilderTypeCollection : BuilderCollectionBase<IContentModelBuilder>
{
    public ContentModelBuilderTypeCollection(Func<IEnumerable<IContentModelBuilder>> items) : base(items)
    {
    }
}
