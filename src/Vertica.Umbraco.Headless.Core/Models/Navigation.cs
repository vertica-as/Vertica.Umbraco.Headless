using System.Collections.Generic;

namespace Vertica.Umbraco.Headless.Core.Models
{
    public class Navigation : INavigation
    {
        public IEnumerable<IBreadcrumbItem> Breadcrumb { get; set; }
    }
}
