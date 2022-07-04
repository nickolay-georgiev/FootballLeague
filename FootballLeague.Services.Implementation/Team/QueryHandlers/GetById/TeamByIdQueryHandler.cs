using FootballLeague.Abstraction.CQS.Query;
using FootballLeague.Abstraction.Validators;
using FootballLeague.Data.Models.Team;
using FootballLeague.Persistence.Queries.GetById;
using FootballLeague.Persistence.Queries.GetById.Team;
using FootballLeague.Persistence.Result.GetById.Team;
using FootballLeague.Services.Implementation.Common.GetById;
using FootballLeague.Services.Implementation.Team.Queries.GetById.Team;
using System.Threading.Tasks;

namespace FootballLeague.Services.Implementation.Team.QueryHandlers.GetById.Team
{
    public sealed class TeamByIdQueryHandler : IAsyncQueryHandler<TeamByIdQuery, EntityByIdResult<SportTeam>>
    {
        private const string TEAM_BY_ID_ERROR_MESSAGE = "Unexpected error, please try again and if this error still occurs, contatct the support team.";

        private readonly IValidator<int> teamIdValidator;
        private readonly IAsyncQueryHandler<EntityByIdDatabaseQuery<EntityByIdDatabaseResult<SportTeam>>, EntityByIdDatabaseResult<SportTeam>> teamByIdHandler;

        public TeamByIdQueryHandler(IValidator<int> teamIdValidator, IAsyncQueryHandler<EntityByIdDatabaseQuery<EntityByIdDatabaseResult<SportTeam>>, EntityByIdDatabaseResult<SportTeam>> teamByIdHandler)
        {
            this.teamIdValidator = teamIdValidator;
            this.teamByIdHandler = teamByIdHandler;
        }

        public async Task<EntityByIdResult<SportTeam>> Handle(TeamByIdQuery query)
        {
            var validationResult = this.teamIdValidator.Validate(query.InputModel.Id);
            if (!validationResult.Succeed) return new EntityByIdResult<SportTeam>(validationResult.Message);

            var result = await this.teamByIdHandler.Handle(new TeamByIdDatabaseQuery(query.InputModel.Id));
            if (!result.Succeed) return new EntityByIdResult<SportTeam>(TEAM_BY_ID_ERROR_MESSAGE);

            return new EntityByIdResult<SportTeam>(result.Entity);
        }
    }
}
