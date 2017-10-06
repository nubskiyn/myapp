using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyApp.Core.Queries
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResult> Dispatch<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default(CancellationToken)) where TQuery : class, IQuery<TResult>
        {
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(typeof(TQuery), typeof(TResult));
            var handler = (IQueryHandler<TQuery, TResult>)_serviceProvider.GetService(handlerType);

            return await handler.Handle(query, cancellationToken);
        }
    }
}
