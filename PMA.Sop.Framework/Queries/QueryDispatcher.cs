using System;

namespace PMA.Sop.Framework.Queries
{
    public sealed class QueryDispatcher
    {
        private readonly IServiceProvider _provider;

        public QueryDispatcher(IServiceProvider provider)
        {
            _provider = provider;
        }
        public T Dispatch<T>(IQuery query)
        {
            var type = typeof(IQueryHandler<,>);
            Type[] typeArgs = { query.GetType(), typeof(T) };
            var handlerType = type.MakeGenericType(typeArgs);
            dynamic handler = _provider.GetService(handlerType);
            T result = handler.Handle((dynamic)query);
            return result;
        }
    }
}