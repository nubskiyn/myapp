using System.Threading;
using System.Threading.Tasks;

namespace MyApp.Core.Commands
{
    /// <summary>
    /// Диспетчер команд
    /// </summary>
    public interface ICommandDispatcher
    {
        /// <summary>
        /// Находит асинхронный обработчик команды и обрабатывает её
        /// </summary>
        /// <typeparam name="TCommand">Тип команды</typeparam>
        /// <param name="command">Команда</param>
        /// <param name="cancellationToken"></param>
        Task Dispatch<TCommand>(TCommand command, CancellationToken cancellationToken = default(CancellationToken)) where TCommand : class, ICommand;
    }
}