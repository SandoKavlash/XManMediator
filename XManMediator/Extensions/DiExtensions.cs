using Microsoft.Extensions.DependencyInjection;
using XManMediator.Abstractions;
using XManMediator.Implementations;
using XManMediator.Models.Configs;
using XManMediator.Models.Configs.Base;
using XManMediator.Models.Enums;

namespace XManMediator.Extensions
{
    public static class DiExtensions
    {
        private static IServiceCollection HandleSingleton(IServiceCollection services, Action<XManMediatorSingletonConfig> configAction)
        {
            services.AddSingleton<IXManMediator, XManMediatorSingletonStrategy>();
            XManMediatorSingletonConfig config = new XManMediatorSingletonConfig(services);
            configAction(config);
            services.AddSingleton<XManMediatorSingletonConfig>(config);
            return services;
        }

        private static IServiceCollection HandleScoped(IServiceCollection services, Action<XManMediatorScopedConfig> configAction)
        {
            return services;
        }

        public static IServiceCollection AddXManMediator(
            this IServiceCollection services, 
            Action<IBaseConfig> configAction, 
            Strategy strategy)
        {
            switch (strategy)
            {
                case Strategy.Scoped:
                    return HandleScoped(services, configAction);
                case Strategy.Singleton:
                    return HandleSingleton(services, configAction);
                default:
                    throw new ArgumentException($"Not implemented strategy {strategy}");
            }
        }
    }
}
