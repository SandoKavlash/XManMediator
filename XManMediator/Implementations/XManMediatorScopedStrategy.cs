using Microsoft.Extensions.DependencyInjection;
using XManMediator.Abstractions;
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
            using(IServiceScope scoped = _serviceProvider.CreateScope())
            {
                IServiceProvider provider = scoped.ServiceProvider;
                RequestHandler handler = (RequestHandler)provider.GetRequiredKeyedService(_config.handlerType, request.XManRequestId);
                return (TResponse)handler.InternalHandleHelper(request);
            }
        }

        public Task<TResponse> SendAsync<TResponse>(IAsyncRequest<TResponse> request)
        {
            using (IServiceScope scoped = _serviceProvider.CreateScope())
            {
                IServiceProvider provider = scoped.ServiceProvider;
                AsyncRequestHandler asyncHandler = (AsyncRequestHandler)provider.GetRequiredKeyedService(_config.asyncHandlerType, request.XManRequestId);
                return (Task<TResponse>)asyncHandler.InternalHandleHelperAsync(request);
            }
        }
    }
}
