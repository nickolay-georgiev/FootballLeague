using FootballLeague.Abstraction.CQS.Result;
using FootballLeague.Data.Models.Team;

namespace FootballLeague.Persistence.Result.Team.GetByName
{
    public class TeamByNameResult : IResult
    {
        public TeamByNameResult()
        {
            Succeed = false;
        }

        public TeamByNameResult(SportTeam sportTeam)
        {
            Succeed = true;
            SportTeam = sportTeam;
        }

        public bool Succeed { get; }

        public SportTeam SportTeam { get; }
    }
}
