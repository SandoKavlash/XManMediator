using Microsoft.Extensions.Hosting;
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
    })
    .Build()
    .Run();