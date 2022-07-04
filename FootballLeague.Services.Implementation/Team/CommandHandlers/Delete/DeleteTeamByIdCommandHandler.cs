using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Abstraction.CQS.Query;
using FootballLeague.Abstraction.CQS.Result;
using FootballLeague.Abstraction.Validators;
using FootballLeague.Data.Models.Team;
using FootballLeague.Persistence.Commands.Delete.Team;
using FootballLeague.Persistence.Queries.GetById;
using FootballLeague.Persistence.Queries.GetById.Team;
using FootballLeague.Services.Implementation.Common.Results.Delete;
using FootballLeague.Services.Implementation.Team.Commands.Delete;
using System.Threading.Tasks;

namespace FootballLeague.Services.Implementation.Team.CommandHandlers.Delete
{
    public sealed class DeleteTeamByIdCommandHandler : ICommandHandlerAsync<DeleteTeamByIdCommand, DeleteEntityByIdResult<SportTeam>>
    {
        private const string DELETE_TEAM_BY_ID_ERROR_MESSAGE = "Failed to delete team with ID: {0}, please try again or contact the support team.";

        private readonly IValidator<int> teamIdValidator;
        private readonly ICommandHandlerAsync<DeleteTeamDatabaseCommand, IResult> deleteTeamHandler;
        private readonly IAsyncQueryHandler<EntityByIdDatabaseQuery<EntityByIdDatabaseResult<SportTeam>>, EntityByIdDatabaseResult<SportTeam>> teamByIdHandler;

        public DeleteTeamByIdCommandHandler(IValidator<int> teamIdValidator, ICommandHandlerAsync<DeleteTeamDatabaseCommand, IResult> deleteTeamHandler, IAsyncQueryHandler<EntityByIdDatabaseQuery<EntityByIdDatabaseResult<SportTeam>>, EntityByIdDatabaseResult<SportTeam>> teamByIdHandler)
        {
            this.teamIdValidator = teamIdValidator;
            this.deleteTeamHandler = deleteTeamHandler;
            this.teamByIdHandler = teamByIdHandler;
        }

        public async Task<DeleteEntityByIdResult<SportTeam>> Handle(DeleteTeamByIdCommand command)
        {
            var validationResult = this.teamIdValidator.Validate(command.InputModel.Id);
            if (!validationResult.Succeed) return new DeleteEntityByIdResult<SportTeam>(validationResult.Message);

            var getTeamResult = await this.teamByIdHandler.Handle(new TeamByIdDatabaseQuery(command.InputModel.Id));
            if (!getTeamResult.Succeed) return new DeleteEntityByIdResult<SportTeam>(getTeamResult.Message);

            var deletionResult = await this.deleteTeamHandler.Handle(new DeleteTeamDatabaseCommand(getTeamResult.Entity));
            if (!deletionResult.Succeed) return new DeleteEntityByIdResult<SportTeam>(string.Format(DELETE_TEAM_BY_ID_ERROR_MESSAGE, command.InputModel.Id));

            return new DeleteEntityByIdResult<SportTeam>();
        }
    }
}
