using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using FastGenericNew;
#pragma warning disable CA1822 // Member does not access instance data and can be marked as static

namespace Benchmark
{
    [StopOnFirstError]
    [MemoryDiagnoser]
    [DisassemblyDiagnoser]
    [BaselineColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class FastNewBenchmark
    {
        [Benchmark]
        public Example DirectNew() =>
            new Example();

        [Benchmark(Baseline = true)]
        public Example FastNewT() =>
            Test<Example>.FastNew();

        [Benchmark]
        public Example NewT() =>
            Test<Example>.New();

        [Benchmark]
        public Example ActivatorCreate() =>
            Test<Example>.ActivatorCreate();
    }

    public static class Test<T> where T : new()
    {
        public static T FastNew() => FastNew<T>.CreateInstance();

        public static T New() => new T();

        public static T ActivatorCreate() => Activator.CreateInstance<T>();
    }

    public class Example { }
}