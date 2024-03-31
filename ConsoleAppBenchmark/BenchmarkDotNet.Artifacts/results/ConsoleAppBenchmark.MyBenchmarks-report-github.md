```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3296/23H2/2023Update/SunValley3)
Intel Core i9-10885H CPU 2.40GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 7.0.407
  [Host]        : .NET 7.0.17 (7.0.1724.11508), X64 RyuJIT AVX2
  .NET 7.0      : .NET 7.0.17 (7.0.1724.11508), X64 RyuJIT AVX2
  NativeAOT 7.0 : .NET 7.0.17-servicing.24115.8, X64 NativeAOT AVX2


```
| Method           | Job           | Runtime       | IterationCount | LaunchCount | WarmupCount | Mean       | Error    | StdDev   | Ratio | RatioSD |
|----------------- |-------------- |-------------- |--------------- |------------ |------------ |-----------:|---------:|---------:|------:|--------:|
| NoVirtual_Cast   | .NET 7.0      | .NET 7.0      | Default        | Default     | Default     | 2,913.7 ns | 32.22 ns | 25.15 ns |  1.00 |    0.00 |
| NoVirtual_Offset | .NET 7.0      | .NET 7.0      | Default        | Default     | Default     | 1,400.2 ns | 16.86 ns | 13.16 ns |  0.48 |    0.01 |
|                  |               |               |                |             |             |            |          |          |       |         |
| NoVirtual_Cast   | MediumRun     | .NET 7.0      | 15             | 2           | 10          | 2,491.5 ns | 38.81 ns | 58.09 ns |  1.00 |    0.00 |
| NoVirtual_Offset | MediumRun     | .NET 7.0      | 15             | 2           | 10          | 1,605.7 ns |  5.60 ns |  8.38 ns |  0.64 |    0.02 |
|                  |               |               |                |             |             |            |          |          |       |         |
| NoVirtual_Cast   | NativeAOT 7.0 | NativeAOT 7.0 | Default        | Default     | Default     | 1,064.0 ns | 13.70 ns | 12.15 ns |  1.00 |    0.00 |
| NoVirtual_Offset | NativeAOT 7.0 | NativeAOT 7.0 | Default        | Default     | Default     |   830.0 ns |  3.68 ns |  3.27 ns |  0.78 |    0.01 |
