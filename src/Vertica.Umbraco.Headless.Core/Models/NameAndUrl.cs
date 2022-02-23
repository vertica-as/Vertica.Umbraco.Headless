namespace Vertica.Umbraco.Headless.Core.Models
{
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
}