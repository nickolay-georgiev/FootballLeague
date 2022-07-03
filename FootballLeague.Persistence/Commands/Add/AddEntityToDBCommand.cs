using FootballLeague.Abstraction.CQS.Command;

namespace FootballLeague.Persistence.Commands.Add
{
    public class AddEntityToDBCommand<TEntity> : ICommand
    {
        public AddEntityToDBCommand(TEntity entity)
        {
            Entity = entity;
        }

        public TEntity Entity { get; }
    }
}
