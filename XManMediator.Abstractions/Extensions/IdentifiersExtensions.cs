using XManMediator.Abstractions.Requests;

namespace XManMediator.Abstractions.Extensions
{
    internal static class RequestIdentifier
    {
        internal static int counter = 0;
        internal static object counterLock = new object();
    }
    internal static class RequestIdentifier<TRequest, TResponse>
        where TRequest : Request<TRequest, TResponse>
        where TResponse : class
    {
        internal static int Id;
        static RequestIdentifier()
        {
            lock (RequestIdentifier.counterLock)
            {
                Id = RequestIdentifier.counter;
                RequestIdentifier.counter++;
            }
        }
    }

    internal static class AsyncRequestIdentifier
    {
        internal static int counter = 0;
        internal static object counterLock = new object();
    }

    internal static class AsyncRequestIdentifier<TRequest, TResponse>
        where TRequest : AsyncRequest<TRequest, TResponse>
        where TResponse : class
    {
        internal static int Id;
        static AsyncRequestIdentifier()
        {
            lock (AsyncRequestIdentifier.counterLock)
            {
                Id = AsyncRequestIdentifier.counter;
                AsyncRequestIdentifier.counter++;
            }
        }
    }

    public static class IdentfiersExtensions
    {
        public static int AsyncHandlersCount
        {
            get
            {
                return AsyncRequestIdentifier.counter;
            }
        }
        public static int HandlersCount
        {
            get
            {
                return RequestIdentifier.counter;
            }
        }
    }
}
