using BenchmarkDotNet.Attributes;
using CodingMilitia.DotNetPerfCuriositiesSample.Benchmarks.Helpers;

namespace CodingMilitia.DotNetPerfCuriositiesSample.Benchmarks.SampleCases
{
    public class InitializeImmutableCollectionProperties
    {
        [Benchmark]
        public void InitializeWithNewCollection() => new InitializedWithNewCollection<int>();

        [Benchmark]
        public void InitializeWithImmutableCollection() => new InitializedWithImmutableCollection<int>();

        [Benchmark]
        public void InitializeWithNewCollectionLoop()
        {
            for (var i = 0; i < 1000; ++i)
            {
                new InitializedWithNewCollection<int>();
            }
        }

        [Benchmark]
        public void InitializeWithImmutableCollectionLoop()
        {
            for (var i = 0; i < 1000; ++i)
            {
                new InitializedWithImmutableCollection<int>();
            }
        }
    }
}