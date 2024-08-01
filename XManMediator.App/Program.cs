using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using XManMediator.Abstractions;
using XManMediator.App.MediatorModels;
using XManMediator.App.XManModels;
using XManMediator.Extensions;
using XManMediator.Models.Enums;


//Build in release mode: dotnet build -c Release XManMediator.App.csproj
//Run dll built in Release mode: dotnet run bin/Release/net8.0/XManMediator.App.dll
[MemoryDiagnoser]
public class BenchmarkTests
{
    private IServiceCollection _services;
    private IServiceProvider _serviceProvider;
    private IMediator _mediator;
    private IXManMediator _xManMediator;
    [GlobalSetup]
    public void Setup()
    {
        // This setup method is run once per benchmark run
        _services = new ServiceCollection();
        _services.AddXManMediator(config =>
        {
            config.RegisterFromAssemblyContaining<Program>();
        },Strategy.Singleton);

        _services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblyContaining<Program>();
            config.Lifetime = ServiceLifetime.Singleton;
        });

        _serviceProvider = _services.BuildServiceProvider();
        _xManMediator = _serviceProvider.GetRequiredService<IXManMediator>();
        _mediator = _serviceProvider.GetRequiredService<IMediator>();
    }

    [Benchmark]
    public async Task XManMediator()
    {
        XManResponse response = await _xManMediator.SendAsync(new XManRequest());
    }

    [Benchmark]
    public async Task Mediator()
    {
        MediatorResponse response = await _mediator.Send(new MediatorRequest());
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<BenchmarkTests>();
    }
}