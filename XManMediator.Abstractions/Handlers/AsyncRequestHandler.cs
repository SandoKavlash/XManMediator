using XManMediator.Abstractions.Extensions;
using XManMediator.Abstractions.Requests;
using XManMediator.Abstractions.Requests.Base;

namespace XManMediator.Abstractions.Handlers
{
    public abstract class AsyncRequestHandler
    {
        public abstract object InternalHandleHelperAsync(IBaseRequest request);

        public abstract int GetAsyncHandlerIdentifier();
    }
    public abstract class AsyncRequestHandler<TRequest, TResponse> : AsyncRequestHandler
        where TRequest : AsyncRequest<TRequest,TResponse>
        where TResponse : class
    {
        public sealed override int GetAsyncHandlerIdentifier() => AsyncRequestIdentifier<TRequest, TResponse>.Id;
        public sealed override object InternalHandleHelperAsync(IBaseRequest request) => this.HandleAsync((TRequest) request);
        public abstract Task<TResponse> HandleAsync(TRequest request);
    }
}
