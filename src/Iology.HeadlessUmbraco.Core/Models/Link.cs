/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

using Umbraco.Cms.Core.Models;

namespace Iology.HeadlessUmbraco.Core.Models;

public class Link
{
    public Link(string name, string target, string url, LinkType linkType)
    {
        Name = name;
        Target = target;
        Url = url;
        LinkType = linkType;
    }

    public string Name { get; }

    public string Target { get; }

    public string Url { get; }

    public LinkType LinkType { get; }
}
