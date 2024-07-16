using Microsoft.Extensions.DependencyInjection;
using XManMediator.Abstractions;
using XManMediator.Abstractions.Extensions;
using XManMediator.Abstractions.Handlers;
using XManMediator.Abstractions.Requests.Base;
using XManMediator.Models.Configs;

namespace XManMediator.Implementations
{
    internal class XManMediatorScopedStrategy : IXManMediator
    {
        private readonly XManMediatorScopedConfig _config;
        private readonly IServiceProvider _serviceProvider;

        public XManMediatorScopedStrategy(XManMediatorScopedConfig config)
        {
            _config = config;
            _serviceProvider = config.services.BuildServiceProvider();
        }
        public TResponse Send<TResponse>(IRequest<TResponse> request)
        {
            if (IdentfiersExtensions.HandlersCount <= request.XManRequestId) throw new ArgumentException("Handler for this request not found in specified assembly/assemblies");
            using(IServiceScope scoped = _serviceProvider.CreateScope())
            {
                IServiceProvider provider = scoped.ServiceProvider;
                RequestHandler handler = (RequestHandler)provider.GetRequiredKeyedService(_config.handlerType, request.XManRequestId);
                return (TResponse)handler.InternalHandleHelper(request);
            }
        }

        public Task<TResponse> SendAsync<TResponse>(IAsyncRequest<TResponse> request)
        {
            if (IdentfiersExtensions.AsyncHandlersCount <= request.XManRequestId) throw new ArgumentException("Async handler for this request not found in specified assembly/assemblies");
            using (IServiceScope scoped = _serviceProvider.CreateScope())
            {
                IServiceProvider provider = scoped.ServiceProvider;
                AsyncRequestHandler asyncHandler = (AsyncRequestHandler)provider.GetRequiredKeyedService(_config.asyncHandlerType, request.XManRequestId);
                return (Task<TResponse>)asyncHandler.InternalHandleHelperAsync(request);
            }
        }
    }
}
