using FootballLeague.Abstraction.CQS.Command;

namespace FootballLeague.Persistence.Common.Commands.Delete
{
    public class DeleteEntityByIdDatabaseCommand<TEntity> : ICommand
    {
        public DeleteEntityByIdDatabaseCommand(TEntity entity)
        {
            Entity = entity;
        }

        public TEntity Entity { get; }
    }
}
