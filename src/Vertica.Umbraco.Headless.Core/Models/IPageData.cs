namespace Vertica.Umbraco.Headless.Core.Models
{
	public interface IPageData : IContentElement
	{
		IMetadata Metadata { get; set; }

		INavigation Navigation { get; set; }
	}
}