namespace Vertica.Umbraco.Headless.Core.Models
{
	public interface IContentElement
	{
		string Alias { get; set; }

		object Content { get; set; }
	}
}