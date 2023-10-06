/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

using Microsoft.AspNetCore.Mvc;

namespace Iology.HeadlessUmbraco.Core.Rendering.Output;

public interface IOutputRenderer
{
    string Serialize(object value);

    IActionResult ActionResult(object value);
}
