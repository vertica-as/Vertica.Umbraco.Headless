/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

namespace Iology.HeadlessUmbraco.Swagger.TypeMapping;

public interface IWithType<in TCurrent> where TCurrent : class
{
    IReplaceType With<T>() where T : TCurrent;
}
