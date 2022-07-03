using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Data.Models.Team;

namespace FootballLeague.Persistence.Commands.Update
{
    public class UpdateSeasonTotalScoreDatabaseCommand : ICommand
    {
        public UpdateSeasonTotalScoreDatabaseCommand(SportTeam sportTeam)
        {
            SportTeam = sportTeam;
        }

        public SportTeam SportTeam { get; }
    }
}
