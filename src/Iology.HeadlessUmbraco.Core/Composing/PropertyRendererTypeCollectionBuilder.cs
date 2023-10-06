/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

using Iology.HeadlessUmbraco.Core.Rendering;
using Umbraco.Cms.Core.Composing;

namespace Iology.HeadlessUmbraco.Core.Composing;

public class PropertyRendererTypeCollectionBuilder : LazyCollectionBuilderBase<PropertyRendererTypeCollectionBuilder, PropertyRendererTypeCollection, IPropertyRenderer>
{
    protected override PropertyRendererTypeCollectionBuilder This => this;
}
