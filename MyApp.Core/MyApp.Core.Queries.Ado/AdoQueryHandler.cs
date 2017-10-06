using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using MyApp.Data;

namespace MyApp.Core.Queries.Ado
{
    /// <summary>
    /// Базовый обработчик запросов (ADO.NET)
    /// </summary>
    /// <typeparam name="TQuery">Тип запроса</typeparam>
    /// <typeparam name="TResult">Тип результата</typeparam>
    public abstract class AdoQueryHandler<TQuery, TResult> : IDisposable, IQueryHandler<TQuery, TResult> where TQuery : class, IQuery<TResult>
    {
        private IDbConnection _connection;

        /// <summary>
        /// Соединение с БД
        /// </summary>
        protected IDbConnection Connection => _connection ?? DbConnectionFactory.GetConnection(ConnectionString);

        /// <summary>
        /// Строка подключения
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="connectionString">Строка подключения к БД</param>
        protected AdoQueryHandler(string connectionString)
        {
            ConnectionString = connectionString;
        }

        /// <summary>
        /// Обрабатывает запрос
        /// </summary>
        /// <param name="query">Запрос</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Результат запроса</returns>
        public abstract Task<TResult> Handle(TQuery query, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Освобождает неуправляемые ресурсы
        /// </summary>
        public void Dispose()
        {
            _connection?.Dispose();
            _connection = null;
        }
    }
}
