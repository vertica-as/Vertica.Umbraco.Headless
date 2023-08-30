using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Vertica.Umbraco.Headless.Core.Extensions
{
    public static class EnumerableExtensions
    {
        public static async Task<TResult[]> ToArrayAsync<T, TResult>(this IEnumerable<T> source, Func<T, Task<TResult>> func)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            var list = new List<TResult>();
            foreach (var item in source)
            {
                var result = await func(item).ConfigureAwait(false);
                list.Add(result);
            }
            return list.ToArray();
        }
    }
}