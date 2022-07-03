using FootballLeague.Abstraction.CQS.Query;
using FootballLeague.Services.Implementation.Team.Models.Result.GetByUd.Team;
using FootballLeague.Web.Models.Team.GetById;

namespace FootballLeague.Services.Implementation.Team.Queries.GetById.Team
{
    public class TeamByIdQuery : IQuery<TeamByIdResult>
    {
        public TeamByIdQuery(TeamByIdInputModel inputModel)
        {
            InputModel = inputModel;
        }

        public TeamByIdInputModel InputModel { get; }    
    }
}
