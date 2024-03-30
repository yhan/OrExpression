```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3296/23H2/2023Update/SunValley3)
Intel Core i9-10885H CPU 2.40GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 7.0.407
  [Host]        : .NET 7.0.17 (7.0.1724.11508), X64 RyuJIT AVX2
  NativeAOT 7.0 : .NET 7.0.17-servicing.24115.8, X64 NativeAOT AVX2


```
| Method          | Job                  | Runtime              | IterationCount | LaunchCount | WarmupCount | Mean     | Error     | StdDev    | Ratio | RatioSD |
|---------------- |--------------------- |--------------------- |--------------- |------------ |------------ |---------:|----------:|----------:|------:|--------:|
| NoVirtualTest   | .NET Core 3.0        | .NET Core 3.0        | Default        | Default     | Default     |       NA |        NA |        NA |     ? |       ? |
| NoVirtualTest   | .NET Framework 4.7.2 | .NET Framework 4.7.2 | Default        | Default     | Default     |       NA |        NA |        NA |     ? |       ? |
| NoVirtualTest   | MediumRun            | .NET 7.0             | 15             | 2           | 10          | 1.765 μs | 0.1625 μs | 0.2433 μs |     ? |       ? |
| NoVirtualTest   | NativeAOT 7.0        | NativeAOT 7.0        | Default        | Default     | Default     | 1.243 μs | 0.0249 μs | 0.0387 μs |     ? |       ? |
|                 |                      |                      |                |             |             |          |           |           |       |         |
| WithVirtualTest | .NET Core 3.0        | .NET Core 3.0        | Default        | Default     | Default     |       NA |        NA |        NA |     ? |       ? |
| WithVirtualTest | .NET Framework 4.7.2 | .NET Framework 4.7.2 | Default        | Default     | Default     |       NA |        NA |        NA |     ? |       ? |
| WithVirtualTest | MediumRun            | .NET 7.0             | 15             | 2           | 10          | 1.610 μs | 0.0172 μs | 0.0252 μs |     ? |       ? |
| WithVirtualTest | NativeAOT 7.0        | NativeAOT 7.0        | Default        | Default     | Default     | 1.482 μs | 0.0287 μs | 0.0599 μs |     ? |       ? |

Benchmarks with issues:
  MyBenchmarks.NoVirtualTest: .NET Core 3.0(Runtime=.NET Core 3.0)
  MyBenchmarks.NoVirtualTest: .NET Framework 4.7.2(Runtime=.NET Framework 4.7.2)
  MyBenchmarks.WithVirtualTest: .NET Core 3.0(Runtime=.NET Core 3.0)
  MyBenchmarks.WithVirtualTest: .NET Framework 4.7.2(Runtime=.NET Framework 4.7.2)
