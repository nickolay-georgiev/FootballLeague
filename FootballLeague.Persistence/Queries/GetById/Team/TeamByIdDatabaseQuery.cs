using FootballLeague.Persistence.Result.GetById.Team;

namespace FootballLeague.Persistence.Queries.GetById.Team
{
    public class TeamByIdDatabaseQuery : EntityByIdQuery<TeamByIdDatabaseResult>
    {
        public TeamByIdDatabaseQuery(int id)
            : base(id)
        {
        }
    }
}
