/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

namespace Iology.HeadlessUmbraco.Core.Models;

public class NameAndUrl
{
    public NameAndUrl(string name, string url)
    {
        Name = name;
        Url = url;
    }

    public string Name { get; }

    public string Url { get; }
}
