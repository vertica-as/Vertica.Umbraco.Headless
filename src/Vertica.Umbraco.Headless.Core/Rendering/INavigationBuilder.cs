using System.Threading;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Vertica.Umbraco.Headless.Core.Models;

namespace Vertica.Umbraco.Headless.Core.Rendering
{
	public interface INavigationBuilder
	{
		Task<INavigation> BuildNavigationAsync(IPublishedContent content, CancellationToken cancellationToken);
	}
}