﻿/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

using Umbraco.Cms.Core;

namespace Iology.HeadlessUmbraco.Core.Rendering.PropertyRenderers;

public class ColorPickerEyeDropperPropertyRenderer : GenericPropertyRenderer<string>
{
	public override string PropertyEditorAlias => Constants.PropertyEditors.Aliases.ColorPickerEyeDropper;
}