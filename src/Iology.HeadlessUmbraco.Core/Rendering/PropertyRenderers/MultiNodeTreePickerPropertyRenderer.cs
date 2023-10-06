/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

using Iology.HeadlessUmbraco.Core.Rendering.Providers;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PropertyEditors;

namespace Iology.HeadlessUmbraco.Core.Rendering.PropertyRenderers;

public class MultiNodeTreePickerPropertyRenderer : NameAndUrlPropertyRenderer
{
    public MultiNodeTreePickerPropertyRenderer(IUrlProvider urlProvider) : base(urlProvider)
    {
    }

    public override string PropertyEditorAlias => Constants.PropertyEditors.Aliases.MultiNodeTreePicker;

    public override bool IsMultiSelect(IPublishedPropertyType propertyType)
        => propertyType.DataType.ConfigurationAs<MultiNodePickerConfiguration>()!.MaxNumber != 1;
}
