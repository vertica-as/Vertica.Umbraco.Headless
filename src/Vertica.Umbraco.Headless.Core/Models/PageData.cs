namespace Vertica.Umbraco.Headless.Core.Models
{
	public class PageData : IPageData
    {
	    public string Alias { get; set; }

	    public object Content { get; set; }

        public IMetadata Metadata { get; set; }

        public INavigation Navigation { get; set; }
    }
}
