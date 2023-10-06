/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

namespace Iology.HeadlessUmbraco.Swagger.TypeMapping;

public class WithType<TCurrent> : IWithType<TCurrent> where TCurrent : class
{
    private readonly Func<Type, IReplaceType> _callback;

    internal WithType(Func<Type, IReplaceType> callback)
    {
        _callback = callback;
    }

    public IReplaceType With<T>() where T : TCurrent => _callback(typeof(T));
}
