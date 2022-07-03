using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Abstraction.CQS.Query;
using FootballLeague.Abstraction.CQS.Result;
using FootballLeague.Abstraction.Validators;
using FootballLeague.Persistence.Commands.Update;
using FootballLeague.Persistence.Queries.GetById.Team;
using FootballLeague.Persistence.Result.GetById.Team;
using FootballLeague.Services.Implementation.Team.Commands.Update;
using FootballLeague.Services.Implementation.Team.Models.Result.Update;
using System.Threading.Tasks;

namespace FootballLeague.Services.Implementation.Team.CommandHandlers.Update
{
    public sealed class UpdateTeamTotalSeasonScoreCommandHandler : ICommandHandlerAsync<UpdateTeamTotalSeasonScoreCommand, UpdateTeamTotalSeasonScoreResult>
    {
        private readonly IValidator<int> teamIdValidator;
        private readonly IAsyncQueryHandler<TeamByIdDatabaseQuery, TeamByIdDatabaseResult> teamByIdHandler;
        private readonly ICommandHandlerAsync<UpdateSportTeamDatabaseCommand, IResult> updateTeamdHandler;

        public UpdateTeamTotalSeasonScoreCommandHandler(IValidator<int> teamIdValidator, IAsyncQueryHandler<TeamByIdDatabaseQuery, TeamByIdDatabaseResult> teamByIdHandler, ICommandHandlerAsync<UpdateSportTeamDatabaseCommand, IResult> updateTeamdHandler)
        {
            this.teamIdValidator = teamIdValidator;
            this.teamByIdHandler = teamByIdHandler;
            this.updateTeamdHandler = updateTeamdHandler;
        }

        public async Task<UpdateTeamTotalSeasonScoreResult> Handle(UpdateTeamTotalSeasonScoreCommand command)
        {
            var validationResult = this.teamIdValidator.Validate(command.InputModel.Id);
            if (!validationResult.Succeed) return new UpdateTeamTotalSeasonScoreResult(validationResult.Message);

            var getTeamResult = await this.teamByIdHandler.Handle(new TeamByIdDatabaseQuery(command.InputModel.Id));
            if (getTeamResult.Entity is null) return new UpdateTeamTotalSeasonScoreResult("Team does not exist");

            var updateResult = await this.updateTeamdHandler.Handle(new UpdateSportTeamDatabaseCommand(getTeamResult.Entity, command.InputModel.MatchScore));
            if (!updateResult.Succeed) return new UpdateTeamTotalSeasonScoreResult("Failed to update SportTeam");

            return new UpdateTeamTotalSeasonScoreResult();
        }
    }
}
