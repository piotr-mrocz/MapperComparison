// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using MapperComparison.Services;

Console.WriteLine("Hello, World!");

var results = BenchmarkRunner.Run<MapService>();
Console.ReadKey();