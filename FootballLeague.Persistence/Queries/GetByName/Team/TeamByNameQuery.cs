using FootballLeague.Abstraction.CQS.Query;
using FootballLeague.Persistence.Result.Team.GetByName;

namespace FootballLeague.Persistence.Queries.GetByName.Team
{
    public class TeamByNameQuery : IQuery<TeamByNameResult>
    {
        public TeamByNameQuery(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
