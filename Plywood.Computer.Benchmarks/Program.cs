// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using Plywood.Computer.Benchmarks;

var summary = BenchmarkRunner.Run<MathLibraryBenchmark>();
Console.WriteLine(summary);