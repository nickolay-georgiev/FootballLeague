using FootballLeague.Data.Models.Team;

namespace FootballLeague.Persistence.Commands.Add.Team
{
    public class AddSportTeamToDatabaseCommand : AddEntityToDBCommand<SportTeam>
    {
        public AddSportTeamToDatabaseCommand(SportTeam entity)
            : base(entity)
        {
        }
    }
}
