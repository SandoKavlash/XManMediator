using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using XManMediator.App.HostedServices;
using XManMediator.App.JustTestServices.Abstractions;
using XManMediator.App.JustTestServices.Implementations;
using XManMediator.Extensions;
using XManMediator.Models.Enums;

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