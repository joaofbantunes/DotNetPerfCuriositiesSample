using System.Collections.Generic;

namespace CodingMilitia.DotNetPerfCuriositiesSample.Benchmarks.Helpers
{
    public class InitializedWithNewCollection<T>
    {
        public IEnumerable<T> Collection { get; set; }

        public InitializedWithNewCollection()
        {
            Collection = new List<T>();
        }
    }
}