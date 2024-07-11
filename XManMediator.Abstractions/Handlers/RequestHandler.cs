using XManMediator.Abstractions.Extensions;
using XManMediator.Abstractions.Requests;
using XManMediator.Abstractions.Requests.Base;

namespace XManMediator.Abstractions.Handlers
{
    public abstract class RequestHandler
    {
        internal abstract object InternalHandleHelper(IBaseRequest request);
        internal abstract int GetHandlerIdentifier();
    }
    public abstract class RequestHandler<TRequest,TResponse> : RequestHandler
        where TRequest : Request<TRequest, TResponse>
        where TResponse : class
    {
        internal override int GetHandlerIdentifier() => RequestIdentifier<TRequest, TResponse>.Id;
        internal override object InternalHandleHelper(IBaseRequest request) => this.Handle((TRequest)request);
        public abstract TResponse Handle(TRequest request);
    }
}
