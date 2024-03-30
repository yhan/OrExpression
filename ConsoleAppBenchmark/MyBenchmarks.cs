using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.InProcess.NoEmit;

namespace ConsoleAppBenchmark;

[Config(typeof(AntiVirusFriendlyConfig))]
[SimpleJob(RuntimeMoniker.Net472, baseline: true)]
[SimpleJob(RuntimeMoniker.NetCoreApp30)]
[SimpleJob(RuntimeMoniker.NativeAot70)]
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

    [Benchmark]
    public void NoVirtualTest()
    {
        int sum = 0;
        for (int i = 0; i < Cnt; i++)
        {
            var h = noVirtuals[i];
            sum += h.Offset == 1 ? ((NoVirtualImpl1)h).Hello() : ((NoVirtualImpl2)h).Hello();
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
}

public class AntiVirusFriendlyConfig : ManualConfig
{
    public AntiVirusFriendlyConfig()
    {
        AddJob(Job.MediumRun
            .WithToolchain(InProcessNoEmitToolchain.Instance));
    }
}
