using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Data.Models.Team;

namespace FootballLeague.Persistence.Commands.Delete.Team
{
    public class DeleteTeamDatabaseCommand : ICommand
    {
        public DeleteTeamDatabaseCommand(SportTeam sportTeam)
        {
            SportTeam = sportTeam;
        }

        public SportTeam SportTeam { get; }
    }
}
