/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

namespace Iology.HeadlessUmbraco.Core.Models;

public class FocalPoint
{
    public FocalPoint(decimal left, decimal top)
    {
        Left = left;
        Top = top;
    }

    public static FocalPoint Default() => new FocalPoint(0.5m, 0.5m);

    public decimal Left { get; }

    public decimal Top { get; }
}
