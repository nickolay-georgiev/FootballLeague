using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Abstraction.CQS.Query;
using FootballLeague.Abstraction.Validators;
using FootballLeague.Data.Models.Match;
using FootballLeague.Persistence.Queries.GetById;
using FootballLeague.Persistence.Queries.GetById.Match;
using FootballLeague.Services.Implementation.Common.Results.Update;
using FootballLeague.Services.Implementation.Match.Commands;
using System.Threading.Tasks;

namespace FootballLeague.Services.Implementation.Match.CommandHandlers.Update
{
    public sealed class UpdateMatchOnGameEndCommandHandler : ICommandHandlerAsync<UpdateMatchOnGameEndCommand, UpdateEntityResult>
    {
        private readonly IValidator<int> teamIdValidator;
        private readonly IAsyncQueryHandler<EntityByIdDatabaseQuery<EntityByIdDatabaseResult<SportMatch>>, EntityByIdDatabaseResult<SportMatch>> teamByIdHandler;

        public async Task<UpdateEntityResult> Handle(UpdateMatchOnGameEndCommand command)
        {
            var validationResult = this.teamIdValidator.Validate(command.InputModel.Id);
            if (!validationResult.Succeed) return new UpdateEntityResult(validationResult.Message);

            var getMatchResult = await this.teamByIdHandler.Handle(new MatchByIdDatabaseQuery(command.InputModel.Id));
            if (!getMatchResult.Succeed) return new UpdateEntityResult(getMatchResult.Message);

            return new UpdateEntityResult();
        }
    }
}
