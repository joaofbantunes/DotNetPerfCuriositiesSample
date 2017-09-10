using System.Collections.Generic;

namespace CodingMilitia.DotNetPerfCuriositiesSample.Benchmarks.Helpers
{
    public static class Extensions
    {
        public static IEnumerable<T> YieldEnumerable<T>(this IEnumerable<T> enumerable)
        {
            foreach(var value in enumerable)
            {
                yield return value;
            }
        }

        public static bool AnyUsingCount<T>(this IReadOnlyCollection<T> collection)
        {
            return collection.Count > 0;
        }
    }
}