/**
 * Copyright (c) 2023 Vertica
 * Copyright (c) 2023 I-ology
 */

namespace Iology.HeadlessUmbraco.Core.Extensions;

internal static class EnumerableExtensions
{
    internal static async Task<TResult[]> ToArrayAsync<TResult>(this IEnumerable<Task<TResult>> source)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        return await Task.WhenAll(source).ConfigureAwait(false);
    }
}
