using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using CodingMilitia.DotNetPerfCuriositiesSample.Benchmarks.Helpers;

namespace CodingMilitia.DotNetPerfCuriositiesSample.Benchmarks.SampleCases
{
    public class ElementAt
    {
        private const int ArraySize = 1000;
        private static readonly int[] SampleArray = Enumerable.Range(0, ArraySize).ToArray();
        private static readonly IEnumerable<int> SampleArrayAsIEnumerable = SampleArray;
        private static readonly IEnumerable<int> SampleWrappedArray = new WrappedEnumerable<int>(SampleArray);
        private static readonly IEnumerable<int> SampleYieldedArray = SampleArray.YieldEnumerable();

        [Benchmark]
        public void LoopOnArray()
        {
            for(var i = 0; i < ArraySize; ++i)
            {
                var v = SampleArray[i];
            }
        }

        [Benchmark]
        public void LoopOnArrayAsIEnumerable()
        {
            for(var i = 0; i < ArraySize; ++i)
            {
                var v = SampleArrayAsIEnumerable.ElementAt(i);
            }
        }

        [Benchmark]
        public void LoopOnWrappedArray()
        {
            for(var i = 0; i < ArraySize; ++i)
            {
                var v = SampleWrappedArray.ElementAt(i);
            }
        }

        [Benchmark]
        public void LoopOnYieldedArray()
        {
            for(var i = 0; i < ArraySize; ++i)
            {
                var v = SampleYieldedArray.ElementAt(i);
            }
        }
    }
}