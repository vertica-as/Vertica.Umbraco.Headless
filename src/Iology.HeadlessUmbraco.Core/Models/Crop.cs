/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

namespace Iology.HeadlessUmbraco.Core.Models;

public class Crop
{
    public Crop(string alias, int width, int height, string url)
    {
        Alias = alias;
        Width = width;
        Height = height;
        Url = url;
    }

    public string Alias { get; }

    public int Width { get; }

    public int Height { get; }

    public string Url { get; }
}
