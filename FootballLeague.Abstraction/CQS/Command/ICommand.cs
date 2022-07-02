using System.Threading.Tasks;

namespace FootballLeague.Abstraction.CQS.Command
{
    public interface ICommand
    {
    }

    public interface ICommandHandler<TCommand, TResult> where TCommand : ICommand
    {
        TResult Handle(TCommand command);
    }

    public interface ICommandHandlerAsync<TCommand, TResult> where TCommand : ICommand
    {
        Task<TResult> Handle(TCommand command);
    }
}
