using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using XManMediator.Abstractions.Handlers;
using XManMediator.Models.Configs.Base;

namespace XManMediator.Models.Configs
{
    public class XManMediatorSingletonConfig : IBaseConfig
    {
        private readonly IServiceCollection _services;
        private readonly Type _handlerType;
        private readonly Type _asyncHandlerType;
        public XManMediatorSingletonConfig(IServiceCollection services)
        {
            _asyncHandlerType = typeof(AsyncRequestHandler);
            _handlerType = typeof(RequestHandler);
            _services = services;
        }
        public IBaseConfig RegisterFromAssemblyContaining<T>()
        {
            Assembly assembly = typeof(T).Assembly;
            IEnumerable<Type> allTypes = assembly
                .GetTypes();

            IEnumerable<Type> handlers = allTypes.Where(t => t.IsSubclassOf(_handlerType));
            
            IEnumerable<Type> asyncHandlers = allTypes.Where(t => t.IsSubclassOf(_asyncHandlerType));
            
            foreach(var item in handlers)
            {
                Console.WriteLine(item.FullName);
            }
            foreach (var item in asyncHandlers)
            {
                Console.WriteLine(item.FullName);
            }

            return this;
        }
    }
}
