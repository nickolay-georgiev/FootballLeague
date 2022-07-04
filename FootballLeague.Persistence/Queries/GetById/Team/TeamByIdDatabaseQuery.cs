using FootballLeague.Data.Models.Team;

namespace FootballLeague.Persistence.Queries.GetById.Team
{
    public class TeamByIdDatabaseQuery : EntityByIdDatabaseQuery<EntityByIdDatabaseResult<SportTeam>>
    {
        public TeamByIdDatabaseQuery(int id)
            : base(id)
        {
        }
    }
}
