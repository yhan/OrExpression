```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3296/23H2/2023Update/SunValley3)
Intel Core i9-10885H CPU 2.40GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 7.0.407
  [Host]        : .NET 7.0.17 (7.0.1724.11508), X64 RyuJIT AVX2
  .NET 7.0      : .NET 7.0.17 (7.0.1724.11508), X64 RyuJIT AVX2
  NativeAOT 7.0 : .NET 7.0.17-servicing.24115.8, X64 NativeAOT AVX2


```
| Method                       | Job           | Runtime       | IterationCount | LaunchCount | WarmupCount | Mean     | Error     | StdDev    | Ratio | RatioSD |
|----------------------------- |-------------- |-------------- |--------------- |------------ |------------ |---------:|----------:|----------:|------:|--------:|
| NoVirtualOneLegInheritance   | .NET 7.0      | .NET 7.0      | Default        | Default     | Default     | 1.475 μs | 0.0291 μs | 0.0494 μs |  1.16 |    0.05 |
| WithVirtualOneLegInheritance | .NET 7.0      | .NET 7.0      | Default        | Default     | Default     | 1.294 μs | 0.0256 μs | 0.0315 μs |  1.00 |    0.00 |
|                              |               |               |                |             |             |          |           |           |       |         |
| NoVirtualOneLegInheritance   | MediumRun     | .NET 7.0      | 15             | 2           | 10          | 1.657 μs | 0.0117 μs | 0.0164 μs |  1.22 |    0.02 |
| WithVirtualOneLegInheritance | MediumRun     | .NET 7.0      | 15             | 2           | 10          | 1.361 μs | 0.0078 μs | 0.0115 μs |  1.00 |    0.00 |
|                              |               |               |                |             |             |          |           |           |       |         |
| NoVirtualOneLegInheritance   | NativeAOT 7.0 | NativeAOT 7.0 | Default        | Default     | Default     | 1.208 μs | 0.0224 μs | 0.0209 μs |  0.84 |    0.02 |
| WithVirtualOneLegInheritance | NativeAOT 7.0 | NativeAOT 7.0 | Default        | Default     | Default     | 1.444 μs | 0.0164 μs | 0.0145 μs |  1.00 |    0.00 |
