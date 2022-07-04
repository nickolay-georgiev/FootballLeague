using FootballLeague.Abstraction.CQS.Query;
using FootballLeague.Data.Models.Team;
using FootballLeague.Services.Implementation.Common.GetById;
using FootballLeague.Web.Models.Team.GetById;

namespace FootballLeague.Services.Implementation.Team.Queries.GetById.Team
{
    public class TeamByIdQuery : IQuery<EntityByIdResult<SportTeam>>
    {
        public TeamByIdQuery(TeamByIdInputModel inputModel)
        {
            InputModel = inputModel;
        }

        public TeamByIdInputModel InputModel { get; }    
    }
}
