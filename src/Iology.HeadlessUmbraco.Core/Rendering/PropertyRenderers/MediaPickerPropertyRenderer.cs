/**
 * Copyright (c) 2023 Vertica
 * Copyright (c) 2023 I-ology
 */

using Iology.HeadlessUmbraco.Core.Extensions;
using Iology.HeadlessUmbraco.Core.Models;
using Iology.HeadlessUmbraco.Core.Rendering.Providers;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PropertyEditors;
using Umbraco.Cms.Core.PropertyEditors.ValueConverters;
using Umbraco.Extensions;

namespace Iology.HeadlessUmbraco.Core.Rendering.PropertyRenderers;

public class MediaPickerPropertyRenderer : IPropertyRenderer
{
    private readonly IUrlProvider _urlProvider;

    public MediaPickerPropertyRenderer(IUrlProvider urlProvider)
    {
        _urlProvider = urlProvider;
    }

    public string PropertyEditorAlias => Constants.PropertyEditors.Aliases.MediaPicker;

    public Type TypeFor(IPublishedPropertyType propertyType)
        => propertyType.DataType.ConfigurationAs<MediaPickerConfiguration>()!.Multiple
            ? typeof(Media[])
            : typeof(Media);

    public virtual async Task<object?> ValueForAsync(object? umbracoValue, IPublishedProperty property, IContentElementBuilder contentElementBuilder, CancellationToken cancellationToken)
    {
        async Task<Media> CreateMediaAsync(IPublishedContent media)
        {
            var imageCropperValue = media.Value<ImageCropperValue>(Constants.Conventions.Media.File);
            return await MediaPicker3PropertyRenderer.ToMediaAsync(media, imageCropperValue, contentElementBuilder, _urlProvider, UrlMode.Auto, cancellationToken).ConfigureAwait(false);
        }

        return umbracoValue switch
        {
            IPublishedContent item => await CreateMediaAsync(item).ConfigureAwait(false),
            IEnumerable<IPublishedContent> items => await items.Select(CreateMediaAsync).ToArrayAsync().ConfigureAwait(false),
            _ => null
        };
    }
}
