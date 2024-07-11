﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using XManMediator.App.HostedServices;
using XManMediator.Extensions;
using XManMediator.Models.Enums;

Host
    .CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddXManMediator(config =>
        {
            config.RegisterFromAssemblyContaining<Program>();
        }, Strategy.Singleton);

        services.AddHostedService<TestHostedService>();
    })
    .Build()
    .Run();