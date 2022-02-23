namespace Vertica.Umbraco.Headless.Core.Models
{
    public class ContentElement : IContentElement
    {
	    public string Alias { get; set; }

        public object Content { get; set; }
    }
}
