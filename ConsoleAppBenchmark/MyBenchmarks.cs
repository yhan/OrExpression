using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.InProcess.NoEmit;

namespace ConsoleAppBenchmark;

[Config(typeof(AntiVirusFriendlyConfig))]
// [SimpleJob(RuntimeMoniker.Net472)]
// [SimpleJob(RuntimeMoniker.NetCoreApp30)]
[SimpleJob(RuntimeMoniker.NativeAot70)]
[SimpleJob(RuntimeMoniker.Net70)]
// [SimpleJob(RuntimeMoniker.Mono)]
[RPlotExporter]
public class MyBenchmarks
{
    private readonly NoVirtual[] noVirtuals;
    private readonly WithVirtual[] virtuals;
    private const int Cnt = 1000;
    public MyBenchmarks()
    {
        noVirtuals = new NoVirtual[Cnt];
        for (int i = 0; i < noVirtuals.Length; i++)
        {
            if (i % 2 == 0) noVirtuals[i] = new NoVirtualImpl1();
            else
                noVirtuals[i] = new NoVirtualImpl2();
        }

        virtuals = new WithVirtual[Cnt];
        for (int i = 0; i < Cnt; i++)
        {
            if (i % 2 == 0) virtuals[i] = new WithVirtualImpl1();
            else
                virtuals[i] = new WithVirtualImpl2();
        }
    }

    [Benchmark(Baseline = true)]
    public void NoVirtual_Cast()
    {
        int sum = 0;
        for (int i = 0; i < Cnt; i++)
        {
            var h = noVirtuals[i];
            if (h is NoVirtualImpl1 impl1)
                sum += impl1.Hello();
            else
                sum += ((NoVirtualImpl2)h).Hello();
        }
    }
    
    [Benchmark]
    public void WithVirtualTest()
    {
        int sum = 0;
        for (int i = 0; i < Cnt; i++)
        {
            var h = virtuals[i];
            sum += h.Hello();
        }
    }
    
    [Benchmark]
    public void NoVirtual_Offset()
    {
        int sum = 0;
        for (int i = 0; i < Cnt; i++)
        {
            var h = noVirtuals[i];
            sum += h.Offset == 1 ? ((NoVirtualImpl1)h).Hello() : ((NoVirtualImpl2)h).Hello();
        }
    }

    // [Benchmark]
    // public void NoVirtualOneLegInheritance()
    // {
    //     int sum = 0;
    //     for (int i = 0; i < Cnt; i++)
    //     {
    //         var h = noVirtuals[i];
    //         sum += h.Offset == 1 ? ((NoVirtualImpl1)h).World() : h.World();
    //     }
    // }
    //
    // [Benchmark(Baseline = true)]
    // public void WithVirtualOneLegInheritance()
    // {
    //     int sum = 0;
    //     for (int i = 0; i < Cnt; i++)
    //     {
    //         var h = virtuals[i];
    //         sum += h.World();
    //     }
    // }

}

public class AntiVirusFriendlyConfig : ManualConfig
{
    public AntiVirusFriendlyConfig()
    {
        // AddExporter(CsvMeasurementsExporter.Default);
        // AddExporter(RPlotExporter.Default);
        AddJob(Job.MediumRun
            .WithToolchain(InProcessNoEmitToolchain.Instance));
    }
}
