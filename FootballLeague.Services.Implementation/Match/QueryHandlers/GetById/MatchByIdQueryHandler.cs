using FootballLeague.Abstraction.CQS.Query;
using FootballLeague.Abstraction.Validators;
using FootballLeague.Data.Models.Match;
using FootballLeague.Persistence.Queries.GetById;
using FootballLeague.Persistence.Queries.GetById.Match;
using FootballLeague.Services.Implementation.Common.GetById;
using FootballLeague.Services.Implementation.Match.Queries.GetById;
using System;
using System.Threading.Tasks;

namespace FootballLeague.Services.Implementation.Match.QueryHandlers.GetById
{
    public sealed class MatchByIdQueryHandler : IAsyncQueryHandler<MatchByIdQuery, EntityByIdResult<SportMatch>>
    {
        private const string TEAM_BY_ID_ERROR_MESSAGE = "Unexpected error, please try again and if this error still occurs, contatct the support team.";

        private readonly IValidator<int> matchIdValidator;
        private readonly IAsyncQueryHandler<EntityByIdDatabaseQuery<EntityByIdDatabaseResult<SportMatch>>, EntityByIdDatabaseResult<SportMatch>> matchHandler;

        public MatchByIdQueryHandler(IValidator<int> matchIdValidator, IAsyncQueryHandler<EntityByIdDatabaseQuery<EntityByIdDatabaseResult<SportMatch>>, EntityByIdDatabaseResult<SportMatch>> matchHandler)
        {
            this.matchIdValidator = matchIdValidator;
            this.matchHandler = matchHandler;
        }

        public async Task<EntityByIdResult<SportMatch>> Handle(MatchByIdQuery query)
        {
            var validationResult = this.matchIdValidator.Validate(query.InputModel.Id);
            if (!validationResult.Succeed) return new EntityByIdResult<SportMatch>(validationResult.Message);

            var result = await this.matchHandler.Handle(new MatchByIdDatabaseQuery(query.InputModel.Id));
            if (!result.Succeed) return new EntityByIdResult<SportMatch>("Match doesn not exist");

            return new EntityByIdResult<SportMatch>(result.Entity);
        }
    }
}
