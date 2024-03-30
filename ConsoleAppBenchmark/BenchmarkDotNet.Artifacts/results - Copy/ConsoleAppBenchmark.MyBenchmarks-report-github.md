```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3296/23H2/2023Update/SunValley3)
Intel Core i9-10885H CPU 2.40GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 7.0.407
  [Host] : .NET 7.0.17 (7.0.1724.11508), X64 RyuJIT AVX2

Job=MediumRun  Toolchain=InProcessNoEmitToolchain  IterationCount=15  
LaunchCount=2  WarmupCount=10  

```
| Method          | Mean     | Error     | StdDev    |
|---------------- |---------:|----------:|----------:|
| NoVirtualTest   | 1.413 μs | 0.0133 μs | 0.0195 μs |
| WithVirtualTest | 1.384 μs | 0.0065 μs | 0.0093 μs |
