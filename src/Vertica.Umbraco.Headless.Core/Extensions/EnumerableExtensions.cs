using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Vertica.Umbraco.Headless.Core.Extensions
{
    public static class EnumerableExtensions
    {
        public static async Task<TResult[]> ToArrayAsync<T, TResult>(this IEnumerable<T> collection, Func<T, Task<TResult>> func)
        {
            var list = new List<TResult>();
            foreach (var item in collection)
            {
                var result = await func(item);
                list.Add(result);
            }
            return list.ToArray();
        }
    }
}