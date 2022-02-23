using Umbraco.Cms.Core.Models;

namespace Vertica.Umbraco.Headless.Core.Models
{
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
}
