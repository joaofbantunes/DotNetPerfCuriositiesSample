using System;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Running;
using CodingMilitia.DotNetPerfCuriositiesSample.Benchmarks.SampleCases;

namespace CodingMilitia.DotNetPerfCuriositiesSample.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var samples = new Type[]
            {
                typeof(Any),
                typeof(ElementAt),
                typeof(Count),
                typeof(InitializeImmutableCollectionProperties)
            };

            var summary = BenchmarkRunner.Run(samples[int.Parse(args[0])],
                    ManualConfig.Create(DefaultConfig.Instance).With(MemoryDiagnoser.Default)
                );
        }
    }
}
