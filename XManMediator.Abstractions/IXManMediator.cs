using XManMediator.Abstractions.Requests;
using XManMediator.Abstractions.Requests.Base;

namespace XManMediator.Abstractions
{
    public interface IXManMediator
    {
        TResponse Send<TResponse>(IRequest<TResponse> request);
        Task<TResponse> SendAsync<TResponse>(IAsyncRequest<TResponse> request);
    }
}
