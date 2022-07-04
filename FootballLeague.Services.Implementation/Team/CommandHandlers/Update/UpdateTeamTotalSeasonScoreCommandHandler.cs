using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Abstraction.CQS.Query;
using FootballLeague.Abstraction.CQS.Result;
using FootballLeague.Abstraction.Validators;
using FootballLeague.Data.Models.Team;
using FootballLeague.Persistence.Commands.Update;
using FootballLeague.Persistence.Queries.GetById;
using FootballLeague.Persistence.Queries.GetById.Team;
using FootballLeague.Services.Implementation.Common.Results.Update;
using FootballLeague.Services.Implementation.Team.Commands.Update;
using System.Threading.Tasks;

namespace FootballLeague.Services.Implementation.Team.CommandHandlers.Update
{
    public sealed class UpdateTeamTotalSeasonScoreCommandHandler : ICommandHandlerAsync<UpdateTeamTotalSeasonScoreCommand, UpdateEntityResult>
    {
        private readonly IValidator<int> teamIdValidator;
        private readonly IAsyncQueryHandler<EntityByIdDatabaseQuery<EntityByIdDatabaseResult<SportTeam>>, EntityByIdDatabaseResult<SportTeam>> teamByIdHandler;
        private readonly ICommandHandlerAsync<UpdateSportTeamDatabaseCommand, IResult> updateTeamdHandler;

        public UpdateTeamTotalSeasonScoreCommandHandler(IValidator<int> teamIdValidator, IAsyncQueryHandler<EntityByIdDatabaseQuery<EntityByIdDatabaseResult<SportTeam>>, EntityByIdDatabaseResult<SportTeam>> teamByIdHandler, ICommandHandlerAsync<UpdateSportTeamDatabaseCommand, IResult> updateTeamdHandler)
        {
            this.teamIdValidator = teamIdValidator;
            this.teamByIdHandler = teamByIdHandler;
            this.updateTeamdHandler = updateTeamdHandler;
        }

        public async Task<UpdateEntityResult> Handle(UpdateTeamTotalSeasonScoreCommand command)
        {
            var validationResult = this.teamIdValidator.Validate(command.InputModel.Id);
            if (!validationResult.Succeed) return new UpdateEntityResult(validationResult.Message);

            var getTeamResult = await this.teamByIdHandler.Handle(new TeamByIdDatabaseQuery(command.InputModel.Id));
            if (!getTeamResult.Succeed) return new UpdateEntityResult(getTeamResult.Message);

            var updateResult = await this.updateTeamdHandler.Handle(new UpdateSportTeamDatabaseCommand(getTeamResult.Entity, command.InputModel.MatchScore));
            if (!updateResult.Succeed) return new UpdateEntityResult("Failed to update SportTeam");

            return new UpdateEntityResult();
        }
    }
}
