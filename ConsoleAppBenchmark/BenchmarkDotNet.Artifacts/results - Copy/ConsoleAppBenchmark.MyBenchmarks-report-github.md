```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3296/23H2/2023Update/SunValley3)
Intel Core i9-10885H CPU 2.40GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 7.0.407
  [Host]        : .NET 7.0.17 (7.0.1724.11508), X64 RyuJIT AVX2
  .NET 7.0      : .NET 7.0.17 (7.0.1724.11508), X64 RyuJIT AVX2
  NativeAOT 7.0 : .NET 7.0.17-servicing.24115.8, X64 NativeAOT AVX2


```
| Method          | Job           | Runtime       | IterationCount | LaunchCount | WarmupCount | Mean     | Error     | StdDev    | Ratio | RatioSD |
|---------------- |-------------- |-------------- |--------------- |------------ |------------ |---------:|----------:|----------:|------:|--------:|
| NoVirtualTest   | .NET 7.0      | .NET 7.0      | Default        | Default     | Default     | 1.365 μs | 0.0189 μs | 0.0177 μs |  1.14 |    0.02 |
| WithVirtualTest | .NET 7.0      | .NET 7.0      | Default        | Default     | Default     | 1.199 μs | 0.0143 μs | 0.0134 μs |  1.00 |    0.00 |
|                 |               |               |                |             |             |          |           |           |       |         |
| NoVirtualTest   | MediumRun     | .NET 7.0      | 15             | 2           | 10          | 2.059 μs | 0.1247 μs | 0.1867 μs |  1.38 |    0.14 |
| WithVirtualTest | MediumRun     | .NET 7.0      | 15             | 2           | 10          | 1.498 μs | 0.0352 μs | 0.0516 μs |  1.00 |    0.00 |
|                 |               |               |                |             |             |          |           |           |       |         |
| NoVirtualTest   | NativeAOT 7.0 | NativeAOT 7.0 | Default        | Default     | Default     | 1.199 μs | 0.0186 μs | 0.0165 μs |  0.85 |    0.01 |
| WithVirtualTest | NativeAOT 7.0 | NativeAOT 7.0 | Default        | Default     | Default     | 1.419 μs | 0.0113 μs | 0.0094 μs |  1.00 |    0.00 |
