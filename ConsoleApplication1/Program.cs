using System;
using System.Diagnostics;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            CollectSamples();
        }

        public static void CollectSamples()
        {
            const String categoryName = "ElapsedTimeSampleCategory";
            const String counterName = "ElapsedTimeSample";

            // If the category does not exist, create the category and exit.
            // Performance counters should not be created and immediately used.
            // There is a latency time to enable the counters, they should be created
            // prior to executing the application that uses the counters.
            // Execute this sample a second time to use the category.
            if (!PerformanceCounterCategory.Exists(categoryName))
            {

                CounterCreationDataCollection CCDC = new CounterCreationDataCollection();

                // Add the counter.
                CounterCreationData ETimeData = new CounterCreationData();
                ETimeData.CounterType = PerformanceCounterType.ElapsedTime;
                ETimeData.CounterName = counterName;
                CCDC.Add(ETimeData);

                // Create the category.
                PerformanceCounterCategory.Create(categoryName,
                                                "Demonstrates ElapsedTime performance counter usage.",
                                                PerformanceCounterCategoryType.SingleInstance,
                                                CCDC);
                // Return, rerun the application to make use of the new counters.
                return;
            }
            else
            {
                Console.WriteLine("Category exists - {0}", categoryName);
            }

            // Create the performance counter.
            PerformanceCounter perfCounter = new PerformanceCounter(categoryName,
            counterName,
            false);
            // Initialize the counter.
            perfCounter.RawValue = Stopwatch.GetTimestamp();

            DateTime start = DateTime.Now;

            // Loop for the samples.
            for (int j = 0; j < 100; j++)
            {
                // Output the values.
                if ((j % 10) == 9)
                {
                    Console.WriteLine("NextValue() = " + perfCounter.NextValue().ToString());
                    Console.WriteLine("Actual elapsed time = " + DateTime.Now.Subtract(start).ToString());
                    OutputSample(perfCounter.NextSample());
                }

                // Reset the counter on every 20th iteration.
                if (j % 20 == 0)
                {
                    perfCounter.RawValue = Stopwatch.GetTimestamp();
                    start = DateTime.Now;
                }
                System.Threading.Thread.Sleep(50);
            }

            Console.WriteLine("Elapsed time = " + DateTime.Now.Subtract(start).ToString());
        }

        private static void OutputSample(CounterSample s)
        {
            Console.WriteLine("\r\n+++++++++++");
            Console.WriteLine("Sample values - \r\n");
            Console.WriteLine("   BaseValue        = " + s.BaseValue);
            Console.WriteLine("   CounterFrequency = " + s.CounterFrequency);
            Console.WriteLine("   CounterTimeStamp = " + s.CounterTimeStamp);
            Console.WriteLine("   CounterType      = " + s.CounterType);
            Console.WriteLine("   RawValue         = " + s.RawValue);
            Console.WriteLine("   SystemFrequency  = " + s.SystemFrequency);
            Console.WriteLine("   TimeStamp        = " + s.TimeStamp);
            Console.WriteLine("   TimeStamp100nSec = " + s.TimeStamp100nSec);
            Console.WriteLine("++++++++++++++++++++++");
        }
    }
}
