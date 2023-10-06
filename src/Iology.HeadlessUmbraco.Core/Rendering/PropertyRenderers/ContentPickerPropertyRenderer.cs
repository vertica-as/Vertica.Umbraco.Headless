/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

using Iology.HeadlessUmbraco.Core.Rendering.Providers;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Iology.HeadlessUmbraco.Core.Rendering.PropertyRenderers;

public class ContentPickerPropertyRenderer : NameAndUrlPropertyRenderer
{
    public ContentPickerPropertyRenderer(IUrlProvider urlProvider) : base(urlProvider)
    { }

    public override string PropertyEditorAlias => Constants.PropertyEditors.Aliases.ContentPicker;

    public override bool IsMultiSelect(IPublishedPropertyType propertyType) => false;
}
