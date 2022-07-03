using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Abstraction.CQS.Query;
using FootballLeague.Abstraction.CQS.Result;
using FootballLeague.Abstraction.Validators;
using FootballLeague.Persistence.Commands.Delete.Team;
using FootballLeague.Persistence.Queries.GetById.Team;
using FootballLeague.Persistence.Result.GetById.Team;
using FootballLeague.Services.Implementation.Team.Commands.Delete;
using FootballLeague.Services.Implementation.Team.Models.Result.Delete;
using System.Threading.Tasks;

namespace FootballLeague.Services.Implementation.Team.CommandHandlers.Delete
{
    public sealed class DeleteTeamByIdCommandHandler : ICommandHandlerAsync<DeleteTeamByIdCommand, DeleteTeamByIdResult>
    {
        private const string TEAM_BY_ID_ERROR_MESSAGE = "Failed to delete team with ID: {0}, please try again or contact the support team.";

        private readonly IValidator<int> teamIdValidator;
        private readonly ICommandHandlerAsync<DeleteTeamDatabaseCommand, IResult> deleteTeamHandler;
        private readonly IAsyncQueryHandler<TeamByIdDatabaseQuery, TeamByIdDatabaseResult> teamByIdHandler;

        public DeleteTeamByIdCommandHandler(IValidator<int> teamIdValidator, ICommandHandlerAsync<DeleteTeamDatabaseCommand, IResult> deleteTeamHandler, IAsyncQueryHandler<TeamByIdDatabaseQuery, TeamByIdDatabaseResult> teamByIdHandler)
        {
            this.teamIdValidator = teamIdValidator;
            this.deleteTeamHandler = deleteTeamHandler;
            this.teamByIdHandler = teamByIdHandler;
        }

        public async Task<DeleteTeamByIdResult> Handle(DeleteTeamByIdCommand command)
        {
            var validationResult = this.teamIdValidator.Validate(command.InputModel.Id);
            if (!validationResult.Succeed) return new DeleteTeamByIdResult(validationResult.Message);

            var getTeamResult = await this.teamByIdHandler.Handle(new TeamByIdDatabaseQuery(command.InputModel.Id));
            if(getTeamResult.Entity is null) return new DeleteTeamByIdResult("Team does not exist");

            var deletionResult = await this.deleteTeamHandler.Handle(new DeleteTeamDatabaseCommand(getTeamResult.Entity));
            if (!deletionResult.Succeed) return new DeleteTeamByIdResult(string.Format(TEAM_BY_ID_ERROR_MESSAGE, command.InputModel.Id));

            return new DeleteTeamByIdResult();
        }
    }
}
