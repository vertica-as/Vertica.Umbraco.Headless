/**
 * Copyright (c) 2023 Vertica
 * Copyright (c) 2023 I-ology
 */

using Iology.HeadlessUmbraco.Core.Extensions;
using Iology.HeadlessUmbraco.Core.Rendering.Providers;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PropertyEditors;
using Umbraco.Cms.Core.PropertyEditors.ValueConverters;
using Umbraco.Extensions;
using Media = Iology.HeadlessUmbraco.Core.Models.Media;

namespace Iology.HeadlessUmbraco.Core.Rendering.PropertyRenderers;

public class MediaPicker3PropertyRenderer : IPropertyRenderer
{
    private readonly IUrlProvider _urlProvider;

    public MediaPicker3PropertyRenderer(IUrlProvider urlProvider)
    {
        _urlProvider = urlProvider;
    }

    public string PropertyEditorAlias => Constants.PropertyEditors.Aliases.MediaPicker3;

    public Type TypeFor(IPublishedPropertyType propertyType)
        => propertyType.DataType.ConfigurationAs<MediaPicker3Configuration>()!.Multiple
            ? typeof(Media[])
            : typeof(Media);

    public async Task<object?> ValueForAsync(object? umbracoValue, IPublishedProperty property, IContentElementBuilder contentElementBuilder, CancellationToken cancellationToken)
    {
        async Task<Media> CreateMediaAsync(MediaWithCrops media) => await ToMediaAsync(media.Content, media.LocalCrops, contentElementBuilder, _urlProvider, UrlMode.Auto, cancellationToken).ConfigureAwait(false);

        return umbracoValue switch
        {
            MediaWithCrops item => await CreateMediaAsync(item).ConfigureAwait(false),
            IEnumerable<MediaWithCrops> items => await items.Select(CreateMediaAsync).ToArrayAsync().ConfigureAwait(false),
            _ => null
        };
    }

    internal static async Task<Media> ToMediaAsync(
        IPublishedContent media,
        ImageCropperValue imageCropperValue,
        IContentElementBuilder contentElementBuilder,
        IUrlProvider urlProvider,
        UrlMode urlMode,
        CancellationToken cancellationToken)
    {
        var additionalProperties = new Dictionary<string, object>();
        foreach (var property in media.Properties)
        {
            if (property.Alias.StartsWith("umbraco") == false)
                additionalProperties.Add(property.Alias, await contentElementBuilder.PropertyValueForAsync(media, property, cancellationToken).ConfigureAwait(false));
        }

        return new Media(
            media.Name,
            urlProvider.UrlFor(media, urlMode),
            media.Value<int>(Constants.Conventions.Media.Width),
            media.Value<int>(Constants.Conventions.Media.Height),
            media.Value<string>(Constants.Conventions.Media.Extension),
            imageCropperValue,
            additionalProperties
        );
    }
}
