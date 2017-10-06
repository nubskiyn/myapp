using MyApp.Core.Commands;
using MyApp.Core.Commands.Ado;

namespace MyApp.Movies.Commands.Ado
{
    public abstract class BaseCommandHandler<TCommand> : AdoCommandHandler<TCommand> where TCommand : class, ICommand
    {
        protected BaseCommandHandler() : base("MyApp.Movies")
        {
        }
    }
}