using XManMediator.Abstractions;
using XManMediator.Abstractions.Requests.Base;
using XManMediator.Models.Configs;

namespace XManMediator.Implementations
{
    internal class XManMediatorScopedStrategy : IXManMediator
    {
        private readonly XManMediatorScopedConfig _config;
        public XManMediatorScopedStrategy(XManMediatorScopedConfig config)
        {
            _config = config;
        }
        public TResponse Send<TResponse>(IRequest<TResponse> request)
        {
            throw new NotImplementedException();
        }

        public Task<TResponse> SendAsync<TResponse>(IAsyncRequest<TResponse> request)
        {
            throw new NotImplementedException();
        }
    }
}
