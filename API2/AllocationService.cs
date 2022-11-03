using System.Diagnostics;

namespace API2;

public class AllocateService : IHostedService
{
    readonly Random rand = new Random();
    public Task StartAsync(CancellationToken cancellationToken)
    {
        var thread = new Thread(Loop);
        thread.Start();
        return Task.CompletedTask;
    }

    private void Loop(object? obj)
    {
        long loop = 0;
        while (true)
        {
            var array = new List<byte[]>();
            for (int i = 0; i < 1024; i++)
            {
                var bytes = new byte[1024];
                rand.NextBytes(bytes);
                array.Add(bytes);
            }

            Thread.Sleep(rand.Next(1, 10));
            Debug.WriteLine($"array size = {array.Count}");
            if (loop + 1 == long.MaxValue)
                loop = 0;
            loop++;
        }
    }
    public Task StopAsync(CancellationToken cancellationToken)
    {
        Debug.WriteLine($" {nameof(AllocateService)} stopped");
        return Task.CompletedTask;
    }
}
