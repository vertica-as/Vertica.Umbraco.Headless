/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

namespace Iology.HeadlessUmbraco.Core.Models;

public class ContentElementWithSettings : ContentElement
{
    public IContentElement Settings { get; set; }
}
