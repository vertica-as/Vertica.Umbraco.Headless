/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

using Umbraco.Cms.Core.PropertyEditors.ValueConverters;

namespace Iology.HeadlessUmbraco.Core.Models;

public class Media : ImageCrop
{
    public Media(string name, string url, int width, int height, string extension, ImageCropperValue imageCropperValue, Dictionary<string, object> additionalProperties)
        : base(url, imageCropperValue)
    {
        Name = name;
        Width = width;
        Height = height;
        Extension = extension?.ToLowerInvariant();
        AdditionalProperties = additionalProperties;
    }

    public string Name { get; }

    public int Width { get; }

    public int Height { get; }

    public string Extension { get; }

    public Dictionary<string, object> AdditionalProperties { get; }
}
