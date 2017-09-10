using System.Collections.Generic;
using System.Linq;

namespace CodingMilitia.DotNetPerfCuriositiesSample.Benchmarks.Helpers
{
    public class InitializedWithImmutableCollection<T>
    {
        public IEnumerable<T> Collection { get; set; }

        public InitializedWithImmutableCollection()
        {
            Collection = Enumerable.Empty<T>(); //or Array.Empty<T>()
        }
    }
}