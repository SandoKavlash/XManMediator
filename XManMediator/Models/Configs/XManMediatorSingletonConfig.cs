using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using XManMediator.Abstractions.Handlers;
using XManMediator.Models.Configs.Base;
using XManMediator.Abstractions.Extensions;

namespace XManMediator.Models.Configs
{
    public class XManMediatorSingletonConfig : IBaseConfig
    {
        internal readonly IServiceCollection services;
        internal readonly Type handlerType;
        internal readonly Type asyncHandlerType;
        public XManMediatorSingletonConfig(IServiceCollection services)
        {
            asyncHandlerType = typeof(AsyncRequestHandler);
            handlerType = typeof(RequestHandler);
            this.services = services;
        }
        public IBaseConfig RegisterFromAssemblyContaining<T>()
        {
            Assembly assembly = typeof(T).Assembly;
            IEnumerable<Type> allTypes = assembly
                .GetTypes();

            IEnumerable<IdentifierTypeKV> handlers = allTypes
                .Where(t => t.IsSubclassOf(handlerType))
                .Select(type => new IdentifierTypeKV() { Identifier = type.GetHandlerIdentifier(), handler = type});
            
            IEnumerable<IdentifierTypeKV> asyncHandlers = allTypes
                .Where(t => t.IsSubclassOf(asyncHandlerType))
                .Select(type => new IdentifierTypeKV() { Identifier = type.GetAsyncHandlerIdentifier(), handler = type});

            foreach(var kvPair in handlers)
            {
                services.AddKeyedSingleton(handlerType, kvPair.Identifier, kvPair.handler);
            }

            foreach(var kvPair in asyncHandlers)
            {
                services.AddKeyedSingleton(asyncHandlerType, kvPair.Identifier, kvPair.handler);
            }



            return this;
        }


    }
}
