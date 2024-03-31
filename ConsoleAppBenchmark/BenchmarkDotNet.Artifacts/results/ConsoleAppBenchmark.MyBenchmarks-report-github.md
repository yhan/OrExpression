```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3296/23H2/2023Update/SunValley3)
Intel Core i9-10885H CPU 2.40GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 7.0.407
  [Host]        : .NET 7.0.17 (7.0.1724.11508), X64 RyuJIT AVX2
  .NET 7.0      : .NET 7.0.17 (7.0.1724.11508), X64 RyuJIT AVX2
  NativeAOT 7.0 : .NET 7.0.17-servicing.24115.8, X64 NativeAOT AVX2


```
| Method           | Job           | Runtime       | IterationCount | LaunchCount | WarmupCount | Mean     | Error     | StdDev    | Ratio | RatioSD |
|----------------- |-------------- |-------------- |--------------- |------------ |------------ |---------:|----------:|----------:|------:|--------:|
| NoVirtual_Cast   | .NET 7.0      | .NET 7.0      | Default        | Default     | Default     | 2.997 μs | 0.0431 μs | 0.0403 μs |  1.00 |    0.00 |
| WithVirtualTest  | .NET 7.0      | .NET 7.0      | Default        | Default     | Default     | 1.247 μs | 0.0156 μs | 0.0146 μs |  0.42 |    0.01 |
| NoVirtual_Offset | .NET 7.0      | .NET 7.0      | Default        | Default     | Default     | 1.427 μs | 0.0285 μs | 0.0266 μs |  0.48 |    0.01 |
|                  |               |               |                |             |             |          |           |           |       |         |
| NoVirtual_Cast   | MediumRun     | .NET 7.0      | 15             | 2           | 10          | 2.760 μs | 0.0623 μs | 0.0832 μs |  1.00 |    0.00 |
| WithVirtualTest  | MediumRun     | .NET 7.0      | 15             | 2           | 10          | 1.466 μs | 0.0273 μs | 0.0401 μs |  0.53 |    0.02 |
| NoVirtual_Offset | MediumRun     | .NET 7.0      | 15             | 2           | 10          | 1.432 μs | 0.0160 μs | 0.0234 μs |  0.52 |    0.02 |
|                  |               |               |                |             |             |          |           |           |       |         |
| NoVirtual_Cast   | NativeAOT 7.0 | NativeAOT 7.0 | Default        | Default     | Default     | 1.111 μs | 0.0222 μs | 0.0389 μs |  1.00 |    0.00 |
| WithVirtualTest  | NativeAOT 7.0 | NativeAOT 7.0 | Default        | Default     | Default     | 1.417 μs | 0.0193 μs | 0.0171 μs |  1.23 |    0.05 |
| NoVirtual_Offset | NativeAOT 7.0 | NativeAOT 7.0 | Default        | Default     | Default     | 1.195 μs | 0.0200 μs | 0.0187 μs |  1.04 |    0.04 |
