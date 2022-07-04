using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Data.Models.Enums;
using FootballLeague.Data.Models.Team;

namespace FootballLeague.Persistence.Commands.Update
{
    public class UpdateSportTeamDatabaseCommand : ICommand
    {
        public UpdateSportTeamDatabaseCommand(SportTeam sportTeam, MatchScore matchScore)
        {
            SportTeam = sportTeam;
            MatchScore = matchScore;
        }

        public SportTeam SportTeam { get; }

        public MatchScore MatchScore { get; }
    }
}
