using System.Threading;
using System.Threading.Tasks;

namespace MyApp.Core.Commands
{
    /// <summary>
    /// Обработчик команд
    /// </summary>
    /// <typeparam name="TCommand">Тип команды</typeparam>
    public interface ICommandHandler<in TCommand> where TCommand : class, ICommand
    {
        /// <summary>
        /// Асинхронно обрабатывает команду
        /// </summary>
        /// <param name="command">Команда</param>
        /// <param name="cancellationToken"></param>
        Task Handle(TCommand command, CancellationToken cancellationToken = default(CancellationToken));
    }
}