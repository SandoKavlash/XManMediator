using XManMediator.Abstractions.Extensions;
using XManMediator.Abstractions.Requests;
using XManMediator.Abstractions.Requests.Base;

namespace XManMediator.Abstractions.Handlers
{
    public abstract class RequestHandler
    {
        public abstract object InternalHandleHelper(IBaseRequest request);
        public abstract int GetHandlerIdentifier();
    }
    public abstract class RequestHandler<TRequest,TResponse> : RequestHandler
        where TRequest : Request<TRequest, TResponse>
        where TResponse : class
    {
        public sealed override int GetHandlerIdentifier() => RequestIdentifier<TRequest, TResponse>.Id;
        public sealed override object InternalHandleHelper(IBaseRequest request) => this.Handle((TRequest)request);
        public abstract TResponse Handle(TRequest request);
    }
}
