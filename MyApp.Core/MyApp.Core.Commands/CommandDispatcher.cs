using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyApp.Core.Commands
{
    /// <inheritdoc />
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Dispatch<TCommand>(TCommand command, CancellationToken cancellationToken = default(CancellationToken)) where TCommand : class, ICommand
        {
            var handlerType = typeof(ICommandHandler<>).MakeGenericType(typeof(TCommand));
            var handler = (ICommandHandler<TCommand>)_serviceProvider.GetService(handlerType);

            await handler.Handle(command, cancellationToken);
        }
    }
}