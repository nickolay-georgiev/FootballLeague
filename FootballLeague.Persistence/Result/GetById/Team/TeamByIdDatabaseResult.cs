using FootballLeague.Data.Models.Team;
using FootballLeague.Persistence.Queries.GetById;

namespace FootballLeague.Persistence.Result.GetById.Team
{
    public class TeamByIdDatabaseResult : EntityByIdResult<SportTeam>
    {
        public TeamByIdDatabaseResult() { }

        public TeamByIdDatabaseResult(SportTeam entity)
            : base(entity)
        {
        }
    }
}
