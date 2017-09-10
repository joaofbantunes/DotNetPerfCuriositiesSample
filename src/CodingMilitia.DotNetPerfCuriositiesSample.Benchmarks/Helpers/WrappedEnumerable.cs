using System.Collections;
using System.Collections.Generic;

namespace CodingMilitia.DotNetPerfCuriositiesSample.Benchmarks.Helpers
{
    public class WrappedEnumerable<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> _enumerable;
        public WrappedEnumerable(IEnumerable<T> enumerable)
        {
            _enumerable = enumerable;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _enumerable.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _enumerable.GetEnumerator();
        }
    }
}