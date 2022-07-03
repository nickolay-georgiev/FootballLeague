using FootballLeague.Abstraction.CQS.Result;
using FootballLeague.Data.Models.Team;

namespace FootballLeague.Persistence.Result.Team.GetByName
{
    public class TeamByNameDatabaseResult : IResult
    {
        public TeamByNameDatabaseResult()
        {
            Succeed = false;
        }

        public TeamByNameDatabaseResult(SportTeam sportTeam)
        {
            Succeed = true;
            SportTeam = sportTeam;
        }

        public bool Succeed { get; }

        public SportTeam SportTeam { get; }
    }
}
