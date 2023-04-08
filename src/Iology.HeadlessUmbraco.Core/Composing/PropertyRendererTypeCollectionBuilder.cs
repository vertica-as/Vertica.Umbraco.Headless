/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

using Umbraco.Cms.Core.Composing;
using Iology.HeadlessUmbraco.Core.Rendering;

namespace Iology.HeadlessUmbraco.Core.Composing;

public class PropertyRendererTypeCollectionBuilder : LazyCollectionBuilderBase<PropertyRendererTypeCollectionBuilder, PropertyRendererTypeCollection, IPropertyRenderer>
{
	protected override PropertyRendererTypeCollectionBuilder This => this;
}
