using FootballLeague.Data.Models.Match;

namespace FootballLeague.Persistence.Commands.Add.Match
{
    public class AddSportMatchToDatabaseCommand : AddEntityToDBCommand<SportMatch>
    {
        public AddSportMatchToDatabaseCommand(SportMatch entity) 
            : base(entity)
        {
        }
    }
}
