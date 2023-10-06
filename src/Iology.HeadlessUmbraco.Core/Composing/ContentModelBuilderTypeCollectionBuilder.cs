/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

using Iology.HeadlessUmbraco.Core.Rendering;
using Umbraco.Cms.Core.Composing;

namespace Iology.HeadlessUmbraco.Core.Composing;

public class ContentModelBuilderTypeCollectionBuilder : LazyCollectionBuilderBase<ContentModelBuilderTypeCollectionBuilder, ContentModelBuilderTypeCollection, IContentModelBuilder>
{
    protected override ContentModelBuilderTypeCollectionBuilder This => this;
}
