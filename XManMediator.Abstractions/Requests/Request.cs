using XManMediator.Abstractions.Extensions;
using XManMediator.Abstractions.Requests.Base;

namespace XManMediator.Abstractions.Requests
{
    public abstract class Request<TRequest, TResponse> : IRequest<TResponse>
        where TRequest : Request<TRequest, TResponse>
        where TResponse : class
    {
        public int XManRequestId => RequestIdentifier<TRequest, TResponse>.Id;
    }
}
