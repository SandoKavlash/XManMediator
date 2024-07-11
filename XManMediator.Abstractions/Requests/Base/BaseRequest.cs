namespace XManMediator.Abstractions.Requests.Base
{
    public interface IBaseRequest
    {
        int XManRequestId { get; }

    }
    public interface IAsyncRequest<TResponse> : IBaseRequest { }
    public interface IRequest<TResponse> : IBaseRequest { }
}
