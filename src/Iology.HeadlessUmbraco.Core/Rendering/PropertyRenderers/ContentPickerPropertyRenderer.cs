/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using Iology.HeadlessUmbraco.Core.Rendering.Providers;

namespace Iology.HeadlessUmbraco.Core.Rendering.PropertyRenderers;

public class ContentPickerPropertyRenderer : NameAndUrlPropertyRenderer
{
	public ContentPickerPropertyRenderer(IUrlProvider urlProvider) : base(urlProvider)
	{
	}

	public override string PropertyEditorAlias => Constants.PropertyEditors.Aliases.ContentPicker;

	public override bool IsMultiSelect(IPublishedPropertyType propertyType) => false;
}