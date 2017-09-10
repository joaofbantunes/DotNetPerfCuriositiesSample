# DotNetPerfCuriositiesSample

This is just to showcase some really simple curiosities on dotnet performance (right now, mainly using LINQ).

Most of them are just to show simple things we do without thinking too much and can have impact on performance, and aren't really too hard to avoid.

## Using the Any() method vs checking Count property greater than 0
``` ini

BenchmarkDotNet=v0.10.9
.NET Core SDK=2.0.0
  [Host]     : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT


```
 |                                          Method |          Mean |       Error |      StdDev |  Gen 0 | Allocated |
 |------------------------------------------------ |--------------:|------------:|------------:|-------:|----------:|
 |                      EmptyReadonlyCollectionAny |     11.968 ns |   0.1197 ns |   0.1119 ns |      - |       0 B |
 |        EmptyReadonlyCollectionCountGreaterThan0 |      3.238 ns |   0.0356 ns |   0.0316 ns |      - |       0 B |
 |                   NonEmptyReadonlyCollectionAny |     17.495 ns |   0.0922 ns |   0.0770 ns | 0.0076 |      32 B |
 |     NonEmptyReadonlyCollectionCountGreaterThan0 |      3.326 ns |   0.0953 ns |   0.1060 ns |      - |       0 B |
 |                  EmptyReadonlyCollectionLoopAny | 12,166.933 ns | 123.0531 ns | 115.1040 ns |      - |       0 B |
 |    EmptyReadonlyCollectionLoopCountGreaterThan0 |  2,780.458 ns |  33.8187 ns |  31.6340 ns |      - |       0 B |
 |               NonEmptyReadonlyCollectionLoopAny | 17,542.220 ns | 205.5246 ns | 192.2478 ns | 7.5989 |   32000 B |
 | NonEmptyReadonlyCollectionLoopCountGreaterThan0 |  2,789.732 ns |  23.9822 ns |  21.2596 ns |      - |       0 B |


## Using ElementAt() method vs using an index prepared collection
``` ini

BenchmarkDotNet=v0.10.9
.NET Core SDK=2.0.0
  [Host]     : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT


```
 |                   Method |           Mean |         Error |        StdDev |   Gen 0 | Allocated |
 |------------------------- |---------------:|--------------:|--------------:|--------:|----------:|
 |              LoopOnArray |       596.9 ns |      8.236 ns |      7.704 ns |       - |       0 B |
 | LoopOnArrayAsIEnumerable |    46,594.3 ns |    419.930 ns |    392.803 ns |       - |       0 B |
 |       LoopOnWrappedArray | 1,279,971.4 ns | 21,846.319 ns | 20,435.059 ns |  5.8594 |   32000 B |
 |       LoopOnYieldedArray | 4,346,367.8 ns | 38,731.909 ns | 36,229.848 ns | 15.6250 |   88000 B |

## Using the Count() method instead of the property
``` ini

BenchmarkDotNet=v0.10.9
.NET Core SDK=2.0.0
  [Host]     : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT


```
 |                 Method |         Mean |       Error |      StdDev |  Gen 0 | Allocated |
 |----------------------- |-------------:|------------:|------------:|-------:|----------:|
 |            ArrayLength |     1.545 ns |   0.0292 ns |   0.0259 ns |      - |       0 B |
 | ArrayAsEnumerableCount |    31.134 ns |   0.6232 ns |   0.5524 ns |      - |       0 B |
 |      WrappedArrayCount | 2,797.372 ns |  34.3275 ns |  32.1100 ns | 0.0038 |      32 B |
 |      YieldedArrayCount | 9,731.539 ns | 155.8781 ns | 145.8085 ns | 0.0153 |      88 B |

## Initialize an immutable collection property with a new collection vs existing immutable collection
``` ini

BenchmarkDotNet=v0.10.9
.NET Core SDK=2.0.0
  [Host]     : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT


```
 |                                Method |          Mean |       Error |      StdDev |   Gen 0 | Allocated |
 |-------------------------------------- |--------------:|------------:|------------:|--------:|----------:|
 |           InitializeWithNewCollection |     16.139 ns |   0.1401 ns |   0.1170 ns |  0.0152 |      64 B |
 |     InitializeWithImmutableCollection |      8.083 ns |   0.2235 ns |   0.2983 ns |  0.0057 |      24 B |
 |       InitializeWithNewCollectionLoop | 12,934.404 ns |  86.7154 ns |  76.8709 ns | 15.2435 |   64000 B |
 | InitializeWithImmutableCollectionLoop |  6,436.796 ns | 127.0472 ns | 212.2673 ns |  5.7144 |   24000 B |
