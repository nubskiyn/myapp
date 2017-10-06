using System.Threading;
using System.Threading.Tasks;

namespace MyApp.Core.Queries
{
    /// <summary>
    /// Обработчик запросов
    /// </summary>
    /// <typeparam name="TQuery"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public interface IQueryHandler<in TQuery, TResult> where TQuery : class, IQuery<TResult>
    {
        /// <summary>
        /// Асинхронно обрабатывает запрос
        /// </summary>
        /// <param name="query">Запрос</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Результат запроса</returns>
        Task<TResult> Handle(TQuery query, CancellationToken cancellationToken = default(CancellationToken));
    }
}