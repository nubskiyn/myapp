using MyApp.Core.Queries;
using MyApp.Core.Queries.Ado;

namespace MyApp.Movies.Queries.Ado
{
    public abstract class BaseQueryHandler<TQuery, TResult> : AdoQueryHandler<TQuery, TResult> where TQuery: class, IQuery<TResult>
    {
        protected BaseQueryHandler() : base("MyApp.Movies")
        {
        }
    }
}