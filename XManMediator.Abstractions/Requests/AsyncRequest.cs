using XManMediator.Abstractions.Extensions;
using XManMediator.Abstractions.Requests.Base;

namespace XManMediator.Abstractions.Requests
{
    public abstract class AsyncRequest<TRequest, TResponse> : IAsyncRequest<TResponse>
        where TRequest : AsyncRequest<TRequest, TResponse>
        where TResponse : class
    {
        public int XManRequestId => AsyncRequestIdentifier<TRequest, TResponse>.Id;
    }
}
