using FootballLeague.Data.Models.Team;
using FootballLeague.Persistence.Common.Commands.Delete;

namespace FootballLeague.Persistence.Commands.Delete.Team
{
    public class DeleteTeamDatabaseCommand : DeleteEntityByIdDatabaseCommand<SportTeam>
    {
        public DeleteTeamDatabaseCommand(SportTeam entity) 
            : base(entity)
        {
        }
    }
}
