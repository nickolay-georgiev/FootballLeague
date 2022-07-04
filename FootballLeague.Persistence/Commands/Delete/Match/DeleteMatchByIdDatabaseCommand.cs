using FootballLeague.Data.Models.Match;
using FootballLeague.Persistence.Common.Commands.Delete;

namespace FootballLeague.Persistence.Commands.Delete.Match
{
    public class DeleteMatchByIdDatabaseCommand : DeleteEntityByIdDatabaseCommand<SportMatch>
    {
        public DeleteMatchByIdDatabaseCommand(SportMatch entity) 
            : base(entity)
        {
        }
    }
}
