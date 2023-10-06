/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

namespace Iology.HeadlessUmbraco.Core.Extensions;

public static class StringExtensions
{
    public static bool IsEmpty(this string value) => string.IsNullOrWhiteSpace(value);

    public static bool IsNotEmpty(this string value) => value.IsEmpty() == false;
}
