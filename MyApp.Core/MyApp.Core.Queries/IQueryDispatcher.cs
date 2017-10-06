using System.Threading;
using System.Threading.Tasks;

namespace MyApp.Core.Queries
{
    /// <summary>
    /// Диспетчер запросов
    /// </summary>
    public interface IQueryDispatcher
    {
        /// <summary>
        /// Находит асинхронный обработчик запроса и обрабатывает его (запрос)
        /// </summary>
        /// <typeparam name="TQuery">Тип запроса</typeparam>
        /// <typeparam name="TResult">Тип результата</typeparam>
        /// <param name="query">Запрос</param>
        /// <param name="cancellationToken"></param>
        Task<TResult> Dispatch<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default(CancellationToken)) where TQuery : class, IQuery<TResult>;
    }
}