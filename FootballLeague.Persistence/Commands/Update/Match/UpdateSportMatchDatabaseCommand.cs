using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Data.Models.Match;

namespace FootballLeague.Persistence.Commands.Update.Match
{
    public class UpdateSportMatchDatabaseCommand : ICommand
    {
        public UpdateSportMatchDatabaseCommand(SportMatch sportMatch)
        {
            SportMatch = sportMatch;
        }

        public SportMatch SportMatch { get; }
    }
}
