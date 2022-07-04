using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Abstraction.CQS.Query;
using FootballLeague.Abstraction.CQS.Result;
using FootballLeague.Abstraction.Validators;
using FootballLeague.Data.Models.Match;
using FootballLeague.Persistence.Commands.Delete.Match;
using FootballLeague.Persistence.Common.Commands.Delete;
using FootballLeague.Persistence.Queries.GetById;
using FootballLeague.Persistence.Queries.GetById.Match;
using FootballLeague.Services.Implementation.Common.Results.Delete;
using FootballLeague.Services.Implementation.Match.Commands.Delete;
using System.Threading.Tasks;

namespace FootballLeague.Services.Implementation.Match.CommandHandlers.Delete
{
    public sealed class DeleteMatchByIdCommandHandler : ICommandHandlerAsync<DeleteMatchByIdCommand, DeleteEntityByIdResult<SportMatch>>
    {
        private const string DELETE_MATCH_BY_ID_ERROR_MESSAGE = "Failed to delete match with ID: {0}, please try again or contact the support team.";

        private readonly IValidator<int> matchIdValidator;
        private readonly IAsyncQueryHandler<EntityByIdDatabaseQuery<EntityByIdDatabaseResult<SportMatch>>, EntityByIdDatabaseResult<SportMatch>> teamByIdHandler;
        private readonly ICommandHandlerAsync<DeleteEntityByIdDatabaseCommand<SportMatch>, IResult> deleteMatchByIdHandler;

        public DeleteMatchByIdCommandHandler(IValidator<int> matchIdValidator, IAsyncQueryHandler<EntityByIdDatabaseQuery<EntityByIdDatabaseResult<SportMatch>>, EntityByIdDatabaseResult<SportMatch>> teamByIdHandler, ICommandHandlerAsync<DeleteEntityByIdDatabaseCommand<SportMatch>, IResult> deleteMatchByIdHandler)
        {
            this.matchIdValidator = matchIdValidator;
            this.teamByIdHandler = teamByIdHandler;
            this.deleteMatchByIdHandler = deleteMatchByIdHandler;
        }

        public async Task<DeleteEntityByIdResult<SportMatch>> Handle(DeleteMatchByIdCommand command)
        {
            var validationResult = this.matchIdValidator.Validate(command.InputModel.Id);
            if (!validationResult.Succeed) return new DeleteEntityByIdResult<SportMatch>(validationResult.Message);

            var getMatchResult = await this.teamByIdHandler.Handle(new MatchByIdDatabaseQuery(command.InputModel.Id));
            if (!getMatchResult.Succeed) return new DeleteEntityByIdResult<SportMatch>(getMatchResult.Message);

            var deletionResult = await this.deleteMatchByIdHandler.Handle(new DeleteMatchByIdDatabaseCommand(getMatchResult.Entity));
            if (!deletionResult.Succeed) return new DeleteEntityByIdResult<SportMatch>(DELETE_MATCH_BY_ID_ERROR_MESSAGE);

            return new DeleteEntityByIdResult<SportMatch>();
        }
    }
}
