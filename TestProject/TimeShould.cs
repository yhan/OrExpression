using System;
using System.Diagnostics;
using NUnit.Framework;

namespace TestProject;

public class TimeShould
{
    [Test]
    public void Test()
    {
        var span = TimeSpan.FromSeconds((DateTimeOffset.UtcNow.Ticks - Stopwatch.GetTimestamp()) / Stopwatch.Frequency);
        var exp = span.TotalDays / 365 + "/ " + span.TotalHours % 24 + "/ " + span.TotalHours % 60 + "/ " + span.TotalSeconds % 60;
        TestContext.WriteLine(exp);
        TestContext.WriteLine(DateTimeOffset.UtcNow.ToString());
    }

    [Test]
    public void StopWatchGetTS()
    {
        long ts = Stopwatch.GetTimestamp();
        var sec = ts / Stopwatch.Frequency;
        TestContext.WriteLine($"nb of Minutes = {TimeSpan.FromSeconds(sec).TotalMinutes}");
    }
}