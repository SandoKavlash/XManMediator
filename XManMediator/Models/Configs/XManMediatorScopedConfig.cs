using Microsoft.Extensions.DependencyInjection;
using XManMediator.Models.Configs.Base;

namespace XManMediator.Models.Configs
{
    public class XManMediatorScopedConfig : IBaseConfig
    {
        private readonly IServiceCollection _services;
        public XManMediatorScopedConfig(IServiceCollection services)
        {
            _services = services;
        }
        public IBaseConfig RegisterFromAssemblyContaining<T>()
        {
            throw new NotImplementedException();
            return this;
        }
    }
}
