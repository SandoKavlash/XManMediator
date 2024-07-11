using Microsoft.Extensions.DependencyInjection;
using XManMediator.Abstractions;
using XManMediator.Abstractions.Extensions;
using XManMediator.Abstractions.Handlers;
using XManMediator.Abstractions.Requests.Base;
using XManMediator.Models.Configs;

namespace XManMediator.Implementations
{
    internal class XManMediatorSingletonStrategy : IXManMediator
    {
        private readonly XManMediatorSingletonConfig _config;
        private readonly object _handlersLock;
        private readonly RequestHandler[] _handlers;
        private readonly IServiceProvider _serviceProvider;

        private readonly object _asyncHandlersLock;
        private readonly AsyncRequestHandler[] _asyncHandlers;
        public XManMediatorSingletonStrategy(XManMediatorSingletonConfig config)
        {
            _serviceProvider = config.services.BuildServiceProvider();
            _handlersLock = new object();
            _asyncHandlersLock = new object();
            _asyncHandlers = new AsyncRequestHandler[TypeExtensions.AsyncHandlersCount];
            _handlers = new RequestHandler[TypeExtensions.HandlersCount];
            _config = config;
        }
        public TResponse Send<TResponse>(IRequest<TResponse> request)
        {
            if (_handlers.Length <= request.XManRequestId) throw new ArgumentException("This request type is not registered in specified assembly");
            if (_handlers[request.XManRequestId] == null)
            {
                lock(_handlersLock)
                {
                    if (_handlers[request.XManRequestId] == null)
                    {
                        _handlers[request.XManRequestId] = (RequestHandler)_serviceProvider.GetRequiredKeyedService(_config.handlerType, request.XManRequestId);
                    }
                }
            }
            return (TResponse)_handlers[request.XManRequestId].InternalHandleHelper(request);
        }

        public Task<TResponse> SendAsync<TResponse>(IAsyncRequest<TResponse> request)
        {
            if (_asyncHandlers.Length <= request.XManRequestId) throw new ArgumentException("This request type is not registered in specified assembly");
            if (_asyncHandlers[request.XManRequestId] == null)
            {
                lock (_asyncHandlersLock)
                {
                    if (_asyncHandlers[request.XManRequestId] == null)
                    {
                        _asyncHandlers[request.XManRequestId] = (AsyncRequestHandler)_serviceProvider.GetRequiredKeyedService(_config.asyncHandlerType, request.XManRequestId);
                    }
                }
            }
            return (Task<TResponse>)_asyncHandlers[request.XManRequestId].InternalHandleHelperAsync(request);
        }
    }
}
