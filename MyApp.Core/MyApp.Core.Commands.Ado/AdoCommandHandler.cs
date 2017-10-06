using System.Data;
using System.Threading;
using System.Threading.Tasks;
using MyApp.Data;

namespace MyApp.Core.Commands.Ado
{
    /// <summary>
    /// Базовый обработчик команд (ADO.NET)
    /// </summary>
    /// <typeparam name="TCommand">Тип команды</typeparam>
    public abstract class AdoCommandHandler<TCommand> : IDisposable, ICommandHandler<TCommand> where TCommand: class, ICommand
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
        /// <param name="connectionString">Строка подключения</param>
        protected AdoCommandHandler(string connectionString)
        {
            ConnectionString = connectionString;
        }

        /// <summary>
        /// Обрабатывает команду
        /// </summary>
        /// <param name="command">Команда</param>
        /// <param name="cancellationToken"></param>
        public abstract Task Handle(TCommand command, CancellationToken cancellationToken = default(CancellationToken));

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
