using System.Reflection;
using XManMediator.Abstractions.Handlers;

namespace XManMediator.Abstractions.Extensions
{
    public static class TypeExtensions
    {
        private static Type genericHandlerDefinition = typeof(RequestHandler<,>);
        private static Type genericRequestIdentifierDefinition = typeof(RequestIdentifier<,>);

        private static Type genericAsyncHandlerDefinition = typeof(AsyncRequestHandler<,>);
        private static Type genericAsyncRequestIdentifierDefinition = typeof(AsyncRequestIdentifier<,>);
        public static int GetHandlerIdentifier(this Type requestHandlerType)
        {
            Type baseHandler = requestHandlerType.GetBaseHandlerType(genericHandlerDefinition);
            if (baseHandler == null) throw new ArgumentException($"handler: {requestHandlerType} is not AsyncRequestHandler<TRequest,TResponse>");
            Type[] genericArguments = baseHandler.GetGenericArguments();
            Type requestIdentifier = genericRequestIdentifierDefinition.MakeGenericType(genericArguments);
            FieldInfo idFieldInfo = requestIdentifier.GetField("Id", BindingFlags.Static | BindingFlags.NonPublic);

            return (int)idFieldInfo.GetValue(null);
        }

        public static int GetAsyncHandlerIdentifier(this Type asyncRequestHandlerType)
        {
            Type baseHandler = asyncRequestHandlerType.GetBaseHandlerType(genericAsyncHandlerDefinition);
            if (baseHandler == null) throw new ArgumentException($"handler: {asyncRequestHandlerType} is not RequestHandler<TRequest,TResponse>");
            Type[] genericArguments = baseHandler.GetGenericArguments();
            Type requestIdentifier = genericAsyncRequestIdentifierDefinition.MakeGenericType(genericArguments);
            FieldInfo idFieldInfo = requestIdentifier.GetField("Id", BindingFlags.Static | BindingFlags.NonPublic);

            return (int)idFieldInfo.GetValue(null);
        }
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

        private static Type GetBaseHandlerType(this Type childType, Type genericParentType)
        {
            Type type = childType;
            while (type != null && type != typeof(object))
            {
                if (type.IsGenericType && type.GetGenericTypeDefinition() == genericParentType)
                {
                    return type;
                }
                type = type.BaseType;
            }
            return null;
        }
    }
}
