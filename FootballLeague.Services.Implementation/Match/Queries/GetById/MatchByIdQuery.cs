using FootballLeague.Abstraction.CQS.Query;
using FootballLeague.Data.Models.Match;
using FootballLeague.Services.Implementation.Common.GetById;
using FootballLeague.Web.Models.Match.GetById;

namespace FootballLeague.Services.Implementation.Match.Queries.GetById
{
    public class MatchByIdQuery : IQuery<EntityByIdResult<SportMatch>>
    {
        public MatchByIdQuery(MatchByIdInputModel inputModel)
        {
            InputModel = inputModel;
        }

        public MatchByIdInputModel InputModel { get; }
    }
}
