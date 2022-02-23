namespace Vertica.Umbraco.Headless.Core.Models
{
	public interface IBreadcrumbItem
	{
		string Name { get; }

		string Url { get; }
	}
}