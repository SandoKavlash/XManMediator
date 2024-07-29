using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using XManMediator.App.HostedServices;
using XManMediator.App.JustTestServices.Abstractions;
using XManMediator.App.JustTestServices.Implementations;
using XManMediator.Extensions;
using XManMediator.Models.Enums;

//TODO: capture scope of the mediator. CaptureScope method in case of Scoped strategy
//TODO: pipeline behiaviours

Host
    .CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddXManMediator(config =>
        {
            config.RegisterFromAssemblyContaining<Program>();
        }, Strategy.Scoped);

        services.AddScoped<ITestService,TestService>();
        services.AddHostedService<TestHostedService>();
    })
    .Build()
    .Run();