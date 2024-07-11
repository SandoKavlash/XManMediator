using XManMediator.Abstractions;
using XManMediator.Abstractions.Requests.Base;
using XManMediator.Models.Configs;

namespace XManMediator.Implementations
{
    internal class XManMediatorSingletonStrategy : IXManMediator
    {
        private readonly XManMediatorSingletonConfig _config;
        public XManMediatorSingletonStrategy(XManMediatorSingletonConfig config)
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
