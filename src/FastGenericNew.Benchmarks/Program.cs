﻿// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Environments;

ManualConfig config = ManualConfig.Create(DefaultConfig.Instance);
config.AddJob(
    Job.Default.WithRuntime(ClrRuntime.Net461),
    Job.Default.WithRuntime(ClrRuntime.Net48),
    Job.Default.WithRuntime(CoreRuntime.Core31),
    Job.Default.WithRuntime(CoreRuntime.Core60),
    Job.Default.WithRuntime(CoreRuntime.Core80),
    Job.Default.WithRuntime(CoreRuntime.Core90)
);

config.AddDiagnoser(MemoryDiagnoser.Default);

BenchmarkRunner.Run(Assembly.GetCallingAssembly(), config);