/**
 * Copyright (c) 2022 Vertica
 * Copyright (c) 2023 I-ology
 */

namespace Iology.HeadlessUmbraco.Swagger.TypeMapping;

public class ReplaceType : IReplaceType
{
    private readonly Dictionary<Type, Type> _mappings;

    internal ReplaceType()
    {
        _mappings = new Dictionary<Type, Type>();
    }

    public IWithType<T> Replace<T>() where T : class
    {
        return new WithType<T>(type =>
        {
            _mappings[typeof(T)] = type;
            return this;
        });
    }

    internal IDictionary<Type, Type> Mappings => _mappings;
}
