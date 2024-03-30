// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using ConsoleAppBenchmark;

Console.WriteLine("Hello, World!");

var summary = BenchmarkRunner.Run<MyBenchmarks>();
