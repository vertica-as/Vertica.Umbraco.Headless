/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

namespace Iology.HeadlessUmbraco.Swagger.TypeMapping;

public interface IReplaceType
{
    IWithType<T> Replace<T>() where T : class;
}
