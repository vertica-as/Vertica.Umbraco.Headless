/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

namespace Iology.HeadlessUmbraco.Core.Models;

public class ContentElement : IContentElement
{
	public string Alias { get; set; }

    public object Content { get; set; }
}
