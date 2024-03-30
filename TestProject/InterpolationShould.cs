using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TestProject;

[TestFixture]
public class InterpolationShould
{
    [Test]
    public void Test()
    {
        double startValue = 0.01;
        double endValue = 0.8;
        int bucketSize = 5;
        int startRange = 10;
        int endRange = 50;

        Dictionary<int, double> interpolatedValues = new Dictionary<int, double>();

        int step = (endRange - 0) / bucketSize;
        for (int i = startRange; i <= endRange; i+= step)
        {
            double interpolation = LinearInterpolation(startRange, endRange, i, startValue, endValue);
            int bucketNumber = (int)Math.Ceiling(interpolation / bucketSize);

            interpolatedValues.Add(i, interpolation);
        }

        foreach (var entry in interpolatedValues)
        {
            Console.WriteLine($"For value {entry.Key}: Interpolated value = {entry.Value}");
        }
    }

    static double LinearInterpolation(int start, int end, int i, double startVal, double endVal)
    {
        return startVal + (endVal - startVal) * (i - start) / (end - start);
    }

}
