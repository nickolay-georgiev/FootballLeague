using FootballLeague.Abstraction.CQS.Query;
using FootballLeague.Persistence.Result.Team.GetByName;

namespace FootballLeague.Persistence.Queries.GetByName.Team
{
    public class TeamByNameDatabaseQuery : IQuery<TeamByNameDatabaseResult>
    {
        public TeamByNameDatabaseQuery(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
