using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using CodingMilitia.DotNetPerfCuriositiesSample.Benchmarks.Helpers;

namespace CodingMilitia.DotNetPerfCuriositiesSample.Benchmarks.SampleCases
{
    public class Count
    {
        private const int ArraySize = 1000;
        private static readonly int[] SampleArray = Enumerable.Range(0, ArraySize).ToArray();
        private static readonly IEnumerable<int> SampleArrayAsIEnumerable = SampleArray;
        private static readonly IEnumerable<int> SampleWrappedArray = new WrappedEnumerable<int>(SampleArray);
        private static readonly IEnumerable<int> SampleYieldedArray = SampleArray.YieldEnumerable();

        [Benchmark]
        public void ArrayLength()
        {
            var v = SampleArray.Length;
        }

        [Benchmark]
        public void ArrayAsEnumerableCount()
        {
            var v = SampleArrayAsIEnumerable.Count();
        }

        [Benchmark]
        public void WrappedArrayCount()
        {
            var v = SampleWrappedArray.Count();
        }

        [Benchmark]
        public void YieldedArrayCount()
        {
            var v = SampleYieldedArray.Count();
        }
    }
}