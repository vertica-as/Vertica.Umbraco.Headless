using System.Collections.Generic;

namespace Vertica.Umbraco.Headless.Core.Models
{
	public interface INavigation
	{
		IEnumerable<IBreadcrumbItem> Breadcrumb { get; set; }
	}
}