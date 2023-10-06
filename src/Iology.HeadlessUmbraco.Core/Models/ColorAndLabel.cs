/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

namespace Iology.HeadlessUmbraco.Core.Models;

public class ColorAndLabel
{
    public ColorAndLabel(string color, string label)
    {
        Color = color;
        Label = label;
    }

    public string Color { get; }
        
    public string Label { get; }
}
