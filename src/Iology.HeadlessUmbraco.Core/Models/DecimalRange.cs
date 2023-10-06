/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

namespace Iology.HeadlessUmbraco.Core.Models;

public class DecimalRange
{
    public DecimalRange(decimal min, decimal max)
    {
        Min = min;
        Max = max;
    }

    public decimal Min { get; }

    public decimal Max { get; }
}
