using FootballLeague.Data.Models.Match;

namespace FootballLeague.Persistence.Queries.GetById.Match
{
    public class MatchByIdDatabaseQuery : EntityByIdDatabaseQuery<EntityByIdDatabaseResult<SportMatch>>
    {
        public MatchByIdDatabaseQuery(int id) 
            : base(id)
        {
        }
    }
}
