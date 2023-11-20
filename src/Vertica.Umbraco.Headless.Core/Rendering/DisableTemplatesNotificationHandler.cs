using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Features;
using Umbraco.Cms.Core.Notifications;

namespace Vertica.Umbraco.Headless.Core.Rendering
{
    public class DisableTemplatesNotificationHandler : INotificationHandler<UmbracoApplicationStartingNotification>
    {
        private readonly UmbracoFeatures _features;

        public DisableTemplatesNotificationHandler(UmbracoFeatures features) => _features = features;

        /// <summary>
        ///     Handles the <see cref="UmbracoApplicationStartingNotification" />
        /// </summary>
        public void Handle(UmbracoApplicationStartingNotification notification) =>
            _features.Disabled.DisableTemplates = true;
    }
}