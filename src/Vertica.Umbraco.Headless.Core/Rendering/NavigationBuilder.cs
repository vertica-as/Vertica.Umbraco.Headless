using System.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;
using Vertica.Umbraco.Headless.Core.Models;

namespace Vertica.Umbraco.Headless.Core.Rendering
{
	public class NavigationBuilder : INavigationBuilder
	{
		public virtual INavigation BuildNavigation(IPublishedContent content) => BuildNavigation<Navigation>(content);

		protected TNavigation BuildNavigation<TNavigation>(IPublishedContent content) where TNavigation : class, INavigation, new()
			=> new TNavigation
			{
				Breadcrumb = content
					.Ancestors()
					.Reverse()
					.Select(c => new BreadcrumbItem(c.Name, c.Url()))
					.ToArray()
			};
	}
}
