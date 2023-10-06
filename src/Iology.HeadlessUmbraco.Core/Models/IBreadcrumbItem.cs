/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

namespace Iology.HeadlessUmbraco.Core.Models;

public interface IBreadcrumbItem
{
    string Name { get; }

    string Url { get; }
}
